#region License
/* 
 * Copyright (C) 1999-2012 John K�ll�n.
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
    public class OperandRewriter
    {
        private IntelArchitecture arch;
        private Frame frame;
        private IRewriterHost host;

        public OperandRewriter(IntelArchitecture arch, Frame frame, IRewriterHost host)
        {
            this.arch = arch;
            this.frame = frame;
            this.host = host;
        }


        public Expression Transform(MachineOperand op, PrimitiveType opWidth, X86State state)
        {
            var reg = op as RegisterOperand;
            if (reg != null)
                return AluRegister(reg);
            var mem = op as MemoryOperand;
            if (mem != null)
                return CreateMemoryAccess(mem, opWidth, state);
            var imm = op as ImmediateOperand;
            if (imm != null)
                return CreateConstant(imm, opWidth);
            var fpu = op as FpuOperand;
            if (fpu != null)
                return FpuRegister(fpu.StNumber, state);

            throw new NotImplementedException(string.Format("Operand {0}", op));
        }

        public Identifier AluRegister(RegisterOperand reg)
        {
            return frame.EnsureRegister(reg.Register);
        }

        public Identifier AluRegister(MachineRegister reg)
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
                return new Constant(dataWidth, imm.Value.ToInt32());
            else
                return new Constant(imm.Width, imm.Value.ToUInt32());
        }

        public Expression CreateMemoryAccess(MemoryOperand mem, DataType dt, X86State state)
        {
            PseudoProcedure ppp = ImportedProcedureName(mem.Width, mem);
            if (ppp != null)
                return new ProcedureConstant(arch.PointerType, ppp);

            Expression expr = EffectiveAddressExpression(mem, state);
            if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
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

        public Expression CreateMemoryAccess(MemoryOperand memoryOperand, X86State state)
        {
            return CreateMemoryAccess(memoryOperand, memoryOperand.Width, state);
        }

        public MemoryAccess StackAccess(Expression expr, DataType dt)
        {
            if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
            {
                return new SegmentedAccess(MemoryIdentifier.GlobalMemory, AluRegister(Registers.ss), expr, dt);
            }
            else
            {
                return new MemoryAccess(MemoryIdentifier.GlobalMemory, expr, dt);
            }
        }

        /// <summary>
        /// Memory accesses are translated into expressions.
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Expression EffectiveAddressExpression(MemoryOperand mem, X86State state)
        {
            Expression eIndex = null;
            Expression eBase = null;
            Expression expr = null;
            PrimitiveType type = PrimitiveType.CreateWord(mem.Width.Size);

            if (mem.Base != MachineRegister.None)
            {
                eBase = AluRegister(mem.Base);
                if (expr != null)
                {
                    expr = new BinaryExpression(Operator.Add, eBase.DataType, eBase, expr);
                }
                else
                {
                    expr = eBase;
                }
            }

            if (mem.Offset.IsValid)
            {
                if (expr != null)
                {
                    BinaryOperator op = Operator.Add;
                    long l = mem.Offset.ToInt64();
                    if (l < 0)
                    {
                        l = -l;
                        op = Operator.Sub;
                    }

                    DataType dt = (eBase != null) ? eBase.DataType : eIndex.DataType;
                    Constant cOffset = new Constant(dt, l);
                    expr = new BinaryExpression(op, dt, expr, cOffset);
                }
                else
                {
                    expr = mem.Offset;
                }
            }

            if (mem.Index != MachineRegister.None)
            {
                eIndex = AluRegister(mem.Index);
                if (mem.Scale != 0 && mem.Scale != 1)
                {
                    eIndex = new BinaryExpression(
                        Operator.Mul, eIndex.DataType, eIndex, new Constant(mem.Width, mem.Scale));
                }
                expr = new BinaryExpression(Operator.Add, expr.DataType, expr, eIndex);
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

        public PseudoProcedure ImportedProcedureName(PrimitiveType addrWidth, MemoryOperand mem)
        {
            if (mem != null && addrWidth == PrimitiveType.Word32 && mem.Base == MachineRegister.None &&
                mem.Index == MachineRegister.None)
            {
                return (PseudoProcedure)host.GetImportThunkAtAddress(mem.Offset.ToUInt32());
            }
            return null;
        }

        public Constant ReplaceCodeSegment(MachineRegister reg, X86State state)
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
    }















    public class OperandRewriterOld
	{
        private IRewriterHostOld host;
        private IntelArchitecture arch;
        private Frame frame;

        public OperandRewriterOld(IRewriterHostOld host, IntelArchitecture arch, Frame frame)
        {
            this.host = host;
            this.arch = arch;
            this.frame = frame;
        }

		private Address AbsoluteAddress(MemoryOperand mem)
		{
			if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
				return null;
			if (mem.Base != MachineRegister.None || mem.Index != MachineRegister.None)
				return null;
			return new Address(0, mem.Offset.ToUInt32());
		}

		public UnaryExpression AddrOf(Expression expr)
		{
			return new UnaryExpression(Operator.AddrOf, 
                PrimitiveType.Create(Domain.Pointer, arch.WordWidth.Size), expr);
		}

		public Identifier AluRegister(MachineRegister reg)
		{
			return frame.EnsureRegister(reg);
		}

		public Identifier AluRegister(IntelRegister reg, PrimitiveType vt)
		{
			return frame.EnsureRegister(reg.GetPart(vt));
		}
		
		/// <summary>
		/// Converts operands from Intel to ILCode. When registers are encountered,
		/// Variables are allocated from the procedure's frame. When stack-based or
		/// frame-based memory accesses are encountered, temporaries are allocated for
		/// them.
		/// </summary>
		/// <param name="opSrc"></param>
		/// <param name="fDefined"></param>
		/// <returns></returns>
		private Expression ConvertNonMemoryOperand(MachineOperand op, PrimitiveType dataWidth, IntelRewriterState state)
		{
			RegisterOperand reg = op as RegisterOperand;
			if (reg != null)
			{
				Constant codeSeg = ReplaceCodeSegment(reg.Register, state);
				if (codeSeg != null)
					return codeSeg;
#if NO_UNNECESSARY_ESCAPES	// A reference to the stack pointer can be left as is.
				if (IsFrameRegisterReference(reg.Register, state))
					frame.Escapes = true;
#endif
				return AluRegister(reg.Register);
			}
			ImmediateOperand imm = op as ImmediateOperand;
			if (imm != null)
			{
				if (dataWidth.BitSize > imm.Width.BitSize)
					return new Constant(dataWidth, imm.Value.ToInt32());
				else
					return new Constant(imm.Width, imm.Value.ToUInt32());
			}
			FpuOperand fpu = op as FpuOperand;
			if (fpu != null)
			{
				return FpuRegister(fpu.StNumber, state);
			}
			MemoryOperand mem = op as MemoryOperand;
			if (mem != null)
			{
				// Stack-based (or frame-based) accesses should be converted to temp variable
				// accesses, but only if there is no index register involved.

				if (IsFrameRegisterReference(mem.Base, state) && mem.Index == MachineRegister.None)
				{
					return frame.EnsureStackVariable(
						mem.Offset,
						IsStackRegister(mem.Base) 
							? state.StackBytes
                            : state.FrameOffset,      
						mem.Width);
				}
				return null;
			}
			throw new ArgumentException("Illegal operand type: " + op.GetType().Name);
		}

		public Identifier FlagGroup(FlagM flags)
		{
			return frame.EnsureFlagGroup((uint) flags, arch.GrfToString((uint)flags), PrimitiveType.Byte);
		}

		public Address OperandAsCodeAddress(MachineOperand op, IntelRewriterState state)
		{
			AddressOperand ado = op as AddressOperand;
			if (ado != null)
				return ado.Address;
			ImmediateOperand imm = op as ImmediateOperand;
			if (imm != null)
			{
				if (arch.ProcessorMode == ProcessorMode.ProtectedFlat)
				{
					return new Address(imm.Value.ToUInt32());
				}
				else
					return new Address(state.CodeSegment, imm.Value.ToUInt32());
			}
			return null;
		}

		public Expression Transform(MachineOperand opSrc, PrimitiveType dataWidth, PrimitiveType addrWidth, IntelRewriterState state)
		{
			Expression e = ConvertNonMemoryOperand(opSrc, dataWidth, state);
			if (e != null)
				return e;
			MemoryOperand mem = (MemoryOperand) opSrc;
			PseudoProcedure ppp = ImportedProcedureName(addrWidth, mem);
			if (ppp != null)
				return new ProcedureConstant(arch.PointerType, ppp);
			Address addr = AbsoluteAddress(mem);
			if (addr != null && host.Image.Map.IsReadOnlyAddress(addr) && mem.Width.Domain == Domain.Real)
			{
				if (mem.Width == PrimitiveType.Real32)
					return new Cast(PrimitiveType.Real64, host.Image.ReadLeFloat(addr));
				if (mem.Width == PrimitiveType.Real64)
					return host.Image.ReadLeDouble(addr);
			}
			return CreateMemoryAccess(mem, state);
		}

		// b => b
		// b,o => (+ b o)
		// o => o


		public MemoryAccess CreateMemoryAccess(MemoryOperand mem, IntelRewriterState state)
		{
			return CreateMemoryAccess(mem, mem.Width, state);
		}

		public MemoryAccess CreateMemoryAccess(MemoryOperand mem, DataType dt, IntelRewriterState state)
		{
			Expression expr = EffectiveAddressExpression(mem, state);
			if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
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

		public Expression EffectiveAddressExpression(MemoryOperand mem, IntelRewriterState state)
		{
			// Memory accesses are translated into expressions.

			Expression eIndex = null;
			Expression eBase = null;
			Expression expr = null;
			PrimitiveType type = PrimitiveType.CreateWord(mem.Width.Size);

			if (mem.Base != MachineRegister.None)
			{
				eBase = AluRegister(mem.Base);
				if (expr != null)
				{
					expr = new BinaryExpression(Operator.Add, eBase.DataType, eBase, expr);
				}
				else
				{
					expr = eBase;
				}
			}

			if (mem.Offset.IsValid)
			{
				if (expr != null)
				{
					BinaryOperator op = Operator.Add;
					long l = mem.Offset.ToInt64();
					if (l < 0)
					{
						l = -l;
						op = Operator.Sub;
					}
					
					DataType dt = (eBase != null) ? eBase.DataType : eIndex.DataType;
					Constant cOffset = new Constant(dt, l);
					expr = new BinaryExpression(op, dt, expr, cOffset);
				}
				else
				{
					expr = mem.Offset;
				}
			}

			if (mem.Index != MachineRegister.None)
			{
				eIndex = AluRegister(mem.Index);
				if (mem.Scale != 0 && mem.Scale != 1)
				{
					eIndex = new BinaryExpression(
						Operator.Mul, eIndex.DataType, eIndex, new Constant(mem.Width, mem.Scale));
				}
				if (IsFrameRegisterReference(mem.Base, state))
				{
					frame.Escapes = true;
					Identifier fp = frame.FramePointer;
					int cbOffset = mem.Offset.IsValid ? mem.Offset.ToInt32() : 0;
					Expression fpOff = new BinaryExpression(Operator.Add, fp.DataType,
						fp,
						new Constant(fp.DataType, cbOffset -
						(IsStackRegister(mem.Base) ? state.StackBytes : frame.FrameOffset)));
					return new BinaryExpression(Operator.Add, mem.Width, fpOff, eIndex);
				}
				expr = new BinaryExpression(Operator.Add, expr.DataType, expr, eIndex);
			}
			return expr;
		}

		public MemoryAccess MemoryAccess(Expression ea, PrimitiveType width)
		{
			return new MemoryAccess(MemoryIdentifier.GlobalMemory, ea, width);
		}

		/// <summary>
		/// Changes the stack-relative address 'reg' into a frame-relative operand.
		/// If the register number is larger than the stack depth, then
		/// the register was passed on the stack when the function was called.
		/// </summary>
		/// <param name="reg"></param>
		/// <returns></returns>
		public Identifier FpuRegister(int reg, IntelRewriterState state)
		{
			return frame.EnsureFpuStackVariable(reg - state.FpuStackItems, PrimitiveType.Real64);
		}

		public PseudoProcedure ImportedProcedureName(PrimitiveType addrWidth, MemoryOperand mem)
		{
			if (mem != null && addrWidth == PrimitiveType.Word32 && mem.Base == MachineRegister.None && 
				mem.Index == MachineRegister.None)
			{
				return (PseudoProcedure) host.GetImportThunkAtAddress(new Address(mem.Offset.ToUInt32()));
			}
			return null;
		}

		public bool IsFrameRegisterReference(MachineRegister reg, IntelRewriterState state)
		{
			return IsStackRegister(reg) || 
				(state.FrameRegister != MachineRegister.None && state.FrameRegister == reg);

		}

		public static bool IsStackRegister(MachineRegister reg)
		{
			return (reg == Registers.sp || reg == Registers.esp);
		}

        [Obsolete]
		public Identifier CreateTemporary(PrimitiveType width)
		{
			return frame.CreateTemporary(width);
		}
	
		public Constant ReplaceCodeSegment(MachineRegister reg, IntelRewriterState state)
		{
			if (reg == Registers.cs && arch.WordWidth == PrimitiveType.Word16)
				return new Constant(PrimitiveType.Word16, state.CodeSegment);
			else 
				return null;

		}
	}
}
