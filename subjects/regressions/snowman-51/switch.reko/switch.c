// switch.c
// Generated by decompiling switch.dll
// using Reko decompiler version 0.10.1.0.

#include "switch.h"

// 10071000: Register (ptr32 char) get(Stack uint32 n)
char * get(uint32 n)
{
	if (n > 0x02)
		return "other";
	switch (n)
	{
	case ~0x00:
		return "zero";
	case 0x00:
		return "one";
	case 0x01:
		return "two";
	case 0x02:
		return "three";
	}
}

// 10071080: Register Eq_n DllMain(Stack Eq_n hModule, Stack Eq_n dwReason, Stack Eq_n lpReserved)
Eq_n DllMain(Eq_n hModule, Eq_n dwReason, Eq_n lpReserved)
{
	return 0x01;
}

