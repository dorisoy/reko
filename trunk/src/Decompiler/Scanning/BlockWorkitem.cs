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
    /// <summary>
    /// Scanner work item for processing basic blocks.
    /// </summary>
    public class BlockWorkitem : WorkItem, RtlInstructionVisitor<bool>
    {
        private IScanner scanner;
        private IProcessorArchitecture arch;
        private Address addrStart;
        private Block blockCur;
        private Frame frame;
        private RtlInstruction ri;
        private RtlInstructionCluster ric;
        private IEnumerator<RtlInstructionCluster> rtlStream;
        private ProcessorState state;
        private ExpressionSimplifier eval;
        private int extraLabels;
        private Identifier stackReg;

        public BlockWorkitem(
            IScanner scanner,
            ProcessorState state,
            Address addr)
        {
            this.scanner = scanner;
            this.arch = scanner.Architecture;   // cached since it's used heavily.
            this.state = state;
            this.eval = new ExpressionSimplifier(state);
            this.addrStart = addr;
            this.blockCur = null;
        }

        /// <summary>
        /// Processes the statements of a basic block by using the architecture-specific
        /// Rewriter to obtain a stream of low-level RTL instructions. RTL assignments are 
        /// simply added to the instruction list of the basic block. Jumps and returns result in the 
        /// termination of processing.
        /// </summary>
        public override void Process()
        {
            try
            {
                ProcessInternal();
            }
            catch (Exception ex)
            {
                if (ric == null)
                    throw;
                scanner.AddDiagnostic(ric.Address, new ErrorDiagnostic(ex.Message));
            }
        }

        public void ProcessInternal()
        {
            state.ErrorListener = (message) => { scanner.AddDiagnostic(ric.Address, new WarningDiagnostic(message)); };
            blockCur = scanner.FindContainingBlock(addrStart);
            if (BlockHasBeenScanned(blockCur))
                return;
            Debug.Print("Scanning jump target {0}", addrStart);
            frame = blockCur.Procedure.Frame;
            this.stackReg = frame.EnsureRegister(arch.StackRegister);
            rtlStream = scanner.GetTrace(addrStart, state, frame)
                .GetEnumerator();

            while (rtlStream.MoveNext())
            {
                ric = rtlStream.Current;
                if (blockCur != scanner.FindContainingBlock(ric.Address))
                    break;
                state.SetInstructionPointer(ric.Address);
                foreach (var rtlInstr in ric.Instructions)
                {
                    ri = rtlInstr;
                    if (!ri.Accept(this))
                        return;
                }
                var blNext = FallenThroughNextBlock(ric.Address + ric.Length);
                if (blNext != null)
                {
                    EnsureEdge(blockCur.Procedure, blockCur, blNext);
                    return;
                }
            }
        }

        private Block FallenThroughNextBlock(Address addr)
        {
            var cont = scanner.FindContainingBlock(addr);
            if (cont == null || cont == blockCur)
                return null;
            return BlockFromAddress(ric.Address, addr, blockCur.Procedure, state);
        }

        private bool BlockHasBeenScanned(Block block)
        {
            return block.Statements.Count > 0;
        }

        private Instruction BuildApplication(Expression fn, ProcedureSignature sig, CallSite site)
        {
            var ab = CreateApplicationBuilder(fn, sig, site);
            return ab.CreateInstruction();
        }

        private ApplicationBuilder CreateApplicationBuilder(Expression callee, ProcedureSignature sig, CallSite site)
        {
            var ab = new ApplicationBuilder(
                arch,
                frame,
                site,
                callee,
                sig, 
                false);
            return ab;
        }

        public Expression GetValue(Expression op)
        {
            return op.Accept<Expression>(eval);
        }

        public void SetValue(Expression dst, Expression  value)
        {
            var id = dst as Identifier;
            if (id != null)
            {
                state.SetValue(id, value);
                return;
            }
            var smem = dst as SegmentedAccess;
            if (smem != null)
            {
                state.SetValueEa(smem.BasePointer, GetValue(smem.EffectiveAddress), value);
            }
            var mem = dst as MemoryAccess;
            if (mem != null)
            {
                state.SetValueEa(GetValue(mem.EffectiveAddress), value);
                return;
            }
        }

        #region RtlInstructionVisitor Members

        public bool VisitAssignment(RtlAssignment a)
        {
            SetValue(a.Dst, GetValue(a.Src));
            var idDst = a.Dst as Identifier;
            var inst = (idDst != null)
                ? new Assignment(idDst, a.Src)
                : (Instruction) new Store(a.Dst, a.Src);
            Emit(inst);
            return true;
        }

        public bool VisitBranch(RtlBranch b)
        {
            // We don't know the 'then' block yet, as the following statements may chop up the block
            // we're presently in. Back-patch in when the block target is obtained.
            var branch = new Branch(b.Condition, new Block(blockCur.Procedure, "TMP!"));
            Emit(branch);

            // The following statements may chop up the blockCur, so hang on to the essentials.
            var proc = blockCur.Procedure;
            var fallthruAddress = ric.Address + ric.Length;

            var blockThen = BlockFromAddress(ric.Address, b.Target, proc, state.Clone());

            var blockElse = FallthroughBlock(ric.Address, proc, fallthruAddress);
            var branchingBlock = scanner.FindContainingBlock(ric.Address);
            branch.Target = blockThen;      // The back-patch referred to above.
            EnsureEdge(proc, branchingBlock, blockElse);
            EnsureEdge(proc, branchingBlock, blockThen);

            // Now, switch to the fallthru block and keep rewriting.
            blockCur = blockElse;
            return true;
        }

        public bool VisitIf(RtlIf rtlIf)
        {
            var branch = new Branch(rtlIf.Condition.Invert(), null);
            Emit(branch);

            var proc = blockCur.Procedure;
            var fallthruAddress = ric.Address + ric.Length;

            var blockInstr = AddIntraStatementBlock(proc);
            var blockFollow = BlockFromAddress(ric.Address, fallthruAddress, proc, state);

            blockCur = blockInstr;
            rtlIf.Instruction.Accept(this);

            var branchingBlock = scanner.FindContainingBlock(ric.Address);
            branch.Target = blockFollow;
            EnsureEdge(proc, branchingBlock, blockInstr);
            EnsureEdge(proc, branchingBlock, blockFollow);
            EnsureEdge(proc, blockInstr, blockFollow);

            blockCur = blockFollow;
            return true;
        }

        private Block BlockFromAddress(Address addrSrc, Address addrDst, Procedure proc, ProcessorState state)
        {
            return scanner.EnqueueJumpTarget(addrSrc, addrDst, proc, state);
        }

        private void EnsureEdge(Procedure proc, Block blockFrom, Block blockTo)
        {
            if (!proc.ControlGraph.ContainsEdge(blockFrom, blockTo))
                proc.ControlGraph.AddEdge(blockFrom, blockTo);
        }

        public bool VisitGoto(RtlGoto g)
        {
            scanner.TerminateBlock(blockCur, ric.Address + ric.Length);
            var addrTarget = g.Target as Address;
            if (addrTarget != null)
            {
                var blockTarget = BlockFromAddress(ric.Address, addrTarget, blockCur.Procedure, state);
                var blockSource = scanner.FindContainingBlock(ric.Address);
                EnsureEdge(blockSource.Procedure, blockSource, blockTarget);
                return false;
            }
            var mem = g.Target as MemoryAccess;
            if (mem != null)
            {
                if (mem.EffectiveAddress is Constant)
                {
                    var site = state.OnBeforeCall(this.stackReg, 4);            //$BUGBUG: hard coded.
                    Emit(new CallInstruction(g.Target, site));
                    Emit(new ReturnInstruction());
                    blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockCur.Procedure.ExitBlock);
                    return false;
                }
            }
            ProcessIndirectControlTransfer(ric.Address, g);
            return false;
        }

        private ProcedureConstant CreateProcedureConstant(ProcedureBase callee)
        {
            return new ProcedureConstant(arch.PointerType, callee);
        }

        public bool VisitCall(RtlCall call)
        {
            var site = state.OnBeforeCall(stackReg, call.ReturnAddressSize);
            ProcedureSignature sig;
            Address addr = call.Target as Address;
            if (addr != null)
            {
                var impProc = scanner.GetImportedProcedure(addr, this.ric.Address);
                if (impProc != null && impProc.Characteristics.IsAlloca)
                    return ProcessAlloca(site, impProc);

                var callee = scanner.ScanProcedure(addr, null, state);
                var pcCallee = CreateProcedureConstant(callee);
                sig = callee.Signature; 
                if (sig != null && sig.ArgumentsValid)
                {
                    Emit(BuildApplication(pcCallee, sig, site));
                }
                else 
                {
                    Emit(new CallInstruction(pcCallee, site));
                }
                var pCallee = callee as Procedure;
                if (pCallee != null)
                {
                    scanner.CallGraph.AddEdge(blockCur.Statements.Last, pCallee);
                }
                return OnAfterCall(sig, callee.Characteristics);
            }

            var procCallee = call.Target as ProcedureConstant;
            if (procCallee != null)
            {
                var ppp = procCallee.Procedure as PseudoProcedure;
                if (ppp != null)
                {
                    sig = ppp.Signature;
                    if (sig != null && sig.ArgumentsValid)
                    {
                        Emit(BuildApplication(procCallee, sig, site));
                    }
                    else
                    {
                        Emit(new CallInstruction(procCallee, site));
                    }
                    return OnAfterCall(ppp.Signature, ppp.Characteristics);
                } 
                var ep = procCallee.Procedure as ExternalProcedure;
                if (ep != null)
                {
                    sig = ep.Signature;
                    if (sig != null && sig.ArgumentsValid)
                    {
                        Emit(BuildApplication(procCallee, sig, site));
                    }
                    else
                    {
                        Emit(new CallInstruction(procCallee, site));
                    }
                    return OnAfterCall(ep.Signature, ep.Characteristics);
                }
            }
            sig = scanner.GetCallSignatureAtAddress(ric.Address);
            if (sig != null)
            {
                Emit(BuildApplication(call.Target, sig, site));
                return OnAfterCall(sig, null);  //$TODO: make characteristics available
            }

            var id = call.Target as Identifier;
            if (id != null)
            {
                var ppp = SearchBackForProcedureConstant(id);
                if (ppp != null)
                {
                    var e = CreateProcedureConstant(ppp);
                    if (ppp.Signature != null && ppp.Signature.ArgumentsValid)
                    {
                        Emit(BuildApplication(e, ppp.Signature, site));
                    }
                    else
                        Emit(new CallInstruction(e, site));
                    return OnAfterCall(ppp.Signature, ppp.Characteristics);
                }
            }

            var imp = ImportedProcedureName(call.Target);
            if (imp != null)
            {
                Emit(BuildApplication(CreateProcedureConstant(imp), imp.Signature, site));
                return OnAfterCall(imp.Signature, imp.Characteristics);
            }

            var syscall = scanner.Platform.FindService(call, state);
            if (syscall != null)
            {
                return !EmitSystemServiceCall(syscall);
            }
            ProcessIndirectControlTransfer(ric.Address, call);

            var ic = new CallInstruction(call.Target, site);
            Emit(ic);
            sig = GuessProcedureSignature(ic);
            return OnAfterCall(sig, null);
        }

        private bool OnAfterCall(ProcedureSignature sigCallee, Decompiler.Core.Serialization.ProcedureCharacteristics characteristics)
        {
            if (sigCallee == null)
                return true;
            state.OnAfterCall(stackReg, sigCallee, eval);
            if (characteristics != null && characteristics.Terminates)
                return false;

            int delta = sigCallee.StackDelta - sigCallee.ReturnAddressOnStack;
            if (delta != 0)
            {
                var d = Constant.Create(stackReg.DataType, delta);
                this.Emit(new Assignment(
                    stackReg,
                    new BinaryExpression(Operator.IAdd, stackReg.DataType, stackReg, d)));
            }
            return true;
        }

        public bool VisitReturn(RtlReturn ret)
        {
            var proc = blockCur.Procedure;
            Emit(new ReturnInstruction());
            proc.ControlGraph.AddEdge(blockCur, proc.ExitBlock);

            int returnAddressBytes = ret.ReturnAddressBytes;
            var address = ric.Address;
            scanner.SetProcedureReturnAddressBytes(proc, returnAddressBytes, address);

            int stackDelta = ret.ReturnAddressBytes + ret.ExtraBytesPopped;
            if (proc.Signature.StackDelta != 0 && proc.Signature.StackDelta != stackDelta)
            {
                scanner.AddDiagnostic(
                    ric.Address,
                    new WarningDiagnostic(string.Format(
                    "Multiple different values of stack delta in procedure {0} when processing RET instruction; was {1} previously.", proc.Name, proc.Signature.StackDelta)));
            }
            else
            {
                proc.Signature.StackDelta = stackDelta;
            }
            state.OnProcedureLeft(proc.Signature);
            scanner.TerminateBlock(blockCur, ric.Address + ric.Length);
            return false;
        }

        public bool VisitSideEffect(RtlSideEffect side)
        {
            var svc = MatchSyscallToService(side);
            if (svc != null)
            {
                return !EmitSystemServiceCall(svc);
            }
            else
            {
                Emit(new SideEffect(side.Expression));
                var appl = side.Expression as Application;
                if (appl != null)
                {
                    var fn = appl.Procedure as ProcedureConstant;
                    if (fn != null)
                        return !fn.Procedure.Characteristics.Terminates;
                }
            }
            return true;
        }

        /// <summary>
        /// Takes a system service description and generates a system call from it.
        /// </summary>
        /// <param name="svc"></param>
        /// <returns>True if the system service terminates.</returns>
        private bool EmitSystemServiceCall(SystemService svc)
        {
            var ep = svc.CreateExternalProcedure(arch);
            var fn = new ProcedureConstant(arch.PointerType, ep);
            var site = state.OnBeforeCall(stackReg, svc.Signature.ReturnAddressOnStack);
            Emit(BuildApplication(fn, ep.Signature, site));
            if (svc.Characteristics.Terminates)
            {
                blockCur.Procedure.ControlGraph.AddEdge(blockCur, blockCur.Procedure.ExitBlock);
                return true;
            }
            AffectProcessorState(svc.Signature);
            return false;
        }

        private ProcedureSignature GuessProcedureSignature(CallInstruction call)
        {
            return new ProcedureSignature(); //$TODO: attempt to detect parameters of procedure?
            // This would have to be arch-dependent + platform-dependent as some arch pass
            // on stack, while others pass in registers, or a combination or both
            // ("thiscall" in x86 µsoft world).
        }

        public bool ProcessAlloca(CallSite site, ExternalProcedure impProc)
        {
            if (impProc.Signature == null)
                throw new ApplicationException(string.Format("You must specify a procedure signature for {0} since it has been marked as 'alloca'.", impProc.Name));
            var ab = CreateApplicationBuilder(new ProcedureConstant(arch.PointerType, impProc), impProc.Signature, site);
            if (impProc.Signature.FormalArguments.Length != 1)
                throw new ApplicationException(string.Format("An alloca function must have exactly one parameter, but {0} has {1}.", impProc.Name, impProc.Signature.FormalArguments.Length));
            var target = ab.Bind(impProc.Signature.FormalArguments[0]);
            var id = target as Identifier;
            if (id == null)
                throw new ApplicationException(string.Format("The parameter of {0} wasn't a register.", impProc.Name));
            Constant c = state.GetValue(id) as Constant;
            if (c != null && c.IsValid)
            {
                Emit(new Assignment(stackReg, new BinaryExpression(Operator.ISub, stackReg.DataType, stackReg, c)));
            }
            else
            {
                Emit(ab.CreateInstruction());
            }
            return true;
        }

        #endregion

        private void ProcessIndirectControlTransfer(Address addrSwitch, RtlTransfer xfer)
        {
            var bw = new Backwalker(new BackwalkerHost(scanner), xfer, eval);
            if (!bw.CanBackwalk())
            {
                scanner.AddDiagnostic(addrSwitch, new WarningDiagnostic(
                    string.Format("Unable to determine index register used in transfer instruction {0}.", xfer)));
                return;
            }
            var bwops = bw.BackWalk(blockCur);
            if (bwops.Count == 0)
                return;     //$REVIEW: warn?
            var idIndex = blockCur.Procedure.Frame.EnsureRegister(bw.Index);

            VectorBuilder builder = new VectorBuilder(arch, scanner, new DirectedGraphImpl<object>());
            List<Address> vector = builder.BuildAux(bw, addrSwitch, state);
            if (vector.Count == 0)
            {
                var addrNext = bw.VectorAddress + bw.Stride;
                var rdr = scanner.CreateReader(bw.VectorAddress);
                if (!rdr.IsValid)
                    return;
                // Can't determine the size of the table, but surely it has one entry?
                vector.Add(arch.ReadCodeAddress(xfer.Target.DataType.Size, rdr, state));
            }

            ScanVectorTargets(xfer, vector);

            if (xfer is RtlGoto)
            {
                var blockSource = scanner.FindContainingBlock(ric.Address);
                blockCur = blockSource;
                foreach (Address addr in vector)
                {
                    var dest = scanner.FindContainingBlock(addr);
                    Debug.Assert(dest != null, "The block at address " + addr + "should have been enqueued.");
                    blockSource.Procedure.ControlGraph.AddEdge(blockSource, dest);
                }
                Emit(new SwitchInstruction(idIndex, blockCur.Procedure.ControlGraph.Successors(blockCur).ToArray()));
            }
            //vectorUses[wi.addrFrom] = new VectorUse(wi.Address, builder.IndexRegister);
            scanner.ImageMap.AddItem(bw.VectorAddress,
                new ImageMapVectorTable(xfer is RtlCall, vector.ToArray(), builder.TableByteSize));
        }

        private void ScanVectorTargets(RtlTransfer xfer, List<Address> vector)
        {
            foreach (Address addr in vector)
            {
                var st = state.Clone();
                if (xfer is RtlCall)
                {
                    var pbase = scanner.ScanProcedure(addr, null, st);
                    var pcallee = pbase as Procedure;
                    if (pcallee != null)
                    {
                        scanner.CallGraph.AddEdge(blockCur.Statements.Last, pcallee);
                    }
                }
                else
                {
                    BlockFromAddress(ric.Address, addr, blockCur.Procedure, state);
                }
            }
        }

        private void Emit(Instruction instruction)
        {
            blockCur.Statements.Add(ric.Address.Linear, instruction);
        }

        private Block FallthroughBlock(Address addrSrc, Procedure proc, Address fallthruAddress)
        {
            if (ri.NextStatementRequiresLabel)
            {
                // Some machine instructions, like the X86 'rep cmps' instruction, force the need to generate 
                // a label where there wouldn't be one normally, in the middle of the rtl sequence corresponding to
                // the machine instruction.
                return AddIntraStatementBlock(proc);
            }
            else
            {
                return BlockFromAddress(addrSrc, fallthruAddress, proc, state);
            }
        }

        private Block AddIntraStatementBlock(Procedure proc)
        {
            var fallthru = new Block(proc, ric.Address.GenerateName("l", string.Format("_{0}", ++extraLabels)));
            proc.ControlGraph.Blocks.Add(fallthru);
            return fallthru;
        }

        /// <summary>
        /// Searches backwards to find a ProcedureConstant that is assigned to the identifier id.
        /// </summary>
        /// <remarks>
        /// This is a sleazy hack since we pay absolutely no attention to register liveness &c. However,
        /// the code is written in the spirit of "innocent until proven guilty". If this turns out to be buggy,
        /// and false positives occur, it will have to be canned and a better solution will have to be invented.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        //$REVIEW: we're effectively doing constant propagation during scanning, why not use that information?
        // Because the scanner constant propagation is doing its propagation by bits (see X86Processorstate)
        // but we want to propagate procedure constants. For the future: change processor state to handle
        // not only numeric constants, but all constants.
        private ProcedureBase SearchBackForProcedureConstant(Identifier id)
        {
            var visited = new HashSet<Block>();
            Block block = blockCur;
            while (block != null && !visited.Contains(block))
            {
                visited.Add(block);
                for (int i = block.Statements.Count - 1; i >= 0; --i)
                {
                    Assignment ass = block.Statements[i].Instruction as Assignment;
                    if (ass == null)
                        continue;
                    Identifier idAss = ass.Dst as Identifier;
                    if (idAss != null && idAss == id)
                    {
                        ProcedureConstant pc = ass.Src as ProcedureConstant;
                        if (pc != null)
                        {
                            return pc.Procedure;
                        }
                        var imp = ImportedProcedureName(ass.Src);
                        if (imp != null)
                            return new ExternalProcedure(imp.Name, imp.Signature, imp.Characteristics);
                        else
                            return null;
                    }
                }
                var pred = block.Procedure.ControlGraph.Predecessors(block).ToArray();
                if (pred.Length != 1)
                    return null;
                block = pred[0];
            }
            return null;
        }

        private void DumpCfg()
        {
            foreach (Block block in blockCur.Procedure.ControlGraph.Blocks)
            {
                Console.WriteLine("block: {0}", block.Name);
                Console.Write("\tpred:");
                foreach (var p in block.Procedure.ControlGraph.Predecessors(block))
                {
                    Console.Write(" {0}", p.Name);
                }
                Console.WriteLine();
                Console.Write("\tsucc:");
                foreach (var s in block.Procedure.ControlGraph.Successors(block))
                {
                    Console.Write(" {0}", s.Name);
                }
                Console.WriteLine();
            }
        }

        public ExternalProcedure ImportedProcedureName(Expression callTarget)
        {
            var mem = callTarget as MemoryAccess;
            if (mem == null)
                return null;
            if (mem.EffectiveAddress.DataType.Size != PrimitiveType.Word32.Size)
                return null;
            var offset = mem.EffectiveAddress as Constant;
            if (offset == null)
                return null;
            return scanner.GetImportedProcedure(new Address(offset.ToUInt32()), ric.Address);
        }

        //$TODO: merge the followng two procedures?
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
            var reg = id.Storage as RegisterStorage;
            if (reg != null)
            {
                state.SetValue(id, Constant.Invalid);
            }
            SequenceStorage seq = id.Storage as SequenceStorage;
            if (seq != null)
            {
                TrashVariable(seq.Head);
                TrashVariable(seq.Tail);
            }
        }

        private SystemService MatchSyscallToService(RtlSideEffect side)
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

        private class BackwalkerHost : IBackWalkHost
        {
            private IScanner scanner;

            public BackwalkerHost(IScanner scanner)
            {
                this.scanner = scanner;
            }

            public void AddDiagnostic(Address addr, Diagnostic d)
            {
                scanner.AddDiagnostic(addr, d);
            }

            public AddressRange GetSinglePredecessorAddressRange(Address block)
            {
                throw new NotImplementedException();
            }

            public Address GetBlockStartAddress(Address addr)
            {
                throw new NotImplementedException();
            }

            public Block GetSinglePredecessor(Block block)
            {
                return block.Procedure.ControlGraph.Predecessors(block).FirstOrDefault();
            }
        }
    }
}
