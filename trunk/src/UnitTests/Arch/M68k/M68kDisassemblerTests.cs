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
using Decompiler.Arch.M68k;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Arch.M68k
{
    [TestFixture]
    public class M68kDisassemblerTests
    {
        private M68kDisassembler dasm;
        private M68kInstruction instr;

        private void DasmSingleInstruction(params byte[] bytes)
        {
            dasm = CreateDasm(bytes, 0x10000000);
            Assert.IsTrue(dasm.MoveNext());
            instr = dasm.Current;
        }

        private M68kDisassembler CreateDasm(byte[] bytes, uint address)
        {
            Address addr = new Address(address);
            LoadedImage img = new LoadedImage(addr, bytes);
            return M68kDisassembler.Create68020(img.CreateReader(addr));
        }

        private M68kDisassembler CreateDasm(params ushort[] words)
        {
            byte[] bytes = words.SelectMany(w => new byte[] { (byte) (w >> 8), (byte) w }).ToArray();
            return CreateDasm(bytes, 0x10000000);
        }

        public MachineInstruction Disassemble()
        {
            if (dasm.MoveNext())
                return dasm.Current;
            return null;
        }

        [Test]
        public void M68kdis_moveQ()
        {
            byte[] bytes = new byte[] {
                0x72, 0x01
            };
            DasmSingleInstruction(bytes);
            Assert.AreEqual("moveq\t#$+01,d1", instr.ToString());
        }

        [Test]
        public void M68kdis_addQ()
        {
            byte[] bytes = new byte[] {
                0x5E, 0x92
            };
            DasmSingleInstruction(bytes);
            Assert.AreEqual("addq.l\t#$07,(a2)", instr.ToString());
        }

        [Test]
        public void M68kdis_Ori()
        {
            byte[] bytes = new byte[] {
                0x00, 0x00, 0x00, 0x12
            };
            DasmSingleInstruction(bytes);
            Assert.AreEqual("ori.b\t#$12,d0", instr.ToString());
        }

        [Test]
        public void M68kdis_OriCcr()
        {
            byte[] bytes = new byte[] {
                0x00, 0x3C, 0x00, 0x42
                };
            DasmSingleInstruction(bytes);
            Assert.AreEqual("ori.b\t#$42,ccr", instr.ToString());
        }

        [Test]
        public void M68kdis_OriSr()
        {
            byte[] bytes = new byte[] {
                0x00, 0x7C, 0x00, 0x42
                };
            DasmSingleInstruction(bytes);
            Assert.AreEqual("ori.w\t#$0042,sr", instr.ToString());
        }

        [Test]
        public void M68kdis_MoveW()
        {
            DasmSingleInstruction(0x30, 0x2F, 0x47, 0x11);
            Assert.AreEqual("move.w\t$4711(a7),d0", instr.ToString());
        }

        [Test]
        public void Lea()
        {
            DasmSingleInstruction(0x43, 0xEF, 0x00, 0x04);
            Assert.AreEqual("lea\t$0004(a7),a1", instr.ToString());
        }

        [Test]
        public void LslD()
        {
            DasmSingleInstruction(0xE5, 0x49, 0x00, 0x04);
            Assert.AreEqual("lsl.w\t#$02,d1", instr.ToString());
        }

        [Test]
        public void AddaW()
        {
            DasmSingleInstruction(0xD2, 0xC1, 0x00, 0x04);
            Assert.AreEqual("adda.w\td1,a1", instr.ToString());
        }

        [Test]
        public void Addal()
        {
            dasm = CreateDasm(0xDBDC);
            Assert.AreEqual("adda.l\t(a4)+,a5", Disassemble().ToString());
        }

        [Test]
        public void MoveA()
        {
            DasmSingleInstruction(0x20, 0x51, 0x00, 0x04);
            Assert.AreEqual("movea.l\t(a1),a0", instr.ToString());
        }

        [Test]
        public void MoveM()
        {
            DasmSingleInstruction(0x48, 0xE7, 0x00, 0x04);
            Assert.AreEqual("movem.l\ta5,-(a7)", instr.ToString());
        }

        [Test]
        public void BraB()
        {
            DasmSingleInstruction(0x60, 0x1A);
            Assert.AreEqual("bra\t$1000001C", instr.ToString());
        }

        [Test]
        public void M68kdis_Bchg()
        {
            DasmSingleInstruction(0x01, 0x40);
            Assert.AreEqual("bchg\td0,d0", instr.ToString());
        }

        [Test]
        public void Dbra()
        {
            DasmSingleInstruction(0x51, 0xCA, 0xFF, 0xE4);
            Assert.AreEqual("dbra\td2,$0FFFFFE6", instr.ToString());
        }

        [Test]
        public void Moveb()
        {
            DasmSingleInstruction(0x14, 0x1A);
            Assert.AreEqual("move.b\t(a2)+,d2", instr.ToString());
        }

        [Test]
        public void ManyMoves()
        {
            dasm = CreateDasm(new byte[] { 0x20, 0x00, 0x20, 0x27, 0x20, 0x40, 0x20, 0x67, 0x20, 0x80, 0x21, 0x40, 0x00, 0x00 }, 0x10000000);
            Assert.AreEqual("move.l\td0,d0", Disassemble().ToString());
            Assert.AreEqual("move.l\t-(a7),d0", Disassemble().ToString());
            Assert.AreEqual("movea.l\td0,a0", Disassemble().ToString());
            Assert.AreEqual("movea.l\t-(a7),a0", Disassemble().ToString());
            Assert.AreEqual("move.l\td0,(a0)", Disassemble().ToString());
            Assert.AreEqual("move.l\td0,$0000(a0)", Disassemble().ToString());
        }

        [Test]
        public void AddB()
        {
            DasmSingleInstruction(0xD2, 0x02);
            Assert.AreEqual("add.b\td2,d1", instr.ToString());
        }

        [Test]
        public void Eor()
        {
            dasm = CreateDasm(0xB103, 0xB143, 0xB183);
            Assert.AreEqual("eor.b\td0,d3", Disassemble().ToString());
            Assert.AreEqual("eor.w\td0,d3", Disassemble().ToString());
            Assert.AreEqual("eor.l\td0,d3", Disassemble().ToString());
        }

        [Test]
        public void Bcs()
        {
            dasm = CreateDasm(0x6572);
            Assert.AreEqual("bcs\t$10000074", Disassemble().ToString());
        }

        private void RunTest(string expected, params ushort[] words)
        {
            dasm = CreateDasm(words);
            Assert.AreEqual(expected, Disassemble().ToString());
        }

        [Test]
        public void or_s_with_immediate()
        {
            RunTest("or.b\t#$23,d3", 0x863c, 0x1123);
            RunTest("or.w\t#$1123,d3", 0x867c, 0x1123);
            RunTest("or.l\t#$11234455,d3", 0x86Bc, 0x1123, 0x4455);
        }

        [Test]
        public void M68kdis_Pre_and_post_dec()
        {
            RunTest("move.w\t-(a3),(a3)+", 0x36E3);
        }

        [Test]
        public void M68kdis_eori()
        {
            RunTest("eori.b\t#$34,d0", 0x0A00, 0x1234);
        }

        [Test]
        public void M68kdis_muls_w()
        {
            RunTest("muls.w\t-(a3),d0", 0xC1E3);
        }

        [Test]
        public void M68kdis_mulu_l()
        {
            RunTest("mulu.l\td0,d6,d7", 0x4c00, 0x7406);
        }

        [Test]
        public void M68kdis_not()
        {
            RunTest("not.b\td7", 0x4607);
        }

        [Test]
        public void M68kdis_and()
        {
            RunTest("and.l\t-(a3),d1", 0xC2A3);
        }

        [Test]
        public void M68kdis_and_rev()
        {
            RunTest("and.l\td1,-(a3)", 0xC3A3);
        }

        [Test]
        public void M68kdis_andi_32()
        {
            RunTest("andi.l\t#$00010000,(a4)+", 0x029C, 0x0001, 0x0000);
        }

        [Test]
        public void M68kdis_andi_8()
        {
            RunTest("andi.b\t#$F0,d2", 0x0202, 0x00F0);
        }

        [Test]
        public void M68kdis_asrb_qb()
        {
            RunTest("asr.b\t#$07,d0", 0xEE00);
        }

        [Test]
        public void M68kdis_neg_w()
        {
            RunTest("neg.w\t(a3)+", 0x445B);
        }

        [Test]
        public void M68kdis_negx_8()
        {
            RunTest("negx.w\td0", 0x4040);
        }

        [Test]
        public void M68kdis_sub_er_16()
        {
            RunTest("sub.w\t-(a4),d0", 0x9064);
        }

        [Test]
        public void M68kdis_suba_16()
        {
            RunTest("suba.w\t(a4)+,a0", 0x90DC);
        }

        [Test]
        public void M68kdis_clrw_ea_off()
        {
            RunTest("clr.w\t$0008(a0)", 0x4268, 0x0008);
        }

        [Test]
        public void M68kdis_clrw_ea()
        {
            RunTest("clr.w\t(a0)+", 0x4258);
        }

        [Test]
        public void M68kdis_cmpib()
        {
            RunTest("cmpi.b\t#$42,d0", 0x0C00, 0x0042);
        }

        [Test]
        public void M68kdis_cmpw_d_d()
        {
            RunTest("cmp.w\td1,d0", 0xB041);
        }

        [Test]
        public void M68kdis_jsr_mem()
        {
            RunTest("jsr.l\t(a0)", 0x4E90);
        }

        [Test]
        public void M68kdis_or()
        {
            RunTest("or.b\td0,$-0008(a0)", 0x8128, 0xFFF8);
            RunTest("or.w\td0,$-0008(a0)", 0x8168, 0xFFF8);
            RunTest("or.l\td0,$-0008(a0)", 0x81A8, 0xFFF8);
        }

        [Test]
        public void M68kdis_lsl_w()
        {
            RunTest("lsl.w\t#$08,d0", 0xE148);
        }

        [Test]
        public void M68kdis_subq_b()
        {
            RunTest("subq.b\t#$04,d6", 0x5906);
            RunTest("subq.b\t#$08,(a2)", 0x5112);
        }

        [Test]
        public void M68kdis_subq_w()
        {
            RunTest("subq.w\t#$07,-(a6)", 0x5F66);
            RunTest("subq.w\t#$01,(34,a0,d1)", 0x5370, 0x1034);
        }

        [Test]
        public void M68kdis_subq_l()
        {
            RunTest("subq.l\t#$06,$12345678", 0x5DB9, 0x1234, 0x5678);
            RunTest("subq.l\t#$01,$1234(a1)", 0x53A9, 0x1234);
        }

        [Test]
        public void M68kdis_subi()
        {
            RunTest("subi.b\t#$34,d0", 0x0400, 0x1234);
            RunTest("subi.w\t#$1234,d0", 0x0440, 0x1234);
            RunTest("subi.l\t#$12345678,d0", 0x0480, 0x1234, 0x5678);
        }

        [Test]
        public void M68kdis_sub_re()
        {
            RunTest("sub.l\td0,(a7)+", 0x919F);
        }

        [Test]
        public void M68kdis_rts()
        {
            RunTest("rts\t", 0x4E75);
        }

        [Test]
        public void M68kdis_asr_r()
        {
            RunTest("asr.b\td3,d4", 0xE624);
            RunTest("asr.w\td3,d4", 0xE664);
            RunTest("asr.l\td3,d4", 0xE6A4);
            RunTest("asr.w\t-(a5)", 0xE0E5, 1234);
        }

        [Test]
        public void M68kdis_asl()
        {
            RunTest("asl.b\t#$08,d1", 0xe101);
            RunTest("asl.w\t#$08,d1", 0xe141);
            RunTest("asl.l\t#$08,d1", 0xe181);
            RunTest("asl.b\td0,d1", 0xe121);
            RunTest("asl.w\td0,d1", 0xe161);
            RunTest("asl.l\td0,d1", 0xe1a1);
            RunTest("asl.w\t(a1)", 0xe1D1);
        }

        [Test]
        public void M68kdis_subx_mm()
        {
            RunTest("subx.b\t-(a1),-(a0)", 0x9109);
            RunTest("subx.w\t-(a1),-(a0)", 0x9149);
            RunTest("subx.l\t-(a1),-(a0)", 0x9189);
        }

        [Test]
        public void M68kdis_subx_rr()
        {
            RunTest("subx.b\td1,d0", 0x9101);
            RunTest("subx.w\td1,d0", 0x9141);
            RunTest("subx.l\td1,d3", 0x9781);
        }

        [Test]
        public void M68kdis_addx_mm()
        {
            RunTest("addx.b\t-(a1),-(a0)", 0xD109);
            RunTest("addx.w\t-(a1),-(a0)", 0xD149);
            RunTest("addx.l\t-(a1),-(a0)", 0xD189);
        }

        [Test]
        public void M68kdis_addx_rr()
        {
            RunTest("addx.b\td1,d0", 0xD101);
            RunTest("addx.w\td1,d0", 0xD141);
            RunTest("addx.l\td1,d3", 0xD781);
        }

        [Test]
        public void M68kdis_addi()
        {
            RunTest("addi.b\t#$34,(a1)", 0x0611, 0x1234);
            RunTest("addi.w\t#$1234,(a1)", 0x0651, 0x1234);
            RunTest("addi.l\t#$12345678,(a1)", 0x0691, 0x1234, 0x5678);
        }

        [Test]
        public void M68kdis_lsl()
        {
            RunTest("lsl.l\t#$03,d2", 0xE78A);
            RunTest("lsl.b\td1,d3", 0xE32B);
            RunTest("lsl.w\td1,d4", 0xE36C);
            RunTest("lsl.l\td1,d4", 0xE3AC);
            RunTest("lsl.w\t(a1)", 0xE3D1);
        }

        [Test]
        public void M68kdis_bcc()
        {
            RunTest("bra\t$0FFFFFFE", 0x60FC);
            RunTest("bhi\t$0FFFFFFE", 0x62FC);
            RunTest("bcc\t$0FFFFFFE", 0x6400, 0xFFFC);
            RunTest("bge\t$0FFFFFFE", 0x6CFF, 0xFFFF, 0xFFFC);
        }

        [Test]
        public void M68kdis_ext()
        {
            RunTest("ext.w\td4", 0x4884);
            RunTest("ext.l\td4", 0x48C4);
            RunTest("extb.l\td4", 0x49C4);
        }

        [Test]
        public void M68kdis_lsr()
        {
            RunTest("lsr.w\t#$08,d1", 0xE049);
            RunTest("lsr.l\t#$08,d1", 0xE089);
            RunTest("lsr.b\td0,d1", 0xE029);
            RunTest("lsr.w\td0,d1", 0xE069);
            RunTest("lsr.l\td0,d1", 0xE0A9);
            RunTest("lsr.w\t(a1)", 0xE2D1);
        }

        [Test]
        public void M68kdis_unlk()
        {
            RunTest("unlk\ta7", 0x4E5F);
        }

        [Test]
        public void M68kdis_cmpm()
        {
            RunTest("cmpm.b\t(a2)+,(a3)+", 0xB70A);
            RunTest("cmpm.w\t(a2)+,(a3)+", 0xB74A);
            RunTest("cmpm.l\t(a2)+,(a3)+", 0xB78A);
        }

        [Test]
        public void M68kdis_bsr()
        {
            RunTest("bsr\t$0FFFFFFE", 0x61FC);
            RunTest("bsr\t$0FFFFFFE", 0x6100, 0xFFFC);
            RunTest("bsr\t$0FFFFFFE", 0x61FF, 0xFFFF, 0xFFFC);
        }

        [Test]
        public void M68kdis_pea()
        {
            RunTest("pea\t$0004(a2)", 0x486A, 0x0004);
        }

        [Test]
        public void M68kdis_dbra()
        {
            RunTest("dbra\td2,$0FFFFFFC", 0x51CA, 0xFFFA);
        }

        [Test]
        public void M68kdis_dble()
        {
            RunTest("dble\td7,$0FFFFFFC", 0x5FCF, 0xFFFA);
        }

        [Test]
        public void M68kdis_link()
        {
            RunTest("link\ta2,#$0004", 0x4E52, 0x0004);
            RunTest("link\ta3,#$00050004", 0x480B, 0x0005, 0004);
        }

        [Test]
        public void M68kdis_divs()
        {
            RunTest("divs.w\td4,d7", 0x8FC4);
        }

        [Test]
        public void M68kdis_bset_s()
        {
            RunTest("bset\t#$001F,d0", 0x08C0, 0x001F);
            RunTest("bset\td4,(a7)", 0x09D7);
        }
    }
}
