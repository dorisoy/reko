// ais3_crackme.h
// Generated by decompiling ais3_crackme
// using Reko decompiler version 0.9.4.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (4003F6 code t4003F6) (400406 code t400406) (4005C5 Eq_16 t4005C5) (400620 Eq_19 t400620) (4006B0 Eq_20 t4006B0) (4006C8 (str char) str4006C8) (4006F0 (str char) str4006F0) (400718 (str char) str400718) (600DF8 (arr (ptr64 code)) a600DF8) (600E08 word64 qw600E08) (600FE0 (ptr64 code) __gmon_start___GOT) (601000 (ptr64 code) puts_GOT) (601008 (ptr64 code) __libc_start_main_GOT) (601020 (arr byte) a601020) (601038 byte b601038))
	globals_t (in globals @ 00000000 : (ptr64 (struct "Globals")))
Eq_2: (fn void ())
	T_2 (in call_gmon_start @ 004003CC : ptr64)
	T_3 (in signature of call_gmon_start @ 0040043C : void)
Eq_5: (fn void ())
	T_5 (in rdx @ 004003D5 : (ptr64 Eq_5))
	T_21 (in rtld_fini @ 00400434 : (ptr64 (fn void ())))
Eq_6: (union "Eq_6" (int32 u0) (word64 u1))
	T_6 (in qwArg00 @ 004003D5 : Eq_6)
	T_17 (in argc @ 00400434 : int32)
Eq_7: (fn void (ptr64))
	T_7 (in __align @ 00400419 : ptr64)
	T_8 (in signature of __align @ 00000000 : void)
Eq_14: (fn int32 ((ptr64 Eq_16), Eq_6, (ptr64 (ptr64 char)), (ptr64 Eq_19), (ptr64 Eq_20), (ptr64 Eq_5), (ptr64 void)))
	T_14 (in __libc_start_main @ 00400434 : ptr64)
	T_15 (in signature of __libc_start_main @ 00000000 : void)
