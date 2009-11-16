﻿/* 
 * Copyright (C) 1999-2009 John Källén.
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

using Decompiler.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decompiler.UnitTests.Mocks
{
    public class FakeDecompilerHost : DecompilerHost
    {
        private StringWriter disassembly = new StringWriter();
        private StringWriter decompiled = new StringWriter();
        private StringWriter typesWriter = new StringWriter();
        private DecompilerConfiguration config = new FakeDecompilerConfiguration();

        public TextWriter CreateDecompiledCodeWriter(string file)
        {
            return decompiled;
        }

        public TextWriter CreateDisassemblyWriter()
        {
            return disassembly;
        }

        public TextWriter GetIntermediateCodeWriter()
        {
            return null;
        }

        DecompilerConfiguration DecompilerHost.Configuration
        {
            get { return config; }
        }

        public TextWriter CreateTypesWriter(string fileName)
        {
            return typesWriter;
        }

        // probing methods.

        public StringWriter DisassemblyWriter
        {
            get { return disassembly; }
        }

        public StringWriter TypesWriter
        {
            get { return typesWriter; }
        }

    }
}
