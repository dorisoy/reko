// test.h
// Generated by decompiling test
// using Reko decompiler version 0.10.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (400416 code t400416) (400426 code t400426) (400436 code t400436) (40053D Eq_19 t40053D) (400550 Eq_22 t400550) (4005C0 Eq_23 t4005C0) (600E10 (arr (ptr64 code)) a600E10) (600E20 word64 qw600E20) (600FF8 (ptr64 code) __gmon_start___GOT) (601018 (ptr64 code) putchar_GOT) (601020 (ptr64 code) __libc_start_main_GOT) (601028 (ptr64 code) __gmon_start___GOT) (601040 byte b601040))
	globals_t (in globals @ 00000000 : (ptr64 (struct "Globals")))
Eq_8: (fn void ())
	T_8 (in rdx @ 004003F0 : (ptr64 Eq_8))
	T_24 (in rtld_fini @ 00400464 : (ptr64 (fn void ())))
Eq_10: (fn void (ptr64))
	T_10 (in __align @ 00400449 : ptr64)
	T_11 (in signature of __align @ 00000000 : void)
Eq_17: (fn int32 ((ptr64 Eq_19), int32, (ptr64 (ptr64 char)), (ptr64 Eq_22), (ptr64 Eq_23), (ptr64 Eq_8), (ptr64 void)))
	T_17 (in __libc_start_main @ 00400464 : ptr64)
	T_18 (in signature of __libc_start_main @ 00000000 : void)
Eq_19: (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))
	T_19 (in main @ 00400464 : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
	T_26 (in 0x40053D<64> @ 00400464 : word64)
Eq_22: (fn void ())
	T_22 (in init @ 00400464 : (ptr64 (fn void ())))
	T_30 (in 0x400550<64> @ 00400464 : word64)
Eq_23: (fn void ())
	T_23 (in fini @ 00400464 : (ptr64 (fn void ())))
	T_31 (in 0x4005C0<64> @ 00400464 : word64)
Eq_33: (fn void ())
	T_33 (in __hlt @ 00400469 : ptr64)
	T_34 (in signature of __hlt @ 00000000 : void)
Eq_46: (fn void ())
	T_46 (in deregister_tm_clones @ 004004ED : ptr64)
	T_47 (in signature of deregister_tm_clones @ 00400470 : void)
Eq_59: (fn void ())
	T_59 (in register_tm_clones @ 00400520 : ptr64)
	T_60 (in signature of register_tm_clones @ 004004A0 : void)
	T_62 (in register_tm_clones @ 00400528 : ptr64)
Eq_65: (fn int32 (int32))
	T_65 (in putchar @ 0040053C : ptr64)
	T_66 (in signature of putchar @ 00000000 : void)
Eq_70: (fn word32 ())
	T_70 (in f @ 00400546 : ptr64)
	T_71 (in signature of f @ 0040052D : void)
Eq_78: (fn void ())
	T_78 (in _init @ 0040057E : ptr64)
	T_79 (in signature of _init @ 004003E0 : void)
Eq_82: (union "Eq_82" (int64 u0) (ptr64 u1))
	T_82 (in 0000000000600E18 @ 00400571 : ptr64)
Eq_83: (union "Eq_83" (int64 u0) (ptr64 u1))
	T_83 (in 0000000000600E10 @ 00400571 : ptr64)
Eq_85: (union "Eq_85" (int64 u0) (uint64 u1))
	T_85 (in rbx_33 @ 00400574 : Eq_85)
	T_86 (in 0<u64> @ 00400574 : uint64)
	T_96 (in rbx_33 + 1<64> @ 0040059D : word64)
	T_97 (in rbp_31 >> 3<64> @ 00000000 : word64)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in __gmon_start__ @ 004003EE : ptr64)
  Class: Eq_2
  DataType: word64
  OrigDataType: 
T_3: (in signature of __gmon_start__ @ 00000000 : void)
  Class: Eq_3
  DataType: Eq_3
  OrigDataType: 
