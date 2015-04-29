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

using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Lib;
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using System;
using System.Text;
using System.Collections.Generic;

namespace Decompiler.Arch.X86
{
	public class IntelRegister : RegisterStorage
	{
		protected readonly int regDword;
		protected readonly int regWord;
		protected readonly int regLoByte;
		protected readonly int regHiByte;
		protected bool isBaseRegister;

		public IntelRegister(string name, int number, PrimitiveType width, int regDword, int regWord, int regLoByte, int regHiByte)
			: base(name, number, width)
		{
			this.regDword  = regDword;
			this.regWord   = regWord;
			this.regLoByte = regLoByte;
			this.regHiByte = regHiByte;
			this.isBaseRegister = true;
		}

		public bool IsBaseRegister
		{
			get { return isBaseRegister; }
		}

		public override bool IsSubRegisterOf(RegisterStorage reg2)
		{
			if (this != reg2 &&
				0 <= Number && Number <= Registers.bh.Number&&
				0 <= reg2.Number && reg2.Number <= Registers.bh.Number)
			{
				return (agrfStrictSubRegisters[reg2.Number] & (1 << Number)) != 0;
			}
			else
				return false;
		}

		internal readonly static int[] agrfStrictSubRegisters = 
		{
			0x00110100,	0x00220200, 0x00440400, 0x00880800,		// EAX, ECX, EDX, EBX 
			0x00001000, 0x00002000, 0x00004000, 0x00008000,		// ESP, EBP, ESI, EDI
			0x00110000,	0x00220000, 0x00440000, 0x00880000,		// AX, CX, DX, BX 
			0x00000000, 0x00000000, 0x00000000, 0x00000000,		// SP, BP, SI, DI
			0x00000000, 0x00000000, 0x00000000, 0x00000000,		// AL, CL, DL, BL
			0x00000000, 0x00000000, 0x00000000, 0x00000000,		// AH, CH, DH, BH
			0x00000000, 0x00000000, 0x00000000, 0x00000000,		// CS, ES, SS, DS
			0x00000000, 0x00000000, 0x00000000, 0x00000000		// FS, GS,
		};
	}

	public class Intel32Register : IntelRegister
	{
		public Intel32Register(string name, int number, int regWord, int regHiByte, int regLoByte)
			: base(name, number, PrimitiveType.Word32, number, regWord, regHiByte, regLoByte) 
		{
		}

