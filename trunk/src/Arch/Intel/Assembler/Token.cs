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

using System;

namespace Decompiler.Arch.Intel.Assembler
{
	public enum Token
	{
		ERR, EOFile, EOL, 
		ID, COLON, COMMA, BRA, KET, PLUS, MINUS, TIMES,
		INTEGER, REGISTER, STRINGLITERAL,
		LPAREN, RPAREN, EQUALS,

		PROC, ENDP, i386, i386p, i86, TEXT, DATA,
		STRUCT, DB, DW, DD, ENDS, SHORT, LONG, 
		BYTE, WORD, DWORD, QWORD, PTR, DUP,
		OFFSET, IMPORT, TITLE, INCLUDE, INCLUDELIB, 
		IF, ELSE, ENDIF,
		MODEL, SEGMENT, GROUP,  ASSUME, PUBLIC, EXTRN,
		COMM,

		MOV, MOVSX, MOVZX, LEA, LDS, LES, LGS, LFS, LSS,
		ADD, SUB, CMP, XOR, OR, AND, ADC, SBB, TEST,
		MUL, IMUL, DIV, IDIV,
		INC, DEC, NEG, NOT,
		SHR, SHL, SAR, SHRD, SHLD,

		PUSH, POP,
		CALL, RET, INT,
		ENTER, LEAVE,
		JMP,
		JZ, JNZ, JA, JBE, JC, JCXZ, JNC, JNS, JL, JLE, JG, JGE, JS, JO, JNO, LOOP, LOOPE, LOOPNE,
		SETNZ, SETZ,
		IN, OUT,			
		CMPSB, CMPSW, MOVSB, MOVSW, LODSB, LODSW, LODSD, SCASB, SCASW, STOSB, STOSW, REP,
		RCL, RCR, ROL, ROR,
		CWD, CDQ,
		STC, CLC, CMC, STI, CLI,
		BT, BSR,

		ST, FADD, FADDP, FCOM, FCOMP, FCOMPP, FSUB, FSUBR, FSUBP, FSUBRP,
		FMUL, FMULP, FDIV, FDIVR, FDIVP, FDIVRP,
		FLD, FLD1, FLDZ, FILD, FISTP, FST, FSTSW, FIST,  FSTP, 
	}
}