T_4: (in 0<64> @ 004003EE : word64)
  Class: Eq_2
  DataType: word64
  OrigDataType: word64
T_5: (in __gmon_start__ == 0<64> @ 00000000 : bool)
  Class: Eq_5
  DataType: bool
  OrigDataType: bool
T_6: (in __gmon_start__ @ 004003F0 : ptr64)
  Class: Eq_6
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_7: (in signature of __gmon_start__ @ 00000000 : void)
  Class: Eq_7
  DataType: Eq_7
  OrigDataType: 
T_8: (in rdx @ 004003F0 : (ptr64 Eq_8))
  Class: Eq_8
  DataType: (ptr64 Eq_8)
  OrigDataType: (ptr64 (fn void ()))
T_9: (in dwArg00 @ 004003F0 : word32)
  Class: Eq_9
  DataType: word32
  OrigDataType: word32
T_10: (in __align @ 00400449 : ptr64)
  Class: Eq_10
  DataType: (ptr64 Eq_10)
  OrigDataType: (ptr64 (fn T_16 (T_15)))
T_11: (in signature of __align @ 00000000 : void)
  Class: Eq_10
  DataType: (ptr64 Eq_10)
  OrigDataType: 
T_12: (in  @ 00400449 : word64)
  Class: Eq_12
  DataType: ptr64
  OrigDataType: 
T_13: (in fp @ 00400449 : ptr64)
  Class: Eq_13
  DataType: (ptr64 void)
  OrigDataType: (ptr64 void)
T_14: (in 8<i64> @ 00400449 : int64)
  Class: Eq_14
  DataType: int64
  OrigDataType: int64
T_15: (in fp + 8<i64> @ 00400449 : word64)
  Class: Eq_12
  DataType: ptr64
  OrigDataType: ptr64
T_16: (in __align((char *) fp + 8<i32>) @ 00400449 : void)
  Class: Eq_16
  DataType: void
  OrigDataType: void
T_17: (in __libc_start_main @ 00400464 : ptr64)
  Class: Eq_17
  DataType: (ptr64 Eq_17)
  OrigDataType: (ptr64 (fn T_32 (T_26, T_28, T_29, T_30, T_31, T_8, T_13)))
T_18: (in signature of __libc_start_main @ 00000000 : void)
  Class: Eq_17
  DataType: (ptr64 Eq_17)
  OrigDataType: 
T_19: (in main @ 00400464 : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
  Class: Eq_19
  DataType: (ptr64 Eq_19)
  OrigDataType: 
T_20: (in argc @ 00400464 : int32)
  Class: Eq_20
  DataType: int32
  OrigDataType: 
T_21: (in ubp_av @ 00400464 : (ptr64 (ptr64 char)))
  Class: Eq_21
  DataType: (ptr64 (ptr64 char))
  OrigDataType: 
T_22: (in init @ 00400464 : (ptr64 (fn void ())))
  Class: Eq_22
  DataType: (ptr64 Eq_22)
  OrigDataType: 
T_23: (in fini @ 00400464 : (ptr64 (fn void ())))
  Class: Eq_23
  DataType: (ptr64 Eq_23)
  OrigDataType: 
T_24: (in rtld_fini @ 00400464 : (ptr64 (fn void ())))
  Class: Eq_8
  DataType: (ptr64 Eq_8)
  OrigDataType: 
T_25: (in stack_end @ 00400464 : (ptr64 void))
  Class: Eq_13
  DataType: (ptr64 void)
  OrigDataType: 
T_26: (in 0x40053D<64> @ 00400464 : word64)
  Class: Eq_19
  DataType: (ptr64 Eq_19)
  OrigDataType: (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char)))))
T_27: (in qwArg00 @ 00400464 : word64)
  Class: Eq_27
  DataType: word64
  OrigDataType: word64
T_28: (in SLICE(qwArg00, int32, 0) @ 00400464 : int32)
  Class: Eq_20
  DataType: int32
  OrigDataType: int32
