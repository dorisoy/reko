// a.h
// Generated by decompiling a.out
// using Reko decompiler version 0.11.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (8000270C (ptr32 code) ptr8000270C) (80002714 (arr (ptr32 code)) a80002714) (8000271C word32 dw8000271C) (80002724 byte b80002724) (80002726 uint32 dtor_idx.3228) (FFFFFFFF code tFFFFFFFF))
	globals_t (in globals : (ptr32 (struct "Globals")))
Eq_6: (fn word32 (ptr32))
	T_6 (in fn00000000 @ 800000A6 : ptr32)
Eq_22: (fn word32 (ptr32, int32))
	T_22 (in fn00000000 @ 800000DC : ptr32)
Eq_43: (fn void ())
	T_43 (in deregister_tm_clones @ 8000012C : ptr32)
	T_44 (in signature of deregister_tm_clones @ 80000080 : void)
Eq_67: (fn word32 (ptr32))
	T_67 (in fn00000000 @ 80000140 : ptr32)
Eq_78: (fn void (ptr32, ptr32))
	T_78 (in fn00000000 @ 8000017A : ptr32)
Eq_86: (fn void (ptr32))
	T_86 (in fn00000000 @ 8000019A : ptr32)
Eq_90: (fn void ())
	T_90 (in register_tm_clones @ 8000018A : ptr32)
	T_91 (in signature of register_tm_clones @ 800000AE : void)
	T_93 (in register_tm_clones @ 800001A0 : ptr32)
Eq_119: (fn void (real64, int32))
	T_119 (in pow_int @ 800003EC : ptr32)
	T_120 (in signature of pow_int @ 80000372 : void)
	T_130 (in pow_int @ 80000444 : ptr32)
Eq_122: (fn void (int32))
	T_122 (in factorial @ 800003FC : ptr32)
	T_123 (in signature of factorial @ 8000033C : void)
	T_132 (in factorial @ 80000454 : ptr32)
Eq_140: (fn void (real64))
	T_140 (in sine_taylor @ 800004AA : ptr32)
	T_141 (in signature of sine_taylor @ 800001AC : void)
Eq_144: (fn void (real64, real64, Eq_148))
	T_144 (in _sin @ 800004CE : ptr32)
	T_145 (in signature of _sin @ 800004DE : void)
Eq_148: (union "Eq_148" ((ptr32 word32) u0) ((ref int32) u1))
	T_148 (in tArg14 @ 800004CE : Eq_148)
	T_152 (in fp - 8<32> @ 800004CE : word32)
Eq_164: (ref int32)
	T_164 (in tArg14 + 0<32> @ 80000608 : word32)
Eq_169: (union "Eq_169" ((ptr32 word32) u0) ((ref int32) u1))
	T_169 (in tArg14 + 0<32> @ 80000608 : word32)
Eq_214: (struct "Eq_214" (FFFFFFFC (ptr32 code) ptrFFFFFFFC))
	T_214 (in a2_23 @ 8000063C : (ptr32 Eq_214))
// Type Variables ////////////
globals_t: (in globals : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in true @ 80000094 : bool)
  Class: Eq_2
  DataType: bool
  OrigDataType: bool
T_3: (in 00000000 @ 8000009E : ptr32)
  Class: Eq_3
  DataType: ptr32
  OrigDataType: ptr32
T_4: (in 0<32> @ 8000009E : word32)
  Class: Eq_3
  DataType: ptr32
  OrigDataType: word32
T_5: (in 0<u32> == 0<32> @ 8000009E : bool)
  Class: Eq_5
  DataType: bool
  OrigDataType: bool
T_6: (in fn00000000 @ 800000A6 : ptr32)
  Class: Eq_6
  DataType: (ptr32 Eq_6)
  OrigDataType: (ptr32 (fn T_9 (T_8)))
T_7: (in signature of fn00000000 : void)
  Class: Eq_7
  DataType: Eq_7
  OrigDataType: 
T_8: (in 80002724 @ 800000A6 : ptr32)
  Class: Eq_8
  DataType: ptr32
  OrigDataType: ptr32
T_9: (in fn00000000(0x80002724<u32>) @ 800000A6 : word32)
  Class: Eq_9
  DataType: word32
  OrigDataType: word32
T_10: (in d0_12 @ 800000C0 : int32)
  Class: Eq_10
  DataType: int32
  OrigDataType: int32
T_11: (in 0<32> @ 800000C0 : word32)
  Class: Eq_10
  DataType: int32
  OrigDataType: word32
T_12: (in false @ 800000C2 : bool)
  Class: Eq_12
  DataType: bool
  OrigDataType: bool
T_13: (in 1<32> @ 800000C4 : word32)
  Class: Eq_10
  DataType: int32
  OrigDataType: word32
T_14: (in d0_18 @ 800000C6 : int32)
  Class: Eq_14
  DataType: int32
  OrigDataType: int32
