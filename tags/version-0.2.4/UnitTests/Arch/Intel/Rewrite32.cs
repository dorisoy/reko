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
using Decompiler.Core;
using Decompiler.Arch.X86;
using Decompiler.Assemblers.x86;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Decompiler.UnitTests.Arch.Intel
{
	[TestFixture]
	public class Rewrite32
	{
		[Test]
		public void RwAutoArray32()
		{
			RunTest("Fragments/autoarray32.asm", "Intel/RwAutoArray32.txt");
		}

		[Test]
		public void RwMallocFree()
		{
			RunTest("Fragments/import32/mallocfree.asm", "Intel/RwMallocFree.txt");
		}

		[Test]
		public void RwFrame32()
		{
			RunTest("fragments/multiple/frame32.asm", "Intel/RwFrame32.txt");
		}

		[Test]
		public void RwFtol()
		{
			RunTest("Fragments/import32/ftol.asm", "Intel/RwFtol.txt");
		}

		[Test]
		public void RwGlobalHandle()
		{
			RunTest("Fragments/import32/globalhandle.asm", "Intel/RwGlobalHandle.txt");
		}

		[Test]
		public void RwLoopMalloc()
		{
			RunTest("Fragments/import32/loopmalloc.asm", "Intel/RwLoopMalloc.txt");
		}

		[Test]
		public void RwLoopGetDC()
		{
			RunTest("Fragments/import32/loop_GetDC.asm", "Intel/RwLoopGetDC.txt");
		}

		[Test]
		public void RwReg00004()
		{
			RunTest("Fragments/regressions/r00004.asm", "Intel/RwReg00004.txt");
		}

		[Test]
		public void RwReg00006()
		{
			RunTest("Fragments/regressions/r00006.asm", "Intel/RwReg00006.txt");
		}


		[Test]
		public void RwSwitch32()
		{
			RunTest("Fragments/switch32.asm", "Intel/RwSwitch32.txt");
		}

		private void RunTest(string sourceFile, string outputFile)
		{
			Program prog = new Program();
            var asm = new IntelTextAssembler();
            using (StreamReader rdr = new StreamReader(FileUnitTester.MapTestPath(sourceFile)))
            {
                asm.Assemble(new Address(0x10000000), rdr);
                prog.Image = asm.Image;
            }
            prog.Platform = new Decompiler.Environments.Win32.Win32Platform(asm.Architecture);
            prog.Architecture = new IntelArchitecture(ProcessorMode.ProtectedFlat);
            foreach (var item in asm.ImportThunks)
            {
                prog.ImportThunks.Add(item.Key, item.Value);
            }
            Scanner scan = new Scanner(prog, new Dictionary<Address, ProcedureSignature>(), new FakeDecompilerEventListener());
            foreach (var ep in asm.EntryPoints)
            {
                scan.EnqueueEntryPoint(ep);
            }
            scan.ProcessQueue();

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