		public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 16)
					return Registers.GetRegister(Number + Registers.di.Number - Registers.edi.Number);
				if (size == 32)
					return this;
			}
			return null;
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word32(c.ToUInt32());
        }

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
			int w = Number + Registers.ax.Number - Registers.eax.Number;
			if (bits[w])
				return Registers.GetRegister(w);
			return null; 
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[Number] = f;
			bits[regWord] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues (registerFile, value, valid);
			int r = regWord;
			registerFile[r] = value & 0xFFFFU;
			valid[r] = true;
		}
	}

	public class Intel64Register : IntelRegister
	{
		public Intel64Register(string name, int number, int regWord, int regHiByte, int regLoByte)
			: base(name, number, PrimitiveType.Word32, number, regWord, regHiByte, regLoByte) 
		{
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word64(c.ToUInt64());
        }

		public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 16)
					return Registers.GetRegister(Number + Registers.di.Number - Registers.edi.Number);
				if (size == 32)
					return this;
			}
			return null;
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
			int w = Number + Registers.ax.Number - Registers.eax.Number;
			if (bits[w])
				return Registers.GetRegister(w);
			return null; 
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[Number] = f;
			bits[regWord] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues (registerFile, value, valid);
			int r = regWord;
			registerFile[r] = value & 0xFFFFU;
			valid[r] = true;
		}
	}

	public class Intel32AccRegister : Intel32Register
	{
		public Intel32AccRegister(string name, int number, int regWord, int regLoByte, int regHiByte)
			: base(name, number, regWord, regLoByte, regHiByte)
		{
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word32(c.ToUInt32());
        }

		public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 8)
					return Registers.GetRegister(Number + Registers.al.Number);
				if (size == 16)
					return Registers.GetRegister(Number + Registers.ax.Number);
				if (size == 32)
					return this;
			}
			if (offset == 8)
			{
				if (size == 8)
					return Registers.GetRegister(Number + Registers.ah.Number - Registers.eax.Number);
			}
			return null;
		}

		public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
            if (bits[regDword])
                return Registers.GetRegister(regDword);
			if (bits[regWord])
				return Registers.GetRegister(regWord);
			if (bits[regHiByte] && bits[regLoByte])
				return Registers.GetRegister(regWord);
			if (bits[regHiByte])
				return Registers.GetRegister(regHiByte);
			if (bits[regLoByte])
				return Registers.GetRegister(regLoByte);

			return null;
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[Number] = f;
			bits[regWord] = f;
			bits[regLoByte] = f;
			bits[regHiByte] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues (registerFile, value, valid);
			int r = regLoByte;
			registerFile[r] = value & 0xFFU;
			valid[r] = true;
			r = regHiByte;
			registerFile[r] = (value >> 8) & 0xFFU;
			valid[r] = true;

		}

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            if (isValid)
            {
                var c = ((Constant) value).ToUInt16();
                ctx[Registers.GetRegister(regLoByte)] = Constant.Byte((byte) c);
                ctx[Registers.GetRegister(regHiByte)] = Constant.Byte((byte) (c >> 8));
                ctx[Registers.GetRegister(regWord)] = Constant.Word16((ushort) c);
            }
            else
            {
                ctx[Registers.GetRegister(regLoByte)] = Constant.Invalid;
                ctx[Registers.GetRegister(regHiByte)] = Constant.Invalid;
                ctx[Registers.GetRegister(regWord)] = Constant.Invalid;
            }
        }
    }

    public class Intel64AccRegister : Intel64Register
    {
        public Intel64AccRegister(string name, int number, int regDword, int regWord, int regLoByte, int regHiByte)
            : base(name, number, regWord, regLoByte, regHiByte)
        {
        }

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word64(c.ToUInt64());
        }

        public override RegisterStorage GetSubregister(int offset, int size)
        {
            if (offset == 0)
            {
                if (size == 8)
                    return Registers.GetRegister(Number + Registers.al.Number);
                if (size == 16)
                    return Registers.GetRegister(Number + Registers.ax.Number);
                if (size == 32)
                    return Registers.GetRegister(Number + Registers.eax.Number);
                return this;
            }
            if (offset == 8)
            {
                if (size == 8)
                    return Registers.GetRegister(Number + Registers.ah.Number - Registers.eax.Number);
            }
            return null;
        }

        public override RegisterStorage GetWidestSubregister(BitSet bits)
        {
            if (bits[Number])
                return this;
            if (bits[regWord])
                return Registers.GetRegister(regWord);
            if (bits[regHiByte] && bits[regLoByte])
                return Registers.GetRegister(regWord);
            if (bits[regHiByte])
                return Registers.GetRegister(regHiByte);
            if (bits[regLoByte])
                return Registers.GetRegister(regLoByte);

            return null;
        }

        public override void SetAliases(BitSet bits, bool f)
        {
            bits[Number] = f;
            bits[regDword] = f;
            bits[regWord] = f;
            bits[regLoByte] = f;
            bits[regHiByte] = f;
        }

        public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
        {
            base.SetRegisterFileValues(registerFile, value, valid);
            int r = regLoByte;
            registerFile[r] = value & 0xFFU;
            valid[r] = true;
            r = regHiByte;
            registerFile[r] = (value >> 8) & 0xFFU;
            valid[r] = true;
        }

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            if (isValid)
            {
                var c = ((Constant) value).ToUInt16();
                ctx[Registers.GetRegister(regLoByte)] = Constant.Byte((byte) c);
                ctx[Registers.GetRegister(regHiByte)] = Constant.Byte((byte) (c >> 8));
                ctx[Registers.GetRegister(regWord)] = Constant.Word16((ushort) c);
                ctx[Registers.GetRegister(regDword)] = Constant.Word32((uint) c);
            }
            else
            {
                ctx[Registers.GetRegister(regLoByte)] = Constant.Invalid;
                ctx[Registers.GetRegister(regHiByte)] = Constant.Invalid;
                ctx[Registers.GetRegister(regWord)] = Constant.Invalid;
                ctx[Registers.GetRegister(regDword)] = Constant.Invalid;
            }
        }
    }

    public class Intel16Register : IntelRegister
    {
        public Intel16Register(string name, int number, int regDword, int regLoByte, int regHiByte)
            : base(name, number, PrimitiveType.Word16, regDword, number, regLoByte, regHiByte)
        {
        }

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word16(c.ToUInt16());
        }

        public override RegisterStorage GetSubregister(int offset, int size)
        {
            if (offset == 0)
            {
                if (size == 16)
                    return this;
            }
            return null;
        }

        public override RegisterStorage GetWidestSubregister(BitSet bits)
        {
            int dw = Number + Registers.eax.Number - Registers.ax.Number;
            if (bits[dw])
                return this;
            if (bits[Number])
                return this;
            return null;
        }

        public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
        {
            base.SetRegisterFileValues(registerFile, value, valid);
            int r = regDword;
            registerFile[r] = (uint) (registerFile[r] & ~0xFFFFU) | (value & 0xFFFFU);
        }

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            ctx[Registers.GetRegister(this.regDword)] = Constant.Invalid;
        }
    }

	public class Intel16AccRegister : Intel16Register
	{
		public Intel16AccRegister(string name, int number, int regDword, int regLoByte, int regHiByte)
			: base(name, number, regDword, regLoByte, regHiByte)
		{
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Word16(c.ToUInt16());
        }

        public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 8)
					return Registers.GetRegister(Number + Registers.al.Number - Registers.ax.Number);
				if (size >= 16)
					return this;
			}
			if (offset == 8)
			{
				if (size == 8)
					return Registers.GetRegister(Number + Registers.ah.Number - Registers.ax.Number);
			}
			return null;
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
			int dw = Number + Registers.eax.Number - Registers.ax.Number;
			if (bits[dw])
				return this;
			int h = Number + Registers.ah.Number - Registers.ax.Number;
			int l = Number + Registers.al.Number - Registers.ax.Number;
			if (bits[h] && bits[l])
				return this;
			if (bits[h])
				return Registers.GetRegister(h);
			if (bits[l])
				return Registers.GetRegister(l);

			return null;
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[regWord] = f;
			bits[regLoByte] = f;
			bits[regHiByte] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues(registerFile, value, valid);
			int r = regLoByte;
			registerFile[r] = value & 0xFFU;
			valid[r] = true;
			r = regHiByte;
			registerFile[r] = (value >> 8) & 0xFFU;
			valid[r] = true;
		}

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            if (isValid)
            {
                var c = ((Constant) value).ToUInt16();
                ctx[Registers.GetRegister(regLoByte)] = Constant.Byte((byte) c);
                ctx[Registers.GetRegister(regHiByte)] = Constant.Byte((byte) (c >> 8));
            }
            else
            {
                ctx[Registers.GetRegister(regLoByte)] = Constant.Invalid;
                ctx[Registers.GetRegister(regHiByte)] = Constant.Invalid;
            }
            ctx[Registers.GetRegister(regDword)] = Constant.Invalid;        //$REVIEW: conservative
        }
	}

	public class IntelLoByteRegister : IntelRegister
	{
		public IntelLoByteRegister(string name, int number, int regDword, int regWord, int regLoByte, int regHiByte)
			: base(name, number, PrimitiveType.Byte, regDword, regWord, regLoByte, regHiByte)
		{
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Byte(c.ToByte());
        }

        public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 8)
					return this;
			}
			return null;
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			int dw = Number + Registers.eax.Number - Registers.al.Number;
			if (bits[dw])
				return this;
			int w = Number + Registers.ax.Number - Registers.al.Number;
			if (bits[w])
				return this;

			if (bits[Number])
				return this;
			return null;
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[Number] = f;
			if (!f && bits[regWord])
				bits[regHiByte] = true;
			bits[regWord] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues(registerFile, value, valid);
			int r = regWord;
			registerFile[r] = (ulong) (registerFile[r] & ~0xFFU) | (value & 0xFF);
			valid[r] = valid[regHiByte];
			r = regDword;
			registerFile[r] = (ulong) (registerFile[r] & ~0xFFU) | (value & 0xFF);
		}

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            ctx[Registers.GetRegister(this.regWord)] = Constant.Invalid;
            ctx[Registers.GetRegister(this.regDword)] = Constant.Invalid;
        }
	}

	public class IntelHiByteRegister : IntelRegister
	{
		public IntelHiByteRegister(string name, int number, int regDword, int regWord, int regLoByte, int regHiByte)
			: base(name, number, PrimitiveType.Byte, regDword, regWord, regLoByte, regHiByte)
		{
		}

		public override int AliasOffset
		{
			get { return 8; }
		}

        protected override Expression GetSliceImpl(Constant c)
        {
            return Constant.Byte((byte)(c.ToUInt16() >> 8));
        }

        public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 16)
					return Registers.GetRegister(Number + Registers.ax.Number - Registers.ah.Number);
				if (size == 8)
					return this;
			}
			if (offset == 8)
			{
				if (size == 8)
					return this;
			}
			return null;
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			int dw = Number + Registers.eax.Number - Registers.ah.Number;
			if (bits[dw])
				return this;
			int w = Number + Registers.ax.Number - Registers.ah.Number;
			if (bits[w])
				return this;

			if (bits[Number])
				return this;

			return null;
		}

		public override void SetAliases(BitSet bits, bool f)
		{
			bits[Number] = f;
			if (!f && bits[regWord])
				bits[regLoByte] = true;
			bits[regWord] = f;
		}

		public override void SetRegisterFileValues(ulong[] registerFile, ulong value, bool[] valid)
		{
			base.SetRegisterFileValues(registerFile, value, valid);
			int r = regWord;
			registerFile[r] = (ulong) (registerFile[r] & ~0xFF00U) | (value << 8);
			valid[r] = valid[regLoByte];
			r = regDword;
			registerFile[r] = (ulong) (registerFile[r] & ~0xFF00U) | (value << 8);
		}

        public override void SetRegisterStateValues(Expression value, bool isValid, Dictionary<Storage, Expression> ctx)
        {
            base.SetRegisterStateValues(value, isValid, ctx);
            ctx[Registers.GetRegister(this.regWord)] = Constant.Invalid;
            ctx[Registers.GetRegister(this.regDword)] = Constant.Invalid;
        }
	}

	public class SegmentRegister : IntelRegister
	{
		public SegmentRegister(string name, int number)
			: base(name, number, PrimitiveType.SegmentSelector, -1, number, -1, -1)
		{
			isBaseRegister = false;
		}

        public override RegisterStorage GetSubregister(int offset, int size)
		{
			if (offset == 0)
			{
				if (size == 16)
					return this;
			}
			return null;
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
			return null;
		}
	}

	public class FlagRegister : IntelRegister
	{
		public FlagRegister(string name, int number)
			: base(name, number, PrimitiveType.Bool, -1, -1, -1, -1)
		{
			isBaseRegister = false;
		}

		public override bool IsAluRegister
		{
			get { return false; }
		}

        public override RegisterStorage GetWidestSubregister(BitSet bits)
		{
			if (bits[Number])
				return this;
			return null;
		}
	}

    public class SseRegister : RegisterStorage
    {
        public SseRegister(string name, int number)
            : base(name, number, PrimitiveType.Word128)
        {
        }
    }
}
