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
using Decompiler.Evaluation;
using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.Core.Machine;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.IO;

namespace Decompiler.UnitTests.Analysis
{
	[TestFixture]
	public class ValuePropagationTests : AnalysisTestBase
	{
		SsaIdentifierCollection ssaIds;

		[SetUp]
		public void Setup()
		{
			ssaIds = new SsaIdentifierCollection();
		}

		[Test]
		public void VpAddSubCarries()
		{
			RunTest("Fragments/addsubcarries.asm", "Analysis/VpAddSubCarries.txt");
		}

		[Test]
		public void VpChainTest()
		{
			RunTest("Fragments/multiple/chaincalls.asm", "Analysis/VpChainTest.txt");
		}


		[Test]
		public void VpConstPropagation()
		{
			RunTest("Fragments/constpropagation.asm", "Analysis/VpConstPropagation.txt");
		}


		[Test]
		public void VpGlobalHandle()
		{
			RunTest32("Fragments/import32/globalhandle.asm", "Analysis/VpGlobalHandle.txt");
		}

		[Test]
		public void VpNegsNots()
		{
			RunTest("Fragments/negsnots.asm", "Analysis/VpNegsNots.txt");
		}

		[Test]
		public void VpNestedRepeats()
		{
			RunTest("Fragments/nested_repeats.asm", "Analysis/VpNestedRepeats.txt");
		}

		[Test]
		public void VpStringInstructions()
		{
			RunTest("Fragments/stringinstr.asm", "Analysis/VpStringInstructions.txt");
		}

		[Test]
		public void VpSuccessiveDecs()
		{
			RunTest("Fragments/multiple/successivedecs.asm", "Analysis/VpSuccessiveDecs.txt");
		}

		[Test]
		public void VpWhileGoto()
		{
			RunTest("Fragments/while_goto.asm", "Analysis/VpWhileGoto.txt");
		}

		[Test]
		public void VpDbp()
		{
			Procedure proc = new DpbMock().Procedure;
			var gr = proc.CreateBlockDominatorGraph();
			SsaTransform sst = new SsaTransform(proc, gr);
			SsaState ssa = sst.SsaState;

            ssa.DebugDump(true);

			ValuePropagator vp = new ValuePropagator(ssa.Identifiers, proc);
			vp.Transform();

			using (FileUnitTester fut = new FileUnitTester("Analysis/VpDbp.txt"))
			{
				proc.Write(false, fut.TextWriter);
				fut.TextWriter.WriteLine();
				fut.AssertFilesEqual();
			}
		}

		[Test]
		public void VpEquality()
		{
			Identifier foo = Reg32("foo");

            var vp = CreatePropagatorWithDummyStatement();
			BinaryExpression expr = 
				new BinaryExpression(Operator.Eq, PrimitiveType.Bool, 
				new BinaryExpression(Operator.Sub, PrimitiveType.Word32, foo,
				Constant.Word32(1)),
				Constant.Word32(0));
			Assert.AreEqual("foo - 0x00000001 == 0x00000000", expr.ToString());

			Expression simpler = vp.VisitBinaryExpression(expr);
			Assert.AreEqual("foo == 0x00000001", simpler.ToString());
		}

        private ExpressionSimplifier CreatePropagatorWithDummyStatement()
        {
            var ctx = new SsaEvaluationContext(ssaIds);
            ctx.Statement = new Statement(0, new SideEffect(Constant.Word32(32)), null);
            return new ExpressionSimplifier(ctx);
        }

		[Test]
		public void VpAddZero()
		{
			Identifier r = Reg32("r");
			Identifier s = Reg32("s");

            var sub = new BinaryExpression(Operator.Sub, PrimitiveType.Word32, new MemoryAccess(MemoryIdentifier.GlobalMemory, r, PrimitiveType.Word32), Constant.Word32(0));
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			var exp = sub.Accept(vp);
			Assert.AreEqual("Mem0[r:word32]", exp.ToString());
		}