T_15: (in 1<32> @ 800000C6 : word32)
  Class: Eq_15
  DataType: word32
  OrigDataType: word32
T_16: (in d0_12 >> 1<32> @ 800000C6 : word32)
  Class: Eq_14
  DataType: int32
  OrigDataType: int32
T_17: (in 0<32> @ 800000C8 : word32)
  Class: Eq_14
  DataType: int32
  OrigDataType: word32
T_18: (in d0_18 == 0<32> @ 800000C8 : bool)
  Class: Eq_18
  DataType: bool
  OrigDataType: bool
T_19: (in 00000000 @ 800000D2 : ptr32)
  Class: Eq_19
  DataType: ptr32
  OrigDataType: ptr32
T_20: (in 0<32> @ 800000D2 : word32)
  Class: Eq_19
  DataType: ptr32
  OrigDataType: word32
T_21: (in 0<u32> == 0<32> @ 800000D2 : bool)
  Class: Eq_21
  DataType: bool
  OrigDataType: bool
T_22: (in fn00000000 @ 800000DC : ptr32)
  Class: Eq_22
  DataType: (ptr32 Eq_22)
  OrigDataType: (ptr32 (fn T_25 (T_24, T_14)))
T_23: (in signature of fn00000000 : void)
  Class: Eq_23
  DataType: Eq_23
  OrigDataType: 
T_24: (in 80002724 @ 800000DC : ptr32)
  Class: Eq_24
  DataType: ptr32
  OrigDataType: ptr32
T_25: (in fn00000000(0x80002724<u32>, d0_18) @ 800000DC : word32)
  Class: Eq_25
  DataType: word32
  OrigDataType: word32
T_26: (in fp @ 800000E4 : ptr32)
  Class: Eq_26
  DataType: ptr32
  OrigDataType: ptr32
T_27: (in a6_35 @ 800000E4 : ptr32)
  Class: Eq_27
  DataType: ptr32
  OrigDataType: ptr32
T_28: (in 4<32> @ 800000E4 : word32)
  Class: Eq_28
  DataType: ui32
  OrigDataType: ui32
T_29: (in fp - 4<32> @ 800000E4 : word32)
  Class: Eq_27
  DataType: ptr32
  OrigDataType: ptr32
T_30: (in 80002724 @ 800000F2 : ptr32)
  Class: Eq_30
  DataType: (ptr32 byte)
  OrigDataType: (ptr32 (struct (0 T_31 t0000)))
T_31: (in Mem13[0x80002724<p32>:byte] @ 800000F2 : byte)
  Class: Eq_31
  DataType: byte
  OrigDataType: byte
T_32: (in 0<8> @ 800000F2 : byte)
  Class: Eq_31
  DataType: byte
  OrigDataType: byte
T_33: (in g_b80002724 != 0<8> @ 800000F2 : bool)
  Class: Eq_33
  DataType: bool
  OrigDataType: bool
T_34: (in d0_19 @ 800000FA : uint32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: up32
T_35: (in 80002726 @ 800000FA : ptr32)
  Class: Eq_35
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_36 t0000)))
T_36: (in Mem13[0x80002726<p32>:word32] @ 800000FA : word32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: word32
T_37: (in a2_18 @ 800000F4 : (arr (ptr32 code)))
  Class: Eq_37
  DataType: (ptr32 (arr (ptr32 code)))
  OrigDataType: (ptr32 (struct (0 (arr T_223) a0000)))
T_38: (in 80002714 @ 800000F4 : ptr32)
  Class: Eq_37
  DataType: (ptr32 (arr (ptr32 code)))
  OrigDataType: ptr32
T_39: (in d2_23 @ 8000010E : up32)
  Class: Eq_39
  DataType: up32
  OrigDataType: up32
T_40: (in 0<32> @ 8000010E : word32)
  Class: Eq_39
  DataType: up32
  OrigDataType: word32
T_41: (in 0<32> @ 80000112 : word32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: up32
T_42: (in d0_19 >= 0<32> @ 80000112 : bool)
  Class: Eq_42
  DataType: bool
  OrigDataType: bool
T_43: (in deregister_tm_clones @ 8000012C : ptr32)
  Class: Eq_43
  DataType: (ptr32 Eq_43)
  OrigDataType: (ptr32 (fn T_45 ()))
T_44: (in signature of deregister_tm_clones @ 80000080 : void)
  Class: Eq_43
  DataType: (ptr32 Eq_43)
  OrigDataType: 
T_45: (in deregister_tm_clones() @ 8000012C : void)
  Class: Eq_45
  DataType: void
  OrigDataType: void
T_46: (in 00000000 @ 80000138 : ptr32)
  Class: Eq_46
  DataType: ptr32
  OrigDataType: ptr32
T_47: (in 0<32> @ 80000138 : word32)
  Class: Eq_46
  DataType: ptr32
  OrigDataType: word32
T_48: (in 0<u32> == 0<32> @ 80000138 : bool)
  Class: Eq_48
  DataType: bool
  OrigDataType: bool
T_49: (in d0_29 @ 80000114 : uint32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: uint32
T_50: (in 1<32> @ 80000114 : word32)
  Class: Eq_50
  DataType: up32
  OrigDataType: up32
T_51: (in d0_19 + 1<32> @ 80000114 : word32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: up32
T_52: (in 80002726 @ 80000116 : ptr32)
  Class: Eq_52
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_53 t0000)))
T_53: (in Mem31[0x80002726<p32>:word32] @ 80000116 : word32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: word32
T_54: (in a0_43 @ 80000120 : word32)
  Class: Eq_54
  DataType: word32
  OrigDataType: word32
T_55: (in d1_91 @ 80000120 : word32)
  Class: Eq_55
  DataType: word32
  OrigDataType: word32
T_56: (in 4<i32> @ 80000120 : int32)
  Class: Eq_56
  DataType: int32
  OrigDataType: int32
T_57: (in d0_29 * 4<i32> @ 80000120 : word32)
  Class: Eq_57
  DataType: ui32
  OrigDataType: ui32
T_58: (in a2_18[d0_29 * 4<i32>] @ 80000120 : word32)
  Class: Eq_58
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_59: (in 80002726 @ 80000122 : ptr32)
  Class: Eq_59
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_60 t0000)))
T_60: (in Mem31[0x80002726<p32>:word32] @ 80000122 : word32)
  Class: Eq_34
  DataType: uint32
  OrigDataType: word32
