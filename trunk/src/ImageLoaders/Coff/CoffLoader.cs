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
using Decompiler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.ImageLoaders.Coff
{
    public class CoffLoader : ImageLoader
    {
        private  IProcessorArchitecture arch;

        public CoffLoader(IServiceProvider services, byte[] rawBytes)
            : base(services, rawBytes)
        {
            this.header = LoadHeader();
        }

        public override IProcessorArchitecture Architecture
        {
            get { return arch; }
        }

        public override Platform Platform
        {
            get { throw new NotImplementedException(); }
        }

        public override Address PreferredBaseAddress
        {
            get { throw new NotImplementedException(); }
        }

        public override ProgramImage Load(Address addrLoad)
        {
            throw new NotImplementedException();
        }

        private FileHeader LoadHeader()
        {
            var rdr = new ImageReader(RawImage, 0);
            var magic = rdr.ReadLeUInt16();
            switch (magic)
            {
            case 0x014C: arch = new IntelArchitecture(ProcessorMode.ProtectedFlat); break;
            default: throw new NotSupportedException();
            }
            return  new FileHeader
            {
                f_magic = magic,
                f_nscns = rdr.ReadUInt16(),
                f_timdat = rdr.ReadUInt32(),
                f_symptr = rdr.ReadUInt32(),
                f_nsyms = rdr.ReadUInt32(),
                f_opthdr = rdr.ReadUInt16(),
                f_flags = rdr.ReadUInt16(),
            };
        }

        public override void Relocate(Address addrLoad, List<EntryPoint> entryPoints, RelocationDictionary relocations)
        {
            throw new NotImplementedException();
        }

        public FileHeader header { get; set; }
    }
}
