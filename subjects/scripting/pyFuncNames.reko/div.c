// div.c
// Generated by decompiling pySample.dll
// using Reko decompiler version 0.10.1.0.

#include "pySample.h"

// 100010A0: Register (ptr32 Eq_n) div_wrapper(Stack (ptr32 Eq_n) ptrArg04, Stack (ptr32 Eq_n) ptrArg08)
PyObject * div_wrapper(PyObject * ptrArg04, PyObject * ptrArg08)
{
	PyObject * eax_n = PyArg_ParseTuple(ptrArg08, "ii:div", fp - 0x08, fp - 0x04);
	if (eax_n != null)
		return Py_BuildValue("i", (int32) ((int64) dwLoc08 /32 dwLoc04));
	return eax_n;
}

