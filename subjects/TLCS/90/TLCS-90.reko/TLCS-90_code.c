// TLCS-90_code.c
// Generated by decompiling TLCS-90.corpus
// using Reko decompiler version 0.11.2.0.

#include "TLCS-90.h"

// 0000: void fn0000(Register byte a)
void fn0000(byte a)
{
	null = (byte *) a;
}

byte g_b0001 = 0x00; // 00000001
// 02F4: Register word16 fn02F4(Register byte a, Register uint8 c, Register ui8 b, Register Eq_n de, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn164F
word16 fn02F4(byte a, uint8 c, ui8 b, Eq_n de, byte h, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	bool C;
	cu8 a_n = a + ix->bFFFFFFE4 + (byte) C;
	ui16 a_a_n = SEQ(v22_n, ix->tFFFFFFF6) + (SEQ(b, c) ^ ix->tFFFFFFFA);
	ui8 a_n = a_n ^ ix->tFFFFFFFC;
	ui8 a_n = h + ix->bFFFFFFE5 + (byte) (a_n < 0x00) ^ ix->bFFFFFFFD;
	ix->tFFFFFFF6 = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v22_n = ix->bFFFFFFF7;
	ix->bFFFFFFF7 = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFF8 + a_n + (byte) (a_n < 0x00);
	ix->tFFFFFFF8 = a_n;
	ix->bFFFFFFF9 = ix->bFFFFFFF9 + a_n + (byte) (a_n < 0x00);
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFF8;
	Eq_n bc_n = ix->tFFFFFFF6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		cu8 b_n = SLICE(bc_n, byte, 8);
		byte c_n = (byte) bc_n;
		hl_n = hl_n * 0x02 + (word16) (b_n < 0x00);
	}
	Eq_n a_n = (word16) ix->tFFFFFFDE + c_n;
	Eq_n de_n;
	Eq_n hl_n;
	Eq_n ix_n;
	word16 bc_n = fn034E(SEQ(hl_n, b_n, c_n), a_n, de, ix, wArg24, out de_n, out hl_n, out ix_n);
	deOut = de_n;
	hlOut = hl_n;
	ixOut = ix_n;
	return bc_n;
}

// 034E: Register word16 fn034E(Sequence uint32 h_l_b_c, Register Eq_n a, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn02F4
word16 fn034E(uint32 h_l_b_c, Eq_n a, Eq_n de, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	ix->tFFFFFFFA = a;
	Eq_n de_n;
	Eq_n hl_n;
	Eq_n ix_n;
	word16 bc_n = fn03B2(h_l_b_c, a, de, ix, wArg24, out de_n, out hl_n, out ix_n);
	deOut = de_n;
	hlOut = hl_n;
	ixOut = ix_n;
	return bc_n;
}

// 0350: Register Eq_n fn0350(Register uint8 b, Register cu8 l, Register byte h, Register (ptr16 Eq_n) ix, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn03B2
//      fn0914
Eq_n fn0350(uint8 b, cu8 l, byte h, struct Eq_n * ix, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	bool C;
	byte c;
	Eq_n a;
	Eq_n de;
	uint8 a_n = b + ix->bFFFFFFDF + (byte) C;
	ix->bFFFFFFFB = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFE0 + l + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = a_n;
	ix->bFFFFFFFD = h + ix->bFFFFFFE1 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v17_n, ix->tFFFFFFF6) + SEQ(v18_n, ix->bFFFFFFEE);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem24[ix + -8:byte] + Mem24[ix + -16:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v17_n = ix->bFFFFFFF7;
	uint8 v18_n = ix->bFFFFFFEF;
	byte a_n = ix->bFFFFFFF9 + ix->bFFFFFFF1 + (byte) (a_n < 0x00);
	ix->tFFFFFFFA = ix->tFFFFFFFA ^ (byte) a_a_n;
	ix->bFFFFFFFB = ix->bFFFFFFFB ^ a_n;
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	// Failed to bind call argument.
	// Please report this issue at https://github.com/uxmal/reko
	Eq_n stackArg36 = <invalid>;
	Eq_n ix_n;
	word16 de_n;
	word16 hl_n;
	fn03B2(SEQ(h, l, b, c), a, de, ix, stackArg36, out de_n, out hl_n, out ix_n);
	deOut.u0 = <invalid>;
	hlOut.u0 = <invalid>;
	ixOut = ix_n;
	return <invalid>;
}

// 039D: void fn039D(Register byte a, Register Eq_n de, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24)
void fn039D(byte a, Eq_n de, byte h, struct Eq_n * ix, Eq_n wArg24)
{
	ix->bFFFFFFFD = a ^ h;
	Eq_n v12_n = ix->tFFFFFFF6;
	uint8 v14_n = ix->bFFFFFFF7;
	Eq_n v16_n = ix->tFFFFFFF8;
	byte v18_n = ix->bFFFFFFF9;
	word16 de_n;
	word16 hl_n;
	word16 ix_n;
	fn03B2(SEQ(v18_n, v16_n, v14_n, v12_n), 0x05, de, ix, wArg24, out de_n, out hl_n, out ix_n);
}

// 03AA: void fn03AA()
// Called from:
//      fn22A6
//      fn3E2D
void fn03AA()
{
}

