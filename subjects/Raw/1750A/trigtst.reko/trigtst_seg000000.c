// trigtst_seg000000.c
// Generated by decompiling trigtst.ldm
// using Reko decompiler version 0.10.2.0.

#include "trigtst.h"

Eq_n g_t0007 = // 0007
	{
		
		{
			;
Eq_n g_t000A = // 000A
			{
				
				{
					;
// 0100: void fn0100(Stack word16 wArg40, Stack word16 wArg7E, Stack cui16 wArgC2)
void fn0100(word16 wArg40, word16 wArg7E, cui16 wArgC2)
{
					__mov(&g_tFFFF8000, 1218);
					__mov(&g_tFFFF80E9, 0x05B7);
					fn0111(wArg40, wArg7E, wArgC2);
					while (true)
						;
}

// 0111: void fn0111(Stack word16 wArg42, Stack word16 wArg80, Stack cui16 wArgC4)
// Called from:
//      fn0100
void fn0111(word16 wArg42, word16 wArg80, cui16 wArgC4)
{
					fn04B9(&g_tFFFF8000);
					real48 gp0_gp1_gp2_n = g_rFFFF80CE;
					int32 gp0_gp1_n = <invalid>;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp11_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn01E6((word32) gp0_gp1_gp2_n, (word16) gp0_gp1_gp2_n), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF800D);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80CE + 3);
					int32 gp0_gp1_n = <invalid>;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp11_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn01E6((word32) gp0_gp1_gp2_n, (word16) gp0_gp1_gp2_n), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF801A);
					real48 gp0_gp1_gp2_n = g_rFFFF80D4;
					int32 gp0_gp1_n = <invalid>;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp11_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn01E6((word32) gp0_gp1_gp2_n, (word16) gp0_gp1_gp2_n), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF8027);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80D4 + 3);
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn01E6((word32) gp0_gp1_gp2_n, (word16) gp0_gp1_gp2_n), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF8036);
					real48 gp0_gp1_gp2_n = g_rFFFF80DA;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, wArg42, wArgC4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF8042);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80DA + 3);
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, gp15_n->w0042, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF804F);
					real48 gp0_gp1_gp2_n = g_rFFFF80E0;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, gp15_n->w0042, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF805C);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80E0 + 3);
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, gp15_n->w0042, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF806B);
					real48 gp0_gp1_gp2_n = g_rFFFF80E6;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp14_n;
					cui16 gp3_n = fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, gp15_n->w0042, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF8076);
					real48 gp0_gp1_gp2_n = g_rFFFF80CE;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn032A((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp3_n, gp11_n, gp15_n->w0042, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF8082);
					real48 gp0_gp1_gp2_n = g_rFFFF80DA;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0064, gp15_n->w00C4), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF808E);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80DA + 3);
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0066, gp15_n->w00C6), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF809B);
					real48 gp0_gp1_gp2_n = g_rFFFF80E0;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0066, gp15_n->w00C6), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF80A8);
					real48 gp0_gp1_gp2_n = *((char *) &g_rFFFF80E0 + 3);
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0066, gp15_n->w00C6), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF80B7);
					real48 gp0_gp1_gp2_n = g_rFFFF80E6;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp10_n;
					struct Eq_n * gp11_n;
					word16 gp8_n;
					cui16 gp9_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0066, gp15_n->w00C6), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
					fn04B9(&g_tFFFF80C2);
					real48 gp0_gp1_gp2_n = g_rFFFF80CE;
					struct Eq_n * gp15_n = (struct Eq_n *) <invalid>;
					int32 gp12_gp13_n = <invalid>;
					int32 gp0_gp1_n = <invalid>;
					word16 gp8_n;
					word16 gp9_n;
					word16 gp10_n;
					word16 gp11_n;
					word16 gp14_n;
					fn04AE(gp0_gp1_n, fn034E((word32) gp0_gp1_gp2_n, gp12_gp13_n, (word16) gp0_gp1_gp2_n, gp8_n, gp9_n, gp10_n, gp11_n, gp15_n->w0066, gp15_n->w00C6), out gp8_n, out gp9_n, out gp10_n, out gp11_n, out gp14_n);
					fn045A(0x0A);
}

