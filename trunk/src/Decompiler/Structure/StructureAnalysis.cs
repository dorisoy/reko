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

using Decompiler.Core;
using Decompiler.Core.Absyn;
using Decompiler.Core.Code;
using Decompiler.Core.Output;
using Decompiler.Core.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Decompiler.Structure
{
    public class StructureAnalysis
    {
        private Procedure proc;
        private ProcedureStructure curProc;

        public StructureAnalysis(Procedure proc)
        {
            this.proc = proc;
        }

        public void Structure()
        {
            CoalesceCompoundConditions();
            BuildProcedureStructure();
            FindStructures();
            GenerateStructuredCode();
        }

        /// <summary>
        /// This routine is called after all the other structuring has been done. It detects
        /// conditionals that are in fact the head of a jump into/outof a loop or into a case body. 
        /// Only forward jumps are considered as unstructured backward jumps will always be generated nicely.
        /// </summary>
        /// <param name="curProc"></param>
        public void DetectUnstructuredConditionals(ProcedureStructure curProc)
        {
            foreach (StructureNode node in curProc.Ordering)
            {
                Loop myLoop = node.Loop;
                Loop follLoop = node.Conditional.Follow.Loop;
                if (IsTwoWayBranchWithFollow(node))
                {

                    // analyze whether this is a jump into/outof a loop
                    if (myLoop != follLoop)
                    {
                        // we want to find the branch that the latch node is on for a jump out of a loop
                        if (myLoop != null)
                        {
                            SetUnstructuredLoopTransfer(node, myLoop.Latch);
                        }

                        if (follLoop != null)
                        {
                            if (node.UnstructType == UnstructuredType.Structured)
                            // find the branch that the loop head is on for a jump into a loop body. If a branch has
                            // already been found, then it will match this one anyway
                            {
                                SetUnstructuredLoopTransfer(node, follLoop.Header);
                            }
                        }
                    }

                    // this is a jump into a case body if either of its children don't have the same
                    // same case header as itself
                    if (IsJumpIntoCaseBody(node))
                    {
                        StructureNode myCaseHead = node.CaseHead;
                        StructureNode thenCaseHead = node.Then.CaseHead;
                        StructureNode elseCaseHead = node.Else.CaseHead;
                        if (thenCaseHead == myCaseHead && (myCaseHead == null || elseCaseHead != myCaseHead.Conditional.Follow))
                        {
                            node.UnstructType = UnstructuredType.JumpIntoCase;
                            node.Conditional = new IfElse(null);
                        }
                        else if (elseCaseHead == myCaseHead && (myCaseHead == null || thenCaseHead != myCaseHead.Conditional.Follow))
                        {
                            node.UnstructType = UnstructuredType.JumpIntoCase;
                            node.Conditional = new IfThen(null);
                        }
                    }
                }

                // for 2 way conditional headers that don't have a follow (i.e. are the source of a back
                // edge) and haven't been structured as latching nodes, set their follow to be the
                // non-back edge child.
                if (node.Conditional != null && node.Conditional.Follow == null &&
                     node.UnstructType == UnstructuredType.Structured && !(node.Conditional is Case))
                {
                    Debug.Assert(HasABackEdge(node));
                    if (node.HasBackEdgeTo(node.Then))
                    {
                        node.Conditional = new IfThen(node.Else);
                    }
                    else
                    {
                        node.Conditional = new IfElse(node.Then);
                    }
                }
            }
        }

        [Obsolete]
        private  bool IsJumpIntoCaseBody(StructureNode curNode)
        {
            return curNode.UnstructType == UnstructuredType.Structured &&
                                     (curNode.CaseHead != curNode.Then.CaseHead ||
                                      curNode.CaseHead != curNode.Else.CaseHead);
        }

        [Obsolete]
        private void SetUnstructuredLoopTransfer(StructureNode curNode, StructureNode loopNode)
        {
            if (curNode.Then == loopNode || curNode.Then.IsAncestorOf(loopNode))
            {
                curNode.UnstructType = UnstructuredType.JumpInOutLoop;
                curNode.Conditional = new IfElse(null);
            }
            else if (curNode.Else == loopNode || curNode.Else.IsAncestorOf(loopNode))
            {
                curNode.UnstructType = UnstructuredType.JumpInOutLoop;
                curNode.Conditional = new IfThen(null);
            }
        }

        [Obsolete]
        private bool IsTwoWayBranchWithFollow(StructureNode curNode)
        {
            return curNode.Conditional != null && curNode.Conditional.Follow != null && !(curNode.Conditional is Case);
        }

        /// <summary>
        /// Structures all conditional headers (i.e. nodes with more than one out edge)
        /// </summary>
        private void StructConds()
        {
            foreach (StructureNode curNode in curProc.Ordering)
            {
                if (curNode.OutEdges.Count < 2)
                    continue;
                
                // if the current conditional header is a two way node and has a back edge, 
                // then it won't have a follow.
                if (HasABackEdge(curNode) && curNode.BlockType == BlockTerminationType.cBranch)
                {
                    curNode.Conditional = CreateConditional(curNode, null);
                }
                else
                {
                    curNode.Conditional = CreateConditional(curNode, curNode.ImmPDom);
                }
            }
        }

        private Conditional CreateConditional(StructureNode node, StructureNode follow)
        {
            if (node.BlockType == BlockTerminationType.nway)
            {
                var c = new Case(follow);
                var cf = new CaseFinder(node, follow);
                cf.SetCaseHead(node);
                return c;
            }
            else if (node.Else == follow)
                return new IfThen(follow);
            else if (node.Then == follow)
                return new IfElse(follow);
            else
                return new IfThenElse(follow);
        }

        [Obsolete]
        private bool HasABackEdge(StructureNode curNode)
        {
            return curNode.HasABackEdge();
        }


        private void GenerateStructuredCode()
        {
            AbsynCodeGenerator codeGen = new AbsynCodeGenerator();
            curProc.Dump();
            codeGen.GenerateCode(curProc, proc.Body);
        }

        private void CoalesceCompoundConditions()
        {
            var ccc = new CompoundConditionCoalescer(proc);
            ccc.Transform();
        }

        public void BuildProcedureStructure()
        {
            var cfgs = new ProcedureStructureBuilder(proc);
            curProc = cfgs.Build();
            cfgs.AnalyzeGraph();
        }

        public void FindStructures()
        {
            StructConds();
            StructLoops(curProc);
            var uns = new UnstructuredConditionalAnalysis(curProc);
            uns.Adjust();
        }

        private void StructLoops(ProcedureStructure curProc)
        {
            for (int gLevel = 0; gLevel < curProc.DerivedGraphs.Count; ++gLevel)
            {
                var curGraph = curProc.DerivedGraphs[gLevel];
                foreach (Interval curInt in curGraph.Intervals)
                {
                    var headNode = IntervalHeaderNode(curInt);
                    var intNodes = curInt.FindIntervalNodes(gLevel);
                    var latch = FindGreatestEnclosingBackEdgeInInterval(headNode, intNodes);

                    // If a latch was found and it doesn't belong to another loop, 
                    // tag the loop nodes and classify it.
                    if (latch != null && latch.Loop == null)
                    {
                        CreateLoop(curProc, headNode, intNodes, latch);
                    }
                }
            }
        }

        private StructureNode IntervalHeaderNode(Interval interval)
        {
            var headNode = interval.Header as Interval;
            while (headNode != null)
            {
                interval = headNode;
                headNode = interval.Header as Interval;
            }
            return interval.Header;
        }

        private StructureNode FindGreatestEnclosingBackEdgeInInterval(StructureNode headNode, HashSet<StructureNode> intNodes)
        {
            StructureNode latch = null;
            foreach (StructureNode pred in headNode.InEdges)
            {
                if (!pred.HasBackEdgeTo(headNode))
                    continue;
                if (!intNodes.Contains(pred))
                    continue;
                if (pred.CaseHead != headNode.CaseHead)
                    continue;
                if (latch == null || latch.Order > pred.Order)
                    latch = pred;
            }
            return latch;
        }


        private void CreateLoop(ProcedureStructure curProc, StructureNode headNode, HashSet<StructureNode> intervalNodes, StructureNode latch)
        {
            Debug.WriteLine(string.Format("Creating loop {0}-{1}", headNode.Name, latch.Name));

            // if the head node has already been determined as a loop header then the nodes
            // within this loop have to be untagged and the latch reset to its original type
            if (headNode.Loop != null && headNode.Loop.Latch != null)
            {
                StructureNode oldLatch = headNode.Loop.Latch;

                // reset the latch node's structured class. Only need to do this for a 2 way latch
//                if (oldLatch.BlockType == bbType.cBranch)
//                    oldLatch.SetStructType(structType.Cond);

                // untag the nodes
                for (int i = headNode.Order - 1; i >= oldLatch.Order; i--)
                    if (curProc.Ordering[i].Loop.Header == headNode)
                        curProc.Ordering[i].Loop = null;
            }


            // the latching node will already have been structured as a conditional header. If it is not
            // also the loop header (i.e. the loop is over more than one block) then reset
            // it to be a sequential node otherwise it will be correctly set as a loop header only later
//            if (latch != headNode)
//                latch.SetStructType(structType.Seq);


            LoopFinder lf = new LoopFinder(headNode, latch, curProc.Ordering);
            HashSet<StructureNode> loopNodes = lf.FindNodesInLoop(intervalNodes);
            Loop loop = lf.DetermineLoopType(loopNodes);
            lf.TagNodesInLoop(loop, loopNodes);
        }

        public ProcedureStructure ProcedureStructure
        {
            get { return curProc; }
        }
    }
}