// 03B2: Register word16 fn03B2(Sequence uint32 h_l_b_c, Register Eq_n a, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn034E
//      fn0350
//      fn039D
word16 fn03B2(uint32 h_l_b_c, Eq_n a, Eq_n de, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	ptr32 fp;
	uint32 h_l_b_c_n = h_l_b_c;
	do
	{
		uint32 v69_n = h_l_b_c_n >> 1;
		uint24 v68_n = SLICE(v69_n, uint24, 8);
		uint16 v67_n = SLICE(v68_n, uint16, 8);
		byte h_n = SLICE(v67_n, byte, 8);
		byte l_n = (byte) v67_n;
		ui8 b_n = (byte) v68_n;
		uint8 c_n = (byte) v69_n;
		--a;
		h_l_b_c_n = v69_n;
	} while (a != 0x00);
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v17_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = (word16) ix->tFFFFFFDC + l_n + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v27_n, ix->tFFFFFFF2) + (a_a_n ^ ix->tFFFFFFFA);
	uint8 v17_n = ix->bFFFFFFDB;
	ui8 a_n = a_n ^ ix->tFFFFFFFC;
	ui8 a_n = h_n + ix->bFFFFFFDD + (byte) (a_n < 0x00) ^ ix->bFFFFFFFD;
	ix->tFFFFFFF2 = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v27_n = ix->bFFFFFFF3;
	ix->bFFFFFFF3 = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFF4 + a_n + (byte) (a_n < 0x00);
	ix->tFFFFFFF4 = a_n;
	ix->bFFFFFFF5 = ix->bFFFFFFF5 + a_n + (byte) (a_n < 0x00);
	uint8 v30_n = ix->bFFFFFFEA;
	uint8 a_n = SLICE(SEQ(ix->bFFFFFFEB, v30_n) + ~0x00, byte, 8);
	cu8 a_n = ix->bFFFFFFEC + ~0x00 + (byte) (a_n < 0x00);
	byte a_n = ix->bFFFFFFED + ~0x00 + (byte) (a_n < 0x00);
	ix->bFFFFFFEA = v30_n + ~0x00;
	ix->bFFFFFFEB = a_n;
	ix->bFFFFFFEC = a_n;
	ix->bFFFFFFED = a_n;
	if ((a_n | a_n | a_n | v30_n + ~0x00) != 0x00)
	{
		Eq_n hl_n;
		Eq_n ix_n;
		Eq_n de_n;
		word16 bc_n = fn0350(b, l, SLICE(hl_n, byte, 8), ix, out de_n, out hl_n, out ix_n);
		deOut = de_n;
		hlOut = hl_n;
		ixOut = ix_n;
		return bc_n;
	}
	else
	{
		Eq_n hl_n = fp + 0x1C;
		word16 bc_n;
		for (bc_n = 0x04; bc_n != 0x00; --bc_n)
		{
			*de = *hl_n;
			hl_n = (word32) hl_n + 1;
			de = (word32) de + 1;
		}
		Eq_n de_n = wArg24;
		Eq_n hl_n = fp + 0x18;
		word16 bc_n;
		for (bc_n = 0x04; bc_n != 0x00; --bc_n)
		{
			*de_n = *hl_n;
			hl_n = (word32) hl_n + 1;
			++de_n;
		}
		Eq_n ix_n = ix->t0000;
		deOut = de_n;
		hlOut = hl_n;
		ixOut = ix_n;
		return bc_n;
	}
}

