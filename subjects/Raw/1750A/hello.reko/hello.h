// hello.h
// Generated by decompiling hello.hex
// using Reko decompiler version 0.10.1.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (111 Eq_4 t0111))
	globals_t (in globals @ 00000000 : (ptr16 (struct "Globals")))
Eq_2: (fn void ((ptr16 Eq_4)))
	T_2 (in fn0105 @ 00000102 : ptr16)
	T_3 (in signature of fn0105 @ 00000105 : void)
Eq_4: (struct "Eq_4" 0001 (0 word16 w0000))
	T_4 (in gp0 @ 00000102 : (ptr16 Eq_4))
	T_5 (in 0x111<16> @ 00000102 : word16)
	T_7 (in gp1_11 @ 00000105 : (ptr16 Eq_4))
	T_14 (in gp1_11 + 1<16> @ 0000010B : word16)
Eq_8: (fn void (word16))
	T_8 (in fn010E @ 00000109 : ptr16)
	T_9 (in signature of fn010E @ 0000010E : void)
Eq_20: (fn void (word16))
	T_20 (in __console_output @ 0000010E : ptr16)
	T_21 (in signature of __console_output @ 00000000 : void)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr16 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr16 Eq_1)
  OrigDataType: (ptr16 (struct "Globals"))
T_2: (in fn0105 @ 00000102 : ptr16)
  Class: Eq_2
  DataType: (ptr16 Eq_2)
  OrigDataType: (ptr16 (fn T_6 (T_5)))
T_3: (in signature of fn0105 @ 00000105 : void)
  Class: Eq_2
  DataType: (ptr16 Eq_2)
  OrigDataType: 
T_4: (in gp0 @ 00000102 : (ptr16 Eq_4))
  Class: Eq_4
  DataType: (ptr16 Eq_4)
  OrigDataType: word16
T_5: (in 0x111<16> @ 00000102 : word16)
  Class: Eq_4
  DataType: (ptr16 Eq_4)
  OrigDataType: word16
T_6: (in fn0105(&g_t0111) @ 00000102 : void)
  Class: Eq_6
  DataType: void
  OrigDataType: void
T_7: (in gp1_11 @ 00000105 : (ptr16 Eq_4))
  Class: Eq_4
  DataType: (ptr16 Eq_4)
  OrigDataType: (ptr16 (struct 0001 (0 word16 w0000)))
T_8: (in fn010E @ 00000109 : ptr16)
  Class: Eq_8
  DataType: (ptr16 Eq_8)
  OrigDataType: (ptr16 (fn T_12 (T_11)))
T_9: (in signature of fn010E @ 0000010E : void)
  Class: Eq_8
  DataType: (ptr16 Eq_8)
  OrigDataType: 
T_10: (in gp0 @ 00000109 : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: word16
T_11: (in gp0_8 @ 00000109 : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: word16
T_12: (in fn010E(gp0_8) @ 00000109 : void)
  Class: Eq_12
  DataType: void
  OrigDataType: void
T_13: (in 1<16> @ 0000010B : word16)
  Class: Eq_13
  DataType: word16
  OrigDataType: word16
T_14: (in gp1_11 + 1<16> @ 0000010B : word16)
  Class: Eq_4
  DataType: (ptr16 Eq_4)
  OrigDataType: word16
T_15: (in 0<16> @ 00000106 : word16)
  Class: Eq_15
  DataType: word16
  OrigDataType: word16
T_16: (in gp1_11 + 0<16> @ 00000106 : word16)
  Class: Eq_16
  DataType: word16
  OrigDataType: word16
T_17: (in Mem0[gp1_11 + 0<16>:word16] @ 00000106 : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: word16
T_18: (in 0<16> @ 00000108 : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: word16
T_19: (in gp0_8 == 0<16> @ 00000000 : bool)
  Class: Eq_19
  DataType: bool
  OrigDataType: bool
T_20: (in __console_output @ 0000010E : ptr16)
  Class: Eq_20
  DataType: (ptr16 Eq_20)
  OrigDataType: (ptr16 (fn T_23 (T_10)))
T_21: (in signature of __console_output @ 00000000 : void)
  Class: Eq_20
  DataType: (ptr16 Eq_20)
  OrigDataType: 
T_22: (in  @ 0000010E : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: 
T_23: (in __console_output(gp0) @ 0000010E : void)
  Class: Eq_23
  DataType: void
  OrigDataType: void
*/
typedef struct Globals {
	Eq_4 t0111;	// 111
} Eq_1;

typedef void (Eq_2)(Eq_4 *);

typedef struct Eq_4 {	// size: 1 1
	word16 w0000;	// 0
} Eq_4;

typedef void (Eq_8)(word16);

typedef void (Eq_20)(word16);

