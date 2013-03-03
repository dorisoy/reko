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

using Decompiler.Analysis;
using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;

namespace Decompiler.UnitTests.Analysis
{
	[TestFixture]
	public class LiveCopyInserterTests : AnalysisTestBase
	{
		private Procedure proc;
		private SsaIdentifierCollection ssaIds;

		[Test]
		public void LciFindCopyslots()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);
			Assert.AreEqual(2, lci.IndexOfInsertedCopy(proc.ControlGraph.Blocks[0]));
            Assert.AreEqual(2, lci.IndexOfInsertedCopy(proc.ControlGraph.Blocks[1].Succ[0]));
            Assert.AreEqual(0, lci.IndexOfInsertedCopy(proc.ControlGraph.Blocks[1].Succ[0].Succ[0]));
            Assert.AreEqual(0, lci.IndexOfInsertedCopy(proc.ControlGraph.Blocks[1].Succ[0].Succ[0].Succ[0]));
		}

		[Test]
		public void LciLiveAtLoop()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);

			var i = ssaIds[2].Identifier;
			var i_6 = ssaIds[6].Identifier;
            var loopHdr = proc.ControlGraph.Blocks[1];
			Assert.IsFalse(lci.IsLiveAtCopyPoint(i, loopHdr));
            Assert.IsTrue(lci.IsLiveAtCopyPoint(i_6, loopHdr), "i_6 should be live");
		}

		[Test]
		public void LciLiveAtCopy()
		{
			Build(new LiveCopyMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);

			var reg   = ssaIds[3].Identifier;
			var reg_5 = ssaIds[5].Identifier;
			var reg_6 = ssaIds[6].Identifier;

			Assert.AreEqual("reg_6 = PHI(reg, reg_5)", ssaIds[6].DefStatement.Instruction.ToString());
			Assert.IsTrue(lci.IsLiveOut(reg, ssaIds[6].DefStatement));
		}

		[Test]
		public void LciInsertAssignmentCopy()
		{
			Build(new LiveCopyMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);

			int i = lci.IndexOfInsertedCopy(proc.ControlGraph.Blocks[1]);
			Assert.AreEqual(i, 0);
			var idNew = lci.InsertAssignmentNewId(ssaIds[3].Identifier, proc.ControlGraph.Blocks[1], i);
			Assert.AreEqual("reg_7 = reg", proc.ControlGraph.Blocks[1].Statements[0].Instruction.ToString());
			Assert.AreSame(proc.ControlGraph.Blocks[1].Statements[0], ssaIds[idNew].DefStatement);
		}


		[Test]
		public void LciInsertAssignmentLiveLoop()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);

			var idNew = lci.InsertAssignmentNewId(ssaIds[4].Identifier, proc.ControlGraph.Blocks[1], 2);
			Assert.AreEqual("i_7 = i_4", proc.ControlGraph.Blocks[1].Statements[2].Instruction.ToString());
			Assert.AreEqual(proc.ControlGraph.Blocks[1].Statements[2], ssaIds[idNew].DefStatement);
		}

		[Test]
		public void LciRenameDominatedIdentifiers()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());
			var lci = new LiveCopyInserter(proc, ssaIds);

			var idNew = lci.InsertAssignmentNewId(ssaIds[4].Identifier, proc.ControlGraph.Blocks[1], 2);
			lci.RenameDominatedIdentifiers(ssaIds[4], ssaIds[idNew]);
            Assert.AreEqual("return i_7", proc.ControlGraph.Blocks[1].ElseBlock.Statements[0].Instruction.ToString());

		}

		[Test]
		public void LciLiveLoop()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());
			LiveCopyInserter lci = new LiveCopyInserter(proc, ssaIds);
			lci.Transform();
			using (FileUnitTester fut = new FileUnitTester("Analysis/LciLiveLoop.txt"))
			{
				proc.Write(false, fut.TextWriter);
				fut.AssertFilesEqual();
			}
		}

		[Test]
		public void LciLiveCopy()
		{
			Build(new LiveCopyMock().Procedure, new FakeArchitecture());
			LiveCopyInserter lci = new LiveCopyInserter(proc, ssaIds);
			lci.Transform();
			using (FileUnitTester fut = new FileUnitTester("Analysis/LciLiveCopy.txt"))
			{
				proc.Write(false, fut.TextWriter);
				fut.AssertFilesEqual();
			}
		}

		[Test]
		public void LciNestedRepeats()
		{
			RunTest("Fragments/nested_repeats.asm", "Analysis/LciNestedRepeats.txt");
		}

		[Test]
		public void LciWhileGoto()
		{
			RunTest("Fragments/while_goto.asm", "Analysis/LciWhileGoto.txt");
		}

		[Test]
		public void LciWhileLoop()
		{
			RunTest("Fragments/while_loop.asm", "Analysis/LciWhileLoop.txt");
		}

		protected new void RunTest(string sourceFile, string outputFile)
		{
			Program prog = RewriteFile(sourceFile);
			Build(prog.Procedures.Values[0], prog.Architecture);
			LiveCopyInserter lci = new LiveCopyInserter(proc, ssaIds);
			lci.Transform();
			using (FileUnitTester fut = new FileUnitTester(outputFile))
			{
				proc.Write(false, fut.TextWriter);
				fut.AssertFilesEqual();
			}
		}

		private void Build(Procedure proc, IProcessorArchitecture arch)
		{
			this.proc = proc;
			Aliases alias = new Aliases(proc, arch);
			alias.Transform();
			var gr = proc.CreateBlockDominatorGraph();
			SsaTransform sst = new SsaTransform(proc, gr);
			SsaState ssa = sst.SsaState;
			this.ssaIds = ssa.Identifiers;

			ConditionCodeEliminator cce = new ConditionCodeEliminator(ssa.Identifiers, arch);
			cce.Transform();
			DeadCode.Eliminate(proc, ssa);

			ValuePropagator vp = new ValuePropagator(ssa.Identifiers, proc);
			vp.Transform();

			Coalescer coa = new Coalescer(proc, ssa);
			coa.Transform();

			DeadCode.Eliminate(proc, ssa);
		}
	}
}
