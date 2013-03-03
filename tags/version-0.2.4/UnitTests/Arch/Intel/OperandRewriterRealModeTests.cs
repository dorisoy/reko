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

using Decompiler.Arch.X86;
using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Types;
using NUnit.Framework;
using System;

namespace Decompiler.UnitTests.Arch.Intel
{
	/// <summary>
	/// Tests for operator rewriting when dealing with real mode.
	/// </summary>
	[TestFixture]
	public class OperandRewriterRealModeTests
	{
		private OperandRewriter orw;
		private IntelArchitecture arch;
        private X86State state;
		private Procedure proc;

		[TestFixtureSetUp]
		public void Setup()
		{
			arch = new IntelArchitecture(ProcessorMode.Real);
			var prog = new Program();
			prog.Image = new ProgramImage(new Address(0x10000), new byte[4]);
			var procAddress = new Address(0x10000000);
            proc = Procedure.Create(null, procAddress, arch.CreateFrame());
			orw = new OperandRewriter(arch, proc.Frame, new FakeRewriterHost(prog));
            state = (X86State)arch.CreateProcessorState();
        }

		[Test]
		public void RewriteSegConst()
		{
			var m = new MemoryOperand(
				PrimitiveType.Byte,
				Registers.bx,
				new Constant(PrimitiveType.Int32, 32));
			var e = orw.CreateMemoryAccess(m, state);
			Assert.AreEqual("Mem0[ds:bx + 0x0020:byte]", e.ToString());
		}
	}
}