T_61: (in d2_23 - d0_19 @ 8000012A : word32)
  Class: Eq_61
  DataType: up32
  OrigDataType: up32
T_62: (in 0<32> @ 8000012A : word32)
  Class: Eq_61
  DataType: up32
  OrigDataType: up32
T_63: (in d2_23 - d0_19 > 0<32> @ 8000012A : bool)
  Class: Eq_63
  DataType: bool
  OrigDataType: bool
T_64: (in 1<8> @ 80000144 : byte)
  Class: Eq_31
  DataType: byte
  OrigDataType: byte
T_65: (in 80002724 @ 80000144 : ptr32)
  Class: Eq_65
  DataType: (ptr32 byte)
  OrigDataType: (ptr32 (struct (0 T_66 t0000)))
T_66: (in Mem77[0x80002724<p32>:byte] @ 80000144 : byte)
  Class: Eq_31
  DataType: byte
  OrigDataType: byte
T_67: (in fn00000000 @ 80000140 : ptr32)
  Class: Eq_67
  DataType: (ptr32 Eq_67)
  OrigDataType: (ptr32 (fn T_70 (T_69)))
T_68: (in signature of fn00000000 : void)
  Class: Eq_68
  DataType: Eq_68
  OrigDataType: 
T_69: (in 8000065C @ 80000140 : ptr32)
  Class: Eq_69
  DataType: ptr32
  OrigDataType: ptr32
T_70: (in fn00000000(0x8000065C<u32>) @ 80000140 : word32)
  Class: Eq_70
  DataType: word32
  OrigDataType: word32
T_71: (in 00000000 @ 8000016C : ptr32)
  Class: Eq_71
  DataType: ptr32
  OrigDataType: ptr32
T_72: (in 0<32> @ 8000016C : word32)
  Class: Eq_71
  DataType: ptr32
  OrigDataType: word32
T_73: (in 0<u32> == 0<32> @ 8000016C : bool)
  Class: Eq_73
  DataType: bool
  OrigDataType: bool
T_74: (in 8000271C @ 80000186 : ptr32)
  Class: Eq_74
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_75 t0000)))
T_75: (in Mem25[0x8000271C<p32>:word32] @ 80000186 : word32)
  Class: Eq_75
  DataType: word32
  OrigDataType: word32
T_76: (in 0<32> @ 80000186 : word32)
  Class: Eq_75
  DataType: word32
  OrigDataType: word32
T_77: (in g_dw8000271C != 0<32> @ 80000186 : bool)
  Class: Eq_77
  DataType: bool
  OrigDataType: bool
T_78: (in fn00000000 @ 8000017A : ptr32)
  Class: Eq_78
  DataType: (ptr32 Eq_78)
  OrigDataType: (ptr32 (fn T_82 (T_80, T_81)))
T_79: (in signature of fn00000000 : void)
  Class: Eq_79
  DataType: Eq_79
  OrigDataType: 
T_80: (in 8000065C @ 8000017A : ptr32)
  Class: Eq_80
  DataType: ptr32
  OrigDataType: ptr32
T_81: (in 8000272A @ 8000017A : ptr32)
  Class: Eq_81
  DataType: ptr32
  OrigDataType: ptr32
