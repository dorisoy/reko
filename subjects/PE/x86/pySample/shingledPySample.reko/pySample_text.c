// pySample_text.c
// Generated by decompiling pySample.dll
// using Reko decompiler version 0.11.2.0.

#include "pySample.h"

// 10001000: Register (ptr32 Eq_n) fn10001000(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn10001000(PyObject * ptrArg04, PyObject * ptrArg08)
{
	int32 dwLoc08;
	int32 dwLoc04;
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:sum", &dwLoc04, &dwLoc08);
	if (eax_n != null)
		return Py_BuildValue("i", dwLoc04 + dwLoc08);
	return eax_n;
}

// 10001050: Register (ptr32 Eq_n) fn10001050(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn10001050(PyObject * ptrArg04, PyObject * ptrArg08)
{
	int32 dwLoc08;
	int32 dwLoc04;
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:dif", &dwLoc08, &dwLoc04);
	if (eax_n != null)
		return Py_BuildValue("i", dwLoc08 - dwLoc04);
	return eax_n;
}

// 100010A0: Register (ptr32 Eq_n) fn100010A0(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn100010A0(PyObject * ptrArg04, PyObject * ptrArg08)
{
	int32 dwLoc08;
	int32 dwLoc04;
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:div", &dwLoc08, &dwLoc04);
	if (eax_n != null)
		return Py_BuildValue("i", (int32) ((int64) dwLoc08 /32 dwLoc04));
	return eax_n;
}

// 100010F0: Register (ptr32 Eq_n) fn100010F0(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn100010F0(PyObject * ptrArg04, PyObject * ptrArg08)
{
	real32 rLoc08;
	real32 rLoc04;
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ff:fdiv", &rLoc08, &rLoc04);
	if (eax_n != null)
		return Py_BuildValue("f", (real64) rLoc08 / (real64) rLoc04);
	return eax_n;
}

// 10001170: void initpySample()
void initpySample()
{
	Py_InitModule4("pySample", methods, null, null, 1007);
}

