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

using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using System;

namespace Decompiler.Typing
{
	/// <summary>
	/// Matches and picks apart component of an array access expression.
	/// </summary>
	public class ArrayExpressionMatcher
	{
		private Expression index;
		private Constant elemSize;
		private Expression arrayPtr;
        private PrimitiveType dtPointer;

		public ArrayExpressionMatcher(PrimitiveType dtPointer)
		{
            this.dtPointer = dtPointer;
		}

		public Expression ArrayPointer
		{
			get { return arrayPtr; }
		}
			
		public Constant ElementSize
		{
			get { return elemSize; }
		}

		public bool MatchMul(BinaryExpression b)
		{
			if (b.Operator == Operator.Muls || b.Operator == Operator.Mulu || b.Operator == Operator.Mul)
			{
				Constant c = b.Left as Constant;
				Expression e = b.Right;
				if (c == null)
				{
					c = b.Right as Constant;
					e = b.Left;
				}
				if (c != null)
				{
					elemSize = c;
					index = e;
					return true;
				}
			}
			if (b.Operator == Operator.Shl)
			{
				Constant c = b.Right as Constant;
				if (c != null)
				{
					elemSize = b.Operator.ApplyConstants(new Constant(b.Left.DataType, 1), c);
					index = b.Left;
					return true;
				}
			}
			return false;
		}

		public bool Match(Expression e)
		{
			elemSize = null;
			index = null;
			arrayPtr = null;

			BinaryExpression b = e as BinaryExpression;
			if (b == null)
				return false;
			if (MatchMul(b))
				return true;

			// (+ x y)
			if (b.Operator == Operator.Add)
			{
				BinaryExpression bInner = b.Left as BinaryExpression;
				if (bInner != null)
				{
					if (MatchMul(bInner))
					{
						// (+ (* i c) ptr)
						arrayPtr = b.Right;
						return true;
					}
				}
				bInner = b.Right as BinaryExpression;
				if (bInner != null)
				{
					if (MatchMul(bInner))
					{
						// (+ ptr (* i c))
						arrayPtr = b.Left;
						return true;
					}
					if (bInner.Operator == Operator.Add)
					{
						// (+ x (+ a b)) 
						BinaryExpression bbInner = bInner.Left as BinaryExpression;
						if (bbInner != null)
						{
							if (MatchMul(bbInner))
							{
								// (+ x (+ (* i c) y)) rearranges to become
								// (+ (* i c) (+ x y))

								b.Right = new BinaryExpression(
									Operator.Add, 
									b.Left.DataType,
									b.Left,
									bInner.Right);
								b.Left = bbInner;
								arrayPtr = b.Right;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public Expression Transform(Expression baseptr, DataType dtAccess)
		{
            if (baseptr != null)
            {
                arrayPtr = new MkSequence(dtPointer, baseptr, arrayPtr);
            }
			return new ArrayAccess(
                dtAccess, 
                arrayPtr,
                new BinaryExpression(
                    BinaryOperator.Mul, 
                    index.DataType,
                    index,
                    ElementSize));
		}
	}
}
