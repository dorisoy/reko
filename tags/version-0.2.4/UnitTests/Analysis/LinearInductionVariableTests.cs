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
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Lib;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Decompiler.UnitTests.Analysis
{
	[TestFixture]
	public class LinearInductionVariableTests : AnalysisTestBase
	{
		private Procedure proc;
		private SsaIdentifierCollection ssaIds;
		private BlockDominatorGraph doms;


		/// <summary>
		/// Builds a strongly connected component corresponding to:
		/// a1 = 0
		/// a2 = phi(a1, a3)
		/// while (a2 != 10)
		/// {
		///    a3 = a2 + 4
		/// }
		/// </summary>
		private List<SsaIdentifier> BuildScc()
		{
            proc = new Procedure("test", new Frame(PrimitiveType.Word32));
			Block b1 = proc.AddBlock("b1");
			Block b2 = proc.AddBlock("b2");

			Identifier a1 = new Identifier("a1", 0, PrimitiveType.Word32, null);
			Identifier a2 = new Identifier("a2", 1, PrimitiveType.Word32, null);
			Identifier a3 = new Identifier("a3", 2, PrimitiveType.Word32, null);
			PhiFunction phi = new PhiFunction(a1.DataType, new Expression [] { a1, a3 });

			Statement stm_a1 = new Statement(0, new Assignment(a1, Constant.Word32(0)), null);
			Statement stm_a2 = new Statement(0, new PhiAssignment(a2, new PhiFunction(a1.DataType,  a1, a3 )), null);
			Statement stm_ex = new Statement(0, new Branch(new BinaryExpression(Operator.Ne, PrimitiveType.Bool, a2, Constant.Word32(10)), b2), null);
			Statement stm_a3 = new Statement(0, new Assignment(a3, new BinaryExpression(Operator.Add, a3.DataType, a2, Constant.Word32(4))), null);
			b1.Statements.Add(stm_a1);
			b2.Statements.Add(stm_a2);
			b2.Statements.Add(stm_a3);

			SsaIdentifier sid_a1 = new SsaIdentifier(a1, a1, stm_a1, ((Assignment)stm_a1.Instruction).Src, false);
            SsaIdentifier sid_a2 = new SsaIdentifier(a2, a2, stm_a2, ((PhiAssignment) stm_a2.Instruction).Src, false);
            SsaIdentifier sid_a3 = new SsaIdentifier(a3, a3, stm_a3, ((Assignment) stm_a3.Instruction).Src, false);
			sid_a1.Uses.Add(stm_a2);
			ssaIds = new SsaIdentifierCollection();
			ssaIds.Add(sid_a1);
			ssaIds.Add(sid_a2);
			ssaIds.Add(sid_a3);

            List<SsaIdentifier> list = new List<SsaIdentifier>();
			list.Add(ssaIds[0]);
			list.Add(ssaIds[1]);
			list.Add(ssaIds[2]);
			return list;
		}

		[Test]
		public void FindPhi()
		{
			List<SsaIdentifier> a = BuildScc();
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, null, null);
			PhiFunction p = liv.FindPhiFunction(a);
			Assert.IsNotNull(p, "Didn't find phi function!");
		}

		[Test]
		public void FindLinearIncrement()
		{
            List<SsaIdentifier> a = BuildScc();
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, null, null);
			Constant c = liv.FindLinearIncrement(a);
			Assert.AreEqual(4, c.ToInt32());
            Assert.AreEqual("a3 = a2 + 0x00000004", liv.Context.DeltaStatement.ToString());
		}

		[Test]
		public void FindInitialValue()
		{
			List<SsaIdentifier> a = BuildScc();
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, ssaIds, null);
			PhiFunction phi = liv.FindPhiFunction(a);
			Constant c = liv.FindInitialValue(phi);
            Assert.AreEqual(0, c.ToInt32());
            Assert.AreEqual("a1 = 0x00000000", liv.Context.InitialStatement.ToString());
		}

		[Test]
		public void FindFinalValue()
		{
			Prepare(new ByteArrayLoopMock().Procedure);
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(proc, ssaIds, null);
			List<SsaIdentifier> a = new List<SsaIdentifier>();
			a.Add(ssaIds[5]);
			a.Add(ssaIds[8]);
			Constant c = liv.FindFinalValue(a);
			Assert.AreEqual(10, c.ToInt32());
            Assert.AreEqual("branch i_5 < 0x0000000A body", liv.Context.TestStatement.ToString());
		}

		[Test]
		public void WhileLtIncMock()
		{
			RunTest(new WhileLtIncMock().Procedure, "Analysis/LivWhileLtInc.txt");
		}

		[Test]
		public void WhileGeDecMock()
		{
			RunTest(new WhileGtDecMock().Procedure, "Analysis/LivWhileGtDec.txt");
		}

        [Test]
        public void ArrayLoopMock()
        {
            RunTest(new ArrayLoopMock().Procedure, "Analysis/LivArrayLoopMock.txt");
        }

		public void Create1()
		{
			Prepare(new WhileLtIncMock().Procedure);
			var doms = proc.CreateBlockDominatorGraph();
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(proc, ssaIds, doms);
			Assert.IsNull(liv.Context.PhiIdentifier);
			Assert.IsNull(liv.Context.PhiStatement);

			liv.Context.PhiStatement = ssaIds[5].DefStatement;
			liv.Context.PhiIdentifier = (Identifier) ((PhiAssignment) liv.Context.PhiStatement.Instruction).Dst;
			liv.Context.TestStatement = proc.ControlGraph.Blocks[2].Statements[1];
			liv.Context.DeltaStatement = ssaIds[8].DefStatement;
			liv.Context.InitialValue = Constant.Word32(0);
			liv.Context.DeltaValue = Constant.Word32(1);
			liv.Context.TestValue = Constant.Word32(10);
			LinearInductionVariable iv = liv.CreateInductionVariable();
			Assert.AreEqual("X", iv.ToString());
		}

		[Test]
		public void CreateNo()
		{
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, null, null);
			Assert.IsNull(liv.CreateInductionVariable());
		}

		[Test]
		public void CreateBareMinimum()
		{
			ssaIds = new SsaIdentifierCollection();
			Identifier id0 = new Identifier("foo", 1, PrimitiveType.Word32, new TemporaryStorage());
			Identifier id1 = new Identifier("bar", 2, PrimitiveType.Word32, new TemporaryStorage());
			ssaIds.Add(new SsaIdentifier(id0, id0, null, null, false));
			ssaIds.Add(new SsaIdentifier(id1, id1, null, null, false));
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, ssaIds, null);
			liv.Context.PhiStatement = new Statement(0, null, null);
			liv.Context.PhiIdentifier = new Identifier("i_3", 1, PrimitiveType.Word32, null);
			liv.Context.DeltaValue = Constant.Word32(1);
			LinearInductionVariable iv = liv.CreateInductionVariable();
			Assert.AreEqual("(? 0x00000001 ?)", iv.ToString());
		}

		[Test]
		public void CreateIncInitialValue()
		{
			ssaIds = new SsaIdentifierCollection();
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, ssaIds, null);
			liv.Context.InitialValue = Constant.Word32(0);
			liv.Context.PhiStatement = new Statement(0, null, null);
			liv.Context.PhiIdentifier = new Identifier("foo_0", 0, PrimitiveType.Word32, null);
            ssaIds.Add(new SsaIdentifier(liv.Context.PhiIdentifier, liv.Context.PhiIdentifier, liv.Context.PhiStatement, null, false));
			liv.Context.DeltaValue = Constant.Word32(1);
			liv.Context.DeltaStatement = new Statement(0, new Assignment(new Identifier("foo_1", 1, PrimitiveType.Word32, null), 
				new BinaryExpression(Operator.Add, PrimitiveType.Word32, liv.Context.PhiIdentifier, liv.Context.DeltaValue)), null);
			ssaIds[liv.Context.PhiIdentifier].Uses.Add(liv.Context.DeltaStatement);

			LinearInductionVariable iv = liv.CreateInductionVariable();
			Assert.AreEqual("(0x00000001 0x00000001 ?)", iv.ToString());
		}

		[Test]
		public void CreateNoincInitialValue()
		{
			ProcedureBuilder m = new ProcedureBuilder();
			ssaIds = new SsaIdentifierCollection();
			SsaId(new Identifier("id0", 0, PrimitiveType.Word32, new TemporaryStorage()), null, null, false);
			SsaId(new Identifier("id1", 1, PrimitiveType.Word32, new TemporaryStorage()), null, null, false);
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(null, ssaIds, null);

			liv.Context.InitialValue = Constant.Word32(0);
			Identifier id2 = m.Local32("id_2");
			SsaId(id2, new Statement(0, null, null), null, false);
			Assert.AreEqual(3, ssaIds.Count);

			Identifier id3 = m.Local32("id_3");
			Assert.AreEqual(3, id3.Number);
			Identifier id4 = m.Local32("id_4");
			liv.Context.PhiStatement = m.Phi(id3, id2, id4);
			liv.Context.PhiIdentifier = id3;
			SsaId(id3, liv.Context.PhiStatement, ((PhiAssignment)liv.Context.PhiStatement.Instruction).Src, false);
			Assert.AreEqual(4, ssaIds.Count);

			Statement use = new Statement(0, null, null);
			ssaIds[id3].Uses.Add(use);

			liv.Context.DeltaValue = m.Int32(1);
            m.Assign(id4, m.Add(id3, liv.Context.DeltaValue));
            liv.Context.DeltaStatement = m.Block.Statements.Last;
			ssaIds[id3].Uses.Add(liv.Context.DeltaStatement);

			LinearInductionVariable iv = liv.CreateInductionVariable();
			Assert.AreEqual("(0x00000000 0x00000001 ?)", iv.ToString());

		}

        [Test]
        public void PreTestedUge()
        {
            Prepare(delegate(ProcedureBuilder m)
            {
                Identifier i = m.Local32("i");
                m.Label("test");
                m.BranchIf(m.Uge(i, 10), "done");
                m.Store(m.Word32(0x4204), i);
                m.Assign(i, m.Add(i, 1));
                m.Jump("test");
                m.Label("done");
                m.Store(m.Word32(0x4200), i);
                m.Return();
            });
            LinearInductionVariableFinder liv = new LinearInductionVariableFinder(proc, ssaIds, doms);
            liv.Find();
            Assert.AreEqual("(? 0x00000001 0x0000000A)", liv.InductionVariables[0].ToString());
        }

		[Test]
		public void CreateDecTest()
		{
            Prepare(delegate(ProcedureBuilder m)
            {
                Identifier id = m.Local32("id");
                m.Assign(id, Constant.Word32(10));
                m.Label("loop");
                m.Assign(id, m.Sub(id, 1));
                m.BranchIf(m.Ge(id, 0), "loop");
                m.Store(m.Word32(0x4232), id);
                m.Return(id);
            });
            proc.Dump(true, false);
            var liv = new LinearInductionVariableFinder(proc, ssaIds, doms);
            liv.Find();
			var iv = liv.InductionVariables[0];
			Assert.AreEqual("(9 -1 -1 signed)", iv.ToString());
		}

		[Test]
		public void Commensurate()
		{
			LinearInductionVariable liv1 = new LinearInductionVariable(null, Constant.Word32(1), null, false);
            LinearInductionVariable liv2 = new LinearInductionVariable(null, Constant.Word32(2), null, false);
			LinearInductionVariable liv =
				LinearInductionVariable.Merge(liv1, liv2);
			Assert.IsNotNull(liv);
			Assert.AreEqual(1, liv.Delta.ToInt32());
		}

		[Test]
		public void Commensurate2()
		{
            LinearInductionVariable liv1 = new LinearInductionVariable(null, Constant.Word32(2), null, false);
            LinearInductionVariable liv2 = new LinearInductionVariable(null, Constant.Word32(8), null, false);
			LinearInductionVariable liv =
				LinearInductionVariable.Merge(liv1, liv2);
			Assert.IsNotNull(liv);
			Assert.AreEqual(2, liv.Delta.ToInt32());
		}

		[Test]
		public void InCommensurate()
		{
			LinearInductionVariable liv1 = new LinearInductionVariable(null, Constant.Word32(3), null, false);
			LinearInductionVariable liv2 = new LinearInductionVariable(null, Constant.Word32(8), null, false);
			LinearInductionVariable liv =
				LinearInductionVariable.Merge(liv1, liv2);
			Assert.IsNull(liv);
		}

		private void Prepare(Procedure proc)
		{
			this.proc = proc;
            doms = proc.CreateBlockDominatorGraph();
			SsaTransform sst = new SsaTransform(proc, doms);
			SsaState ssa = sst.SsaState;
			ssaIds = ssa.Identifiers;
	

			ConditionCodeEliminator cce = new ConditionCodeEliminator(ssaIds, new FakeArchitecture());
			cce.Transform();
			

			DeadCode.Eliminate(proc, ssa);

			ValuePropagator vp = new ValuePropagator(ssa.Identifiers, proc);
			vp.Transform();

			DeadCode.Eliminate(proc, ssa);
		}

        private void Prepare(Action<ProcedureBuilder> m)
        {
            ProcedureBuilder mock = new ProcedureBuilder();
            m(mock);
            Prepare(mock.Procedure);
        }

		private void RunTest(Procedure proc, string outputFile)
		{
			Prepare(proc);
			LinearInductionVariableFinder liv = new LinearInductionVariableFinder(proc, ssaIds, doms);
			liv.Find();
			using (FileUnitTester fut = new FileUnitTester(outputFile))
			{
				proc.Write(false, fut.TextWriter);
				fut.TextWriter.WriteLine();
				foreach (LinearInductionVariable iv in liv.InductionVariables)
				{
					fut.TextWriter.WriteLine(iv);
				}
				fut.AssertFilesEqual();
			}
		}

		private void SsaId(Identifier id, Statement stm, Expression expr, bool isSideEffect)
		{
			ssaIds.Add(new SsaIdentifier(id, id, stm, expr, isSideEffect));
		}
	}
}