T_29: (in fp + 8<i64> @ 00400464 : word64)
  Class: Eq_21
  DataType: (ptr64 (ptr64 char))
  OrigDataType: (ptr64 (ptr64 char))
T_30: (in 0x400550<64> @ 00400464 : word64)
  Class: Eq_22
  DataType: (ptr64 Eq_22)
  OrigDataType: (ptr64 (fn void ()))
T_31: (in 0x4005C0<64> @ 00400464 : word64)
  Class: Eq_23
  DataType: (ptr64 Eq_23)
  OrigDataType: (ptr64 (fn void ()))
T_32: (in __libc_start_main(&g_t40053D, (int32) qwArg00, (char *) fp + 8<i32>, &g_t400550, &g_t4005C0, rdx, fp) @ 00400464 : int32)
  Class: Eq_32
  DataType: int32
  OrigDataType: int32
T_33: (in __hlt @ 00400469 : ptr64)
  Class: Eq_33
  DataType: (ptr64 Eq_33)
  OrigDataType: (ptr64 (fn T_35 ()))
T_34: (in signature of __hlt @ 00000000 : void)
  Class: Eq_33
  DataType: (ptr64 Eq_33)
  OrigDataType: 
T_35: (in __hlt() @ 00400469 : void)
  Class: Eq_35
  DataType: void
  OrigDataType: void
T_36: (in false @ 00400483 : bool)
  Class: Eq_36
  DataType: bool
  OrigDataType: bool
T_37: (in true @ 0040048F : bool)
  Class: Eq_37
  DataType: bool
  OrigDataType: bool
T_38: (in 0<u64> @ 00400497 : uint64)
  Class: Eq_38
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_39: (in false @ 004004C0 : bool)
  Class: Eq_39
  DataType: bool
  OrigDataType: bool
T_40: (in true @ 004004CC : bool)
  Class: Eq_40
  DataType: bool
  OrigDataType: bool
