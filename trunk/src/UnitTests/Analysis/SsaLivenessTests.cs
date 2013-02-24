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

using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Lib;
using Decompiler.Core.Types;
using Decompiler.Analysis;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Decompiler.UnitTests.Analysis
{
	[TestFixture]
	public class SsaLivenessTests : AnalysisTestBase
	{
		private Procedure proc;
		private SsaState ssa;
		private SsaLivenessAnalysis sla;
		private SsaLivenessAnalysis2 sla2;

		[Test]
		public void SltLiveLoop()
		{
			Build(new LiveLoopMock().Procedure, new FakeArchitecture());

			using (FileUnitTester fut = new FileUnitTester("Analysis/SltLiveLoop.txt"))
			{
				sla.Write(proc, fut.TextWriter);
				fut.TextWriter.WriteLine("=======================");
                fut.AssertFilesEqual();
			}
			Identifier i =   ssa.Identifiers[2].Identifier; 
			Identifier i_4 = ssa.Identifiers[4].Identifier;
			Identifier i_6 = ssa.Identifiers[6].Identifier;
			Assert.AreEqual("i", i.Name);
			Assert.AreEqual("i_4", i_4.Name);
			Assert.AreEqual("i_6", i_6.Name);
			Assert.IsFalse(sla.IsLiveOut(i, ssa.Identifiers[4].DefStatement));
            var block1 = proc.ControlGraph.Blocks[1];
			Assert.AreEqual("branch Mem0[i_6:byte] != 0x00 loop", block1.Statements[2].Instruction.ToString());
			Assert.IsTrue(sla.IsLiveOut(i_4, block1.Statements[2]), "i_4 should be live at the end of block 1");
			Assert.IsTrue(sla.IsLiveOut(i_6, block1.Statements[2]),"i_6 should be live at the end of block 1");
			Assert.AreEqual("i_4 = PHI(i, i_6)", block1.Statements[0].Instruction.ToString());
			Assert.IsFalse(sla.IsLiveOut(i_6, block1.Statements[0]), "i_6 is dead after the phi function");
		}

		[Test]
		public void SltSimple()
		{
			Build(new SimpleMock().Procedure, new FakeArchitecture());

			using (FileUnitTester fut = new FileUnitTester("Analysis/SltSimple.txt"))
			{
				ssa.Write(fut.TextWriter);
				sla.Write(proc, fut.TextWriter);
				fut.TextWriter.WriteLine();
				fut.AssertFilesEqual();
			}

			Block block = proc.ControlGraph.Blocks[0];
			block.Write(Console.Out);
			Assert.AreEqual("Mem6[0x10000000:word32] = a + b", block.Statements[0].Instruction.ToString());
			Assert.AreEqual("Mem7[0x10000004:word32] = a", block.Statements[1].Instruction.ToString());

			Identifier a = ssa.Identifiers[2].Identifier;
			Identifier c_5 = ssa.Identifiers[5].Identifier;
			Assert.AreEqual("a", a.Name);
			Assert.IsFalse(sla.IsLiveOut(a, block.Statements[1]), "a should be dead after its last use");
			Assert.IsTrue(sla.IsLiveOut(a, block.Statements[0]), "a should be live after the first use");
			Assert.IsFalse(sla.IsDefinedAtStatement(ssa.Identifiers[c_5], block.Statements[0]));
			Assert.IsFalse(sla.IsDefinedAtStatement(ssa.Identifiers[4], block.Statements[0]));
		}

		[Test]
		public void SltWhileGoto()
		{
			Program prog = RewriteFile("Fragments/while_goto.asm");
			Build(prog.Procedures.Values[0], prog.Architecture);

			using (FileUnitTester fut = new FileUnitTester("Analysis/SltWhileGoto.txt"))
			{
				ssa.Write(fut.TextWriter);
				sla.Write(proc, fut.TextWriter);
				fut.TextWriter.WriteLine();
				fut.AssertFilesEqual();
			}
		}

		[Test]
		public void SltLiveCopy()
		{
			Build(new LiveCopyMock().Procedure, new FakeArchitecture());
			WebBuilder wb = new WebBuilder(proc, ssa.Identifiers, new Dictionary<Identifier,LinearInductionVariable>());
			using (FileUnitTester fut = new FileUnitTester("Analysis/SltLiveCopy.txt"))
			{
				ssa.Write(fut.TextWriter);
				proc.Write(false, fut.TextWriter);
			}

			Statement phiStm = proc.ControlGraph.Blocks[3].Statements[0];
			Assert.AreEqual("reg_6 = PHI(reg, reg_5)", phiStm.Instruction.ToString());
			Identifier reg   = ssa.Identifiers[3].Identifier;
			Assert.AreEqual("reg", reg.Name);
			Identifier reg_5 = ssa.Identifiers[5].Identifier;
			Identifier reg_6 = ssa.Identifiers[6].Identifier;
			Assert.IsTrue(sla.IsLiveOut(reg,   phiStm), "reg is live!");
			Assert.IsFalse(sla.IsLiveOut(reg_5, phiStm), "reg_5 should be dead");
			Assert.IsTrue(sla.IsLiveOut(reg_6, phiStm), "reg_6 should be live");
		}

		[Test]
		public void SltManyIncrements()
		{
			Build(new ManyIncrements().Procedure, new FakeArchitecture());
			using (FileUnitTester fut = new FileUnitTester("Analysis/SltManyIncrements.txt"))
			{
				ssa.Write(fut.TextWriter);
				proc.Write(false, fut.TextWriter);
				fut.TextWriter.WriteLine("- Interference graph -------------------");
				sla2.InterferenceGraph.Write(fut.TextWriter);
				fut.AssertFilesEqual();
			}
			Statement phiStm = proc.ControlGraph.Blocks[1].Statements[0];
			Identifier r0_4 = ssa.Identifiers[4].Identifier;
			Identifier r0_15 = ssa.Identifiers[15].Identifier;
			Console.WriteLine(r0_15);
			Assert.IsFalse(sla2.InterferenceGraph.Interfere(r0_4, r0_15));
		}

		private void Build(Procedure proc, IProcessorArchitecture arch)
		{
			this.proc = proc;
			Aliases alias = new Aliases(proc, arch);
			alias.Transform();
			SsaTransform sst = new SsaTransform(proc, proc.CreateBlockDominatorGraph());
			ssa = sst.SsaState;
			ConditionCodeEliminator cce = new ConditionCodeEliminator(ssa.Identifiers, arch);
			cce.Transform();
			ValuePropagator vp = new ValuePropagator(ssa.Identifiers, proc);
			vp.Transform();
			DeadCode.Eliminate(proc, ssa);
			Coalescer coa = new Coalescer(proc, ssa);
			coa.Transform();
			DeadCode.Eliminate(proc, ssa);

			sla = new SsaLivenessAnalysis(proc, ssa.Identifiers);
			sla2 = new SsaLivenessAnalysis2(proc, ssa.Identifiers);
			sla2.Analyze();
		}


		public class SimpleMock : ProcedureBuilder
		{
			protected override void BuildBody()
			{
				Identifier a  = Local32("a");
				Identifier b  = Local32("b");
				Identifier c  = Local32("c");

				Assign(c, Add(a, b));
				Store(Int32(0x10000000), c);
				Store(Int32(0x10000004), a);
			}
		}

		public class ManyIncrements : ProcedureBuilder
		{
			protected override void BuildBody()
			{
				Identifier r0 = Register(0);
				Identifier r1 = Register(1);
				
				Label("loopTop");
				Assign(r1, Load(PrimitiveType.Byte, r0));
				Assign(r0, Add(r0, 1));
				BranchIf(Ne(r1, base.Int8(1)), "not1");

				Assign(r1, Load(PrimitiveType.Byte, r0));
				Assign(r0, Add(r0, 1));
				Store(Int32(0x33333330), r1);
				Assign(r1, Load(PrimitiveType.Byte, r0));
				Assign(r0, Add(r0, 1));
				Store(Int32(0x33333331), r1);
				Jump("loopTop");

				Label("not1");
				BranchIf(Ne(r1, base.Int8(2)), "done");
				Assign(r1, Load(PrimitiveType.Byte, r0));
				Assign(r0, Add(r0, 1));
				Store(Int32(0x33333330), r1);
				Jump("loopTop");

				Label("done");
				Return();
			}
		}
	}
}
