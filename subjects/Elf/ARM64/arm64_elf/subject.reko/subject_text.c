// subject_text.c
// Generated by decompiling subject.exe
// using Reko decompiler version 0.11.1.0.

#include "subject.h"

Eq_n g_t0FC0 = ??/* Unexpected function type (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char)))) */ ; // 0000000000000FC0
// 0000000000001460: void fn0000000000001460(Register (ptr64 Eq_n) x0, Stack word32 dwArg00)
void fn0000000000001460(void (* x0)(), word32 dwArg00)
{
	void * fp;
	word64 qwArg00;
	__libc_start_main(g_ptr1FFE8, (int32) qwArg00, (char *) fp + 8, g_ptr1FFE0, g_ptr1FF98, x0, fp);
	abort();
}

// 0000000000001498: void fn0000000000001498()
// Called from:
//      fn0000000000000D88
void fn0000000000001498()
{
	if (g_qw1FFD0 == 0x00)
		return;
	__gmon_start__();
}

// 00000000000014B0: void fn00000000000014B0()
void fn00000000000014B0()
{
	if (0x00020008 - 0x00020008 == 0x00)
		return;
	<anonymous> * x1_n = g_ptr1FFA0;
	if (x1_n == null)
		return;
	x1_n();
}

Eq_n g_t16B8 = ??/* Unexpected function type (fn void ()) */ ; // 00000000000016B8
Eq_n g_t1738 = ??/* Unexpected function type (fn void ()) */ ; // 0000000000001738
// 0000000000001740: void fn0000000000001740(Register (ptr64 Eq_n) x0)
void fn0000000000001740(void (* x0)(void * x0))
{
	void * x2_n = null;
	void ** x1_n = g_ptr1FFD8;
	if (x1_n != null)
		x2_n = (void *) *x1_n;
	__cxa_atexit(x0, null, x2_n);
}

