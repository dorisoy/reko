// subject.h
// Generated by decompiling subject.exe
// using Reko decompiler version 0.10.1.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (10CB8 Eq_2 t10CB8) (10CF4 word32 _lib_version) (10CF8 (str char) str10CF8) (10D00 (str char) str10D00) (20E3C ptr32 environ) (20E58 ui32 dw20E58) (20E5C word32 __fnonstd_used) (20E60 ptr32 ___Argv))
	globals_t (in globals @ 00000000 : (ptr32 (struct "Globals")))
Eq_2: (fn void ())
	T_2 (in g1 @ 00000000 : (ptr32 Eq_2))
	T_24 (in 0<32> @ 00010A00 : word32)
	T_40 (in func @ 00010A14 : (ptr32 (fn void ())))
	T_41 (in 0x10CB8<32> @ 00010A14 : word32)
Eq_7: (struct "Eq_7" (8 int32 dw0008))
	T_7 (in o7 @ 00000000 : (ptr32 Eq_7))
	T_51 (in o7 @ 00010A1C : (ptr32 Eq_7))
	T_123 (in o7 @ 00010C84 : (ptr32 Eq_7))
	T_131 (in i7 @ 00010C84 : (ptr32 Eq_7))
Eq_38: (fn void ((ptr32 Eq_2)))
	T_38 (in atexit @ 00010A14 : ptr32)
	T_39 (in signature of atexit @ 00000000 : void)
	T_55 (in atexit @ 00010A08 : ptr32)
Eq_43: (fn void (word32, word32, word32, word32, word32, word32, (ptr32 Eq_7)))
	T_43 (in _init @ 00010A1C : ptr32)
	T_44 (in signature of _init @ 00010C80 : void)
Eq_110: (fn int32 ((ptr32 char)))
	T_110 (in printf @ 00010C60 : ptr32)
	T_111 (in signature of printf @ 00000000 : void)
Eq_115: (fn int32 ((ptr32 char)))
	T_115 (in printf @ 00010C4C : ptr32)
	T_116 (in signature of printf @ 00000000 : void)
Eq_121: (fn void ((ptr32 Eq_7), word32, word32, word32, word32, word32, word32, ptr32, (ptr32 Eq_7)))
	T_121 (in fn00010C90 @ 00010C84 : ptr32)
	T_122 (in signature of fn00010C90 @ 00010C90 : void)
Eq_138: (struct "Eq_138" (FFFFFFF8 (ptr32 code) ptrFFFFFFF8))
	T_138 (in o7 + Mem0[o7 + 8<i32>:word32] @ 00010C98 : word32)
Eq_150: (struct "Eq_150" (8 int32 dw0008))
	T_150 (in o7 @ 00010CA8 : (ptr32 Eq_150))
	T_153 (in o7 @ 00010CBC : (ptr32 Eq_150))
	T_161 (in i7 @ 00010CBC : (ptr32 Eq_150))
Eq_151: (fn void ((ptr32 Eq_150), word32, word32, word32, word32, word32, word32, ptr32, (ptr32 Eq_150)))
	T_151 (in fn00010CC8 @ 00010CBC : ptr32)
	T_152 (in signature of fn00010CC8 @ 00010CC8 : void)
Eq_168: (struct "Eq_168" (FFFFFFFC (ptr32 code) ptrFFFFFFFC))
	T_168 (in o7 + Mem0[o7 + 8<i32>:word32] @ 00010CD0 : word32)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in g1 @ 00000000 : (ptr32 Eq_2))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 (fn void ()))
T_3: (in o2 @ 00000000 : word32)
  Class: Eq_3
  DataType: word32
  OrigDataType: word32
T_4: (in o3 @ 00000000 : word32)
  Class: Eq_4
  DataType: word32
  OrigDataType: word32
T_5: (in o4 @ 00000000 : word32)
  Class: Eq_5
  DataType: word32
  OrigDataType: word32
T_6: (in o5 @ 00000000 : word32)
  Class: Eq_6
  DataType: word32
  OrigDataType: word32