Eq_16: (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))
	T_16 (in main @ 00400434 : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
	T_23 (in 0x4005C5<64> @ 00400434 : word64)
Eq_19: (fn void ())
	T_19 (in init @ 00400434 : (ptr64 (fn void ())))
	T_25 (in 0x400620<64> @ 00400434 : word64)
Eq_20: (fn void ())
	T_20 (in fini @ 00400434 : (ptr64 (fn void ())))
	T_26 (in 0x4006B0<64> @ 00400434 : word64)
Eq_28: (fn void ())
	T_28 (in __hlt @ 00400439 : ptr64)
	T_29 (in signature of __hlt @ 00000000 : void)
Eq_46: (fn void ())
	T_46 (in deregister_tm_clones @ 004004DD : ptr64)
	T_47 (in signature of deregister_tm_clones @ 00400460 : void)
Eq_59: (fn void ())
	T_59 (in register_tm_clones @ 00400510 : ptr64)
	T_60 (in signature of register_tm_clones @ 00400490 : void)
	T_62 (in register_tm_clones @ 00400518 : ptr64)
Eq_167: (struct "Eq_167" (8 (ptr64 (arr byte)) ptr0008))
	T_167 (in rsi @ 004005C4 : (ptr64 Eq_167))
Eq_171: (fn uint32 ((ptr64 (arr byte))))
	T_171 (in verify @ 00400600 : ptr64)
	T_172 (in signature of verify @ 00400520 : void)
Eq_181: (fn int32 ((ptr64 char)))
	T_181 (in puts @ 004005DF : ptr64)
	T_182 (in signature of puts @ 00000000 : void)
	T_186 (in puts @ 00400613 : ptr64)
	T_189 (in puts @ 00400607 : ptr64)
Eq_197: (fn void ())
	T_197 (in _init @ 00400660 : ptr64)
	T_198 (in signature of _init @ 004003C8 : void)
Eq_201: (union "Eq_201" (int64 u0) (ptr64 u1))
	T_201 (in 0000000000600E00 @ 00400650 : ptr64)
Eq_202: (union "Eq_202" (int64 u0) (ptr64 u1))
	T_202 (in 0000000000600DF8 @ 00400650 : ptr64)
Eq_211: (union "Eq_211" (int64 u0) (uint64 u1))
	T_211 (in rbx_38 @ 0040066A : Eq_211)
	T_212 (in 0<u64> @ 0040066A : uint64)
	T_218 (in rbx_38 + 1<64> @ 0040067D : word64)
	T_219 (in rbp_19 >> 3<64> @ 00000000 : word64)
// Type Variables ////////////
globals_t: (in globals : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in call_gmon_start : ptr64)
  Class: Eq_2
  DataType: (ptr64 Eq_2)
  OrigDataType: (ptr64 (fn T_4 ()))
T_3: (in signature of call_gmon_start : void)
  Class: Eq_2
  DataType: (ptr64 Eq_2)
  OrigDataType: 
T_4: (in call_gmon_start() : void)
  Class: Eq_4
  DataType: void
  OrigDataType: void
T_5: (in rdx : (ptr64 Eq_5))
  Class: Eq_5
  DataType: (ptr64 Eq_5)
  OrigDataType: (ptr64 (fn void ()))
T_6: (in qwArg00 : Eq_6)
  Class: Eq_6
  DataType: Eq_6
  OrigDataType: (union (int32 u1) (word64 u0))
T_7: (in __align : ptr64)
  Class: Eq_7
  DataType: (ptr64 Eq_7)
  OrigDataType: (ptr64 (fn T_13 (T_12)))
T_8: (in signature of __align : void)
  Class: Eq_7
  DataType: (ptr64 Eq_7)
  OrigDataType: 
T_9: (in  : word64)
  Class: Eq_9
  DataType: ptr64
  OrigDataType: 
T_10: (in fp : ptr64)
  Class: Eq_10
  DataType: (ptr64 void)
  OrigDataType: (ptr64 void)
T_11: (in 8<i64> : int64)
  Class: Eq_11
  DataType: int64
  OrigDataType: int64
T_12: (in fp + 8<i64> : word64)
  Class: Eq_9
  DataType: ptr64
  OrigDataType: ptr64
T_13: (in __align((char *) fp + 8<i32>) : void)
  Class: Eq_13
  DataType: void
  OrigDataType: void
T_14: (in __libc_start_main : ptr64)
  Class: Eq_14
  DataType: (ptr64 Eq_14)
  OrigDataType: (ptr64 (fn T_27 (T_23, T_6, T_24, T_25, T_26, T_5, T_10)))
T_15: (in signature of __libc_start_main : void)
  Class: Eq_14
  DataType: (ptr64 Eq_14)
  OrigDataType: 
T_16: (in main : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
  Class: Eq_16
  DataType: (ptr64 Eq_16)
  OrigDataType: 
T_17: (in argc : int32)
  Class: Eq_6
  DataType: Eq_6
  OrigDataType: 
T_18: (in ubp_av : (ptr64 (ptr64 char)))
  Class: Eq_18
  DataType: (ptr64 (ptr64 char))
  OrigDataType: 
T_19: (in init : (ptr64 (fn void ())))
  Class: Eq_19
  DataType: (ptr64 Eq_19)
  OrigDataType: 
T_20: (in fini : (ptr64 (fn void ())))
  Class: Eq_20
  DataType: (ptr64 Eq_20)
  OrigDataType: 
T_21: (in rtld_fini : (ptr64 (fn void ())))
  Class: Eq_5
  DataType: (ptr64 Eq_5)
  OrigDataType: 
T_22: (in stack_end : (ptr64 void))
  Class: Eq_10
  DataType: (ptr64 void)
  OrigDataType: 
T_23: (in 0x4005C5<64> : word64)
  Class: Eq_16
  DataType: (ptr64 Eq_16)
  OrigDataType: (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char)))))
T_24: (in fp + 8<i64> : word64)
  Class: Eq_18
  DataType: (ptr64 (ptr64 char))
  OrigDataType: (ptr64 (ptr64 char))
T_25: (in 0x400620<64> : word64)
  Class: Eq_19
  DataType: (ptr64 Eq_19)
  OrigDataType: (ptr64 (fn void ()))
T_26: (in 0x4006B0<64> : word64)
  Class: Eq_20
  DataType: (ptr64 Eq_20)
  OrigDataType: (ptr64 (fn void ()))
T_27: (in __libc_start_main(&g_t4005C5, qwArg00, (char *) fp + 8<i32>, &g_t400620, &g_t4006B0, rdx, fp) : int32)
  Class: Eq_27
  DataType: int32
  OrigDataType: int32
T_28: (in __hlt : ptr64)
  Class: Eq_28
  DataType: (ptr64 Eq_28)
  OrigDataType: (ptr64 (fn T_30 ()))
T_29: (in signature of __hlt : void)
  Class: Eq_28
  DataType: (ptr64 Eq_28)
  OrigDataType: 
T_30: (in __hlt() : void)
  Class: Eq_30
  DataType: void
  OrigDataType: void
T_31: (in __gmon_start__ : ptr64)
  Class: Eq_31
  DataType: word64
  OrigDataType: 
