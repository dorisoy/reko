// retpoline.h
// Generated by decompiling retpoline.elf
// using Reko decompiler version 0.9.2.3.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (400660 Eq_18 t400660) (400710 Eq_21 t400710) (400780 Eq_22 t400780) (600E10 (arr (ptr64 code)) a600E10) (601040 byte b601040))
	globals_t (in globals : (ptr64 (struct "Globals")))
Eq_7: (fn void ())
	T_7 (in rdx : (ptr64 Eq_7))
	T_23 (in rtld_fini : (ptr64 (fn void ())))
Eq_8: (union "Eq_8" (int32 u0) (word64 u1))
	T_8 (in qwArg00 : Eq_8)
	T_19 (in argc : int32)
Eq_9: (fn void (ptr64))
	T_9 (in __align : ptr64)
	T_10 (in signature of __align : void)
Eq_16: (fn int32 ((ptr64 Eq_18), Eq_8, (ptr64 (ptr64 char)), (ptr64 Eq_21), (ptr64 Eq_22), (ptr64 Eq_7), (ptr64 void)))
	T_16 (in __libc_start_main : ptr64)
	T_17 (in signature of __libc_start_main : void)
Eq_18: (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))
	T_18 (in main : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
	T_25 (in 0x400660<64> : word64)
Eq_21: (fn void ())
	T_21 (in init : (ptr64 (fn void ())))
	T_27 (in 0x400710<64> : word64)
Eq_22: (fn void ())
	T_22 (in fini : (ptr64 (fn void ())))
	T_28 (in 0x400780<64> : word64)
Eq_30: (fn void ())
	T_30 (in __hlt : ptr64)
	T_31 (in signature of __hlt : void)
Eq_43: (fn void ())
	T_43 (in deregister_tm_clones : ptr64)
	T_44 (in signature of deregister_tm_clones : void)
Eq_49: (fn void ())
	T_49 (in register_tm_clones : ptr64)
	T_50 (in signature of register_tm_clones : void)
Eq_132: (fn void (word32, word32))
	T_132 (in my1 : ptr64)
	T_133 (in signature of my1 : void)
Eq_139: (fn void ((ptr64 void)))
	T_139 (in free : ptr64)
	T_140 (in signature of free : void)
Eq_143: (fn void ())
	T_143 (in __llvm_retpoline_r11 : ptr64)
	T_144 (in signature of __llvm_retpoline_r11 : void)
Eq_146: (fn void ())
	T_146 (in fn0000000000400700 : ptr64)
	T_147 (in signature of fn0000000000400700 : void)
Eq_149: (fn void ())
	T_149 (in __pause : ptr64)
	T_150 (in signature of __pause : void)
Eq_157: (fn void ())
	T_157 (in _init : ptr64)
	T_158 (in signature of _init : void)
Eq_164: (union "Eq_164" (int64 u0) (ptr64 u1))
	T_164 (in 0000000000600E18 : ptr64)
Eq_165: (union "Eq_165" (int64 u0) (ptr64 u1))
	T_165 (in 0000000000600E10 : ptr64)
Eq_171: (union "Eq_171" (int64 u0) (uint64 u1))
	T_171 (in rbx_44 : Eq_171)
	T_172 (in 0<u64> : uint64)
	T_178 (in rbx_44 + 1<64> : word64)
	T_179 (in rbp_31 >> 3<64> : word64)
// Type Variables ////////////
globals_t: (in globals : (ptr64 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr64 Eq_1)
  OrigDataType: (ptr64 (struct "Globals"))
T_2: (in __gmon_start__ : ptr64)
  Class: Eq_2
  DataType: word64
  OrigDataType: 
T_3: (in signature of __gmon_start__ : void)
  Class: Eq_3
  DataType: Eq_3
  OrigDataType: 
T_4: (in 0<64> : word64)
  Class: Eq_2
  DataType: word64
  OrigDataType: word64
T_5: (in __gmon_start__ == 0<64> : bool)
  Class: Eq_5
  DataType: bool
  OrigDataType: bool
T_6: (in __gmon_start__ : ptr64)
  Class: Eq_6
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_7: (in rdx : (ptr64 Eq_7))
  Class: Eq_7
  DataType: (ptr64 Eq_7)
  OrigDataType: (ptr64 (fn void ()))
T_8: (in qwArg00 : Eq_8)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: (union (int32 u1) (word64 u0))
T_9: (in __align : ptr64)
  Class: Eq_9
  DataType: (ptr64 Eq_9)
  OrigDataType: (ptr64 (fn T_15 (T_14)))
T_10: (in signature of __align : void)
  Class: Eq_9
  DataType: (ptr64 Eq_9)
  OrigDataType: 
T_11: (in  : word64)
  Class: Eq_11
  DataType: ptr64
  OrigDataType: 
T_12: (in fp : ptr64)
  Class: Eq_12
  DataType: (ptr64 void)
  OrigDataType: (ptr64 void)
T_13: (in 8<i64> : int64)
  Class: Eq_13
  DataType: int64
  OrigDataType: int64
T_14: (in fp + 8<i64> : word64)
  Class: Eq_11
  DataType: ptr64
  OrigDataType: ptr64
T_15: (in __align((char *) fp + 8<i32>) : void)
  Class: Eq_15
  DataType: void
  OrigDataType: void
T_16: (in __libc_start_main : ptr64)
  Class: Eq_16
  DataType: (ptr64 Eq_16)
  OrigDataType: (ptr64 (fn T_29 (T_25, T_8, T_26, T_27, T_28, T_7, T_12)))
T_17: (in signature of __libc_start_main : void)
  Class: Eq_16
  DataType: (ptr64 Eq_16)
  OrigDataType: 
T_18: (in main : (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char))))))
  Class: Eq_18
  DataType: (ptr64 Eq_18)
  OrigDataType: 