// 04EE: void fn04EE(Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn04EE(Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	ix->bFFFFFFDB = 55;
	ix->tFFFFFFDC.u0 = ~0x10;
	ix->bFFFFFFDD = 0xC6;
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFE8;
	Eq_n bc_n = ix->tFFFFFFE6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = (word16) bc_n.u1 + SEQ(v23_n, ix->tFFFFFFF6);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v23_n = ix->bFFFFFFF7;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (word16) ix->tFFFFFFF8 + l_n + (byte) (a_n < 0x00);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = h_n + ix->bFFFFFFF9 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v28_n, ix->tFFFFFFE6) + SEQ(v29_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem65[ix + -24:byte] + Mem65[ix + -36:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v28_n = ix->bFFFFFFE7;
	uint8 v29_n = ix->bFFFFFFDB;
	byte a_n = ix->bFFFFFFE9 + ix->bFFFFFFDD + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	byte a_n;
	uint32 h_l_b_c_n = SEQ(ix->bFFFFFFE9, ix->tFFFFFFE8, ix->bFFFFFFE7, ix->tFFFFFFE6);
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		uint32 v121_n = h_l_b_c_n >> 1;
		uint24 v120_n = SLICE(v121_n, uint24, 8);
		uint16 v119_n = SLICE(v120_n, uint16, 8);
		byte h_n = SLICE(v119_n, byte, 8);
		byte l_n = (byte) v119_n;
		ui8 b_n = (byte) v120_n;
		uint8 c_n = (byte) v121_n;
		h_l_b_c_n = v121_n;
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v45_n, ix->bFFFFFFEA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = l_n + ix->bFFFFFFEC + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v53_n, ix->tFFFFFFDE) - (a_a_n ^ ix->tFFFFFFFC);
	uint8 v45_n = ix->bFFFFFFEB;
	ui8 a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h_n + ix->bFFFFFFED + (byte) (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v53_n = ix->bFFFFFFDF;
	ix->bFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (byte) (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (byte) (a_n < 0x00);
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFE0;
	Eq_n bc_n = ix->tFFFFFFDE;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = bc_n + SEQ(v61_n, Mem217[ix + -18:byte]);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v61_n = ix->bFFFFFFEF;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (word16) ix->tFFFFFFF0 + l_n + (byte) (a_n < 0x00);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = h_n + ix->bFFFFFFF1 + (byte) (a_n < 0x00);
	uint8 a_n = (word16) ix->tFFFFFFDE + ix->bFFFFFFDA;
	uint8 v66_n = ix->bFFFFFFDF;
	fn060E(v66_n, a_n, de, ix, wArg20);
}

// 0607: void fn0607(Register byte a, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0607(byte a, Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	uint8 a_n = a + ix->bFFFFFFDA;
	uint8 v9_n = ix->bFFFFFFDF;
	fn060E(v9_n, a_n, de, ix, wArg20);
}

// 060E: void fn060E(Register uint8 a, Register uint8 c, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn04EE
//      fn0607
//      fn0DFC
//      fn164F
void fn060E(uint8 a, uint8 c, Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	ptr32 fp;
	bool C;
	do
	{
		cu8 a_n = a + ix->bFFFFFFDB + (byte) C;
		byte a_n = Mem4[ix + -32:byte] + Mem4[ix + -36:byte] + CONVERT(a_n <u 0x00, bool, byte);
		byte a_n = ix->bFFFFFFE1 + ix->bFFFFFFDD + (byte) (a_n < 0x00);
		ix->tFFFFFFFC = ix->tFFFFFFFC ^ c;
		ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
		ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
		ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
		byte a_n;
		uint32 h_l_b_c_n = SEQ(ix->bFFFFFFE1, ix->tFFFFFFE0, ix->bFFFFFFDF, ix->tFFFFFFDE);
		for (a_n = 0x05; a_n != 0x00; --a_n)
		{
			uint32 v68_n = h_l_b_c_n >> 1;
			uint24 v67_n = SLICE(v68_n, uint24, 8);
			uint16 v66_n = SLICE(v67_n, uint16, 8);
			byte h_n = SLICE(v66_n, byte, 8);
			byte l_n = (byte) v66_n;
			ui8 b_n = (byte) v67_n;
			uint8 c_n = (byte) v68_n;
			h_l_b_c_n = v68_n;
		}
		ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v33_n, ix->tFFFFFFF2);
		cu8 a_n = SLICE(a_a_n, byte, 8);
		cu8 a_n = (word16) ix->tFFFFFFF4 + l_n + (byte) (a_n < 0x00);
		ui16 a_a_n = SEQ(v41_n, ix->tFFFFFFE6) - (a_a_n ^ ix->tFFFFFFFC);
		uint8 v33_n = ix->bFFFFFFF3;
		ui8 a_n = a_n ^ ix->bFFFFFFFE;
		ui8 a_n = h_n + ix->bFFFFFFF5 + (byte) (a_n < 0x00) ^ ix->bFFFFFFFF;
		ix->tFFFFFFE6 = (byte) a_a_n;
		uint8 a_n = SLICE(a_a_n, byte, 8);
		uint8 v41_n = ix->bFFFFFFE7;
		ix->bFFFFFFE7 = a_n;
		Eq_n a_n = ix->tFFFFFFE8 - a_n - (byte) (a_n < 0x00);
		ix->tFFFFFFE8 = a_n;
		ix->bFFFFFFE9 = ix->bFFFFFFE9 - a_n - (byte) (a_n < 0x00);
		uint8 v44_n = ix->bFFFFFFDA;
		ix->bFFFFFFDA = v44_n + 0x47;
		uint8 a_n = SLICE(SEQ(ix->bFFFFFFDB, v44_n) + 34375, byte, 8);
		ix->bFFFFFFDB = a_n;
		Eq_n a_n = (word16) ix->tFFFFFFDC + 200 + (byte) (a_n < 0x00);
		ix->tFFFFFFDC = a_n;
		ix->bFFFFFFDD = ix->bFFFFFFDD + 0x61 + (byte) (a_n < 0x00);
		uint8 v48_n = ix->bFFFFFFE2;
		uint8 a_n = SLICE(SEQ(ix->bFFFFFFE3, v48_n) + ~0x00, byte, 8);
		cu8 a_n = ix->bFFFFFFE4 + ~0x00 + (byte) (a_n < 0x00);
		byte a_n = ix->bFFFFFFE5 + ~0x00 + (byte) (a_n < 0x00);
		ix->bFFFFFFE2 = v48_n + ~0x00;
		ix->bFFFFFFE3 = a_n;
		ix->bFFFFFFE4 = a_n;
		ix->bFFFFFFE5 = a_n;
		c = v48_n + ~0x00;
		a = a_n | a_n | a_n | v48_n + ~0x00;
		C = false;
	} while (a != 0x00);
	Eq_n hl_n = fp + 0x0C;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de = *hl_n;
		hl_n = (word32) hl_n + 1;
		de = (word32) de + 1;
	}
	Eq_n de_n = wArg20;
	Eq_n hl_n = fp + 0x04;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		hl_n = (word32) hl_n + 1;
		de_n = (word32) de_n + 1;
	}
}

// 0805: void fn0805()
// Called from:
//      fn1BA4
void fn0805()
{
	__disable_interrupts();
	fn0823();
	fn0822();
	__halt();
}

// 0822: void fn0822()
// Called from:
//      fn0805
void fn0822()
{
	fn0823();
}

// 0823: void fn0823()
// Called from:
//      fn0805
//      fn0822
void fn0823()
{
}

