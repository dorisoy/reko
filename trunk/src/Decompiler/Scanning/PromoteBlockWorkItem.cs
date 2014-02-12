﻿#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
using Decompiler.Core.Lib;
using Decompiler.Core.Rtl;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.Evaluation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Decompiler.Scanning
{
    public class PromoteBlockWorkItem : WorkItem
    {
        public Address Address;
        public Block Block;
        public Procedure ProcNew;
        public IScanner Scanner;

        public override void Process()
        {
            var movedBlocks = new HashSet<Block>();
            var stack = new Stack<IEnumerator<Block>>();
            stack.Push(new Block[] { Block }.Cast<Block>().GetEnumerator());
            var replacer = new IdentifierReplacer(ProcNew.Frame);
            while (stack.Count != 0)
            {
                var e = stack.Peek();
                if (!e.MoveNext())
                {
                    stack.Pop();
                    continue;
                }
                var b = e.Current;
                if (b.Procedure == ProcNew || b == b.Procedure.ExitBlock || b.Procedure.EntryBlock.Succ[0] == b)
                    continue;

                b.Procedure.RemoveBlock(b);
                ProcNew.AddBlock(b);
                b.Procedure = ProcNew;
                movedBlocks.Add(b);
                foreach (var stm in b.Statements)
                {
                    stm.Instruction = replacer.ReplaceIdentifiers(stm.Instruction);
                }
                if (b.Succ.Count > 0)
                    stack.Push(b.Succ.GetEnumerator());
            }
            foreach (var b in movedBlocks)
            {
                FixExitEdges(b);
                FixInboundEdges(b);
                FixOutboundEdges(b);
            }
        }

        public void FixInboundEdges(Block blockToPromote)
        {
            // Get all blocks that are from "outside" blocks.
            var inboundBlocks = blockToPromote.Pred.Where(p => p.Procedure != ProcNew).ToArray();
            foreach (var inboundBlock in inboundBlocks)
            {
                var callRetThunkBlock = Scanner.CreateCallRetThunk(inboundBlock.Procedure, ProcNew);
                ReplaceSuccessorsWith(inboundBlock, blockToPromote, callRetThunkBlock);
            }
            foreach (var p in inboundBlocks)
            {
                blockToPromote.Pred.Remove(p);
            }
        }

        public void FixOutboundEdges(Block block)
        {
            for (int i = 0; i < block.Succ.Count; ++i)
            {
                var s = block.Succ[i];
                if (s.Procedure == block.Procedure)
                    continue;
                if (s.Procedure.EntryBlock.Succ[0] == s)
                {
                    var retCallThunkBlock = Scanner.CreateCallRetThunk(block.Procedure, s.Procedure);
                    block.Succ[i] = retCallThunkBlock;
                }
                s.ToString();
            }
        }

        private void ReplaceSuccessorsWith(Block block, Block blockOld, Block blockNew)
        {
            for (int s = 0; s < block.Succ.Count; ++s)
            {
                if (block.Succ[s] == blockOld)
                    block.Succ[s] = blockNew;
            }
        }

        private void FixExitEdges(Block block)
        {
            for (int i = 0; i < block.Succ.Count; ++i)
            {
                var s = block.Succ[i];
                if (s.Procedure != ProcNew && s == s.Procedure.ExitBlock)
                {
                    s.Pred.Remove(block);
                    ProcNew.ExitBlock.Pred.Add(block);
                    block.Succ[i] = ProcNew.ExitBlock;
                }
            }
        }
    }
}
