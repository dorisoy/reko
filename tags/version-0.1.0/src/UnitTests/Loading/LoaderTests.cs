/* 
 * Copyright (C) 1999-2009 John K�ll�n.
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
using Decompiler.Core;
using Decompiler.Core.Serialization;
using Decompiler.Loading;
using Decompiler.Scanning;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace Decompiler.UnitTests.Loading
{
	[TestFixture]
	public class LoaderTests
	{
        private IServiceContainer sc;
        FakeDecompilerEventListener eventListener;

        [SetUp]
        public void Setup()
        {
            sc = new ServiceContainer();
            eventListener = new FakeDecompilerEventListener();
            sc.AddService(typeof(DecompilerEventListener), eventListener);
        }

		[Test]
		public void LoadProjectFileNoBom()
		{
			byte [] image = new UTF8Encoding(false).GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?><project xmlns=\"http://schemata.jklnet.org/Decompiler\">" +
				"<input><filename>foo.bar</filename></input></project>");
            TestLoader ldr = new TestLoader(new Program(), sc);
			ldr.Image = image;
            Assert.AreEqual("foo.bar", ldr.Load(null).Project.Input.Filename);
		}

        [Test]
        public void Match()
        {
            TestLoader ldr = new TestLoader(new Program(), sc);
            Assert.IsTrue(ldr.ImageBeginsWithMagicNumber(new byte[] { 0x47, 0x11 }, "4711"));
        }

        [Test]
        public void LoadUnknownImageType()
        {
            Program prog = new Program();
            TestLoader ldr = new TestLoader(prog, sc);
            ldr.Image = new byte[] { 42, 42, 42, 42, };
            LoadedProject lpr = ldr.Load(null);

            Assert.AreEqual("WarningDiagnostic - 00000000: The format of the file test.bin is unknown; you will need to specify it manually." , eventListener.LastDiagnostic);
            Assert.AreEqual(0, lpr.Program.Image.BaseAddress.Offset);
            Assert.IsNull(lpr.Program.Architecture);
            Assert.IsNull(lpr.Program.Platform);

        }

		private class TestLoader : Loader
		{
			public TestLoader(Program prog, IServiceProvider services)
                : base("test.bin", new FakeDecompilerConfiguration(), services)
			{
			}

			private byte [] image;

			public byte [] Image
			{
				get { return image; }
				set { image = value; }
			}

			public override byte[] LoadImageBytes(string fileName, int offset)
			{
				return image;
			}

		}
	}
}