T_19: (in argc : int32)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: 
T_20: (in ubp_av : (ptr64 (ptr64 char)))
  Class: Eq_20
  DataType: (ptr64 (ptr64 char))
  OrigDataType: 
T_21: (in init : (ptr64 (fn void ())))
  Class: Eq_21
  DataType: (ptr64 Eq_21)
  OrigDataType: 
T_22: (in fini : (ptr64 (fn void ())))
  Class: Eq_22
  DataType: (ptr64 Eq_22)
  OrigDataType: 
T_23: (in rtld_fini : (ptr64 (fn void ())))
  Class: Eq_7
  DataType: (ptr64 Eq_7)
  OrigDataType: 
T_24: (in stack_end : (ptr64 void))
  Class: Eq_12
  DataType: (ptr64 void)
  OrigDataType: 
T_25: (in 0x400660<64> : word64)
  Class: Eq_18
  DataType: (ptr64 Eq_18)
  OrigDataType: (ptr64 (fn int32 (int32, (ptr64 (ptr64 char)), (ptr64 (ptr64 char)))))
T_26: (in fp + 8<i64> : word64)
  Class: Eq_20
  DataType: (ptr64 (ptr64 char))
  OrigDataType: (ptr64 (ptr64 char))
T_27: (in 0x400710<64> : word64)
  Class: Eq_21
  DataType: (ptr64 Eq_21)
  OrigDataType: (ptr64 (fn void ()))
T_28: (in 0x400780<64> : word64)
  Class: Eq_22
  DataType: (ptr64 Eq_22)
  OrigDataType: (ptr64 (fn void ()))
T_29: (in __libc_start_main(&g_t400660, qwArg00, (char *) fp + 8<i32>, &g_t400710, &g_t400780, rdx, fp) : int32)
  Class: Eq_29
  DataType: int32
  OrigDataType: int32
T_30: (in __hlt : ptr64)
  Class: Eq_30
  DataType: (ptr64 Eq_30)
  OrigDataType: (ptr64 (fn T_32 ()))
T_31: (in signature of __hlt : void)
  Class: Eq_30
  DataType: (ptr64 Eq_30)
  OrigDataType: 
T_32: (in __hlt() : void)
  Class: Eq_32
  DataType: void
  OrigDataType: void
T_33: (in true : bool)
  Class: Eq_33
  DataType: bool
  OrigDataType: bool
T_34: (in true : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_35: (in 0<u64> : uint64)
  Class: Eq_35
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_36: (in true : bool)
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
T_39: (in 0000000000601040 : ptr64)
  Class: Eq_39
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_40 t0000)))
T_40: (in Mem0[0x0000000000601040<p64>:byte] : byte)
  Class: Eq_40
  DataType: byte
  OrigDataType: byte
