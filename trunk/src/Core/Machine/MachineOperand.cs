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
using Decompiler.Core.Expressions;
using Decompiler.Core.Types;
using System;
using System.IO;
using System.Text;

namespace Decompiler.Core.Machine
{
    /// <summary>
    /// Abstraction of a processor instruction operand.
    /// </summary>
	public abstract class MachineOperand
	{
		public PrimitiveType Width;

		protected MachineOperand(PrimitiveType width)
		{
			Width = width;
		}

		public virtual string ToString(bool fExplicit)
		{
			return ToString();
		}

        public virtual void Write(bool fExplicit, TextWriter writer)
        {
            writer.Write(ToString(fExplicit));
        }

		public string FormatSignedValue(Constant c)
		{
			string s = "+";
			int tmp = c.ToInt32();
			if (tmp < 0)
			{
				s = "-";
				tmp = -tmp;
			}
			return s + tmp.ToString(FormatString(c.DataType));
		}

        public string FormatValue(Constant c)
        {
            if (((PrimitiveType)c.DataType).Domain == Domain.SignedInt)
                return FormatSignedValue(c);
            else
                return FormatUnsignedValue(c);
        }

		private string FormatString(DataType dt)
		{
			switch (dt.Size)
			{
			case 1: return "X2";
			case 2: return "X4";
			case 4: return "X8";
			case 8: return "X8";
			default: throw new InvalidOperationException();
			}
		}

		public string FormatUnsignedValue(Constant c)
		{
			return c.ToUInt32().ToString(FormatString(c.DataType));
		}

	}


	public class RegisterOperand : MachineOperand
	{
		private RegisterStorage reg;
		
		public RegisterOperand(RegisterStorage reg) :
			base(reg.DataType)
		{
			this.reg = reg;
		}

		public RegisterStorage Register
		{
			get { return reg; }
		}

		public override string ToString()
		{
			return reg.ToString();
		}
	}

	public class ImmediateOperand : MachineOperand
	{
		private Constant value;

		public ImmediateOperand(Constant c) : base((PrimitiveType)c.DataType)
		{
			value = c;
		}

		public override string ToString()
		{
			return FormatValue(value);
		}

		public Constant Value
		{
			get { return value; }
		}

        public static ImmediateOperand Byte(byte value)
        {
            return new ImmediateOperand(Constant.Byte(value));
        }

        public static ImmediateOperand Word32(int value)
        {
            return new ImmediateOperand(Constant.Word32(value));
        }

        public static ImmediateOperand Word32(uint value) { return Word32((int) value); }

    }

    //$TODO: move into intel assembly.
	public class AddressOperand : MachineOperand
	{
		public Address Address;

		public AddressOperand(Address a) : base(PrimitiveType.Pointer32)	//$BUGBUG: P6 pointers?
		{
			Address = a;
		}

		public override string ToString()
		{
			return "far " + Address.ToString();
		}
	}

	public class FpuOperand : MachineOperand
	{
		private int fpuReg;

		public FpuOperand(int f) : base(PrimitiveType.Real64)
		{
			fpuReg = f;
		}

		public int StNumber
		{
			get { return fpuReg; }
		}

		public override string ToString()
		{
			return "st(" + fpuReg + ")";
		}
	}
}