// 01E6: Register word16 fn01E6(Sequence word32 gp0_gp1, Register word16 gp2)
// Called from:
//      fn0111
word16 fn01E6(word32 gp0_gp1, word16 gp2)
{
					word16 gp0 = SLICE(gp0_gp1, word16, 16);
					int16 gp1 = (word16) gp0_gp1;
					real48 gp0_gp1_gp2_n = SEQ(gp0_gp1, gp2);
					if (gp0_gp1_gp2_n == g_r05AB)
						return gp2;
					if (gp0_gp1_gp2_n < g_r05AB)
						__bpt();
					Eq_n gp6_n = __xbr(gp1);
					real48 gp0_gp1_gp2_n = SEQ(gp0, gp1 & 0xFF00, gp2) * g_r05AE + g_r05B1;
					real48 gp0_gp1_gp2_n = gp0_gp1_gp2_n + SEQ(gp0, gp1 & 0xFF00, gp2) / gp0_gp1_gp2_n;
					real48 gp0_gp1_gp2_n = SEQ(SLICE(gp0_gp1_gp2_n, word16, 32), SLICE(gp0_gp1_gp2_n, word16, 16) & 0xFF00 | 0xFE, 0xFE) + SEQ(gp0, gp1 & 0xFF00, gp2) / gp0_gp1_gp2_n;
					real48 gp0_gp1_gp2_n = gp0_gp1_gp2_n + SEQ(gp0, gp1 & 0xFF00, gp2) / gp0_gp1_gp2_n;
					word16 gp0_n = SLICE(gp0_gp1_gp2_n, word16, 32);
					word16 gp2_n = (word16) gp0_gp1_gp2_n;
					cui16 gp1_n = SLICE(gp0_gp1_gp2_n, word16, 16) & 0xFF00 | 0xFF;
					if (Test(NE,(gp6_n >> 0x08 & 0x8000) == 0x00))
						gp2_n = (word16) (SEQ(gp0_n, gp1_n, gp2_n) * g_r05B4);
					return gp2_n;
}

// 02BF: Register word16 fn02BF(Register ci16 gp1, Stack cui16 wArgC8, Register out ptr16 gp1Out, Register out ptr16 gp14Out)
// Called from:
//      fn032A
//      fn034E
word16 fn02BF(ci16 gp1, cui16 wArgC8, ptr16 & gp1Out, ptr16 & gp14Out)
{
					word16 gp3 = (word16) gp2_gp3;
					if (gp1 >= 0x00)
					{
						gp1Out = gp4;
						gp14Out = fp;
						return gp3;
					}
					else
					{
						struct Eq_n * gp2_n = wArgC8 + 0x07 & ~0x07;
						while (true)
						{
							Eq_n gp1_gp2_n = (uint32) (gp1 - gp2_n);
							do
								;
							while (gp1_gp2_n > 0x07);
							gp2_n = gp2_n->ptr02DA;
						}
					}
}