// 0914: void fn0914(Register word16 bc, Register (ptr32 byte) de, Register (ptr32 byte) hl, Register (ptr16 Eq_n) ix, Stack word16 wArg00, Stack Eq_n wArg02, Stack Eq_n wArg28)
void fn0914(word16 bc, byte * de, byte * hl, struct Eq_n * ix, word16 wArg00, Eq_n wArg02, Eq_n wArg28)
{
	ptr32 fp;
	do
	{
		*de = *hl;
		++hl;
		++de;
		--bc;
	} while (bc != 0x00);
	Eq_n de_n = fp + 0x08;
	Eq_n hl_n = wArg00 + 0x08;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		++hl_n;
		de_n = (word32) de_n + 1;
	}
	Eq_n de_n = fp + 0x04;
	Eq_n hl_n = wArg00 + 0x0C;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		++hl_n;
		de_n = (word32) de_n + 1;
	}
	ix->bFFFFFFEA = 0x20;
	ix->bFFFFFFEB = 0x00;
	ix->bFFFFFFEC = 0x00;
	ix->bFFFFFFED = 0x00;
	ix->bFFFFFFEE = 0x00;
	ix->bFFFFFFEF = 0x00;
	ix->tFFFFFFF0.u0 = 0x00;
	ix->bFFFFFFF1 = 0x00;
	uint8 v22_n = ix->bFFFFFFEE;
	ix->bFFFFFFEE = v22_n + ~0x46;
	uint8 a_n = SLICE(SEQ(ix->bFFFFFFEF, v22_n) + 31161, byte, 8);
	ix->bFFFFFFEF = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFF0 + 55 + (byte) (a_n < 0x00);
	ix->tFFFFFFF0 = a_n;
	ix->bFFFFFFF1 = ix->bFFFFFFF1 + ~0x61 + (byte) (a_n < 0x00);
	Eq_n de_n = wArg02;
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFF4;
	Eq_n bc_n = ix->tFFFFFFF2;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = (word16) bc_n.u1 + SEQ(v39_n, ix->tFFFFFFE6);
	ix->tFFFFFFFA = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v39_n = ix->bFFFFFFE7;
	ix->bFFFFFFFB = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFE8 + l_n + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = a_n;
	ix->bFFFFFFFD = h_n + ix->bFFFFFFE9 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v44_n, ix->tFFFFFFF2) + SEQ(v45_n, ix->bFFFFFFEE);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem170[ix + -0x0C:byte] + Mem170[ix + -16:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v44_n = ix->bFFFFFFF3;
	uint8 v45_n = ix->bFFFFFFEF;
	byte a_n = ix->bFFFFFFF5 + ix->bFFFFFFF1 + (byte) (a_n < 0x00);
	ix->tFFFFFFFA = ix->tFFFFFFFA ^ (byte) a_a_n;
	ix->bFFFFFFFB = ix->bFFFFFFFB ^ a_n;
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	byte a_n;
	uint32 h_l_b_c_n = SEQ(ix->bFFFFFFF5, ix->tFFFFFFF4, ix->bFFFFFFF3, ix->tFFFFFFF2);
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		uint32 v130_n = h_l_b_c_n >> 1;
		uint24 v129_n = SLICE(v130_n, uint24, 8);
		uint16 v128_n = SLICE(v129_n, uint16, 8);
		byte h_n = SLICE(v128_n, byte, 8);
		byte l_n = (byte) v128_n;
		ui8 b_n = (byte) v129_n;
		uint8 c_n = (byte) v130_n;
		h_l_b_c_n = v130_n;
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v59_n, ix->bFFFFFFE2);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = l_n + ix->bFFFFFFE4 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v67_n, ix->tFFFFFFF6) + (a_a_n ^ ix->tFFFFFFFA);
	uint8 v59_n = ix->bFFFFFFE3;
	ui8 a_n = a_n ^ ix->tFFFFFFFC;
	ui8 a_n = h_n + ix->bFFFFFFE5 + (byte) (a_n < 0x00) ^ ix->bFFFFFFFD;
	ix->tFFFFFFF6 = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v67_n = ix->bFFFFFFF7;
	ix->bFFFFFFF7 = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFF8 + a_n + (byte) (a_n < 0x00);
	ix->tFFFFFFF8 = a_n;
	ix->bFFFFFFF9 = ix->bFFFFFFF9 + a_n + (byte) (a_n < 0x00);
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFF8;
	Eq_n bc_n = ix->tFFFFFFF6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = bc_n + SEQ(v75_n, Mem322[ix + -0x0022:byte]);
	ix->tFFFFFFFA = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v75_n = ix->bFFFFFFDF;
	ix->bFFFFFFFB = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFE0 + l_n + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = a_n;
	ix->bFFFFFFFD = h_n + ix->bFFFFFFE1 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v80_n, ix->tFFFFFFF6) + SEQ(v81_n, ix->bFFFFFFEE);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem375[ix + -8:byte] + Mem375[ix + -16:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v80_n = ix->bFFFFFFF7;
	uint8 v81_n = ix->bFFFFFFEF;
	byte a_n = ix->bFFFFFFF9 + ix->bFFFFFFF1 + (byte) (a_n < 0x00);
	ix->tFFFFFFFA = ix->tFFFFFFFA ^ (byte) a_a_n;
	ix->bFFFFFFFB = ix->bFFFFFFFB ^ a_n;
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	byte a_n;
	uint32 h_l_b_c_n = SEQ(ix->bFFFFFFF9, ix->tFFFFFFF8, ix->bFFFFFFF7, ix->tFFFFFFF6);
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		uint32 v136_n = h_l_b_c_n >> 1;
		uint24 v135_n = SLICE(v136_n, uint24, 8);
		uint16 v134_n = SLICE(v135_n, uint16, 8);
		byte h_n = SLICE(v134_n, byte, 8);
		byte l_n = (byte) v134_n;
		ui8 b_n = (byte) v135_n;
		uint8 c_n = (byte) v136_n;
		h_l_b_c_n = v136_n;
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v95_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = (word16) ix->tFFFFFFDC + l_n + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v103_n, ix->tFFFFFFF2) + (a_a_n ^ ix->tFFFFFFFA);
	uint8 v95_n = ix->bFFFFFFDB;
	ui8 a_n = a_n ^ ix->tFFFFFFFC;
	ui8 a_n = h_n + ix->bFFFFFFDD + (byte) (a_n < 0x00) ^ ix->bFFFFFFFD;
	ix->tFFFFFFF2 = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v103_n = ix->bFFFFFFF3;
	ix->bFFFFFFF3 = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFF4 + a_n + (byte) (a_n < 0x00);
	ix->tFFFFFFF4 = a_n;
	ix->bFFFFFFF5 = ix->bFFFFFFF5 + a_n + (byte) (a_n < 0x00);
	uint8 v106_n = ix->bFFFFFFEA;
	uint8 a_n = SLICE(SEQ(ix->bFFFFFFEB, v106_n) + ~0x00, byte, 8);
	cu8 a_n = ix->bFFFFFFEC + ~0x00 + (byte) (a_n < 0x00);
	byte a_n = ix->bFFFFFFED + ~0x00 + (byte) (a_n < 0x00);
	ix->bFFFFFFEA = v106_n + ~0x00;
	ix->bFFFFFFEB = a_n;
	ix->bFFFFFFEC = a_n;
	ix->bFFFFFFED = a_n;
	if ((a_n | a_n | a_n | v106_n + ~0x00) != 0x00)
	{
		word16 ix_n;
		word16 de_n;
		word16 hl_n;
		fn0350(a_n, a_n, a_n, ix, out de_n, out hl_n, out ix_n);
	}
	else
	{
		Eq_n hl_n = fp + 0x20;
		word16 bc_n;
		for (bc_n = 0x04; bc_n != 0x00; --bc_n)
		{
			*de_n = *hl_n;
			hl_n = (word32) hl_n + 1;
			de_n = (word32) de_n + 1;
		}
		Eq_n de_n = wArg28;
		Eq_n hl_n = fp + 0x1C;
		word16 bc_n;
		for (bc_n = 0x04; bc_n != 0x00; --bc_n)
		{
			*de_n = *hl_n;
			hl_n = (word32) hl_n + 1;
			de_n = (word32) de_n + 1;
		}
	}
}

