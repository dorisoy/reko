﻿#region License
/* 
 * Copyright (C) 1999-2011 John Källén.
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

using Decompiler.Core.Expressions;
using Decompiler.Evaluation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Evaluation
{
    [TestFixture]
    public class ExpressionMatcherTests
    {
        private ExpressionEmitter m;
        private ExpressionMatcher matcher;

        [SetUp]
        public void Setup()
        {
            m = new ExpressionEmitter();
        }

        private void Create(Expression pattern)
        {
            matcher = new ExpressionMatcher(pattern);
        }

        [Test]
        public void Identifier()
        {
            string name = "foo";
            var id = Id(name);
            Create(Id("foo"));
            Assert.IsTrue(matcher.Match(id));
        }

        private static Identifier Id(string name)
        {
            return new Identifier(name, 1, null, null);
        }

        [Test]
        public void MatchConstant()
        {
            var c = Constant.Word32(4);
            Create(Constant.Word32(4));
            Assert.IsTrue(matcher.Match(c));
        }

        [Test]
        public void MatchAnyConstant()
        {
            var c = Constant.Word32(4);
            Create(ExpressionMatcher.AnyConstant("c"));
            Assert.IsTrue(matcher.Match(c));
            Assert.AreEqual("0x00000004", matcher.CapturedExpression("c").ToString());
        }

        [Test]
        public void MatchBinOp()
        {
            var b = m.Add(Id("esp"), 4);
            Create(m.Add(Id("esp"), 4));
            Assert.IsTrue(matcher.Match(b));
        }

        [Test]
        public void BinOpMismatch()
        {
            var b = m.Add(Id("esp"), 4);
            Create(m.Sub(Id("esp"), 4));
            Assert.IsFalse(matcher.Match(b));
        }

        [Test]
        public void MemAccess()
        {
            var mem = m.LoadW(m.Add(Id("ebx"), 4));
            Create(m.LoadW(m.Add(AnyId("idx"), AnyC("offset"))));
            Assert.IsTrue(matcher.Match(mem));
            Assert.AreEqual("ebx", matcher.CapturedExpression("idx").ToString());
        }

        private Expression AnyC(string p)
        {
            return ExpressionMatcher.AnyConstant(p);
        }

        private Expression AnyId(string label)
        {
            return ExpressionMatcher.AnyId(label);
        }
    }
}
