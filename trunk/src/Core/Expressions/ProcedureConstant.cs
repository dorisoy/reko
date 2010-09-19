#region License
/* 
 * Copyright (C) 1999-2010 John K�ll�n.
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

using Decompiler.Core.Types;
using System;

namespace Decompiler.Core.Expressions
{
	public class ProcedureConstant : Expression
	{
		private ProcedureBase proc;

		public ProcedureConstant(PrimitiveType ptrType, ProcedureBase proc) : base(ptrType)
		{
			this.proc = proc;
		}

		public override Expression Accept(IExpressionTransformer xform)
		{
			return xform.TransformProcedureConstant(this);
		}

		public override void Accept(IExpressionVisitor visit)
		{
			visit.VisitProcedureConstant(this);
		}

		public ProcedureBase Procedure
		{
			get { return proc; }
		}

		public override Expression CloneExpression()
		{
			throw new NotImplementedException();
		}

	}
}
