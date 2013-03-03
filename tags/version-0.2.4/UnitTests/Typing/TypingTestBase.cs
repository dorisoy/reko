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
using Decompiler.Analysis;
using Decompiler.Arch.X86;
using Decompiler.Assemblers.x86;
using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using Decompiler.Loading;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Decompiler.UnitTests.Typing
{
	/// <summary>
	/// Base class for all typing tests.
	/// </summary>
	public abstract class TypingTestBase
	{
		protected Program RewriteFile(string relativePath)
		{
            AssemblerLoader ldr = new AssemblerLoader(
                new IntelTextAssembler(),
                FileUnitTester.MapTestPath(relativePath));

            var prog = ldr.Load(new Address(0xC00, 0));
            var ep = new EntryPoint(prog.Image.BaseAddress, prog.Architecture.CreateProcessorState());
			var scan = new Scanner(prog, new Dictionary<Address, ProcedureSignature>(), new FakeDecompilerEventListener());
			scan.EnqueueEntryPoint(ep);
			scan.ProcessQueue();

			var dfa = new DataFlowAnalysis(prog, new FakeDecompilerEventListener());
			dfa.AnalyzeProgram();
            return prog;
		}

        protected void RunTest(string srcfile, string outputFile)
        {
            RunTest(RewriteFile(srcfile), outputFile);
        }
        
        protected void RunTest(ProgramBuilder mock, string outputFile)
        {
            Program prog = mock.BuildProgram();
            DataFlowAnalysis dfa = new DataFlowAnalysis(prog, new FakeDecompilerEventListener());
            dfa.DumpProgram();
            dfa.BuildExpressionTrees();
            RunTest(prog, outputFile);
        }

        protected void RunTest(ProcGenerator pg, string outputFile)
        {
            ProcedureBuilder m = new ProcedureBuilder();
            pg(m);
            ProgramBuilder prog = new ProgramBuilder();
            prog.Add(m);
            RunTest(prog, outputFile);
        }


        protected abstract void RunTest(Program prog, string outputFile);

		protected void DumpSsaInfo(Procedure proc, SsaState ssa, TextWriter writer)
		{
			writer.WriteLine("// {0} ////////////////////////////////", proc.Name);
			DumpSsaTypes(ssa, writer);
			proc.Write(false, writer);
			writer.WriteLine();
		}

		protected void DumpSsaTypes(SsaState ssa, TextWriter writer)
		{
			foreach (SsaIdentifier id in ssa.Identifiers)
			{
				if (id.Identifier.TypeVariable != null)
					writer.WriteLine("{0}: {1}", id.Identifier, id.Identifier.TypeVariable);
			}
		}

		protected MemoryAccess MemLoad(Identifier id, int offset, DataType size)
		{
			return new MemoryAccess(MemoryIdentifier.GlobalMemory, 
				new BinaryExpression(Operator.Add, PrimitiveType.Word32, id, Constant.Word32(offset)),
				size);
		}
	}
}
