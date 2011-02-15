#region License
/* 
 * Copyright (C) 1999-2011 John K�ll�n.
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
using Decompiler.Arch.Intel;
using Decompiler.Assemblers.x86;
using Decompiler.Core;
using Decompiler.Core.Assemblers;
using Decompiler.Core.Output;
using Decompiler.Core.Serialization;
using Decompiler.Environments.Msdos;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Decompiler.UnitTests.Analysis
{
	public abstract class AnalysisTestBase
	{
		protected void DumpProcedureFlows(Program prog, DataFlowAnalysis dfa, RegisterLiveness live, TextWriter w)
		{
			foreach (Procedure proc in prog.Procedures.Values)
			{
				w.WriteLine("// {0} /////////////////////", proc.Name);
				ProcedureFlow flow = dfa.ProgramDataFlow[proc];
				DataFlow.EmitRegisters(prog.Architecture, "\tLiveOut:  ", flow.grfLiveOut, flow.LiveOut, w);
				w.WriteLine();
				DataFlow.EmitRegisters(prog.Architecture, "\tMayUseIn: ", flow.grfMayUse, flow.MayUse, w);
				w.WriteLine();
				DataFlow.EmitRegisters(prog.Architecture, "\tBypassIn: ", flow.grfMayUse, flow.ByPass, w);
				w.WriteLine();
				DataFlow.EmitRegisters(prog.Architecture, "\tTrashed:  ", flow.grfTrashed, flow.TrashedRegisters, w);
				w.WriteLine();
				DataFlow.EmitRegisters(prog.Architecture, "\tPreserved:", flow.grfPreserved, flow.PreservedRegisters, w);
				w.WriteLine();

				w.WriteLine("// {0}", proc.Name);
				proc.Signature.Emit(proc.Name, ProcedureSignature.EmitFlags.None, new Formatter(w));
				w.WriteLine();
				foreach (Block block in proc.RpoBlocks)
				{
					block.Write(w);
					if (live != null)
					{
						dfa.ProgramDataFlow[block].Emit(prog.Architecture, w);
						w.WriteLine();
					}
				}
			}
		}


        protected Program BuildProgramMock(Action<ProcedureBuilder> builder)
        {
            ProcedureBuilder m = new ProcedureBuilder();
            builder(m);
            return BuildProgramMock(m);
        }

        [Obsolete]
        protected Program BuildProgramMockOld(Action<ProcedureBuilder> builder)
        {
            ProcedureBuilder m = new ProcedureBuilder();
            builder(m);
            return BuildProgramMockOld(m);
        }

        protected Program BuildProgramMock(ProcedureBuilder mock)
        {
            var m = new ProgramBuilder();
            m.Add(mock);
            var prog = m.BuildProgram();
            prog.CallGraph.AddProcedure(mock.Procedure);
            DataFlowAnalysis dfa = new DataFlowAnalysis(prog, new FakeDecompilerEventListener());
            dfa.UntangleProcedures();
            return prog;
        }

        [Obsolete]
        protected Program BuildProgramMockOld(ProcedureBuilder mock)
		{
			ProgramBuilder m = new ProgramBuilder();
			m.Add(mock);
			Program prog = m.BuildProgram();
            prog.CallGraph.AddProcedure(mock.Procedure);
			DataFlowAnalysis dfa = new DataFlowAnalysis(prog, new FakeDecompilerEventListener());
			dfa.UntangleProcedures();
			return prog;
		}

        private Program RewriteFile(string relativePath, string configFile)
        {
            Program prog = new Program();
            prog.Architecture = new IntelArchitecture(ProcessorMode.Real);
            prog.Platform = new MsdosPlatform(prog.Architecture);
            Assembler asm = new IntelTextAssembler();
            using (var rdr = new StreamReader(FileUnitTester.MapTestPath(relativePath)))
            {
                asm.Assemble(new Address(0xC00, 0), rdr);
                prog.Image = asm.Image;
            }
            Rewrite(prog, asm, configFile);
            return prog;
        }

        [Obsolete]
		private Program RewriteFileOld(string relativePath, string configFile)
		{
			Program prog = new Program();
			prog.Architecture = new IntelArchitecture(ProcessorMode.Real);
			prog.Platform = new MsdosPlatform(prog.Architecture);
            Assembler asm = new IntelTextAssembler();
			asm.Assemble(new Address(0xC00, 0), FileUnitTester.MapTestPath(relativePath));
            prog.Image = asm.Image;
			Rewrite(prog, asm, configFile);
			return prog;
		}

		protected Program RewriteFileOld(string relativePath)
		{
			return RewriteFileOld(relativePath, null);
		}

        protected Program RewriteFile32(string sourceFile)
        {
            return RewriteFile32(sourceFile, null);
        }

        private Program RewriteFile32(string relativePath, string configFile)
        {
            Program prog = new Program();
            prog.Architecture = new IntelArchitecture(ProcessorMode.ProtectedFlat);
            Assembler asm = new IntelTextAssembler();
            using (var rdr = new StreamReader(FileUnitTester.MapTestPath(relativePath)))
            {
                asm.Assemble(new Address(0x10000000), rdr);
            }
            prog.Image = asm.Image;
            prog.Architecture = asm.Architecture;
            foreach (KeyValuePair<uint, PseudoProcedure> item in asm.ImportThunks)
            {
                prog.ImportThunks.Add(item.Key, item.Value);
            }
            Rewrite(prog, asm, configFile);
            return prog;
        }

        [Obsolete]
		protected Program RewriteFile32Old(string sourceFile)
		{
			return RewriteFile32Old(sourceFile, null);
		}

        [Obsolete]
        private Program RewriteFile32Old(string relativePath, string configFile)
        {
            Program prog = new Program();
            prog.Architecture = new IntelArchitecture(ProcessorMode.ProtectedFlat);
            Assembler asm = new IntelTextAssembler();
            asm.Assemble(new Address(0x10000000), FileUnitTester.MapTestPath(relativePath));
            prog.Image = asm.Image;
            prog.Architecture = asm.Architecture;
            foreach (KeyValuePair<uint, PseudoProcedure> item in asm.ImportThunks)
            {
                prog.ImportThunks.Add(item.Key, item.Value);
            }
            RewriteOld(prog, asm, configFile);
            return prog;
        }

        protected Program RewriteCodeFragment(string s)
        {
            Program prog = new Program();
            prog.Architecture = new IntelArchitecture(ProcessorMode.Real);
            Assembler asm = new IntelTextAssembler();
            asm.AssembleFragment(new Address(0xC00, 0), s);
            prog.Image = asm.Image;
            Rewrite(prog, asm, null);
            return prog;
        }

        [Obsolete]
		protected Program RewriteCodeFragmentOld(string s)
		{
			Program prog = new Program();
			prog.Architecture = new IntelArchitecture(ProcessorMode.Real);
            Assembler asm = new IntelTextAssembler();
			asm.AssembleFragment(new Address(0xC00, 0), s);
            prog.Image = asm.Image;
			RewriteOld(prog, asm, null);
			return prog;
		}

        private void Rewrite(Program prog, Assembler asm, string configFile)
        {
            Scanner scan = new Scanner(prog.Architecture, prog.Image, prog.Platform, 
                new Dictionary<Address, ProcedureSignature>(), new FakeDecompilerEventListener());
            SerializedProject project = new SerializedProject();
            if (configFile != null)
            {
                project = SerializedProject.Load(FileUnitTester.MapTestPath(configFile));
            }
            EntryPoint ep = new EntryPoint(asm.StartAddress, new IntelState());
            scan.EnqueueEntryPoint(ep);
            foreach (SerializedProcedure sp in project.UserProcedures)
            {
                scan.EnqueueUserProcedure(sp);
            }
            scan.ProcessQueue();
        }

        [Obsolete]
		private void RewriteOld(Program prog, Assembler asm, string configFile)
		{
			ScannerOld scan = new ScannerOld(prog, new FakeDecompilerEventListener());
			SerializedProject project = new SerializedProject();
			if (configFile != null)
			{
				project = SerializedProject.Load(FileUnitTester.MapTestPath(configFile));
			}
			EntryPoint ep = new EntryPoint(asm.StartAddress, new IntelState());
			scan.EnqueueEntryPoint(ep);
			foreach (SerializedProcedure sp in project.UserProcedures)
			{
				scan.EnqueueUserProcedure(sp);
			}
			scan.ProcessQueue();
			RewriterHost rw = new RewriterHost(prog, null, scan.SystemCalls, scan.VectorUses);
			rw.RewriteProgram();
		}


		protected void RunTest(string sourceFile, string outputFile)
		{
			Program prog = RewriteFileOld(sourceFile);
			SaveRunOutput(prog, outputFile);
		}

		protected void RunTest(ProcedureBuilder mock, string outputFile)
		{
			Program prog = BuildProgramMockOld(mock);
			SaveRunOutput(prog, outputFile);
		}

		protected void RunTest(string sourceFile, string configFile, string outputFile)
		{
			Program prog = RewriteFileOld(sourceFile, configFile);
			SaveRunOutput(prog, outputFile);
		}

		protected void RunTest32(string sourceFile, string outputFile)
		{
			Program prog = RewriteFile32Old(sourceFile);
			SaveRunOutput(prog, outputFile);
		}

		protected void RunTest32(string sourceFile, string configFile, string outputFile)
		{
			Program prog = RewriteFile32Old(sourceFile, configFile);
			SaveRunOutput(prog, outputFile);
		}

		protected virtual void RunTest(Program prog, FileUnitTester fut)
		{
		}

		protected void SaveRunOutput(Program prog, string outputFile)
		{
			using (FileUnitTester fut = new FileUnitTester(outputFile))
			{
				RunTest(prog, fut);
				fut.AssertFilesEqual();
			}
		}
	}
}
