// Executable_text.c
// Generated by decompiling Executable.exe
// using Reko decompiler version 0.10.2.0.

#include "Executable.h"

// 00401000: Register word32 fn00401000()
// Called from:
//      Win32CrtStartup
word32 fn00401000()
{
	InitializeCriticalSection(&exported_critical_section);
	fn00401060(0x00402108);
	slow_and_safe_increment(0x01);
	fn00401060(0x00402108);
	fn00401060(0x00402108);
	return 0x00;
}

// 00401050: Register ptr32 fn00401050()
// Called from:
//      fn00401060
//      fn0040173F
ptr32 fn00401050()
{
	return 0x00403378;
}

// 00401060: void fn00401060(Stack word32 dwArg04)
// Called from:
//      fn00401000
void fn00401060(word32 dwArg04)
{
	struct Eq_n * esp_n;
	word32 eax_n;
	_acrt_iob_func();
	esp_n->ptr0000 = fp + 0x08;
	esp_n->dwFFFFFFFC = 0x00;
	esp_n->dwFFFFFFF8 = dwArg04;
	esp_n->dwFFFFFFF4 = eax_n;
	struct Eq_n * eax_n = fn00401050();
	esp_n->dwFFFFFFF0 = eax_n->dw0004;
	esp_n->dwFFFFFFEC = eax_n->dw0000;
	_stdio_common_vfprintf();
}

// 004012CE: Register Eq_n Win32CrtStartup()
Eq_n Win32CrtStartup()
{
	word24 ebx_24_8_n = SLICE(ebx, word24, 8);
	fn00401663();
	struct Eq_n * ebp_n = fn00401980(ebx, esi, edi, dwLoc0C, 0x14);
	word32 * esp_n = fp - 8;
	if (fn00401474(edx, 0x01) == 0x00)
	{
l00401177:
		esp_n -= 4;
		*esp_n = 0x07;
		fn00401774(*esp_n);
	}
	ebp_n->bFFFFFFE7 = 0x00;
	ebp_n->dwFFFFFFFC = 0x00;
	word32 edx_n;
	ebp_n->tFFFFFFDC = fn0040143F(out edx_n);
	struct Eq_n * ebp_n = ebp_n;
	word32 eax_n = g_dw403334;
	word32 ebx_n = SEQ(ebx_24_8_n, 0x00);
	if (eax_n != 0x01)
	{
		Eq_n eax_n;
		struct Eq_n * esp_n;
		if (eax_n == 0x00)
		{
			g_dw403334 = 0x01;
			struct Eq_n * esp_n = esp_n - 4;
			esp_n->ptr0000 = &g_t4020EC;
			esp_n->ptrFFFFFFFC = &g_t4020E0;
			esp_n = (struct Eq_n *) ((char *) &esp_n->ptr0000 + 4);
			if (_initterm_e(esp_n->ptrFFFFFFFC, esp_n->ptr0000) != 0x00)
			{
				ebp_n->dwFFFFFFFC = ~0x01;
				eax_n.u0 = 0xFF;
				goto l004012C8;
			}
			esp_n->ptr0000 = &g_t4020DC;
			esp_n->ptrFFFFFFFC = &g_t4020D4;
			_initterm(esp_n->ptrFFFFFFFC, esp_n->ptr0000);
			g_dw403334 = 0x02;
		}
		else
		{
			ebp_n->bFFFFFFE7 = 0x01;
			ebx_n = SEQ(ebx_24_8_n, 0x01);
		}
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000 = ebp_n->tFFFFFFDC;
		fn004015CE(esp_n->t0000);
		ptr32 esp_n = (char *) &esp_n->t0000 + 4;
		Eq_n eax_n = fn00401768();
		Eq_n edi_n = 0x00;
		if (*eax_n != 0x00)
		{
			esp_n->t0000 = eax_n;
			esp_n = (char *) &esp_n->t0000 + 4;
			<anonymous> ** esi_n;
			if (fn00401544(ebx_n, eax_n, 0x00, out edx_n, out ebx_n, out ebp_n, out esi_n, out edi_n) != 0x00)
			{
				esp_n->t0000 = edi_n;
				esp_n->dwFFFFFFFC = 0x02;
				esp_n->tFFFFFFF8 = edi_n;
				<anonymous> * esi_n = *esi_n;
				fn00401976();
				esi_n();
			}
		}
		Eq_n eax_n = fn0040176E();
		if (*eax_n != edi_n)
		{
			union Eq_n * esp_n = esp_n - 4;
			*esp_n = (union Eq_n *) eax_n;
			union Eq_n * esi_n;
			word32 edi_n;
			if (fn00401544(ebx_n, eax_n, edi_n, out edx_n, out ebx_n, out ebp_n, out esi_n, out edi_n) != 0x00)
			{
				*esp_n = *esi_n;
				register_thread_local_exe_atexit_callback();
			}
		}
		word32 * eax_n;
		word32 edx_n;
		_p___argv();
		word32 * eax_n;
		word32 edx_n;
		_p___argc();
		struct Eq_n * esp_n;
		Eq_n eax_n;
		word32 edx_n;
		get_initial_narrow_environment();
		esp_n->tFFFFFFFC = eax_n;
		esp_n->dwFFFFFFF8 = *eax_n;
		esp_n->dwFFFFFFF4 = *eax_n;
		Eq_n eax_n = fn00401000();
		byte bl_n = (byte) ebx_n;
		struct Eq_n * esp_n = esp_n;
		if (fn0040188F() == 0x00)
		{
			esp_n->tFFFFFFFC = eax_n;
			exit(esp_n->tFFFFFFFC);
		}
		if (bl_n == 0x00)
			cexit();
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000.u1 = 0x00;
		esp_n->dwFFFFFFFC = 0x01;
		fn004015EB(esp_n->t0000);
		ebp_n->dwFFFFFFFC = ~0x01;
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		eax_n = eax_n;
l004012C8:
		word32 ebp_n;
		word32 edi_n;
		word32 esi_n;
		fn004019C6(ebp_n, esp_n->tFFFFFFFC, out ebp_n, out esi_n, out edi_n);
		return eax_n;
	}
	goto l00401177;
}

