﻿#region License
/* 
 * Copyright (C) 1999-2015 John Källén.
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

#if DEBUG
using Decompiler.Core;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decompiler.ImageLoaders.OdbgScript
{
    [TestFixture]
    public class OllyLangTests
    {
        private MockRepository mr;
        private IHost host;
        private OllyLang engine;
        private LoadedImage image;

        [SetUp]
        public void Setup()
        {
            mr = new MockRepository();
        }

        [Test]
        public void Ose_var()
        {
            Given_Engine();
            Given_Script("var foo\r\n");
            mr.ReplayAll();

            engine.Run();

            Assert.IsTrue(engine.variables.ContainsKey("foo"));
        }

        private void Given_Script(string script)
        {
            engine.script.Clear();
            engine.script.LoadScriptFromString(script, ".");
        }

        private void Given_Engine()
        {
            this.host = mr.Stub<IHost>();
            engine = new OllyLang();
            engine.Host = host;
            engine.Debugger = new Debugger(null);
        }

        private void Given_Image(uint addr, params byte[] bytes)
        {
            image = new LoadedImage(Address.Ptr32(addr), bytes);
            host.Stub(h => h.Image).Return(image);
            host.Stub(h => h.TE_GetMemoryInfo(
                Arg<ulong>.Is.Anything,
                out Arg<MEMORY_BASIC_INFORMATION>.Out(new MEMORY_BASIC_INFORMATION
                {
                    BaseAddress = image.BaseAddress.ToLinear(),
                    RegionSize = (uint)image.Length,
                    AllocationBase = image.BaseAddress.ToLinear()
                }).Dummy)).Return(true);
        }

        [Test]
        public void Ose_LineArgs()
        {
            var line = new OllyScript.Line();
            OllyScript.ParseArgumentsIntoLine( " hello,world", line);
            Assert.AreEqual(2, line.args.Length);
        }

        [Test]
        public void Ose_LineArgString()
        {
            var line = new OllyScript.Line();
            OllyScript.ParseArgumentsIntoLine(" \"hello,world\"", line);
            Assert.AreEqual(1, line.args.Length);
        }

        [Test]
        public void Ose_Find()
        {
            Given_Engine();
            Given_Image(0x001000, new byte[] { 0, 0, 0, 0, 0, 1, 2, 3 });
            Given_Script("find 001000, #01#\r\n");
            mr.ReplayAll();

            engine.Run();

            Assert.AreEqual(0x1000 + 5, engine.variables["$RESULT"].ToUInt64());
        }

        [Test]
        public void Ose_FindReplace()
        {
            Given_Engine();
            Given_Image(0x001000, new byte[] { 0x2a, 0x2a, 0x2a, 0x21, 0x23, 0x21, 0x23 });
            host.Expect(h => h.WriteMemory(
                Arg<ulong>.Is.Anything,
                Arg<int>.Is.Equal(3),
                Arg<byte[]>.Is.NotNull)).Do(new Func<ulong,int,byte[],bool>((a, l, b) =>
            {
                LoadedImage.WriteBytes(b, a - image.BaseAddress.ToLinear(), l,image.Bytes);
                return true;
            }));

            Given_Script(
                "find 001000, #21??21#\r\n" +
                "test $RESULT,$RESULT\r\n" +
                "jz done\r\n"+
                "fill $RESULT,3,2d\r\n"+
                "done:\r\n"
                );
            mr.ReplayAll();

            engine.Run();

            Assert.AreEqual("***---#", Encoding.ASCII.GetString(image.Bytes));
        }
    }

    [TestFixture]
    public class VarTests
    {
        [Test]
        public void Reverse_Pattern()
        {
            var v = Var.Create("#1234#");
            v = v.reverse();
            Assert.AreEqual("3412", v.to_bytes());
            v = Var.Create("#123456#");
            v = v.reverse();
            Assert.AreEqual("563412", v.to_bytes());
        }

        [Test]
        public void Resize_Pattern()
        {
            var v = Var.Create("#1234#");
            v.resize(1);
            Assert.AreEqual("12", v.to_bytes());
        }
    }
}

#endif
