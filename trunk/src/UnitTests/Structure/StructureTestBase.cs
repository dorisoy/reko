/* 
 * Copyright (C) 1999-2008 John K�ll�n.
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

using Decompiler;
using Decompiler.Analysis;
using Decompiler.Arch.Intel;
using Decompiler.Core;
using Decompiler.Loading;
using Decompiler.Scanning;
using System;

namespace Decompiler.UnitTests.Structure
{
	public class StructureTestBase
	{
		protected Program prog;

		protected void RewriteProgram(string sourceFilename, Address addrBase)
		{
			prog = new Program();
			AssemblerLoader ldr = new AssemblerLoader(
                FileUnitTester.MapTestPath(sourceFilename),
                prog,
                new IntelArchitecture(addrBase.Selector != 0 ? ProcessorMode.Real : ProcessorMode.ProtectedFlat));
            ldr.Load(addrBase);
			Scanner scan = new Scanner(prog,  null);
			foreach (EntryPoint ep in ldr.EntryPoints)
			{
				scan.EnqueueEntryPoint(ep);
			}
			scan.ProcessQueues();
			DecompilerHost host = new FakeDecompilerHost();
			RewriterHost rw = new RewriterHost(prog, host, scan.SystemCalls, scan.VectorUses);
			rw.RewriteProgram();
			DataFlowAnalysis da = new DataFlowAnalysis(prog, host);
			da.AnalyzeProgram();
		}
	}
}
