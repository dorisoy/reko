// TLCS-90_code.c
// Generated by decompiling TLCS-90.corpus
// using Reko decompiler version 0.10.2.0.

#include "TLCS-90.h"

// 0000: void fn0000(Register byte a)
void fn0000(byte a)
{
	null = (byte *) a;
}

byte g_b0001 = 0x00; // 00000001
// 02F4: Register word16 fn02F4(Register byte a, Register byte c, Register byte b, Register Eq_n de, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn164F
word16 fn02F4(byte a, byte c, byte b, Eq_n de, byte h, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	cu8 a_n = (bool) C + (a + ix->bFFFFFFE4);
	ui16 a_a_n = SEQ(v22_n, ix->tFFFFFFF6) + SEQ(b ^ ix->bFFFFFFFB, c ^ ix->bFFFFFFFA);
	ui8 a_n = a_n ^ ix->tFFFFFFFC;
	ui8 a_n = (bool) (a_n < 0x00) + (h + ix->bFFFFFFE5) ^ ix->bFFFFFFFD;
	ix->tFFFFFFF6 = (byte) a_a_n;
	Eq_n a_n = SLICE(a_a_n, byte, 8);
	Eq_n v22_n = ix->tFFFFFFF7;
	ix->tFFFFFFF7 = a_n;
	Eq_n a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFF8 + a_n);
	ix->tFFFFFFF8 = a_n;
	ix->bFFFFFFF9 = (uint8) ((bool) (a_n < 0x00) + (ix->bFFFFFFF9 + a_n));
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFF8;
	Eq_n bc_n = ix->tFFFFFFF6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		Eq_n b_n = SLICE(bc_n, byte, 8);
		hl_n = hl_n * 0x02 + (b_n < 0x00);
		Eq_n c_n = (byte) bc_n;
		uint8 h_n = SLICE(hl_n, byte, 8);
		Eq_n l_n = (byte) hl_n;
	}
	byte a_n = c_n + Mem62[ix + -0x0022:byte];
	Eq_n de_n;
	Eq_n hl_n;
	Eq_n ix_n;
	word16 bc_n = fn034E(a_n, b_n, c_n, de, h_n, l_n, ix, wArg24, out de_n, out hl_n, out ix_n);
	deOut = de_n;
	hlOut = hl_n;
	ixOut = ix_n;
	return bc_n;
}

// 034E: Register word16 fn034E(Register ui8 a, Register Eq_n b, Register Eq_n c, Register Eq_n de, Register uint8 h, Register Eq_n l, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn02F4
word16 fn034E(ui8 a, Eq_n b, Eq_n c, Eq_n de, uint8 h, Eq_n l, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	ix->bFFFFFFFA = a;
	Eq_n de_n;
	Eq_n hl_n;
	Eq_n ix_n;
	word16 bc_n = fn03B2(a, b, c, de, h, l, ix, wArg24, out de_n, out hl_n, out ix_n);
	deOut = de_n;
	hlOut = hl_n;
	ixOut = ix_n;
	return bc_n;
}

// 039D: void fn039D(Register byte a, Register Eq_n de, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24)
void fn039D(byte a, Eq_n de, byte h, struct Eq_n * ix, Eq_n wArg24)
{
	ix->bFFFFFFFD = a ^ h;
	Eq_n v12_n = ix->tFFFFFFF6;
	Eq_n v14_n = ix->tFFFFFFF7;
	Eq_n v16_n = ix->tFFFFFFF8;
	uint8 v18_n = ix->bFFFFFFF9;
	word16 de_n;
	word16 hl_n;
	word16 ix_n;
	fn03B2(0x05, v14_n, v12_n, de, v18_n, v16_n, ix, wArg24, out de_n, out hl_n, out ix_n);
}

// 03AA: void fn03AA()
// Called from:
//      fn22A6
//      fn3E2D
void fn03AA()
{
}

