// flags3.h
// Generated by decompiling flags3
// using Reko decompiler version 0.10.1.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals")
	globals_t (in globals @ 00000000 : (ptr64 (struct "Globals")))
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in rdi @ 00000000 : (ptr64 word32))
  Class: Eq_2
  DataType: (ptr64 word32)
  OrigDataType: (ptr64 (struct (0 T_5 t0000)))
T_3: (in 0<64> @ 00000FB4 : word64)
  Class: Eq_3
  DataType: word64
  OrigDataType: word64
T_4: (in rdi + 0<64> @ 00000FB4 : word64)
  Class: Eq_4
  DataType: word64
  OrigDataType: word64
T_5: (in Mem0[rdi + 0<64>:word32] @ 00000FB4 : word32)
  Class: Eq_5
  DataType: word32
  OrigDataType: word32
T_6: (in CONVERT(Mem0[rdi + 0<64>:word32], word32, uint64) @ 00000FB4 : uint64)
  Class: Eq_6
  DataType: uint64
  OrigDataType: uint64
T_7: (in SLICE(CONVERT(Mem0[rdi + 0<64>:word32], word32, uint64), word32, 0) @ 00000FB4 : word32)
  Class: Eq_7
  DataType: int32
  OrigDataType: int32
T_8: (in 0x101<32> @ 00000FB4 : word32)
  Class: Eq_7
  DataType: int32
  OrigDataType: int32
T_9: (in (word32) (uint64) *rdi < 0x101<32> @ 00000000 : bool)
  Class: Eq_9
  DataType: bool
  OrigDataType: bool
*/
typedef struct Globals {
} Eq_1;