T_41: (in 0<8> : byte)
  Class: Eq_40
  DataType: byte
  OrigDataType: byte
T_42: (in g_b601040 != 0<8> : bool)
  Class: Eq_42
  DataType: bool
  OrigDataType: bool
T_43: (in deregister_tm_clones : ptr64)
  Class: Eq_43
  DataType: (ptr64 Eq_43)
  OrigDataType: (ptr64 (fn T_45 ()))
T_44: (in signature of deregister_tm_clones : void)
  Class: Eq_43
  DataType: (ptr64 Eq_43)
  OrigDataType: 
T_45: (in deregister_tm_clones() : void)
  Class: Eq_45
  DataType: void
  OrigDataType: void
T_46: (in 1<8> : byte)
  Class: Eq_40
  DataType: byte
  OrigDataType: byte
T_47: (in 0000000000601040 : ptr64)
  Class: Eq_47
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_48 t0000)))
T_48: (in Mem17[0x0000000000601040<p64>:byte] : byte)
  Class: Eq_40
  DataType: byte
  OrigDataType: byte
T_49: (in register_tm_clones : ptr64)
  Class: Eq_49
  DataType: (ptr64 Eq_49)
  OrigDataType: (ptr64 (fn T_51 ()))
T_50: (in signature of register_tm_clones : void)
  Class: Eq_49
  DataType: (ptr64 Eq_49)
  OrigDataType: 
T_51: (in register_tm_clones() : void)
  Class: Eq_51
  DataType: void
  OrigDataType: void
T_52: (in esi : word32)
  Class: Eq_52
  DataType: word32
  OrigDataType: word32
T_53: (in edi : word32)
  Class: Eq_53
  DataType: word32
  OrigDataType: word32
T_54: (in calloc : ptr64)
  Class: Eq_54
  DataType: ptr64
  OrigDataType: ptr64
T_55: (in signature of calloc : void)
  Class: Eq_54
  DataType: ptr64
  OrigDataType: 
T_56: (in num : size_t)
  Class: Eq_56
  DataType: int64
  OrigDataType: 
T_57: (in size : size_t)
  Class: Eq_56
  DataType: int64
  OrigDataType: 
T_58: (in CONVERT(edi, word32, int64) : int64)
  Class: Eq_56
  DataType: int64
  OrigDataType: int64
T_59: (in CONVERT(esi, word32, int64) : int64)
  Class: Eq_56
  DataType: int64
  OrigDataType: int64
T_60: (in calloc((int64) edi, (int64) esi) : (ptr64 void))
  Class: Eq_60
  DataType: (ptr64 void)
  OrigDataType: (ptr64 void)
T_61: (in sil : byte)
  Class: Eq_61
  DataType: byte
  OrigDataType: byte
T_62: (in rdi : (ptr64 byte))
  Class: Eq_62
  DataType: (ptr64 byte)
  OrigDataType: (ptr64 (struct (0 T_65 t0000)))
T_63: (in 0<64> : word64)
  Class: Eq_63
  DataType: word64
  OrigDataType: word64
T_64: (in rdi + 0<64> : word64)
  Class: Eq_64
  DataType: word64
  OrigDataType: word64
T_65: (in Mem17[rdi + 0<64>:byte] : byte)
  Class: Eq_61
  DataType: byte
  OrigDataType: byte
T_66: (in esi : int32)
  Class: Eq_66
  DataType: int32
  OrigDataType: int32
T_67: (in edi : int32)
  Class: Eq_67
  DataType: int32
  OrigDataType: int32
T_68: (in rdi : word64)
  Class: Eq_68
  DataType: word64
  OrigDataType: word64
T_69: (in SLICE(rdi, word32, 0) : word32)
  Class: Eq_67
  DataType: int32
  OrigDataType: word32
T_70: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_70
  DataType: uint64
  OrigDataType: uint64
T_71: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_66
  DataType: int32
  OrigDataType: int32
T_72: (in (word32) (uint64) edi >= esi : bool)
  Class: Eq_72
  DataType: bool
  OrigDataType: bool
T_73: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_73
  DataType: uint64
  OrigDataType: uint64
T_74: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_74
  DataType: ui32
  OrigDataType: ui32
