// flags_TEXT_text.c
// Generated by decompiling flags
// using Reko decompiler version 0.9.2.3.

#include "flags_TEXT_text.h"

// 0000000000000F9E: void foo(Register byte sil, Register (ptr64 word32) rdi)
void foo(byte sil, word32 * rdi)
{
	if (((byte) (uint64) ((word32) (uint64) *rdi >> 0x0A) ^ sil) != 0x00)
		return;
	bar();
}

// 0000000000000FB4: void bar()
// Called from:
//      foo
void bar()
{
}