T_32: (in signature of __gmon_start__ : void)
  Class: Eq_32
  DataType: Eq_32
  OrigDataType: 
T_33: (in 0<64> : word64)
  Class: Eq_31
  DataType: word64
  OrigDataType: word64
T_34: (in __gmon_start__ == 0<64> : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_35: (in __gmon_start__ : ptr64)
  Class: Eq_35
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_36: (in false : bool)
  Class: Eq_36
  DataType: bool
  OrigDataType: bool
T_37: (in true : bool)
  Class: Eq_37
  DataType: bool
  OrigDataType: bool
T_38: (in 0<u64> : uint64)
  Class: Eq_38
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_39: (in false : bool)
  Class: Eq_39
  DataType: bool
  OrigDataType: bool
T_40: (in true : bool)
  Class: Eq_40
  DataType: bool
  OrigDataType: bool
T_41: (in 0<u64> : uint64)
  Class: Eq_41
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_42: (in 0000000000601038 : ptr64)
  Class: Eq_42
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_43 t0000)))
T_43: (in Mem0[0x0000000000601038<p64>:byte] : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_44: (in 0<8> : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_45: (in g_b601038 != 0<8> : bool)
  Class: Eq_45
  DataType: bool
  OrigDataType: bool
T_46: (in deregister_tm_clones : ptr64)
  Class: Eq_46
  DataType: (ptr64 Eq_46)
  OrigDataType: (ptr64 (fn T_48 ()))
T_47: (in signature of deregister_tm_clones : void)
  Class: Eq_46
  DataType: (ptr64 Eq_46)
  OrigDataType: 
T_48: (in deregister_tm_clones() : void)
  Class: Eq_48
  DataType: void
  OrigDataType: void
T_49: (in 1<8> : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_50: (in 0000000000601038 : ptr64)
  Class: Eq_50
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_51 t0000)))
T_51: (in Mem19[0x0000000000601038<p64>:byte] : byte)
  Class: Eq_43
  DataType: byte
  OrigDataType: byte
T_52: (in 0000000000600E08 : ptr64)
  Class: Eq_52
  DataType: (ptr64 word64)
  OrigDataType: (ptr64 (struct (0 T_53 t0000)))
T_53: (in Mem0[0x0000000000600E08<p64>:word64] : word64)
  Class: Eq_53
  DataType: word64
  OrigDataType: word64
T_54: (in 0<64> : word64)
  Class: Eq_53
  DataType: word64
  OrigDataType: word64
T_55: (in g_qw600E08 == 0<64> : bool)
  Class: Eq_55
  DataType: bool
  OrigDataType: bool
T_56: (in true : bool)
  Class: Eq_56
  DataType: bool
  OrigDataType: bool
T_57: (in fn0000000000000000 : ptr64)
  Class: Eq_57
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_58: (in signature of fn0000000000000000 : void)
  Class: Eq_58
  DataType: Eq_58
  OrigDataType: 
T_59: (in register_tm_clones : ptr64)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: (ptr64 (fn T_61 ()))
T_60: (in signature of register_tm_clones : void)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: 
T_61: (in register_tm_clones() : void)
  Class: Eq_61
  DataType: void
  OrigDataType: void
T_62: (in register_tm_clones : ptr64)
  Class: Eq_59
  DataType: (ptr64 Eq_59)
  OrigDataType: (ptr64 (fn T_63 ()))
T_63: (in register_tm_clones() : void)
  Class: Eq_61
  DataType: void
  OrigDataType: void
T_64: (in eax : word32)
  Class: Eq_64
  DataType: word32
  OrigDataType: word32
T_65: (in rdi : (arr byte))
  Class: Eq_65
  DataType: (ptr64 (arr byte))
  OrigDataType: (ptr64 (struct (0 (arr T_221) a0000)))
T_66: (in dwLoc0C_130 : word32)
  Class: Eq_66
  DataType: word32
  OrigDataType: word32
T_67: (in 0<32> : word32)
  Class: Eq_66
  DataType: word32
  OrigDataType: word32
T_68: (in rax_117 : uint64)
  Class: Eq_68
  DataType: uint64
  OrigDataType: uint64
T_69: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_69
  DataType: uint64
  OrigDataType: uint64
T_70: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_70
  DataType: word32
  OrigDataType: word32
T_71: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) : int64)
  Class: Eq_71
  DataType: int64
  OrigDataType: int64
T_72: (in rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) : word64)
  Class: Eq_72
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_73 t0000)))
T_73: (in Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte] : byte)
  Class: Eq_73
  DataType: byte
  OrigDataType: byte
