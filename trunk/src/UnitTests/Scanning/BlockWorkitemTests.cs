﻿#region License
/* 
 * Copyright (C) 1999-2010 John Källén.
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
using Decompiler.Core.Code;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.UnitTests.Scanning
{
    [TestFixture]
    public class BlockWorkitemTests
    {
        private MockRepository repository;
        private IScanner scanner;
        private IProcessorArchitecture arch;
        private Rewriter2 rewriter;
        private Program prog;
        private Procedure proc;
        private Block block;
        private LowLevelStatementStream m;

        [SetUp]
        public void Setup()
        {
            repository = new MockRepository();
            prog = new Program();
            proc = new Procedure("testProc", new Frame(null));
            block = new Block(proc, "test");
            m = new LowLevelStatementStream();

            scanner = repository.DynamicMock<IScanner>();
            arch = repository.DynamicMock<IProcessorArchitecture>();
            rewriter = repository.Stub<Rewriter2>();
        }

        [Test]
        public void RewriteReturn()
        {
            var addr = new Address(0x1000);

            m.Return();
            m.Fn(m.Int32(0x49242));

            using (repository.Record())
            {
                arch.Stub(x => x.CreateRewriter2(
                    Arg<Address>.Is.Anything)).Return(rewriter);
                rewriter.Stub(x => x.GetEnumerator()).Return(m.GetRewrittenInstructions());
            }

            BlockWorkitem2 wi = new BlockWorkitem2(scanner, arch, block, addr);
            wi.Process();
            Assert.AreEqual(1, block.Statements.Count);
            Assert.IsTrue(proc.ControlGraph.ContainsEdge(block, proc.ExitBlock));
        }

        [Test]
        public void RewritersMustNotSendBranches()
        {
            var addr = new Address(0x1000);

            using (repository.Record())
            {
                arch.Stub(x => x.CreateRewriter2(Arg<Address>.Is.Anything)).Return(rewriter);
                rewriter.Stub(x => x.GetEnumerator()).Return(m.GetRewrittenInstructions());
            }

            m.Emit(new Branch(m.Eq0(m.Register(0)), null));
            var wi = new BlockWorkitem2(scanner, arch, block, addr);
            try
            {
                wi.Process();
                Assert.Fail("Expected an exception to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Branch instructions should not be generated by rewriters: return a GotoStatement with a condition instead.", ex.Message);
            }
        }



        [Test]
        public void StopOnGoto()
        {
            m.Assign(m.Register(0), 3);
            m.Goto(0x4000);
            using (repository.Record())
            {
                arch.Stub(x => x.CreateRewriter2(Arg<Address>.Is.Anything)).Return(rewriter);
                rewriter.Stub(x => x.GetEnumerator()).Return(m.GetRewrittenInstructions());
            }

            var wi = new BlockWorkitem2(scanner, arch, block, new Address(0x1234));
            wi.Process();
            Assert.AreEqual(0, block.Statements.Count);
        }

    }
}