T_7: (in o7 @ 00000000 : (ptr32 Eq_7))
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: word32
T_8: (in fsr @ 00000000 : ui32)
  Class: Eq_8
  DataType: ui32
  OrigDataType: word32
T_9: (in dwArg40 @ 00000000 : ui32)
  Class: Eq_9
  DataType: ui32
  OrigDataType: ui32
T_10: (in fp @ 00010968 : ptr32)
  Class: Eq_10
  DataType: ptr32
  OrigDataType: ptr32
T_11: (in 0x44<32> @ 00010968 : word32)
  Class: Eq_11
  DataType: int32
  OrigDataType: int32
T_12: (in fp + 0x44<32> @ 00000000 : word32)
  Class: Eq_12
  DataType: ptr32
  OrigDataType: ptr32
T_13: (in 0x20E60<32> @ 00010968 : word32)
  Class: Eq_13
  DataType: (ptr32 ptr32)
  OrigDataType: (ptr32 (struct (0 T_14 t0000)))
T_14: (in Mem8[0x20E60<32>:word32] @ 00010968 : word32)
  Class: Eq_12
  DataType: ptr32
  OrigDataType: word32
T_15: (in fp + 0x44<32> @ 00000000 : word32)
  Class: Eq_15
  DataType: ptr32
  OrigDataType: ptr32
T_16: (in 2<32> @ 0001097C : word32)
  Class: Eq_16
  DataType: word32
  OrigDataType: word32
T_17: (in dwArg40 << 2<32> @ 00000000 : word32)
  Class: Eq_17
  DataType: ui32
  OrigDataType: ui32
T_18: (in 4<32> @ 0001097C : word32)
  Class: Eq_18
  DataType: word32
  OrigDataType: word32
T_19: (in (dwArg40 << 2<32>) + 4<32> @ 00000000 : word32)
  Class: Eq_19
  DataType: int32
  OrigDataType: int32
T_20: (in fp + 0x44<32> + ((dwArg40 << 2<32>) + 4<32>) @ 00000000 : word32)
  Class: Eq_20
  DataType: ptr32
  OrigDataType: ptr32
T_21: (in 0x20E3C<32> @ 0001097C : word32)
  Class: Eq_21
  DataType: (ptr32 ptr32)
  OrigDataType: (ptr32 (struct (0 T_22 t0000)))
T_22: (in Mem13[0x20E3C<32>:word32] @ 0001097C : word32)
  Class: Eq_20
  DataType: ptr32
  OrigDataType: word32
T_23: (in true @ 0001098C : bool)
  Class: Eq_23
  DataType: bool
  OrigDataType: bool
T_24: (in 0<32> @ 00010A00 : word32)
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: word32
T_25: (in g1 == null @ 00000000 : bool)
  Class: Eq_25
  DataType: bool
  OrigDataType: bool
T_26: (in 0x20E58<32> @ 000109B0 : word32)
  Class: Eq_26
  DataType: (ptr32 ui32)
  OrigDataType: (ptr32 (struct (0 T_27 t0000)))
T_27: (in Mem27[0x20E58<32>:word32] @ 000109B0 : word32)
  Class: Eq_8
  DataType: ui32
  OrigDataType: word32
T_28: (in 0x20E58<32> @ 000109C8 : word32)
  Class: Eq_28
  DataType: (ptr32 ui32)
  OrigDataType: (ptr32 (struct (0 T_29 t0000)))
T_29: (in Mem27[0x20E58<32>:word32] @ 000109C8 : word32)
  Class: Eq_8
  DataType: ui32
  OrigDataType: ui32
T_30: (in 0x303FFFFF<32> @ 000109C8 : word32)
  Class: Eq_30
  DataType: ui32
  OrigDataType: ui32
T_31: (in g_dw20E58 & 0x303FFFFF<32> @ 00000000 : word32)
  Class: Eq_8
  DataType: ui32
  OrigDataType: ui32
T_32: (in 0x20E58<32> @ 000109C8 : word32)
  Class: Eq_32
  DataType: (ptr32 ui32)
  OrigDataType: (ptr32 (struct (0 T_33 t0000)))
T_33: (in Mem33[0x20E58<32>:word32] @ 000109C8 : word32)
  Class: Eq_8
  DataType: ui32
  OrigDataType: word32
