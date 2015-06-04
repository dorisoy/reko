#region License
/* 
 * Copyright (C) 1999-2015 John K�ll�n.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

using Decompiler.Arch.X86;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.Core;
using System;

namespace Decompiler.Arch.X86
{
    /// <summary>
    /// Helper class used by the X86 rewriter to turn machine code operands into
    /// IL expressions.
    /// </summary>
    public abstract class OperandRewriter
    {
        private readonly IntelArchitecture arch;
        private readonly Frame frame;
        private readonly IRewriterHost host;

        public OperandRewriter(IntelArchitecture arch, Frame frame, IRewriterHost host)
        {
            this.arch = arch;
            this.frame = frame;
            this.host = host;
        }

        public Expression Transform(IntelInstruction instr, MachineOperand op, PrimitiveType opWidth, X86State state)
        {
            var reg = op as RegisterOperand;
            if (reg != null)
                return AluRegister(reg);
            var mem = op as MemoryOperand;
            if (mem != null)
                return CreateMemoryAccess(instr, mem, opWidth, state);
            var imm = op as ImmediateOperand;
            if (imm != null)
                return CreateConstant(imm, opWidth);
            var fpu = op as FpuOperand;
            if (fpu != null)
                return FpuRegister(fpu.StNumber, state);
            var addr = op as AddressOperand;
            if (addr != null)
                return addr.Address;
            throw new NotImplementedException(string.Format("Operand {0}", op));
        }

        public Identifier AluRegister(RegisterOperand reg)
        {
            return frame.EnsureRegister(reg.Register);
        }

        public Identifier AluRegister(RegisterStorage reg)
        {
            return frame.EnsureRegister(reg);
        }

        public Identifier AluRegister(IntelRegister reg, PrimitiveType vt)
        {
            return frame.EnsureRegister(reg.GetPart(vt));
        }

        public Constant CreateConstant(ImmediateOperand imm, PrimitiveType dataWidth)
        {
            if (dataWidth.BitSize > imm.Width.BitSize)
                return Constant.Create(dataWidth, imm.Value.ToInt64());
            else
                return Constant.Create(imm.Width, imm.Value.ToUInt32());
        }

        public Expression CreateMemoryAccess(IntelInstruction instr, MemoryOperand mem, DataType dt, X86State state)
        {
            var exp = ImportedProcedureName(instr.Address, mem.Width, mem);
            if (exp != null)
                return new ProcedureConstant(arch.PointerType, exp);

            Expression expr = EffectiveAddressExpression(instr, mem, state);
            if (IsSegmentedAccessRequired ||
                (mem.DefaultSegment != Registers.ds && mem.DefaultSegment != Registers.ss))
            {
                Expression seg = ReplaceCodeSegment(mem.DefaultSegment, state);
                if (seg == null)
                    seg = AluRegister(mem.DefaultSegment);
                return new SegmentedAccess(MemoryIdentifier.GlobalMemory, seg, expr, dt);
            }
            else
            {
                return new MemoryAccess(MemoryIdentifier.GlobalMemory, expr, dt);
            }
        }

        public virtual bool IsSegmentedAccessRequired { get { return false; } }

        public Expression CreateMemoryAccess(IntelInstruction instr, MemoryOperand memoryOperand, X86State state)
        {
            return CreateMemoryAccess(instr, memoryOperand, memoryOperand.Width, state);
        }

        public virtual MemoryAccess StackAccess(Expression expr, DataType dt)
        {
            return new MemoryAccess(MemoryIdentifier.GlobalMemory, expr, dt);
        }

        /// <summary>
        /// Memory accesses are translated into expressions.
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Expression EffectiveAddressExpression(IntelInstruction instr, MemoryOperand mem, X86State state)
        {
            Expression eIndex = null;
            Expression eBase = null;
            Expression expr = null;
            PrimitiveType type = PrimitiveType.CreateWord(mem.Width.Size);
            bool ripRelative = false;

            if (mem.Base != RegisterStorage.None)
            {
                if (mem.Base == Registers.rip)
                {
                    ripRelative = true;
                }
                else
                {
                    eBase = AluRegister(mem.Base);
                    if (expr != null)
                    {
                        expr = new BinaryExpression(Operator.IAdd, eBase.DataType, eBase, expr);
                    }
                    else
                    {
                        expr = eBase;
                    }
                }
            }

            if (mem.Offset.IsValid)
            {
                if (ripRelative)
                {
                    expr = instr.Address + (instr.Length + mem.Offset.ToInt64());
                }
                else if (expr != null)
                {
                    BinaryOperator op = Operator.IAdd;
                    long l = mem.Offset.ToInt64();
                    if (l < 0 && l > -0x800)
                    {
                        l = -l;
                        op = Operator.ISub;
                    }

                    DataType dt = (eBase != null) ? eBase.DataType : eIndex.DataType;
                    Constant cOffset = Constant.Create(dt, l);
                    expr = new BinaryExpression(op, dt, expr, cOffset);
                }
                else
                {
                    expr = mem.Offset;
                }
            }

            if (mem.Index != RegisterStorage.None)
            {
                eIndex = AluRegister(mem.Index);
                if (mem.Scale != 0 && mem.Scale != 1)
                {
                    eIndex = new BinaryExpression(
                        Operator.IMul, eIndex.DataType, eIndex, Constant.Create(mem.Width, mem.Scale));
                }
                expr = new BinaryExpression(Operator.IAdd, expr.DataType, expr, eIndex);
            }
            return expr;
        }

        public Identifier FlagGroup(FlagM flags)
        {
            return frame.EnsureFlagGroup((uint)flags, arch.GrfToString((uint)flags), PrimitiveType.Byte);
        }


        /// <summary>
        /// Changes the stack-relative address 'reg' into a frame-relative operand.
        /// If the register number is larger than the stack depth, then
        /// the register was passed on the stack when the function was called.
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Identifier FpuRegister(int reg, X86State state)
        {
            return frame.EnsureFpuStackVariable(reg - state.FpuStackItems, PrimitiveType.Real64);
        }

        public ExternalProcedure ImportedProcedureName(Address addrInstruction, PrimitiveType addrWidth, MemoryOperand mem)
        {
            if (mem != null && addrWidth == PrimitiveType.Word32 && mem.Base == RegisterStorage.None &&
                mem.Index == RegisterStorage.None)
            {
                return host.GetImportedProcedure(Address.Ptr32(mem.Offset.ToUInt32()), addrInstruction);
            }
            return null;
        }

        public Constant ReplaceCodeSegment(RegisterStorage reg, X86State state)
        {
            if (reg == Registers.cs && arch.WordWidth == PrimitiveType.Word16)
                return state.GetRegister(reg);
            else
                return null;
        }

        public UnaryExpression AddrOf(Expression expr)
        {
            return new UnaryExpression(Operator.AddrOf,
                PrimitiveType.Create(Domain.Pointer, arch.WordWidth.Size), expr);
        }

        public abstract Address ImmediateAsAddress(Address address, ImmediateOperand imm);
    }

    public class OperandRewriter16 : OperandRewriter
    {
        public OperandRewriter16(IntelArchitecture arch, Frame frame, IRewriterHost host) : base(arch, frame, host) { }

        public override bool IsSegmentedAccessRequired { get { return true; } }

        public override Address ImmediateAsAddress(Address address, ImmediateOperand imm)
        {
            return Address.SegPtr(address.Selector, imm.Value.ToUInt32());
        }

        public override MemoryAccess StackAccess(Expression expr, DataType dt)
        {
            return new SegmentedAccess(MemoryIdentifier.GlobalMemory, AluRegister(Registers.ss), expr, dt);
        }
    }

    public class OperandRewriter32 : OperandRewriter
    {
        public OperandRewriter32(IntelArchitecture arch, Frame frame, IRewriterHost host) : base(arch, frame, host) { }

        public override Address ImmediateAsAddress(Address address, ImmediateOperand imm)
        {
            return Address.Ptr32(imm.Value.ToUInt32());
        }
    }

    public class OperandRewriter64 : OperandRewriter
    {
        public OperandRewriter64(IntelArchitecture arch, Frame frame, IRewriterHost host) : base(arch, frame, host) { }

        public override Address ImmediateAsAddress(Address address, ImmediateOperand imm)
        {
            return Address.Ptr64(imm.Value.ToUInt64());
        }
    }
}
