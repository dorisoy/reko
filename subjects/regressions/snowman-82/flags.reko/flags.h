// flags.h
// Generated by decompiling flags
// using Reko decompiler version 0.11.1.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals")
	globals_t (in globals @ 00000000 : (ptr64 (struct "Globals")))
Eq_13: (fn void ())
	T_13 (in bar @ 00000FA6 : ptr64)
	T_14 (in signature of bar @ 00000FB4 : void)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in sil @ 00000000 : byte)
  Class: Eq_2
  DataType: byte
  OrigDataType: byte
T_3: (in rdi @ 00000000 : (ptr64 uint32))
  Class: Eq_3
  DataType: (ptr64 uint32)
  OrigDataType: (ptr64 (struct (0 T_6 t0000)))
T_4: (in 0<64> @ 00000FA6 : word64)
  Class: Eq_4
  DataType: word64
  OrigDataType: word64
T_5: (in rdi + 0<64> @ 00000FA6 : word64)
  Class: Eq_5
  DataType: word64
  OrigDataType: word64
T_6: (in Mem0[rdi + 0<64>:word32] @ 00000FA6 : word32)
  Class: Eq_6
  DataType: uint32
  OrigDataType: uint32
T_7: (in 0xA<32> @ 00000FA6 : word32)
  Class: Eq_7
  DataType: word32
  OrigDataType: word32
T_8: (in *rdi >> 0xA<32> @ 00000000 : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: uint32
T_9: (in SLICE(Mem0[rdi + 0<64>:word32] >>u 0xA<32>, byte, 0) @ 00000FA6 : byte)
  Class: Eq_9
  DataType: byte
  OrigDataType: byte
T_10: (in (byte) (*rdi >> 0xA<32>) ^ sil @ 00000000 : byte)
  Class: Eq_10
  DataType: ui8
  OrigDataType: ui8
T_11: (in 0<8> @ 00000FA6 : byte)
  Class: Eq_10
  DataType: ui8
  OrigDataType: byte
T_12: (in ((byte) (*rdi >> 0xA<32>) ^ sil) == 0<8> @ 00000000 : bool)
  Class: Eq_12
  DataType: bool
  OrigDataType: bool
T_13: (in bar @ 00000FA6 : ptr64)
  Class: Eq_13
  DataType: (ptr64 Eq_13)
  OrigDataType: (ptr64 (fn T_15 ()))
T_14: (in signature of bar @ 00000FB4 : void)
  Class: Eq_13
  DataType: (ptr64 Eq_13)
  OrigDataType: 
T_15: (in bar() @ 00000FA6 : void)
  Class: Eq_15
  DataType: void
  OrigDataType: void
*/
typedef struct Globals {
} Eq_1;

typedef void (Eq_13)();