		[Test]
		public void VpEquality2()
		{
			// Makes sure that 
			// y = x - 2
			// if (y == 0) ...
			// doesn't get munged into
			// y = x - 2
			// if (x == 2)

			Identifier x = Reg32("x");
			Identifier y = Reg32("y");
            ProcedureBuilder m = new ProcedureBuilder();
            var stmX = m.Assign(x, m.LoadDw(Constant.Word32(0x1000300)));
			ssaIds[x].DefStatement = m.Block.Statements.Last;
            var stmY = m.Assign(y, m.Sub(x, 2));
			ssaIds[y].DefStatement = m.Block.Statements.Last;
			var stm = m.BranchIf(m.Eq(y, 0), "test");
			Assert.AreEqual("x = Mem0[0x01000300:word32]", stmX.ToString());
			Assert.AreEqual("y = x - 0x00000002", stmY.ToString());
			Assert.AreEqual("branch y == 0x00000000 test", stm.ToString());

			var vp = new ValuePropagator(ssaIds, null);
			vp.Transform(stm);
			Assert.AreEqual("branch x == 0x00000002 test", stm.Instruction.ToString());
		}

		[Test]
		public void VpCopyPropagate()
		{
			Identifier x = Reg32("x");
			Identifier y = Reg32("y");
			Identifier z = Reg32("z");
			Identifier w = Reg32("w");
			Statement stmX = new Statement(0, new Assignment(x, new MemoryAccess(MemoryIdentifier.GlobalMemory, Constant.Word32(0x10004000), PrimitiveType.Word32)), null);
			Statement stmY = new Statement(1, new Assignment(y, x), null);
			Statement stmZ = new Statement(2, new Assignment(z, new BinaryExpression(Operator.Add, PrimitiveType.Word32, y, Constant.Word32(2))), null);
			Statement stmW = new Statement(3, new Assignment(w, y), null);
			ssaIds[x].DefStatement = stmX;
			ssaIds[y].DefStatement = stmY;
			ssaIds[z].DefStatement = stmZ;
			ssaIds[w].DefStatement = stmW;
			ssaIds[x].Uses.Add(stmY);
			ssaIds[y].Uses.Add(stmZ);
			ssaIds[y].Uses.Add(stmW);
			Assert.AreEqual("x = Mem0[0x10004000:word32]", stmX.Instruction.ToString());
			Assert.AreEqual("y = x", stmY.Instruction.ToString());
			Assert.AreEqual("z = y + 0x00000002", stmZ.Instruction.ToString());
			Assert.AreEqual("w = y", stmW.Instruction.ToString());

			ValuePropagator vp = new ValuePropagator(ssaIds, null);
			vp.Transform(stmX);
			vp.Transform(stmY);
			vp.Transform(stmZ);
			vp.Transform(stmW);

			Assert.AreEqual("x = Mem0[0x10004000:word32]", stmX.Instruction.ToString());
			Assert.AreEqual("y = x", stmY.Instruction.ToString());
			Assert.AreEqual("z = x + 0x00000002", stmZ.Instruction.ToString());
			Assert.AreEqual("w = x", stmW.Instruction.ToString());
			Assert.AreEqual(3, ssaIds[x].Uses.Count);
			Assert.AreEqual(0, ssaIds[y].Uses.Count);
		}

		[Test]
		public void VpSliceConstant()
		{
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
            Expression c = new Slice(PrimitiveType.Byte, Constant.Word32(0x10FF), 0).Accept(vp);
			Assert.AreEqual("0xFF", c.ToString());
		}

		[Test]
		public void VpNegSub()
		{
			Identifier x = Reg32("x");
			Identifier y = Reg32("y");
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			Expression e = vp.VisitUnaryExpression(
				new UnaryExpression(Operator.Neg, PrimitiveType.Word32, new BinaryExpression(
				Operator.Sub, PrimitiveType.Word32, x, y)));
			Assert.AreEqual("y - x", e.ToString());
		}

		/// <summary>
		/// (<< (+ (* id c1) id) c2))
		/// </summary>
		[Test] 
		public void VpMulAddShift()
		{
			Identifier id = Reg32("id");
			Identifier x =  Reg32("x");
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			PrimitiveType t = PrimitiveType.Int32;
			BinaryExpression b = new BinaryExpression(Operator.Shl, t, 
				new BinaryExpression(Operator.Add, t, 
					new BinaryExpression(Operator.Muls, t, id, new Constant(t, 4)),
					id),
				new Constant(t, 2));
			Expression e = vp.VisitBinaryExpression(b);
			Assert.AreEqual("id *s 20", e.ToString());

		}

		[Test]
		public void VpShiftShift()
		{
			Identifier id = Reg32("id");
			ProcedureBuilder m = new ProcedureBuilder();
			Expression e = m.Shl(m.Shl(id, 1), 4);
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			e = e.Accept(vp);
			Assert.AreEqual("id << 0x00000005", e.ToString());
		}