// 03B2: Register word16 fn03B2(Register ui8 a, Register Eq_n b, Register Eq_n c, Register Eq_n de, Register uint8 h, Register Eq_n l, Register (ptr16 Eq_n) ix, Stack Eq_n wArg24, Register out Eq_n deOut, Register out Eq_n hlOut, Register out Eq_n ixOut)
// Called from:
//      fn034E
//      fn039D
word16 fn03B2(ui8 a, Eq_n b, Eq_n c, Eq_n de, uint8 h, Eq_n l, struct Eq_n * ix, Eq_n wArg24, union Eq_n & deOut, union Eq_n & hlOut, union Eq_n & ixOut)
{
	while (true)
	{
		do
		{
			h >>= 1;
			l = __rcr(l, 0x01, (bool) cond(h));
			b = __rcr(b, 0x01, (bool) cond(l));
			c = __rcr(c, 0x01, (bool) cond(b));
			--a;
		} while (a != 0x00);
		ui16 a_a_n = SEQ(b, c) + SEQ(v17_n, ix->bFFFFFFDA);
		cu8 a_n = SLICE(a_a_n, byte, 8);
		byte a_n = l + Mem25[ix + -36:byte] + (a_n <u 0x00);
		ui16 a_a_n = SEQ(v27_n, ix->bFFFFFFF2) + SEQ(a_n ^ ix->bFFFFFFFB, (byte) a_a_n ^ ix->bFFFFFFFA);
		uint8 v17_n = ix->bFFFFFFDB;
		ui8 a_n = a_n ^ ix->tFFFFFFFC;
		ui8 a_n = h + ix->bFFFFFFDD + (a_n < 0x00) ^ ix->bFFFFFFFD;
		ix->bFFFFFFF2 = (byte) a_a_n;
		uint8 a_n = SLICE(a_a_n, byte, 8);
		uint8 v27_n = ix->bFFFFFFF3;
		ix->bFFFFFFF3 = a_n;
		cu8 a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFF4 + a_n);
		ix->bFFFFFFF4 = a_n;
		ix->bFFFFFFF5 = (bool) (a_n < 0x00) + (ix->bFFFFFFF5 + a_n);
		uint8 v30_n = ix->bFFFFFFEA;
		uint8 a_n = (bool) (v30_n < ~0x00) + (ix->bFFFFFFEB + ~0x00);
		Eq_n a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFEC + 0x00FF);
		byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFED + ~0x00);
		ix->bFFFFFFEA = v30_n + ~0x00;
		ix->bFFFFFFEB = a_n;
		ix->tFFFFFFEC = a_n;
		ix->bFFFFFFED = a_n;
		if ((a_n | a_n | a_n | v30_n + ~0x00) == 0x00)
			break;
		ui16 a_a_n = SEQ(a_n, a_n) + SEQ(v44_n, ix->tFFFFFFDF);
		ix->bFFFFFFFB = (byte) a_a_n;
		Eq_n a_n = SLICE(a_a_n, byte, 8);
		Eq_n v44_n = ix->tFFFFFFE0;
		ix->tFFFFFFFC = a_n;
		ix->bFFFFFFFD = (uint8) ((bool) (a_n < 0x00) + (a_n + ix->bFFFFFFE1));
		ui16 a_a_n = SEQ(v48_n, ix->tFFFFFFF6) + SEQ(v49_n, ix->bFFFFFFEE);
		cu8 a_n = SLICE(a_a_n, byte, 8);
		cu8 a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFF8 + ix->bFFFFFFF0);
		Eq_n v48_n = ix->tFFFFFFF7;
		ui8 v49_n = ix->bFFFFFFEF;
		byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFF9 + ix->bFFFFFFF1);
		ix->bFFFFFFFA = ix->bFFFFFFFA ^ (byte) a_a_n;
		ix->bFFFFFFFB = ix->bFFFFFFFB ^ a_n;
		ix->tFFFFFFFC = ix->tFFFFFFFC ^ a_n;
		ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
		c = ix->tFFFFFFF6;
		b = ix->tFFFFFFF7;
		l = ix->tFFFFFFF8;
		h = ix->bFFFFFFF9;
		a = 0x05;
	}
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
		hl_n = hl_n * 0x02 + (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = (word16) bc_n.u1 + SEQ(v23_n, ix->tFFFFFFF6);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	Eq_n v23_n = ix->tFFFFFFF7;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFF8 + l_n);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = (ui8) ((bool) (a_n < 0x00) + (h_n + ix->bFFFFFFF9));
	ui16 a_a_n = SEQ(v28_n, ix->tFFFFFFE6) + SEQ(v29_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem65[ix + -24:byte] + Mem65[ix + -36:byte] + (a_n <u 0x00);
	Eq_n v28_n = ix->tFFFFFFE7;
	uint8 v29_n = ix->bFFFFFFDB;
	byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE9 + ix->bFFFFFFDD);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	Eq_n c_n = ix->tFFFFFFE6;
	Eq_n b_n = ix->tFFFFFFE7;
	Eq_n l_n = ix->tFFFFFFE8;
	uint8 h_n = ix->bFFFFFFE9;
	byte a_n;
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		h_n >>= 1;
		l_n = __rcr(l_n, 0x01, (bool) cond(h_n));
		b_n = __rcr(b_n, 0x01, (bool) cond(l_n));
		c_n = __rcr(c_n, 0x01, (bool) cond(b_n));
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v45_n, ix->bFFFFFFEA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = l_n + Mem117[ix + -20:byte] + (a_n <u 0x00);
	ui16 a_a_n = SEQ(v53_n, ix->tFFFFFFDE) - SEQ(a_n ^ ix->bFFFFFFFD, (byte) a_a_n ^ ix->tFFFFFFFC);
	uint8 v45_n = ix->bFFFFFFEB;
	Eq_n a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h_n + ix->bFFFFFFED + (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	Eq_n a_n = SLICE(a_a_n, byte, 8);
	Eq_n v53_n = ix->tFFFFFFDF;
	ix->tFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (a_n < 0x00);
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFE0;
	Eq_n bc_n = ix->tFFFFFFDE;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl_n;
		byte h_n = SLICE(hl_n, byte, 8);
	}
	ui16 a_a_n = bc_n + SEQ(v61_n, Mem217[ix + -18:byte]);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	ui8 v61_n = ix->bFFFFFFEF;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (bool) (a_n < 0x00) + (l_n + ix->bFFFFFFF0);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = (ui8) ((bool) (a_n < 0x00) + (h_n + ix->bFFFFFFF1));
	uint8 a_n = (word16) ix->tFFFFFFDE + ix->bFFFFFFDA;
	Eq_n v66_n = ix->tFFFFFFDF;
	fn060E(v66_n, a_n, de, ix, wArg20);
}

