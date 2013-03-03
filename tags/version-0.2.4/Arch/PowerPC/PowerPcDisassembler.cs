#region License
/* 
 * Copyright (C) 1999-2013 John K�ll�n.
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
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.PowerPC
{
    public class PowerPcDisassembler : Disassembler
    {
        private PowerPcArchitecture arch;
        private ImageReader rdr;
        private PrimitiveType defaultWordWidth;

        public PowerPcDisassembler(PowerPcArchitecture arch, ImageReader rdr, PrimitiveType defaultWordWidth)
        {
            this.arch = arch;
            this.rdr = rdr;
            this.defaultWordWidth = defaultWordWidth;
        }

        public Address Address
        {
            get { return rdr.Address; }
        }

        public PowerPcInstruction Disassemble()
        {
            uint wInstr = rdr.ReadBeUInt32();
            return oprecs[wInstr >> 26].Decode(this, wInstr);
        }

        public MachineInstruction DisassembleInstruction()
        {
            return Disassemble();
        }

        private RegisterOperand RegFromBits(uint r)
        {
            return new RegisterOperand(arch.Registers[(int)r & 0x1F]);
        }

        private abstract class OpRec
        {
            public abstract PowerPcInstruction Decode(PowerPcDisassembler dasm, uint wInstr);
        }

        private class InvalidOpRec  : OpRec
        {
            public override PowerPcInstruction Decode(PowerPcDisassembler dasm, uint wInstr)
            {
                return new PowerPcInstruction(Opcode.illegal);
            }
        }

        private class DOpRec : OpRec
        {
            private Opcode opcode;
            private bool signed;
            private bool swapOps;

            public DOpRec(Opcode opcode, bool signed, bool swapOps)
            {
                this.opcode = opcode;
                this.signed = signed;
                this.swapOps = swapOps;
            }

            public override PowerPcInstruction Decode(PowerPcDisassembler dasm, uint wInstr)
            {
                RegisterOperand op1 = dasm.RegFromBits(wInstr >> (swapOps? 21 : 16));
                RegisterOperand op2 = dasm.RegFromBits(wInstr >> (swapOps? 16 : 21));

                return new PowerPcInstruction(
                    opcode, op1, op2,
                    Imm(signed ? PrimitiveType.Int16 : PrimitiveType.Word16, wInstr & 0xFFFFU),
                    false);
            }

            private ImmediateOperand Imm(PrimitiveType type, uint bits)
            {
                return new ImmediateOperand(new Constant(type, bits));
            }
        }

        private class XOpRec : OpRec
        {
            public override PowerPcInstruction Decode(PowerPcDisassembler dasm, uint wInstr)
            {
                return xOpRecs[(wInstr >> 1) & 0x3FF].Decode(dasm, wInstr, (wInstr & 1) == 1);
            }
        }

        private class XOpRecAux
        {
            private Opcode opcode;

            public XOpRecAux(Opcode opcode)
            {
                this.opcode = opcode;
            }

            public PowerPcInstruction Decode(PowerPcDisassembler dasm, uint wInstr, bool setsCr0)
            {
                return new PowerPcInstruction(opcode,
                    dasm.RegFromBits(wInstr >> 16),
                    dasm.RegFromBits(wInstr >> 21),
                    dasm.RegFromBits(wInstr >> 11),
                    setsCr0);
            }
        }

        static OpRec[] oprecs;
        static Dictionary<uint, XOpRecAux> xOpRecs;

        static PowerPcDisassembler()
        { 
            oprecs = new OpRec[] {
                // 00
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),

                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new DOpRec(Opcode.addi, true, true),
                new InvalidOpRec(),
                // 10
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),

                new DOpRec(Opcode.ori, false, false),
                new DOpRec(Opcode.oris, false, false),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new XOpRec(),
                // 20
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),

                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                // 30
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),

                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec(),
                new InvalidOpRec()
            };

            xOpRecs = new Dictionary<uint, XOpRecAux>();
            xOpRecs.Add(444, new XOpRecAux(Opcode.or));
        }
    }
}
/*
new DOpRec(2,tdi),	// Trap Doubleword Immediate
new DOpRec(3,twi),	// Trap Word Immediate
new DOpRec(7,mulli),	// Multiply Low Immediate
new DOprec(8, SR, Opcode.subfic),  //  Subtract From Immediate Carrying
new DOpRec(10,61,cmpli),	// Compare Logical Immediate
new DOpRec(11,60,cmpi),	// Compare Immediate
new DOpRec(12,SR,Opcode.52),	// addic Add Immediate Carrying
new DOpRec(13,SR,Opcode.52),	// addic. Add Immediate Carrying and Record
new DOpRec(14,51,addi),	// Add Immediate
new DOpRec(15,51,addis),	// Add Immediate Shifted
new BOpRec(16,CT), //bc[l][a] // Branch Conditional
new ScOpRec(17, 26, Opcode.sc ), // System Call
new IOpRec(18, b), // b[l][a]              // Branch
new XlOpRec(19,0,Opcode.mcrf),	// Move Condition Register Field
new XlOpRec(19,16, CT, Opcode.bclr[l]   // Branch Conditional to Link Register
new XlOpRec(19,18,Opcode.rfid),	// rfidReturn from Interrupt Doubleword
new XlOpRec(19,33,Opcode.crnor),	// Condition Register NOR
new XlOpRec(19,129,Opcode.crandc),	// Condition Register AND with Complement
new XlOpRec(19,150,Opcode.isync),	// Instruction Synchronize
new XlOpRec(19,193,Opcode.crxor),	// Condition Register XOR
new XlOpRec(19,225,Opcode.crnand),	// Condition Register NAND
new XlOpRec(19,257,Opcode.crand),	// Condition Register AND
new XlOpRec(19,274,Opcode.hrfid),	// Hypervisor Return from Interrupt Doubleword
new XlOpRec(19,289,Opcode.creqv),	// Condition Register Equivalent
new XlOpRec(19,417,Opcode.crorc),	// Condition Register OR with Complement
new XlOpRec(19,449,Opcode.cror),	// Condition Register OR
new XlOpRec(19, 528, CT), bcctr[l] // Branch Conditional to Count Register
M 20 SR 76 rlwimi[.] Rotate Left Word Immediate then Mask Insert
M 21 SR 73 rlwinm[.] Rotate Left Word Immediate then AND with Mask
M 23 SR 75 rlwnm[.] Rotate Left Word then AND with Mask
new DOpRec(24,66,ori),	// OR Immediate
new DOpRec(25,66,oris),	// OR Immediate Shifted
new DOpRec(26,66,xori),	// XOR Immediate
new DOpRec(27,66,xoris),	// XOR Immediate Shifted
new DOpRec(28,SR,Opcode.65),	// andi. AND Immediate
new DOpRec(29,SR,Opcode.65),	// andis. AND Immediate Shifted
MD 30 0 SR 72 rldicl[.] Rotate Left Doubleword Immediate then Clear Left
MD 30 1 SR 72 rldicr[.] Rotate Left Doubleword Immediate then Clear Right
MD 30 2 SR 73 rldic[.] Rotate Left Doubleword Immediate then Clear
MD 30 3 SR 76 rldimi[.] Rotate Left Doubleword Immediate then Mask Insert
MDS 30 8 SR 74 rldcl[.] Rotate Left Doubleword then Clear Left

MDS 30 9 SR 75 rldcr[.] Rotate Left Doubleword then Clear Right
X 31 0 60 cmp Compare
X 31 4 64 tw Trap Word
XO 31 8 SR 53 subfc[o][.] Subtract From Carrying
XO 31 9 SR 57 mulhdu[.] Multiply High Doubleword Unsigned
XO 31 10 SR 53 addc[o][.] Add Carrying
XO 31 11 SR 57 mulhwu[.] Multiply High Word Unsigned
XFX 31 19 83 mfcr Move From Condition Register
XFX 31 19 124 mfocrf Move From One Condition Register Field
X 31 20 II lwarx Load Word And Reserve Indexed
X 31 21 39 ldx Load Doubleword Indexed
X 31 23 37 lwzx Load Word and Zero Indexed
X 31 24 SR 77 slw[.] Shift Left Word
X 31 26 SR 70 cntlzw[.] Count Leading Zeros Word
X 31 27 SR 77 sld[.] Shift Left Doubleword
X 31 28 SR 67 and[.] AND
X 31 32 61 cmpl Compare Logical
XO 31 40 SR 52 subf[o][.] Subtract From
X 31 53 39 ldux Load Doubleword with Update Indexed
X 31 54 II dcbst Data Cache Block Store
X 31 55 37 lwzux Load Word and Zero with Update Indexed
X 31 58 SR 70 cntlzd[.] Count Leading Zeros Doubleword
X 31 60 SR 68 andc[.] AND with Complement
X 31 68 64 td Trap Doubleword
XO 31 73 SR 57 mulhd[.] Multiply High Doubleword
XO 31 75 SR 57 mulhw[.] Multiply High Word
X 31 83 III mfmsr Move From Machine State Register
X 31 84 II ldarx Load Doubleword And Reserve Indexed
X 31 86 II dcbf Data Cache Block Flush
X 31 87 34 lbzx Load Byte and Zero Indexed
XO 31 104 SR 55 neg[o][.] Negate
X 31 119 34 lbzux Load Byte and Zero with Update Indexed
X 31 122 70 popcntb Population Count Bytes
X 31 124 SR 68 nor[.] NOR
XO 31 136 SR 54 subfe[o][.] Subtract From Extended
XO 31 138 SR 54 adde[o][.] Add Extended
XFX 31 144 83 mtcrf Move To Condition Register Fields
XFX 31 144 124 mtocrf Move To One Condition Register Field
X 31 146 III mtmsr Move To Machine State Register
X 31 149 43 stdx Store Doubleword Indexed
X 31 150 II stwcx. Store Word Conditional Indexed
X 31 151 42 stwx Store Word Indexed
X 31 178 III mtmsrd Move To Machine State Register Doubleword
X 31 181 43 stdux Store Doubleword with Update Indexed
X 31 183 42 stwux Store Word with Update Indexed
XO 31 200 SR 55 subfze[o][.] Subtract From Zero Extended
XO 31 202 SR 55 addze[o][.] Add to Zero Extended
X 31 210 32 III mtsr Move To Segment Register
X 31 214 II stdcx. Store Doubleword Conditional Indexed
X 31 215 40 stbx Store Byte Indexed
XO 31 232 SR 54 subfme[o][.] Subtract From Minus One Extended
XO 31 233 SR 56 mulld[o][.] Multiply Low Doubleword
XO 31 234 SR 54 addme[o][.] Add to Minus One Extended
XO 31 235 SR 56 mullw[o][.] Multiply Low Word
X 31 242 32 III mtsrin Move To Segment Register Indirect
X 31 246 II dcbtst Data Cache Block Touch for Store
X 31 247 40 stbux Store Byte with Update Indexed
XO 31 266 SR 52 add[o][.] Add
X 31 278 II dcbt Data Cache Block Touch
X 31 279 35 lhzx Load Halfword and Zero Indexed
X 31 284 SR 68 eqv[.] Equivalent
X 31 306 64 III tlbie TLB Invalidate Entry

X 31 310 II eciwx External Control In Word Indexed
X 31 311 35 lhzux Load Halfword and Zero with Update Indexed
X 31 316 SR 67 xor[.] XOR
XFX 31 339 82 mfspr Move From Special Purpose Register
X 31 341 38 lwax Load Word Algebraic Indexed
X 31 343 36 lhax Load Halfword Algebraic Indexed
X 31 370 III tlbia TLB Invalidate All
XFX 31 371 II mftb Move From Time Base
X 31 373 38 lwaux Load Word Algebraic with Update Indexed
X 31 375 36 lhaux Load Halfword Algebraic with Update Indexed
X 31 402 III slbmte SLB Move To Entry
X 31 407 41 sthx Store Halfword Indexed
X 31 412 SR 68 orc[.] OR with Complement
XS 31 413 SR 79 sradi[.] Shift Right Algebraic Doubleword Immediate
X 31 434 III slbie SLB Invalidate Entry
X 31 438 II ecowx External Control Out Word Indexed
X 31 439 41 sthux Store Halfword with Update Indexed
X 31 444 SR 67 or[.] OR
XO 31 457 SR 59 divdu[o][.] Divide Doubleword Unsigned
XO 31 459 SR 59 divwu[o][.] Divide Word Unsigned
XFX 31 467 81 mtspr Move To Special Purpose Register
X 31 476 SR 67 nand[.] NAND
XO 31 489 SR 58 divd[o][.] Divide Doubleword
XO 31 491 SR 58 divw[o][.] Divide Word
X 31 498 III slbia SLB Invalidate All
X 31 512 135 mcrxr Move to Condition Register from XER
X 31 533 48 lswx Load String Word Indexed
X 31 534 44 lwbrx Load Word Byte-Reverse Indexed
X 31 535 104 lfsx Load Floating-Point Single Indexed
X 31 536 SR 78 srw[.] Shift Right Word
X 31 539 SR 78 srd[.] Shift Right Doubleword
X 31 566 III tlbsync TLB Synchronize
X 31 567 104 lfsux Load Floating-Point Single with Update Indexed
X 31 595 32 III mfsr Move From Segment Register
X 31 597 48 lswi Load String Word Immediate
X 31 598 II sync Synchronize
X 31 599 105 lfdx Load Floating-Point Double Indexed
X 31 631 105 lfdux Load Floating-Point Double with Update Indexed
X 31 659 32 III mfsrin Move From Segment Register Indirect
X 31 661 49 stswx Store String Word Indexed
X 31 662 45 stwbrx Store Word Byte-Reverse Indexed
X 31 663 107 stfsx Store Floating-Point Single Indexed
X 31 695 107 stfsux Store Floating-Point Single with Update Indexed
X 31 725 49 stswi Store String Word Immediate
X 31 727 108 stfdx Store Floating-Point Double Indexed
X 31 759 108 stfdux Store Floating-Point Double with Update Indexed
X 31 790 44 lhbrx Load Halfword Byte-Reverse Indexed
X 31 792 SR 80 sraw[.] Shift Right Algebraic Word
X 31 794 SR 80 srad[.] Shift Right Algebraic Doubleword
X 31 824 SR 79 srawi[.] Shift Right Algebraic Word Immediate
X 31 851 III slbmfev SLB Move From Entry VSID
X 31 854 II eieio Enforce In-order Execution of I/O
X 31 915 III slbmfee SLB Move From Entry ESID
X 31 918 45 sthbrx Store Halfword Byte-Reverse Indexed
X 31 922 SR 69 extsh[.] Extend Sign Halfword
X 31 954 SR 69 extsb[.] Extend Sign Byte
X 31 982 II icbi Instruction Cache Block Invalidate
X 31 983 109 stfiwx Store Floating-Point as Integer Word Indexed
X 31 986 SR 69 extsw[.] Extend Sign Word
X 31 1014 II dcbz Data Cache Block set to Zero
new DOpRec(32,37,lwz),	// Load Word and Zero
new DOpRec(33,37,lwzu),	// Load Word and Zero with Update

new DOpRec(34,34,lbz),	// Load Byte and Zero
new DOpRec(35,34,lbzu),	// Load Byte and Zero with Update
new DOpRec(36,42,stw),	// Store Word
new DOpRec(37,42,stwu),	// Store Word with Update
new DOpRec(38,40,stb),	// Store Byte
new DOpRec(39,40,stbu),	// Store Byte with Update
new DOpRec(40,35,lhz),	// Load Halfword and Zero
new DOpRec(41,35,lhzu),	// Load Halfword and Zero with Update
new DOpRec(42,36,lha),	// Load Halfword Algebraic
new DOpRec(43,36,lhau),	// Load Halfword Algebraic with Update
new DOpRec(44,41,sth),	// Store Halfword
new DOpRec(45,41,Opcode.sthu),	// Store Halfword with Update
new DOpRec(46,46,Opcode.lmw),	// Load Multiple Word
new DOpRec(47,46,Opcode.stmw),	// Store Multiple Word
new DOpRec(48,104,Opcode.lfs),	// Load Floating-Point Single
new DOpRec(49,104,Opcode.lfsu),	// Load Floating-Point Single with Update
new DOpRec(50,105,Opcode.lfd),	// Load Floating-Point Double
new DOpRec(51,105,Opcode.lfdu),	// Load Floating-Point Double with Update
new DOpRec(52,107,Opcode.stfs),	// Store Floating-Point Single
new DOpRec(53,107,Opcode.stfsu),	// Store Floating-Point Single with Update
new DOpRec(54,108,Opcode.stfd),	// Store Floating-Point Double
new DOpRec(55,108,Opcode.stfdu),	// Store Floating-Point Double with Update
DS 58 0 39 ld Load Doubleword
DS 58 1 39 ldu Load Doubleword with Update
DS 58 2 38 lwa Load Word Algebraic
A 59 18 112 fdivs[.] Floating Divide Single
A 59 20 111 fsubs[.] Floating Subtract Single
A 59 21 111 fadds[.] Floating Add Single
A 59 22 125 fsqrts[.] Floating Square Root Single
A 59 24 125 fres[.] Floating Reciprocal Estimate Single
A 59 25 112 fmuls[.] Floating Multiply Single
A 59 26 126 frsqrtes[.] Floating Reciprocal Square Root Estimate Single
A 59 28 113 fmsubs[.] Floating Multiply-Subtract Single
A 59 29 113 fmadds[.] Floating Multiply-Add Single
A 59 30 114 fnmsubs[.] Floating Negative Multiply-Subtract Single
A 59 31 114 fnmadds[.] Floating Negative Multiply-Add Single
DS 62 0 43 std Store Doubleword
DS 62 1 43 stdu Store Doubleword with Update
X 63 0 119 fcmpu Floating Compare Unordered
X 63 12 115 frsp[.] Floating Round to Single-Precision
X 63 14 117 fctiw[.] Floating Convert To Integer Word
X 63 15 117 fctiwz[.] Floating Convert To Integer Word with round toward Zero
A 63 18 112 fdiv[.] Floating Divide
A 63 20 111 fsub[.] Floating Subtract
A 63 21 111 fadd[.] Floating Add
A 63 22 125 fsqrt[.] Floating Square Root
A 63 23 126 fsel[.] Floating Select
A 63 24 125 fre[.] Floating Reciprocal Estimate
A 63 25 112 fmul[.] Floating Multiply
A 63 26 126 frsqrte[.] Floating Reciprocal Square Root Estimate
A 63 28 113 fmsub[.] Floating Multiply-Subtract
A 63 29 113 fmadd[.] Floating Multiply-Add
A 63 30 114 fnmsub[.] Floating Negative Multiply-Subtract
A 63 31 114 fnmadd[.] Floating Negative Multiply-Add
X 63 32 119 fcmpo Floating Compare Ordered
X 63 38 122 mtfsb1[.] Move To FPSCR Bit 1
X 63 40 110 fneg[.] Floating Negate
X 63 64 120 mcrfs Move to Condition Register from FPSCR
X 63 70 122 mtfsb0[.] Move To FPSCR Bit 0
X 63 72 110 fmr[.] Floating Move Register
X 63 134 121 mtfsfi[.] Move To FPSCR Field Immediate
X 63 136 110 fnabs[.] Floating Negative Absolute Value
    }
}
*/
