// pySample_text.c
// Generated by decompiling pySample.dll
// using Reko decompiler version 0.10.2.0.

#include "pySample.h"

// 10001000: Register (ptr32 Eq_n) fn10001000(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn10001000(PyObject * ptrArg04, PyObject * ptrArg08)
{
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:sum", fp - 0x04, fp - 0x08);
	if (eax_n != null)
		return Py_BuildValue("i", dwLoc04 + dwLoc08);
	return eax_n;
}

// 10001050: Register (ptr32 Eq_n) fn10001050(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn10001050(PyObject * ptrArg04, PyObject * ptrArg08)
{
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:dif", fp - 0x08, fp - 0x04);
	if (eax_n != null)
		return Py_BuildValue("i", dwLoc08 - dwLoc04);
	return eax_n;
}

// 100010A0: Register (ptr32 Eq_n) fn100010A0(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn100010A0(PyObject * ptrArg04, PyObject * ptrArg08)
{
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:div", fp - 0x08, fp - 0x04);
	if (eax_n != null)
		return Py_BuildValue("i", (int32) ((int64) dwLoc08 /32 dwLoc04));
	return eax_n;
}

// 100010F0: Register (ptr32 Eq_n) fn100010F0(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * fn100010F0(PyObject * ptrArg04, PyObject * ptrArg08)
{
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ff:fdiv", fp - 0x08, fp - 0x04);
	if (eax_n != null)
		return Py_BuildValue("f", (real64) rLoc08 / (real64) rLoc04);
	return eax_n;
}

// 10001170: void initpySample()
void initpySample()
{
	Py_InitModule4("pySample", methods, null, null, 1007);
}

// 100011E9: Register word32 fn100011E9(Stack Eq_n dwArg04, Stack Eq_n dwArg08, Stack Eq_n dwArg0C, Register out Eq_n ecxOut, Register out ptr32 edxOut, Register out ptr32 ebxOut, Register out ptr32 esiOut, Register out ptr32 ediOut)
// Called from:
//      fn10001388
word32 fn100011E9(Eq_n dwArg04, Eq_n dwArg08, Eq_n dwArg0C, DWORD & ecxOut, ptr32 & edxOut, ptr32 & ebxOut, ptr32 & esiOut, ptr32 & ediOut)
{
	word32 eax_n;
	Eq_n ebp_n = 0x00;
	if (dwArg08 == 0x00)
	{
		if (g_dw10003070 <= 0x00)
		{
			eax_n = 0x00;
			goto l10001384;
		}
		--g_dw10003070;
	}
	ecx = (Eq_n) *adjust_fdiv;
	g_t100033A4 = (Eq_n) ecx;
	ptr32 * esp_n = fp - 16;
	if (dwArg08 == 0x01)
	{
		Eq_n edi_n = fs->ptr0018->t0004;
		while (true)
		{
			Eq_n eax_n = InterlockedCompareExchange(&g_t100033AC, edi_n, 0x00);
			if (eax_n == 0x00)
				break;
			if (eax_n == edi_n)
			{
				ebp_n = 0x01;
				break;
			}
			Sleep(1000);
		}
		if (g_dw100033A8 != 0x00)
			_amsg_exit(0x1F);
		g_dw100033A8 = 0x01;
		ecx = 0x100020A8;
		esp_n = fp - 16;
		if (_initterm_e(&g_t100020A0, &g_t100020A8) != 0x00)
		{
			eax_n = 0x00;
l10001381:
			struct Eq_n * esp_n = esp_n + 1;
			edi = *esp_n;
			esi = esp_n->ptr0000;
			ebx = esp_n->ptr0004;
l10001384:
			ecxOut = ecx;
			edxOut = edx;
			ebxOut = ebx;
			esiOut = esi;
			ediOut = edi;
			return eax_n;
		}
		_initterm(&g_t10002098, &g_t1000209C);
		g_dw100033A8 = 0x02;
		ecx = 0x1000209C;
		if (ebp_n == 0x00)
			InterlockedExchange(&g_t100033AC, ebp_n);
		esp_n = fp - 16;
		if (g_ptr100033B8 != null)
		{
			ecx = 0x100033B8;
			esp_n = fp - 16;
			word32 edi_n;
			if (fn10001742(InterlockedCompareExchange, 268448684, 0x02, out edx, out edi_n) != 0x00)
				g_ptr100033B8();
		}
		++g_dw10003070;
	}
	else if (dwArg08 == 0x00)
	{
		while (InterlockedCompareExchange(&g_t100033AC, 0x01, 0x00) != 0x00)
			Sleep(1000);
		if (g_dw100033A8 != 0x02)
			_amsg_exit(0x1F);
		Eq_n v15_n = g_t100033B4;
		Eq_n eax_n = _decode_pointer(v15_n);
		ecx = v15_n;
		ptr32 esp_n = fp - 16;
		if (eax_n != 0x00)
		{
			ptr32 esp_n = fp - 16;
			DWORD edi_n = _decode_pointer(g_t100033B0);
			while (true)
			{
				ptr32 edx_n;
				edi_n -= 0x04;
				if (edi_n < eax_n)
					break;
				<anonymous> * eax_n = *edi_n;
				if (eax_n != null)
				{
					word32 ecx_n;
					eax_n();
					edx = edx_n;
				}
			}
			DWORD * esp_n = esp_n - 4;
			*esp_n = (uint32) eax_n;
			free(*esp_n);
			ecx = (Eq_n) *esp_n;
			Eq_n eax_n = _encoded_null();
			g_t100033B0 = (Eq_n) eax_n;
			g_t100033B4 = (Eq_n) eax_n;
			esp_n = esp_n + 1;
		}
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000 = 0x00;
		esp_n->ptrFFFFFFFC = (LONG *) &g_t100033AC;
		g_dw100033A8 = 0x00;
		InterlockedExchange(esp_n->ptrFFFFFFFC, esp_n->t0000);
		esp_n = (ptr32 *) (&esp_n->t0000 + 1);
	}
	eax_n = 0x01;
	goto l10001381;
}

