// reko_array.h
// Generated by decompiling reko_array.dll
// using Reko decompiler version 0.11.1.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (121D5000 (arr byte) a121D5000))
	globals_t (in globals @ 00000000 : (ptr64 (struct "Globals")))
Eq_13: (fn void ((ptr64 (arr byte))))
	T_13 (in reko_array_byref @ 2121D104E : ptr64)
	T_14 (in signature of reko_array_byref @ 2121D1000 : void)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in rcx @ 00000000 : (arr byte))
  Class: Eq_2
  DataType: (ptr64 (arr byte))
  OrigDataType: (ptr64 (struct (0 (arr T_30) a0000)))
T_3: (in dwLoc0C_38 @ 2121D100C : int32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_4: (in 0<32> @ 2121D100C : word32)
  Class: Eq_3
  DataType: int32
  OrigDataType: word32
T_5: (in 0x1F<32> @ 2121D102F : word32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_6: (in dwLoc0C_38 <= 0x1F<32> @ 00000000 : bool)
  Class: Eq_6
  DataType: bool
  OrigDataType: bool
T_7: (in SLICE(dwLoc0C_38, byte, 0) @ 2121D1025 : byte)
  Class: Eq_7
  DataType: byte
  OrigDataType: byte
T_8: (in CONVERT(dwLoc0C_38, word32, int64) @ 2121D1025 : int64)
  Class: Eq_8
  DataType: int64
  OrigDataType: int64
T_9: (in rcx + CONVERT(dwLoc0C_38, word32, int64) @ 2121D1025 : word64)
  Class: Eq_9
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_10 t0000)))
T_10: (in Mem25[rcx + CONVERT(dwLoc0C_38, word32, int64):byte] @ 2121D1025 : byte)
  Class: Eq_7
  DataType: byte
  OrigDataType: byte
T_11: (in 1<32> @ 2121D1027 : word32)
  Class: Eq_11
  DataType: word32
  OrigDataType: word32
T_12: (in dwLoc0C_38 + 1<32> @ 00000000 : word32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_13: (in reko_array_byref @ 2121D104E : ptr64)
  Class: Eq_13
  DataType: (ptr64 Eq_13)
  OrigDataType: (ptr64 (fn T_16 (T_15)))
T_14: (in signature of reko_array_byref @ 2121D1000 : void)
  Class: Eq_13
  DataType: (ptr64 Eq_13)
  OrigDataType: 
T_15: (in 00000002121D5000 @ 2121D104E : ptr64)
  Class: Eq_2
  DataType: (ptr64 (arr byte))
  OrigDataType: ptr64
T_16: (in reko_array_byref(g_a121D5000) @ 2121D104E : void)
  Class: Eq_16
  DataType: void
  OrigDataType: void
T_17: (in fp @ 2121D105E : ptr64)
  Class: Eq_17
  DataType: ptr64
  OrigDataType: ptr64
T_18: (in dwLoc0C_39 @ 2121D1066 : up32)
  Class: Eq_18
  DataType: up32
  OrigDataType: up32
T_19: (in 0<32> @ 2121D1066 : word32)
  Class: Eq_18
  DataType: up32
  OrigDataType: word32
T_20: (in 0x1F<32> @ 2121D1087 : word32)
  Class: Eq_18
  DataType: up32
  OrigDataType: up32
T_21: (in dwLoc0C_39 <= 0x1F<32> @ 00000000 : bool)
  Class: Eq_21
  DataType: bool
  OrigDataType: bool
T_22: (in SLICE(dwLoc0C_39, byte, 0) @ 2121D1079 : byte)
  Class: Eq_22
  DataType: byte
  OrigDataType: byte
T_23: (in 56<i64> @ 2121D1079 : int64)
  Class: Eq_23
  DataType: int64
  OrigDataType: int64
T_24: (in fp - 56<i64> @ 00000000 : (arr byte))
  Class: Eq_24
  DataType: (ptr64 (arr byte))
  OrigDataType: (ptr64 (struct (0 (arr T_32) a0000)))
T_25: (in CONVERT(dwLoc0C_39, word32, int64) @ 2121D1079 : int64)
  Class: Eq_25
  DataType: int64
  OrigDataType: int64
T_26: (in fp - 56<i64> + CONVERT(dwLoc0C_39, word32, int64) @ 2121D1079 : word64)
  Class: Eq_26
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_27 t0000)))
T_27: (in Mem27[fp - 56<i64> + CONVERT(dwLoc0C_39, word32, int64):byte] @ 2121D1079 : byte)
  Class: Eq_22
  DataType: byte
  OrigDataType: byte
T_28: (in 1<32> @ 2121D107D : word32)
  Class: Eq_28
  DataType: up32
  OrigDataType: up32
T_29: (in dwLoc0C_39 + 1<32> @ 00000000 : word32)
  Class: Eq_18
  DataType: up32
  OrigDataType: up32
T_30:
  Class: Eq_30
  DataType: byte
  OrigDataType: (struct 0001 (0 T_10 t0000))
T_31:
  Class: Eq_31
  DataType: (arr byte)
  OrigDataType: (arr T_30)
T_32:
  Class: Eq_32
  DataType: byte
  OrigDataType: (struct 0001 (0 T_27 t0000))
T_33:
  Class: Eq_33
  DataType: (arr byte)
  OrigDataType: (arr T_32)
*/
typedef struct Globals {
	byte a121D5000[];	// 121D5000
} Eq_1;

typedef void (Eq_13)(byte *[]);