// 004012D8: void fn004012D8(Stack (ptr32 Eq_n) dwArg04)
void fn004012D8(struct _EXCEPTION_POINTERS * dwArg04)
{
	SetUnhandledExceptionFilter(null);
	UnhandledExceptionFilter(dwArg04);
	TerminateProcess(GetCurrentProcess(), 0xC0000409);
}

// 004013FB: Register (ptr32 Eq_n) fn004013FB(Stack (ptr32 Eq_n) dwArg04, Stack uint32 dwArg08, Register out (ptr32 Eq_n) edxOut)
// Called from:
//      fn00401544
struct Eq_n * fn004013FB(struct Eq_n * dwArg04, uint32 dwArg08, struct Eq_n & edxOut)
{
	struct Eq_n * eax_n;
	struct Eq_n * ecx_n = dwArg04 + dwArg04->dw003C / 64;
	struct Eq_n * edx_n = &ecx_n->w0014 + 2 + (word32) ecx_n->w0014 / 22;
	struct Eq_n * esi_n = edx_n + (word32) ecx_n->w0006;
	for (; edx_n != esi_n; ++edx_n)
	{
		if (dwArg08 >= edx_n->dw000C && dwArg08 < edx_n->dw0008 + edx_n->dw000C)
		{
			eax_n = edx_n;
			goto l00401438;
		}
	}
	eax_n = null;
l00401438:
	edxOut = edx_n;
	return eax_n;
}

// 0040143F: Register byte fn0040143F(Register out ptr32 edxOut)
// Called from:
//      Win32CrtStartup
byte fn0040143F(ptr32 & edxOut)
{
	word32 eax_n = fn00401B98();
	if (eax_n != 0x00)
	{
		ptr32 edx_n = fs->ptr0018->ptr0004;
		do
		{
			__lock();
			ptr32 eax_n;
			__cmpxchg(g_dw403338, edx_n, 0x00, out eax_n);
			if (eax_n == 0x00)
			{
				edxOut = edx_n;
				return 0x00;
			}
		} while (edx_n != eax_n);
		edxOut = edx_n;
		return 0x01;
	}
	else
	{
		edxOut = edx;
		return 0x00;
	}
}

// 00401474: Register byte fn00401474(Register word32 edx, Stack word32 dwArg04)
// Called from:
//      Win32CrtStartup
byte fn00401474(word32 edx, word32 dwArg04)
{
	if (dwArg04 == 0x00)
		g_b403354 = 0x01;
	fn004019FE(edx);
	if (fn00401C48() == 0x00)
		return 0x00;
	if (fn00401C48() != 0x00)
		return 0x01;
	fn00401C48();
	return 0x00;
}

