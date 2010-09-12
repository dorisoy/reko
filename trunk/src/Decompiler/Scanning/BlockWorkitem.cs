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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.Scanning
{
    /// <summary>
    /// Scanner work item for processing (extended) basic blocks: linear sequences of code.
    /// </summary>
    public class BlockWorkitem2 : Scanner2.WorkItem2, InstructionVisitor
    {
        private IScanner scanner;
        private IProcessorArchitecture arch;
        private Address addrStart;
        private Block blockCur;
        private Frame frame;
        private RewrittenInstruction ri;

        private bool processNextInstruction;

        public BlockWorkitem2(
            IScanner scanner, 
            IProcessorArchitecture arch, 
            Address addr,
            Frame frame,
            Block block)
        {
            this.scanner = scanner;
            this.arch = arch;
            this.blockCur = block;
            this.addrStart = addr;
            this.frame = frame;
        }

        public override void Process()
        {
            var rw = arch.CreateRewriter2(scanner.CreateReader(addrStart), frame);
            processNextInstruction = true;
            for (var e = rw.GetEnumerator(); e.MoveNext(); )
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

        #region InstructionVisitor Members

        public void VisitAssignment(Assignment a)
        {
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
                var blockTarget = scanner.EnqueueJumpTarget((Address)g.Target, blockCur.Procedure);
                blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockTarget);
                TerminateBlock();
                this.processNextInstruction = false;
            }
            else
            {
                var blockThen = scanner.EnqueueJumpTarget((Address)g.Target, blockCur.Procedure);
                var blockElse = scanner.EnqueueJumpTarget(ri.Address + ri.Length, blockCur.Procedure);
                this.blockCur.Statements.Add(
                    ri.Address.Linear,
                    new Branch(g.Condition, blockThen));
                TerminateBlock();
                this.processNextInstruction = false;
            }
        }

        public void VisitPhiAssignment(PhiAssignment phi)
        {
        }

        public void VisitIndirectCall(IndirectCall ic)
        {
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