T_74: (in CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32) : word32)
  Class: Eq_74
  DataType: word32
  OrigDataType: word32
T_75: (in CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64) : uint64)
  Class: Eq_75
  DataType: uint64
  OrigDataType: uint64
T_76: (in SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), byte, 0) : byte)
  Class: Eq_76
  DataType: byte
  OrigDataType: byte
T_77: (in 0<8> : byte)
  Class: Eq_76
  DataType: byte
  OrigDataType: byte
T_78: (in (byte) (uint64) (word32) rdi[(int64) (word32) (uint64) dwLoc0C_130] != 0<8> : bool)
  Class: Eq_78
  DataType: bool
  OrigDataType: bool
T_79: (in al_42 : byte)
  Class: Eq_79
  DataType: byte
  OrigDataType: byte
T_80: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_80
  DataType: uint64
  OrigDataType: uint64
T_81: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_81
  DataType: word32
  OrigDataType: word32
T_82: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_82
  DataType: uint64
  OrigDataType: uint64
T_83: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_83
  DataType: word32
  OrigDataType: word32
T_84: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) : int64)
  Class: Eq_84
  DataType: int64
  OrigDataType: int64
T_85: (in rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) : word64)
  Class: Eq_85
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_86 t0000)))
T_86: (in Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte] : byte)
  Class: Eq_73
  DataType: byte
  OrigDataType: byte
T_87: (in CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32) : word32)
  Class: Eq_87
  DataType: word32
  OrigDataType: word32
T_88: (in CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64) : uint64)
  Class: Eq_88
  DataType: uint64
  OrigDataType: uint64
T_89: (in SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), word32, 0) : word32)
  Class: Eq_89
  DataType: word32
  OrigDataType: word32
T_90: (in CONVERT(SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_90
  DataType: uint64
  OrigDataType: uint64
T_91: (in SLICE(CONVERT(SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_91
  DataType: word32
  OrigDataType: word32
T_92: (in (word32) (uint64) dwLoc0C_130 ^ (word32) ((uint64) ((word32) ((uint64) ((word32) rdi[(int64) ((word32) ((uint64) dwLoc0C_130))])))) : word32)
  Class: Eq_92
  DataType: ui32
  OrigDataType: ui32
T_93: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ SLICE(CONVERT(SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_93
  DataType: uint64
  OrigDataType: uint64
T_94: (in SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ SLICE(CONVERT(SLICE(CONVERT(CONVERT(Mem12[rdi + CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64):byte], byte, word32), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0) : byte)
  Class: Eq_79
  DataType: byte
  OrigDataType: byte
T_95: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_95
  DataType: uint64
  OrigDataType: uint64
T_96: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_96
  DataType: word32
  OrigDataType: word32
T_97: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) : int64)
  Class: Eq_97
  DataType: int64
  OrigDataType: int64
T_98: (in 0x601020<64> : word64)
  Class: Eq_98
  DataType: (ptr64 (arr byte))
  OrigDataType: (ptr64 (struct (0 (arr T_225) a0000)))
T_99: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) + 0x601020<64> : word64)
  Class: Eq_99
  DataType: int64
  OrigDataType: int64
T_100: (in Mem103[CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) + 0x601020<64>:byte] : byte)
  Class: Eq_100
  DataType: byte
  OrigDataType: byte
T_101: (in CONVERT(Mem103[CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) + 0x601020<64>:byte], byte, word32) : word32)
  Class: Eq_101
  DataType: word32
  OrigDataType: word32
T_102: (in CONVERT(CONVERT(Mem103[CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) + 0x601020<64>:byte], byte, word32), word32, uint64) : uint64)
  Class: Eq_102
  DataType: uint64
  OrigDataType: uint64
T_103: (in SLICE(CONVERT(CONVERT(Mem103[CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0), word32, int64) + 0x601020<64>:byte], byte, word32), word32, uint64), byte, 0) : byte)
  Class: Eq_103
  DataType: byte
  OrigDataType: byte
T_104: (in CONVERT(al_42, byte, word32) : word32)
  Class: Eq_104
  DataType: word32
  OrigDataType: word32
T_105: (in CONVERT(CONVERT(al_42, byte, word32), word32, uint64) : uint64)
  Class: Eq_105
  DataType: uint64
  OrigDataType: uint64
T_106: (in SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) : word32)
  Class: Eq_106
  DataType: int32
  OrigDataType: int32
T_107: (in 8<32> : word32)
  Class: Eq_107
  DataType: word32
  OrigDataType: word32
T_108: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_108
  DataType: uint64
  OrigDataType: uint64
