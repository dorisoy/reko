﻿#region License
/* 
 * Copyright (C) 1999-2013 John Källén.
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Decompiler.Scanning
{
    public class BlockCloner :
        InstructionVisitor<Instruction>,
        ExpressionVisitor<Expression>,
        StorageVisitor<Identifier>
    {
        private Block blockToClone;
        private Procedure procCalling;
        private CallGraph callGraph;

        public BlockCloner(Block blockToClone, Procedure procCalling, CallGraph callGraph)
        {
            this.blockToClone = blockToClone;
            this.procCalling = procCalling;
            this.callGraph = callGraph;
        }

        public Statement Statement { get; set; }
        public Identifier Identifier { get; set; }

        public Block Execute()
        {
            return CloneBlock(blockToClone);
        }

        public Block CloneBlock(Block blockOrig)
        {
            if (blockOrig == blockOrig.Procedure.ExitBlock)
                return null;

            var succ = blockOrig.Succ.Count > 0 ? CloneBlock(blockOrig.Succ[0]) : null;
            var blockNew = new Block(procCalling, blockOrig.Name + "_in_" + procCalling.Name);
            foreach (var stm in blockOrig.Statements)
            {
                Statement = stm;
                blockNew.Statements.Add(new Statement(
                    stm.LinearAddress,
                    stm.Instruction.Accept(this),
                    blockNew));
            }
            procCalling.AddBlock(blockNew);
            if (succ == null)
                procCalling.ControlGraph.AddEdge(blockNew, procCalling.ExitBlock);
            else
                procCalling.ControlGraph.AddEdge(blockNew, succ);
            return blockNew;
        }

        public Instruction VisitAssignment(Assignment ass)
        {
            var id = (Identifier) ass.Dst.Accept(this);
            var src = ass.Src.Accept(this);
            return new Assignment(id, src);
        }

        public Instruction VisitBranch(Branch branch)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitCallInstruction(CallInstruction ci)
        {
            var callee = ci.Callee.Accept(this);
            var pc = callee as ProcedureConstant;
            if (pc != null)
            {
                var calledProc = pc.Procedure as Procedure;
                if (calledProc != null)
                {
                    callGraph.AddEdge(Statement, calledProc);
                }
            }
            var ciNew = new CallInstruction(ci.Callee, new CallSite(ci.CallSite.SizeOfReturnAddressOnStack, ci.CallSite.FpuStackDepthBefore));
            return ciNew;  
        }

        public Instruction VisitDeclaration(Declaration decl)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitDefInstruction(DefInstruction def)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitGotoInstruction(GotoInstruction gotoInstruction)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitPhiAssignment(PhiAssignment phi)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitReturnInstruction(ReturnInstruction ret)
        {
            var exp = ret.Expression != null ? ret.Expression.Accept(this) : null;
            return new ReturnInstruction(exp);
        }

        public Instruction VisitSideEffect(SideEffect side)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitStore(Store store)
        {
            var dst = store.Dst.Accept(this);
            var src = store.Src.Accept(this);
            return new Store(dst, src);
        }

        public Instruction VisitSwitchInstruction(SwitchInstruction si)
        {
            throw new NotImplementedException();
        }

        public Instruction VisitUseInstruction(UseInstruction use)
        {
            throw new NotImplementedException();
        }

        public Expression VisitAddress(Address addr)
        {
            throw new NotImplementedException();
        }

        public Expression VisitApplication(Application appl)
        {
            var proc = appl.Procedure.Accept(this);
            var args = appl.Arguments.Select(a => a.Accept(this)).ToArray();
            return new Application(proc, appl.DataType, args);
        }

        public Expression VisitArrayAccess(ArrayAccess acc)
        {
            throw new NotImplementedException();
        }

        public Expression VisitBinaryExpression(BinaryExpression binExp)
        {
            var left = binExp.Left.Accept(this);
            var right = binExp.Right.Accept(this);
            return new BinaryExpression(
                binExp.Operator,
                binExp.DataType,
                left, right);
        }

        public Expression VisitCast(Cast cast)
        {
            throw new NotImplementedException();
        }

        public Expression VisitConditionOf(ConditionOf cof)
        {
            return new ConditionOf(cof.Expression.Accept(this));
        }

        public Expression VisitConstant(Constant c)
        {
            return c.CloneExpression();
        }

        public Expression VisitDepositBits(DepositBits d)
        {
            throw new NotImplementedException();
        }

        public Expression VisitDereference(Dereference deref)
        {
            throw new NotImplementedException();
        }

        public Expression VisitFieldAccess(FieldAccess acc)
        {
            throw new NotImplementedException();
        }

        public Expression VisitIdentifier(Identifier id)
        {
            this.Identifier = id;
            return id.Storage.Accept(this);
        }

        public Expression VisitMemberPointerSelector(MemberPointerSelector mps)
        {
            throw new NotImplementedException();
        }

        public Expression VisitMemoryAccess(MemoryAccess access)
        {
            var mem = (MemoryIdentifier) access.MemoryId.Accept(this);
            var ea = access.EffectiveAddress.Accept(this);
            return new MemoryAccess(mem, ea, access.DataType);
        }

        public Expression VisitMkSequence(MkSequence seq)
        {
            throw new NotImplementedException();
        }

        public Expression VisitPhiFunction(PhiFunction phi)
        {
            throw new NotImplementedException();
        }

        public Expression VisitPointerAddition(PointerAddition pa)
        {
            throw new NotImplementedException();
        }

        public Expression VisitProcedureConstant(ProcedureConstant pc)
        {
            return new ProcedureConstant(pc.DataType, pc.Procedure);
        }

        public Expression VisitScopeResolution(ScopeResolution scopeResolution)
        {
            throw new NotImplementedException();
        }

        public Expression VisitSegmentedAccess(SegmentedAccess access)
        {
            throw new NotImplementedException();
        }

        public Expression VisitSlice(Slice slice)
        {
            throw new NotImplementedException();
        }

        public Expression VisitTestCondition(TestCondition tc)
        {
            throw new NotImplementedException();
        }

        public Expression VisitUnaryExpression(UnaryExpression unary)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitFlagGroupStorage(FlagGroupStorage grf)
        {
            return procCalling.Frame.EnsureFlagGroup(grf.FlagGroupBits, grf.Name, grf.DataType);
        }

        public Identifier VisitFpuStackStorage(FpuStackStorage fpu)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitMemoryStorage(MemoryStorage global)
        {
            return procCalling.Frame.Memory;
        }

        public Identifier VisitStackLocalStorage(StackLocalStorage local)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitOutArgumentStorage(OutArgumentStorage arg)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitRegisterStorage(RegisterStorage reg)
        {
            return procCalling.Frame.EnsureRegister(reg);
        }

        public Identifier VisitSequenceStorage(SequenceStorage seq)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitStackArgumentStorage(StackArgumentStorage stack)
        {
            throw new NotImplementedException();
        }

        public Identifier VisitTemporaryStorage(TemporaryStorage temp)
        {
            return procCalling.Frame.CreateTemporary(Identifier.Name, Identifier.DataType); 
        }
    }
}
