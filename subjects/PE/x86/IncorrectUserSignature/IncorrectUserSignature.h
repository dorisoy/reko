// IncorrectUserSignature.h
// Generated by decompiling VCExeSample.exe
// using Reko decompiler version 0.8.0.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals")
	globals_t (in globals : (ptr (struct "Globals")))
Eq_2: cdecl_class
	T_2 (in c : (ptr Eq_2))
Eq_5: cdecl_class
	T_5 (in c : (ptr cdecl_class))
Eq_7: cdecl_class_vtbl
	T_7 (in c + 0x00000000 : word32)
Eq_8: cdecl_class_vtbl
	T_8 (in Mem0[c + 0x00000000:word32] : word32)
Eq_10: (fn void ((ptr cdecl_class), int32, int32))
	T_10 (in Mem0[c + 0x00000000:word32] + 0x00000008 : word32)
Eq_11: (fn void ((ptr cdecl_class), int32, int32))
	T_11 (in Mem0[Mem0[c + 0x00000000:word32] + 0x00000008:word32] : word32)
Eq_17: (struct "Eq_17" (4 (ptr Eq_20) ptr0004))
	T_17 (in Mem48[c + 0x00000000:word32] : word32)
Eq_20: (fn void ((ptr Eq_5), Eq_21))
	T_20 (in Mem48[Mem48[c + 0x00000000:word32] + 0x00000004:word32] : word32)
// Type Variables ////////////
globals_t: (in globals : (ptr (struct "Globals")))
  Class: Eq_1
  DataType: (ptr Eq_1)
  OrigDataType: (ptr (struct "Globals"))
T_2: (in c : (ptr Eq_2))
  Class: Eq_2
  DataType: (ptr Eq_2)
  OrigDataType: (ptr cdecl_class)
T_3: (in a : int32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_4: (in b : int32)
  Class: Eq_4
  DataType: int32
  OrigDataType: int32
T_5: (in c : (ptr cdecl_class))
  Class: Eq_5
  DataType: (ptr Eq_5)
  OrigDataType: (ptr cdecl_class)
T_6: (in 0x00000000 : word32)
  Class: Eq_6
  DataType: word32
  OrigDataType: word32
T_7: (in c + 0x00000000 : word32)
  Class: Eq_7
  DataType: (ptr (ptr Eq_7))
  OrigDataType: (ptr (ptr cdecl_class_vtbl))
T_8: (in Mem0[c + 0x00000000:word32] : word32)
  Class: Eq_8
  DataType: (ptr Eq_8)
  OrigDataType: (ptr (union (cdecl_class_vtbl u1)))
T_9: (in 0x00000008 : word32)
  Class: Eq_9
  DataType: word32
  OrigDataType: word32
T_10: (in Mem0[c + 0x00000000:word32] + 0x00000008 : word32)
  Class: Eq_10
  DataType: (ptr (ptr Eq_10))
  OrigDataType: (ptr (ptr (fn void ((ptr cdecl_class), int32, int32))))
T_11: (in Mem0[Mem0[c + 0x00000000:word32] + 0x00000008:word32] : word32)
  Class: Eq_11
  DataType: (ptr Eq_11)
  OrigDataType: (ptr (fn T_14 ((ptr cdecl_class), int32, int32)))
T_12: (in a : int32)
  Class: Eq_12
  DataType: int32
  OrigDataType: int32
T_13: (in b : int32)
  Class: Eq_13
  DataType: int32
  OrigDataType: int32
T_14: (in c->vtbl->sum(c, a, b) : void)
  Class: Eq_14
  DataType: void
  OrigDataType: void
T_15: (in 0x00000000 : word32)
  Class: Eq_15
  DataType: word32
  OrigDataType: word32
T_16: (in c + 0x00000000 : word32)
  Class: Eq_16
  DataType: ptr32
  OrigDataType: ptr32
T_17: (in Mem48[c + 0x00000000:word32] : word32)
  Class: Eq_17
  DataType: (ptr Eq_17)
  OrigDataType: (ptr (struct (4 T_20 t0004)))
T_18: (in 0x00000004 : word32)
  Class: Eq_18
  DataType: word32
  OrigDataType: word32
T_19: (in Mem48[c + 0x00000000:word32] + 0x00000004 : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_20: (in Mem48[Mem48[c + 0x00000000:word32] + 0x00000004:word32] : word32)
  Class: Eq_20
  DataType: (ptr Eq_20)
  OrigDataType: (ptr (fn T_22 (T_5, T_21)))
T_21: (in <invalid> : void)
  Class: Eq_21
  DataType: Eq_21
  OrigDataType: T_21
T_22: (in c->vtbl->method04(c, <invalid>) : void)
  Class: Eq_22
  DataType: void
  OrigDataType: void
*/
typedef struct Globals {
} Eq_1;

typedef cdecl_class Eq_2;

typedef cdecl_class Eq_5;

typedef cdecl_class_vtbl Eq_7;

typedef cdecl_class_vtbl Eq_8;

typedef void (Eq_10)(cdecl_class * ptrArg04, int32 dwArg08, int32 dwArg0C);

typedef void (Eq_11)(cdecl_class *, int32, int32);

typedef struct Eq_17 {
	void (* ptr0004)(cdecl_class *, Eq_21);	// 4
} Eq_17;

typedef void (Eq_20)(cdecl_class *, ERROR: EQ_21.DataType is Null);