T_109: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_109
  DataType: word32
  OrigDataType: word32
T_110: (in 9<32> : word32)
  Class: Eq_110
  DataType: word32
  OrigDataType: word32
T_111: (in (word32) (uint64) dwLoc0C_130 ^ 9<32> : word32)
  Class: Eq_111
  DataType: ui32
  OrigDataType: ui32
T_112: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64) : uint64)
  Class: Eq_112
  DataType: uint64
  OrigDataType: uint64
T_113: (in SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_113
  DataType: ui32
  OrigDataType: ui32
T_114: (in 3<32> : word32)
  Class: Eq_114
  DataType: ui32
  OrigDataType: ui32
T_115: (in (word32) (uint64) ((word32) (uint64) dwLoc0C_130 ^ 9<32>) & 3<32> : word32)
  Class: Eq_115
  DataType: ui32
  OrigDataType: ui32
T_116: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64) : uint64)
  Class: Eq_116
  DataType: uint64
  OrigDataType: uint64
T_117: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_117
  DataType: word32
  OrigDataType: word32
T_118: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_118
  DataType: uint64
  OrigDataType: uint64
T_119: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_119
  DataType: word32
  OrigDataType: word32
T_120: (in 8<32> - (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))) : word32)
  Class: Eq_120
  DataType: word32
  OrigDataType: word32
T_121: (in CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_121
  DataType: uint64
  OrigDataType: uint64
T_122: (in SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_122
  DataType: word32
  OrigDataType: word32
T_123: (in CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_123
  DataType: uint64
  OrigDataType: uint64
T_124: (in SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0) : byte)
  Class: Eq_124
  DataType: byte
  OrigDataType: byte
T_125: (in (word32) (uint64) (word32) al_42 >> (byte) ((uint64) ((word32) ((uint64) (8<32> - (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))))))) : word32)
  Class: Eq_125
  DataType: int32
  OrigDataType: int32
T_126: (in CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64) : uint64)
  Class: Eq_126
  DataType: uint64
  OrigDataType: uint64
T_127: (in SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_127
  DataType: word32
  OrigDataType: word32
T_128: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_128
  DataType: uint64
  OrigDataType: uint64
T_129: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_129
  DataType: ui32
  OrigDataType: ui32
T_130: (in CONVERT(al_42, byte, word32) : word32)
  Class: Eq_130
  DataType: word32
  OrigDataType: word32
T_131: (in CONVERT(CONVERT(al_42, byte, word32), word32, uint64) : uint64)
  Class: Eq_131
  DataType: uint64
  OrigDataType: uint64
T_132: (in SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) : word32)
  Class: Eq_132
  DataType: ui32
  OrigDataType: ui32
T_133: (in CONVERT(dwLoc0C_130, word32, uint64) : uint64)
  Class: Eq_133
  DataType: uint64
  OrigDataType: uint64
T_134: (in SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) : word32)
  Class: Eq_134
  DataType: word32
  OrigDataType: word32
T_135: (in 9<32> : word32)
  Class: Eq_135
  DataType: word32
  OrigDataType: word32
T_136: (in (word32) (uint64) dwLoc0C_130 ^ 9<32> : word32)
  Class: Eq_136
  DataType: ui32
  OrigDataType: ui32
T_137: (in CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64) : uint64)
  Class: Eq_137
  DataType: uint64
  OrigDataType: uint64
T_138: (in SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_138
  DataType: ui32
  OrigDataType: ui32
T_139: (in 3<32> : word32)
  Class: Eq_139
  DataType: ui32
  OrigDataType: ui32
T_140: (in (word32) (uint64) ((word32) (uint64) dwLoc0C_130 ^ 9<32>) & 3<32> : word32)
  Class: Eq_140
  DataType: ui32
  OrigDataType: ui32
T_141: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64) : uint64)
  Class: Eq_141
  DataType: uint64
  OrigDataType: uint64
T_142: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_142
  DataType: word32
  OrigDataType: word32
T_143: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_143
  DataType: uint64
  OrigDataType: uint64
T_144: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0) : byte)
  Class: Eq_144
  DataType: byte
  OrigDataType: byte
T_145: (in (word32) (uint64) (word32) al_42 << (byte) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))) : word32)
  Class: Eq_145
  DataType: ui32
  OrigDataType: ui32
T_146: (in CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64) : uint64)
  Class: Eq_146
  DataType: uint64
  OrigDataType: uint64