// 10001388: Register Eq_n fn10001388(Register Eq_n ecx, Register Eq_n edx, Register (ptr32 Eq_n) ebx, Register ptr32 esi, Register word32 edi)
// Called from:
//      DllMain
Eq_n fn10001388(Eq_n ecx, Eq_n edx, Eq_n (* ebx)(LONG *, Eq_n, Eq_n), ptr32 esi, word32 edi)
{
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
		{
			Eq_n eax_n;
			fn00000000();
			ebp_n->tFFFFFFE4 = eax_n;
			dwLoc0C = ecx;
		}
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
		word32 edx_n;
		word32 ecx_n;
		Eq_n eax_n = fn100011E9(esp_n->tFFFFFFF8, esp_n->tFFFFFFFC, esp_n->t0000, out ecx_n, out edx_n, out ebx_n, out esi_n, out edi_n);
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
		word32 ecx_n;
		word32 edx_n;
		fn100011E9(esp_n->tFFFFFFF8, esp_n->tFFFFFFFC, esp_n->t0000, out ecx_n, out edx_n, out ebx_n, out esi_n, out edi_n);
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		if (g_dw100020CC != 0x00)
		{
			esp_n->t0000 = edi_n;
			esp_n->tFFFFFFFC = 0x00;
			esp_n->tFFFFFFF8 = ebx_n;
			fn00000000();
		}
	}
	if (esi_n == 0x00 || esi_n == 0x03)
	{
		struct Eq_n * esp_n = esp_n - 4;
		esp_n->t0000 = edi_n;
		esp_n->tFFFFFFFC = esi_n;
		esp_n->tFFFFFFF8 = ebx_n;
		Eq_n ebx_n;
		word32 ecx_n;
		Eq_n esi_n;
		Eq_n edi_n;
		word32 edx_n;
		Eq_n eax_n = fn100011E9(esp_n->tFFFFFFF8, esp_n->tFFFFFFFC, esp_n->t0000, out ecx_n, out edx_n, out ebx_n, out esi_n, out edi_n);
		esp_n = (struct Eq_n *) ((char *) &esp_n->t0000 + 4);
		if (eax_n == 0x00)
			ebp_n->tFFFFFFE4 &= eax_n;
		if (ebp_n->tFFFFFFE4 != 0x00 && g_dw100020CC != 0x00)
		{
			esp_n->t0000 = edi_n;
			esp_n->tFFFFFFFC = esi_n;
			esp_n->tFFFFFFF8 = ebx_n;
			Eq_n eax_n;
			fn00000000();
			ebp_n->tFFFFFFE4 = eax_n;
		}
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
	if (dwReason == 0x01)
		fn10001864();
	return fn10001388(lpReserved, dwReason, ebx, esi, edi);
}

