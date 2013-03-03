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

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Decompiler.Core.Types
{
	/// <summary>
	/// Compares two data types to see if they are equal or
	/// less than each other.
	/// </summary>
	public class DataTypeComparer : IComparer<DataType>, IDataTypeVisitor<int>
	{
		private const int Prim  =  0;
		private const int Ptr =    1;
		private const int MemPtr = 2;
		private const int Fn =     3;
		private const int Array =  4;
		private const int Struct = 5;
		private const int Union =  6;
		private const int TVar =   7;
		private const int EqClass= 8;
		private const int Unk =    9;

		public DataTypeComparer()
		{
		}

		public int Compare(DataType x, DataType y)
		{
			return Compare(x, y, 0);
		}

		/// <summary>
		/// Implements a partial ordering on data types, where 
		/// primitives &lt; pointers &lt; arrays &lt; structs &lt; unions
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(DataType x, DataType y, int count)
		{
			if (count > 20)
				throw new ApplicationException("Way too deep");
			int prioX = x.Accept(this);
			int prioY = y.Accept(this);
			int dPrio = prioX - prioY;
			if (dPrio != 0)
				return dPrio;

			PrimitiveType ix = x as PrimitiveType;
			PrimitiveType iy = y as PrimitiveType;
			if (ix != null && iy != null)
			{
				return ix.Compare(iy);
			}
			if (ix != null)
				return -1;
			if (iy != null)
				return 1;
			
			TypeVariable tx = x as TypeVariable;
			TypeVariable ty = y as TypeVariable;
			if (tx != null && ty != null)
			{
				return tx.Number - ty.Number;
			}

			EquivalenceClass ex = x as EquivalenceClass;
			EquivalenceClass ey = y as EquivalenceClass;
			if (ex != null && ey != null)
			{
				return ex.Number - ey.Number;
			}

			Pointer ptrX = x as Pointer;
			Pointer ptrY = y as Pointer;
			if (ptrX != null && ptrY != null)
			{
				return Compare(ptrX.Pointee, ptrY.Pointee, ++count);
			}

			MemberPointer mX = x as MemberPointer;
			MemberPointer mY = y as MemberPointer;
			if (mX != null && mY != null)
			{
				int d = Compare(mX.BasePointer, mY.BasePointer, ++count);
				if (d != 0)
					return d;
				return Compare(mX.Pointee, mY.Pointee, ++count);
			}

			StructureType sX = x as StructureType;
			StructureType sY = y as StructureType;
			if (sX != null && sY != null)
			{
				return Compare(sX, sY, ++count);
			}

			UnionType ux = x as UnionType;
			UnionType uy = y as UnionType;
			if (ux != null && uy != null)
			{
				return Compare(ux, uy, ++count);
			}
			ArrayType ax = x as ArrayType;
			ArrayType ay = y as ArrayType;
			if (ax != null && ay != null)
			{
				return Compare(ax, ay, ++count);
			}
			throw new NotImplementedException(string.Format("NYI: comparison between {0} and {1}", x.GetType(), y.GetType()));
		}

		public int Compare(UnionType x, UnionType y, int count)
		{
			int d;
			d = x.Alternatives.Count - y.Alternatives.Count;
			if (d != 0)
				return d;
			++count;
            for (int i = 0; i < x.Alternatives.Count; ++i)
            {
				UnionAlternative ax = x.Alternatives.Values[0];
                UnionAlternative ay = y.Alternatives.Values[0];
				d = Compare(ax.DataType, ay.DataType, count);
				if (d != 0)
					return d;
			}
			return 0;
		}

		public int Compare(ArrayType x, ArrayType y, int count)
		{
			int d = Compare(x.ElementType, y.ElementType, ++count);
			if (d != 0)
				return d;
			return x.Length - y.Length;
		}

		public int Compare(StructureType x, StructureType y, int count)
		{
			int d;
			if (x.Size > 0 && y.Size > 0)
			{
				d = x.Size - y.Size;
				if (d != 0)
					return d;
			}
			d = x.Fields.Count - y.Fields.Count;
			if (d != 0)
				return d;

			++count;
			IEnumerator<StructureField> ex = x.Fields.GetEnumerator();
            IEnumerator<StructureField> ey = y.Fields.GetEnumerator();
			while (ex.MoveNext())
			{
				ey.MoveNext();
				StructureField fx = ex.Current;
				StructureField fy = ey.Current;
				d = fx.Offset - fy.Offset;
				if (d != 0)
					return d;
				d = Compare(fx.DataType, fy.DataType, count);
				if (d != 0)
					return d;
			}
			return 0;
		}

		#region IDataTypeVisitor Members /////////////////////////////////////////

		public int VisitArray(ArrayType at)
		{
			return Array;
		}

		public int VisitEquivalenceClass(EquivalenceClass eq)
		{
			return EqClass;
		}

		public int VisitFunctionType(FunctionType ft)
		{
			return Fn;
		}

		public int VisitMemberPointer(MemberPointer memptr)
		{
			return MemPtr;
		}

		public int VisitPrimitive(PrimitiveType pt)
		{
			return Prim;
		}

		public int VisitStructure(StructureType str)
		{
			return Struct;
		}

		public int VisitPointer(Pointer ptr)
		{
			return Ptr;
		}

		public int VisitTypeVar(TypeVariable tv)
		{
			return TVar;
		}

		public int VisitUnion(UnionType ut)
		{
			return Union;
		}

		public int VisitUnknownType(UnknownType ut)
		{
			return Unk;
		}

		#endregion
	}
}