T_147: (in SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_147
  DataType: word32
  OrigDataType: word32
T_148: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_148
  DataType: uint64
  OrigDataType: uint64
T_149: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_149
  DataType: word32
  OrigDataType: word32
T_150: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_150
  DataType: uint64
  OrigDataType: uint64
T_151: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_151
  DataType: ui32
  OrigDataType: ui32
T_152: (in (word32) (uint64) (word32) (uint64) ((word32) (uint64) (word32) al_42 >> (byte) ((uint64) ((word32) ((uint64) (8<32> - (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>))))))))) | (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) al_42)) << (byte) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))))))))) : word32)
  Class: Eq_152
  DataType: ui32
  OrigDataType: ui32
T_153: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) | SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_153
  DataType: uint64
  OrigDataType: uint64
T_154: (in SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) >> SLICE(CONVERT(SLICE(CONVERT(8<32> - SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0) | SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(CONVERT(al_42, byte, word32), word32, uint64), word32, 0) << SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(SLICE(CONVERT(dwLoc0C_130, word32, uint64), word32, 0) ^ 9<32>, word32, uint64), word32, 0) & 3<32>, word32, uint64), word32, 0), word32, uint64), byte, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), word32, 0), word32, uint64), byte, 0) : byte)
  Class: Eq_154
  DataType: byte
  OrigDataType: byte
T_155: (in 8<8> : byte)
  Class: Eq_155
  DataType: byte
  OrigDataType: byte
T_156: (in (byte) (uint64) ((word32) (uint64) (word32) (uint64) ((word32) (uint64) (word32) al_42 >> (byte) ((uint64) ((word32) ((uint64) (8<32> - (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>))))))))) | (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) al_42)) << (byte) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>))))))))))) + 8<8> : byte)
  Class: Eq_103
  DataType: byte
  OrigDataType: byte
T_157: (in (byte) (uint64) (word32) g_a601020[(int64) (word32) (uint64) dwLoc0C_130] == (byte) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) al_42)) >> (byte) ((uint64) ((word32) ((uint64) (8<32> - (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))))))))))) | (word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) al_42)) << (byte) ((uint64) ((word32) ((uint64) ((word32) ((uint64) ((word32) ((uint64) dwLoc0C_130) ^ 9<32>)) & 3<32>)))))))))))) + 8<8> : bool)
  Class: Eq_157
  DataType: bool
  OrigDataType: bool
T_158: (in 0x17<32> : word32)
  Class: Eq_66
  DataType: word32
  OrigDataType: word32
T_159: (in dwLoc0C_130 == 0x17<32> : bool)
  Class: Eq_159
  DataType: bool
  OrigDataType: bool
T_160: (in CONVERT(dwLoc0C_130 == 0x17<32>, bool, int8) : int8)
  Class: Eq_160
  DataType: int8
  OrigDataType: int8
T_161: (in CONVERT(CONVERT(dwLoc0C_130 == 0x17<32>, bool, int8), int8, word32) : word32)
  Class: Eq_161
  DataType: word32
  OrigDataType: word32
T_162: (in CONVERT(CONVERT(CONVERT(dwLoc0C_130 == 0x17<32>, bool, int8), int8, word32), word32, uint64) : uint64)
  Class: Eq_68
  DataType: uint64
  OrigDataType: uint64
T_163: (in 1<32> : word32)
  Class: Eq_163
  DataType: word32
  OrigDataType: word32
T_164: (in dwLoc0C_130 + 1<32> : word32)
  Class: Eq_66
  DataType: word32
  OrigDataType: word32
T_165: (in 0<u64> : uint64)
  Class: Eq_68
  DataType: uint64
  OrigDataType: uint64
T_166: (in SLICE(rax_117, word32, 0) : word32)
  Class: Eq_64
  DataType: word32
  OrigDataType: word32
T_167: (in rsi : (ptr64 Eq_167))
  Class: Eq_167
  DataType: (ptr64 Eq_167)
  OrigDataType: (ptr64 (struct (8 T_175 t0008)))
T_168: (in edi : word32)
  Class: Eq_168
  DataType: word32
  OrigDataType: word32
T_169: (in 2<32> : word32)
  Class: Eq_168
  DataType: word32
  OrigDataType: word32
T_170: (in edi == 2<32> : bool)
  Class: Eq_170
  DataType: bool
  OrigDataType: bool
T_171: (in verify : ptr64)
  Class: Eq_171
  DataType: (ptr64 Eq_171)
  OrigDataType: (ptr64 (fn T_176 (T_175)))
T_172: (in signature of verify : void)
  Class: Eq_171
  DataType: (ptr64 Eq_171)
  OrigDataType: 
T_173: (in 8<64> : word64)
  Class: Eq_173
  DataType: word64
  OrigDataType: word64
