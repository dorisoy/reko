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

namespace Decompiler.Core.Types
{
	/// <summary>
	/// Visitor methods for types.
	/// </summary>
	public interface IDataTypeVisitor
	{
		void VisitArray(ArrayType at);
		void VisitEquivalenceClass(EquivalenceClass eq);
		void VisitFunctionType(FunctionType ft);
		void VisitPrimitive(PrimitiveType pt);
		void VisitMemberPointer(MemberPointer memptr);
		void VisitPointer(Pointer ptr);
		void VisitStructure(StructureType str);
		void VisitTypeVar(TypeVariable tv);
		void VisitUnion(UnionType ut);
		void VisitUnknownType(UnknownType ut);
	}

    public interface IDataTypeVisitor<T>
    {
        T VisitArray(ArrayType at);
        T VisitEquivalenceClass(EquivalenceClass eq);
        T VisitFunctionType(FunctionType ft);
        T VisitPrimitive(PrimitiveType pt);
        T VisitMemberPointer(MemberPointer memptr);
        T VisitPointer(Pointer ptr);
        T VisitStructure(StructureType str);
        T VisitTypeVar(TypeVariable tv);
        T VisitUnion(UnionType ut);
        T VisitUnknownType(UnknownType ut);
    }
}
