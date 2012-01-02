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

using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using System;
using System.Text;

namespace Decompiler.Arch.X86
{
	public class MemoryOperand : MachineOperand
	{
		public MachineRegister SegOverride  {get;set;}
        public MachineRegister Base { get; set; }
        public MachineRegister Index { get; set; }
        public byte Scale { get; set; }
		public Constant Offset {get;set;}

		public MemoryOperand(PrimitiveType width) : base(width)
		{
            SegOverride = MachineRegister.None;
			Base = MachineRegister.None;
            Index = MachineRegister.None;
            SegOverride = MachineRegister.None;
			Scale = 1;
		}

		public MemoryOperand(PrimitiveType width, Constant off) : base(width)
		{
            SegOverride = MachineRegister.None;
            Base = MachineRegister.None;
			Offset = off;
            Index = MachineRegister.None;
			Scale = 1;
		}

		public MemoryOperand(PrimitiveType width, MachineRegister @base, Constant off) : base(width)
		{
            SegOverride = MachineRegister.None;
			Base = @base;
			Offset = off;
            Index = MachineRegister.None;
			Scale = 1;
		}

		public MemoryOperand(PrimitiveType width, MachineRegister @base, MachineRegister index, byte scale,  Constant off) : base(width)
		{
            SegOverride = MachineRegister.None;
			Base = @base;
			Offset = off;
			Index = index;
			Scale = scale;
		}

		public bool IsAbsolute
		{
            get { return Offset.IsValid && Base == MachineRegister.None && Index == MachineRegister.None; }
		}

		public override string ToString()
		{
			return ToString(true);
		}

		public override string ToString(bool fExplicit)
		{
			StringBuilder sb = new StringBuilder();
			if (fExplicit)
			{
				string s;
				if (Width == PrimitiveType.Byte)
					s = "byte ptr ";
				else if (Width == PrimitiveType.Word16)
					s = "word ptr ";
				else if (Width.Size == 4)
					s = "dword ptr ";
				else if (Width == PrimitiveType.Word64)
					s = "qword ptr ";
				else if (Width == PrimitiveType.Real32)
					s = "float ptr ";
				else if (Width == PrimitiveType.Real64)
					s = "double ptr ";
				else if (Width == PrimitiveType.Real80)
					s = "tword ptr ";
				else
					throw new ArgumentOutOfRangeException();
				sb.Append(s);
			}

            if (SegOverride != MachineRegister.None)
			{
				sb.Append(SegOverride.ToString());
				sb.Append(":");
			}
			sb.Append("[");
			if (Base != MachineRegister.None)
			{
				sb.Append(Base.ToString());
			}
			else
			{
				sb.AppendFormat(FormatUnsignedValue(Offset));
			}

			if (Index != MachineRegister.None)
			{
				sb.Append("+");
				sb.Append(Index.ToString());
				if (Scale > 1)
				{
					sb.Append("*");
					sb.Append(Scale);
				}
			}
			if (Base != MachineRegister.None && Offset != null && Offset.IsValid)
			{
				if (Offset.DataType == PrimitiveType.Byte || Offset.DataType == PrimitiveType.SByte)
				{
					sb.Append(FormatSignedValue(Offset));
				}
				else
				{	
					sb.Append("+");
					sb.Append(FormatUnsignedValue(Offset));
				}
			}
			sb.Append("]");
			return sb.ToString();
		}

		/// <summary>
        /// Returns the segment to use when referring to data unless an overriding segment was specfied.
		/// </summary>
		public MachineRegister DefaultSegment
		{					 
			get 
			{
				if (SegOverride != MachineRegister.None)
					return SegOverride;
				if (Base == Registers.bp || Base == Registers.ebp || Base == Registers.sp || Base == Registers.esp)
					return Registers.ss;
				return Registers.ds;
			}
		}
	}
}