// 032A: Register word16 fn032A(Sequence int32 gp0_gp1, Sequence int32 gp12_gp13, Register word16 gp2, Register cui16 gp3, Register (ptr16 Eq_n) gp11, Stack word16 wArg44, Stack cui16 wArgC6)
// Called from:
//      fn0111
word16 fn032A(int32 gp0_gp1, int32 gp12_gp13, word16 gp2, cui16 gp3, struct Eq_n * gp11, word16 wArg44, cui16 wArgC6)
{
					cui16 gp1 = (word16) gp0_gp1;
					struct Eq_n * gp0 = SLICE(gp0_gp1, word16, 16);
					struct Eq_n * gp12 = SLICE(gp12_gp13, word16, 16);
					int32 gp1_gp2_n = SEQ(gp1, gp2);
					if (gp0_gp1 >= 0x00)
					{
						if (gp0_gp1 != 0x00)
						{
							word16 gp1_n;
							word16 gp2_n;
							word16 gp3_n;
							word16 gp8_n;
							word16 gp12_n;
							word16 gp13_n;
							word16 gp14_n;
							fn03E0(gp1_gp2_n, gp0, gp3, out gp1_n, out gp2_n, out gp3_n, out gp8_n, out gp12_n, out gp13_n, out gp14_n);
							return gp2_n;
						}
						else
						{
							if ((gp1 & 0x8000) != 0x00)
								gp11[2] = (struct Eq_n) SEQ((byte) gp2, gp11[2]);
							else
								gp11[2] = (struct Eq_n) SEQ(gp11[3], (byte) gp2);
							return wArg02;
						}
					}
					else
					{
						word32 gp1_gp2_n;
						cui16 gp9_n;
						real48 gp2_gp3_gp4_n = g_rFFFF8122;
						real48 gp5_gp6_gp7_n = (SEQ((word32) gp2_gp3_gp4_n, (word16) gp2_gp3_gp4_n) - SEQ(gp0_gp1, gp2)) *48 *((char *) (&g_rFFFF8122) + 3);
						Eq_n gp0_gp1_n = (int32) gp5_gp6_gp7_n;
						real48 gp5_gp6_gp7_n = gp5_gp6_gp7_n - (real48) gp0_gp1_n;
						word16 gp7_n = (word16) gp5_gp6_gp7_n;
						word16 gp2_n = SLICE(gp5_gp6_gp7_n, word16, 16);
						word16 gp3_n = (word16) gp5_gp6_gp7_n;
						if (gp5_gp6_gp7_n < 0.0)
						{
							word32 gp0_gp1_n = gp0_gp1_n + Mem0[0x812B<p16>:word32];
							gp9_n = gp1;
							gp1_gp2_n = SEQ((word16) gp0_gp1_n, SLICE(SEQ(wArg44, gp3_n, gp7_n) + g_rFFFF8128, word16, 32));
							if (gp0_gp1 < 0x00)
							{
								word16 gp1_n;
								word16 gp14_n;
								fn02BF(*((char *) &g_uFFFF812B + 2) + (word16) gp0_gp1_n /16 33085, wArgC6, out gp1_n, out gp14_n);
								return wArg49;
							}
						}
						else
						{
							word16 gp1_n = (word16) (gp0_gp1_n + gp12->r0020);
							for (gp9_n = 0x06; gp9_n != 0x00; --gp9_n)
							{
								gp11->w0000 = gp2;
								++gp11;
								gp1_gp2_n = SEQ(gp1_n, gp2_n);
							}
						}
						struct Eq_n * gp11_n = gp11 - 0x01;
						gp11_n->t0000 = SEQ(gp11_n->b0001, (byte) gp9_n);
						ci16 gp1_n = SLICE(gp1_gp2_n, word16, 16);
						if (gp1_n >= 0x00)
						{
							word16 gp1_n;
							word16 gp2_n;
							fn000003B4(gp1_gp2_n, gp12_gp13, gp9_n, 0x20, gp11_n, fp, out gp1_n, out gp2_n);
							return gp2_n;
						}
						else if (gp1_n != 0x8000)
						{
							word16 gp1_n;
							word16 gp2_n;
							fn000003B4(gp1_gp2_n, gp12_gp13, gp9_n, 0x2D, gp11_n, fp, out gp1_n, out gp2_n);
							return gp2_n;
						}
						else
						{
							word16 gp1_n;
							word16 gp2_n;
							fn000003B2(gp1_gp2_n, gp12_gp13, gp9_n, 0x2D, gp11_n, fp, out gp1_n, out gp2_n);
							return gp2_n;
						}
					}
}