T_34: (in true @ 000109E0 : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_35: (in 1<32> @ 000109F4 : word32)
  Class: Eq_35
  DataType: word32
  OrigDataType: word32
T_36: (in 0x20E5C<32> @ 000109F4 : word32)
  Class: Eq_36
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_37 t0000)))
T_37: (in Mem44[0x20E5C<32>:word32] @ 000109F4 : word32)
  Class: Eq_35
  DataType: word32
  OrigDataType: word32
T_38: (in atexit @ 00010A14 : ptr32)
  Class: Eq_38
  DataType: (ptr32 Eq_38)
  OrigDataType: (ptr32 (fn T_42 (T_41)))
T_39: (in signature of atexit @ 00000000 : void)
  Class: Eq_38
  DataType: (ptr32 Eq_38)
  OrigDataType: 
T_40: (in func @ 00010A14 : (ptr32 (fn void ())))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: 
T_41: (in 0x10CB8<32> @ 00010A14 : word32)
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 (fn void ()))
T_42: (in atexit(&g_t10CB8) @ 00010A14 : void)
  Class: Eq_42
  DataType: void
  OrigDataType: void
T_43: (in _init @ 00010A1C : ptr32)
  Class: Eq_43
  DataType: (ptr32 Eq_43)
  OrigDataType: (ptr32 (fn T_54 (T_52, T_53, T_3, T_4, T_5, T_6, T_7)))
T_44: (in signature of _init @ 00010C80 : void)
  Class: Eq_43
  DataType: (ptr32 Eq_43)
  OrigDataType: 
T_45: (in o0 @ 00010A1C : word32)
  Class: Eq_45
  DataType: word32
  OrigDataType: word32
T_46: (in o1 @ 00010A1C : word32)
  Class: Eq_46
  DataType: word32
  OrigDataType: word32
T_47: (in o2 @ 00010A1C : word32)
  Class: Eq_3
  DataType: word32
  OrigDataType: word32
T_48: (in o3 @ 00010A1C : word32)
  Class: Eq_4
  DataType: word32
  OrigDataType: word32
T_49: (in o4 @ 00010A1C : word32)
  Class: Eq_5
  DataType: word32
  OrigDataType: word32
T_50: (in o5 @ 00010A1C : word32)
  Class: Eq_6
  DataType: word32
  OrigDataType: word32
T_51: (in o7 @ 00010A1C : (ptr32 Eq_7))
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: word32
T_52: (in 0x10CB8<32> @ 00010A1C : word32)
  Class: Eq_45
  DataType: word32
  OrigDataType: word32
T_53: (in 0x20C00<32> @ 00010A1C : word32)
  Class: Eq_46
  DataType: word32
  OrigDataType: word32
T_54: (in _init(0x10CB8<32>, 0x20C00<32>, o2, o3, o4, o5, o7) @ 00010A1C : void)
  Class: Eq_54
  DataType: void
  OrigDataType: void
T_55: (in atexit @ 00010A08 : ptr32)
  Class: Eq_38
  DataType: (ptr32 Eq_38)
  OrigDataType: (ptr32 (fn T_56 (T_2)))
T_56: (in atexit(g1) @ 00010A08 : void)
  Class: Eq_42
  DataType: void
  OrigDataType: void
T_57: (in o0 @ 00010B04 : int32)
  Class: Eq_57
  DataType: int32
  OrigDataType: int32