T_174: (in rsi + 8<64> : word64)
  Class: Eq_174
  DataType: word64
  OrigDataType: word64
T_175: (in Mem12[rsi + 8<64>:word64] : word64)
  Class: Eq_65
  DataType: (ptr64 (arr byte))
  OrigDataType: word64
T_176: (in verify(rsi->ptr0008) : word32)
  Class: Eq_176
  DataType: uint32
  OrigDataType: uint32
T_177: (in CONVERT(verify(rsi->ptr0008), uint32, uint64) : uint64)
  Class: Eq_177
  DataType: uint64
  OrigDataType: uint64
T_178: (in SLICE(CONVERT(verify(rsi->ptr0008), uint32, uint64), word32, 0) : word32)
  Class: Eq_178
  DataType: word32
  OrigDataType: word32
T_179: (in 0<32> : word32)
  Class: Eq_178
  DataType: word32
  OrigDataType: word32
T_180: (in (word32) (uint64) verify(rsi->ptr0008) == 0<32> : bool)
  Class: Eq_180
  DataType: bool
  OrigDataType: bool
T_181: (in puts : ptr64)
  Class: Eq_181
  DataType: (ptr64 Eq_181)
  OrigDataType: (ptr64 (fn T_185 (T_184)))
T_182: (in signature of puts : void)
  Class: Eq_181
  DataType: (ptr64 Eq_181)
  OrigDataType: 
T_183: (in s : (ptr64 char))
  Class: Eq_183
  DataType: (ptr64 char)
  OrigDataType: 
T_184: (in 0x4006C8<u64> : uint64)
  Class: Eq_183
  DataType: (ptr64 char)
  OrigDataType: (ptr64 char)
T_185: (in puts("You need to enter the secret key!") : int32)
  Class: Eq_185
  DataType: int32
  OrigDataType: int32
T_186: (in puts : ptr64)
  Class: Eq_181
  DataType: (ptr64 Eq_181)
  OrigDataType: (ptr64 (fn T_188 (T_187)))
T_187: (in 0x400718<u64> : uint64)
  Class: Eq_183
  DataType: (ptr64 char)
  OrigDataType: (ptr64 char)
T_188: (in puts("I'm sorry, that's the wrong secret key!") : int32)
  Class: Eq_185
  DataType: int32
  OrigDataType: int32
T_189: (in puts : ptr64)
  Class: Eq_181
  DataType: (ptr64 Eq_181)
  OrigDataType: (ptr64 (fn T_191 (T_190)))
T_190: (in 0x4006F0<u64> : uint64)
  Class: Eq_183
  DataType: (ptr64 char)
  OrigDataType: (ptr64 char)
T_191: (in puts("Correct! that is the secret key!") : int32)
  Class: Eq_185
  DataType: int32
  OrigDataType: int32
T_192: (in rdx : word64)
  Class: Eq_192
  DataType: word64
  OrigDataType: word64
T_193: (in rsi : word64)
  Class: Eq_193
  DataType: word64
  OrigDataType: word64
T_194: (in edi : word32)
  Class: Eq_194
  DataType: word32
  OrigDataType: word32
T_195: (in rdi : word64)
  Class: Eq_195
  DataType: word64
  OrigDataType: word64
T_196: (in SLICE(rdi, word32, 0) : word32)
  Class: Eq_194
  DataType: word32
  OrigDataType: word32
T_197: (in _init : ptr64)
  Class: Eq_197
  DataType: (ptr64 Eq_197)
  OrigDataType: (ptr64 (fn T_199 ()))
T_198: (in signature of _init : void)
  Class: Eq_197
  DataType: (ptr64 Eq_197)
  OrigDataType: 
T_199: (in _init() : void)
  Class: Eq_199
  DataType: void
  OrigDataType: void
T_200: (in rbp_19 : int64)
  Class: Eq_200
  DataType: int64
  OrigDataType: int64
T_201: (in 0000000000600E00 : ptr64)
  Class: Eq_201
  DataType: int64
  OrigDataType: (union (int64 u0) (ptr64 u1))
T_202: (in 0000000000600DF8 : ptr64)
  Class: Eq_202
  DataType: int64
  OrigDataType: (union (int64 u1) (ptr64 u0))
T_203: (in 0x600E00<u64> - 0x600DF8<u64> : word64)
  Class: Eq_200
  DataType: int64
  OrigDataType: int64
T_204: (in r13d_75 : word32)
  Class: Eq_204
  DataType: word32
  OrigDataType: word32
T_205: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_205
  DataType: uint64
  OrigDataType: uint64
