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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Decompiler.Arch.X86
{
    public partial class X86Disassembler
    {
        private static OpRec[] CreateFpuOprecs()
        {
            return new SingleByteOpRec[]  
			{
				// D8 /////////////////////////

				new SingleByteOpRec(Opcode.fadd, "Mf"),
				new SingleByteOpRec(Opcode.fmul, "Mf"),
				new SingleByteOpRec(Opcode.fcom, "Mf"),
				new SingleByteOpRec(Opcode.fcomp, "Mf"),
				new SingleByteOpRec(Opcode.fsub,  "Mf"),
				new SingleByteOpRec(Opcode.fsubr, "Mf"),
				new SingleByteOpRec(Opcode.fdiv,  "Mf"),
				new SingleByteOpRec(Opcode.fdivr, "Mf"),
				// D8 C0
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F"),

				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F"),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				// D8 D0		
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				new SingleByteOpRec(Opcode.fcomp, "f,F"),
				// D8 E0
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
				new SingleByteOpRec(Opcode.fsub, "f,F"),
						
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				new SingleByteOpRec(Opcode.fsubr, "f,F"),
				// D8 F0
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F"),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F"),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				
				// D9 ////////////////////////////////
				
				new SingleByteOpRec(Opcode.fld, "Mf"),
				new SingleByteOpRec(Opcode.illegal, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "Mf"),
				new SingleByteOpRec(Opcode.fstp, "Mf"),
				new SingleByteOpRec(Opcode.fldenv, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fldcw, "Mw"),
				new SingleByteOpRec(Opcode.fstenv, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fstcw, "Mw"),
						
				// D9 C0
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
				new SingleByteOpRec(Opcode.fld, "F"),
						
				new SingleByteOpRec(Opcode.fxch, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
				new SingleByteOpRec(Opcode.fxch, "f,F"),
						
				// D9 D0
				new SingleByteOpRec(Opcode.fnop, "", OpFlag.X),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// E0
				new SingleByteOpRec(Opcode.fchs),
				new SingleByteOpRec(Opcode.fabs, "", OpFlag.X),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.ftst),
				new SingleByteOpRec(Opcode.fxam),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.fld1),
				new SingleByteOpRec(Opcode.fldl2t, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fldl2e, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fldpi),
				new SingleByteOpRec(Opcode.fldlg2, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fldln2),
				new SingleByteOpRec(Opcode.fldz),
				new SingleByteOpRec(Opcode.illegal),
						
				// D9 F0
				new SingleByteOpRec(Opcode.f2xm1, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fyl2x, "F,f"),
				new SingleByteOpRec(Opcode.fptan, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fpatan, "F,f"),
				new SingleByteOpRec(Opcode.fxtract, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fprem1, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdecstp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fincstp, "F,f", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fprem, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fyl2xp1, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fsqrt),
				new SingleByteOpRec(Opcode.fsincos),
				new SingleByteOpRec(Opcode.frndint),
				new SingleByteOpRec(Opcode.fscale, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fsin),
				new SingleByteOpRec(Opcode.fcos),
				
				// DA //////////////
				
				new SingleByteOpRec(Opcode.fiadd, "Md"),
				new SingleByteOpRec(Opcode.fimul, "Md"),
				new SingleByteOpRec(Opcode.ficom, "Md"),
				new SingleByteOpRec(Opcode.ficomp, "Md"),
				new SingleByteOpRec(Opcode.fisub, "Md"),
				new SingleByteOpRec(Opcode.fisubr, "Md"),
				new SingleByteOpRec(Opcode.fidiv, "Md"),
				new SingleByteOpRec(Opcode.fidivr, "Md"),
				
				// DA C0 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				// DB ///////////////////////////
				
				new SingleByteOpRec(Opcode.fild, "Md"),
				new SingleByteOpRec(Opcode.illegal, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fist, "Md", OpFlag.X),
				new SingleByteOpRec(Opcode.fistp, "Md"),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.fld, "Mh"),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.fstp, "Mh", OpFlag.X),
						
				// DB C0, Conditional moves.

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.fclex), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 

				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
				new SingleByteOpRec(Opcode.illegal), 
					
				// DC ////////////////////

				new SingleByteOpRec(Opcode.fadd, "Mg"),
				new SingleByteOpRec(Opcode.fmul, "Mg"),
				new SingleByteOpRec(Opcode.fcom, "Mg"),
				new SingleByteOpRec(Opcode.fcomp, "Mg"),
				new SingleByteOpRec(Opcode.fsub, "Mg"),
				new SingleByteOpRec(Opcode.fsubr, "Mg"),
				new SingleByteOpRec(Opcode.fdiv, "Mg"),
				new SingleByteOpRec(Opcode.fdivr, "Mg"),

                // DC C0
						
				new SingleByteOpRec(Opcode.fadd, "f,F"),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fadd, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fmul, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcom, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fcomp, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsub, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubr, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdiv, "f,F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivr, "f,F", OpFlag.X),

				// DD ////////////////

				new SingleByteOpRec(Opcode.fld, "Mg"),
				new SingleByteOpRec(Opcode.illegal, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "Mg"),
				new SingleByteOpRec(Opcode.fstp, "Mg"),
				new SingleByteOpRec(Opcode.frstor, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.fsave, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fstsw, "Mw"),
						
				// DD C0

				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.ffree, "F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				// DD D0
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
				new SingleByteOpRec(Opcode.fst, "F", OpFlag.X),
						
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
				new SingleByteOpRec(Opcode.fstp, "F"),
						
				// E0
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// F0
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// DE //////////////////////////

				new SingleByteOpRec(Opcode.fiadd, "Mw"),
				new SingleByteOpRec(Opcode.fimul, "Mw"),
				new SingleByteOpRec(Opcode.ficom, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.ficomp, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fisub, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fisubr, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fidiv, "Mw"),
				new SingleByteOpRec(Opcode.fidivr, "Mw", OpFlag.X),
				
                // DE C0
				
                new SingleByteOpRec(Opcode.faddp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
				new SingleByteOpRec(Opcode.faddp, "F,f"),
						
				new SingleByteOpRec(Opcode.fmulp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
				new SingleByteOpRec(Opcode.fmulp, "F,f"),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.fcompp),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				// DE E0	
				new SingleByteOpRec(Opcode.fsubrp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
				new SingleByteOpRec(Opcode.fsubrp, "F,f"),
						
				new SingleByteOpRec(Opcode.fsubp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				new SingleByteOpRec(Opcode.fsubp, "F,f"),
				// DE F0
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
				new SingleByteOpRec(Opcode.fdivrp, "F,f"),
						
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f"),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				new SingleByteOpRec(Opcode.fdivp, "F,f", OpFlag.X),
				
				// DF //////////////////////

				new SingleByteOpRec(Opcode.fild, "Mw"),
				new SingleByteOpRec(Opcode.illegal, "", OpFlag.X),
				new SingleByteOpRec(Opcode.fist, "Mw", OpFlag.X),
				new SingleByteOpRec(Opcode.fistp, "Mw"),
				new SingleByteOpRec(Opcode.fbld, "MB", OpFlag.X),
				new SingleByteOpRec(Opcode.fild, "Mq", OpFlag.X),
				new SingleByteOpRec(Opcode.fbstp, "MB", OpFlag.X),
				new SingleByteOpRec(Opcode.fistp, "Mq"),

				// C0
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// D0
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// E0
				new SingleByteOpRec(Opcode.fstsw, "aw"),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				// F0
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
						
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
				new SingleByteOpRec(Opcode.illegal),
			};
            Debug.Assert(s_aFpOpRec.Length == 8 * 0x48);
        }
    }
}