T_41: (in 0<u64> @ 004004D7 : uint64)
  Class: Eq_41
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_42: (in 0000000000601040 @ 004004E7 : ptr64)
  Class: Eq_42
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_43 t0000)))
T_43: (in Mem0[0x0000000000601040<p64>:byte] @ 004004E7 : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_44: (in 0<8> @ 004004E7 : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_45: (in g_b601040 != 0<8> @ 00000000 : bool)
  Class: Eq_45
  DataType: bool
  OrigDataType: bool
T_46: (in deregister_tm_clones @ 004004ED : ptr64)
  Class: Eq_46
  DataType: (ptr64 Eq_46)
  OrigDataType: (ptr64 (fn T_48 ()))
T_47: (in signature of deregister_tm_clones @ 00400470 : void)
  Class: Eq_46
  DataType: (ptr64 Eq_46)
  OrigDataType: 
T_48: (in deregister_tm_clones() @ 004004ED : void)
  Class: Eq_48
  DataType: void
  OrigDataType: void
T_49: (in 1<8> @ 004004F3 : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_50: (in 0000000000601040 @ 004004F3 : ptr64)
  Class: Eq_50
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_51 t0000)))
T_51: (in Mem19[0x0000000000601040<p64>:byte] @ 004004F3 : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_52: (in 0000000000600E20 @ 00400508 : ptr64)
  Class: Eq_52
  DataType: (ptr64 word64)
  OrigDataType: (ptr64 (struct (0 T_53 t0000)))
T_53: (in Mem0[0x0000000000600E20<p64>:word64] @ 00400508 : word64)
  Class: Eq_53
  DataType: word64
  OrigDataType: word64
T_54: (in 0<64> @ 00400508 : word64)
  Class: Eq_53
  DataType: word64
  OrigDataType: word64
T_55: (in g_qw600E20 == 0<64> @ 00000000 : bool)
  Class: Eq_55
  DataType: bool
  OrigDataType: bool
T_56: (in true @ 00400512 : bool)
  Class: Eq_56
  DataType: bool
  OrigDataType: bool
T_57: (in fn0000000000000000 @ 0040051D : ptr64)
  Class: Eq_57
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_58: (in signature of fn0000000000000000 @ 00000000 : void)
  Class: Eq_58
  DataType: Eq_58
  OrigDataType: 
T_59: (in register_tm_clones @ 00400520 : ptr64)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: (ptr64 (fn T_61 ()))
T_60: (in signature of register_tm_clones @ 004004A0 : void)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: 
T_61: (in register_tm_clones() @ 00400520 : void)
  Class: Eq_61
  DataType: void
  OrigDataType: void
T_62: (in register_tm_clones @ 00400528 : ptr64)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: (ptr64 (fn T_63 ()))
T_63: (in register_tm_clones() @ 00400528 : void)
  Class: Eq_61
  DataType: void
  OrigDataType: void
T_64: (in eax @ 00400528 : int32)
  Class: Eq_64
  DataType: int32
  OrigDataType: word32
T_65: (in putchar @ 0040053C : ptr64)
  Class: Eq_65
  DataType: (ptr64 Eq_65)
  OrigDataType: (ptr64 (fn T_69 (T_68)))
T_66: (in signature of putchar @ 00000000 : void)
  Class: Eq_65
  DataType: (ptr64 Eq_65)
  OrigDataType: 
T_67: (in c @ 0040053C : int32)
  Class: Eq_67
  DataType: int32
  OrigDataType: 
T_68: (in 120<i32> @ 0040053C : int32)
  Class: Eq_67
  DataType: int32
  OrigDataType: int32
T_69: (in putchar(120<i32>) @ 0040053C : int32)
  Class: Eq_64
  DataType: int32
  OrigDataType: int32
T_70: (in f @ 00400546 : ptr64)
  Class: Eq_70
  DataType: (ptr64 Eq_70)
  OrigDataType: (ptr64 (fn T_72 ()))
T_71: (in signature of f @ 0040052D : void)
  Class: Eq_70
  DataType: (ptr64 Eq_70)
  OrigDataType: 
T_72: (in f() @ 00400546 : word32)
  Class: Eq_72
  DataType: word32
  OrigDataType: word32
T_73: (in rdx @ 0040054C : word64)
  Class: Eq_73
  DataType: word64
  OrigDataType: word64
T_74: (in rsi @ 0040054C : word64)
  Class: Eq_74
  DataType: word64
  OrigDataType: word64
T_75: (in edi @ 0040054C : word32)
  Class: Eq_75
  DataType: word32
  OrigDataType: word32
T_76: (in rdi @ 00400550 : word64)
  Class: Eq_76
  DataType: word64
  OrigDataType: word64
T_77: (in SLICE(rdi, word32, 0) @ 00400550 : word32)
  Class: Eq_75
  DataType: word32
  OrigDataType: word32
T_78: (in _init @ 0040057E : ptr64)
  Class: Eq_78
  DataType: (ptr64 Eq_78)
  OrigDataType: (ptr64 (fn T_80 ()))
T_79: (in signature of _init @ 004003E0 : void)
  Class: Eq_78
  DataType: (ptr64 Eq_78)
  OrigDataType: 
T_80: (in _init() @ 0040057E : void)
  Class: Eq_80
  DataType: void
  OrigDataType: void
T_81: (in rbp_31 @ 00400571 : int64)
  Class: Eq_81
  DataType: int64
  OrigDataType: int64
T_82: (in 0000000000600E18 @ 00400571 : ptr64)
  Class: Eq_82
  DataType: int64
  OrigDataType: (union (int64 u0) (ptr64 u1))
T_83: (in 0000000000600E10 @ 00400571 : ptr64)
  Class: Eq_83
  DataType: int64
  OrigDataType: (union (int64 u1) (ptr64 u0))
T_84: (in 0x600E18<u64> - 0x600E10<u64> @ 00000000 : word64)
  Class: Eq_81
  DataType: int64
  OrigDataType: int64
T_85: (in rbx_33 @ 00400574 : Eq_85)
  Class: Eq_85
  DataType: Eq_85
  OrigDataType: word64
T_86: (in 0<u64> @ 00400574 : uint64)
  Class: Eq_85
  DataType: uint64
  OrigDataType: uint64
T_87: (in 3<64> @ 00400586 : word64)
  Class: Eq_87
  DataType: word64
  OrigDataType: word64
T_88: (in rbp_31 >> 3<64> @ 00000000 : word64)
  Class: Eq_88
  DataType: int64
  OrigDataType: int64
T_89: (in 0<64> @ 00400586 : word64)
  Class: Eq_88
  DataType: int64
  OrigDataType: word64
T_90: (in rbp_31 >> 3<64> == 0<64> @ 00000000 : bool)
  Class: Eq_90
  DataType: bool
  OrigDataType: bool
T_91: (in 0000000000600E10 @ 00400599 : ptr64)
  Class: Eq_91
  DataType: (ptr64 (arr (ptr64 code)))
  OrigDataType: (ptr64 (struct (0 (arr T_99) a0000)))
T_92: (in 8<64> @ 00400599 : word64)
  Class: Eq_92
  DataType: ui64
  OrigDataType: ui64
T_93: (in rbx_33 * 8<64> @ 00000000 : word64)
  Class: Eq_93
  DataType: ui64
  OrigDataType: ui64
T_94: (in 0x0000000000600E10<p64>[rbx_33 * 8<64>] @ 00400599 : word64)
  Class: Eq_94
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_95: (in 1<64> @ 0040059D : word64)
  Class: Eq_95
  DataType: word64
  OrigDataType: word64
T_96: (in rbx_33 + 1<64> @ 0040059D : word64)
  Class: Eq_85
  DataType: Eq_85
  OrigDataType: uint64
T_97: (in rbp_31 >> 3<64> @ 00000000 : word64)
  Class: Eq_85
  DataType: Eq_85
  OrigDataType: int64
T_98: (in rbx_33 != rbp_31 >> 3<64> @ 00000000 : bool)
  Class: Eq_98
  DataType: bool
  OrigDataType: bool
T_99:
  Class: Eq_99
  DataType: (ptr64 code)
  OrigDataType: (struct 0008 (0 T_94 t0000))
*/
typedef struct Globals {
	<anonymous> t400416;	// 400416
	<anonymous> t400426;	// 400426
	<anonymous> t400436;	// 400436
	Eq_19 t40053D;	// 40053D
	Eq_22 t400550;	// 400550
	Eq_23 t4005C0;	// 4005C0
	<anonymous> * a600E10[];	// 600E10
	word64 qw600E20;	// 600E20
	<anonymous> * __gmon_start___GOT;	// 600FF8
	<anonymous> * putchar_GOT;	// 601018
	<anonymous> * __libc_start_main_GOT;	// 601020
	<anonymous> * __gmon_start___GOT;	// 601028
	byte b601040;	// 601040
} Eq_1;

typedef void (Eq_8)();

typedef void (Eq_10)(ptr64);

typedef int32 (Eq_17)( *, int32, char * *,  *,  *,  *, void);

typedef int32 (Eq_19)(int32 rdi, char * * rsi, char * * rdx);

typedef void (Eq_22)();

typedef void (Eq_23)();

typedef void (Eq_33)();

typedef void (Eq_46)();

typedef void (Eq_59)();

typedef int32 (Eq_65)(int32);

typedef word32 (Eq_70)();

typedef void (Eq_78)();

typedef union Eq_82 {
	int64 u0;
	ptr64 u1;
} Eq_82;

typedef union Eq_83 {
	int64 u0;
	ptr64 u1;
} Eq_83;

typedef union Eq_85 {
	int64 u0;
	uint64 u1;
} Eq_85;