T_75: (in 1<32> : word32)
  Class: Eq_75
  DataType: word32
  OrigDataType: word32
T_76: (in (word32) (uint64) edi << 1<32> : word32)
  Class: Eq_76
  DataType: ui32
  OrigDataType: ui32
T_77: (in CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0) << 1<32>, word32, uint64) : uint64)
  Class: Eq_77
  DataType: uint64
  OrigDataType: uint64
T_78: (in SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0) << 1<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_78
  DataType: int32
  OrigDataType: int32
T_79: (in CONVERT(esi, word32, uint64) : uint64)
  Class: Eq_79
  DataType: uint64
  OrigDataType: uint64
T_80: (in SLICE(CONVERT(esi, word32, uint64), word32, 0) : word32)
  Class: Eq_80
  DataType: ui32
  OrigDataType: ui32
T_81: (in 1<32> : word32)
  Class: Eq_81
  DataType: word32
  OrigDataType: word32
T_82: (in (word32) (uint64) esi << 1<32> : word32)
  Class: Eq_82
  DataType: ui32
  OrigDataType: ui32
T_83: (in CONVERT(SLICE(CONVERT(esi, word32, uint64), word32, 0) << 1<32>, word32, uint64) : uint64)
  Class: Eq_83
  DataType: uint64
  OrigDataType: uint64