// 0BD0: void fn0BD0(Register word16 bc, Register (ptr32 byte) de, Register (ptr32 byte) hl, Register (ptr16 Eq_n) ix, Stack word16 wArg00, Stack Eq_n wArg02, Stack Eq_n wArg24)
void fn0BD0(word16 bc, byte * de, byte * hl, struct Eq_n * ix, word16 wArg00, Eq_n wArg02, Eq_n wArg24)
{
	ptr32 fp;
	do
	{
		*de = *hl;
		++hl;
		++de;
		--bc;
	} while (bc != 0x00);
	Eq_n de_n = fp + 0x20;
	Eq_n hl_n = wArg00 + 0x08;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		++hl_n;
		de_n = (word32) de_n + 1;
	}
	Eq_n de_n = fp + 0x14;
	Eq_n hl_n = wArg00 + 0x0C;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		++hl_n;
		de_n = (word32) de_n + 1;
	}
	ix->bFFFFFFE2 = 0x20;
	ix->bFFFFFFE3 = 0x00;
	ix->bFFFFFFE4 = 0x00;
	ix->bFFFFFFE5 = 0x00;
	ix->bFFFFFFDA = 0x20;
	ix->bFFFFFFDB = 55;
	ix->tFFFFFFDC.u0 = ~0x10;
	ix->bFFFFFFDD = 0xC6;
	fn0C1D(wArg02, ix, wArg24);
}

// 0C1D: void fn0C1D(Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg22)
// Called from:
//      fn0BD0
void fn0C1D(Eq_n de, struct Eq_n * ix, Eq_n wArg22)
{
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFE8;
	Eq_n bc_n = ix->tFFFFFFE6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	fn0C35(bc_n, de, l_n, h_n, ix, wArg22);
}