T_82: (in fn00000000(0x8000065C<u32>, 0x8000272A<u32>) @ 8000017A : void)
  Class: Eq_82
  DataType: void
  OrigDataType: void
T_83: (in 00000000 @ 80000196 : ptr32)
  Class: Eq_83
  DataType: ptr32
  OrigDataType: ptr32
T_84: (in 0<32> @ 80000196 : word32)
  Class: Eq_83
  DataType: ptr32
  OrigDataType: word32
T_85: (in 0<u32> == 0<32> @ 80000196 : bool)
  Class: Eq_85
  DataType: bool
  OrigDataType: bool
T_86: (in fn00000000 @ 8000019A : ptr32)
  Class: Eq_86
  DataType: (ptr32 Eq_86)
  OrigDataType: (ptr32 (fn T_89 (T_88)))
T_87: (in signature of fn00000000 : void)
  Class: Eq_87
  DataType: Eq_87
  OrigDataType: 
T_88: (in 8000271C @ 8000019A : ptr32)
  Class: Eq_88
  DataType: ptr32
  OrigDataType: ptr32
T_89: (in fn00000000(0x8000271C<u32>) @ 8000019A : void)
  Class: Eq_89
  DataType: void
  OrigDataType: void
T_90: (in register_tm_clones @ 8000018A : ptr32)
  Class: Eq_90
  DataType: (ptr32 Eq_90)
  OrigDataType: (ptr32 (fn T_92 ()))
T_91: (in signature of register_tm_clones @ 800000AE : void)
  Class: Eq_90
  DataType: (ptr32 Eq_90)
  OrigDataType: 
T_92: (in register_tm_clones() @ 8000018A : void)
  Class: Eq_92
  DataType: void
  OrigDataType: void
T_93: (in register_tm_clones @ 800001A0 : ptr32)
  Class: Eq_90
  DataType: (ptr32 Eq_90)
  OrigDataType: (ptr32 (fn T_94 ()))
T_94: (in register_tm_clones() @ 800001A0 : void)
  Class: Eq_92
  DataType: void
  OrigDataType: void
T_95: (in rArg04 @ 800001AA : real64)
  Class: Eq_95
  DataType: real64
  OrigDataType: real64