// 0607: void fn0607(Register byte a, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0607(byte a, Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	uint8 a_n = a + ix->bFFFFFFDA;
	Eq_n v9_n = ix->tFFFFFFDF;
	fn060E(v9_n, a_n, de, ix, wArg20);
}

// 060E: void fn060E(Register Eq_n a, Register uint8 c, Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn04EE
//      fn0607
//      fn0C1D
//      fn0DFC
void fn060E(Eq_n a, uint8 c, Eq_n de, struct Eq_n * ix, Eq_n wArg20)
{
	do
	{
		cu8 a_n = (word16) a + ix->bFFFFFFDB;
		byte a_n = Mem4[ix + -32:byte] + Mem4[ix + -36:byte] + (a_n <u 0x00);
		byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE1 + ix->bFFFFFFDD);
		ix->tFFFFFFFC = ix->tFFFFFFFC ^ c;
		ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
		ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
		ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
		Eq_n c_n = ix->tFFFFFFDE;
		Eq_n b_n = ix->tFFFFFFDF;
		Eq_n l_n = ix->tFFFFFFE0;
		uint8 h_n = ix->bFFFFFFE1;
		byte a_n;
		for (a_n = 0x05; a_n != 0x00; --a_n)
		{
			h_n >>= 1;
			l_n = __rcr(l_n, 0x01, (bool) cond(h_n));
			b_n = __rcr(b_n, 0x01, (bool) cond(l_n));
			c_n = __rcr(c_n, 0x01, (bool) cond(b_n));
		}
		ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v33_n, ix->bFFFFFFF2);
		cu8 a_n = SLICE(a_a_n, byte, 8);
		cu8 a_n = (bool) (a_n < 0x00) + ((word16) l_n + ix->bFFFFFFF4);
		ui16 a_a_n = SEQ(v41_n, ix->tFFFFFFE6) - SEQ(a_n ^ ix->bFFFFFFFD, (byte) a_a_n ^ ix->tFFFFFFFC);
		uint8 v33_n = ix->bFFFFFFF3;
		ui8 a_n = a_n ^ ix->bFFFFFFFE;
		ui8 a_n = h_n + ix->bFFFFFFF5 + (a_n < 0x00) ^ ix->bFFFFFFFF;
		ix->tFFFFFFE6 = (byte) a_a_n;
		Eq_n a_n = SLICE(a_a_n, byte, 8);
		Eq_n v41_n = ix->tFFFFFFE7;
		ix->tFFFFFFE7 = a_n;
		Eq_n a_n = ix->tFFFFFFE8 - a_n - (a_n < 0x00);
		ix->tFFFFFFE8 = a_n;
		ix->bFFFFFFE9 = ix->bFFFFFFE9 - a_n - (a_n < 0x00);
		uint8 v44_n = ix->bFFFFFFDA;
		ix->bFFFFFFDA = v44_n + 0x47;
		uint8 a_n = (bool) (v44_n < 0x47) + (ix->bFFFFFFDB + 0x86);
		ix->bFFFFFFDB = a_n;
		Eq_n a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFDC + 200);
		ix->tFFFFFFDC = a_n;
		ix->bFFFFFFDD = (bool) (a_n < 0x00) + (ix->bFFFFFFDD + 0x61);
		uint8 v48_n = ix->bFFFFFFE2;
		cu8 a_n = (bool) (v48_n < ~0x00) + (ix->bFFFFFFE3 + ~0x00);
		cu8 a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE4 + ~0x00);
		byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE5 + ~0x00);
		ix->bFFFFFFE2 = v48_n + ~0x00;
		ix->bFFFFFFE3 = a_n;
		ix->bFFFFFFE4 = a_n;
		ix->bFFFFFFE5 = a_n;
		c = v48_n + ~0x00;
		a = a_n | a_n | a_n | v48_n + ~0x00;
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