// 100011E9: Register word32 fn100011E9(Stack Eq_n dwArg08, Register out ptr32 ebxOut, Register out ptr32 esiOut, Register out ptr32 ediOut)
// Called from:
//      fn10001388
word32 fn100011E9(Eq_n dwArg08, ptr32 & ebxOut, ptr32 & esiOut, ptr32 & ediOut)
{
	ptr32 fp;
	ptr32 ebx;
	ptr32 esi;
	ptr32 edi;
	struct Eq_n * fs;
	word32 eax_n;
	word32 ebp_n = 0x00;
	if (dwArg08 == 0x00)
	{
		if (g_dw10003070 <= 0x00)
		{
			eax_n = 0x00;
			goto l10001384;
		}
		--g_dw10003070;
	}
	g_dw100033A4 = *adjust_fdiv;
	struct Eq_n * esp_n = fp - 16;
	if (dwArg08 == 0x01)
	{
		word32 edi_n = fs->ptr0018->dw0004;
		while (true)
		{
			word32 eax_n = KERNEL32.dll!InterlockedCompareExchange(268448684, edi_n);
			if (eax_n == 0x00)
				break;
			if (eax_n == edi_n)
			{
				ebp_n = 0x01;
				break;
			}
			esp_n->tFFFFFFFC = 1000;
			Sleep(esp_n->tFFFFFFFC);
			esp_n->tFFFFFFFC = 0x00;
		}
		Eq_n eax_n = g_t100033A8;
		esp_n->tFFFFFFFC = 0x02;
		Eq_n edi_n = esp_n->tFFFFFFFC;
		if (eax_n != 0x00)
		{
			esp_n->tFFFFFFFC = 0x1F;
			_amsg_exit(esp_n->tFFFFFFFC);
		}
		esp_n->tFFFFFFFC = 0x100020A8;
		esp_n->ptrFFFFFFF8 = (PVFV *) &g_t100020A0;
		g_t100033A8 = (Eq_n) 0x01;
		esp_n = esp_n;
		if (_initterm_e(esp_n->ptrFFFFFFF8, esp_n->tFFFFFFFC) != 0x00)
		{
			eax_n = 0x00;
l10001381:
			struct Eq_n * esp_n = &esp_n->ptr0000 + 1;
			edi = esp_n->ptr0000;
			esi = esp_n->ptr0000;
			ebx = esp_n->ptr0004;
l10001384:
			ebxOut = ebx;
			esiOut = esi;
			ediOut = edi;
			return eax_n;
		}
		esp_n->tFFFFFFFC = 0x1000209C;
		esp_n->ptrFFFFFFF8 = (PVFV *) &g_t10002098;
		_initterm(esp_n->ptrFFFFFFF8, esp_n->tFFFFFFFC);
		g_t100033A8 = (Eq_n) edi_n;
		esp_n = esp_n;
		if (ebp_n == 0x00)
			KERNEL32.dll!InterlockedExchange(268448684, ebp_n);
		if (g_ptr100033B8 != null)
		{
			struct Eq_n * esp_n = esp_n - 4;
			esp_n->dw0000 = 0x100033B8;
			esp_n = (struct Eq_n *) (&esp_n->dw0000 + 1);
			word32 edi_n;
			if (fn10001742(KERNEL32.dll!InterlockedCompareExchange, 268448684, edi_n, out edi_n) != 0x00)
			{
				esp_n->dw0000 = esp_n->dw0020;
				esp_n->dwFFFFFFFC = edi_n;
				esp_n->dwFFFFFFF8 = esp_n->dw0018;
				word32 ecx_n;
				word32 edx_n;
				g_ptr100033B8();
			}
		}
		++g_dw10003070;
	}
	else if (dwArg08 == 0x00)
	{
		while (KERNEL32.dll!InterlockedCompareExchange(268448684, 0x01, 0x00) != 0x00)
		{
			esp_n->tFFFFFFFC = 1000;
			Sleep(esp_n->tFFFFFFFC);
		}
		if (g_t100033A8 != 0x02)
		{
			esp_n->tFFFFFFFC = 0x1F;
			_amsg_exit(esp_n->tFFFFFFFC);
		}
		esp_n->tFFFFFFFC = (Eq_n) g_t100033B4;
		Eq_n eax_n = _decode_pointer(esp_n->tFFFFFFFC);
		if (eax_n != 0x00)
		{
			esp_n->tFFFFFFFC = (Eq_n) g_t100033B0;
			struct Eq_n * esp_n = esp_n;
			DWORD edi_n = _decode_pointer(esp_n->tFFFFFFFC);
			while (true)
			{
				edi_n -= 0x04;
				if (edi_n < eax_n)
					break;
				<anonymous> * eax_n = *edi_n;
				if (eax_n != null)
				{
					word32 ecx_n;
					word32 edx_n;
					eax_n();
				}
			}
			DWORD * esp_n = esp_n - 4;
			*esp_n = (uint32) eax_n;
			free(*esp_n);
			Eq_n eax_n = _encoded_null();
			g_t100033B0 = (Eq_n) eax_n;
			g_t100033B4 = (Eq_n) eax_n;
		}
		g_t100033A8 = (Eq_n) 0x00;
		KERNEL32.dll!InterlockedExchange(268448684, 0x00);
	}
	eax_n = 0x01;
	goto l10001381;
}

