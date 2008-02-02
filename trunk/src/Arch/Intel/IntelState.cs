/* 
 * Copyright (C) 1999-2008 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Types;
using System;
using System.Collections;

namespace Decompiler.Arch.Intel
{
	public class IntelState : ProcessorState
	{
		private ulong [] regs;
		private bool [] valid;
		private Stack stack;

		public IntelState()
		{
			regs = new ulong[(int)Registers.Max];
			valid = new bool[(int)Registers.Max];
			stack = new Stack();
		}

		public IntelState(IntelState st)
		{
			regs = (ulong []) st.regs.Clone();
			valid = (bool []) st.valid.Clone();
			stack = (Stack) st.stack.Clone();
		}

		public Address AddressFromSegOffset(MachineRegister seg, uint offset)
		{
			Constant c = GetV(seg);
			if (c.IsValid)
			{
				return new Address((ushort) c.ToUInt32(), offset & 0xFFFF);
			}
			else
				return null;
		}

		public Address AddressFromSegReg(MachineRegister seg, IntelRegister reg)
		{
			Constant c = GetV(reg);
			if (c.IsValid)
			{
				return AddressFromSegOffset(seg, c.ToUInt32());
			}
			else 
				return null;
		}

		public override object Clone()
		{
			return new IntelState(this);
		}

		public override void Set(MachineRegister reg, Constant c)
		{
			if (!c.IsValid)
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
			Set(Registers.cs, new Constant(PrimitiveType.Word16, addr.seg));
		}

		public override Constant GetV(MachineRegister reg)
		{
			if (valid[reg.Number])
				return new Constant(reg.DataType, regs[reg.Number]);
			else
				return Constant.Invalid;
		}

		public Constant Pop(PrimitiveType t)
		{
			try
			{
				switch (t.Size)
				{
				default:
					throw new ArgumentOutOfRangeException("t");
				case 2:
					if (stack.Count < 1)
					{
						System.Diagnostics.Debug.WriteLine("bad pop");
						return Constant.Invalid;
					}
					return (Constant) stack.Pop();
				case 4:
					if (stack.Count < 2)
					{
						System.Diagnostics.Debug.WriteLine("bad pop");
						return Constant.Invalid;
					}
					Constant v = (Constant) stack.Pop();
					Constant v2 = (Constant) stack.Pop();
					if (v.IsValid && v2.IsValid)
					{
						return new Constant(t, (v.ToUInt32() & 0x0000FFFF) | (v2.ToUInt32() << 16));
					}
					else
					{
						return Constant.Invalid;
					}
				}
			}
			catch (InvalidOperationException)
			{
				//$NYI:				Log.Warn("Stack underflow");
				return Constant.Invalid;
			}
		}

		public void Push(PrimitiveType t, Constant c)
		{
			switch (t.Size)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case 1:
			case 2:
				stack.Push(c);
				break;
			case 4:
				if (!c.IsValid)
				{
					stack.Push(c);
					stack.Push(c);
				}				 
				else
				{
					//$REVIEW: we lose type information here, change stack model to sortedlist.
					//$BUG: 64-bit constants?
					stack.Push(new Constant(PrimitiveType.Word16, c.ToUInt32() >> 16));
					stack.Push(new Constant(PrimitiveType.Word16, c.ToUInt32() & 0xFFFF));
				}
				break;
			}
		}
	}
}