// 0C1D: void fn0C1D(Register Eq_n de, Register (ptr16 Eq_n) ix, Stack Eq_n wArg22)
void fn0C1D(Eq_n de, struct Eq_n * ix, Eq_n wArg22)
{
	byte a_n;
	Eq_n hl_n = ix->tFFFFFFE8;
	Eq_n bc_n = ix->tFFFFFFE6;
	for (a_n = 0x04; a_n != 0x00; --a_n)
	{
		bc_n <<= 0x01;
		hl_n = hl_n * 0x02 + (SLICE(bc_n, byte, 8) < 0x00);
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
	Eq_n v10_n = ix->tFFFFFFF7;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFF8 + l);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = (ui8) ((bool) (a_n < 0x00) + (h + ix->bFFFFFFF9));
	ui16 a_a_n = SEQ(v18_n, ix->tFFFFFFE6) + SEQ(v19_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem30[ix + -24:byte] + Mem30[ix + -36:byte] + (a_n <u 0x00);
	Eq_n v18_n = ix->tFFFFFFE7;
	uint8 v19_n = ix->bFFFFFFDB;
	byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE9 + ix->bFFFFFFDD);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	Eq_n v32_n = ix->tFFFFFFE6;
	Eq_n v33_n = ix->tFFFFFFE7;
	Eq_n v34_n = ix->tFFFFFFE8;
	uint8 v35_n = ix->bFFFFFFE9;
	fn0C9D(0x05, v33_n, v32_n, de, v35_n, v34_n, ix, wArg20);
}

// 0C39: void fn0C39(Register Eq_n a, Register byte b, Register Eq_n de, Register byte l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0C39(Eq_n a, byte b, Eq_n de, byte l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	ix->tFFFFFFFC = a;
	uint8 a_n = (bool) C + ((word16) ix->tFFFFFFF7 + b);
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFF8 + l);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = (ui8) ((bool) (a_n < 0x00) + (h + ix->bFFFFFFF9));
	ui16 a_a_n = SEQ(v17_n, ix->tFFFFFFE6) + SEQ(v18_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem25[ix + -24:byte] + Mem25[ix + -36:byte] + (a_n <u 0x00);
	Eq_n v17_n = ix->tFFFFFFE7;
	uint8 v18_n = ix->bFFFFFFDB;
	byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE9 + ix->bFFFFFFDD);
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
	Eq_n v16_n = ix->tFFFFFFE7;
	Eq_n v18_n = ix->tFFFFFFE8;
	uint8 v19_n = ix->bFFFFFFE9;
	fn0C9D(0x05, v16_n, v14_n, de, v19_n, v18_n, ix, wArg20);
}

