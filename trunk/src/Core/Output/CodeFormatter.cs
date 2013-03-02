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

using Decompiler.Core.Absyn;
using Decompiler.Core.Code;
using Decompiler.Core.Lib;
using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Decompiler.Core.Output
{
	/// <summary>
	/// Formats intermediate-level instructions or abstract syntax statements.
	/// </summary>
	public class CodeFormatter : InstructionVisitor, IAbsynVisitor, IExpressionVisitor
	{
		private int precedenceCur = PrecedenceLeast;
        private Formatter writer;

        //$TODO: move this to a language-specific class.
		private static Dictionary<Operator,int> precedences;

		private const int PrecedenceApplication = 1;
		private const int PrecedenceArrayAccess = 1;
		private const int PrecedenceFieldAccess = 1;
		private const int PrecedenceDereference = 2;
		private const int PrecedenceMemberPointerSelector = 3;
		private const int PrecedenceCase = 2;
		private const int PrecedenceLeast = 20;

		public CodeFormatter(Formatter writer)
		{
            this.writer = writer;
		}

        protected Formatter InnerFormatter
        {
            get { return writer; }
        }

		static CodeFormatter()
		{
            precedences = new Dictionary<Operator, int>();
			precedences[Operator.Not] = 2;			//$REFACTOR: precedence is a property of the output language; these are the C/C++ precedences
			precedences[Operator.Neg] = 2;			
			precedences[Operator.Comp] = 2;
			precedences[Operator.AddrOf] = 2;
			precedences[Operator.Muls] = 4;
			precedences[Operator.Mulu] = 4;
			precedences[Operator.Mul] = 4;
			precedences[Operator.Divs] = 4;
			precedences[Operator.Divu] = 4;
			precedences[Operator.Mod] = 4;
			precedences[Operator.Add] = 5;
			precedences[Operator.Sub] = 5;
			precedences[Operator.Sar] = 6;
			precedences[Operator.Shr] = 6;
			precedences[Operator.Shl] = 6;
			precedences[Operator.Lt] = 7;
			precedences[Operator.Le] = 7;
			precedences[Operator.Gt] = 7;
			precedences[Operator.Ge] = 7;
			precedences[Operator.Rlt] = 7;
			precedences[Operator.Rle] = 7;
			precedences[Operator.Rgt] = 7;
			precedences[Operator.Rge] = 7;
			precedences[Operator.Ult] = 7;
			precedences[Operator.Ule] = 7;
			precedences[Operator.Ugt] = 7;
			precedences[Operator.Uge] = 7;
			precedences[Operator.Eq] = 8;
			precedences[Operator.Ne] = 8;
			precedences[Operator.And] = 9;
			precedences[Operator.Xor] = 10;
			precedences[Operator.Or] = 11;
			precedences[Operator.Cand] = 12;
			precedences[Operator.Cor] = 13;
		}

		private void ResetPresedence(int precedenceOld)
		{
			if (precedenceOld < precedenceCur)
			{
				writer.Write(")");
			}
			precedenceCur = precedenceOld;
		}

		private int SetPrecedence(int precedence)
		{
			if (precedenceCur < precedence)
			{
				writer.Write("(");
			}
			int precedenceOld = precedenceCur;
			precedenceCur = precedence;
			return precedenceOld;
		}


		#region IExpressionVisitor members ///////////////////////

        public void VisitAddress(Address addr)
        {
            if (addr.Selector == 0)
            {
                writer.Write("0x{0:X8}", addr.Offset);
            }
            else
            {
                writer.Write(addr.ToString());
            }
        }

		public void VisitApplication(Application appl)
		{
			int prec = SetPrecedence(PrecedenceApplication);
			appl.Procedure.Accept(this);
			ResetPresedence(prec);
			WriteActuals(appl.Arguments);
		}

		public void VisitArrayAccess(ArrayAccess acc)
		{
			int prec = SetPrecedence(PrecedenceArrayAccess);
			acc.Array.Accept(this);
			ResetPresedence(prec);
			writer.Write("[");
			WriteExpression(acc.Index);
			writer.Write("]");
		}

		public void VisitBinaryExpression(BinaryExpression binExp)
		{
			int prec = SetPrecedence((int) precedences[binExp.Operator]);
			binExp.Left.Accept(this);
			writer.Write(BinaryExpression.OperatorToString(binExp.Operator));
			binExp.Right.Accept(this);
			ResetPresedence(prec);
		}

		public void VisitCast(Cast cast)
		{
			int prec = SetPrecedence(PrecedenceCase);
			writer.Write("(");
			writer.Write(cast.DataType.ToString());        //$TODO: use a TypeFormatter
			writer.Write(") ");
			cast.Expression.Accept(this);
			ResetPresedence(prec);
		}

		public void VisitConditionOf(ConditionOf cond)
		{
			writer.Write("cond(");
			WriteExpression(cond.Expression);
			writer.Write(")");
		}

        public void VisitConstant(Constant c)
        {
            if (!c.IsValid)
            {
                writer.Write("<invalid>");
            }
            else
            {
                PrimitiveType t = (PrimitiveType)c.DataType;
                if (t.Domain == Domain.Boolean)
                {
                    writer.Write(Convert.ToBoolean(c.GetValue()) ? "true" : "false");
                }
                else
                {
                    object v = c.GetValue();
                    writer.Write(FormatString(t, v), v);
                }
            }
        }

		public void VisitDepositBits(DepositBits d)
		{
			writer.Write("DPB(");
			WriteExpression(d.Source);
			writer.Write(", ");
			WriteExpression(d.InsertedBits);
			writer.Write(", {0}, {1})", d.BitPosition, d.BitCount);
		}

		public void VisitMkSequence(MkSequence seq)
		{
			writer.Write("SEQ(");
			WriteExpression(seq.Head);
			writer.Write(", ");
			WriteExpression(seq.Tail);
			writer.Write(")");
		}

		public void VisitDereference(Dereference deref)
		{
			int prec = SetPrecedence(PrecedenceDereference);
			writer.Write("*");
			deref.Expression.Accept(this);
			ResetPresedence(prec);
		}

		public void VisitFieldAccess(FieldAccess acc)
		{
			int prec = SetPrecedence(PrecedenceFieldAccess);
			Dereference d = acc.structure as Dereference;
			if (d != null)
			{
				d.Expression.Accept(this);
				writer.Write("->{0}", acc.FieldName);
			}
			else
			{
				acc.structure.Accept(this);
				writer.Write(".{0}", acc.FieldName);
			}
			ResetPresedence(prec);
		}

		public void VisitMemberPointerSelector(MemberPointerSelector mps)
		{
			int prec = SetPrecedence(PrecedenceMemberPointerSelector);
			Dereference d = mps.BasePointer as Dereference;
			if (d != null)
			{
				d.Expression.Accept(this);
				writer.Write("->*");
			}
			else
			{
				mps.BasePointer.Accept(this);
				writer.Write(".*");
			}
			mps.MemberPointer.Accept(this);
			ResetPresedence(prec);
		}

		public void VisitIdentifier(Identifier id)
		{
			writer.Write(id.Name);
		}

		public void VisitMemoryAccess(MemoryAccess access)
		{
			access.MemoryId.Accept(this);
			writer.Write("[");
			WriteExpression(access.EffectiveAddress);
			writer.Write(":");
			writer.Write((access.DataType != null) ? access.DataType.ToString() : "??");
			writer.Write("]");
		}

		public void VisitSegmentedAccess(SegmentedAccess access)
		{
			access.MemoryId.Accept(this);
			writer.Write("[");
			WriteExpression(access.BasePointer);
			writer.Write(":");
			WriteExpression(access.EffectiveAddress);
			writer.Write(":");
			writer.Write((access.DataType != null) ? access.DataType.ToString() : "??");
			writer.Write("]");
		}

		public void VisitPhiFunction(PhiFunction phi)
		{
			writer.Write("PHI");
			WriteActuals(phi.Arguments);
		}

		public void VisitPointerAddition(PointerAddition pa)
		{
			throw new NotImplementedException("NYI");
		}

		public virtual void VisitProcedureConstant(ProcedureConstant pc)
		{
			writer.Write(pc.Procedure.Name);
		}

		public void VisitTestCondition(TestCondition tc)
		{
			writer.Write("Test({0},", tc.ConditionCode);
			WriteExpression(tc.Expression);
			writer.Write(")");
		}

		public void VisitScopeResolution(ScopeResolution scope)
		{
			writer.Write(scope.TypeName);
		}

		public void VisitSlice(Slice slice)
		{
			writer.Write("SLICE(");
			WriteExpression(slice.Expression);
			writer.Write(", {0}, {1})", slice.DataType, slice.Offset);
		}

		public void VisitUnaryExpression(UnaryExpression unary)
		{
			int prec = SetPrecedence((int) precedences[unary.Operator]);
			writer.Write(UnaryExpression.OperatorToString(unary.Operator));
			unary.Expression.Accept(this);
			ResetPresedence(prec);
		}

		#endregion


		#region InstructionVisitor ///////////////////////////////
		
		public void VisitAssignment(Assignment a)
		{
			writer.Indent();
			if (a.Dst != null)
			{
				a.Dst.Accept(this);
				writer.Write(" = "); 
			}
			a.Src.Accept(this);
			if (a.IsAlias)
				writer.Write(" (alias)");
			writer.Terminate();
		}

		public void VisitBranch(Branch b)
		{
			writer.Indent();
			writer.WriteKeyword("branch");
            writer.Write(" ");
			b.Condition.Accept(this);
            writer.Write(" ");
            writer.Write(b.Target.Name);
			writer.Terminate();
		}

		public void VisitCallInstruction(CallInstruction ci)
		{
			writer.Indent();
			writer.WriteKeyword("call");
            writer.Write(" ");
            ci.Callee.Accept(this);
            writer.Write(" ({0})", ci.CallSite);
			writer.Terminate();
		}

		public void VisitDeclaration(Declaration decl)
		{
			writer.Indent();
			if (decl.Identifier.DataType != null)
			{
                TypeFormatter tf = new TypeFormatter(writer, true);
                tf.Write(decl.Identifier.DataType, decl.Identifier.Name);
			}
			else
			{
                writer.Write("?unknown?");
                writer.Write(" ");
                decl.Identifier.Accept(this);
            }
			if (decl.Expression != null)
			{
				writer.Write(" = ");
				decl.Expression.Accept(this);
			}
			writer.Terminate();
		}

		public void VisitDefInstruction(DefInstruction def)
		{
			writer.Indent();
            writer.WriteKeyword("def");
            writer.Write(" ");
			def.Expression.Accept(this);
			writer.Terminate();
		}

        public void VisitGotoInstruction(GotoInstruction g)
        {
            writer.Indent();
            if (!(g.Condition is Constant))
            {
                writer.WriteKeyword("if");
                writer.Write(" (");
                g.Condition.Accept(this);
                writer.Write(") ");
            }
            writer.WriteKeyword("goto");
            writer.WriteKeyword(" ");
            g.Target.Accept(this);
            writer.Terminate();
        }

		public void VisitPhiAssignment(PhiAssignment phi)
		{
			writer.Indent();
			WriteExpression(phi.Dst);
			writer.Write(" = ");
			WriteExpression(phi.Src);
			writer.Terminate();
		}

		public void VisitReturnInstruction(ReturnInstruction ret)
		{
			writer.Indent();
			writer.WriteKeyword("return");
			if (ret.Expression != null)
			{
				writer.Write(" ");
				WriteExpression(ret.Expression);
			}
			writer.Terminate();
		}

		public void VisitSideEffect(SideEffect side)
		{
			writer.Indent();
			side.Expression.Accept(this);
			writer.Terminate();
		}

		public void VisitStore(Store store)
		{
			writer.Indent();
			WriteExpression(store.Dst);
			writer.Write(" = ");
			WriteExpression(store.Src);
			writer.Terminate();
		}

		public void VisitSwitchInstruction(SwitchInstruction si)
		{
			writer.Indent();
			writer.WriteKeyword("switch");
            writer.Write(" (");
			si.Expression.Accept(this);
			writer.Write(") { ");
			foreach (Block b in si.targets)
			{
				writer.Write("{0} ", b.Name);
			}
			writer.Write("}");
			writer.Terminate();
		}

		public void VisitUseInstruction(UseInstruction u)
		{
			writer.Indent();
			writer.WriteKeyword("use");
            writer.Write(" ");
			WriteExpression(u.Expression);
			if (u.OutArgument != null)
			{
				writer.Write(" (=> {0})", u.OutArgument);
			}
			writer.Terminate();
		}
		#endregion


		#region IAbsynStatementVisitor //////////////////////

		public void VisitAssignment(AbsynAssignment a)
		{
			writer.Indent();
			a.Dst.Accept(this);
			writer.Write(" = ");
			a.Src.Accept(this);
			writer.Terminate(";");
		}

		public void VisitBreak(AbsynBreak brk)
		{
			writer.Indent();
			writer.WriteKeyword("break");
			writer.Terminate(";");
		}

        public void VisitCase(AbsynCase c)
        {
            writer.Indentation -= writer.TabSize;
            writer.Indent();
            writer.WriteKeyword("case");
            writer.Write(" ");
            writer.Write("{0}", c.Number);
            writer.Terminate(":");
            writer.Indentation += writer.TabSize;
        }
		
        public void VisitContinue(AbsynContinue cont)
		{
            writer.Indent();
			writer.WriteKeyword("continue");
            writer.Terminate(";");
		}

		public void VisitDeclaration(AbsynDeclaration decl)
		{
			writer.Indent();
			if (decl.Identifier.DataType != null)
			{
                TypeFormatter tf = new TypeFormatter(writer, true);
                tf.Write(decl.Identifier.DataType, decl.Identifier.Name);
			}
			else
			{
                writer.Write("?unknown?");
                writer.Write(" ");
                decl.Identifier.Accept(this);
            }
			if (decl.Expression != null)
			{
				writer.Write(" = ");
				decl.Expression.Accept(this);
			}
			writer.Terminate(";");
		}

		public void VisitDoWhile(AbsynDoWhile loop)
		{
			writer.Indent();
			writer.WriteKeyword("do");
			writer.Terminate();
			WriteIndentedStatements(loop.Body);
			
			writer.Indent();
			writer.WriteKeyword("while");
            writer.Write(" (");
			WriteExpression(loop.Condition);
			writer.Terminate(");");
		}

		public void VisitGoto(AbsynGoto g)
		{
			writer.Indent();
			writer.WriteKeyword("goto");
            writer.Write(" ");
			writer.Write(g.Label);
			writer.Terminate(";");
		}

		public void VisitIf(AbsynIf ifs)
		{
			writer.Indent();
			WriteIf(ifs);
		}

		private void WriteIf(AbsynIf ifs)
		{
			writer.WriteKeyword("if");
            writer.Write(" (");
			WriteExpression(ifs.Condition);
			writer.Write(")");
			writer.Terminate();

			WriteIndentedStatements(ifs.Then);

			if (ifs.Else != null && ifs.Else.Count > 0)
			{
				writer.Indent();
				writer.WriteKeyword("else");
                AbsynIf elseIf;
                if (IsSingleIfStatement(ifs.Else, out elseIf))
				{
					writer.Write(" ");
					WriteIf(elseIf);
				}
				else
				{
					writer.Terminate();
					WriteIndentedStatements(ifs.Else);
				}
			}
		}

        private string FormatString(PrimitiveType type, object value)
        {
            switch (type.Domain)
            {
            case Domain.SignedInt:
                return "{0}";
            case Domain.Real:
                switch (type.Size)
                {
                case 4: return "{0:g}F";
                case 8: return "{0:g}";
                default: throw new ArgumentOutOfRangeException("Only real types of size 4 and 8 are supported.");
                }
            default:
                var iVal = Convert.ToUInt64(value);
                switch (type.Size)
                {
                case 1: return "0x{0:X2}";
                case 2: return "0x{0:X4}";
                case 4: return "0x{0:X8}";
                case 5:
                case 3: return "$$0x{0:X16}$$";
                case 8: return "0x{0:X16}";
                default: throw new ArgumentOutOfRangeException("type", type.Size, string.Format("Integral types of size {0} are not supported.", type.Size));
                }
            }
        }
        private bool IsSingleIfStatement(List<AbsynStatement> stms, out AbsynIf elseIf)
        {
            elseIf = null;
            if (stms.Count != 1)
                return false;
            elseIf = stms[0] as AbsynIf;
            return elseIf != null;
        }

		public void VisitLabel(AbsynLabel lbl)
		{
			writer.Write(lbl.Name);
			writer.Terminate(":");
		}

		public void VisitReturn(AbsynReturn ret)
		{
			writer.Indent();
			writer.WriteKeyword("return");
			if (ret.Value != null)
			{
				writer.Write(" ");
				WriteExpression(ret.Value);
			}
			writer.Terminate(";");
		}

		public void VisitSideEffect(AbsynSideEffect side)
		{
			writer.Indent();
			side.Expression.Accept(this);
			writer.Terminate(";");
		}

        public void VisitSwitch(AbsynSwitch s)
        {
            writer.Indent();
            writer.WriteKeyword("switch");
            writer.Write(" (");
            WriteExpression(s.Expression);
            writer.Terminate(")");
            WriteIndentedStatements(s.Statements);
        }

		public void VisitWhile(AbsynWhile loop)
		{
			writer.Indent();
			writer.WriteKeyword("while");
            writer.Write(" (");
			WriteExpression(loop.Condition);
			writer.Terminate(")");

			WriteIndentedStatements(loop.Body);
		}

		#endregion

		public void Write(Procedure proc)
		{
			proc.Signature.Emit(proc.Name, ProcedureSignature.EmitFlags.None, writer, this, new TypeFormatter(writer, true));
			writer.WriteLine();
			writer.Write("{");
            writer.WriteLine();
			if (proc.Body.Count > 0)
			{
				for (int i = 0; i < proc.Body.Count; ++i)
				{
					proc.Body[i].Accept(this);
				}
			}
			else
			{
				foreach (Block b in new DfsIterator<Block>(proc.ControlGraph).PostOrder().Reverse())
				{
                    if (!string.IsNullOrEmpty(b.Name))
                    {
                        writer.Write(b.Name);
                        writer.Write(":");
                        writer.WriteLine();
                    }
					if (b.Statements.Count > 0)
					{
                        int c = b.Statements.Count;
                        Branch br = b.Statements.Last.Instruction as Branch;
                        if (br != null)
                        {
                            --c;
                        }
                        for (int s = 0; s < c; ++s)
						{
							b.Statements[s].Instruction.Accept(this);
						}
                        if (br != null)
                        {
                            writer.Indent();
                            writer.WriteKeyword("if");
                            writer.Write(" (");
                            WriteExpression(br.Condition);
                            writer.Terminate(")");
                            int old = writer.Indentation;
                            writer.Indentation += writer.TabSize;
                            writer.Indent();
                            writer.WriteKeyword("goto");
                            writer.Write(" ");
                            writer.Write(b.Succ[1].Name);
                            writer.Terminate();
                            writer.Indentation = old;
                        }
                        else if (b.Succ.Count == 1 && !(b.Statements.Last.Instruction is ReturnInstruction))
                        {
                            writer.Indent();
                            writer.WriteKeyword("goto");
                            writer.Write(" ");
                            writer.Write(b.Succ[0].Name);
                            writer.Terminate();
                        }
					}
				}
			}
			writer.Write("}");
            writer.WriteLine();
		}

    	private void WriteActuals(Expression [] arguments)
		{
			writer.Write("(");
			if (arguments.Length >= 1)
			{
				WriteExpression(arguments[0]);
				for (int i = 1; i < arguments.Length; ++i)
				{
					writer.Write(", ");
					WriteExpression(arguments[i]);
				}
			}
			writer.Write(")");
		}

		/// <summary>
		/// Writes an expression in a context where it needs no parentheses.
		/// </summary>
		/// <param name="expr"></param>
		public void WriteExpression(Expression expr)
		{
			int prec = precedenceCur;
			precedenceCur = PrecedenceLeast;
			expr.Accept(this);
			precedenceCur = prec;
		}

        public void WriteFormalArgument(Identifier arg, bool writeStorage, TypeFormatter t)
        {
            if (writeStorage)
            {
                WriteFormalArgumentType(arg, writeStorage);
                writer.Write(" ");
                writer.Write(arg.Name);
            }
            else
            {
                t.Write(arg.DataType, arg.Name);
            }
        }

        public void WriteFormalArgumentType(Identifier arg, bool writeStorage)
        {
            if (writeStorage)
            {
                OutArgumentStorage os = arg.Storage as OutArgumentStorage;
                if (os != null)
                {
                    writer.Write(os.OriginalIdentifier.Storage.Kind);
                    writer.Write(" out ");
                }
                else
                {
                    writer.Write(arg.Storage.Kind);
                    writer.Write(" ");
                }
            }
            writer.Write(arg.DataType.ToString());
        }

		public void WriteIndentedStatement(AbsynStatement stm)
		{
			writer.Indentation += writer.TabSize;
			if (stm != null)
				stm.Accept(this);
			else
			{
				writer.Indent();				
				writer.Terminate(";");
			}
			writer.Indentation -= writer.TabSize;
		}

        public void WriteIndentedStatements(List<AbsynStatement> stms)
        {
            if (stms.Count <= 1)
            {
                writer.Indentation += writer.TabSize;
                if (stms.Count == 0)
                {
                    writer.Indent();
                    writer.Terminate(";");
                }
                else
                {
                    stms[0].Accept(this);
                }
                writer.Indentation -= writer.TabSize;
            }
            else
            {
                writer.Indent();
                writer.Write("{");
                writer.Terminate();

                writer.Indentation += writer.TabSize;
                foreach (AbsynStatement stm in stms)
                {
                    stm.Accept(this);
                }
                writer.Indentation -= writer.TabSize;

                writer.Indent();
                writer.Write("}");
                writer.Terminate();
            }

        }

		public void WriteStatementList(List<AbsynStatement> list)
		{
			foreach (AbsynStatement s in list)
			{
				s.Accept(this);
			}
		}
    }
}
