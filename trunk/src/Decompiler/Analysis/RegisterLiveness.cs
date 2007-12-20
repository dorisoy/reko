/* 
 * Copyright (C) 1999-2007 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Operators;
using System;
using System.Diagnostics;
using System.Collections;
using BitSet = Decompiler.Core.Lib.BitSet;
using Hashtable = System.Collections.Hashtable;

namespace Decompiler.Analysis
{
	using StringBuilder = System.Text.StringBuilder;
	using StringWriter = System.IO.StringWriter;

	/// <summary>
	/// Implements Interprocedural Register Liveness as described by 
	/// Robert Muth (Register Liveness of Executable Code)
	/// </summary>
	/// <remarks>
	/// Procedures need to be teased apart from each other. This is done by finding
	/// what registers are live in and live out from procedures. Once this is known,
	/// we can summarize the effects of a procedure, and use that information when
	/// rewriting call sites to SSA form.
	/// </remarks>
	public class RegisterLiveness : InstructionVisitorBase		//$REFACTOR: should be called InterproceduralLiveness
	{
		private Program prog;
		private Procedure proc;
		private WorkList worklist;
		private ProgramDataFlow mpprocData;
		private State state;
		private Statement stmCur;
		private IdentifierLiveness varLive;
		private int bitUseOffset;
		private int cbitsUse;
		private IsLiveHelper isLiveHelper;

		private static TraceSwitch trace = new TraceSwitch("RegisterLiveness", "Details of register liveness analysis");

		public RegisterLiveness(Program prog, ProgramDataFlow procFlow)
		{
			this.prog = prog;
			this.mpprocData = procFlow;
			this.worklist = new WorkList();
			this.varLive = new IdentifierLiveness(prog.Architecture);
			this.isLiveHelper = new IsLiveHelper();
			CollectBasicBlocks();
			Dump();
		}

		private void CollectBasicBlocks()
		{
			foreach (Procedure proc in prog.Procedures.Values)
			{
				foreach (Block block in proc.RpoBlocks)
				{
					worklist.Add(mpprocData[block]);
				}
			}
		}
		
		/// <summary>
		/// Computes intraprocedural liveness of the program <paramref name="p"/>,
		/// storing the results in <paramref name="procFlow"/>.
		/// </summary>
		/// <param name="p"></param>
		/// <param name="procFlow"></param>
		/// <returns></returns>
		public static RegisterLiveness Compute(Program p, ProgramDataFlow procFlow)
		{
			RegisterLiveness live = new RegisterLiveness(p, procFlow);
			Debug.WriteLineIf(trace.TraceError, "** Computing ByPass ****");
			live.CurrentState = new ByPassState();
			live.Iterate();

			Debug.WriteLineIf(trace.TraceError, "** Computing MayUse ****");
			live.CurrentState = new MayUseState();
			if (trace.TraceInfo) live.Dump();
			live.Iterate();
			
			//$REVIEW: since we never use the liveinstate, can we get rid of the following
			// four statements?
			Debug.WriteLineIf(trace.TraceError, "** Computing LiveIn ****");
			live.CurrentState = new LiveInState();
			if (trace.TraceInfo) live.Dump();
			live.Iterate();

			live.CompleteWork();
			if (trace.TraceInfo) live.Dump();

			return live;
		}

		/// <summary>
		/// Make summary information available in LiveIn and LiveOut for each procedure.
		/// </summary>
		private void CompleteWork()
		{
			foreach (Procedure proc in prog.Procedures.Values)
			{
				ProcedureFlow pi = mpprocData[proc];

				BlockFlow bi = mpprocData[proc.ExitBlock];
				pi.LiveOut = bi.DataOut;
				pi.grfLiveOut = bi.grfOut;

				// Remove unneeded data. Done for performance (and to give GC something to do).

				pi.ByPass = null;
			}
		}

		private void Def(Identifier id)
		{
			varLive.Def(proc.Frame.Identifiers[id.Number]);
		}

		private void DumpBlock(Block block)
		{
			StringWriter sw = new StringWriter();
			block.Write(sw);
			Debug.WriteLine(sw.ToString());
		}

		private string DumpRegisters(BitSet arr)
		{
			StringBuilder sb = new StringBuilder();
			IProcessorArchitecture arch = prog.Architecture;
			for (int i = 0; i < arr.Count; ++i)
			{
				if (arr[i])
				{
					MachineRegister reg = arch.GetRegister(i);
					if (reg != null && reg.IsAluRegister)
					{
						sb.Append(reg.Name);
						sb.Append(" ");
					}
				}
			}
			return sb.ToString();
		}

		private void InitializeWorkList()
		{
			foreach (object b in mpprocData.Values)
			{
				if (b is BlockFlow)
					worklist.Add(b);
			}
		}


		private void Iterate()
		{
			InitializeWorkList();
			while (!worklist.IsEmpty)
			{
				object o = worklist.GetWorkItem();
				BlockFlow item = (BlockFlow) o;
				ProcessBlock(item);
			}
		}

		public Procedure Procedure
		{
			get { return proc; }
			set { proc = value; }
		}

		/// <summary>
		/// Processes the data flow of a block by beginning with
		/// the dataOut after the last instruction, simluates all instructions
		/// until the beginning of the block is reached, and percolates any
		/// *changes* to predecessor blocks to the worklist for futher processing.
		/// </summary>
		/// <param name="item">The block dataflow item we are about to process</param>
		public void ProcessBlock(BlockFlow item)
		{
			bool t = trace.TraceInfo;
			if (t)
			{
				Debug.Write(item.Block.Procedure.Name + ", ");
				DumpBlock(item.Block);
			}
			
			varLive.BitSet = new BitSet(item.DataOut);
			varLive.Grf = item.grfOut;
			varLive.LiveStackVariables = item.StackVarsOut.Clone();

			Debug.WriteLineIf(t, string.Format("   out: {0}", DumpRegisters(varLive.BitSet)));
			Procedure = item.Block.Procedure;		// Used by statements because we need to lookup registers using identifiers and the procedure frame.
			StatementList stms = item.Block.Statements;
			for (int i = stms.Count - 1; i >= 0; --i)
			{
				stmCur = stms[i];
				Debug.WriteLineIf(t, stms[i].Instruction);
				stmCur.Instruction.Accept(this);
				if (t)
					Debug.WriteLineIf(t, string.Format("\tin: {0}", DumpRegisters(varLive.BitSet)));
			}

			if (item.Block == item.Block.Procedure.EntryBlock)
			{
				PropagateToProcedureSummary(item.Block.Procedure);
			}
			else
			{
				PropagateToPredecessorBlocks(item);
			}
		}

		private void Dump()
		{
			foreach (Procedure proc in prog.Procedures.Values)
			{
				StringWriter sw = new StringWriter();
				ProcedureFlow flow = mpprocData[proc];
				sw.WriteLine(proc.Name);
				DataFlow.EmitRegisters(prog.Architecture, "\tByPass: ", flow.ByPass, sw); sw.WriteLine();
				DataFlow.EmitRegisters(prog.Architecture, "\tMayUse: ", flow.MayUse, sw); sw.WriteLine();
				Debug.WriteLine(sw.ToString());
			}
		}

		private void Dump(bool enable, string s, BitSet a)
		{
			if (enable)
			{
				StringWriter sw = new StringWriter();
				sw.Write("{0}: ", s);
				ProcedureFlow.EmitRegisters(prog.Architecture, "", a, sw);
				Debug.WriteLine(sw.ToString());
			}
		}

		public void MarkLiveStackParameters(CallInstruction ci)
		{
			int cBegin = ci.Callee.Frame.GetStackArgumentSpace();
			foreach (Identifier id in Procedure.Frame.Identifiers)
			{
				StackLocalStorage sl = id.Storage as StackLocalStorage;
				if (sl == null)
					continue;
				if (-ci.CallSite.StackDepthBefore <= sl.StackOffset && sl.StackOffset < cBegin - ci.CallSite.StackDepthBefore)
				{
					Use(id);
				}
			}
		}

		public void MergeBlockInfo(Block block)
		{
			BlockFlow blockFlow = mpprocData[block];
			if (state.MergeBlockInfo(varLive, blockFlow))
			{
				worklist.Add(blockFlow);
			}
		}

		
		public bool MergeIntoProcedureFlow(IdentifierLiveness varLive, ProcedureFlow item)
		{
			bool fChange = false;
			if (!(varLive.BitSet & ~item.Summary).IsEmpty)
			{
				item.Summary |= varLive.BitSet;
				fChange = true;
			}
			if ((varLive.Grf & ~item.grfSummary) != 0)
			{
				item.grfSummary |= varLive.Grf;
				fChange = true;
			}
			foreach (DictionaryEntry de in varLive.LiveStackVariables)
			{
				StackArgumentStorage sa = de.Key as StackArgumentStorage;
				if (sa == null)
					continue;
				int bits = (int) de.Value;

				object o = item.StackArguments[sa];
				if (o != null)
				{
					int bitsOld = (int) o;
					if (bitsOld < bits)
					{
						item.StackArguments[sa] = bits;
						fChange = true;
					}
				}
				else
				{
					item.StackArguments[sa] = bits;
					fChange = true;
				}
			}
			return fChange;
		}

		/// <summary>
		/// Propagates the live-out from a call instruction to
		/// the exit block of the function the call statement invokes.
		/// </summary>
		/// <param name="stm"></param>
		private void PropagateToCalleeExitBlocks(Statement stm)
		{
			BitSet liveOrig = new BitSet(varLive.BitSet);
			uint grfOrig = varLive.Grf;
			StorageWidthMap stackOrig = varLive.LiveStackVariables.Clone();
			foreach (Procedure p in prog.CallGraph.Callees(stm))
			{
				ProcedureFlow flow = mpprocData[p];
				varLive.BitSet = liveOrig - flow.PreservedRegisters;
				varLive.LiveStackVariables = new StorageWidthMap();
				MergeBlockInfo(p.ExitBlock);
				varLive.BitSet = new BitSet(liveOrig);
				varLive.Grf = grfOrig;
				varLive.LiveStackVariables = stackOrig.Clone();
			}
		}

		/// <summary>
		/// Propagates liveness information to predecessor blocks, but only
		/// if there are changes to their dataOut fields.
		/// </summary>
		/// <param name="item"></param>
		private void PropagateToPredecessorBlocks(BlockFlow item)
		{
			foreach (Block p in item.Block.Pred)
			{
				MergeBlockInfo(p);
			}
		}

		/// <summary>
		/// When liveness analysis reaches the entry block of the procedure,
		/// update the procedure summary information with the current set of
		/// live registers.
		/// </summary>
		/// <param name="p"></param>
		public void PropagateToProcedureSummary(Procedure p)
		{
			bool fChange = false;
			ProcedureFlow item = mpprocData[p];
			
			state.ApplySavedRegisters(item, varLive);
			fChange = MergeIntoProcedureFlow(varLive, item);
			if (fChange)
			{
				if (trace.TraceInfo) Debug.WriteLineIf(trace.TraceInfo, item.EmitRegisters(prog.Architecture, p.Name + " summary:", item.Summary));
				state.UpdateSummary(item);
				foreach (Statement stmCaller in prog.CallGraph.CallerStatements(p))
				{
					if (trace.TraceInfo) Debug.WriteLineIf(trace.TraceVerbose, string.Format("Propagating to {0} (block {1} in {2}", stmCaller.Instruction.ToString(), stmCaller.block.RpoNumber, stmCaller.block.Procedure.Name));
					worklist.Add(mpprocData[stmCaller.block]);
				}
			}
		}


		private void Use(Identifier id)
		{
			varLive.Use(proc.Frame.Identifiers[id.Number], bitUseOffset, cbitsUse);
		}
 
		public IdentifierLiveness IdentifierLiveness
		{
			get { return varLive; }
		}

		public void VisitAssignmentInner(Identifier idDst, Expression src)
		{
			Def(idDst);
			bitUseOffset = varLive.DefOffset;
			cbitsUse = varLive.DefBitSize;
			src.Accept(this);
		}

		public void VisitCopy(Identifier idDst, Identifier idSrc)
		{
			if (isLiveHelper.IsLive(idDst, this.varLive))
			{
				VisitAssignmentInner(idDst, idSrc);
			}
			else
			{
				Def(idDst);
			}
		}

		#region InstructionVisitor methods ////////////////////////////////////////////////////////////

		private void Dump(string caption, IdentifierLiveness vl)
		{
			StringWriter sw = new System.IO.StringWriter();
			vl.Write(sw, caption);
			Debug.WriteLine(sw.ToString());
		}	

		public override void VisitAssignment(Assignment a)
		{
			Identifier idSrc = a.Src as Identifier;
			if (idSrc != null)
			{
				VisitCopy(a.Dst, idSrc);
			}
			else
			{
				VisitAssignmentInner(a.Dst, a.Src);
			}
		}


		public override void VisitApplication(Application appl)
		{
			appl.Procedure.Accept(this);
			for (int i = 0; i < appl.Arguments.Length; ++i)
			{
				bitUseOffset = 0;
				cbitsUse = 0;
				UnaryExpression u = appl.Arguments[i] as UnaryExpression;
				if (u != null && u.op == Operator.addrOf)
				{
					Identifier id = (Identifier) u.Expression;
					Def(id);
				}
			}
			for (int i = 0; i < appl.Arguments.Length; ++i)
			{	
				UnaryExpression u = appl.Arguments[i] as UnaryExpression;
				if (u == null || u.op != Operator.addrOf)
				{
					appl.Arguments[i].Accept(this);
				}
			}
		}

		public override void VisitBinaryExpression(BinaryExpression binExp)
		{
			if (binExp.op is ConditionalOperator ||
				binExp.op == BinaryOperator.muls ||
				binExp.op == BinaryOperator.mulu ||
				binExp.op == BinaryOperator.divs ||
				binExp.op == BinaryOperator.divu)
			{
				bitUseOffset = 0;
				cbitsUse = 0;
			}
			binExp.Left.Accept(this);

			if (binExp.op == BinaryOperator.shl ||
				binExp.op == BinaryOperator.sar ||
				binExp.op == BinaryOperator.muls ||
				binExp.op == BinaryOperator.mulu ||
				binExp.op == BinaryOperator.divs ||
				binExp.op == BinaryOperator.divu)
			{
				bitUseOffset = 0;
				cbitsUse = 0;
			}
			binExp.Right.Accept(this);
		}

		public override void VisitCallInstruction(CallInstruction ci)
		{
			if (ci.Callee.Signature != null && ci.Callee.Signature.ArgumentsValid)		
			{
				ProcedureSignature sig = ci.Callee.Signature;
				if (sig.ReturnValue != null)
				{
					varLive.Def(sig.ReturnValue.Storage.BindFormalArgumentToFrame(proc.Frame, ci.CallSite));
				}
				foreach (Identifier arg in sig.Arguments)
				{
					if (arg.Storage is OutArgumentStorage)
					{
						varLive.Def(arg.Storage.BindFormalArgumentToFrame(proc.Frame, ci.CallSite));
					}
				}

				foreach (Identifier arg in sig.Arguments)
				{
					if (!(arg.Storage is OutArgumentStorage))
					{
						varLive.Use(arg.Storage.BindFormalArgumentToFrame(proc.Frame, ci.CallSite));
					}
				}
			}
			else
			{
				if (state.PropagateThroughExitNodes)
				{
					PropagateToCalleeExitBlocks(stmCur);
				}

				// Update trash information.

				ProcedureFlow pi = mpprocData[ci.Callee];
				ProcedureFlow item = mpprocData[proc];

				// The registers that are still live before a call are those
				// that were live after the call and were bypassed by the called function
				// or used by the called function.
				varLive.BitSet = pi.MayUse | ((pi.ByPass    | ~pi.TrashedRegisters) & varLive.BitSet);
				varLive.Grf = pi.grfMayUse | ((pi.grfByPass | ~pi.grfTrashed) & varLive.Grf);

				// Any stack parameters are also considered live.
				MarkLiveStackParameters(ci);
			}
		}

		public override void VisitConditionOf(ConditionOf cof)
		{
			bitUseOffset = 0;
			cbitsUse = 0;
			base.VisitConditionOf (cof);
		}

		public override void VisitIdentifier(Identifier id)
		{
			Use(id);
		}

		public override void VisitMemoryAccess(MemoryAccess access)
		{
			bitUseOffset = 0;
			cbitsUse = 0;
			access.EffectiveAddress.Accept(this);
		}

		public override void VisitSegmentedAccess(SegmentedAccess access)
		{
			bitUseOffset = 0;
			cbitsUse = 0;
			base.VisitSegmentedAccess(access);
		}

		public override void VisitStore(Store store)
		{
			store.Dst.Accept(this);
			bitUseOffset = 0;
			cbitsUse = store.Dst.DataType.BitSize;
			store.Src.Accept(this);
		}


		#endregion // Visitor Methods //////////////////////////////////////

		public State CurrentState
		{
			get { return state; }
			set
			{
				state = value;
				foreach (object o in mpprocData.Values)
				{
					ProcedureFlow pi = o as ProcedureFlow;
					if (pi != null)
					{
						state.InitializeProcedureFlow(pi);
						continue;
					}
					BlockFlow bi = o as BlockFlow;
					if (bi != null)
					{
						state.InitializeBlockFlow(bi.Block, mpprocData, bi.Block.Procedure.ExitBlock == bi.Block);
						continue;
					}
				}
			}
		}

		public abstract class State
		{
			private bool propagateThroughExitNodes;

			public State(bool prop) 
			{
				this.propagateThroughExitNodes = prop;
			}

			public abstract void InitializeBlockFlow(Block blow, ProgramDataFlow flow, bool isExitBlock);

			public abstract void InitializeProcedureFlow(ProcedureFlow flow);

			public abstract void ApplySavedRegisters(ProcedureFlow procFlow, IdentifierLiveness varLive);

			public virtual bool MergeBlockInfo(IdentifierLiveness varLive, BlockFlow blockFlow)
			{
				bool ret = false;
				if (!(varLive.BitSet & (~blockFlow.DataOut)).IsEmpty)
				{
					blockFlow.DataOut |= varLive.BitSet;
					ret = true;
				}
				if ((varLive.Grf & (~blockFlow.grfOut)) != 0)
				{
					blockFlow.grfOut |= varLive.Grf;
					ret = true;
				}
				IDictionary dict = blockFlow.StackVarsOut;
				foreach (DictionaryEntry de in varLive.LiveStackVariables)
				{
					if (!dict.Contains(de.Key))
					{
						dict.Add(de.Key, de.Value);
						ret = true;
					}
				}
				return ret;
			}

			public bool PropagateThroughExitNodes
			{
				get { return this.propagateThroughExitNodes; }
			}

			public abstract void UpdateSummary(ProcedureFlow item);
		}


		public class ByPassState : State
		{
			public ByPassState() : base(false)
			{
			}

			public override void ApplySavedRegisters(ProcedureFlow procFlow, IdentifierLiveness varLive)
			{
//				varLive.BitSet &= ~procFlow.PreservedRegisters;
			}

			public override void InitializeBlockFlow(Block block, ProgramDataFlow flow, bool isExitBlock)
			{
				BlockFlow bf = flow[block];
				if (isExitBlock && block.Procedure.Signature.ArgumentsValid)
				{
					Identifier ret = block.Procedure.Signature.ReturnValue;
					if (ret != null)
					{
						RegisterStorage rs = ret.Storage as RegisterStorage;
						if (rs != null)
							rs.Register.SetAliases(bf.DataOut, true);
					}
					foreach (Identifier id in block.Procedure.Signature.Arguments)
					{
						OutArgumentStorage os = id.Storage as OutArgumentStorage;
						if (os == null)
							continue;
						RegisterStorage rs = os.OriginalIdentifier.Storage as RegisterStorage;
						if (rs != null) 
						{
							rs.Register.SetAliases(bf.DataOut, true);
						}
					}
				}
				else
				{
					bf.DataOut.SetAll(isExitBlock);
					bf.DataOut &= ~flow[block.Procedure].PreservedRegisters;
				}
			}

			public override void InitializeProcedureFlow(ProcedureFlow flow)
			{
				flow.Summary = flow.ByPass;
				flow.Summary.SetAll(false);
			}

			public override void UpdateSummary(ProcedureFlow item)
			{
				item.ByPass = item.Summary.Clone();
			}

			public override bool MergeBlockInfo(IdentifierLiveness varLive, BlockFlow blockFlow)
			{
				bool ret = false;
				if (!(~varLive.BitSet & blockFlow.DataOut).IsEmpty)
				{
					blockFlow.DataOut |= varLive.BitSet;
					ret = true;
				}
				if ((~varLive.Grf & blockFlow.grfOut) != 0)
				{
					blockFlow.grfOut |= varLive.Grf;
					ret = true;
				}
				return ret;
			}
		}


		private class MayUseState : State
		{
			public MayUseState() : base(false)
			{
			}

			public override void ApplySavedRegisters(ProcedureFlow procFlow, IdentifierLiveness varLive)
			{
			}

			public override void InitializeBlockFlow(Block block, ProgramDataFlow flow, bool isExitBlock)
			{
				flow[block].DataOut.SetAll(false);
			}

			public override void InitializeProcedureFlow(ProcedureFlow flow)
			{
				flow.ByPass = flow.Summary.Clone();
				flow.Summary.SetAll(false);
				flow.grfByPass = flow.grfSummary;
				flow.grfSummary = 0;
			}

			public override void UpdateSummary(ProcedureFlow item)
			{
				item.MayUse = item.Summary.Clone();
			}
		}


		private class LiveInState : State
		{
			public LiveInState() : base(true)
			{
			}

			public override void InitializeBlockFlow(Block block, ProgramDataFlow flow, bool isExitBlock)
			{
				flow[block].DataOut.SetAll(false);
			}

			public override void InitializeProcedureFlow(ProcedureFlow flow)
			{
				flow.MayUse = new BitSet(flow.Summary);
				flow.Summary.SetAll(false);
				flow.grfMayUse = flow.grfSummary;
				flow.grfSummary = 0;
			}

			public override void ApplySavedRegisters(ProcedureFlow procFlow, IdentifierLiveness varLive)
			{
			}

			public override void UpdateSummary(ProcedureFlow item)
			{
				// Used to update LiveIn, but it was never used.
			}
		}

		public class IsLiveHelper : StorageVisitor
		{
			private bool retval;
			private IdentifierLiveness liveState;

			/// <summary>
			/// Determines whether an identifier is live in <paramref>liveStat</paramref>.
			/// </summary>
			public bool IsLive(Identifier id, IdentifierLiveness liveState)
			{
				retval = false;
				this.liveState = liveState;
				id.Storage.Accept(this);
				return retval;
			}

			#region StorageVisitor Members

			public void VisitTemporaryStorage(TemporaryStorage temp)
			{
				throw new NotImplementedException();
			}

			public void VisitStackArgumentStorage(StackArgumentStorage stack)
			{
				throw new NotImplementedException();
			}

			public void VisitOutArgumentStorage(OutArgumentStorage arg)
			{
				throw new NotImplementedException();
			}

			public void VisitMemoryStorage(MemoryStorage global)
			{
				throw new NotImplementedException();
			}

			public void VisitRegisterStorage(RegisterStorage reg)
			{
				//$REFACTOR: make SetAliases be a bitset of Register.
				BitSet b = new BitSet(liveState.BitSet.Count);
				reg.Register.SetAliases(b, true);
				retval = !(liveState.BitSet & b).IsEmpty;
			}

			public void VisitFpuStackStorage(FpuStackStorage fpu)
			{
				throw new NotImplementedException();
			}

			public void VisitFlagGroupStorage(FlagGroupStorage grf)
			{
				retval = (grf.FlagGroup & liveState.Grf) != 0;
			}

			public void VisitSequenceStorage(SequenceStorage seq)
			{
				seq.Head.Storage.Accept(this);
				if (!retval)
					seq.Tail.Storage.Accept(this);
			}

			public void VisitStackLocalStorage(StackLocalStorage local)
			{
				retval = liveState.LiveStackVariables.Contains(local);
			}

			#endregion

		}

	}
}