// 10001388: Register Eq_n fn10001388(Register Eq_n ecx, Register Eq_n edx, Register ptr32 ebx, Register ptr32 esi, Register Eq_n edi)
// Called from:
//      DllMain
Eq_n fn10001388(Eq_n ecx, Eq_n edx, ptr32 ebx, ptr32 esi, Eq_n edi)
{
	ptr32 fp;
	word32 dwLoc0C;
	struct Eq_n * ebp_n = fn100017E8(ebx, esi, edi, dwLoc0C, 0x10);
	Eq_n ebx_n = ebp_n->t0008;
	ebp_n->tFFFFFFE4 = 0x01;
	ebp_n->dwFFFFFFFC = 0x00;
	g_t10003008 = (Eq_n) edx;
	ebp_n->dwFFFFFFFC = 0x01;
	struct Eq_n * esp_n = fp - 8;
	Eq_n edi_n = ecx;
	Eq_n esi_n = edx;
	if (edx == 0x00 && g_dw10003070 == 0x00)
	{
		ebp_n->tFFFFFFE4 = 0x00;
		goto l1000147A;
	}
	if (edx == 0x01 || edx == 0x02)
	{
		if (g_dw100020CC != 0x00)
			ebp_n->tFFFFFFE4 = fn00000000(ebx_n, edx, ecx);
		if (ebp_n->tFFFFFFE4 == 0x00)
		{
l1000147A:
			ebp_n->dwFFFFFFFC = 0x00;
			ebp_n->dwFFFFFFFC = ~0x01;
			fn10001493();
			Eq_n eax_n = ebp_n->tFFFFFFE4;
			fn1000182D(ebp_n, esp_n->tFFFFFFFC);
			return eax_n;
		}
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000 = ecx;
		esp_n->tFFFFFFFC = edx;
		esp_n->tFFFFFFF8 = ebx_n;
		Eq_n eax_n = fn100011E9(esp_n->tFFFFFFFC, out ebx_n, out esi_n, out edi_n);
		ebp_n->tFFFFFFE4 = eax_n;
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		if (eax_n == 0x00)
			goto l1000147A;
	}
	struct Eq_n * esp_n = esp_n - 4;
	esp_n->t0000 = edi_n;
	esp_n->tFFFFFFFC = esi_n;
	esp_n->tFFFFFFF8 = ebx_n;
	Eq_n eax_n = fn100017C6(esp_n->tFFFFFFF8, esp_n->tFFFFFFFC);
	ebp_n->tFFFFFFE4 = eax_n;
	esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
	if (esi_n == 0x01 && eax_n == 0x00)
	{
		esp_n->t0000 = edi_n;
		esp_n->tFFFFFFFC = eax_n;
		esp_n->tFFFFFFF8 = ebx_n;
		fn100017C6(esp_n->tFFFFFFF8, esp_n->tFFFFFFFC);
		esp_n->t0000 = edi_n;
		esp_n->tFFFFFFFC = 0x00;
		esp_n->tFFFFFFF8 = ebx_n;
		fn100011E9(esp_n->tFFFFFFFC, out ebx_n, out esi_n, out edi_n);
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		if (g_dw100020CC != 0x00)
			fn00000000(ebx_n, 0x00, edi_n);
	}
	if (esi_n == 0x00 || esi_n == 0x03)
	{
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000 = edi_n;
		esp_n->tFFFFFFFC = esi_n;
		esp_n->tFFFFFFF8 = ebx_n;
		word32 ebx_n;
		word32 esi_n;
		word32 edi_n;
		Eq_n eax_n = fn100011E9(esp_n->tFFFFFFFC, out ebx_n, out esi_n, out edi_n);
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		if (eax_n == 0x00)
			ebp_n->tFFFFFFE4 &= eax_n;
		if (ebp_n->tFFFFFFE4 != 0x00 && g_dw100020CC != 0x00)
			ebp_n->tFFFFFFE4 = fn00000000(ebx_n, esi_n, edi_n);
	}
	goto l1000147A;
}

// 10001493: void fn10001493()
// Called from:
//      fn10001388
void fn10001493()
{
	g_t10003008 = (Eq_n) ~0x00;
}

// 1000149E: Register Eq_n DllMain(Stack Eq_n hModule, Stack Eq_n dwReason, Stack Eq_n lpReserved)
Eq_n DllMain(Eq_n hModule, Eq_n dwReason, Eq_n lpReserved)
{
	ptr32 ebx;
	ptr32 esi;
	Eq_n edi;
	if (dwReason == 0x01)
		fn10001864();
	return fn10001388(lpReserved, dwReason, ebx, esi, edi);
}

