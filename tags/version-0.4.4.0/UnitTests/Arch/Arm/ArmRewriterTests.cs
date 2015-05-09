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

using Decompiler.Arch.Arm;
using Decompiler.Core;
using Decompiler.Core.Rtl;
using Decompiler.Core.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Arch.Arm
{
    [TestFixture]
    class ArmRewriterTests : RewriterTestBase
    {
        private ArmProcessorArchitecture arch = new ArmProcessorArchitecture();
        private LoadedImage image;
        private Address baseAddress = Address.Ptr32(0x00100000);

        public override IProcessorArchitecture Architecture
        {
            get { return arch; }
        }

        public override Address LoadAddress
        {
            get { return baseAddress; }
        }

        protected override IEnumerable<RtlInstructionCluster> GetInstructionStream(Frame frame, IRewriterHost host)
        {
            return new ArmRewriter(arch, new LeImageReader(image, 0), new ArmProcessorState(arch), frame, host);
        }

        private void BuildTest(params string[] bitStrings)
        {
            var bytes = bitStrings.Select(bits => base.ParseBitPattern(bits))
                .SelectMany(u => new byte[] { (byte) u, (byte) (u >> 8), (byte) (u >> 16), (byte) (u >> 24) })
                .ToArray();
            image = new LoadedImage(Address.Ptr32(0x00100000), bytes);
        }

        private void BuildTest(params uint[] words)
        {
            var bytes = words
                .SelectMany(u => new byte[] { (byte) u, (byte) (u >> 8), (byte) (u >> 16), (byte) (u >> 24) })
                .ToArray();
            image = new LoadedImage(Address.Ptr32(0x00100000), bytes);
        }

        [Test]
        public void ArmRw_mov_r1_r2()
        {
            BuildTest("1110 00 0 1101 0 0000 0001 00000000 0010");
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|r1 = r2");
        }

        [Test]
        public void ArmRw_add_r1_r2_r3()
        {
            BuildTest("1110 00 0 0100 0 0010 0001 00000000 0011");
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|r1 = r2 + r3");
        }

        [Test]
        public void ArmRw_adds_r1_r2_r3()
        {
            BuildTest("1110 00 0 0100 1 0010 0001 00000000 0011");
            AssertCode(
                "0|00100000(4): 2 instructions",
                "1|L--|r1 = r2 + r3",
                "2|L--|SZCO = cond(r1)");
        }

        [Test]
        public void ArmRw_subgt_r1_r2_imm4()
        {
            BuildTest("1100 00 1 0010 0 0010 0001 0000 00000100");
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|if (Test(GT,NZV)) r1 = r2 - 0x00000004");
        }

        [Test]
        public void ArmRw_orr_r3_r4_r5_lsl_5()
        {
            BuildTest("1110 00 0 1100 0 1100 0001 00100 000 0100");
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|r1 = ip | r4 << 0x04");
        }

        [Test]
        public void ArmRw_brgt()
        {
            BuildTest("1100 1010 000000000000000000000000");
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|T--|if (Test(GT,NZV)) branch 00100008");
        }

        [Test]
        public void ArmRw_lsl()
        {
            BuildTest(0xE1a00200);  // mov\tr0,r0,lsl #4
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|r0 = r0 << 0x04");
        }

        [Test]
        public void ArmRw_stmdb()
        {
            BuildTest(0xE92C003B);  // stmdb ip!,{r0,r1,r3-r5},lr,pc}
            AssertCode(
                "0|00100000(4): 6 instructions",
                "1|L--|Mem0[ip:word32] = r0",
                "2|L--|Mem0[ip - 0x00000004:word32] = r1",
                "3|L--|Mem0[ip - 0x00000008:word32] = r3",
                "4|L--|Mem0[ip - 0x0000000C:word32] = r4",
                "5|L--|Mem0[ip - 0x00000010:word32] = r5",
                "6|L--|ip = ip - 0x00000014");
        }

        [Test]
        public void ArmRw_bllt()
        {
            BuildTest(0xBB000330);  // bllt
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|T--|if (Test(LT,NV)) call 00100CC8 (0)");
        }

        [Test]
        public void ArmRw_ldr()
        {
            BuildTest(0xE5940008);  // ldr r0,[r4,#8]
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|r0 = Mem0[r4 + 0x00000008:word32]");
        }

        [Test]
        public void ArmRw_bne()
        {
            BuildTest(0x1A000004);  // bne
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|T--|if (Test(NE,Z)) branch 00100018");
        }

        [Test]
        public void ArmRw_bic()
        {
            BuildTest(0xE3CEB3FF);  // bic
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|L--|fp = lr & ~0xFC000003");
        }

        [Test]
        public void ArmRw_mov_pc_lr()
        {
            BuildTest(0xE1B0F00E);  // mov pc,lr
            AssertCode(
                "0|00100000(4): 1 instructions",
                "1|T--|return (0,0)");
        }

        [Test]
        public void ArmRw_mvns()
        {
            BuildTest(0xE1F120D1);  // mvns\tr2,r1,asr r0
                 AssertCode(
                "0|00100000(4): 2 instructions",
                "1|r2 = ~r0L",
                "2|SCZO = cond(r2)");
        }
    }
}