// 0C9D: void fn0C9D(Register byte a, Register Eq_n b, Register Eq_n c, Register Eq_n de, Register uint8 h, Register Eq_n l, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C1D
//      fn0C80
void fn0C9D(byte a, Eq_n b, Eq_n c, Eq_n de, uint8 h, Eq_n l, struct Eq_n * ix, Eq_n wArg20)
{
	do
	{
		h >>= 1;
		l = __rcr(l, 0x01, (bool) cond(h));
		b = __rcr(b, 0x01, (bool) cond(l));
		c = __rcr(c, 0x01, (bool) cond(b));
		--a;
	} while (a != 0x00);
	ui16 a_a_n = SEQ(b, c) + SEQ(v17_n, ix->bFFFFFFEA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = l + Mem0[ix + -20:byte] + (a_n <u 0x00);
	ui16 a_a_n = SEQ(v27_n, ix->tFFFFFFDE) - SEQ(a_n ^ ix->bFFFFFFFD, (byte) a_a_n ^ ix->tFFFFFFFC);
	uint8 v17_n = ix->bFFFFFFEB;
	ui8 a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h + ix->bFFFFFFED + (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	Eq_n a_n = SLICE(a_a_n, byte, 8);
	Eq_n v27_n = ix->tFFFFFFDF;
	ix->tFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (a_n < 0x00);
	Eq_n bc_n = ix->tFFFFFFDE;
	Eq_n hl_n = ix->tFFFFFFE0;
	fn0D00(0x04, bc_n, de, hl_n, ix, wArg20);
}

// 0CB7: void fn0CB7(Register byte c, Register byte b, Register Eq_n de, Register byte h, Register byte l, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0CB7(byte c, byte b, Eq_n de, byte h, byte l, struct Eq_n * ix, Eq_n wArg20)
{
	ui16 a_a_n = SEQ(v21_n, ix->tFFFFFFDE) - SEQ(b ^ ix->bFFFFFFFD, c ^ ix->tFFFFFFFC);
	ui8 a_n = l ^ ix->bFFFFFFFE;
	ui8 a_n = (bool) C + (h + ix->bFFFFFFED) ^ ix->bFFFFFFFF;
	ix->tFFFFFFDE = (byte) a_a_n;
	Eq_n a_n = SLICE(a_a_n, byte, 8);
	Eq_n v21_n = ix->tFFFFFFDF;
	ix->tFFFFFFDF = a_n;
	Eq_n a_n = ix->tFFFFFFE0 - a_n - (a_n < 0x00);
	ix->tFFFFFFE0 = a_n;
	ix->bFFFFFFE1 = ix->bFFFFFFE1 - a_n - (a_n < 0x00);
	Eq_n bc_n = ix->tFFFFFFDE;
	Eq_n hl_n = ix->tFFFFFFE0;
	fn0D00(0x04, bc_n, de, hl_n, ix, wArg20);
}

// 0D00: void fn0D00(Register byte a, Register Eq_n bc, Register Eq_n de, Register Eq_n hl, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
// Called from:
//      fn0C1D
//      fn0CB7
void fn0D00(byte a, Eq_n bc, Eq_n de, Eq_n hl, struct Eq_n * ix, Eq_n wArg20)
{
	Eq_n bc_n = bc;
	do
	{
		bc_n <<= 0x01;
		hl = hl * 0x02 + (SLICE(bc_n, byte, 8) < 0x00);
		byte l_n = (byte) hl;
		byte h_n = SLICE(hl, byte, 8);
		--a;
	} while (a != 0x00);
	ui16 a_a_n = (word16) bc_n.u1 + SEQ(v16_n, ix->bFFFFFFEE);
	ix->tFFFFFFFC = (byte) a_a_n;
	uint8 a_n = SLICE(a_a_n, byte, 8);
	ui8 v16_n = ix->bFFFFFFEF;
	ix->bFFFFFFFD = a_n;
	uint8 a_n = (bool) (a_n < 0x00) + (l_n + ix->bFFFFFFF0);
	ix->bFFFFFFFE = a_n;
	ix->bFFFFFFFF = (ui8) ((bool) (a_n < 0x00) + (h_n + ix->bFFFFFFF1));
	ui16 a_a_n = SEQ(v23_n, ix->tFFFFFFDE) + SEQ(v24_n, ix->bFFFFFFDA);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	byte a_n = Mem46[ix + -32:byte] + Mem46[ix + -36:byte] + (a_n <u 0x00);
	Eq_n v23_n = ix->tFFFFFFDF;
	uint8 v24_n = ix->bFFFFFFDB;
	byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE1 + ix->bFFFFFFDD);
	ix->tFFFFFFFC = ix->tFFFFFFFC ^ (byte) a_a_n;
	ix->bFFFFFFFD = ix->bFFFFFFFD ^ a_n;
	ix->bFFFFFFFE = ix->bFFFFFFFE ^ a_n;
	ix->bFFFFFFFF = ix->bFFFFFFFF ^ a_n;
	Eq_n c_n = ix->tFFFFFFDE;
	Eq_n b_n = ix->tFFFFFFDF;
	Eq_n l_n = ix->tFFFFFFE0;
	uint8 h_n = ix->bFFFFFFE1;
	byte a_n;
	for (a_n = 0x05; a_n != 0x00; --a_n)
	{
		h_n >>= 1;
		l_n = __rcr(l_n, 0x01, (bool) cond(h_n));
		b_n = __rcr(b_n, 0x01, (bool) cond(l_n));
		c_n = __rcr(c_n, 0x01, (bool) cond(b_n));
	}
	ui16 a_a_n = SEQ(b_n, c_n) + SEQ(v41_n, ix->bFFFFFFF2);
	cu8 a_n = SLICE(a_a_n, byte, 8);
	cu8 a_n = (bool) (a_n < 0x00) + ((word16) l_n + ix->bFFFFFFF4);
	ui16 a_a_n = SEQ(v49_n, ix->tFFFFFFE6) - SEQ(a_n ^ ix->bFFFFFFFD, (byte) a_a_n ^ ix->tFFFFFFFC);
	uint8 v41_n = ix->bFFFFFFF3;
	ui8 a_n = a_n ^ ix->bFFFFFFFE;
	ui8 a_n = h_n + ix->bFFFFFFF5 + (a_n < 0x00) ^ ix->bFFFFFFFF;
	ix->tFFFFFFE6 = (byte) a_a_n;
	Eq_n a_n = SLICE(a_a_n, byte, 8);
	Eq_n v49_n = ix->tFFFFFFE7;
	ix->tFFFFFFE7 = a_n;
	Eq_n a_n = ix->tFFFFFFE8 - a_n - (a_n < 0x00);
	ix->tFFFFFFE8 = a_n;
	ix->bFFFFFFE9 = ix->bFFFFFFE9 - a_n - (a_n < 0x00);
	uint8 v52_n = ix->bFFFFFFDA;
	ix->bFFFFFFDA = v52_n + 0x47;
	uint8 a_n = (bool) (v52_n < 0x47) + (ix->bFFFFFFDB + 0x86);
	ix->bFFFFFFDB = a_n;
	Eq_n a_n = (bool) (a_n < 0x00) + ((word16) ix->tFFFFFFDC + 200);
	ix->tFFFFFFDC = a_n;
	ix->bFFFFFFDD = (bool) (a_n < 0x00) + (ix->bFFFFFFDD + 0x61);
	uint8 v56_n = ix->bFFFFFFE2;
	cu8 a_n = (bool) (v56_n < ~0x00) + (ix->bFFFFFFE3 + ~0x00);
	cu8 a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE4 + ~0x00);
	byte a_n = (bool) (a_n < 0x00) + (ix->bFFFFFFE5 + ~0x00);
	ix->bFFFFFFE2 = v56_n + ~0x00;
	ix->bFFFFFFE3 = a_n;
	ix->bFFFFFFE4 = a_n;
	ix->bFFFFFFE5 = a_n;
	Eq_n a_n = a_n | a_n | a_n | v56_n + ~0x00;
	if (a_n != 0x00)
		fn060E(a_n, v56_n + ~0x00, de, ix, wArg20);
	else
		fn0E13(de, wArg20);
}