// 034E: Register word16 fn034E(Sequence int32 gp0_gp1, Sequence int32 gp12_gp13, Register word16 gp2, Register word16 gp8, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Stack word16 wArg66, Stack cui16 wArgC6)
// Called from:
//      fn0111
word16 fn034E(int32 gp0_gp1, int32 gp12_gp13, word16 gp2, word16 gp8, cui16 gp9, word16 gp10, struct Eq_n * gp11, word16 wArg66, cui16 wArgC6)
{
					word32 gp1_gp2_n = SEQ((word16) gp0_gp1, gp2);
					if (gp0_gp1 >= 0x00)
					{
						word16 gp1_n;
						word16 gp2_n;
						fn000003B2(gp1_gp2_n, gp12_gp13, gp9, gp10, gp11, fp, out gp1_n, out gp2_n);
						return gp2_n;
					}
					else
					{
						real48 gp2_gp3_gp4_n = g_rFFFF812F - SEQ(gp0_gp1, gp2);
						real48 gp5_gp6_gp7_n = SEQ((word32) gp2_gp3_gp4_n, (word16) gp2_gp3_gp4_n) *48 *((char *) (&g_rFFFF812F) + 3);
						int32 gp0_gp1_n = (int32) gp5_gp6_gp7_n;
						real48 gp5_gp6_gp7_n = gp5_gp6_gp7_n - (real48) gp0_gp1_n;
						word16 gp7_n = (word16) gp5_gp6_gp7_n;
						word16 gp5_n = SLICE(gp5_gp6_gp7_n, word16, 32);
						word16 gp3_n = (word16) gp5_gp6_gp7_n;
						if (gp5_gp6_gp7_n >= 0.0)
						{
							word16 gp1_n;
							word16 gp2_n;
							fn000003C0(gp12_gp13, SEQ(gp7_n, gp8), gp5_n, gp9, gp10, gp11, fp, out gp1_n, out gp2_n);
							return gp2_n;
						}
						else
						{
							word16 gp2_n = SLICE(SEQ(wArg66, gp3_n, gp7_n) + g_rFFFF8135, word16, 32);
							word16 gp1_n;
							word16 gp14_n;
							fn02BF(SLICE(gp0_gp1_n, word16, 0) + Mem0[0x8138<p16>:word16] + Mem0[0x813A<p16>:word16], wArgC6, out gp1_n, out gp14_n);
							return gp2_n;
						}
					}
}

// 000003B2: Register word16 fn000003B2(Sequence word32 gp1_gp2, Sequence int32 gp12_gp13, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn032A
//      fn034E
word16 fn000003B2(word32 gp1_gp2, int32 gp12_gp13, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					word16 gp1 = SLICE(gp1_gp2, word16, 16);
					word16 gp2 = (word16) gp1_gp2;
					if (Z)
					{
						ptr16 gp1_n;
						ptr16 gp2_n;
						word16 gp0_n = fn000003B4(gp1_gp2, gp12_gp13, gp9, gp10, gp11, gp14, out gp1_n, out gp2_n);
						gp1Out = gp1_n;
						gp2Out = gp2_n;
						return gp0_n;
					}
					else
					{
						ptr16 gp1_n;
						ptr16 gp2_n;
						word16 gp0_n = fn000003B3(gp12_gp13, gp1, gp2, gp9, gp10, gp11, gp14, out gp1_n, out gp2_n);
						gp1Out = gp1_n;
						gp2Out = gp2_n;
						return gp0_n;
					}
}

// 000003B3: Register word16 fn000003B3(Sequence int32 gp12_gp13, Register word16 gp1, Register word16 gp2, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn032A
//      fn000003B2
word16 fn000003B3(int32 gp12_gp13, word16 gp1, word16 gp2, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					ptr16 gp1_n;
					ptr16 gp2_n;
					word16 gp0_n = fn000003B4(SEQ(gp1, gp2 + 0x01), gp12_gp13, gp9, gp10, gp11, gp14, out gp1_n, out gp2_n);
					gp1Out = gp1_n;
					gp2Out = gp2_n;
					return gp0_n;
}

// 000003B4: Register word16 fn000003B4(Sequence word32 gp1_gp2, Sequence int32 gp12_gp13, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn032A
//      fn000003B2
word16 fn000003B4(word32 gp1_gp2, int32 gp12_gp13, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					int32 gp1_gp2_n = -gp1_gp2;
					word16 gp5_n = (word16) gp1_gp2_n - (word16) (gp1_gp2_n / 0x0A) * 0x0A;
					ptr16 gp1_n;
					ptr16 gp2_n;
					word16 gp0_n = fn000003C0(gp12_gp13, 0x0A, gp5_n + 0x30, gp9 + 0x01, gp10, gp11, gp14, out gp1_n, out gp2_n);
					gp1Out = gp1_n;
					gp2Out = gp2_n;
					return gp0_n;
}

// 000003C0: Register word16 fn000003C0(Sequence int32 gp12_gp13, Sequence int32 gp7_gp8, Register word16 gp5, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn034E
//      fn000003B4
word16 fn000003C0(int32 gp12_gp13, int32 gp7_gp8, word16 gp5, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					if (Z)
					{
						ptr16 gp2_n;
						ptr16 gp1_n;
						word16 gp0_n = fn000003C5(gp12_gp13, gp7_gp8, gp5, gp9, gp10, gp11, gp14, out gp1_n, out gp2_n);
						gp1Out = gp1_n;
						gp2Out = gp2_n;
						return gp0_n;
					}
					else
					{
						ptr16 gp1_n;
						ptr16 gp2_n;
						word16 gp0_n = fn000003C1(gp12_gp13, gp7_gp8, gp5, gp9, gp10, gp11, gp14, out gp1_n, out gp2_n);
						gp1Out = gp1_n;
						gp2Out = gp2_n;
						return gp0_n;
					}
}

