﻿#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
using Decompiler.Core.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Arch
{
    abstract class DisassemblerTestBase<TInstruction> : ArchTestBase
        where TInstruction : MachineInstruction
    {
        private Address baseAddress;

        public DisassemblerTestBase(IProcessorArchitecture arch, Address baseAddress, int instructionSizeInBits) : base(arch, instructionSizeInBits)
        {
            this.baseAddress = baseAddress;
        }


        protected abstract ImageWriter CreateImageWriter(byte[] bytes);

        public TInstruction DisassembleBytes(byte[] a)
        {
            LoadedImage img = new LoadedImage(baseAddress, a);
            return Disassemble(img);
        }

        public TInstruction DisassembleWord(uint instr)
        {
            var bytes = new byte[256];
            CreateImageWriter(bytes).WriteUInt32(0, instr);
            var img = new LoadedImage(baseAddress, bytes);
            return Disassemble(img);
        }

        protected TInstruction DisassembleBits(string bitPattern)
        {
            var img = new LoadedImage(baseAddress, new byte[256]);
            uint instr = ParseBitPattern(bitPattern);
            CreateImageWriter(img.Bytes).WriteUInt32(0, instr);
            return Disassemble(img);
        }

        public TInstruction Disassemble(LoadedImage img)
        {
            var dasm = Architecture.CreateDisassembler(img.CreateReader(0U));
            var instr = dasm.DisassembleInstruction();
            return (TInstruction) instr;
        }
    }
}
