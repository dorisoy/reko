// Rmm68jx_code.c
// Generated by decompiling Rmm68jx.bin
// using Reko decompiler version 0.10.2.0.

#include "Rmm68jx.h"

// 0000: void fn0000(Register (ptr16 Eq_n) SP)
void fn0000(struct Eq_n * SP)
{
	*(word16 *) ~0xED = 0x8004;
	*(word16 *) ~0xED = 0x8004;
	SP->wFFFFFFFE = 0x00;
	SP->wFFFFFFFC = 0x00;
	SP->wFFFFFFFA = 0x34;
}

// 0034: void fn0034()
void fn0034()
{
	__disable_watchdog_timer();
	__end_of_initialization();
	word16 S0TIC_n = 0x00;
	word16 S0RIC_n = 0x00;
	do
	{
		while (true)
		{
			fn0128(&g_b013E, S0TIC_n);
			S0RIC_n = fn011C(S0RIC_n);
			cui16 r0_n = <invalid>;
			if ((r0_n & 223) != 0x44)
				break;
			while (true)
			{
				do
				{
					cui16 r0_n = <invalid>;
					S0RIC_n = fn011C(S0RIC_n);
				} while ((byte) r0_n == 0x3A);
				cui16 r0_n = <invalid>;
				word16 S0RIC_n = fn011C(S0RIC_n);
				if ((byte) r0_n == 0x00)
					break;
				cui16 r0_n = <invalid>;
				cui16 r0_n = <invalid>;
				cu16 r2_n = r0_n & 0xFF;
				word16 S0RIC_n = fn011C(fn011C(fn011C(S0RIC_n)));
				byte * r1_n = SEQ((byte) r0_n, (byte) r0_n);
				do
				{
					cui16 r0_n = <invalid>;
					S0RIC_n = fn011C(S0RIC_n);
					*r1_n = (byte) r0_n;
					++r1_n;
					r2_n = r2_n - 1;
					r2_n = r2_n;
				} while (r2_n > 0x01);
				S0RIC_n = fn011C(S0RIC_n);
				S0TIC_n = fn0110(S0TIC_n);
			}
			S0RIC_n = fn011C(fn011C(fn011C(fn011C(S0RIC_n))));
			S0TIC_n = fn0110(S0TIC_n);
		}
	} while ((r0_n & 223) != 0x47);
	fn011C(fn011C(S0RIC_n));
	cui16 r0_n = <invalid>;
	*(word16 *) ~0x0401 = SEQ((byte) r0_n, (byte) fp);
}

// 0110: Register word16 fn0110(Register word16 S0TIC)
// Called from:
//      fn0034
//      fn0128
word16 fn0110(word16 S0TIC)
{
	*(ptr16 *) ~0x014F = fp;
	do
		;
	while (!__bit(S0TIC, 7));
	return __bit_clear(S0TIC, 7);
}

// 011C: Register word16 fn011C(Register word16 S0RIC)
// Called from:
//      fn0034
word16 fn011C(word16 S0RIC)
{
	do
		;
	while (!__bit(S0RIC, 7));
	return __bit_clear(S0RIC, 7);
}

// 0128: void fn0128(Register (ptr16 byte) r1, Register word16 S0TIC)
// Called from:
//      fn0034
void fn0128(byte * r1, word16 S0TIC)
{
	while (*r1 != 0x00)
	{
		S0TIC = fn0110(S0TIC);
		++r1;
	}
}

byte g_b013E = 0x0D; // 013E