// 004014AD: void fn004014AD(Register word32 ebx, Register Eq_n edi, Stack Eq_n dwArg04)
void fn004014AD(word32 ebx, Eq_n edi, Eq_n dwArg04)
{
	if (dwArg04 == 0x00 || dwArg04 == 0x01)
	{
		if (fn00401B98() != 0x00 && dwArg04 == 0x00)
		{
			word32 * esp_n;
			word32 eax_n;
			word32 edx_n;
			initialize_onexit_table();
			if (eax_n == 0x00)
			{
				*esp_n = 0x00403348;
				word32 edx_n;
				initialize_onexit_table();
			}
		}
		else
		{
			ui32 eax_n = __ror<word32,byte>(~0x00, 0x20 - (g_t403004 & 0x1F)) ^ g_t403004;
			g_dw40333C = eax_n;
			g_dw403340 = eax_n;
			g_dw403344 = eax_n;
			g_dw403348 = eax_n;
			g_dw40334C = eax_n;
			g_dw403350 = eax_n;
		}
	}
	else
	{
		fn00401774(0x05);
		int3();
		word32 esi_n;
		word32 edi_n;
		word32 ebx_n;
		word32 ebp_n;
		word32 edx_n;
		fn00401544(ebx, dwArg04, edi, out edx_n, out ebx_n, out ebp_n, out esi_n, out edi_n);
	}
}

// 00401544: Register byte fn00401544(Register word32 ebx, Register Eq_n esi, Register Eq_n edi, Register out ptr32 edxOut, Register out ptr32 ebxOut, Register out (ptr32 Eq_n) ebpOut, Register out ptr32 esiOut, Register out ptr32 ediOut)
// Called from:
//      Win32CrtStartup
//      fn004014AD
byte fn00401544(word32 ebx, Eq_n esi, Eq_n edi, ptr32 & edxOut, ptr32 & ebxOut, struct Eq_n & ebpOut, ptr32 & esiOut, ptr32 & ediOut)
{
	word32 eax_n;
	struct Eq_n * ebp_n = fn00401980(ebx, esi, edi, dwLoc0C, 0x08);
	ebp_n->dwFFFFFFFC = 0x00;
	word24 eax_24_8_n = 0x5A;
	if (g_w400000 == 23117)
	{
		struct Eq_n * eax_n = g_ptr40003C;
		eax_24_8_n = SLICE(eax_n, word24, 8);
		if (eax_n->dw400000 == 0x4550 && eax_n->w400018 == 0x010B)
		{
			ui32 eax_n = ebp_n->dw0008;
			struct Eq_n * eax_n = fn004013FB(&g_w400000, eax_n - 0x00400000, out edx);
			dwLoc0C = eax_n - 0x00400000;
			eax_24_8_n = SLICE(eax_n, word24, 8);
			if (eax_n != null && eax_n->dw0024 >= 0x00)
			{
				ebp_n->dwFFFFFFFC = ~0x01;
				eax_n = SEQ(eax_24_8_n, 0x01);
l004015C8:
				struct Eq_n * ebp_n;
				ptr32 edi_n;
				ptr32 esi_n;
				ptr32 ebx_n = fn004019C6(ebp_n, dwLoc0C, out ebp_n, out esi_n, out edi_n);
				edxOut = edx;
				ebxOut = ebx_n;
				ebpOut = ebp_n;
				esiOut = esi_n;
				ediOut = edi_n;
				return (byte) eax_n;
			}
		}
	}
	ebp_n->dwFFFFFFFC = ~0x01;
	eax_n = SEQ(eax_24_8_n, 0x00);
	goto l004015C8;
}

// 004015CE: void fn004015CE(Stack Eq_n bArg04)
// Called from:
//      Win32CrtStartup
void fn004015CE(Eq_n bArg04)
{
	if (fn00401B98() != 0x00 && bArg04 == 0x00)
		g_dw403338 = 0x00;
}

// 004015EB: void fn004015EB(Stack Eq_n bArg08)
// Called from:
//      Win32CrtStartup
void fn004015EB(Eq_n bArg08)
{
	if (g_b403354 == 0x00 || bArg08 == 0x00)
	{
		fn00401C48();
		fn00401C48();
	}
}

// 00401613: Register ui32 fn00401613(Stack ui32 dwArg04)
// Called from:
//      fn0040164E
ui32 fn00401613(ui32 dwArg04)
{
	word32 eax_n;
	Eq_n eax_n = g_t403004;
	if (__ror<word32,byte>(eax_n ^ g_dw40333C, (byte) eax_n & 0x1F) == ~0x00)
		crt_atexit();
	else
		register_onexit_function();
	return ~(0x00 - (word32) (eax_n != 0x00)) & dwArg04;
}