		[Test]
		public void VpShiftSum()
		{
			Constant c = Constant.Word32(1);
			ProcedureBuilder m = new ProcedureBuilder();
			Expression e = m.Shl(1, m.Sub(new Constant(PrimitiveType.Byte, 32), 1));
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			e = e.Accept(vp);
			Assert.AreEqual("0x80000000", e.ToString());
		}

		[Test]
		public void VpSequenceOfConstants()
		{
			Constant pre = new Constant(PrimitiveType.Word16, 0x0001);
			Constant fix = new Constant(PrimitiveType.Word16, 0x0002);
			Expression e = new MkSequence(PrimitiveType.Word32, pre, fix);
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
			e = e.Accept(vp);
			Assert.AreEqual("0x00010002", e.ToString());
		}

        [Test]
        public void SliceShift()
        {
            Constant eight = new Constant(PrimitiveType.Word16, 8);
            Constant ate = new Constant(PrimitiveType.Word32, 8);
            Identifier C = Reg8("C");
            Identifier ax = Reg16("ax");
            Expression e = new Slice(PrimitiveType.Byte, new BinaryExpression(Operator.Shl, PrimitiveType.Word16, C, eight), 8);
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
            e = e.Accept(vp);
            Assert.AreEqual("C", e.ToString());
        }

        [Test]
        public void MkSequenceToAddress()
        {
            Constant seg = new Constant(PrimitiveType.SegmentSelector, 0x4711);
            Constant off = new Constant(PrimitiveType.Word16, 0x4111);
            Expression e = new MkSequence(PrimitiveType.Word32, seg, off);
            var vp = new ExpressionSimplifier(new SsaEvaluationContext(ssaIds));
            e = e.Accept(vp);
            Assert.IsInstanceOf(typeof(Address), e);
            Assert.AreEqual("4711:4111", e.ToString());
        }

        [Test]

		private Identifier Reg32(string name)
		{
			var mr = new RegisterStorage(name, ssaIds.Count, PrimitiveType.Word32);
			Identifier id = new Identifier(mr.Name, ssaIds.Count, mr.DataType, mr);
			SsaIdentifier sid = new SsaIdentifier(id, id, null, null, false);
			ssaIds.Add(sid);
			return sid.Identifier;
		}

        private Identifier Reg16(string name)
        {
            var mr = new RegisterStorage(name, ssaIds.Count, PrimitiveType.Word16);
            Identifier id = new Identifier(mr.Name, ssaIds.Count, mr.DataType, mr);
            SsaIdentifier sid = new SsaIdentifier(id, id, null, null, false);
            ssaIds.Add(sid);
            return sid.Identifier;
        }


        private Identifier Reg8(string name)
        {
            var mr = new RegisterStorage(name, ssaIds.Count, PrimitiveType.Byte);
            Identifier id = new Identifier(mr.Name, ssaIds.Count, mr.DataType, mr);
            SsaIdentifier sid = new SsaIdentifier(id, id, null, null, false);
            ssaIds.Add(sid);
            return sid.Identifier;
        }

        protected override void RunTest(Program prog, TextWriter writer)
		{
			var dfa = new DataFlowAnalysis(prog, new FakeDecompilerEventListener());
			dfa.UntangleProcedures();
			foreach (Procedure proc in prog.Procedures.Values)
			{
				writer.WriteLine("= {0} ========================", proc.Name);
				var gr = proc.CreateBlockDominatorGraph();
				Aliases alias = new Aliases(proc, prog.Architecture);
				alias.Transform();
				SsaTransform sst = new SsaTransform(proc, gr);
				SsaState ssa = sst.SsaState;

				ssa.Write(writer);
				proc.Write(false, writer);
				writer.WriteLine();

				ValuePropagator vp = new ValuePropagator(ssa.Identifiers, proc);
				vp.Transform();

				ssa.Write(writer);
				proc.Write(false, writer);
			}
		}

		private class DpbMock : ProcedureBuilder
		{
			protected override void BuildBody()
			{
				var dl = LocalByte("dl");
				var dx = Local16("dx");
				var edx = Local32("edx");

				Assign(edx, Int32(0x0AAA00AA));
				Assign(edx, Dpb(edx, Int8(0x55), 8, 8));
				Store(Int32(0x1000000), edx);


				Assign(edx, Int32(0));
                Assign(edx, Dpb(edx, dl, 0, 8));
				Return(edx);
			}
		}
	}
}