// 0DFC: void fn0DFC(Register uint8 c, Register cu8 b, Register Eq_n de, Register cu8 l, Register byte h, Register (ptr16 Eq_n) ix, Stack Eq_n wArg20)
void fn0DFC(uint8 c, cu8 b, Eq_n de, cu8 l, byte h, struct Eq_n * ix, Eq_n wArg20)
{
	ix->bFFFFFFE2 = c;
	ix->bFFFFFFE3 = b;
	ix->bFFFFFFE4 = l;
	ix->bFFFFFFE5 = h;
	Eq_n a_n = h | l | b | c;
	if (a_n != 0x00)
		fn060E(a_n, c, de, ix, wArg20);
	else
		fn0E13(de, wArg20);
}

// 0E13: void fn0E13(Register Eq_n de, Stack Eq_n wArg20)
// Called from:
//      fn0D00
//      fn0DFC
void fn0E13(Eq_n de, Eq_n wArg20)
{
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

// 164F: void fn164F(Register Eq_n a, Register word16 bc, Register byte h, Register (ptr16 Eq_n) ix, Stack (ptr16 ui16) wArg0C, Stack byte bArg0F, Stack Eq_n wArg13, Stack (ptr16 Eq_n) wArg15, Stack byte bArg18, Stack (ptr16 ui16) wArg19, Stack (ptr16 ui16) wArg1B, Stack byte bArg1D, Stack byte bArg1E, Stack (ptr16 Eq_n) wArg1F, Stack (ptr16 ui16) wArg23)
void fn164F(Eq_n a, word16 bc, byte h, struct Eq_n * ix, ui16 * wArg0C, byte bArg0F, Eq_n wArg13, struct Eq_n * wArg15, byte bArg18, ui16 * wArg19, ui16 * wArg1B, byte bArg1D, byte bArg1E, struct Eq_n * wArg1F, ui16 * wArg23)
{
	byte bArg1B_n = (byte) wArg1B;
	byte bArg1C_n = SLICE(wArg1B, byte, 8);
	byte bArg1A = SLICE(wArg19, byte, 8);
	byte bArg1F_n = (byte) wArg1F;
	byte bArg19 = (byte) wArg19;
	ix->tFFFFFFEC = a;
	ix->bFFFFFFED = ix->bFFFFFFF9 - h - C;
	ui16 a_a_n = bc - *wArg1B;
	byte a_n = SLICE(ix->tFFFFFFF8 - ix->tFFFFFFFC, byte, 8);
	Eq_n de_n;
	word16 hl_n;
	struct Eq_n * ix_n;
	Eq_n bc_n = fn02F4(a_n, (byte) a_a_n, SLICE(a_a_n, byte, 8), wArg13, a_n, ix, SEQ(bArg1B_n, bArg1A), out de_n, out hl_n, out ix_n);
	byte h_n = SLICE(hl_n, byte, 8);
	Eq_n wArg1C_n = SEQ(bArg1D, bArg1C_n);
	Eq_n wArg1E_n = SEQ(bArg1F_n, bArg1E);
	if ((byte) hl_n != 0x00)
	{
		uint8 v31_n = wArg15->b0000;
		ui8 v32_n = wArg15->b0001;
		ui16 a_a_n = SEQ(v32_n, v31_n) - *wArg13;
		ix_n->tFFFFFFEC = (byte) a_a_n;
		ix_n->bFFFFFFED = SLICE(a_a_n, byte, 8);
		uint8 v39_n = wArg1F->b0000;
		ui8 v40_n = wArg1F->b0001;
		ui16 a_a_n = SEQ(v40_n, v39_n) - *wArg0C;
		ix_n->bFFFFFFEA = (byte) a_a_n;
		ix_n->bFFFFFFEB = SLICE(a_a_n, byte, 8);
		ui16 a_a_n = SEQ(v32_n, v31_n) - *wArg19;
		Eq_n a_a_n = SEQ(v40_n, v39_n) - *wArg23;
		Eq_n de_n;
		word16 hl_n;
		struct Eq_n * ix_n;
		Eq_n bc_n = fn02F4(SLICE(a_a_n, byte, 8), (byte) a_a_n, SLICE(a_a_n, byte, 8), a_a_n, SLICE(wArg0F, byte, 8), ix_n, SEQ(bArg19, bArg18), out de_n, out hl_n, out ix_n);
		byte h_n = SLICE(hl_n, byte, 8);
		if ((byte) hl_n != 0x00)
			fn0C35(bc_n, de_n, 0x00, h_n, ix_n, wArg1C_n);
		else
			fn0C35(bc_n, de_n, 0x03, h_n, ix_n, wArg1C_n);
	}
	else
		fn0C35(bc_n, de_n, 0x03, h_n, ix_n, wArg1E_n);
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
	cu8 v4_n = ix->bFFFFFFF7;
	ix->bFFFFFFF7 = v4_n + 0x09;
	ix->bFFFFFFF8 = (bool) (v4_n < 0x09) + ix->bFFFFFFF8;
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

