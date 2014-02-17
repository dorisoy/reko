#region License
/* 
 * Copyright (C) 1999-2014 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.Core.Rtl;
using Decompiler.Evaluation;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Decompiler.Scanning
{
	/// <summary>
	/// Walks code backwards to find "dominating" comparisons against constants,
	/// which may provide vector table limits.
	/// </summary>
	public class Backwalker
	{
        private IBackWalkHost host;
        private ExpressionSimplifier eval;
        private static TraceSwitch trace = new TraceSwitch("BackWalker", "Traces the progress backward instruction walking");

		public Backwalker(IBackWalkHost host, RtlTransfer xfer, ExpressionSimplifier eval)
		{
            this.host = host;
            this.eval = eval;
            var target = xfer.Target;
            var seq = xfer.Target as MkSequence;
            if (seq != null)
            {
                target = seq.Tail;
            }
            var mem = target as MemoryAccess;
            if (mem == null)
            {
                Index = null;
            }
            else
            {
                Index = DetermineIndexRegister(mem);
            }
            Operations = new List<BackwalkOperation>();
		}

        /// <summary>
        /// The register used to perform a table-dispatch switch.
        /// </summary>
        public RegisterStorage Index { get; private set; }
        public Identifier UsedFlagIdentifier { get; set; } 
        public int Stride { get; private set; }
        public Address VectorAddress { get; private set; }
        public List<BackwalkOperation> Operations { get; private set; }

        private IEnumerable<Statement> StatementsInReverseOrder(Block block)
        {
            for (int i = block.Statements.Count - 1; i >= 0; --i)
            {
                yield return block.Statements[i];
            }
        }

        /// <summary>
        /// Walks backward along the <paramref name="block"/>, recording the operations done to the idx register.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public List<BackwalkOperation> BackWalk(Block block)
        {
            if (Stride > 1)
                Operations.Add(new BackwalkOperation(BackwalkOperator.mul, Stride));

            bool continueBackwalking = BackwalkInstructions(Index, StatementsInReverseOrder(block));
            if (Index == null)
                return null;	// unable to find guard. //$REVIEW: return warning.

            if (continueBackwalking)
            {
                block = host.GetSinglePredecessor(block);
                if (block == null)
                    return null;	// seems unguarded to me.	//$REVIEW: emit warning.

                BackwalkInstructions(Index, StatementsInReverseOrder(block));
                if (Index == null)
                    return null;
            }
            Operations.Reverse();
            return Operations;
        }

        public bool BackwalkInstruction(Instruction instr)
        {
            var ass = instr as Assignment;
            if (ass != null)
            {
                var regSrc = RegisterOf(ass.Src as Identifier);
                var binSrc = ass.Src as BinaryExpression;
                if (binSrc != null)
                {
                    if (RegisterOf(ass.Dst) == Index)
                    {
                        regSrc = RegisterOf(binSrc.Left as Identifier);
                        var immSrc = binSrc.Right as Constant;
                        if (binSrc.Operator == Operator.IAdd || binSrc.Operator == Operator.ISub)
                        {
                            Index = HandleAddition(Index, Index, regSrc, immSrc, binSrc.Operator == Operator.IAdd);
                            return true;
                        }
                        if (binSrc.Operator == Operator.And)
                        {
                            if (immSrc != null && IsEvenPowerOfTwo(immSrc.ToInt32() + 1))
                            {
                                Operations.Add(new BackwalkOperation(BackwalkOperator.cmp, immSrc.ToInt32() + 1));
                            }
                            else
                            {
                                Index = null;
                            }
                            return false;
                        }
                    }
                    if (binSrc.Operator == Operator.Xor && 
                        binSrc.Left == ass.Dst && 
                        binSrc.Right == ass.Dst && 
                        RegisterOf(ass.Dst) == Index.GetSubregister(8,8))
                    {
                        Operations.Add(new BackwalkOperation(BackwalkOperator.and, 0xFF));
                        Index = Index.GetSubregister(0, 8);
                    }
                }

                var cof = ass.Src as ConditionOf;
                if (cof != null && UsedFlagIdentifier != null)
                {
                    var grfDef = (ass.Dst.Storage as FlagGroupStorage).FlagGroupBits;
                    var grfUse = (UsedFlagIdentifier.Storage as FlagGroupStorage).FlagGroupBits;
                    if ((grfDef & grfUse) == 0)
                        return true;
                    var binCmp = cof.Expression as BinaryExpression;
                    if (binCmp != null && binCmp.Operator is ISubOperator)
                    {
                        var idLeft = RegisterOf(binCmp.Left  as Identifier);
                        if (idLeft != RegisterStorage.None &&
                            (idLeft == Index || idLeft == Index.GetPart(PrimitiveType.Byte)))
                        {
                            var immSrc = binCmp.Right as Constant;
                            if (immSrc != null)
                            {
                                Operations.Add(new BackwalkOperation(BackwalkOperator.cmp, immSrc.ToInt32()));
                                return false;
                            }
                        }
                    }
                }

                var memSrc = ass.Src as MemoryAccess;
                var regDst = RegisterOf(ass.Dst);
                if (memSrc != null && (regDst == Index || regDst.IsSubRegisterOf(Index)))
                {
                    var rIdx = Index;
                    var rDst = RegisterOf(ass.Dst);
                    if (rDst != rIdx.GetSubregister(0, 8))
                        return false;

                    var binEa = memSrc.EffectiveAddress as BinaryExpression;
                    if (binEa == null)
                        return false;
                    var memOffset = binEa.Right as Constant;
                    var scale = GetMultiplier(binEa.Left);
                    var baseReg = GetBaseRegister(binEa.Left);
                    if (memOffset != null)
                    {
                        Operations.Add(new BackwalkDereference(memOffset.ToInt32(), scale));
                        Index = baseReg;
                        return true;
                    }
                }

                if (regSrc != null && regDst == Index)
                {
                    Index = regSrc;
                    return true;
                }
                return true;
            }

            var bra = instr as Branch;
            if (bra != null)
            {
                var cond = bra.Condition as TestCondition;
                if (cond != null && cond.ConditionCode == ConditionCode.UGT)
                {
                    Operations.Add(new BackwalkBranch(ConditionCode.UGT));
                    UsedFlagIdentifier = (Identifier) cond.Expression;
                }
                return true;
            }

            Debug.WriteLine("Backwalking not supported: " + instr);
            return true;
        }

        private RegisterStorage RegisterOf(Identifier id)
        {
            if (id == null)
                return RegisterStorage.None;
            var reg = id.Storage as RegisterStorage;
            if (reg == null)
                return RegisterStorage.None;
            return reg;
        }

        public bool BackwalkInstructions(
            RegisterStorage regIdx,
            IEnumerable<Statement> backwardStatementSequence)
        {
            foreach (var stm in backwardStatementSequence)
            {
                if (!BackwalkInstruction(stm.Instruction))
                    return false;
            }
            return true;
        }

        private RegisterStorage GetBaseRegister(Expression ea)
        {
            var id = ea as Identifier;
            if (id != null)
                return RegisterOf(id);
            var bin = ea as BinaryExpression;
            if (bin == null)
                return RegisterStorage.None;
            id = bin.Left as Identifier;
            if (id != null)
                return RegisterOf(id);
            var scaledExpr = bin.Left as BinaryExpression;
            if (bin == null)
                return RegisterStorage.None;
            return RegisterOf(scaledExpr.Left as Identifier);
        }

        private int GetMultiplier(Expression exp)
        {
            var bin = exp as BinaryExpression;
            if (bin == null)
                return 1;
            if (bin.Operator is IMulOperator)
            {
                var scale = bin.Right as Constant;
                if (scale == null)
                    return 1;
                return scale.ToInt32();
            }
            else
                return 1;
        }

        public bool CanBackwalk()
        {
            return Index != null;
        }

        [Conditional("DEBUG")]
        private void DumpInstructions(StatementList instrs, int idx)
        {
            for (int i = 0; i < instrs.Count; ++i)
            {
                Debug.WriteLineIf(trace.TraceInfo,
                    string.Format("{0} {1}",
                    idx == i ? '*' : ' ',
                    instrs[i]));
            }
        }
		
        public RegisterStorage DetermineIndexRegister(MemoryAccess mem)
        {
            Stride = 0;
            var id = mem.EffectiveAddress as Identifier;    // Mem[reg]
            if (id != null)
            {
                Stride = 1;
                return RegisterOf(id);
            }
            var bin = mem.EffectiveAddress as BinaryExpression;
            if (bin == null)
                return null;
            var idLeft = bin.Left as Identifier;
            var idRight = bin.Right as Identifier;
            if (idRight != null && idLeft == null)
            {
                var t = idLeft;
                idLeft = idRight;
                idRight = t;
            }
            if (idLeft != null && idRight != null)
                return null;
            if (idLeft != null)
            {
                Stride = 1;
                DetermineVector(mem, bin.Right);
                return RegisterOf(idLeft);
            }
            var binLeft = bin.Left as BinaryExpression;
            if (IsScaledIndex(binLeft))
            {
                return DetermineVectorWithScaledIndex(mem, bin.Right, binLeft);
            }
            var binRight = bin.Right as BinaryExpression;
            if (IsScaledIndex(binRight))
            {
                return DetermineVectorWithScaledIndex(mem, bin.Left, binRight);
            }
            return null;
        }

        private bool IsScaledIndex(BinaryExpression bin)
        {
            return bin != null && bin.Operator is IMulOperator && bin.Right is Constant;
        }

        private RegisterStorage DetermineVectorWithScaledIndex(MemoryAccess mem, Expression possibleVector, BinaryExpression scaledIndex)
        {
            Stride = ((Constant)scaledIndex.Right).ToInt32();   // Mem[x + reg * C]
            DetermineVector(mem, possibleVector);
            return RegisterOf(scaledIndex.Left as Identifier);
        }

        private void DetermineVector(MemoryAccess mem, Expression possibleVector)
        {
            var vector = possibleVector as Constant;
            if (vector == null)
                return;
            var pt = vector.DataType as PrimitiveType;
            if (pt != null && pt.Domain == Domain.SignedInt)
                return;
            var segmem = mem as SegmentedAccess;
            if (segmem != null)
            {
                var selector = segmem.BasePointer.Accept(eval) as Constant;
                if (selector != null)
                {
                    VectorAddress = new Address(selector.ToUInt16(), vector.ToUInt16());
                }
            }
            else
            {
                VectorAddress = new Address(vector.ToUInt32());
            }
        }

        private RegisterStorage HandleAddition(
			RegisterStorage regIdx,
			RegisterStorage ropDst,
			RegisterStorage ropSrc, 
			Constant immSrc, 
			bool add)
		{
			if (ropSrc != null && immSrc == null)
			{
				if (ropSrc == ropDst && add)
				{
					Operations.Add(new BackwalkOperation(BackwalkOperator.mul, 2));
                    Stride *= 2;
					return ropSrc;
				}		
				else
				{
					return null;
				}
			} 
			
            if (immSrc != null)
			{
				Operations.Add(new BackwalkOperation(
					add ? BackwalkOperator.add : BackwalkOperator.sub,
					immSrc.ToInt32()));
				return regIdx;
			}
			else
				return null;
		}

		public static bool IsEvenPowerOfTwo(int n)
		{
			return n != 0 && (n & (n - 1)) == 0;
		}

    }
}
