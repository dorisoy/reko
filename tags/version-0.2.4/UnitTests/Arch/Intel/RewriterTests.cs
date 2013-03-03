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

using Decompiler;
using Decompiler.Arch.X86;
using Decompiler.Assemblers.x86;
using Decompiler.Core;
using Decompiler.Core.Assemblers;
using Decompiler.Core.Code;
using Decompiler.Core.Serialization;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Decompiler.UnitTests.Arch.Intel
{
	public class RewriterTestBase
	{
		private string configFile;
		protected Assembler asm; 
		protected Program prog;
		protected Scanner scanner;
		protected Address baseAddress;

		public RewriterTestBase()
		{
			baseAddress = new Address(0xC00, 0);
		}

		[SetUp]
		public void SetUp()
		{
			prog = new Program();
			prog.Architecture = new IntelArchitecture(ProcessorMode.Real);
            asm = new IntelTextAssembler();
			configFile = null;
		}

		public string ConfigFile
		{
			get { return configFile; }
			set { configFile = value; }
		}

		protected Procedure DoRewrite(string code)
		{
            asm.AssembleFragment(baseAddress, code);
            prog.Image = asm.Image;
			DoRewriteCore();
			return scanner.Procedures.Values[0];
		}

        private void DoRewriteCore()
        {
            SerializedProject project = (configFile != null)
                ? SerializedProject.Load(FileUnitTester.MapTestPath(configFile))
                : new SerializedProject();
            scanner = new Scanner(prog, new Dictionary<Address, ProcedureSignature>(), new FakeDecompilerEventListener());
            EntryPoint ep = new EntryPoint(baseAddress, prog.Architecture.CreateProcessorState());
            scanner.EnqueueEntryPoint(ep);
            foreach (SerializedProcedure sp in project.UserProcedures)
            {
                scanner.EnqueueUserProcedure(sp);
            }
            scanner.ProcessQueue();
        }

		protected void DoRewriteFile(string relativePath)
		{
            using (var stm = new StreamReader(FileUnitTester.MapTestPath(relativePath)))
            {
                asm.Assemble(baseAddress, stm);
            }
            prog.Image = asm.Image;
            prog.Platform = asm.Platform;
			DoRewriteCore();
		}
	}

	/// <summary>
	/// Unit Tests for the Intel code rewriter.
	/// </summary>

	[TestFixture]
	public class RewriterTests : RewriterTestBase
	{
		[Test]
		public void SimpleTest()
		{
			DoRewrite(
				@"	.i86
	mov	ax,0x0000
	mov	cx,0x10
	add	ax,cx
	ret
");

			Assert.AreEqual(1, prog.Procedures.Count );
			Procedure proc = prog.Procedures.Values[0];
			Assert.AreEqual(3, proc.ControlGraph.Blocks.Count);		// Entry, code, Exit

            Block block = new List<Block>(proc.ControlGraph.Successors(proc.EntryBlock))[0];
			Assert.AreEqual(5, block.Statements.Count);
			Assignment instr1 = (Assignment) block.Statements[0].Instruction;
			Assert.IsTrue(block.Statements[1].Instruction is Assignment);

			Assert.AreSame(new List<Block>(proc.ControlGraph.Successors(block))[0], proc.ExitBlock);
		}

		[Test]
		public void IfTest()
		{
			Procedure proc = DoRewrite(
				@"	.i86
	cmp	bx,ax
	jnz	not_eq

	mov	cx,3
	jmp	join
not_eq:
	mov	cx,2
join:
	ret
");
			Assert.AreEqual(6, proc.ControlGraph.Blocks.Count);
			StringWriter sb = new StringWriter();
			proc.Write(true, sb);
		}

		[Test]
		public void RwDeadConditionals()
		{
			DoRewriteFile("Fragments/small_loop.asm");
			Procedure proc = prog.Procedures.Values[0];
			using (FileUnitTester fut = new FileUnitTester("Intel/RwDeadConditionals.txt"))
			{
				proc.Write(true, fut.TextWriter);
				fut.AssertFilesEqual();
			}
			Assert.AreEqual(5, proc.ControlGraph.Blocks.Count);
		}

		[Test]
		public void RwPseudoProcs()
		{
			DoRewriteFile("Fragments/pseudoprocs.asm");
			Procedure proc = prog.Procedures.Values[0];
			using (FileUnitTester fut = new FileUnitTester("Intel/RwPseudoProcs.txt"))
			{
				proc.Write(true, fut.TextWriter);
				fut.AssertFilesEqual();
			}
		}

		[Test]
		public void RwAddSubCarries()
		{
			RunTest("Fragments/addsubcarries.asm", "Intel/RwAddSubCarries.txt");
		}

		[Test]
		public void RwLongAddSub()
		{
			RunTest("Fragments/longaddsub.asm", "Intel/RwLongAddSub.txt");
		}

		[Test]
		public void RwEnterLeave()
		{
			RunTest("Fragments/enterleave.asm", "Intel/RwEnterLeave.txt");
		}

		[Test]
		public void RwReg00003()
		{
			RunTest("Fragments/regressions/r00003.asm", "Intel/RwReg00003.txt");
		}

		[Test]
		public void RwReg00005()
		{
			RunTest("Fragments/regressions/r00005.asm", "Intel/RwReg00005.txt");
		}

		[Test]
		public void RwSequenceShifts()
		{
			RunTest("Fragments/sequenceshift.asm", "Intel/RwSequenceShifts.txt");
		}

		[Test]
		public void RwLogical()
		{
			RunTest("Fragments/logical.asm", "Intel/RwLogical.txt");
		}

		[Test]
		public void RwNegsNots()
		{
			RunTest("Fragments/negsnots.asm", "Intel/RwNegsNots.txt");
		}

		[Test]
		public void RwFpuArgs()
		{
			RunTest("Fragments/multiple/fpuargs.asm", "Intel/RwFpuArgs.txt");
		}

		[Test]
		public void RwFpuOps()
		{
			RunTest("Fragments/fpuops.asm", "Intel/RwFpuOps.txt");
		}

		[Test]
		public void RwFpuReversibles()
		{
			RunTest("Fragments/fpureversibles.asm", "Intel/RwFpuReversibles.txt");
		}

		private void RunTest(string sourceFile, string outputFile)
		{
			DoRewriteFile(sourceFile);
			using (FileUnitTester fut = new FileUnitTester(outputFile))
			{
				foreach (Procedure proc in prog.Procedures.Values)
				{
					proc.Write(true, fut.TextWriter);
					fut.TextWriter.WriteLine();
				}
				fut.AssertFilesEqual();
			}
		}
	}
}
