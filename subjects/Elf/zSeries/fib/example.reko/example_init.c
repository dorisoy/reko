// example_init.c
// Generated by decompiling example
// using Reko decompiler version 0.11.1.0.

#include "example.h"

// 0000000000000560: Register word64 _init(Register word64 r6, Register word64 r7, Register word64 r8, Register word64 r9, Register word64 r10, Register word64 r11, Register word64 r13, Register out ptr64 r8Out, Register out ptr64 r9Out, Register out ptr64 r10Out, Register out ptr64 r12Out, Register out ptr64 r13Out)
// Called from:
//      __libc_csu_init
word64 _init(word64 r6, word64 r7, word64 r8, word64 r9, word64 r10, word64 r11, word64 r13, ptr64 & r8Out, ptr64 & r9Out, ptr64 & r10Out, ptr64 & r12Out, ptr64 & r13Out)
{
	ptr64 fp;
	struct Eq_n * r15_n = fp - 320;
	<anonymous> * r1_n = g_ptr2038;
	if (r1_n != null)
		r1_n();
	ptr64 v16_n = (char *) r15_n + 0x00D0;
	word64 r6_n;
	ptr64 r8_n;
	ptr64 r9_n;
	ptr64 r10_n;
	ptr64 r12_n;
	ptr64 r13_n;
	r15_n->ptr0110();
	r8Out = r8_n;
	r9Out = r9_n;
	r10Out = r10_n;
	r12Out = r12_n;
	r13Out = r13_n;
	return r6_n;
}