// 0C35: void fn0C35(Register Eq_n bc, Register Eq_n de, Register byte l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C1D
//      fn164F
//      fn1873
void fn0C35(Eq_n bc, Eq_n de, byte l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	ui16 a_a_n = (word16) bc + SEQ(v10_n, ix->tFFFFFFF6);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v10_n = ix->bFFFFFFF7;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (word16) ix->tFFFFFFF8 + l + (byte) (a_n < 0x00);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = h + ix->bFFFFFFF9 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v18_n, ix->tFFFFFFE6) + SEQ(v19_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem30[ix + -24:byte] + Mem30[ix + -36:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v18_n = ix->bFFFFFFE7;
	uint8 v19_n = ix->bFFFFFFDB;
	byte a_n = ix->bFFFFFFE9 + ix->bFFFFFFDD + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	Eq_n v32_n = ix->tFFFFFFE6;
	uint8 v33_n = ix->bFFFFFFE7;
	Eq_n v34_n = ix->tFFFFFFE8;
	byte v35_n = ix->bFFFFFFE9;
	fn0C9D(SEQ(v35_n, v34_n, v33_n, v32_n), 0x05, de, ix, wArg20);
}

// 0C39: void fn0C39(Register Eq_n a, Register byte b, Register Eq_n de, Register byte l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0C39(Eq_n a, byte b, Eq_n de, byte l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	bool C;
	ix->tFFFFFFFC = a;
	uint8 a_n = b + ix->bFFFFFFF7 + (byte) C;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (word16) ix->tFFFFFFF8 + l + (byte) (a_n < 0x00);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = h + ix->bFFFFFFF9 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v17_n, ix->tFFFFFFE6) + SEQ(v18_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem25[ix + -24:byte] + Mem25[ix + -36:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v17_n = ix->bFFFFFFE7;
	uint8 v18_n = ix->bFFFFFFDB;
	byte a_n = ix->bFFFFFFE9 + ix->bFFFFFFDD + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	uint8 v28_n = ix->bFFFFFFFE;
	fn0C80(v28_n, de, a_n, a_n, ix, wArg20);
}

// 0C80: void fn0C80(Register uint8 a, Register Eq_n de, Register cu8 l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C39
void fn0C80(uint8 a, Eq_n de, cu8 l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	ix->bFFFFFFFE = a ^ l;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ h;
	Eq_n v14_n = ix->tFFFFFFE6;
	uint8 v16_n = ix->bFFFFFFE7;
	Eq_n v18_n = ix->tFFFFFFE8;
	byte v19_n = ix->bFFFFFFE9;
	fn0C9D(SEQ(v19_n, v18_n, v16_n, v14_n), 0x05, de, ix, wArg20);
}

// 0C9D: void fn0C9D(Sequence uint32 h_l_b_c, Register byte a, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C35
//      fn0C80
void fn0C9D(uint32 h_l_b_c, byte a, Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	uint32 h_l_b_c_n = h_l_b_c;
	do
	{
		uint32 v46_n = h_l_b_c_n >> 1;
		uint24 v45_n = SLICE(v46_n, uint24, 8);
		uint16 v44_n = SLICE(v45_n, uint16, 8);
		byte h_n = SLICE(v44_n, byte, 8);
		byte l_n = (byte) v44_n;
		ui8 b_n = (byte) v45_n;
		uint8 c_n = (byte) v46_n;
		--a;
		h_l_b_c_n = v46_n;
	} while (a != 0x00);
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v17_n, ix->bFFFFFFEA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = l_n + ix->bFFFFFFEC + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v27_n, ix->tFFFFFFDE) - (a_a_n ^ ix->tFFFFFFFC);
	uint8 v17_n = ix->bFFFFFFEB;
	ui8 a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h_n + ix->bFFFFFFED + (byte) (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v27_n = ix->bFFFFFFDF;
	ix->bFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (byte) (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (byte) (a_n < 0x00);
	Eq_n bc_n = ix->tFFFFFFDE;
	Eq_n hl_n = ix->tFFFFFFE0;
	fn0D00(0x04, bc_n, de, hl_n, ix, wArg20);
}

// 0CB7: void fn0CB7(Register uint8 c, Register ui8 b, Register Eq_n de, Register byte h, Register byte l, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0CB7(uint8 c, ui8 b, Eq_n de, byte h, byte l, struct Eq_n * ix, Eq_n wArg20)
{
	bool C;
	ui16 a_a_n = SEQ(v21_n, ix->tFFFFFFDE) - (SEQ(b, c) ^ ix->tFFFFFFFC);
	ui8 a_n = l ^ ix->bFFFFFFFE;
	ui8 a_n = h + ix->bFFFFFFED + (byte) C ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v21_n = ix->bFFFFFFDF;
	ix->bFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (byte) (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (byte) (a_n < 0x00);
	Eq_n bc_n = ix->tFFFFFFDE;
	Eq_n hl_n = ix->tFFFFFFE0;
	fn0D00(0x04, bc_n, de, hl_n, ix, wArg20);
}

// 0D00: void fn0D00(Register byte a, Register Eq_n bc, Register Eq_n de, Register Eq_n hl, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C35
//      fn0CB7
void fn0D00(byte a, Eq_n bc, Eq_n de, Eq_n hl, struct Eq_n * ix, Eq_n wArg20)
{
	Eq_n bc_n = bc;
	do
	{
		bc_n <<= 0x01;
		hl = hl * 0x02 + (word16) (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl;
		byte h_n = SLICE(hl, byte, 8);
		--a;
	} while (a != 0x00);
	ui16 a_a_n = (word16) bc_n.u1 + SEQ(v16_n, ix->bFFFFFFEE);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v16_n = ix->bFFFFFFEF;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (word16) ix->tFFFFFFF0 + l_n + (byte) (a_n < 0x00);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = h_n + ix->bFFFFFFF1 + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v23_n, ix->tFFFFFFDE) + SEQ(v24_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem46[ix + -32:byte] + Mem46[ix + -36:byte] + CONVERT(a_n <u 0x00, bool, byte);
	uint8 v23_n = ix->bFFFFFFDF;
	uint8 v24_n = ix->bFFFFFFDB;
	byte a_n = ix->bFFFFFFE1 + ix->bFFFFFFDD + (byte) (a_n < 0x00);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	byte a_n;
	uint32 h_l_b_c_n = SEQ(ix->bFFFFFFE1, ix->tFFFFFFE0, ix->bFFFFFFDF, ix->tFFFFFFDE);
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		uint32 v75_n = h_l_b_c_n >> 1;
		uint24 v74_n = SLICE(v75_n, uint24, 8);
		uint16 v73_n = SLICE(v74_n, uint16, 8);
		byte h_n = SLICE(v73_n, byte, 8);
		byte l_n = (byte) v73_n;
		ui8 b_n = (byte) v74_n;
		uint8 c_n = (byte) v75_n;
		h_l_b_c_n = v75_n;
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v41_n, ix->tFFFFFFF2);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = (word16) ix->tFFFFFFF4 + l_n + (byte) (a_n < 0x00);
	ui16 a_a_n = SEQ(v49_n, ix->tFFFFFFE6) - (a_a_n ^ ix->tFFFFFFFC);
	uint8 v41_n = ix->bFFFFFFF3;
	ui8 a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h_n + ix->bFFFFFFF5 + (byte) (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFE6 = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	uint8 v49_n = ix->bFFFFFFE7;
	ix->bFFFFFFE7 = a_n;
	Eq_n a_n = ix->tFFFFFFE8 - a_n - (byte) (a_n < 0x00);
	ix->tFFFFFFE8 = a_n;
	ix->bFFFFFFE9 = ix->bFFFFFFE9 - a_n - (byte) (a_n < 0x00);
	uint8 v52_n = ix->bFFFFFFDA;
	ix->bFFFFFFDA = v52_n + 0x47;
	uint8 a_n = SLICE(SEQ(ix->bFFFFFFDB, v52_n) + 34375, byte, 8);
	ix->bFFFFFFDB = a_n;
	Eq_n a_n = (word16) ix->tFFFFFFDC + 200 + (byte) (a_n < 0x00);
	ix->tFFFFFFDC = a_n;
	ix->bFFFFFFDD = ix->bFFFFFFDD + 0x61 + (byte) (a_n < 0x00);
	uint8 v56_n = ix->bFFFFFFE2;
	uint8 a_n = SLICE(SEQ(ix->bFFFFFFE3, v56_n) + ~0x00, byte, 8);
	cu8 a_n = ix->bFFFFFFE4 + ~0x00 + (byte) (a_n < 0x00);
	byte a_n = ix->bFFFFFFE5 + ~0x00 + (byte) (a_n < 0x00);
	ix->bFFFFFFE2 = v56_n + ~0x00;
	ix->bFFFFFFE3 = a_n;
	ix->bFFFFFFE4 = a_n;
	ix->bFFFFFFE5 = a_n;
	uint8 a_n = a_n | a_n | a_n | v56_n + ~0x00;
	if (a_n != 0x00)
		fn060E(a_n, v56_n + ~0x00, de, ix, wArg20);
	else
		fn0E13(de, wArg20);
}

// 0DFC: void fn0DFC(Register uint8 c, Register uint8 b, Register Eq_n de, Register cu8 l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0DFC(uint8 c, uint8 b, Eq_n de, cu8 l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	ix->bFFFFFFE2 = c;
	ix->bFFFFFFE3 = b;
	ix->bFFFFFFE4 = l;
	ix->bFFFFFFE5 = h;
	uint8 a_n = h | l | b | c;
	if (a_n != 0x00)
		fn060E(a_n, c, de, ix, wArg20);
	else
		fn0E13(de, wArg20);
}

// 0E13: void fn0E13(Register Eq_n de, Stack Eq_n wArg20)
// Called from:
//      fn0C35
//      fn0DFC
void fn0E13(Eq_n de, Eq_n wArg20)
{
	ptr32 fp;
	Eq_n hl_n = fp + 0x0C;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de = *hl_n;
		hl_n = (word32) hl_n + 1;
		++de;
	}
	Eq_n de_n = wArg20;
	Eq_n hl_n = fp + 0x04;
	word16 bc_n;
	for (bc_n = 0x04; bc_n != 0x00; --bc_n)
	{
		*de_n = *hl_n;
		hl_n = (word32) hl_n + 1;
		++de_n;
	}
}

// 0F9A: void fn0F9A()
void fn0F9A()
{
}

// 164F: void fn164F(Register cu8 a, Register word16 bc, Register byte h, Register (ptr16 Eq_n) ix, Stack (ptr16 ui16) wArg0E, Stack byte bArg11, Stack Eq_n wArg13, Stack (ptr16 ui16) wArg15, Stack (ptr16 Eq_n) wArg17, Stack byte bArg1A, Stack (ptr16 ui16) wArg1B, Stack byte bArg20, Stack (ptr16 Eq_n) wArg21, Stack (ptr16 ui16) wArg25)
void fn164F(cu8 a, word16 bc, byte h, struct Eq_n * ix, ui16 * wArg0E, byte bArg11, Eq_n wArg13, ui16 * wArg15, struct Eq_n * wArg17, byte bArg1A, ui16 * wArg1B, byte bArg20, struct Eq_n * wArg21, ui16 * wArg25)
{
	bool C;
	word16 wArg11;
	byte bArg1B_n = (byte) wArg1B;
	byte bArg21_n = (byte) wArg21;
	Eq_n wArg20_n;
	ix->bFFFFFFEC = a;
	ix->bFFFFFFED = ix->bFFFFFFF9 - h - (byte) C;
	ui16 a_a_n = bc - *wArg1B;
	ui16 a_a_n = ix->tFFFFFFF8 - ix->tFFFFFFFC;
	Eq_n de_n;
	word16 hl_n;
	struct Eq_n * ix_n;
	Eq_n bc_n = fn02F4(SLICE(a_a_n, byte, 8), (byte) a_a_n, SLICE(a_a_n, byte, 8), wArg13, SLICE(a_a_n, byte, 8), ix, SEQ(bArg1B_n, bArg1A), out de_n, out hl_n, out ix_n);
	byte h_n = SLICE(hl_n, byte, 8);
	if ((byte) hl_n != 0x00)
	{
		uint8 v31_n = wArg17->b0000;
		ui8 v32_n = wArg17->b0001;
		ui16 a_a_n = SEQ(v32_n, v31_n) - *wArg15;
		ix_n->bFFFFFFEC = (byte) a_a_n;
		ix_n->bFFFFFFED = SLICE(a_a_n, byte, 8);
		uint8 v39_n = wArg21->b0000;
		ui8 v40_n = wArg21->b0001;
		ui16 a_a_n = SEQ(v40_n, v39_n) - *wArg0E;
		ix_n->bFFFFFFEA = (byte) a_a_n;
		ix_n->bFFFFFFEB = SLICE(a_a_n, byte, 8);
		ui16 a_a_n = SEQ(v32_n, v31_n) - *wArg1B;
		Eq_n a_a_n = SEQ(v40_n, v39_n) - *wArg25;
		Eq_n de_n;
		word16 hl_n;
		struct Eq_n * ix_n;
		Eq_n bc_n = fn02F4(SLICE(a_a_n, byte, 8), (byte) a_a_n, SLICE(a_a_n, byte, 8), a_a_n, SLICE(wArg11, byte, 8), ix_n, SEQ(bArg1B_n, bArg1A), out de_n, out hl_n, out ix_n);
		byte h_n = SLICE(hl_n, byte, 8);
		wArg20_n = SEQ(bArg21_n, bArg20);
		if ((byte) hl_n != 0x00)
			fn0C35(bc_n, de_n, 0x00, h_n, ix_n, wArg20_n);
		else
			fn0C35(bc_n, de_n, 0x03, h_n, ix_n, wArg20_n);
	}
	else
		fn0C35(bc_n, de_n, 0x03, h_n, ix_n, wArg20_n);
}

// 1873: void fn1873(Register Eq_n bc, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack (ptr16 Eq_n) wArg13, Stack Eq_n wArg20)
void fn1873(Eq_n bc, Eq_n de, struct Eq_n * ix, struct Eq_n * wArg13, Eq_n wArg20)
{
	byte c = (byte) bc;
	byte b = SLICE(bc, byte, 8);
	wArg13->b0000 = c;
	wArg13->b0001 = b;
	byte h_n = SLICE(&wArg13->b0001, byte, 8);
	fn0C35(bc, de, 0x02, h_n, ix, wArg20);
}

// 1BA4: void fn1BA4()
void fn1BA4()
{
	fn0805();
}

// 1BDE: void fn1BDE(Register byte b, Register byte c, Register Eq_n de, Register (ptr16 Eq_n) ix)
void fn1BDE(byte b, byte c, Eq_n de, struct Eq_n * ix)
{
	++ix->bFFFFFFE9;
	ix->bFFFFFFFF = ix->bFFFFFFE9;
	fn1BF9(b, c, de, ix);
}

// 1BF9: void fn1BF9(Register byte b, Register byte c, Register Eq_n de, Register (ptr16 Eq_n) ix)
// Called from:
//      fn1BA4
//      fn1BDE
void fn1BF9(byte b, byte c, Eq_n de, struct Eq_n * ix)
{
	uint8 v4_n = ix->bFFFFFFF7;
	ix->bFFFFFFF7 = v4_n + 0x09;
	ix->bFFFFFFF8 = SLICE(SEQ(ix->bFFFFFFF8, v4_n) + 0x09, byte, 8);
	++ix->bFFFFFFF5;
	Eq_n hl_n = 0x0823;
	word16 bc_n = SEQ(b + 1, c);
	do
	{
		*de = *hl_n;
		++hl_n;
		de = (word32) de + 1;
		--bc_n;
	} while (bc_n != 0x00);
}

// 1C89: void fn1C89(Register byte a, Register byte c)
void fn1C89(byte a, byte c)
{
}

// 22A6: void fn22A6(Register word16 bc, Register (ptr16 Eq_n) ix, Stack word16 wArg05, Stack ptr16 wArg10)
void fn22A6(word16 bc, struct Eq_n * ix, word16 wArg05, ptr16 wArg10)
{
	ix->bFFFFFFFC = ix->bFFFFFFF7;
	ix->bFFFFFFFD = 0x00;
	byte v15_n = wArg10 + (wArg05 + 1);
	struct Eq_n * hl_n = (uint16) v15_n * 0x08 + (uint16) v15_n + bc;
	ix->bFFFFFFF8 = hl_n->b0002;
	ix->bFFFFFFF9 = hl_n->b0003;
	fn03AA();
}

// 3E2D: void fn3E2D(Register word16 bc, Register (ptr16 Eq_n) ix, Stack word16 wArg05, Stack ptr16 wArg10)
void fn3E2D(word16 bc, struct Eq_n * ix, word16 wArg05, ptr16 wArg10)
{
	ix->bFFFFFFFC = ix->bFFFFFFF7;
	ix->bFFFFFFFD = 0x00;
	byte v15_n = wArg10 + (wArg05 + 1);
	struct Eq_n * hl_n = (uint16) v15_n * 0x08 + (uint16) v15_n + bc;
	ix->bFFFFFFF8 = hl_n->b0002;
	ix->bFFFFFFF9 = hl_n->b0003;
	fn03AA();
}

