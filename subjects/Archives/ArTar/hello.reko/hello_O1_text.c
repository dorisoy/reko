// hello_O1_text.c
// Generated by decompiling hello_O1
// using Reko decompiler version 0.11.1.0.

#include "hello_O1.h"

// 0000000000001080: void _start(Register (ptr64 Eq_n) rdx, Stack word32 dwArg00)
void _start(void (* rdx)(), word32 dwArg00)
{
	void * fp;
	word64 qwArg00;
	__align_stack<word64>((char *) fp + 8);
	__libc_start_main(&g_t11E0, (int32) qwArg00, (char *) fp + 8, &g_t1280, &g_t12E0, rdx, fp);
	__hlt();
}

// 00000000000010B0: void deregister_tm_clones()
// Called from:
//      __do_global_dtors_aux
void deregister_tm_clones()
{
	if (0x4048 == 0x4048 || _ITM_deregisterTMCloneTable == null)
		return;
	_ITM_deregisterTMCloneTable();
}

// 00000000000010E0: void register_tm_clones()
// Called from:
//      frame_dummy
void register_tm_clones()
{
	Eq_n rsi_n = 0x4048 - 0x4048;
	if ((rsi_n >>u 0x3F) + (rsi_n >> 0x03) >> 0x01 == 0x00 || _ITM_registerTMCloneTable == null)
		return;
	_ITM_registerTMCloneTable();
}

// 0000000000001120: void __do_global_dtors_aux()
void __do_global_dtors_aux()
{
	if (g_b4048 != 0x00)
		return;
	if (__cxa_finalize != 0x00)
		__cxa_finalize(g_qw4040);
	deregister_tm_clones();
	g_b4048 = 0x01;
}

// 0000000000001160: void frame_dummy()
// Called from:
//      __libc_csu_init
void frame_dummy()
{
	register_tm_clones();
}

// 0000000000001169: Register word128 Q_rsqrt(Register word128 xmm0, Stack int32 dwArg00)
// Called from:
//      main
word128 Q_rsqrt(word128 xmm0, int32 dwArg00)
{
	word128 xmm2_n = (word128) (0x5F3759DF - (word32) (SEQ(dwArg00, (real32) xmm0) >> 0x01));
	return SEQ(0, (1.5F - (((real32) xmm0 * 0.5F) * (real32) xmm2_n) * (real32) xmm2_n) * (real32) xmm2_n);
}

// 00000000000011A6: Register word128 lib_rsqrt(Register word128 xmm0)
// Called from:
//      main
word128 lib_rsqrt(word128 xmm0)
{
	if ((real32) xmm0 >= 0.0F)
		return SEQ(0, 1.0F /32 fsqrt((real32) xmm0));
	sqrtf((real32) xmm0);
	return SEQ(0, 1.0F / sqrtf((real32) xmm0));
}

// 00000000000011E0: void main(Register (ptr64 Eq_n) rsi)
void main(struct Eq_n * rsi)
{
	int32 dwLoc20;
	printf("Hello %s, I'm inside an archive.\n", rsi->ptr0008);
	puts("Inverse square root computation.");
	char * rdi_n = rsi->ptr0010;
	word128 xmm0_n = SEQ(0, strtof(rdi_n, null));
	real32 rLoc10_n = strtof(rdi_n, null);
	real32 rLoc0C_n = (real32) Q_rsqrt(xmm0_n, dwLoc20);
	real32 rLoc10_n = (real32) lib_rsqrt(SEQ(0, rLoc10_n));
	printf("    Quick:   %g\n", (real64) rLoc0C_n);
	printf("    Library: %g\n", (real64) rLoc10_n);
}

// 0000000000001280: void __libc_csu_init(Register word64 rdx, Register word64 rsi, Register word32 edi)
void __libc_csu_init(word64 rdx, word64 rsi, word32 edi)
{
	word64 rdi;
	word32 edi = (word32) rdi;
	_init();
	int64 rbp_n = 0x3DE0 - 0x3DD8;
	if (rbp_n >> 0x03 != 0x00)
	{
		Eq_n rbx_n = 0x00;
		do
		{
			(*((char *) g_a3DD8 + rbx_n * 0x08))();
			rbx_n = (word64) rbx_n.u1 + 1;
		} while (rbp_n >> 0x03 != rbx_n);
	}
}

// 00000000000012E0: void __libc_csu_fini()
void __libc_csu_fini()
{
}