// 100015CF: Register Eq_n fn100015CF(Register ptr32 ebx, Register ptr32 esi, Register Eq_n edi)
// Called from:
//      fn1000166E
Eq_n fn100015CF(ptr32 ebx, ptr32 esi, Eq_n edi)
{
	ptr32 fp;
	word32 dwLoc0C;
	Eq_n eax_n;
	struct Eq_n * esp_n;
	struct Eq_n * ebp_n = fn100017E8(ebx, esi, edi, dwLoc0C, 0x14);
	Eq_n eax_n = _decode_pointer(g_t100033B4);
	ebp_n->tFFFFFFE4 = eax_n;
	if (eax_n == ~0x00)
	{
		eax_n = _onexit(ebp_n->t0008);
		esp_n = fp - 8;
	}
	else
	{
		lock(0x08);
		Eq_n ecx_n = esp_n->t0000;
		ebp_n->dwFFFFFFFC = 0x00;
		Eq_n v14_n = g_t100033B4;
		ebp_n->tFFFFFFE4 = _decode_pointer(esp_n->t0000);
		Eq_n v15_n = g_t100033B0;
		ebp_n->tFFFFFFE0 = _decode_pointer(esp_n->tFFFFFFFC);
		Eq_n v16_n = ebp_n->t0008;
		ebp_n->tFFFFFFDC = __dllonexit(esp_n->tFFFFFFF0, esp_n->ptrFFFFFFF4, esp_n->ptrFFFFFFF8);
		g_t100033B4 = (Eq_n) encode_pointer(ecx_n, ebp_n->tFFFFFFE4, v16_n, ebp_n - 28, ebp_n - 32, v15_n, v14_n);
		g_t100033B0 = (Eq_n) encode_pointer(ebp_n->tFFFFFFE0);
		ebp_n->dwFFFFFFFC = ~0x01;
		fn10001665();
		esp_n = esp_n + 0x1C;
		eax_n = ebp_n->tFFFFFFDC;
	}
	fn1000182D(ebp_n, esp_n->tFFFFFFFC);
	return eax_n;
}

// 10001665: void fn10001665()
// Called from:
//      fn100015CF
void fn10001665()
{
	unlock();
}

// 1000166E: void fn1000166E(Register ptr32 ebx, Register ptr32 esi, Register Eq_n edi)
void fn1000166E(ptr32 ebx, ptr32 esi, Eq_n edi)
{
	fn100015CF(ebx, esi, edi);
}

// 10001680: void fn10001680()
void fn10001680()
{
	word32 * esi_n = g_a100021D8;
	if (false)
	{
		do
		{
			if (*esi_n != 0x00)
				fn00000000();
			++esi_n;
		} while (esi_n < g_a100021D8);
	}
}

// 100016D0: Register uint32 fn100016D0(Stack (ptr32 Eq_n) dwArg04)
// Called from:
//      fn10001742
uint32 fn100016D0(struct Eq_n * dwArg04)
{
	if (dwArg04->w0000 != 23117)
		return 0x00;
	struct Eq_n * eax_n = dwArg04 + dwArg04->dw003C / 64;
	if (eax_n->dw0000 != 0x4550)
		return 0x00;
	return (uint32) (int8) (eax_n->w0018 == 0x010B);
}

// 10001700: Register (ptr32 Eq_n) fn10001700(Stack (ptr32 Eq_n) dwArg04, Stack uint32 dwArg08)
// Called from:
//      fn10001742
struct Eq_n * fn10001700(struct Eq_n * dwArg04, uint32 dwArg08)
{
	struct Eq_n * ecx_n = dwArg04 + dwArg04->dw003C / 64;
	up32 esi_n = (word32) ecx_n->w0006;
	up32 edx_n = 0x00;
	struct Eq_n * eax_n = ecx_n + ((word32) ecx_n->w0014 + 24) / 22;
	if (esi_n > 0x00)
	{
		do
		{
			uint32 ecx_n = eax_n->dw000C;
			if (dwArg08 >= ecx_n && dwArg08 < eax_n->dw0008 + ecx_n)
				return eax_n;
			++edx_n;
			++eax_n;
		} while (edx_n < esi_n);
	}
	eax_n = null;
	return eax_n;
}

