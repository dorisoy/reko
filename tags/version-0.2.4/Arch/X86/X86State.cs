#region License
/* 
 * Copyright (C) 1999-2013 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Operators;
using Decompiler.Core.Rtl;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Decompiler.Arch.X86
{
	public class X86State : ProcessorState
	{
		private ulong [] regs;
		private bool [] valid;
        private IntelArchitecture arch;

        private const int StackItemSize = 2;

		public X86State(IntelArchitecture arch)
		{
            this.arch = arch;
			this.regs = new ulong[(int)Registers.Max];
			this.valid = new bool[(int)Registers.Max];
		}

		public X86State(X86State st) : base(st)
		{
            arch = st.arch;
            FpuStackItems = st.FpuStackItems;
            regs = (ulong[])st.regs.Clone();
			valid = (bool []) st.valid.Clone();
		}

        public override IProcessorArchitecture Architecture { get { return arch; } }
        public int FpuStackItems { get; set; }

		public Address AddressFromSegOffset(RegisterStorage seg, uint offset)
		{
			Constant c = GetRegister(seg);
			if (c.IsValid)
			{
				return new Address((ushort) c.ToUInt32(), offset & 0xFFFF);
			}
			else
				return null;
		}

        public Address AddressFromSegReg(RegisterStorage seg, RegisterStorage reg)
		{
			Constant c = GetRegister(reg);
			if (c.IsValid)
			{
				return AddressFromSegOffset(seg, c.ToUInt32());
			}
			else 
				return null;
		}

		public override ProcessorState Clone()
		{
			return new X86State(this);
		}

        public override Constant GetRegister(RegisterStorage reg)
        {
            if (valid[reg.Number])
                return new Constant(reg.DataType, regs[reg.Number]);
            else
                return Constant.Invalid;
        }

		public override void SetRegister(RegisterStorage reg, Constant c)
		{
			if (c == null || !c.IsValid)
			{
				valid[reg.Number] = false;
			}
			else
			{
				reg.SetRegisterFileValues(regs, c.ToUInt32(), valid);	//$REVIEW: AsUint64 for x86-64?
			}
		}

		public override void SetInstructionPointer(Address addr)
		{
			SetRegister(Registers.cs, new Constant(PrimitiveType.Word16, addr.Selector));
		}

        public override void OnProcedureEntered()
        {
            FpuStackItems = 0;
            SetRegister(Registers.D, Constant.False());
        }

        public override void OnProcedureLeft(ProcedureSignature sig)
        {
            sig.FpuStackDelta = FpuStackItems;     
        }

        public override CallSite OnBeforeCall(Identifier sp, int returnAddressSize)
        {
            if (returnAddressSize > 0)
            {
                var spVal = GetValue(sp);
                SetValue(
                    arch.StackRegister,
                    new BinaryExpression(
                        Operator.Sub,
                        spVal.DataType,
                        sp,
                        new Constant(
                            PrimitiveType.CreateWord(returnAddressSize),
                            returnAddressSize)));
            }
            return new CallSite(returnAddressSize, FpuStackItems);  
        }

        public override void OnAfterCall(Identifier sp, ProcedureSignature sig, ExpressionVisitor<Expression> eval)
        {
            var spReg = (RegisterStorage) sp.Storage;
            var spVal = GetValue(spReg);
            var stackOffset = SetValue(
                spReg,
                new BinaryExpression(
                    Operator.Add,
                    spVal.DataType,
                    sp,
                    new Constant(
                        PrimitiveType.CreateWord(spReg.DataType.Size),
                        sig.StackDelta)).Accept(eval));
            if (stackOffset.IsValid)
            {
                if (stackOffset.ToInt32() > 0)
                    ErrorListener("Possible stack underflow detected.");
            }
            ShrinkFpuStack(-sig.FpuStackDelta);
        }


        public bool HasSameValues(X86State st2)
        {
            for (int i = 0; i < valid.Length; ++i)
            {
                if (valid[i] != st2.valid[i])
                    return false;
                if (valid[i])
                {
                    RegisterStorage reg = Registers.GetRegister(i);
                    ulong u1 = (ulong)(regs[reg.Number] & ((1UL << reg.DataType.BitSize) - 1UL));
                    ulong u2 = (ulong)(st2.regs[reg.Number] & ((1UL << reg.DataType.BitSize) - 1UL));
                    if (u1 != u2)
                        return false;
                }
            }
            return true;
        }


		public void GrowFpuStack(Address addrInstr)
		{
			++FpuStackItems;
			if (FpuStackItems > 7)
			{
				Debug.WriteLine(string.Format("Possible FPU stack overflow at address {0}", addrInstr));	//$BUGBUG: should be an exception
			}
		}

        public void ShrinkFpuStack(int cItems)
        {
            FpuStackItems -= cItems;
        }
    }
}
