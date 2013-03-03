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
using System.IO;
using Decompiler.Core;
using Decompiler.Core.Output;
using Decompiler.Core.Types;

namespace Decompiler.Core
{
	/// <summary>
	/// Represents predefined functions or processor instructions that don't have a 
	/// C/C++ equivalent (like rotate operations).
	/// </summary>
	public class PseudoProcedure : ProcedureBase
	{
		private int arity;
        private DataType returnType;
		private ProcedureSignature sig;

		public PseudoProcedure(string name, DataType returnType, int arity) : base(name)
		{
            this.returnType = returnType;
			this.arity = arity;
		}

		public PseudoProcedure(string name, ProcedureSignature sig) : base(name)
		{
			this.sig = sig;
		}

		public int Arity
		{
			get { return sig != null ? sig.FormalArguments.Length : arity; }
		}

        public DataType ReturnType
        {
            get { return returnType; }
        }

		public override ProcedureSignature Signature
		{
			get { return sig; }
			set { throw new InvalidOperationException("Not allowed to change the signature of a PseudoProcedure."); }
		}

		public override string ToString()
		{
			if (Signature != null)
			{
                return base.ToString();
			}
			else
			{
				return string.Format("{0} {1}({2} args)", ReturnType, Name, arity);
			}
		}

	}
}