// 000003C1: Register word16 fn000003C1(Sequence int32 gp12_gp13, Sequence int32 gp7_gp8, Register word16 gp5, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn032A
//      fn000003C0
word16 fn000003C1(int32 gp12_gp13, int32 gp7_gp8, word16 gp5, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					gp11->t0000 = SEQ((byte) gp5, gp11->t0000);
					ptr16 gp2_n;
					ptr16 gp1_n;
					word16 gp0_n = fn000003C5(gp12_gp13, gp7_gp8, gp5, gp9, gp10, gp11 - 0x01, gp14, out gp1_n, out gp2_n);
					gp1Out = gp1_n;
					gp2Out = gp2_n;
					return gp0_n;
}

// 000003C5: Register word16 fn000003C5(Sequence int32 gp12_gp13, Sequence int32 gp7_gp8, Register word16 gp5, Register cui16 gp9, Register word16 gp10, Register (ptr16 Eq_n) gp11, Register Eq_n gp14, Register out ptr16 gp1Out, Register out ptr16 gp2Out)
// Called from:
//      fn032A
//      fn000003C0
word16 fn000003C5(int32 gp12_gp13, int32 gp7_gp8, word16 gp5, cui16 gp9, word16 gp10, struct Eq_n * gp11, Eq_n gp14, ptr16 & gp1Out, ptr16 & gp2Out)
{
					byte bArg01_n = (byte) wArg00;
					byte bArg02 = (byte) wArg02;
					gp11->t0000 = SEQ(gp11->b0001, (byte) gp5);
					int32 gp12_gp13_n = gp12_gp13 / gp7_gp8;
					if (gp12_gp13_n != 0x00)
					{
						ptr16 gp2_n;
						word16 gp14_n;
						word16 gp0_n = fn00000418(SEQ(gp12_gp13_n, gp14), out gp2_n, out gp14_n);
						gp1Out = gp1;
						gp2Out = gp2_n;
						return gp0_n;
					}
					else
					{
						if (Test(EQ,(gp9 + 0x01 & 0x8000) == 0x00))
							gp11->t0000 = SEQ(gp11->b0001, (byte) gp10);
						else
							gp11->t0000 = SEQ((byte) gp10, gp11->t0000);
						gp1Out = SEQ(bArg01_n, bArg02);
						gp2Out = wArg02;
						return wArg00;
					}
}

// 03E0: Register (ptr16 Eq_n) fn03E0(Sequence int32 gp1_gp2, Register (ptr16 Eq_n) gp0, Register cui16 gp3, Register out ptr16 gp1Out, Register out ptr16 gp2Out, Register out ptr16 gp3Out, Register out ptr16 gp8Out, Register out ptr16 gp12Out, Register out ptr16 gp13Out, Register out ptr16 gp14Out)
// Called from:
//      fn032A
//      fn04AE
struct Eq_n * fn03E0(int32 gp1_gp2, struct Eq_n * gp0, cui16 gp3, ptr16 & gp1Out, ptr16 & gp2Out, ptr16 & gp3Out, ptr16 & gp8Out, ptr16 & gp12Out, ptr16 & gp13Out, ptr16 & gp14Out)
{
					cui16 gp2 = (word16) gp1_gp2;
					struct Eq_n * gp1 = SLICE(gp1_gp2, word16, 16);
					gp0[0x0A] = (struct Eq_n) 0x00;
					byte bLoc0C_n = (byte) gp2;
					ptr16 gp14_n = fn03EC(0x00, 11, gp0, gp1, gp2, gp3);
					gp1Out = SEQ((byte) gp1, bLoc0C_n);
					byte bLoc0B_n = (byte) gp3;
					gp2Out = SEQ(bLoc0C_n, bLoc0B_n);
					gp3Out = SEQ(bLoc0B_n, (byte) gp4);
					gp8Out = SEQ((byte) gp8, (byte) gp9);
					byte bLoc01_n = (byte) gp13;
					gp12Out = SEQ((byte) gp12, bLoc01_n);
					gp13Out = SEQ(bLoc01_n, (byte) gp14);
					gp14Out = gp14_n;
					return gp1;
}