T_84: (in SLICE(CONVERT(SLICE(CONVERT(esi, word32, uint64), word32, 0) << 1<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_78
  DataType: int32
  OrigDataType: int32
T_85: (in (word32) (uint64) ((word32) (uint64) edi << 1<32>) >= (word32) ((uint64) ((word32) ((uint64) esi) << 1<32>)) : bool)
  Class: Eq_85
  DataType: bool
  OrigDataType: bool
T_86: (in 3<32> : word32)
  Class: Eq_86
  DataType: int32
  OrigDataType: int32
T_87: (in edi *s 3<32> : int32)
  Class: Eq_87
  DataType: int32
  OrigDataType: int32
T_88: (in CONVERT(edi *s 3<32>, int32, uint64) : uint64)
  Class: Eq_88
  DataType: uint64
  OrigDataType: uint64
T_89: (in SLICE(CONVERT(edi *s 3<32>, int32, uint64), word32, 0) : word32)
  Class: Eq_89
  DataType: int32
  OrigDataType: int32
T_90: (in 3<32> : word32)
  Class: Eq_90
  DataType: int32
  OrigDataType: int32
T_91: (in esi *s 3<32> : int32)
  Class: Eq_91
  DataType: int32
  OrigDataType: int32
T_92: (in CONVERT(esi *s 3<32>, int32, uint64) : uint64)
  Class: Eq_92
  DataType: uint64
  OrigDataType: uint64
T_93: (in SLICE(CONVERT(esi *s 3<32>, int32, uint64), word32, 0) : word32)
  Class: Eq_89
  DataType: int32
  OrigDataType: int32
T_94: (in (word32) (uint64) (edi *s 3<32>) >= (word32) ((uint64) (esi *s 3<32>)) : bool)
  Class: Eq_94
  DataType: bool
  OrigDataType: bool
T_95: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_95
  DataType: uint64
  OrigDataType: uint64
T_96: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_96
  DataType: ui32
  OrigDataType: ui32
T_97: (in 2<32> : word32)
  Class: Eq_97
  DataType: word32
  OrigDataType: word32
T_98: (in (word32) (uint64) edi << 2<32> : word32)
  Class: Eq_98
  DataType: ui32
  OrigDataType: ui32
T_99: (in CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0) << 2<32>, word32, uint64) : uint64)
  Class: Eq_99
  DataType: uint64
  OrigDataType: uint64
T_100: (in SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0) << 2<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_100
  DataType: int32
  OrigDataType: int32
T_101: (in CONVERT(esi, word32, uint64) : uint64)
  Class: Eq_101
  DataType: uint64
  OrigDataType: uint64
T_102: (in SLICE(CONVERT(esi, word32, uint64), word32, 0) : word32)
  Class: Eq_102
  DataType: ui32
  OrigDataType: ui32
T_103: (in 2<32> : word32)
  Class: Eq_103
  DataType: word32
  OrigDataType: word32
T_104: (in (word32) (uint64) esi << 2<32> : word32)
  Class: Eq_104
  DataType: ui32
  OrigDataType: ui32
T_105: (in CONVERT(SLICE(CONVERT(esi, word32, uint64), word32, 0) << 2<32>, word32, uint64) : uint64)
  Class: Eq_105
  DataType: uint64
  OrigDataType: uint64
T_106: (in SLICE(CONVERT(SLICE(CONVERT(esi, word32, uint64), word32, 0) << 2<32>, word32, uint64), word32, 0) : word32)
  Class: Eq_100
  DataType: int32
  OrigDataType: int32
T_107: (in (word32) (uint64) ((word32) (uint64) edi << 2<32>) >= (word32) ((uint64) ((word32) ((uint64) esi) << 2<32>)) : bool)
  Class: Eq_107
  DataType: bool
  OrigDataType: bool
T_108: (in rax_77 : uint64)
  Class: Eq_108
  DataType: uint64
  OrigDataType: uint64
T_109: (in CONVERT(esi, word32, uint64) : uint64)
  Class: Eq_109
  DataType: uint64
  OrigDataType: uint64
T_110: (in SLICE(CONVERT(esi, word32, uint64), word32, 0) : word32)
  Class: Eq_110
  DataType: word32
  OrigDataType: word32
T_111: (in CONVERT(SLICE(CONVERT(esi, word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_108
  DataType: uint64
  OrigDataType: uint64
T_112: (in eax_84 : int32)
  Class: Eq_112
  DataType: int32
  OrigDataType: int32
T_113: (in SLICE(rax_77, word32, 0) : word32)
  Class: Eq_113
  DataType: word32
  OrigDataType: word32
T_114: (in CONVERT(SLICE(rax_77, word32, 0), word32, int64) : int64)
  Class: Eq_114
  DataType: int64
  OrigDataType: int64
T_115: (in 2<32> : word32)
  Class: Eq_115
  DataType: int32
  OrigDataType: int32
T_116: (in (int64) (word32) rax_77 / 2<32> : word32)
  Class: Eq_116
  DataType: int32
  OrigDataType: int32
T_117: (in CONVERT(CONVERT(SLICE(rax_77, word32, 0), word32, int64) / 2<32>, word32, int32) : int32)
  Class: Eq_112
  DataType: int32
  OrigDataType: int32
T_118: (in rax_105 : (ptr64 void))
  Class: Eq_118
  DataType: (ptr64 void)
  OrigDataType: (ptr64 void)
T_119: (in SLICE(rax_77, word32, 32) : word32)
  Class: Eq_119
  DataType: word32
  OrigDataType: word32
T_120: (in SEQ(SLICE(rax_77, word32, 32), eax_84) : word64)
  Class: Eq_118
  DataType: (ptr64 void)
  OrigDataType: word64
T_121: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_121
  DataType: uint64
  OrigDataType: uint64
T_122: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_122
  DataType: word32
  OrigDataType: word32
T_123: (in CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64) : uint64)
  Class: Eq_123
  DataType: uint64
  OrigDataType: uint64
T_124: (in SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64), word32, 0) : word32)
  Class: Eq_124
  DataType: word32
  OrigDataType: word32
T_125: (in CONVERT(SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, int64) : int64)
  Class: Eq_125
  DataType: int64
  OrigDataType: int64
T_126: (in 2<32> : word32)
  Class: Eq_126
  DataType: int32
  OrigDataType: int32
T_127: (in (int64) (word32) (uint64) (word32) (uint64) edi / 2<32> : word32)
  Class: Eq_127
  DataType: int32
  OrigDataType: int32
T_128: (in CONVERT(CONVERT(SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, int64) / 2<32>, word32, int32) : int32)
  Class: Eq_128
  DataType: int32
  OrigDataType: int32
T_129: (in CONVERT(CONVERT(CONVERT(SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, int64) / 2<32>, word32, int32), int32, uint64) : uint64)
  Class: Eq_129
  DataType: uint64
  OrigDataType: uint64
T_130: (in SLICE(CONVERT(CONVERT(CONVERT(SLICE(CONVERT(SLICE(CONVERT(edi, word32, uint64), word32, 0), word32, uint64), word32, 0), word32, int64) / 2<32>, word32, int32), int32, uint64), word32, 0) : word32)
  Class: Eq_112
  DataType: int32
  OrigDataType: int32
T_131: (in (word32) (uint64) (int32) ((int64) (word32) (uint64) (word32) (uint64) edi / 2<32>) >= eax_84 : bool)
  Class: Eq_131
  DataType: bool
  OrigDataType: bool
T_132: (in my1 : ptr64)
  Class: Eq_132
  DataType: (ptr64 Eq_132)
  OrigDataType: (ptr64 (fn T_138 (T_135, T_137)))
T_133: (in signature of my1 : void)
  Class: Eq_132
  DataType: (ptr64 Eq_132)
  OrigDataType: 
T_134: (in CONVERT(esi, word32, uint64) : uint64)
  Class: Eq_134
  DataType: uint64
  OrigDataType: uint64
T_135: (in SLICE(CONVERT(esi, word32, uint64), word32, 0) : word32)
  Class: Eq_52
  DataType: word32
  OrigDataType: word32
T_136: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_136
  DataType: uint64
  OrigDataType: uint64
T_137: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_53
  DataType: word32
  OrigDataType: word32
T_138: (in my1((word32) (uint64) esi, (word32) (uint64) edi) : void)
  Class: Eq_138
  DataType: void
  OrigDataType: void
T_139: (in free : ptr64)
  Class: Eq_139
  DataType: (ptr64 Eq_139)
  OrigDataType: (ptr64 (fn T_142 (T_118)))
T_140: (in signature of free : void)
  Class: Eq_139
  DataType: (ptr64 Eq_139)
  OrigDataType: 
T_141: (in p : (ptr64 void))
  Class: Eq_118
  DataType: (ptr64 void)
  OrigDataType: 
T_142: (in free(rax_105) : void)
  Class: Eq_142
  DataType: void
  OrigDataType: void
T_143: (in __llvm_retpoline_r11 : ptr64)
  Class: Eq_143
  DataType: (ptr64 Eq_143)
  OrigDataType: (ptr64 (fn T_145 ()))
T_144: (in signature of __llvm_retpoline_r11 : void)
  Class: Eq_143
  DataType: (ptr64 Eq_143)
  OrigDataType: 
T_145: (in __llvm_retpoline_r11() : void)
  Class: Eq_145
  DataType: void
  OrigDataType: void
T_146: (in fn0000000000400700 : ptr64)
  Class: Eq_146
  DataType: (ptr64 Eq_146)
  OrigDataType: (ptr64 (fn T_148 ()))
T_147: (in signature of fn0000000000400700 : void)
  Class: Eq_146
  DataType: (ptr64 Eq_146)
  OrigDataType: 
T_148: (in fn0000000000400700() : void)
  Class: Eq_148
  DataType: void
  OrigDataType: void
T_149: (in __pause : ptr64)
  Class: Eq_149
  DataType: (ptr64 Eq_149)
  OrigDataType: (ptr64 (fn T_151 ()))
T_150: (in signature of __pause : void)
  Class: Eq_149
  DataType: (ptr64 Eq_149)
  OrigDataType: 
T_151: (in __pause() : void)
  Class: Eq_151
  DataType: void
  OrigDataType: void
T_152: (in rdx : word64)
  Class: Eq_152
  DataType: word64
  OrigDataType: word64
T_153: (in rsi : word64)
  Class: Eq_153
  DataType: word64
  OrigDataType: word64
T_154: (in edi : word32)
  Class: Eq_154
  DataType: word32
  OrigDataType: word32
T_155: (in rdi : word64)
  Class: Eq_155
  DataType: word64
  OrigDataType: word64
T_156: (in SLICE(rdi, word32, 0) : word32)
  Class: Eq_154
  DataType: word32
  OrigDataType: word32
T_157: (in _init : ptr64)
  Class: Eq_157
  DataType: (ptr64 Eq_157)
  OrigDataType: (ptr64 (fn T_159 ()))
T_158: (in signature of _init : void)
  Class: Eq_157
  DataType: (ptr64 Eq_157)
  OrigDataType: 
T_159: (in _init() : void)
  Class: Eq_159
  DataType: void
  OrigDataType: void
T_160: (in r15d_87 : word32)
  Class: Eq_160
  DataType: word32
  OrigDataType: word32
T_161: (in CONVERT(edi, word32, uint64) : uint64)
  Class: Eq_161
  DataType: uint64
  OrigDataType: uint64
T_162: (in SLICE(CONVERT(edi, word32, uint64), word32, 0) : word32)
  Class: Eq_160
  DataType: word32
  OrigDataType: word32
T_163: (in rbp_31 : int64)
  Class: Eq_163
  DataType: int64
  OrigDataType: int64
T_164: (in 0000000000600E18 : ptr64)
  Class: Eq_164
  DataType: int64
  OrigDataType: (union (int64 u0) (ptr64 u1))
T_165: (in 0000000000600E10 : ptr64)
  Class: Eq_165
  DataType: int64
  OrigDataType: (union (int64 u1) (ptr64 u0))
T_166: (in 0x600E18<u64> - 0x600E10<u64> : word64)
  Class: Eq_163
  DataType: int64
  OrigDataType: int64
T_167: (in 3<64> : word64)
  Class: Eq_167
  DataType: word64
  OrigDataType: word64
T_168: (in rbp_31 >> 3<64> : word64)
  Class: Eq_168
  DataType: int64
  OrigDataType: int64
T_169: (in 0<64> : word64)
  Class: Eq_168
  DataType: int64
  OrigDataType: word64
T_170: (in rbp_31 >> 3<64> == 0<64> : bool)
  Class: Eq_170
  DataType: bool
  OrigDataType: bool
T_171: (in rbx_44 : Eq_171)
  Class: Eq_171
  DataType: Eq_171
  OrigDataType: word64
T_172: (in 0<u64> : uint64)
  Class: Eq_171
  DataType: uint64
  OrigDataType: uint64
T_173: (in 0000000000600E10 : ptr64)
  Class: Eq_173
  DataType: (ptr64 (arr (ptr64 code)))
  OrigDataType: (ptr64 (struct (0 (arr T_181) a0000)))
T_174: (in 8<64> : word64)
  Class: Eq_174
  DataType: ui64
  OrigDataType: ui64
T_175: (in rbx_44 * 8<64> : word64)
  Class: Eq_175
  DataType: ui64
  OrigDataType: ui64
T_176: (in 0x0000000000600E10<p64>[rbx_44 * 8<64>] : word64)
  Class: Eq_176
  DataType: (ptr64 code)
  OrigDataType: (ptr64 code)
T_177: (in 1<64> : word64)
  Class: Eq_177
  DataType: word64
  OrigDataType: word64
T_178: (in rbx_44 + 1<64> : word64)
  Class: Eq_171
  DataType: Eq_171
  OrigDataType: uint64
T_179: (in rbp_31 >> 3<64> : word64)
  Class: Eq_171
  DataType: Eq_171
  OrigDataType: int64
T_180: (in rbp_31 >> 3<64> != rbx_44 : bool)
  Class: Eq_180
  DataType: bool
  OrigDataType: bool
T_181:
  Class: Eq_181
  DataType: (ptr64 code)
  OrigDataType: (struct 0008 (0 T_176 t0000))
*/
typedef struct Globals {
	Eq_18 t400660;	// 400660
	Eq_21 t400710;	// 400710
	Eq_22 t400780;	// 400780
	<anonymous> * a600E10[];	// 600E10
	byte b601040;	// 601040
} Eq_1;

typedef void (Eq_7)();

typedef union Eq_8 {
	int32 u0;
	word64 u1;
} Eq_8;

typedef void (Eq_9)(ptr64);

typedef int32 (Eq_16)( *, Eq_8, char * *,  *,  *,  *, void);

typedef int32 (Eq_18)(int32 rdi, char * * rsi, char * * rdx);

typedef void (Eq_21)();

typedef void (Eq_22)();

typedef void (Eq_30)();

typedef void (Eq_43)();

typedef void (Eq_49)();

typedef void (Eq_132)(word32, word32);

typedef void (Eq_139)(void);

typedef void (Eq_143)();

typedef void (Eq_146)();

typedef void (Eq_149)();

typedef void (Eq_157)();

typedef union Eq_164 {
	int64 u0;
	ptr64 u1;
} Eq_164;

typedef union Eq_165 {
	int64 u0;
	ptr64 u1;
} Eq_165;

typedef union Eq_171 {
	int64 u0;
	uint64 u1;
} Eq_171;