// 0040164E: void fn0040164E(Stack ui32 dwArg04)
void fn0040164E(ui32 dwArg04)
{
	fn00401613(dwArg04);
}

// 00401663: void fn00401663()
// Called from:
//      Win32CrtStartup
void fn00401663()
{
	Eq_n eax_n = g_t403004;
	if (eax_n != 0xBB40E64E && (eax_n & 0xFFFF0000) != 0x00)
		g_dw403000 = ~eax_n;
	else
	{
		GetSystemTimeAsFileTime(fp - 0x10);
		ui32 v14_n = GetCurrentThreadId() ^ GetCurrentProcessId();
		QueryPerformanceCounter(fp - 0x18);
		Eq_n ecx_n = dwLoc14 ^ dwLoc18 ^ v14_n ^ fp - 0x08;
		if (ecx_n == 0xBB40E64E)
			ecx_n.u0 = ~0x44BF19B0;
		else if ((ecx_n & 0xFFFF0000) == 0x00)
			ecx_n |= (ecx_n | 0x4711) << 0x10;
		g_t403004 = ecx_n;
		g_dw403000 = ~ecx_n;
	}
}

// 004016FF: void fn004016FF()
void fn004016FF()
{
}

// 00401703: void fn00401703()
void fn00401703()
{
}

// 00401709: void fn00401709()
void fn00401709()
{
}

// 0040170C: void fn0040170C()
void fn0040170C()
{
	InitializeSListHead(&g_u403358);
}

// 00401718: void fn00401718()
void fn00401718()
{
	word32 eax_n;
	controlfp_s();
	if (eax_n == 0x00)
		return;
	fn00401774(0x07);
	int3();
	fn00401739();
}

// 00401739: Register ptr32 fn00401739()
// Called from:
//      fn00401718
//      fn0040173F
ptr32 fn00401739()
{
	return 0x00403360;
}

// 0040173F: void fn0040173F()
void fn0040173F()
{
	struct Eq_n * eax_n = fn00401050();
	word32 ecx_n = eax_n->dw0004;
	eax_n->dw0000 |= 0x04;
	eax_n->dw0004 = ecx_n;
	struct Eq_n * eax_n = fn00401739();
	word32 ecx_n = eax_n->dw0004;
	eax_n->dw0000 |= 0x02;
	eax_n->dw0004 = ecx_n;
}

// 0040175C: void fn0040175C()
void fn0040175C()
{
}

// 00401768: Register ptr32 fn00401768()
// Called from:
//      Win32CrtStartup
ptr32 fn00401768()
{
	return 0x00403388;
}

// 0040176E: Register ptr32 fn0040176E()
// Called from:
//      Win32CrtStartup
ptr32 fn0040176E()
{
	return 0x00403384;
}

// 00401774: void fn00401774(Stack word32 dwArg04)
// Called from:
//      Win32CrtStartup
//      fn004014AD
//      fn00401718
void fn00401774(word32 dwArg04)
{
	if (IsProcessorFeaturePresent(0x17) == 0x00)
	{
		g_dw403368 = 0x00;
		memset(fp - 808, 0x00, 0x02CC);
		memset(fp - 0x5C, 0x00, 0x50);
		byte bl_n = 0x00 - (IsDebuggerPresent() != 0x01);
		SetUnhandledExceptionFilter(null);
		if (UnhandledExceptionFilter(fp - 0x0C) == 0x00)
			g_dw403368 &= 0x00 - ((word32) (bl_n + 0x01) != 0x00);
	}
	else
		__fastfail(dwArg04);
}

// 0040188F: Register int8 fn0040188F()
// Called from:
//      Win32CrtStartup
int8 fn0040188F()
{
	Eq_n eax_n = GetModuleHandleW(null);
	if (eax_n == null || eax_n->unused != 23117)
		return 0x00;
	struct Eq_n * eax_n = eax_n + eax_n->dw003C / 64;
	if (eax_n->dw0000 != 0x4550 || (eax_n->w0018 != 0x010B || eax_n->dw0074 <= 0x0E))
		return 0x00;
	return (int8) (eax_n->dw00E8 != 0x00);
}

// 004018D3: void fn004018D3()
void fn004018D3()
{
	SetUnhandledExceptionFilter(&g_t4018DF);
}