// 03EC: Register cui16 fn03EC(Register cui16 gp0, Register word16 gp1, Register (ptr16 Eq_n) gp11, Register (ptr16 Eq_n) gp12, Register cui16 gp13, Register cui16 gp14)
// Called from:
//      fn03E0
cui16 fn03EC(cui16 gp0, word16 gp1, struct Eq_n * gp11, struct Eq_n * gp12, cui16 gp13, cui16 gp14)
{
					while (true)
					{
						Eq_n gp12_gp13_gp14_n;
						word16 gp0_n;
						if (Test(NE,(gp12 & 0x01) == 0x00))
						{
							if (Test(EQ,(gp12 & 0x02) == 0x00))
							{
								gp0_n = 0x2D20;
								gp12_gp13_gp14_n = SEQ(gp12, gp13, gp14) * g_r0610;
								goto l00000406;
							}
						}
						else
						{
							gp0 = gp0 | gp12 | gp13 | gp14;
							if (gp0 == 0x00 || Test(NE,(gp12 & 0x02) == 0x00))
							{
								gp0_n = 0x2B20;
								gp12_gp13_gp14_n = SEQ(gp12, gp13, gp14);
l00000406:
								gp11->t0000.u1 = gp0_n;
								int16 gp2_n = 0x00;
								Eq_n gp12_gp13_gp14_n = gp12_gp13_gp14_n;
								if (Test(NE,(SLICE(gp12_gp13_gp14_n, word16, 16) & 0x0100) == 0x00))
								{
									cui16 gp14_n;
									word16 gp2_n;
									fn00000418(gp12_gp13_gp14_n, out gp2_n, out gp14_n);
									return gp14_n;
								}
								else
								{
									for (; gp12_gp13_gp14_n >= g_t060A; gp12_gp13_gp14_n /= g_t060A)
										++gp2_n;
									if (gp1 != 0x06)
										gp11[8] = (struct Eq_n) 17707;
									else
										gp11[5] = (struct Eq_n) 17707;
									int16 gp2_n = gp2_n / 0x0A;
									Eq_n gp2_n = __xbr(gp2_n) | gp2_n % 0x0A;
									if (gp1 != 0x06)
										gp11[9] = (struct Eq_n) (gp2_n | 0x3030);
									else
										gp11[6] = (struct Eq_n) (gp2_n | 0x3030);
									int32 gp2_gp3_n = (int32) gp12_gp13_gp14_n;
									gp11->t0000.u1 = SEQ(gp11[1], (byte) (word16) gp2_gp3_n + 0x30);
									gp11[1] = (struct Eq_n) SEQ(0x2E, gp11[1]);
									cui16 gp7_n = 0x00;
									real48 gp12_gp13_gp14_n = gp12_gp13_gp14_n - (real48) gp2_gp3_n;
									do
									{
										real48 gp12_gp13_gp14_n = gp12_gp13_gp14_n * g_t060A;
										int32 gp2_gp3_n = (int32) SEQ((word32) gp12_gp13_gp14_n, (word16) gp12_gp13_gp14_n);
										gp12_gp13_gp14_n = gp12_gp13_gp14_n - (real48) gp2_gp3_n;
										word16 gp3_n = (word16) gp2_gp3_n;
										cui16 gp14_n = (word16) gp12_gp13_gp14_n;
										++gp7_n;
										if ((gp7_n & 0x8000) != 0x00)
											gp11[1] = (struct Eq_n) SEQ((byte) gp3_n + 0x30, gp11[1]);
										else
										{
											gp11[1] = (struct Eq_n) SEQ(gp11[2], (byte) gp3_n + 0x30);
											++gp11;
										}
										--gp1;
									} while (gp1 != 0x00);
									gp11[1] = (struct Eq_n) 0x2020;
									return gp14_n;
								}
							}
						}
						gp12 = &g_t0007;
						if (gp1 != 0x06)
							gp12 = &g_t000A;
						__mov(gp11, 1555);
					}
}

