/* 
 * Copyright (C) 1999-2007 John K�ll�n.
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

using Decompiler.Core.Types;
using System;
using System.Collections;

namespace Decompiler.Typing
{
	/// <summary>
	/// Traverses all types and replaces references to type variables with 
	/// references to their equivalence class representatives.
	/// </summary>
	public class TypeVariableReplacer : DataTypeTransformer
	{
		private TypeStore store;

		public TypeVariableReplacer(TypeStore store)
		{
			this.store = store;
		}

		/// <summary>
		/// Replaces each type variable occurrence T with eq(T). 
		/// </summary>
		public void ReplaceTypeVariables()
		{
			Hashtable visited = new Hashtable();
			foreach (TypeVariable tv in store.TypeVariables)
			{
				EquivalenceClass eq = tv.Class;
				if (!visited.Contains(eq))
				{
					visited.Add(eq, eq);
					if (eq.DataType != null)
					{
						eq.DataType = eq.DataType.Accept(this);
					} 
				}
			}

			foreach (TypeVariable tv in store.TypeVariables)
			{
				tv.DataType = tv.Class;
			}
		}


		public override DataType TransformTypeVar(TypeVariable tv)
		{
			return tv.Class;
		}
	}
}
