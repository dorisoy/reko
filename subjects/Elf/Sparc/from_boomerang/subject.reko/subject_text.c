// subject_text.c
// Generated by decompiling subject.exe
// using Reko decompiler version 0.10.1.0.

#include "subject.h"

// 00010958: void _start(Register (ptr32 Eq_n) g1, Register word32 o2, Register word32 o3, Register word32 o4, Register word32 o5, Register (ptr32 Eq_n) o7, Register ui32 fsr, Stack ui32 dwArg40)
void _start(void (* g1)(), word32 o2, word32 o3, word32 o4, word32 o5, struct Eq_n * o7, ui32 fsr, ui32 dwArg40)
{
	___Argv = fp + 0x44;
	environ = fp + 0x44 + ((dwArg40 << 0x02) + 0x04);
	if (false)
	{
		g_dw20E58 = fsr;
		g_dw20E58 &= 0x303FFFFF;
		if (false)
			__fnonstd_used = 0x01;
	}
	if (g1 == null)
	{
		atexit(&g_t10CB8);
		_init(0x00010CB8, 0x00020C00, o2, o3, o4, o5, o7);
	}
	else
		atexit(g1);
}

// 00010A5C: void func1()
void func1()
{
}

// 00010A74: void func2()
void func2()
{
}

// 00010A8C: void func3()
void func3()
{
}

// 00010AA4: void func4()
void func4()
{
}

// 00010ABC: void func5()
void func5()
{
}

// 00010AD4: void func6()
void func6()
{
}

// 00010AEC: void func7()
void func7()
{
}

// 00010B04: void func8()
void func8()
{
}

// 00010B0C: void main(Register int32 o0)
// Called from:
//      _start
void main(int32 o0)
{
	word32 o0_n = 0x01;
	if (o0 <= 0x01)
		o0_n = 0x00;
	word32 o0_n;
	if (o0_n != 0x00)
		o0_n = 68188;
	else
		o0_n = 68212;
	word32 o3_n;
	if (o0_n != 0x00)
		o3_n = 68236;
	else
		o3_n = 0x00010AA4;
	word32 o2_n;
	if (o0_n != 0x00)
		o2_n = 68284;
	else
		o2_n = 68308;
	word32 o1_n;
	if (o0_n != 0x00)
		o1_n = 68332;
	else
		o1_n = 0x00010B04;
	bool v24_n;
	word32 i1_n;
	if (o0_n != 0x00)
	{
		if (o0_n != 68188 || (o3_n != 68236 || (o2_n != 68284 || o1_n != 68332)))
		{
			i1_n = 0x00;
			v24_n = true;
			goto l00010C44;
		}
		i1_n = 0x01;
	}
	else if (o0_n == 68212 && (o3_n == 0x00010AA4 && (o2_n == 68308 && o1_n == 0x00010B04)))
		i1_n = 0x01;
	else
		i1_n = 0x00;
	v24_n = i1_n == 0x00;
l00010C44:
	if (!v24_n)
		printf("Pass\n");
	else
		printf("Failed!\n");
}

