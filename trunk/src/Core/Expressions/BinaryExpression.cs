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

using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using System;
using System.IO;

namespace Decompiler.Core.Expressions
{
	public class BinaryExpression : Expression
	{

		public BinaryExpression(BinaryOperator op, DataType dt, Expression left, Expression right) : base(dt)
		{
			this.Operator = op;
			this.Left = left;
			this.Right = right;
		}

        public BinaryOperator Operator { get; set; } 
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public override Expression Accept(IExpressionTransformer xform)
		{
			return xform.TransformBinaryExpression(this);
		}

        public override T Accept<T>(ExpressionVisitor<T> v)
        {
            return v.VisitBinaryExpression(this);
        }

		public override void Accept(IExpressionVisitor v)
		{
			v.VisitBinaryExpression(this);
		}

		public override Expression CloneExpression()
		{
			return new BinaryExpression(Operator, DataType, Left.CloneExpression(), Right.CloneExpression());
		}

        /// <summary>
        /// Creates a BinaryExpression with the operands commuted.
        /// </summary>
        /// <returns></returns>
        public BinaryExpression Commute()
        {
            return new BinaryExpression(
                Operator,
                DataType,
                Right,
                Left);
        }

		public bool Commutes()
		{
			return Commutes(Operator);
		}

		public static bool Commutes(BinaryOperator op)
		{
			return op == Operators.Operator.Add ||
                op == Operators.Operator.And ||
                op == Operators.Operator.Muls ||
                op == Operators.Operator.Mulu ||
                op == Operators.Operator.Mul ||
                op == Operators.Operator.Or ||
                op == Operators.Operator.Xor;
		}

		public override Expression Invert()
		{
            if (Operator == Operators.Operator.Cand)
                return new BinaryExpression(Operators.Operator.Cor, this.DataType, Left.Invert(), Right.Invert());
            if (Operator == Operators.Operator.Cor)
                return new BinaryExpression(Operators.Operator.Cand, this.DataType, Left.Invert(), Right.Invert());
            if (Operator == Operators.Operator.Le)
                return new BinaryExpression(Operators.Operator.Gt, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Lt)
                return new BinaryExpression(Operators.Operator.Ge, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Ge)
                return new BinaryExpression(Operators.Operator.Lt, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Gt)
                return new BinaryExpression(Operators.Operator.Le, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Ule)
                return new BinaryExpression(Operators.Operator.Ugt, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Ult)
                return new BinaryExpression(Operators.Operator.Uge, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Uge)
                return new BinaryExpression(Operators.Operator.Ult, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Ugt)
                return new BinaryExpression(Operators.Operator.Ule, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Eq)
                return new BinaryExpression(Operators.Operator.Ne, this.DataType, Left, Right);
            if (Operator == Operators.Operator.Ne)
                return new BinaryExpression(Operators.Operator.Eq, this.DataType, Left, Right);
			throw new NotImplementedException();
		}

	}
}