LONG g_t4018DF(struct _EXCEPTION_POINTERS * ExceptionInfo) = ??/* Unexpected function type (fn LONG ((ptr32 (struct "_EXCEPTION_POINTERS")))) */ ; // 004018DF
// 00401920: void fn00401920()
void fn00401920()
{
	word32 * esi_n = g_a4024C8;
	if (false)
	{
		do
		{
			if (*esi_n != 0x00)
			{
				fn00401976();
				word32 ecx_n;
				fn00000000();
			}
			++esi_n;
		} while (esi_n < g_a4024C8);
	}
}

// 00401976: void fn00401976()
// Called from:
//      Win32CrtStartup
//      fn00401920
void fn00401976()
{
	g_ptr4020D0();
}

// 00401980: Register ptr32 fn00401980(Register word32 ebx, Register Eq_n esi, Register Eq_n edi, Stack Eq_n dwArg00, Stack ui32 dwArg08)
// Called from:
//      Win32CrtStartup
//      fn00401544
ptr32 fn00401980(word32 ebx, Eq_n esi, Eq_n edi, Eq_n dwArg00, ui32 dwArg08)
{
	struct Eq_n * esp_n = fp - 8 - dwArg08;
	esp_n->dwFFFFFFFC = ebx;
	esp_n->tFFFFFFF8 = esi;
	esp_n->tFFFFFFF4 = edi;
	esp_n->dwFFFFFFF0 = g_t403004 ^ fp + 0x08;
	esp_n->tFFFFFFEC = dwArg00;
	fs->ptr0000 = fp - 0x08;
	return fp + 0x08;
}

// 004019C6: Register word32 fn004019C6(Register (ptr32 Eq_n) ebp, Stack Eq_n dwArg00, Register out Eq_n ebpOut, Register out ptr32 esiOut, Register out ptr32 ediOut)
// Called from:
//      Win32CrtStartup
//      fn00401544
word32 fn004019C6(struct Eq_n * ebp, Eq_n dwArg00, union Eq_n & ebpOut, ptr32 & esiOut, ptr32 & ediOut)
{
	fs->dw0000 = ebp->dwFFFFFFF0;
	Eq_n ebp_n = ebp->t0000;
	ebp->t0000 = dwArg00;
	ebpOut = ebp_n;
	esiOut = dwArg0C;
	ediOut = dwArg08;
	return dwArg10;
}

// 004019FE: void fn004019FE(Register word32 edx)
// Called from:
//      fn00401474
void fn004019FE(word32 edx)
{
	g_dw40336C = 0x00;
	g_dw403010 |= 0x01;
	if (IsProcessorFeaturePresent(0x0A) != 0x00)
	{
		ui32 edi_n;
		g_dw403010 |= 0x02;
		g_dw40336C = 0x01;
		__cpuid(0x00, 0x00, &0x00, &0x01, &0x00, &edx);
		__cpuid(0x01, 0x00, &0x01, &0x01, &0x00, &edx);
		byte bLoc14_n = 0x00;
		if ((edx ^ 0x49656E69 | 1818588270 | 0x756E6546) == 0x00 && (false || (false || (false || (false || (false || false))))))
		{
			ui32 edi_n = g_dw403370;
			g_dw403370 = edi_n | 0x01;
			edi_n = edi_n | 0x01;
		}
		else
			edi_n = g_dw403370;
		if (false)
		{
			__cpuid(0x07, 0x00, &0x07, &0x01, &0x00, &edx);
			bLoc14_n = 0x01;
			if (false)
				g_dw403370 = edi_n | 0x02;
		}
		if (false)
		{
			g_dw403010 |= 0x04;
			g_dw40336C = 0x02;
			if (false && (false && (((word32) __xgetbv(0x00) & 0x06) == 0x06 && true)))
			{
				ui32 eax_n = g_dw403010;
				g_dw40336C = 0x03;
				g_dw403010 = eax_n | 0x08;
				if ((bLoc14_n & 0x20) != 0x00)
				{
					g_dw40336C = 0x05;
					g_dw403010 = eax_n | 0x08 | 0x20;
				}
			}
		}
	}
}

// 00401B98: Register uint32 fn00401B98()
// Called from:
//      fn0040143F
//      fn004014AD
//      fn004015CE
uint32 fn00401B98()
{
	return (uint32) (int8) (g_dw403014 != 0x00);
}

// 00401BA4: void fn00401BA4()
void fn00401BA4()
{
}

// 00401C48: Register byte fn00401C48()
// Called from:
//      fn00401474
//      fn004015EB
byte fn00401C48()
{
	return 0x01;
}

