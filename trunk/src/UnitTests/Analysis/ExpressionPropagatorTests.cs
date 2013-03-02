﻿#region License
/* 
 * Copyright (C) 1999-2013 John Källén.
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
using Decompiler.Analysis;
using Decompiler.Evaluation;
using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Types;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Analysis
{
    [TestFixture]
    public class ExpressionPropagatorTests
    {
        [Test]
        public void TestCondition()
        {
            var p = new ProgramBuilder();
            var proc = p.Add("main", (m) =>
            {
                m.Label("foo");
                m.BranchCc(ConditionCode.EQ, "foo");
                m.Return();
            });

            var ctx = new SymbolicEvaluationContext(new IntelArchitecture(ProcessorMode.ProtectedFlat), proc.Frame);
            var simplifier = new ExpressionSimplifier(ctx);
            var ep = new ExpressionPropagator(null, simplifier, ctx, new ProgramDataFlow());

            var newInstr = proc.EntryBlock.Succ[0].Statements[0].Instruction.Accept(ep);
            Assert.AreEqual("branch Test(EQ,Z) foo", newInstr.ToString());
        }
    

        [Test]
        public void ConditionOf()
        {
            var p = new ProgramBuilder();
            var proc = p.Add("main", (m) =>
            {
                var szo = m.Frame.EnsureFlagGroup(0x7, "SZO", PrimitiveType.Byte);
                var ebx = m.Frame.EnsureRegister(new RegisterStorage("ebx", 0, PrimitiveType.Word32));
                var v4 = m.Frame.CreateTemporary(PrimitiveType.Word16);

                m.Assign(v4, m.Add(m.LoadW(ebx), 1));
                m.Store(ebx, v4);
                m.Assign(szo, m.Cond(v4));
                m.Return();
            });

            var ctx = new SymbolicEvaluationContext(new IntelArchitecture(ProcessorMode.ProtectedFlat), proc.Frame);
            var simplifier = new ExpressionSimplifier(ctx);
            var ep = new ExpressionPropagator(null, simplifier, ctx, new ProgramDataFlow());

            var newInstr = proc.EntryBlock.Succ[0].Statements[2].Instruction.Accept(ep);
            Assert.AreEqual("SZO = cond(v4)", newInstr.ToString());
        }

        [Test]
        public void Application()
        {
            var p = new ProgramBuilder();
            var proc = p.Add("main", (m) =>
            {
                var r1 = m.Frame.EnsureRegister(new RegisterStorage("r1", 1, PrimitiveType.Word32));

                m.Assign(r1, m.Word32(0x42));
                m.SideEffect(m.Fn("foo", r1));
                m.Return();
            });

            var ctx = new SymbolicEvaluationContext(new FakeArchitecture(), proc.Frame);
            var simplifier = new ExpressionSimplifier(ctx);
            var ep = new ExpressionPropagator(null, simplifier, ctx, new ProgramDataFlow());

            var stms = proc.EntryBlock.Succ[0].Statements;
            stms[0].Instruction.Accept(ep);
            var newInstr = stms[1].Instruction.Accept(ep);
            Assert.AreEqual("foo(0x00000042)", newInstr.ToString());
        }

        [Test]
        public void IndirectCall()
        {
            var arch = new FakeArchitecture();
            var p = new ProgramBuilder(arch);
            var proc = p.Add("main", (m) =>
            {
                var r1 = m.Register("r1");

                m.Assign(r1, m.Word32(0x42));
                m.Emit(new CallInstruction(r1, new CallSite(4, 0)));
                m.Return();
            });

            var ctx = new SymbolicEvaluationContext(arch, proc.Frame);
            var simplifier = new ExpressionSimplifier(ctx);
            var ep = new ExpressionPropagator(arch, simplifier, ctx, new ProgramDataFlow());

            ctx.RegisterState[arch.StackRegister] = proc.Frame.FramePointer;
            var stms = proc.EntryBlock.Succ[0].Statements;
            stms[0].Instruction.Accept(ep);
            var newInstr = stms[1].Instruction.Accept(ep);
            Assert.AreEqual("call 0x00000042 (retsize: 4; depth: 4)", newInstr.ToString());
        }

        [Test]
        public void StackReference()
        {
            var arch = new FakeArchitecture();
            var p = new ProgramBuilder(arch);
            var proc = p.Add("main", (m) =>
            {
                var sp = m.Frame.EnsureRegister(m.Architecture.StackRegister);
                var r1 = m.Register(1);
                m.Assign(sp, m.Sub(sp, 4));
                m.Assign(r1, m.LoadDw(m.Add(sp, 8)));
                m.Return();
            });

            var ctx = new SymbolicEvaluationContext(arch, proc.Frame);
            var simplifier = new ExpressionSimplifier(ctx);
            var ep = new ExpressionPropagator(arch, simplifier, ctx, new ProgramDataFlow());

            ctx.RegisterState[arch.StackRegister] = proc.Frame.FramePointer;

            var stms = proc.EntryBlock.Succ[0].Statements;
            var newInstr = stms[0].Instruction.Accept(ep);
            Assert.AreEqual("r63 = fp - 0x00000004", newInstr.ToString());
            newInstr = stms[1].Instruction.Accept(ep);
            Assert.AreEqual("r1 = dwArg04", newInstr.ToString());
        }
    }
}