T_96: (in dwArg04 @ 8000033A : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_97: (in dwLoc08_32 @ 80000348 : int32)
  Class: Eq_97
  DataType: int32
  OrigDataType: int32
T_98: (in 2<i32> @ 80000348 : int32)
  Class: Eq_97
  DataType: int32
  OrigDataType: int32
T_99: (in 1<32> @ 80000364 : word32)
  Class: Eq_99
  DataType: word32
  OrigDataType: word32
T_100: (in dwLoc08_32 + 1<32> @ 80000364 : word32)
  Class: Eq_97
  DataType: int32
  OrigDataType: int32
T_101: (in dwLoc08_32 - dwArg04 @ 80000354 : word32)
  Class: Eq_101
  DataType: int32
  OrigDataType: int32
T_102: (in 0<32> @ 80000354 : word32)
  Class: Eq_101
  DataType: int32
  OrigDataType: int32
T_103: (in dwLoc08_32 - dwArg04 > 0<32> @ 80000354 : bool)
  Class: Eq_103
  DataType: bool
  OrigDataType: bool
T_104: (in rArg04 @ 80000354 : real64)
  Class: Eq_104
  DataType: real64
  OrigDataType: real64
T_105: (in dwArg0C @ 80000354 : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_106: (in dwLoc08_46 @ 80000382 : int32)
  Class: Eq_106
  DataType: int32
  OrigDataType: int32
T_107: (in 0<32> @ 80000382 : word32)
  Class: Eq_106
  DataType: int32
  OrigDataType: word32
T_108: (in 1<32> @ 800003A2 : word32)
  Class: Eq_108
  DataType: word32
  OrigDataType: word32
T_109: (in dwLoc08_46 + 1<32> @ 800003A2 : word32)
  Class: Eq_106
  DataType: int32
  OrigDataType: word32
T_110: (in dwLoc08_46 - dwArg0C @ 8000038E : word32)
  Class: Eq_110
  DataType: int32
  OrigDataType: int32
T_111: (in 0<32> @ 8000038E : word32)
  Class: Eq_110
  DataType: int32
  OrigDataType: int32
T_112: (in dwLoc08_46 - dwArg0C >= 0<32> @ 8000038E : bool)
  Class: Eq_112
  DataType: bool
  OrigDataType: bool
T_113: (in rArg04 @ 8000038E : real64)
  Class: Eq_104
  DataType: real64
  OrigDataType: real64
T_114: (in dwArg0C @ 8000038E : int32)
  Class: Eq_114
  DataType: int32
  OrigDataType: int32
T_115: (in dwLoc08_115 @ 800003D2 : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_116: (in 3<i32> @ 800003D2 : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_117: (in dwLoc08_118 @ 8000042A : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_118: (in 5<i32> @ 8000042A : int32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_119: (in pow_int @ 800003EC : ptr32)
  Class: Eq_119
  DataType: (ptr32 Eq_119)
  OrigDataType: (ptr32 (fn T_121 (T_113, T_115)))
T_120: (in signature of pow_int @ 80000372 : void)
  Class: Eq_119
  DataType: (ptr32 Eq_119)
  OrigDataType: 
T_121: (in pow_int(rArg04, dwLoc08_115) @ 800003EC : void)
  Class: Eq_121
  DataType: void
  OrigDataType: void
T_122: (in factorial @ 800003FC : ptr32)
  Class: Eq_122
  DataType: (ptr32 Eq_122)
  OrigDataType: (ptr32 (fn T_124 (T_115)))
T_123: (in signature of factorial @ 8000033C : void)
  Class: Eq_122
  DataType: (ptr32 Eq_122)
  OrigDataType: 
T_124: (in factorial(dwLoc08_115) @ 800003FC : void)
  Class: Eq_124
  DataType: void
  OrigDataType: void
T_125: (in 4<32> @ 80000422 : word32)
  Class: Eq_125
  DataType: word32
  OrigDataType: word32
T_126: (in dwLoc08_115 + 4<32> @ 80000422 : word32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_127: (in dwLoc08_115 - dwArg0C @ 800003DE : word32)
  Class: Eq_127
  DataType: int32
  OrigDataType: int32
T_128: (in 0<32> @ 800003DE : word32)
  Class: Eq_127
  DataType: int32
  OrigDataType: int32
T_129: (in dwLoc08_115 - dwArg0C > 0<32> @ 800003DE : bool)
  Class: Eq_129
  DataType: bool
  OrigDataType: bool
T_130: (in pow_int @ 80000444 : ptr32)
  Class: Eq_119
  DataType: (ptr32 Eq_119)
  OrigDataType: (ptr32 (fn T_131 (T_113, T_117)))
T_131: (in pow_int(rArg04, dwLoc08_118) @ 80000444 : void)
  Class: Eq_121
  DataType: void
  OrigDataType: void
T_132: (in factorial @ 80000454 : ptr32)
  Class: Eq_122
  DataType: (ptr32 Eq_122)
  OrigDataType: (ptr32 (fn T_133 (T_117)))
T_133: (in factorial(dwLoc08_118) @ 80000454 : void)
  Class: Eq_124
  DataType: void
  OrigDataType: void
T_134: (in 4<32> @ 8000047A : word32)
  Class: Eq_134
  DataType: word32
  OrigDataType: word32
T_135: (in dwLoc08_118 + 4<32> @ 8000047A : word32)
  Class: Eq_96
  DataType: int32
  OrigDataType: int32
T_136: (in dwLoc08_118 - dwArg0C @ 80000436 : word32)
  Class: Eq_136
  DataType: int32
  OrigDataType: int32
T_137: (in 0<32> @ 80000436 : word32)
  Class: Eq_136
  DataType: int32
  OrigDataType: int32
T_138: (in dwLoc08_118 - dwArg0C > 0<32> @ 80000436 : bool)
  Class: Eq_138
  DataType: bool
  OrigDataType: bool
T_139: (in fp @ 8000049A : ptr32)
  Class: Eq_139
  DataType: ptr32
  OrigDataType: ptr32
T_140: (in sine_taylor @ 800004AA : ptr32)
  Class: Eq_140
  DataType: (ptr32 Eq_140)
  OrigDataType: (ptr32 (fn T_143 (T_142)))
T_141: (in signature of sine_taylor @ 800001AC : void)
  Class: Eq_140
  DataType: (ptr32 Eq_140)
  OrigDataType: 
T_142: (in 3.14 @ 800004AA : real64)
  Class: Eq_95
  DataType: real64
  OrigDataType: real64
T_143: (in sine_taylor(3.14) @ 800004AA : void)
  Class: Eq_143
  DataType: void
  OrigDataType: void
T_144: (in _sin @ 800004CE : ptr32)
  Class: Eq_144
  DataType: (ptr32 Eq_144)
  OrigDataType: (ptr32 (fn T_153 (T_149, T_150, T_152)))
T_145: (in signature of _sin @ 800004DE : void)
  Class: Eq_144
  DataType: (ptr32 Eq_144)
  OrigDataType: 
T_146: (in rArg04 @ 800004CE : real64)
  Class: Eq_146
  DataType: real64
  OrigDataType: real64
T_147: (in rArg0C @ 800004CE : real64)
  Class: Eq_147
  DataType: real64
  OrigDataType: real64
T_148: (in tArg14 @ 800004CE : Eq_148)
  Class: Eq_148
  DataType: Eq_148
  OrigDataType: (union ((ptr32 (struct (0 T_165 t0000))) u1) ((ref int32) u0))
T_149: (in 3.14 @ 800004CE : real64)
  Class: Eq_146
  DataType: real64
  OrigDataType: real64
T_150: (in 0.003 @ 800004CE : real64)
  Class: Eq_147
  DataType: real64
  OrigDataType: real64
T_151: (in 8<32> @ 800004CE : word32)
  Class: Eq_151
  DataType: ui32
  OrigDataType: ui32
T_152: (in fp - 8<32> @ 800004CE : word32)
  Class: Eq_148
  DataType: Eq_148
  OrigDataType: (union (ptr32 u0) ((ref int32) u1))
T_153: (in _sin(3.14, 0.003, fp - 8<32>) @ 800004CE : void)
  Class: Eq_153
  DataType: void
  OrigDataType: void
T_154: (in rLoc0C_109 @ 800004EE : real64)
  Class: Eq_146
  DataType: real64
  OrigDataType: real64
T_155: (in v9_14 @ 800004FA : real64)
  Class: Eq_155
  DataType: real64
  OrigDataType: real64
T_156: (in CONVERT(rArg04, real64, real96) @ 800004FA : real96)
  Class: Eq_156
  DataType: real96
  OrigDataType: real96
T_157: (in (real96) rArg04 *96 rArg04 @ 800004FA : real96)
  Class: Eq_157
  DataType: real96
  OrigDataType: real96
T_158: (in CONVERT(CONVERT(rArg04, real64, real96) *96 rArg04, real96, real64) @ 800004FA : real64)
  Class: Eq_155
  DataType: real64
  OrigDataType: real64
T_159: (in dwLoc20_115 @ 80000516 : word32)
  Class: Eq_159
  DataType: word32
  OrigDataType: word32
T_160: (in 2<32> @ 80000516 : word32)
  Class: Eq_159
  DataType: word32
  OrigDataType: word32
T_161: (in rLoc14_117 @ 80000516 : real64)
  Class: Eq_161
  DataType: real64
  OrigDataType: real64
T_162: (in 0x3FF0000000000000<64> @ 80000516 : word64)
  Class: Eq_161
  DataType: real64
  OrigDataType: word64
T_163: (in 0<32> @ 80000608 : word32)
  Class: Eq_163
  DataType: word32
  OrigDataType: word32
T_164: (in tArg14 + 0<32> @ 80000608 : word32)
  Class: Eq_164
  DataType: Eq_164
  OrigDataType: (ref int32)
T_165: (in Mem94[tArg14 + 0<32>:word32] @ 80000608 : word32)
  Class: Eq_165
  DataType: word32
  OrigDataType: word32
T_166: (in 1<32> @ 80000608 : word32)
  Class: Eq_166
  DataType: word32
  OrigDataType: word32
T_167: (in Mem94[tArg14 + 0<32>:word32] + 1<32> @ 80000608 : word32)
  Class: Eq_165
  DataType: word32
  OrigDataType: word32
T_168: (in 0<32> @ 80000608 : word32)
  Class: Eq_168
  DataType: word32
  OrigDataType: word32
T_169: (in tArg14 + 0<32> @ 80000608 : word32)
  Class: Eq_169
  DataType: Eq_169
  OrigDataType: (union ((ptr32 word32) u1) ((ref int32) u0))
T_170: (in Mem101[tArg14 + 0<32>:word32] @ 80000608 : word32)
  Class: Eq_165
  DataType: Eq_148
  OrigDataType: word32
T_171: (in v18_53 @ 8000055E : word32)
  Class: Eq_171
  DataType: word32
  OrigDataType: word32
T_172: (in 0<32> @ 8000055E : word32)
  Class: Eq_172
  DataType: word32
  OrigDataType: word32
T_173: (in dwLoc20_115 + 0<32> @ 8000055E : word32)
  Class: Eq_171
  DataType: word32
  OrigDataType: word32
T_174: (in CONVERT(rLoc0C_109, real64, real96) @ 800005BE : real96)
  Class: Eq_174
  DataType: real96
  OrigDataType: real96
T_175: (in (real96) rLoc0C_109 *96 v9_14 @ 800005BE : real96)
  Class: Eq_175
  DataType: real96
  OrigDataType: real96
T_176: (in (real96) rLoc0C_109 *96 v9_14 *96 v9_14 @ 800005BE : real96)
  Class: Eq_176
  DataType: real96
  OrigDataType: real96
T_177: (in CONVERT(CONVERT(rLoc0C_109, real64, real96) *96 v9_14 *96 v9_14, real96, real64) @ 800005BE : real64)
  Class: Eq_146
  DataType: real64
  OrigDataType: real64
T_178: (in 3<32> @ 800005E0 : word32)
  Class: Eq_178
  DataType: word32
  OrigDataType: word32
T_179: (in v18_53 + 3<32> @ 800005E0 : word32)
  Class: Eq_159
  DataType: word32
  OrigDataType: word32
T_180: (in CONVERT(rLoc14_117, real64, real96) @ 800005F6 : real96)
  Class: Eq_180
  DataType: real96
  OrigDataType: real96
T_181: (in CONVERT(v18_53, word32, real96) @ 800005F6 : real96)
  Class: Eq_181
  DataType: real96
  OrigDataType: real96
T_182: (in CONVERT(CONVERT(v18_53, word32, real96), real96, real80) @ 800005F6 : real80)
  Class: Eq_182
  DataType: real80
  OrigDataType: real80
T_183: (in (real96) rLoc14_117 *96 (real80) ((real96) v18_53) @ 800005F6 : real96)
  Class: Eq_183
  DataType: real96
  OrigDataType: real96
T_184: (in 1<32> @ 800005F6 : word32)
  Class: Eq_184
  DataType: word32
  OrigDataType: word32
T_185: (in v18_53 + 1<32> @ 800005F6 : word32)
  Class: Eq_185
  DataType: word32
  OrigDataType: word32
T_186: (in CONVERT(v18_53 + 1<32>, word32, real96) @ 800005F6 : real96)
  Class: Eq_186
  DataType: real96
  OrigDataType: real96
T_187: (in CONVERT(CONVERT(v18_53 + 1<32>, word32, real96), real96, real80) @ 800005F6 : real80)
  Class: Eq_187
  DataType: real80
  OrigDataType: real80
T_188: (in (real96) rLoc14_117 *96 (real80) ((real96) v18_53) *96 (real80) ((real96) (v18_53 + 1<32>)) @ 800005F6 : real96)
  Class: Eq_188
  DataType: real96
  OrigDataType: real96
T_189: (in 2<32> @ 800005F6 : word32)
  Class: Eq_189
  DataType: word32
  OrigDataType: word32
T_190: (in v18_53 + 2<32> @ 800005F6 : word32)
  Class: Eq_190
  DataType: word32
  OrigDataType: word32
T_191: (in CONVERT(v18_53 + 2<32>, word32, real96) @ 800005F6 : real96)
  Class: Eq_191
  DataType: real96
  OrigDataType: real96
T_192: (in CONVERT(CONVERT(v18_53 + 2<32>, word32, real96), real96, real80) @ 800005F6 : real80)
  Class: Eq_192
  DataType: real80
  OrigDataType: real80
T_193: (in (real96) rLoc14_117 *96 (real80) ((real96) v18_53) *96 (real80) ((real96) (v18_53 + 1<32>)) *96 (real80) ((real96) (v18_53 + 2<32>)) @ 800005F6 : real96)
  Class: Eq_193
  DataType: real96
  OrigDataType: real96
T_194: (in v18_53 + 3<32> @ 800005F6 : word32)
  Class: Eq_194
  DataType: word32
  OrigDataType: word32
T_195: (in CONVERT(v18_53 + 3<32>, word32, real96) @ 800005F6 : real96)
  Class: Eq_195
  DataType: real96
  OrigDataType: real96
T_196: (in CONVERT(CONVERT(v18_53 + 3<32>, word32, real96), real96, real80) @ 800005F6 : real80)
  Class: Eq_196
  DataType: real80
  OrigDataType: real80
T_197: (in (real96) rLoc14_117 *96 (real80) ((real96) v18_53) *96 (real80) ((real96) (v18_53 + 1<32>)) *96 (real80) ((real96) (v18_53 + 2<32>)) *96 (real80) ((real96) (v18_53 + 3<32>)) @ 800005F6 : real96)
  Class: Eq_197
  DataType: real96
  OrigDataType: real96
T_198: (in CONVERT(CONVERT(rLoc14_117, real64, real96) *96 CONVERT(CONVERT(v18_53, word32, real96), real96, real80) *96 CONVERT(CONVERT(v18_53 + 1<32>, word32, real96), real96, real80) *96 CONVERT(CONVERT(v18_53 + 2<32>, word32, real96), real96, real80) *96 CONVERT(CONVERT(v18_53 + 3<32>, word32, real96), real96, real80), real96, real64) @ 800005F6 : real64)
  Class: Eq_161
  DataType: real64
  OrigDataType: real64
T_199: (in CONVERT(rLoc0C_109, real64, real96) @ 8000052C : real96)
  Class: Eq_199
  DataType: real96
  OrigDataType: real96
T_200: (in (real96) rLoc0C_109 /96 rLoc14_117 @ 8000052C : real96)
  Class: Eq_200
  DataType: real96
  OrigDataType: real96
T_201: (in CONVERT(CONVERT(rLoc0C_109, real64, real96) /96 rLoc14_117, real96, real64) @ 8000052C : real64)
  Class: Eq_147
  DataType: real64
  OrigDataType: real64
T_202: (in (real64) ((real96) rLoc0C_109 /96 rLoc14_117) < rArg0C @ 8000052C : bool)
  Class: Eq_202
  DataType: bool
  OrigDataType: bool
T_203: (in fp @ 80000624 : ptr32)
  Class: Eq_203
  DataType: ptr32
  OrigDataType: ptr32
T_204: (in a0_11 @ 8000062A : (ptr32 code))
  Class: Eq_204
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_205: (in 8000270C @ 8000062A : ptr32)
  Class: Eq_205
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_206 t0000)))
T_206: (in Mem10[0x8000270C<p32>:word32] @ 8000062A : word32)
  Class: Eq_204
  DataType: (ptr32 code)
  OrigDataType: word32
T_207: (in a6_18 @ 80000624 : ptr32)
  Class: Eq_207
  DataType: ptr32
  OrigDataType: ptr32
T_208: (in 4<32> @ 80000624 : word32)
  Class: Eq_208
  DataType: ui32
  OrigDataType: ui32
T_209: (in fp - 4<32> @ 80000624 : word32)
  Class: Eq_207
  DataType: ptr32
  OrigDataType: ptr32
T_210: (in a2_12 @ 80000630 : ptr32)
  Class: Eq_210
  DataType: ptr32
  OrigDataType: ptr32
T_211: (in 8000270C @ 80000630 : ptr32)
  Class: Eq_210
  DataType: ptr32
  OrigDataType: ptr32
T_212: (in -1<i32> @ 8000063A : int32)
  Class: Eq_204
  DataType: (ptr32 code)
  OrigDataType: int32
T_213: (in a0_11 == (<anonymous> *) -1<i32> @ 8000063A : bool)
  Class: Eq_213
  DataType: bool
  OrigDataType: bool
T_214: (in a2_23 @ 8000063C : (ptr32 Eq_214))
  Class: Eq_214
  DataType: (ptr32 Eq_214)
  OrigDataType: (ptr32 (struct (FFFFFFFC T_217 tFFFFFFFC)))
T_215: (in -4<i32> @ 8000063E : int32)
  Class: Eq_215
  DataType: int32
  OrigDataType: int32
T_216: (in a2_23 + -4<i32> @ 8000063E : word32)
  Class: Eq_216
  DataType: word32
  OrigDataType: word32
T_217: (in Mem10[a2_23 + -4<i32>:word32] @ 8000063E : word32)
  Class: Eq_204
  DataType: (ptr32 code)
  OrigDataType: word32
T_218: (in 4<i32> @ 8000063E : int32)
  Class: Eq_218
  DataType: int32
  OrigDataType: int32
T_219: (in a2_23 - 4<i32> @ 8000063E : word32)
  Class: Eq_210
  DataType: ptr32
  OrigDataType: ptr32
T_220: (in -1<i32> @ 80000644 : int32)
  Class: Eq_204
  DataType: (ptr32 code)
  OrigDataType: int32
T_221: (in a0_11 != (<anonymous> *) -1<i32> @ 80000644 : bool)
  Class: Eq_221
  DataType: bool
  OrigDataType: bool
T_222:
  Class: Eq_34
  DataType: uint32
  OrigDataType: word32
T_223:
  Class: Eq_223
  DataType: (ptr32 code)
  OrigDataType: (struct 0004 (0 T_58 t0000))
T_224:
  Class: Eq_224
  DataType: (arr (ptr32 code))
  OrigDataType: (arr T_223)
*/
typedef struct Globals {
	<anonymous> * ptr8000270C;	// 8000270C
	<anonymous> * a80002714[];	// 80002714
	word32 dw8000271C;	// 8000271C
	byte b80002724;	// 80002724
	uint32 dtor_idx.3228;	// 80002726
	<anonymous> tFFFFFFFF;	// FFFFFFFF
} Eq_1;

typedef word32 (Eq_6)(ptr32);

typedef word32 (Eq_22)(ptr32, int32);

typedef void (Eq_43)();

typedef word32 (Eq_67)(ptr32);

typedef void (Eq_78)(ptr32, ptr32);

typedef void (Eq_86)(ptr32);

typedef void (Eq_90)();

typedef void (Eq_119)(real64, int32);

typedef void (Eq_122)(int32);

typedef void (Eq_140)(real64);

typedef void (Eq_144)(real64, real64, Eq_148);

typedef union Eq_148 {
	word32 * u0;
	int32 & u1;
} Eq_148;

typedef int32 & Eq_164;

typedef union Eq_169 {
	word32 * u0;
	int32 & u1;
} Eq_169;

typedef struct Eq_214 {
	<anonymous> * ptrFFFFFFFC;	// FFFFFFFC
} Eq_214;