// 100015CF: Register Eq_n fn100015CF(Register (ptr32 Eq_n) ebx, Register ptr32 esi, Register word32 edi)
// Called from:
//      fn1000166E
Eq_n fn100015CF(Eq_n (* ebx)(LONG *, Eq_n, Eq_n), ptr32 esi, word32 edi)
{
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
		struct Eq_n * esp_n;
		lock();
		Eq_n ecx_n = esp_n->t0000;
		ebp_n->dwFFFFFFFC = 0x00;
		esp_n->t0000 = (Eq_n) g_t100033B4;
		ebp_n->tFFFFFFE4 = _decode_pointer(esp_n->t0000);
		esp_n->tFFFFFFFC = (Eq_n) g_t100033B0;
		ebp_n->tFFFFFFE0 = _decode_pointer(esp_n->tFFFFFFFC);
		esp_n->ptrFFFFFFF8 = ebp_n - 0x20;
		esp_n->ptrFFFFFFF4 = ebp_n - 0x1C;
		esp_n->tFFFFFFF0 = ebp_n->t0008;
		Eq_n eax_n = __dllonexit(esp_n->tFFFFFFF0, esp_n->ptrFFFFFFF4, esp_n->ptrFFFFFFF8);
		ebp_n->tFFFFFFDC = eax_n;
		esp_n->tFFFFFFEC = ebp_n->tFFFFFFE4;
		struct Eq_n * esp_n;
		Eq_n eax_n;
		encode_pointer();
		g_t100033B4 = (Eq_n) eax_n;
		esp_n->tFFFFFFFC = ebp_n->tFFFFFFE0;
		word32 esp_n;
		Eq_n eax_n;
		encode_pointer();
		g_t100033B0 = (Eq_n) eax_n;
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

// 1000166E: void fn1000166E(Register (ptr32 Eq_n) ebx, Register ptr32 esi, Register word32 edi)
void fn1000166E(Eq_n (* ebx)(LONG *, Eq_n, Eq_n), ptr32 esi, word32 edi)
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

// 10001700: Register (ptr32 Eq_n) fn10001700(Stack (ptr32 Eq_n) dwArg04, Stack uint32 dwArg08, Register out ptr32 edxOut)
// Called from:
//      fn10001742
struct Eq_n * fn10001700(struct Eq_n * dwArg04, uint32 dwArg08, ptr32 & edxOut)
{
	struct Eq_n * ecx_n = dwArg04 + dwArg04->dw003C / 64;
	ptr32 esi_n = (word32) ecx_n->w0006;
	ptr32 edx_n = 0x00;
	struct Eq_n * eax_n = ecx_n + ((word32) ecx_n->w0014 + 0x18) / 22;
	if (esi_n > 0x00)
	{
		do
		{
			uint32 ecx_n = eax_n->dw000C;
			if (dwArg08 >= ecx_n && dwArg08 < eax_n->dw0008 + ecx_n)
				goto l1000173E;
			++edx_n;
			++eax_n;
		} while (edx_n < esi_n);
	}
	eax_n = null;
l1000173E:
	edxOut = edx_n;
	return eax_n;
}

// 10001742: Register ui32 fn10001742(Register (ptr32 Eq_n) ebx, Register ptr32 esi, Register word32 edi, Register out ptr32 edxOut, Register out ptr32 ediOut)
// Called from:
//      fn100011E9
ui32 fn10001742(Eq_n (* ebx)(LONG *, Eq_n, Eq_n), ptr32 esi, word32 edi, ptr32 & edxOut, ptr32 & ediOut)
{
	ui32 eax_n;
	struct Eq_n * ebp_n = fn100017E8(ebx, esi, edi, dwLoc0C, 0x08);
	ebp_n->dwFFFFFFFC = 0x00;
	ptr32 edx_n = 0x10000000;
	Eq_n dwLoc0C_n = 0x10000000;
	if (fn100016D0(&g_t10000000) != 0x00)
	{
		Eq_n eax_n = ebp_n->t0008;
		dwLoc0C_n = eax_n - 0x10000000;
		struct Eq_n * eax_n = fn10001700(&g_t10000000, eax_n - 0x10000000, out edx_n);
		if (eax_n != null)
		{
			eax_n = ~(eax_n->dw0024 >> 0x1F) & 0x01;
			ebp_n->dwFFFFFFFC = ~0x01;
l100017A8:
			ptr32 edi_n = fn1000182D(ebp_n, dwLoc0C_n);
			edxOut = edx_n;
			ediOut = edi_n;
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

// 100017E8: Register ptr32 fn100017E8(Register (ptr32 Eq_n) ebx, Register ptr32 esi, Register word32 edi, Stack Eq_n dwArg00, Stack ui32 dwArg08)
// Called from:
//      fn10001388
//      fn100015CF
//      fn10001742
ptr32 fn100017E8(Eq_n (* ebx)(LONG *, Eq_n, Eq_n), ptr32 esi, word32 edi, Eq_n dwArg00, ui32 dwArg08)
{
	struct Eq_n * esp_n = fp - 8 - dwArg08;
	esp_n->ptrFFFFFFFC = ebx;
	esp_n->ptrFFFFFFF8 = esi;
	esp_n->dwFFFFFFF4 = edi;
	esp_n->dwFFFFFFF0 = g_dw10003000 ^ fp + 0x08;
	esp_n->tFFFFFFEC = dwArg00;
	fs->ptr0000 = fp - 0x08;
	return fp + 0x08;
}

// 1000182D: Register word32 fn1000182D(Register (ptr32 Eq_n) ebp, Stack Eq_n dwArg00)
// Called from:
//      fn10001388
//      fn100015CF
//      fn10001742
word32 fn1000182D(struct Eq_n * ebp, Eq_n dwArg00)
{
	fs->dw0000 = ebp->dwFFFFFFF0;
	ebp->t0000 = dwArg00;
	return dwArg08;
}

// 10001864: void fn10001864()
// Called from:
//      DllMain
void fn10001864()
{
	ui32 eax_n = g_dw10003000;
	if (eax_n != 0xBB40E64E && (eax_n & 0xFFFF0000) != 0x00)
		g_dw10003004 = ~eax_n;
	else
	{
		GetSystemTimeAsFileTime(fp - 0x0C);
		ui32 esi_n = GetCurrentProcessId() ^ GetCurrentThreadId() ^ GetTickCount();
		QueryPerformanceCounter(fp - 0x14);
		ui32 esi_n = esi_n ^ (dwLoc10 ^ dwLoc14);
		if (esi_n == 0xBB40E64E)
			esi_n = ~0x44BF19B0;
		else if ((esi_n & 0xFFFF0000) == 0x00)
			esi_n |= esi_n << 0x10;
		g_dw10003000 = esi_n;
		g_dw10003004 = ~esi_n;
	}
}