// 00000418: Register word16 fn00000418(Sequence Eq_n gp12_gp13_gp14, Register out ptr16 gp2Out, Register out ptr16 gp14Out)
// Called from:
//      fn032A
//      fn03EC
word16 fn00000418(Eq_n gp12_gp13_gp14, ptr16 & gp2Out, ptr16 & gp14Out)
{
					Eq_n gp12_gp13_gp14_n = gp12_gp13_gp14;
					do
					{
						gp12_gp13_gp14_n *= g_t060A;
						word16 gp0_n = SLICE(gp12_gp13_gp14_n, word16, 32) + 0x1F;
						struct Eq_n * gp12_n = SLICE(gp12_gp13_gp14_n, word16, 32);
						ptr16 gp14_n = (word16) gp12_gp13_gp14_n;
					} while (gp12_gp13_gp14_n < g_t060D);
					ptr16 gp2_n = gp12_n->ptr0037;
					fn045A(gp0_n);
					gp2Out = gp2_n;
					gp14Out = gp14_n;
					return gp0_n;
}

// 045A: void fn045A(Register word16 gp0)
// Called from:
//      fn0111
//      fn03EC
//      fn045D
//      fn04B9
void fn045A(word16 gp0)
{
					__console_output(gp0);
}

// 045D: Register word16 fn045D(Register (ptr16 byte) gp0, Register out ptr16 gp10Out, Register out ptr16 gp11Out)
// Called from:
//      fn04AE
word16 fn045D(byte * gp0, ptr16 & gp10Out, ptr16 & gp11Out)
{
					byte bArg00_n = (byte) gp12;
					byte bLoc01_n = (byte) gp11;
					byte * gp11_n = gp0;
					word16 gp0_n = 0x00;
					while (true)
					{
						byte bLoc02_n = (byte) gp10;
						word16 gp0_n = SEQ(*gp11_n, (byte) gp0_n);
						if (gp0_n == 0x00)
							break;
						fn045A(gp0_n);
						gp0_n = SEQ(*gp11_n, *gp11_n);
						if (gp0_n == 0x00)
							break;
						fn045A(gp0_n);
						++gp11_n;
					}
					gp10Out = SEQ(bLoc02_n, bLoc01_n);
					gp11Out = SEQ(bLoc01_n, bArg00_n);
					return gp10;
}

// 04AE: Register word16 fn04AE(Sequence int32 gp0_gp1, Register cui16 gp2, Register out ptr16 gp8Out, Register out ptr16 gp9Out, Register out ptr16 gp10Out, Register out ptr16 gp11Out, Register out ptr16 gp14Out)
// Called from:
//      fn0111
word16 fn04AE(int32 gp0_gp1, cui16 gp2, ptr16 & gp8Out, ptr16 & gp9Out, ptr16 & gp10Out, ptr16 & gp11Out, ptr16 & gp14Out)
{
					word16 gp12_n;
					word16 gp13_n;
					ptr16 gp14_n;
					word16 gp3_n;
					ptr16 gp8_n;
					ptr16 gp10_n;
					ptr16 gp11_n;
					word16 gp1_n;
					word16 gp2_n;
					ptr16 gp9_n = fn045D(fn03E0(gp0_gp1, &g_tFFFF813C, gp2, out gp1_n, out gp2_n, out gp3_n, out gp8_n, out gp12_n, out gp13_n, out gp14_n), out gp10_n, out gp11_n);
					gp8Out = gp8_n;
					gp9Out = gp9_n;
					gp10Out = gp10_n;
					gp11Out = gp11_n;
					gp14Out = gp14_n;
					return gp3_n;
}

// 04B9: void fn04B9(Register (ptr16 Eq_n) gp0)
// Called from:
//      fn0111
void fn04B9(struct Eq_n * gp0)
{
					struct Eq_n * gp1_n = gp0;
					while (true)
					{
						word16 gp0_n = gp1_n->w0000;
						if (gp0_n == 0x00)
							break;
						fn045A(gp0_n);
						++gp1_n;
					}
}

real48 g_r05AB = ;
real48 g_r05AE = ;
real48 g_r05B1 = ;
real48 g_r05B4 = ;
Eq_n g_t060A = // 060A
					{
						;
Eq_n g_t060D = // 060D
						{
							;
real48 g_r0610 = ;
