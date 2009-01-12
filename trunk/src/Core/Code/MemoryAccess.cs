/* 
 * Copyright (C) 1999-2009 John K�ll�n.
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

namespace Decompiler.Core.Code
{
	public class MemoryAccess : Expression
	{
		public MemoryIdentifier MemoryId;
		public Expression EffectiveAddress;
		
		public MemoryAccess(Expression ea, DataType dt) : base(dt)
		{
			this.MemoryId = MemoryIdentifier.GlobalMemory;
			this.EffectiveAddress = ea;
		}

		public MemoryAccess(MemoryIdentifier id, Expression ea, DataType dt) : base(dt)
		{
			if (dt == null)
				throw new ArgumentNullException("dt");
			this.MemoryId = id;
			this.EffectiveAddress = ea;
		}

		public override void Accept(IExpressionVisitor v)
		{
			v.VisitMemoryAccess(this);
		}

		public override Expression Accept(IExpressionTransformer xform)
		{
			return xform.TransformMemoryAccess(this);
		}

		public override Expression CloneExpression()
		{
			return new MemoryAccess(EffectiveAddress.CloneExpression(), DataType);
		}
	}

	/// <summary>
	/// Segmented memory access that models x86 segmented memory adderssing.
	/// </summary>
	public class SegmentedAccess : MemoryAccess
	{
		public Expression BasePointer;			// Segment usually goes here

		public SegmentedAccess(MemoryIdentifier id, Expression basePtr, Expression ea, DataType dt) : base(id, ea, dt)
		{
			this.BasePointer = basePtr;
		}

		public override Expression Accept(IExpressionTransformer xform)
		{
			return xform.TransformSegmentedAccess(this);
		}

		public override void Accept(IExpressionVisitor visit)
		{
			visit.VisitSegmentedAccess(this);
		}

		public override Expression CloneExpression()
		{
			return new SegmentedAccess(MemoryId, BasePointer.CloneExpression(), EffectiveAddress.CloneExpression(), DataType);
		}

	}
}
