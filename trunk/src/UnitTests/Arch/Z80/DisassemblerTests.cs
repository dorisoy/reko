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

using Decompiler.Arch.Z80;
using Decompiler.Core;
using Decompiler.Core.Machine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Arch.Z80
{
    [TestFixture]
    public class DisassemblerTests
    {
        private MachineInstruction RunTest(params byte [] bytes)
        {
            var image = new ProgramImage(new Address(0x0100), bytes);
            var rdr = new LeImageReader(image, 0);
            var dasm = new Z80Disassembler(rdr);
            return dasm.DisassembleInstruction();
        }

        [Test]
        public void Z80dis_ld_b_a()
        {
            var instr = RunTest(0x47);
            Assert.AreEqual("ld\tb,a", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_M_a()
        {
            var instr = RunTest(0x71);
            Assert.AreEqual("ld\t(hl),c", instr.ToString());
        }

        [Test]
        public void Z80dis_hlt()
        {
            var instr = RunTest(0x76);
            Assert.AreEqual("hlt\t", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_a_bc()
        {
            var instr = RunTest(0x0A);
            Assert.AreEqual("ld\ta,(bc)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_a_de()
        {
            var instr = RunTest(0x1A);
            Assert.AreEqual("ld\ta,(de)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_a_offset()
        {
            var instr = RunTest(0x3A, 0x34, 0x12);
            Assert.AreEqual("ld\ta,(1234)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_a_ix_offset()
        {
            var instr = RunTest(0xDD, 0x7E, 0x12);
            Assert.AreEqual("ld\ta,(ix+12)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_a_iy_negoffset()
        {
            var instr = RunTest(0xFD, 0x7E, 0xFF);
            Assert.AreEqual("ld\ta,(iy-01)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_b_ix()
        {
            var instr = RunTest(0xDD, 0x46, 0x00);
            Assert.AreEqual("ld\tb,(ix)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_ix_e()
        {
            var instr = RunTest(0xDD, 0x73, 0xFE);
            Assert.AreEqual("ld\t(ix-02),e", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_h_imm()
        {
            var instr = RunTest(0x26, 0xFE);
            Assert.AreEqual("ld\th,FE", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_bc_a()
        {
            var instr = RunTest(0x02);
            Assert.AreEqual("ld\t(bc),a", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_de_a()
        {
            var instr = RunTest(0x12);
            Assert.AreEqual("ld\t(de),a", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_offset_a()
        {
            var instr = RunTest(0x32, 0x78, 0x56);
            Assert.AreEqual("ld\t(5678),a", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_hl_imm()
        {
            var instr = RunTest(0x21, 0x78, 0x56);
            Assert.AreEqual("ld\thl,5678", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_sp_imm()
        {
            var instr = RunTest(0x31, 0x34, 0x12);
            Assert.AreEqual("ld\tsp,1234", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_ix_imm()
        {
            var instr = RunTest(0xDD, 0x21, 0x34, 0x12);
            Assert.AreEqual("ld\tix,1234", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_hl_off()
        {
            var instr = RunTest(0x2A, 0x34, 0x12);
            Assert.AreEqual("ld\thl,(1234)", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_off_hl()
        {
            var instr = RunTest(0x22, 0x34, 0x12);
            Assert.AreEqual("ld\t(1234),hl", instr.ToString());
        }

        [Test]
        public void Z80dis_ld_sp_hl()
        {
            var instr = RunTest(0xF9);
            Assert.AreEqual("ld\tsp,hl", instr.ToString());
        }

        [Test]
        public void Z80dis_add_a_c()
        {
            var instr = RunTest(0x81);
            Assert.AreEqual("add\ta,c", instr.ToString());
        }

        [Test]
        public void Z80dis_add_a_imm()
        {
            var instr = RunTest(0xC6, 0x81);
            Assert.AreEqual("add\ta,81", instr.ToString());
        }

        [Test]
        public void Z80dis_adc_a_c()
        {
            var instr = RunTest(0x89);
            Assert.AreEqual("adc\ta,c", instr.ToString());
        }

        [Test]
        public void Z80dis_adc_a_imm()
        {
            var instr = RunTest(0xCE, 0x81);
            Assert.AreEqual("adc\ta,81", instr.ToString());
        }

        [Test]
        public void Z80dis_add_hl_sp()
        {
            var instr = RunTest(0x39);
            Assert.AreEqual("add\thl,sp", instr.ToString());
        }

        [Test]
        public void Z80dis_inc_d()
        {
            var instr = RunTest(0x14);
            Assert.AreEqual("inc\td", instr.ToString());
        }
    }
}
