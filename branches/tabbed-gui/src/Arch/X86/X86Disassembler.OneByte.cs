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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.Arch.X86
{
    public partial class X86Disassembler
    {
        private static OpRec[] CreateOnebyteOprecs()
        {
            return new OpRec[] { 
				// 00
				new SingleByteOpRec(Opcode.add, "Eb,Gb"),
				new SingleByteOpRec(Opcode.add, "Ev,Gv"),
				new SingleByteOpRec(Opcode.add, "Gb,Eb"),
				new SingleByteOpRec(Opcode.add, "Gv,Ev"),
				new SingleByteOpRec(Opcode.add, "ab,Ib"),
				new SingleByteOpRec(Opcode.add, "av,Iv"),
				new SingleByteOpRec(Opcode.push, "s0"),
				new SingleByteOpRec(Opcode.pop, "s0"),

				new SingleByteOpRec(Opcode.or, "Eb,Gb"),
				new SingleByteOpRec(Opcode.or, "Ev,Gv"),
				new SingleByteOpRec(Opcode.or, "Gb,Eb"),
				new SingleByteOpRec(Opcode.or, "Gv,Ev"),
				new SingleByteOpRec(Opcode.or, "ab,Ib"),
				new SingleByteOpRec(Opcode.or, "av,Iv"),
				new SingleByteOpRec(Opcode.push, "s1"),
				new TwoByteOpRec(),

				// 10
				new SingleByteOpRec(Opcode.adc, "Eb,Gb"),
				new SingleByteOpRec(Opcode.adc, "Ev,Gv"),
				new SingleByteOpRec(Opcode.adc, "Gb,Eb"),
				new SingleByteOpRec(Opcode.adc, "Gv,Ev"),
				new SingleByteOpRec(Opcode.adc, "ab,Ib"),
				new SingleByteOpRec(Opcode.adc, "av,Iv"),
				new SingleByteOpRec(Opcode.push, "s2"),
				new SingleByteOpRec(Opcode.pop, "s2"),

				new SingleByteOpRec(Opcode.sbb, "Eb,Gb"),
				new SingleByteOpRec(Opcode.sbb, "Ev,Gv"),
				new SingleByteOpRec(Opcode.sbb, "Gb,Eb"),
				new SingleByteOpRec(Opcode.sbb, "Gv,Ev"),
				new SingleByteOpRec(Opcode.sbb, "ab,Ib"),
				new SingleByteOpRec(Opcode.sbb, "av,Iv"),
				new SingleByteOpRec(Opcode.push, "s3"),
				new SingleByteOpRec(Opcode.pop, "s3"),

				// 20
				new SingleByteOpRec(Opcode.and, "Eb,Gb"), 
				new SingleByteOpRec(Opcode.and, "Ev,Gv"),
				new SingleByteOpRec(Opcode.and, "Gb,Eb"),
				new SingleByteOpRec(Opcode.and, "Gv,Ev"),
				new SingleByteOpRec(Opcode.and, "ab,Ib"),
				new SingleByteOpRec(Opcode.and, "av,Iv"),
				new SegmentOverrideOprec(0),
				new SingleByteOpRec(Opcode.daa),

				new SingleByteOpRec(Opcode.sub, "Eb,Gb"),
				new SingleByteOpRec(Opcode.sub, "Ev,Gv"),
				new SingleByteOpRec(Opcode.sub, "Gb,Eb"),
				new SingleByteOpRec(Opcode.sub, "Gv,Ev"),
				new SingleByteOpRec(Opcode.sub, "ab,Ib"),
				new SingleByteOpRec(Opcode.sub, "av,Iv"),
                new SegmentOverrideOprec(1),
				new SingleByteOpRec(Opcode.das),

				// 30
				new SingleByteOpRec(Opcode.xor, "Eb,Gb"),
				new SingleByteOpRec(Opcode.xor, "Ev,Gv"),
				new SingleByteOpRec(Opcode.xor, "Gb,Eb"),
				new SingleByteOpRec(Opcode.xor, "Gv,Ev"),
				new SingleByteOpRec(Opcode.xor, "ab,Ib"),
				new SingleByteOpRec(Opcode.xor, "av,Iv"),
                new SegmentOverrideOprec(2),
				new SingleByteOpRec(Opcode.aaa),

				new SingleByteOpRec(Opcode.cmp, "Eb,Gb"),
				new SingleByteOpRec(Opcode.cmp, "Ev,Gv"),
				new SingleByteOpRec(Opcode.cmp, "Gb,Eb"),
				new SingleByteOpRec(Opcode.cmp, "Gv,Ev"),
				new SingleByteOpRec(Opcode.cmp, "ab,Ib"),
				new SingleByteOpRec(Opcode.cmp, "av,Iv"),
                new SegmentOverrideOprec(3),
				new SingleByteOpRec(Opcode.aas),

				// 40
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),
				new Rex_SingleByteOpRec(Opcode.inc, "rv"),

				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),
				new Rex_SingleByteOpRec(Opcode.dec, "rv"),

				// 50
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),
				new SingleByteOpRec(Opcode.push, "rv"),

				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),
				new SingleByteOpRec(Opcode.pop, "rv"),

				// 60
				new SingleByteOpRec(Opcode.pusha),
				new SingleByteOpRec(Opcode.popa),
				new SingleByteOpRec(Opcode.bound, "Gv,Mv"),
				new SingleByteOpRec(Opcode.arpl, "Ew,rw"),
				new SegmentOverrideOprec(4),
				new SegmentOverrideOprec(5),
				new ChangeDataWidth(),
				new ChangeAddressWidth(),

				new SingleByteOpRec(Opcode.push, "Iv"),
				new SingleByteOpRec(Opcode.imul, "Gv,Ev,Iv"),
				new SingleByteOpRec(Opcode.push, "Ib"),
				new SingleByteOpRec(Opcode.imul, "Gv,Ev,Ib"),
				new SingleByteOpRec(Opcode.insb, "b"),
				new SingleByteOpRec(Opcode.ins,  ""),
				new SingleByteOpRec(Opcode.outsb, "b"),
				new SingleByteOpRec(Opcode.outs),

				// 70
				new SingleByteOpRec(Opcode.jo, "Jb"),
				new SingleByteOpRec(Opcode.jno, "Jb"),
				new SingleByteOpRec(Opcode.jc, "Jb"),
				new SingleByteOpRec(Opcode.jnc, "Jb"),
				new SingleByteOpRec(Opcode.jz, "Jb"),
				new SingleByteOpRec(Opcode.jnz, "Jb"),
				new SingleByteOpRec(Opcode.jbe, "Jb"),
				new SingleByteOpRec(Opcode.ja, "Jb"),

				new SingleByteOpRec(Opcode.js, "Jb"),
				new SingleByteOpRec(Opcode.jns, "Jb"),
				new SingleByteOpRec(Opcode.jpe, "Jb"),
				new SingleByteOpRec(Opcode.jpo, "Jb"),
				new SingleByteOpRec(Opcode.jl, "Jb"),
				new SingleByteOpRec(Opcode.jge, "Jb"),
				new SingleByteOpRec(Opcode.jle, "Jb"),
				new SingleByteOpRec(Opcode.jg, "Jb"),

				// 80
				new GroupOpRec(1, "Eb,Ib"),
				new GroupOpRec(1, "Ev,Iv"),
				new GroupOpRec(1, "Eb,Ib"), // invalid in 64-bit mode.
				new GroupOpRec(1, "Ev,Ib"),
				new SingleByteOpRec(Opcode.test, "Eb,Gb"),
				new SingleByteOpRec(Opcode.test, "Ev,Gv"),
				new SingleByteOpRec(Opcode.xchg, "Eb,Gb"),
				new SingleByteOpRec(Opcode.xchg, "Ev,Gv"),

				new SingleByteOpRec(Opcode.mov, "Eb,Gb"),
				new SingleByteOpRec(Opcode.mov, "Ev,Gv"),
				new SingleByteOpRec(Opcode.mov, "Gb,Eb"),
				new SingleByteOpRec(Opcode.mov, "Gv,Ev"),
				new SingleByteOpRec(Opcode.mov, "Ew,Sw"),
				new SingleByteOpRec(Opcode.lea, "Gv,Mv"),
				new SingleByteOpRec(Opcode.mov, "Sw,Ew"),
				new SingleByteOpRec(Opcode.pop, "Ev"),

				// 90
				new SingleByteOpRec(Opcode.nop),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),
				new SingleByteOpRec(Opcode.xchg, "av,rv"),

				new SingleByteOpRec(Opcode.cbw),
				new SingleByteOpRec(Opcode.cwd),
				new SingleByteOpRec(Opcode.call, "Ap"),
				new SingleByteOpRec(Opcode.wait),
				new SingleByteOpRec(Opcode.pushf),
				new SingleByteOpRec(Opcode.popf),
				new SingleByteOpRec(Opcode.sahf),
				new SingleByteOpRec(Opcode.lahf),

				// A0
				new SingleByteOpRec(Opcode.mov, "ab,Ob"),
				new SingleByteOpRec(Opcode.mov, "av,Ov"),
				new SingleByteOpRec(Opcode.mov, "Ob,ab"),
				new SingleByteOpRec(Opcode.mov, "Ov,av"),
				new SingleByteOpRec(Opcode.movsb, "b"),
				new SingleByteOpRec(Opcode.movs),
				new SingleByteOpRec(Opcode.cmpsb, "b"),
				new SingleByteOpRec(Opcode.cmps),

				new SingleByteOpRec(Opcode.test, "ab,Ib"),
				new SingleByteOpRec(Opcode.test, "av,Iv"),
				new SingleByteOpRec(Opcode.stosb, "b"),
				new SingleByteOpRec(Opcode.stos),
				new SingleByteOpRec(Opcode.lodsb, "b"),
				new SingleByteOpRec(Opcode.lods),
				new SingleByteOpRec(Opcode.scasb, "b"),
				new SingleByteOpRec(Opcode.scas),

				// B0
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),
				new SingleByteOpRec(Opcode.mov, "rb,Ib"),

				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),
				new SingleByteOpRec(Opcode.mov, "rv,Iv"),

				// C0
				new GroupOpRec(2, "Eb,Ib"),
				new GroupOpRec(2, "Ev,Ib"),
				new SingleByteOpRec(Opcode.ret,	"Iw"),
				new SingleByteOpRec(Opcode.ret),
				new SingleByteOpRec(Opcode.les,	"Gv,Mp"),
				new SingleByteOpRec(Opcode.lds,	"Gv,Mp"),
				new SingleByteOpRec(Opcode.mov,	"Eb,Ib"),
				new SingleByteOpRec(Opcode.mov,	"Ev,Iv"),

				new SingleByteOpRec(Opcode.enter, "Iw,Ib"),
				new SingleByteOpRec(Opcode.leave),
				new SingleByteOpRec(Opcode.retf,	"Iw"),
				new SingleByteOpRec(Opcode.retf,	""),
				new SingleByteOpRec(Opcode.@int,	"3"),
				new SingleByteOpRec(Opcode.@int,	"Ib"),
				new SingleByteOpRec(Opcode.into,	""),
				new SingleByteOpRec(Opcode.iret,	""),

				// D0
				new GroupOpRec(2, "Eb,1"),
				new GroupOpRec(2, "Ev,1"),
				new GroupOpRec(2, "Eb,c"),
				new GroupOpRec(2, "Ev,c"),
				new SingleByteOpRec(Opcode.aam, "Ib"),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.xlat, "b"),

				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),
				new FpuOpRec(),

				// E0
				new SingleByteOpRec(Opcode.loopne,"Jb"),
				new SingleByteOpRec(Opcode.loope, "Jb"),
				new SingleByteOpRec(Opcode.loop, "Jb"),
				new SingleByteOpRec(Opcode.jcxz, "Jb"),
				new SingleByteOpRec(Opcode.@in, "ab,Ib"),
				new SingleByteOpRec(Opcode.@in, "av,Ib"),
				new SingleByteOpRec(Opcode.@out, "Ib,ab"),
				new SingleByteOpRec(Opcode.@out, "Ib,av"),

				new SingleByteOpRec(Opcode.call, "Jv"),
				new SingleByteOpRec(Opcode.jmp, "Jv"),
				new SingleByteOpRec(Opcode.jmp, "Ap"),
				new SingleByteOpRec(Opcode.jmp, "Jb"),
				new SingleByteOpRec(Opcode.@in, "ab,dw"),
				new SingleByteOpRec(Opcode.@in, "av,dw"),
				new SingleByteOpRec(Opcode.@out, "dw,ab"),
				new SingleByteOpRec(Opcode.@out, "dw,av"),

				// F0
				new SingleByteOpRec(Opcode.@lock),
				new SingleByteOpRec(Opcode.illegal),
				new F2ByteOpRec(),
				new F3ByteOpRec(),
				new SingleByteOpRec(Opcode.hlt),
				new SingleByteOpRec(Opcode.cmc),
				new GroupOpRec(3, "Eb"),
				new GroupOpRec(3, "Ev"),

				new SingleByteOpRec(Opcode.clc),
				new SingleByteOpRec(Opcode.stc),
				new SingleByteOpRec(Opcode.cli),
				new SingleByteOpRec(Opcode.sti),
				new SingleByteOpRec(Opcode.cld),
				new SingleByteOpRec(Opcode.std),
				new GroupOpRec(4, ""),
				new GroupOpRec(5, "")
			};
        }
    }
}
