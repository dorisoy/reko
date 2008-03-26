/* 
 * Copyright (C) 1999-2008 John K�ll�n.
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

using System;

namespace Decompiler.Core.Code
{
	public interface InstructionVisitor
	{
		void VisitAssignment(Assignment a);

		void VisitBranch(Branch b);

		void VisitCallInstruction(CallInstruction ci);

		void VisitDeclaration(Declaration decl);

		void VisitDefInstruction(DefInstruction def);

		void VisitPhiAssignment(PhiAssignment phi);

		void VisitIndirectCall(IndirectCall ic);

		void VisitReturnInstruction(ReturnInstruction ret);

		void VisitSideEffect(SideEffect side);

		void VisitStore(Store store);

		void VisitSwitchInstruction(SwitchInstruction si);

		void VisitUseInstruction(UseInstruction u);
	}

	/// <summary>
	/// Useful base class when only a few of the methods of InstructionVisitor and IExpressionVisitor 
	/// are actually implemented.
	/// </summary>
	public class InstructionVisitorBase : InstructionVisitor, IExpressionVisitor
	{
		#region InstructionVisitor Members

		public virtual void VisitAssignment(Assignment a)
		{
			a.Src.Accept(this);
			a.Dst.Accept(this);
		}

		public virtual void VisitBranch(Branch b)
		{
			b.Condition.Accept(this);
		}

		public virtual void VisitCallInstruction(CallInstruction ci)
		{
		}

		public virtual void VisitDeclaration(Declaration decl)
		{
			decl.Id.Accept(this);
			if (decl.Expression != null)
				decl.Expression.Accept(this);
		}

		public virtual void VisitDefInstruction(DefInstruction def)
		{
			def.Expression.Accept(this);
		}

		public virtual void VisitPhiAssignment(PhiAssignment phi)
		{
			phi.Src.Accept(this);
			phi.Dst.Accept(this);
		}

		public virtual void VisitIndirectCall(IndirectCall ic)
		{
			ic.Callee.Accept(this);
		}

		public virtual void VisitReturnInstruction(ReturnInstruction ret)
		{
			if (ret.Value != null)
				ret.Value.Accept(this);
		}

		public virtual void VisitSideEffect(SideEffect side)
		{
			side.Expression.Accept(this);
		}

		public virtual void VisitStore(Store store)
		{
			store.Src.Accept(this);
			store.Dst.Accept(this);
		}

		public virtual void VisitSwitchInstruction(SwitchInstruction si)
		{
			si.expr.Accept(this);
		}

		public virtual void VisitUseInstruction(UseInstruction u)
		{
			u.Expression.Accept(this);
		}

		#endregion

		#region IExpressionVisitor Members

		public virtual void VisitApplication(Application appl)
		{
			for (int i = 0; i < appl.Arguments.Length; ++i)
			{
				appl.Arguments[i].Accept(this);
			}
		}

		public virtual void VisitArrayAccess(ArrayAccess acc)
		{
			acc.Index.Accept(this);
			acc.Array.Accept(this);
		}

		public virtual void VisitBinaryExpression(BinaryExpression binExp)
		{
			binExp.Left.Accept(this);
			binExp.Right.Accept(this);
		}

		public virtual void VisitCast(Cast cast)
		{
			cast.Expression.Accept(this);
		}

		public virtual void VisitConditionOf(ConditionOf cof)
		{
			cof.Expression.Accept(this);
		}

		public virtual void VisitConstant(Constant c)
		{
		}

		public virtual void VisitDepositBits(DepositBits d)
		{
			d.Source.Accept(this);
			d.InsertedBits.Accept(this);
		}

		public virtual void VisitDereference(Dereference deref)
		{
			deref.Expression.Accept(this);
		}

		public virtual void VisitFieldAccess(FieldAccess acc)
		{
			acc.structure.Accept(this);
		}

		public virtual void VisitMemberPointerSelector(MemberPointerSelector mps)
		{
			mps.BasePointer.Accept(this);
			mps.MemberPointer.Accept(this);
		}

		public virtual void VisitMemoryAccess(MemoryAccess access)
		{
			access.EffectiveAddress.Accept(this);
			access.MemoryId.Accept(this);
		}

		public virtual void VisitMkSequence(MkSequence seq)
		{
			seq.Head.Accept(this);
			seq.Tail.Accept(this);
		}

		public virtual void VisitIdentifier(Identifier id)
		{
		}

		public virtual void VisitPhiFunction(PhiFunction phi)
		{
			for (int i = 0; i < phi.Arguments.Length; ++i)
			{
				phi.Arguments[i].Accept(this);
			}
		}

		public virtual void VisitPointerAddition(PointerAddition pa)
		{
			pa.Pointer.Accept(this);
		}

		public virtual void VisitProcedureConstant(ProcedureConstant pc)
		{
		}

		public virtual void VisitTestCondition(TestCondition tc)
		{
			tc.Expression.Accept(this);
		}

		public virtual void VisitSegmentedAccess(SegmentedAccess access)
		{
			access.MemoryId.Accept(this);
			access.BasePointer.Accept(this);
			access.EffectiveAddress.Accept(this);
		}

		public virtual void VisitSlice(Slice slice)
		{
			slice.Expression.Accept(this);
		}

		public virtual void VisitUnaryExpression(UnaryExpression unary)
		{
			unary.Expression.Accept(this);
		}

		#endregion
	}
}
