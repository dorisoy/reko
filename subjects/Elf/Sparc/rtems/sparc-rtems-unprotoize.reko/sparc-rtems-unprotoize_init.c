// sparc-rtems-unprotoize_init.c
// Generated by decompiling sparc-rtems-unprotoize
// using Reko decompiler version 0.11.1.0.

#include "sparc-rtems-unprotoize.h"

// 00016EC8: Register word32 _init(Register word32 o3, Register word32 o4, Register word32 o5, Register word32 o7)
// Called from:
//      _start
word32 _init(word32 o3, word32 o4, word32 o5, word32 o7)
{
	frame_dummy(o7);
	return __do_global_ctors_aux(o3, o4, o5, o7);
}

