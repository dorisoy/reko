﻿#region License
/* 
 * Copyright (C) 1999-2010 John Källén.
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
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.Scanning
{
    /// <summary>
    /// Scanner work item for processing basic blocks.
    /// </summary>
    public class BlockWorkitem2 : Scanner2.WorkItem2, InstructionVisitor
    {
        private IScanner scanner;
        private IProcessorArchitecture arch;
        private Address addrStart;
        private Block blockCur;
        private Frame frame;
        private RewrittenInstruction ri;
        private Rewriter2 rewriter;
        private ProcessorState state;

        private bool processNextInstruction;

        public BlockWorkitem2(
            IScanner scanner,
            IProcessorArchitecture arch,
            Rewriter2 rewriter,
            ProcessorState state,
            Frame frame,
            Block block)
        {
            this.scanner = scanner;
            this.arch = arch;
            this.rewriter = rewriter;
            this.state = state;
            this.frame = frame;
            this.blockCur = block;
        }

        public override void Process()
        {
            processNextInstruction = true;
            for (var e = rewriter.GetEnumerator(); e.MoveNext(); )
            {
                ri = e.Current;
                ri.Instruction.Accept(this);
                if (!processNextInstruction)
                    break;
            }
        }

        /// <summary>
        /// Rewrites instructions until the current address is exactly on an instruction boundary.
        /// </summary>
        /// <param name="block"></param>
        /// <param name="blockCur"></param>
        /// <param name="addrStart"></param>
        private void ResyncBlocks(Block oldBlock, Address addrStart)
        {
            uint linAddr = (uint) addrStart.Linear;
        }

        private void TerminateBlock()
        {
        }

        private Block AddBlock(Block block)
        {
            throw new NotImplementedException();
        }

        private void BuildApplication(Expression fn, ProcedureSignature sig)
        {
            ApplicationBuilder ab = new ApplicationBuilder(
                frame,
                new CallSite(0, 0),
                fn,
                sig);
            //state.ShrinkStack(sig.StackDelta);
            //state.ShrinkFpuStack(sig.FpuStackDelta);
            blockCur.Statements.Add(ri.Address.Linear, ab.CreateInstruction());
        }

        public Constant GetValue(Expression op)
        {
            var co = op as Constant;
            if (co != null)
                return co;
            var id = op as Identifier;
            if (id != null)
            {
                var reg = id.Storage as RegisterStorage;
                if (reg != null)
                {
                    return state.Get(reg.Register);
                }
            }
            var bin = op as BinaryExpression;
            if (bin != null)
            {
                // Special case XOR/SUB (self,self)
                if ((bin.op == Operator.Xor || 
                    bin.op == Operator.Sub) && bin.Left == bin.Right)
                    return Constant.Zero(bin.Left.DataType);
                var c1 = GetValue(bin.Left);
                var c2 = GetValue(bin.Right);
                if (c1.IsValid && c2.IsValid)
                {
                    return bin.op.ApplyConstants(c1, c2);
                }
            }
            return Constant.Invalid;
        }

        public void SetValue(Expression op, Constant c)
        {
            var id = op as Identifier;
            if (id == null)
                return;
            var reg = id.Storage as RegisterStorage;
            if (reg != null)
            {
                state.Set(reg.Register, c);
            }
        }

        #region InstructionVisitor Members

        public void VisitAssignment(Assignment a)
        {
            SetValue(a.Dst, GetValue(a.Src));
        }

        public void VisitBranch(Branch b)
        {
            throw new InvalidOperationException("Branch instructions should not be generated by rewriters: return a GotoStatement with a condition instead.");
        }

        public void VisitCallInstruction(CallInstruction ci)
        {
            throw new NotImplementedException();
        }

        public void VisitDeclaration(Declaration decl)
        {
        }

        public void VisitDefInstruction(DefInstruction def)
        {
        }

        public void VisitGotoInstruction(GotoInstruction g)
        {
            if (g.Condition is Constant)
            {
                var blockTarget = scanner.EnqueueJumpTarget((Address)g.Target, blockCur.Procedure, state);
                blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockTarget);
                TerminateBlock();
                this.processNextInstruction = false;
            }
            else
            {
                var blockThen = scanner.EnqueueJumpTarget((Address)g.Target, blockCur.Procedure, state);
                var blockElse = scanner.EnqueueJumpTarget(ri.Address + ri.Length, blockCur.Procedure, state);
                this.blockCur.Statements.Add(
                    ri.Address.Linear,
                    new Branch(g.Condition, blockThen));
                TerminateBlock();
                this.processNextInstruction = false;
            }
        }

        public void VisitPhiAssignment(PhiAssignment phi)
        {
            throw new InvalidOperationException("Medium-level instruction should not be generated at this stage");
        }

        public void VisitIndirectCall(IndirectCall ic)
        {
            Address addr = ic.Callee as Address;
            if (addr != null)
            {
                var callee = scanner.EnqueueProcedure(this, addr, null, null);
                blockCur.Statements.Add(
                    ri.Address.Linear, 
                    new CallInstruction(
                        new ProcedureConstant(PrimitiveType.Pointer32, callee),
                        new CallSite(0, 0)));
                scanner.CallGraph.AddEdge(blockCur.Statements.Last, callee);
                return;
            }
            throw new NotImplementedException();
        }

        public void VisitReturnInstruction(ReturnInstruction ret)
        {
            blockCur.Statements.Add(ri.Address.Linear, ret);
            blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockCur.Procedure.ExitBlock);
            TerminateBlock();
            this.processNextInstruction = false;
        }

        public void VisitSideEffect(SideEffect side)
        {
            SystemService svc = MatchSyscallToService(side);
            if (svc != null)
            {
                ExternalProcedure ep = svc.CreateExternalProcedure(arch);
                ProcedureConstant fn = new ProcedureConstant(arch.PointerType, ep);
                BuildApplication(fn, ep.Signature);
                if (svc.Characteristics.Terminates)
                {
                    blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockCur.Procedure.ExitBlock);
                    TerminateBlock();
                    this.processNextInstruction = false;
                    return;
                }
                AffectProcessorState(svc.Signature);
            }
        }

        private void AffectProcessorState(ProcedureSignature sig)
        {
            TrashVariable(sig.ReturnValue);
            for (int i = 0; i < sig.FormalArguments.Length; ++i)
            {
                var os = sig.FormalArguments[i].Storage as OutArgumentStorage;
                if (os != null)
                {
                    TrashVariable(os.OriginalIdentifier);
                }
            }
        }

        public void TrashVariable(Identifier id)
        {
            if (id == null)
                return;
            RegisterStorage reg = id.Storage as RegisterStorage;
            if (reg != null)
            {
                state.Set(reg.Register, Constant.Invalid);
            }
            SequenceStorage seq = id.Storage as SequenceStorage;
            if (seq != null)
            {
                TrashVariable(seq.Head);
                TrashVariable(seq.Tail);
            }
        }


        private SystemService MatchSyscallToService(SideEffect side)
        {
            var fn = side.Expression as Application;
            if (fn == null)
                return null;
            var pc = fn.Procedure as ProcedureConstant;
            if (pc == null)
                return null;
            var ppp = pc.Procedure as PseudoProcedure;
            if (ppp == null)
                return null;
            if (ppp.Name != "__syscall")
                return null;

            var vector = fn.Arguments[0] as Constant;
            if (vector == null)
                return null;
            return scanner.Platform.FindService(vector.ToInt32(), state);
        }

        public void VisitStore(Store store)
        {
        }

        public void VisitSwitchInstruction(SwitchInstruction si)
        {
            throw new NotImplementedException();
        }

        public void VisitUseInstruction(UseInstruction u)
        {
        }

        #endregion
    }
}