T_58: (in o0_20 @ 00010B10 : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_59: (in 1<32> @ 00010B10 : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_60: (in 1<32> @ 00010B18 : word32)
  Class: Eq_57
  DataType: int32
  OrigDataType: int32
T_61: (in o0 <= 1<32> @ 00000000 : bool)
  Class: Eq_61
  DataType: bool
  OrigDataType: bool
T_62: (in o0_31 @ 00010B20 : word32)
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_63: (in 0<32> @ 00010B24 : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_64: (in o0_20 == 0<32> @ 00000000 : bool)
  Class: Eq_64
  DataType: bool
  OrigDataType: bool
T_65: (in 0<32> @ 00010B1C : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_66: (in 0x10A74<32> @ 00010B38 : word32)
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_67: (in 0x10A5C<32> @ 00010B2C : word32)
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_68: (in o3_37 @ 00010B3C : word32)
  Class: Eq_68
  DataType: word32
  OrigDataType: word32
T_69: (in 0<32> @ 00010B3C : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_70: (in o0_20 == 0<32> @ 00000000 : bool)
  Class: Eq_70
  DataType: bool
  OrigDataType: bool
T_71: (in 0x10AA4<32> @ 00010B50 : word32)
  Class: Eq_68
  DataType: word32
  OrigDataType: word32
T_72: (in 0x10A8C<32> @ 00010B44 : word32)
  Class: Eq_68
  DataType: word32
  OrigDataType: word32
T_73: (in o2_43 @ 00010B54 : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_74: (in 0<32> @ 00010B54 : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_75: (in o0_20 == 0<32> @ 00000000 : bool)
  Class: Eq_75
  DataType: bool
  OrigDataType: bool
T_76: (in 0x10AD4<32> @ 00010B68 : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_77: (in 0x10ABC<32> @ 00010B5C : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_78: (in o1_49 @ 00010B6C : word32)
  Class: Eq_78
  DataType: word32
  OrigDataType: word32
T_79: (in 0<32> @ 00010B6C : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_80: (in o0_20 == 0<32> @ 00000000 : bool)
  Class: Eq_80
  DataType: bool
  OrigDataType: bool
T_81: (in 0x10B04<32> @ 00010B80 : word32)
  Class: Eq_78
  DataType: word32
  OrigDataType: word32
T_82: (in 0x10AEC<32> @ 00010B74 : word32)
  Class: Eq_78
  DataType: word32
  OrigDataType: word32
T_83: (in v24_217 @ 00010B84 : bool)
  Class: Eq_83
  DataType: bool
  OrigDataType: bool
T_84: (in i1_114 @ 00010B84 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_85: (in 0<32> @ 00010B84 : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_86: (in o0_20 == 0<32> @ 00000000 : bool)
  Class: Eq_86
  DataType: bool
  OrigDataType: bool
T_87: (in 0x10A74<32> @ 00010BF4 : word32)
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_88: (in o0_31 != 0x10A74<32> @ 00000000 : bool)
  Class: Eq_88
  DataType: bool
  OrigDataType: bool
T_89: (in 0x10A5C<32> @ 00010B94 : word32)
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_90: (in o0_31 != 0x10A5C<32> @ 00000000 : bool)
  Class: Eq_90
  DataType: bool
  OrigDataType: bool
T_91: (in 0x10A8C<32> @ 00010BA4 : word32)
  Class: Eq_68
  DataType: word32
  OrigDataType: word32
T_92: (in o3_37 != 0x10A8C<32> @ 00000000 : bool)
  Class: Eq_92
  DataType: bool
  OrigDataType: bool
T_93: (in 0<32> @ 00010BE0 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_94: (in true @ 00010BE0 : bool)
  Class: Eq_83
  DataType: bool
  OrigDataType: bool
T_95: (in 0x10ABC<32> @ 00010BB8 : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_96: (in o2_43 != 0x10ABC<32> @ 00000000 : bool)
  Class: Eq_96
  DataType: bool
  OrigDataType: bool
T_97: (in 0x10AEC<32> @ 00010BCC : word32)
  Class: Eq_78
  DataType: word32
  OrigDataType: word32
T_98: (in o1_49 != 0x10AEC<32> @ 00000000 : bool)
  Class: Eq_98
  DataType: bool
  OrigDataType: bool
T_99: (in 1<32> @ 00010BD4 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_100: (in 0<32> @ 00010C40 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_101: (in i1_114 == 0<32> @ 00000000 : bool)
  Class: Eq_83
  DataType: bool
  OrigDataType: bool
T_102: (in 0<32> @ 00010C3C : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_103: (in 0x10AA4<32> @ 00010C04 : word32)
  Class: Eq_68
  DataType: word32
  OrigDataType: word32
T_104: (in o3_37 != 0x10AA4<32> @ 00000000 : bool)
  Class: Eq_104
  DataType: bool
  OrigDataType: bool
T_105: (in 0x10AD4<32> @ 00010C18 : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_106: (in o2_43 != 0x10AD4<32> @ 00000000 : bool)
  Class: Eq_106
  DataType: bool
  OrigDataType: bool
T_107: (in 0x10B04<32> @ 00010C2C : word32)
  Class: Eq_78
  DataType: word32
  OrigDataType: word32
T_108: (in o1_49 != 0x10B04<32> @ 00000000 : bool)
  Class: Eq_108
  DataType: bool
  OrigDataType: bool
T_109: (in 1<32> @ 00010C34 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_110: (in printf @ 00010C60 : ptr32)
  Class: Eq_110
  DataType: (ptr32 Eq_110)
  OrigDataType: (ptr32 (fn T_114 (T_113)))
T_111: (in signature of printf @ 00000000 : void)
  Class: Eq_110
  DataType: (ptr32 Eq_110)
  OrigDataType: 
T_112: (in format @ 00010C60 : (ptr32 char))
  Class: Eq_112
  DataType: (ptr32 char)
  OrigDataType: 
T_113: (in 0x10D00<32> @ 00010C60 : word32)
  Class: Eq_112
  DataType: (ptr32 char)
  OrigDataType: (ptr32 char)
T_114: (in printf("Failed!\n") @ 00010C60 : int32)
  Class: Eq_114
  DataType: int32
  OrigDataType: int32
T_115: (in printf @ 00010C4C : ptr32)
  Class: Eq_115
  DataType: (ptr32 Eq_115)
  OrigDataType: (ptr32 (fn T_118 (T_117)))
T_116: (in signature of printf @ 00000000 : void)
  Class: Eq_115
  DataType: (ptr32 Eq_115)
  OrigDataType: 
T_117: (in 0x10CF8<32> @ 00010C4C : word32)
  Class: Eq_112
  DataType: (ptr32 char)
  OrigDataType: (ptr32 char)
T_118: (in printf("Pass\n") @ 00010C4C : int32)
  Class: Eq_118
  DataType: int32
  OrigDataType: int32
T_119: (in 0<32> @ 00010C70 : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_120: (in i1_114 == 0<32> @ 00000000 : bool)
  Class: Eq_120
  DataType: bool
  OrigDataType: bool
T_121: (in fn00010C90 @ 00010C84 : ptr32)
  Class: Eq_121
  DataType: (ptr32 Eq_121)
  OrigDataType: (ptr32 (fn T_133 (T_51, T_45, T_46, T_47, T_48, T_49, T_50, T_132, T_51)))
T_122: (in signature of fn00010C90 @ 00010C90 : void)
  Class: Eq_121
  DataType: (ptr32 Eq_121)
  OrigDataType: 
T_123: (in o7 @ 00010C84 : (ptr32 Eq_7))
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: (ptr32 (struct (8 T_137 t0008)))
T_124: (in i0 @ 00010C84 : word32)
  Class: Eq_45
  DataType: word32
  OrigDataType: word32
T_125: (in i1 @ 00010C84 : word32)
  Class: Eq_46
  DataType: word32
  OrigDataType: word32
T_126: (in i2 @ 00010C84 : word32)
  Class: Eq_3
  DataType: word32
  OrigDataType: word32
T_127: (in i3 @ 00010C84 : word32)
  Class: Eq_4
  DataType: word32
  OrigDataType: word32
T_128: (in i4 @ 00010C84 : word32)
  Class: Eq_5
  DataType: word32
  OrigDataType: word32
T_129: (in i5 @ 00010C84 : word32)
  Class: Eq_6
  DataType: word32
  OrigDataType: word32
T_130: (in i6 @ 00010C84 : ptr32)
  Class: Eq_130
  DataType: ptr32
  OrigDataType: word32
T_131: (in i7 @ 00010C84 : (ptr32 Eq_7))
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: word32
T_132: (in fp @ 00010C84 : ptr32)
  Class: Eq_130
  DataType: ptr32
  OrigDataType: ptr32
T_133: (in fn00010C90(o7, o0, o1, o2, o3, o4, o5, fp, o7) @ 00010C84 : void)
  Class: Eq_133
  DataType: void
  OrigDataType: void
T_134: (in l0_7 @ 00010C98 : (ptr32 code))
  Class: Eq_134
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_135: (in 8<i32> @ 00010C98 : int32)
  Class: Eq_135
  DataType: int32
  OrigDataType: int32
T_136: (in o7 + 8<i32> @ 00010C98 : word32)
  Class: Eq_136
  DataType: word32
  OrigDataType: word32
T_137: (in Mem0[o7 + 8<i32>:word32] @ 00010C98 : word32)
  Class: Eq_137
  DataType: int32
  OrigDataType: int32
T_138: (in o7 + Mem0[o7 + 8<i32>:word32] @ 00010C98 : word32)
  Class: Eq_138
  DataType: (ptr32 Eq_138)
  OrigDataType: (ptr32 (struct (FFFFFFF8 T_141 tFFFFFFF8)))
T_139: (in -8<i32> @ 00010C98 : int32)
  Class: Eq_139
  DataType: int32
  OrigDataType: int32
T_140: (in o7 + Mem0[o7 + 8<i32>:word32] + -8<i32> @ 00010C98 : word32)
  Class: Eq_140
  DataType: word32
  OrigDataType: word32
T_141: (in Mem0[o7 + Mem0[o7 + 8<i32>:word32] + -8<i32>:word32] @ 00010C98 : word32)
  Class: Eq_134
  DataType: (ptr32 code)
  OrigDataType: word32
T_142: (in 0<32> @ 00010CA0 : word32)
  Class: Eq_134
  DataType: (ptr32 code)
  OrigDataType: word32
T_143: (in l0_7 == null @ 00000000 : bool)
  Class: Eq_143
  DataType: bool
  OrigDataType: bool
T_144: (in o0 @ 00010CA8 : word32)
  Class: Eq_144
  DataType: word32
  OrigDataType: word32
T_145: (in o1 @ 00010CA8 : word32)
  Class: Eq_145
  DataType: word32
  OrigDataType: word32
T_146: (in o2 @ 00010CA8 : word32)
  Class: Eq_146
  DataType: word32
  OrigDataType: word32
T_147: (in o3 @ 00010CA8 : word32)
  Class: Eq_147
  DataType: word32
  OrigDataType: word32
T_148: (in o4 @ 00010CA8 : word32)
  Class: Eq_148
  DataType: word32
  OrigDataType: word32
T_149: (in o5 @ 00010CA8 : word32)
  Class: Eq_149
  DataType: word32
  OrigDataType: word32
T_150: (in o7 @ 00010CA8 : (ptr32 Eq_150))
  Class: Eq_150
  DataType: (ptr32 Eq_150)
  OrigDataType: word32
T_151: (in fn00010CC8 @ 00010CBC : ptr32)
  Class: Eq_151
  DataType: (ptr32 Eq_151)
  OrigDataType: (ptr32 (fn T_163 (T_150, T_144, T_145, T_146, T_147, T_148, T_149, T_162, T_150)))
T_152: (in signature of fn00010CC8 @ 00010CC8 : void)
  Class: Eq_151
  DataType: (ptr32 Eq_151)
  OrigDataType: 
T_153: (in o7 @ 00010CBC : (ptr32 Eq_150))
  Class: Eq_150
  DataType: (ptr32 Eq_150)
  OrigDataType: (ptr32 (struct (8 T_167 t0008)))
T_154: (in i0 @ 00010CBC : word32)
  Class: Eq_144
  DataType: word32
  OrigDataType: word32
T_155: (in i1 @ 00010CBC : word32)
  Class: Eq_145
  DataType: word32
  OrigDataType: word32
T_156: (in i2 @ 00010CBC : word32)
  Class: Eq_146
  DataType: word32
  OrigDataType: word32
T_157: (in i3 @ 00010CBC : word32)
  Class: Eq_147
  DataType: word32
  OrigDataType: word32
T_158: (in i4 @ 00010CBC : word32)
  Class: Eq_148
  DataType: word32
  OrigDataType: word32
T_159: (in i5 @ 00010CBC : word32)
  Class: Eq_149
  DataType: word32
  OrigDataType: word32
T_160: (in i6 @ 00010CBC : ptr32)
  Class: Eq_160
  DataType: ptr32
  OrigDataType: word32
T_161: (in i7 @ 00010CBC : (ptr32 Eq_150))
  Class: Eq_150
  DataType: (ptr32 Eq_150)
  OrigDataType: word32
T_162: (in fp @ 00010CBC : ptr32)
  Class: Eq_160
  DataType: ptr32
  OrigDataType: ptr32
T_163: (in fn00010CC8(o7, o0, o1, o2, o3, o4, o5, fp, o7) @ 00010CBC : void)
  Class: Eq_163
  DataType: void
  OrigDataType: void
T_164: (in l0_7 @ 00010CD0 : (ptr32 code))
  Class: Eq_164
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_165: (in 8<i32> @ 00010CD0 : int32)
  Class: Eq_165
  DataType: int32
  OrigDataType: int32
T_166: (in o7 + 8<i32> @ 00010CD0 : word32)
  Class: Eq_166
  DataType: word32
  OrigDataType: word32
T_167: (in Mem0[o7 + 8<i32>:word32] @ 00010CD0 : word32)
  Class: Eq_167
  DataType: int32
  OrigDataType: int32
T_168: (in o7 + Mem0[o7 + 8<i32>:word32] @ 00010CD0 : word32)
  Class: Eq_168
  DataType: (ptr32 Eq_168)
  OrigDataType: (ptr32 (struct (FFFFFFFC T_171 tFFFFFFFC)))
T_169: (in -4<i32> @ 00010CD0 : int32)
  Class: Eq_169
  DataType: int32
  OrigDataType: int32
T_170: (in o7 + Mem0[o7 + 8<i32>:word32] + -4<i32> @ 00010CD0 : word32)
  Class: Eq_170
  DataType: word32
  OrigDataType: word32
T_171: (in Mem0[o7 + Mem0[o7 + 8<i32>:word32] + -4<i32>:word32] @ 00010CD0 : word32)
  Class: Eq_164
  DataType: (ptr32 code)
  OrigDataType: word32
T_172: (in 0<32> @ 00010CD8 : word32)
  Class: Eq_164
  DataType: (ptr32 code)
  OrigDataType: word32
T_173: (in l0_7 == null @ 00000000 : bool)
  Class: Eq_173
  DataType: bool
  OrigDataType: bool
T_174:
  Class: Eq_174
  DataType: word32
  OrigDataType: word32
T_175:
  Class: Eq_20
  DataType: ptr32
  OrigDataType: word32
T_176:
  Class: Eq_35
  DataType: word32
  OrigDataType: word32
T_177:
  Class: Eq_12
  DataType: ptr32
  OrigDataType: word32
*/
typedef struct Globals {
	Eq_2 t10CB8;	// 10CB8
	word32 _lib_version;	// 10CF4
	char str10CF8[];	// 10CF8
	char str10D00[];	// 10D00
	ptr32 environ;	// 20E3C
	ui32 dw20E58;	// 20E58
	word32 __fnonstd_used;	// 20E5C
	ptr32 ___Argv;	// 20E60
} Eq_1;

typedef void (Eq_2)();

typedef struct Eq_7 {
	int32 dw0008;	// 8
} Eq_7;

typedef void (Eq_38)( *);

typedef void (Eq_43)(word32, word32, word32, word32, word32, word32, Eq_7 *);

typedef int32 (Eq_110)(char *);

typedef int32 (Eq_115)(char *);

typedef void (Eq_121)(Eq_7 *, word32, word32, word32, word32, word32, word32, ptr32, Eq_7 *);

typedef struct Eq_138 {
	<anonymous> * ptrFFFFFFF8;	// FFFFFFF8
} Eq_138;

typedef struct Eq_150 {
	int32 dw0008;	// 8
} Eq_150;

typedef void (Eq_151)(Eq_150 *, word32, word32, word32, word32, word32, word32, ptr32, Eq_150 *);

typedef struct Eq_168 {
	<anonymous> * ptrFFFFFFFC;	// FFFFFFFC
} Eq_168;