// 10001742: Register ui32 fn10001742(Register ptr32 ebx, Register ptr32 esi, Register Eq_n edi, Register out ptr32 ediOut)
// Called from:
//      fn100011E9
ui32 fn10001742(ptr32 ebx, ptr32 esi, Eq_n edi, ptr32 & ediOut)
{
	word32 dwLoc0C;
	ui32 eax_n;
	struct Eq_n * ebp_n = fn100017E8(ebx, esi, edi, dwLoc0C, 0x08);
	ebp_n->dwFFFFFFFC = 0x00;
	Eq_n dwLoc0C_n = 0x10000000;
	if (fn100016D0(&g_t10000000) != 0x00)
	{
		Eq_n eax_n = ebp_n->t0008;
		dwLoc0C_n = eax_n - 0x10000000;
		struct Eq_n * eax_n = fn10001700(&g_t10000000, eax_n - 0x10000000);
		if (eax_n != null)
		{
			eax_n = ~(eax_n->dw0024 >> 0x1F) & 0x01;
			ebp_n->dwFFFFFFFC = ~0x01;
l100017A8:
			ediOut = fn1000182D(ebp_n, dwLoc0C_n);
			return eax_n;
		}
	}
	ebp_n->dwFFFFFFFC = ~0x01;
	eax_n = 0x00;
	goto l100017A8;
}

// 100017C6: Register word32 fn100017C6(Stack Eq_n dwArg04, Stack Eq_n dwArg08)
// Called from:
//      fn10001388
word32 fn100017C6(Eq_n dwArg04, Eq_n dwArg08)
{
	if (dwArg08 == 0x01 && g_dw100020CC == 0x00)
		DisableThreadLibraryCalls(dwArg04);
	return 0x01;
}

// 100017E8: Register ptr32 fn100017E8(Register ptr32 ebx, Register ptr32 esi, Register Eq_n edi, Stack word32 dwArg00, Stack ui32 dwArg08)
// Called from:
//      fn10001388
//      fn100015CF
//      fn10001742
ptr32 fn100017E8(ptr32 ebx, ptr32 esi, Eq_n edi, word32 dwArg00, ui32 dwArg08)
{
	ptr32 fp;
	struct Eq_n * fs;
	struct Eq_n * esp_n = fp - 8 - dwArg08;
	esp_n->ptrFFFFFFFC = ebx;
	esp_n->ptrFFFFFFF8 = esi;
	esp_n->tFFFFFFF4 = edi;
	esp_n->dwFFFFFFF0 = g_dw10003000 ^ fp + 8;
	esp_n->dwFFFFFFEC = dwArg00;
	fs->ptr0000 = fp - 8;
	return fp + 8;
}

// 1000182D: Register word32 fn1000182D(Register (ptr32 Eq_n) ebp, Stack Eq_n dwArg00)
// Called from:
//      fn10001388
//      fn100015CF
//      fn10001742
word32 fn1000182D(struct Eq_n * ebp, Eq_n dwArg00)
{
	struct Eq_n * fs;
	word32 dwArg08;
	fs->dw0000 = ebp->dwFFFFFFF0;
	ebp->t0000 = dwArg00;
	return dwArg08;
}

// 10001864: void fn10001864()
// Called from:
//      DllMain
void fn10001864()
{
	Eq_n tLoc14;
	Eq_n tLoc0C;
	ui32 eax_n = g_dw10003000;
	tLoc0C.dwLowDateTime = (DWORD) 0x00;
	tLoc0C.dwHighDateTime = (DWORD) 0x00;
	if (eax_n != 0xBB40E64E && (eax_n & 0xFFFF0000) != 0x00)
		g_dw10003004 = ~eax_n;
	else
	{
		GetSystemTimeAsFileTime(&tLoc0C);
		ui32 esi_n = tLoc0C.dwHighDateTime ^ tLoc0C.dwLowDateTime ^ GetCurrentProcessId() ^ GetCurrentThreadId() ^ GetTickCount();
		QueryPerformanceCounter(&tLoc14);
		ui32 esi_n = esi_n ^ (tLoc14.dw0004 ^ tLoc14);
		if (esi_n == 0xBB40E64E)
			esi_n = ~0x44BF19B0;
		else if ((esi_n & 0xFFFF0000) == 0x00)
			esi_n |= esi_n << 0x10;
		g_dw10003000 = esi_n;
		g_dw10003004 = ~esi_n;
	}
}