T_206: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_204
  DataType: word32
  OrigDataType: word32
T_207: (in 3<64> : word64)
  Class: Eq_207
  DataType: word64
  OrigDataType: word64
T_208: (in rbp_19 >> 3<64> : word64)
  Class: Eq_208
  DataType: int64
  OrigDataType: int64
T_209: (in 0<64> : word64)
  Class: Eq_208
  DataType: int64
  OrigDataType: word64
T_210: (in rbp_19 >> 3<64> == 0<64> : bool)
  Class: Eq_210
  DataType: bool
  OrigDataType: bool
T_211: (in rbx_38 : Eq_211)
  Class: Eq_211
  DataType: Eq_211
  OrigDataType: word64
T_212: (in 0<u64> : uint64)
  Class: Eq_211
  DataType: uint64
  OrigDataType: uint64
T_213: (in 0000000000600DF8 : ptr64)
  Class: Eq_213
  DataType: (ptr64 (arr (ptr64 code)))
  OrigDataType: (ptr64 (struct (0 (arr T_226) a0000)))
T_214: (in 8<64> : word64)
  Class: Eq_214
  DataType: ui64
  OrigDataType: ui64
T_215: (in rbx_38 * 8<64> : word64)
  Class: Eq_215
  DataType: ui64
  OrigDataType: ui64
T_216: (in 0x0000000000600DF8<p64>[rbx_38 * 8<64>] : word64)
  Class: Eq_216
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_217: (in 1<64> : word64)
  Class: Eq_217
  DataType: word64
  OrigDataType: word64
T_218: (in rbx_38 + 1<64> : word64)
  Class: Eq_211
  DataType: Eq_211
  OrigDataType: uint64
T_219: (in rbp_19 >> 3<64> : word64)
  Class: Eq_211
  DataType: Eq_211
  OrigDataType: int64
T_220: (in rbx_38 != rbp_19 >> 3<64> : bool)
  Class: Eq_220
  DataType: bool
  OrigDataType: bool
T_221:
  Class: Eq_221
  DataType: byte
  OrigDataType: (struct 0001 (0 T_73 t0000))
T_222:
  Class: Eq_222
  DataType: (arr byte)
  OrigDataType: (arr T_221)
T_223:
  Class: Eq_221
  DataType: byte
  OrigDataType: (struct 0001 (0 T_86 t0000))
T_224:
  Class: Eq_224
  DataType: (arr byte)
  OrigDataType: (arr T_223)
T_225:
  Class: Eq_225
  DataType: byte
  OrigDataType: (struct 0001 (0 T_100 t0000))
T_226:
  Class: Eq_226
  DataType: (ptr64 code)
  OrigDataType: (struct 0008 (0 T_216 t0000))
*/
typedef struct Globals {
	<anonymous> t4003F6;	// 4003F6
	<anonymous> t400406;	// 400406
	Eq_16 t4005C5;	// 4005C5
	Eq_19 t400620;	// 400620
	Eq_20 t4006B0;	// 4006B0
	char str4006C8[];	// 4006C8
	char str4006F0[];	// 4006F0
	char str400718[];	// 400718
	<anonymous> * a600DF8[];	// 600DF8
	word64 qw600E08;	// 600E08
	<anonymous> * __gmon_start___GOT;	// 600FE0
	<anonymous> * puts_GOT;	// 601000
	<anonymous> * __libc_start_main_GOT;	// 601008
	byte a601020[];	// 601020
	byte b601038;	// 601038
} Eq_1;

typedef void (Eq_2)();

typedef void (Eq_5)();

typedef union Eq_6 {
	int32 u0;
	word64 u1;
} Eq_6;

typedef void (Eq_7)(ptr64);

typedef int32 (Eq_14)( *, Eq_6, char * *,  *,  *,  *, void);

typedef int32 (Eq_16)(int32 rdi, char * * rsi, char * * rdx);

typedef void (Eq_19)();

typedef void (Eq_20)();

typedef void (Eq_28)();

typedef void (Eq_46)();

typedef void (Eq_59)();

typedef struct Eq_167 {
	byte (* ptr0008)[];	// 8
} Eq_167;

typedef uint32 (Eq_171)(byte *[]);

typedef int32 (Eq_181)(char *);

typedef void (Eq_197)();

typedef union Eq_201 {
	int64 u0;
	ptr64 u1;
} Eq_201;

typedef union Eq_202 {
	int64 u0;
	ptr64 u1;
} Eq_202;

typedef union Eq_211 {
	int64 u0;
	uint64 u1;
} Eq_211;

