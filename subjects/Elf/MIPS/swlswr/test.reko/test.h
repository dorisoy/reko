// test.h
// Generated by decompiling test
// using Reko decompiler version 0.10.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (FFFFFFFF code tFFFFFFFF) (0 code t0000) (A58 word32 _IO_stdin_used) (10A60 (ptr32 code) ptr10A60) (10A98 (ptr32 code) main_GOT) (10A9C (ptr32 code) __libc_csu_init_GOT) (10AA0 (ptr32 code) __libc_csu_fini_GOT) (10AA4 int32 dw10AA4) (10AAC word32 dw10AAC) (10AB0 int32 dw10AB0) (10AB8 (ptr32 code) _init_GOT) (10ABC (ptr32 (ptr32 code)) ptr10ABC) (10AD0 (ptr32 code) calloc_GOT) (10AD4 (ptr32 code) ptr10AD4) (10AD8 (ptr32 code) memset_GOT) (10ADC (ptr32 code) __libc_start_main_GOT) (10AE0 (ptr32 code) __gmon_start___GOT) (10AE4 (ptr32 code) ptr10AE4) (10AE8 (ptr32 code) __cxa_finalize_GOT) (10AF0 byte b10AF0) (10AF4 Eq_84 dtor_idx.6258) (20A24 (ptr32 code) ptr20A24) (20A4C ptr32 ptr20A4C) (20A60 word32 dw20A60) (20A64 word32 dw20A64) (20A68 word32 dw20A68))
	globals_t (in globals @ 00000000 : (ptr32 (struct "Globals")))
Eq_24: (struct "Eq_24" (10 word32 dw0010) (14 word32 dw0014) (18 (ptr32 Eq_24) ptr0018))
	T_24 (in sp_17 @ 00000640 : (ptr32 Eq_24))
	T_29 (in (fp & -8<i32>) + -32<i32> @ 00000000 : word32)
	T_44 (in Mem23[sp_17 + 0x18<32>:word32] @ 00000654 : word32)
Eq_25: (union "Eq_25" (ui32 u0) (ptr32 u1))
	T_25 (in fp @ 00000640 : ptr32)
Eq_56: (union "Eq_56" (int32 u0) (uint32 u1))
	T_56 (in r5_12 @ 000006C4 : Eq_56)
	T_62 (in g_dw10AA4 - 0x10A84<32> >> 2<8> @ 00000000 : word32)
Eq_64: (union "Eq_64" (int32 u0) (uint32 u1))
	T_64 (in r5_12 >> 0x1F<8> @ 00000000 : word32)
Eq_65: (union "Eq_65" (int32 u0) (uint32 u1))
	T_65 (in (r5_12 >>u 0x1F<8>) + r5_12 @ 000006D4 : word32)
Eq_84: (union "Eq_84" (int32 u0) (uint32 u1))
	T_84 (in r2_40 @ 0000075C : Eq_84)
	T_86 (in Mem19[0x10AF4<32>:word32] @ 0000075C : word32)
	T_87 (in r16_42 @ 00000764 : Eq_84)
	T_95 (in (g_dw10AB0 - 0x10A68<32> >> 2<8>) + -1<i32> @ 00000000 : word32)
	T_113 (in r2_47 @ 00000774 : Eq_84)
	T_115 (in r2_40 + 1<i32> @ 00000774 : word32)
	T_117 (in Mem50[0x10AF4<32>:word32] @ 0000077C : word32)
	T_128 (in Mem50[0x10AF4<32>:word32] @ 00000790 : word32)
	T_243
Eq_107: (fn void ())
	T_107 (in deregister_tm_clones @ 000007A8 : ptr32)
	T_108 (in signature of deregister_tm_clones @ 00000670 : void)
Eq_114: (union "Eq_114" (int32 u0) (up32 u1))
	T_114 (in 1<i32> @ 00000774 : int32)
Eq_133: (fn void ())
	T_133 (in register_tm_clones @ 000007E8 : ptr32)
	T_134 (in signature of register_tm_clones @ 000006A8 : void)
Eq_136: (fn (ptr32 void) ((ptr32 void), int32, Eq_140))
	T_136 (in memset @ 00000830 : ptr32)
	T_137 (in signature of memset @ 00000000 : void)
Eq_140: size_t
	T_140 (in num @ 00000830 : size_t)
	T_146 (in SLICE(5<i32>, size_t, 0) @ 00000830 : size_t)
	T_151 (in num @ 0000084C : size_t)
	T_152 (in size @ 0000084C : size_t)
	T_154 (in SLICE(1<i32>, size_t, 0) @ 0000084C : size_t)
	T_156 (in SLICE(5<i32>, size_t, 0) @ 0000084C : size_t)
Eq_148: (struct "Eq_148" (0 Eq_158 t0000) (1 word32 dw0001) (4 byte b0004))
	T_148 (in r2_38 @ 0000084C : (ptr32 Eq_148))
	T_157 (in calloc((size_t) 1<i32>, (size_t) 5<i32>) @ 0000084C : (ptr32 void))
	T_174 (in r2_43 @ 0000085C : word32)
	T_176 (in r2_52 @ 00000880 : word32)
Eq_158: (union "Eq_158" (byte u0) (word32 u1))
	T_158 (in dwLoc14 @ 00000868 : word32)
	T_161 (in Mem45[r2_38 + 0<32>:word32] @ 00000868 : word32)
	T_166 (in 0xC<8> @ 0000087C : byte)
	T_169 (in Mem51[r2_38 + 0<32>:byte] @ 0000087C : byte)
	T_175 (in r3_44 @ 00000860 : word32)
Eq_180: (fn void ())
	T_180 (in _init @ 000008FC : ptr32)
	T_181 (in signature of _init @ 00000588 : void)
Eq_219: (struct "Eq_219" (FFFF8010 (ptr32 code) ptrFFFF8010))
	T_219 (in r28 @ 000009B4 : (ptr32 Eq_219))
Eq_224: (struct "Eq_224" (FFFF8010 (ptr32 code) ptrFFFF8010))
	T_224 (in r28 @ 000009D8 : (ptr32 Eq_224))
Eq_229: (struct "Eq_229" (FFFF8010 (ptr32 code) ptrFFFF8010))
	T_229 (in r28 @ 000009E8 : (ptr32 Eq_229))
Eq_234: (fn void ())
	T_234 (in _fini @ 00000A0C : ptr32)
	T_235 (in signature of _fini @ 00000A10 : void)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in __gmon_start__ @ 000005A4 : ptr32)
  Class: Eq_2
  DataType: word32
  OrigDataType: 
T_3: (in signature of __gmon_start__ @ 00000000 : void)
  Class: Eq_3
  DataType: Eq_3
  OrigDataType: 
T_4: (in 0<32> @ 000005A4 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_5: (in __gmon_start__ == 0<32> @ 00000000 : bool)
  Class: Eq_5
  DataType: bool
  OrigDataType: bool
T_6: (in r25_16 @ 000005CC : ptr32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: ptr32
T_7: (in 00020A4C @ 000005CC : ptr32)
  Class: Eq_7
  DataType: (ptr32 ptr32)
  OrigDataType: (ptr32 (struct (0 T_8 t0000)))
T_8: (in Mem10[0x00020A4C<p32>:word32] @ 000005CC : word32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: word32
T_9: (in 2004<i32> @ 000005D4 : int32)
  Class: Eq_9
  DataType: int32
  OrigDataType: int32
T_10: (in r25_16 + 2004<i32> @ 00000000 : word32)
  Class: Eq_10
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_11: (in r25_24 @ 000005F0 : ptr32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: ptr32
T_12: (in 00020A4C @ 000005F0 : ptr32)
  Class: Eq_12
  DataType: (ptr32 ptr32)
  OrigDataType: (ptr32 (struct (0 T_13 t0000)))
T_13: (in Mem10[0x00020A4C<p32>:word32] @ 000005F0 : word32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: word32
T_14: (in 2416<i32> @ 000005F8 : int32)
  Class: Eq_14
  DataType: int32
  OrigDataType: int32
T_15: (in r25_24 + 2416<i32> @ 00000000 : word32)
  Class: Eq_15
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_16: (in r25_31 @ 000005B0 : word32)
  Class: Eq_16
  DataType: word32
  OrigDataType: word32
T_17: (in __gmon_start__ @ 000005B0 : ptr32)
  Class: Eq_17
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_18: (in signature of __gmon_start__ @ 00000000 : void)
  Class: Eq_18
  DataType: Eq_18
  OrigDataType: 
T_19: (in r2 @ 000005B0 : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_20: (in dwArg00 @ 000005B0 : word32)
  Class: Eq_20
  DataType: word32
  OrigDataType: word32
T_21: (in r4_12 @ 0000062C : word32)
  Class: Eq_21
  DataType: word32
  OrigDataType: word32
T_22: (in 00020A68 @ 0000062C : ptr32)
  Class: Eq_22
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_23 t0000)))
T_23: (in Mem0[0x00020A68<p32>:word32] @ 0000062C : word32)
  Class: Eq_21
  DataType: word32
  OrigDataType: word32
T_24: (in sp_17 @ 00000640 : (ptr32 Eq_24))
  Class: Eq_24
  DataType: (ptr32 Eq_24)
  OrigDataType: (ptr32 (struct (10 T_38 t0010) (14 T_41 t0014) (18 T_44 t0018)))
T_25: (in fp @ 00000640 : ptr32)
  Class: Eq_25
  DataType: Eq_25
  OrigDataType: (union (ui32 u1) (ptr32 u0))
T_26: (in -8<i32> @ 00000640 : int32)
  Class: Eq_26
  DataType: int32
  OrigDataType: int32
T_27: (in fp & -8<i32> @ 00000000 : word32)
  Class: Eq_27
  DataType: ui32
  OrigDataType: ui32
T_28: (in -32<i32> @ 00000640 : int32)
  Class: Eq_28
  DataType: int32
  OrigDataType: int32
T_29: (in (fp & -8<i32>) + -32<i32> @ 00000000 : word32)
  Class: Eq_24
  DataType: (ptr32 Eq_24)
  OrigDataType: ui32
T_30: (in r7_18 @ 00000644 : word32)
  Class: Eq_30
  DataType: word32
  OrigDataType: word32
T_31: (in 00020A64 @ 00000644 : ptr32)
  Class: Eq_31
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_32 t0000)))
T_32: (in Mem0[0x00020A64<p32>:word32] @ 00000644 : word32)
  Class: Eq_30
  DataType: word32
  OrigDataType: word32
T_33: (in r8_19 @ 00000648 : word32)
  Class: Eq_33
  DataType: word32
  OrigDataType: word32
T_34: (in 00020A60 @ 00000648 : ptr32)
  Class: Eq_34
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_35 t0000)))
T_35: (in Mem0[0x00020A60<p32>:word32] @ 00000648 : word32)
  Class: Eq_33
  DataType: word32
  OrigDataType: word32
T_36: (in 0x10<32> @ 0000064C : word32)
  Class: Eq_36
  DataType: word32
  OrigDataType: word32
T_37: (in sp_17 + 0x10<32> @ 0000064C : word32)
  Class: Eq_37
  DataType: ui32
  OrigDataType: ui32
T_38: (in Mem20[sp_17 + 0x10<32>:word32] @ 0000064C : word32)
  Class: Eq_33
  DataType: word32
  OrigDataType: word32
T_39: (in 0x14<32> @ 00000650 : word32)
  Class: Eq_39
  DataType: word32
  OrigDataType: word32
T_40: (in sp_17 + 0x14<32> @ 00000650 : word32)
  Class: Eq_40
  DataType: ptr32
  OrigDataType: ptr32
T_41: (in Mem22[sp_17 + 0x14<32>:word32] @ 00000650 : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_42: (in 0x18<32> @ 00000654 : word32)
  Class: Eq_42
  DataType: word32
  OrigDataType: word32
T_43: (in sp_17 + 0x18<32> @ 00000654 : word32)
  Class: Eq_43
  DataType: ptr32
  OrigDataType: ptr32
T_44: (in Mem23[sp_17 + 0x18<32>:word32] @ 00000654 : word32)
  Class: Eq_24
  DataType: (ptr32 Eq_24)
  OrigDataType: word32
T_45: (in 00020A24 @ 0000065C : ptr32)
  Class: Eq_45
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_46 t0000)))
T_46: (in Mem23[0x00020A24<p32>:word32] @ 0000065C : word32)
  Class: Eq_46
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_47: (in 0x10AA4<32> @ 00000688 : word32)
  Class: Eq_47
  DataType: (ptr32 int32)
  OrigDataType: (ptr32 (struct (0 T_48 t0000)))
T_48: (in Mem0[0x10AA4<32>:word32] @ 00000688 : word32)
  Class: Eq_48
  DataType: int32
  OrigDataType: word32
T_49: (in 0x10A84<32> @ 00000688 : word32)
  Class: Eq_48
  DataType: int32
  OrigDataType: word32
T_50: (in g_dw10AA4 == 0x10A84<32> @ 00000000 : bool)
  Class: Eq_50
  DataType: bool
  OrigDataType: bool
T_51: (in r25_12 @ 00000690 : (ptr32 code))
  Class: Eq_51
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_52: (in 0<32> @ 00000690 : word32)
  Class: Eq_51
  DataType: (ptr32 code)
  OrigDataType: word32
T_53: (in r25_12 == null @ 00000000 : bool)
  Class: Eq_53
  DataType: bool
  OrigDataType: bool
T_54: (in 0x10AE4<32> @ 0000068C : word32)
  Class: Eq_54
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_55 t0000)))
T_55: (in Mem0[0x10AE4<32>:word32] @ 0000068C : word32)
  Class: Eq_51
  DataType: (ptr32 code)
  OrigDataType: word32
T_56: (in r5_12 @ 000006C4 : Eq_56)
  Class: Eq_56
  DataType: Eq_56
  OrigDataType: (union (int32 u1) (uint32 u0))
T_57: (in 0x10AA4<32> @ 000006C4 : word32)
  Class: Eq_57
  DataType: (ptr32 int32)
  OrigDataType: (ptr32 (struct (0 T_58 t0000)))
T_58: (in Mem0[0x10AA4<32>:word32] @ 000006C4 : word32)
  Class: Eq_48
  DataType: int32
  OrigDataType: int32
T_59: (in 0x10A84<32> @ 000006C4 : word32)
  Class: Eq_59
  DataType: int32
  OrigDataType: int32
T_60: (in g_dw10AA4 - 0x10A84<32> @ 00000000 : word32)
  Class: Eq_60
  DataType: int32
  OrigDataType: int32
T_61: (in 2<8> @ 000006C4 : byte)
  Class: Eq_61
  DataType: byte
  OrigDataType: byte
T_62: (in g_dw10AA4 - 0x10A84<32> >> 2<8> @ 00000000 : word32)
  Class: Eq_56
  DataType: Eq_56
  OrigDataType: int32
T_63: (in 0x1F<8> @ 000006D4 : byte)
  Class: Eq_63
  DataType: byte
  OrigDataType: byte
T_64: (in r5_12 >> 0x1F<8> @ 00000000 : word32)
  Class: Eq_64
  DataType: Eq_64
  OrigDataType: (union (int32 u1) (uint32 u0))
T_65: (in (r5_12 >>u 0x1F<8>) + r5_12 @ 000006D4 : word32)
  Class: Eq_65
  DataType: Eq_65
  OrigDataType: (union (int32 u1) (uint32 u0))
T_66: (in 1<8> @ 000006D4 : byte)
  Class: Eq_66
  DataType: byte
  OrigDataType: byte
T_67: (in (r5_12 >>u 0x1F<8>) + r5_12 >> 1<8> @ 000006D4 : word32)
  Class: Eq_67
  DataType: int32
  OrigDataType: int32
T_68: (in 0<32> @ 000006D4 : word32)
  Class: Eq_67
  DataType: int32
  OrigDataType: word32
T_69: (in (r5_12 >>u 0x1F<8>) + r5_12 >> 1<8> == 0<32> @ 000006D4 : bool)
  Class: Eq_69
  DataType: bool
  OrigDataType: bool
T_70: (in r25_17 @ 000006D8 : (ptr32 code))
  Class: Eq_70
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_71: (in 0x10AD4<32> @ 000006D8 : word32)
  Class: Eq_71
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_72 t0000)))
T_72: (in Mem0[0x10AD4<32>:word32] @ 000006D8 : word32)
  Class: Eq_70
  DataType: (ptr32 code)
  OrigDataType: word32
T_73: (in 0<32> @ 000006DC : word32)
  Class: Eq_70
  DataType: (ptr32 code)
  OrigDataType: word32
T_74: (in r25_17 == null @ 00000000 : bool)
  Class: Eq_74
  DataType: bool
  OrigDataType: bool
T_75: (in 0x10AF0<32> @ 00000724 : word32)
  Class: Eq_75
  DataType: (ptr32 byte)
  OrigDataType: (ptr32 (struct (0 T_76 t0000)))
T_76: (in Mem19[0x10AF0<32>:byte] @ 00000724 : byte)
  Class: Eq_76
  DataType: byte
  OrigDataType: byte
T_77: (in CONVERT(Mem19[0x10AF0<32>:byte], byte, word32) @ 00000724 : word32)
  Class: Eq_77
  DataType: word32
  OrigDataType: word32
T_78: (in 0<32> @ 00000724 : word32)
  Class: Eq_77
  DataType: word32
  OrigDataType: word32
T_79: (in (word32) g_b10AF0 != 0<32> @ 00000000 : bool)
  Class: Eq_79
  DataType: bool
  OrigDataType: bool
T_80: (in __cxa_finalize @ 0000072C : ptr32)
  Class: Eq_80
  DataType: word32
  OrigDataType: 
T_81: (in signature of __cxa_finalize @ 00000000 : void)
  Class: Eq_81
  DataType: Eq_81
  OrigDataType: 
T_82: (in 0<32> @ 0000072C : word32)
  Class: Eq_80
  DataType: word32
  OrigDataType: word32
T_83: (in __cxa_finalize == 0<32> @ 00000000 : bool)
  Class: Eq_83
  DataType: bool
  OrigDataType: bool
T_84: (in r2_40 @ 0000075C : Eq_84)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: up32
T_85: (in 0x10AF4<32> @ 0000075C : word32)
  Class: Eq_85
  DataType: (ptr32 Eq_84)
  OrigDataType: (ptr32 (struct (0 T_86 t0000)))
T_86: (in Mem19[0x10AF4<32>:word32] @ 0000075C : word32)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: word32
T_87: (in r16_42 @ 00000764 : Eq_84)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: (union (int32 u0) (uint32 u1))
T_88: (in 0x10AB0<32> @ 00000764 : word32)
  Class: Eq_88
  DataType: (ptr32 int32)
  OrigDataType: (ptr32 (struct (0 T_89 t0000)))
T_89: (in Mem19[0x10AB0<32>:word32] @ 00000764 : word32)
  Class: Eq_89
  DataType: int32
  OrigDataType: int32
T_90: (in 0x10A68<32> @ 00000764 : word32)
  Class: Eq_90
  DataType: int32
  OrigDataType: int32
T_91: (in g_dw10AB0 - 0x10A68<32> @ 00000000 : word32)
  Class: Eq_91
  DataType: int32
  OrigDataType: int32
T_92: (in 2<8> @ 00000764 : byte)
  Class: Eq_92
  DataType: byte
  OrigDataType: byte
T_93: (in g_dw10AB0 - 0x10A68<32> >> 2<8> @ 00000000 : word32)
  Class: Eq_93
  DataType: int32
  OrigDataType: int32
T_94: (in -1<i32> @ 00000764 : int32)
  Class: Eq_94
  DataType: int32
  OrigDataType: int32
T_95: (in (g_dw10AB0 - 0x10A68<32> >> 2<8>) + -1<i32> @ 00000000 : word32)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: int32
T_96: (in r2_40 < r16_42 @ 00000000 : bool)
  Class: Eq_96
  DataType: bool
  OrigDataType: bool
T_97: (in CONVERT(r2_40 <u r16_42, bool, word32) @ 0000076C : word32)
  Class: Eq_97
  DataType: word32
  OrigDataType: word32
T_98: (in 0<32> @ 0000076C : word32)
  Class: Eq_97
  DataType: word32
  OrigDataType: word32
T_99: (in (word32) (r2_40 < r16_42) == 0<32> @ 00000000 : bool)
  Class: Eq_99
  DataType: bool
  OrigDataType: bool
T_100: (in r25_27 @ 00000738 : word32)
  Class: Eq_100
  DataType: word32
  OrigDataType: word32
T_101: (in r3_30 @ 00000738 : word32)
  Class: Eq_101
  DataType: word32
  OrigDataType: word32
T_102: (in __cxa_finalize @ 00000738 : ptr32)
  Class: Eq_102
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_103: (in signature of __cxa_finalize @ 00000000 : void)
  Class: Eq_103
  DataType: Eq_103
  OrigDataType: 
T_104: (in r2_24 @ 00000730 : word32)
  Class: Eq_104
  DataType: word32
  OrigDataType: word32
T_105: (in 0x10AAC<32> @ 00000730 : word32)
  Class: Eq_105
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_106 t0000)))
T_106: (in Mem19[0x10AAC<32>:word32] @ 00000730 : word32)
  Class: Eq_104
  DataType: word32
  OrigDataType: word32
T_107: (in deregister_tm_clones @ 000007A8 : ptr32)
  Class: Eq_107
  DataType: (ptr32 Eq_107)
  OrigDataType: (ptr32 (fn T_109 ()))
T_108: (in signature of deregister_tm_clones @ 00000670 : void)
  Class: Eq_107
  DataType: (ptr32 Eq_107)
  OrigDataType: 
T_109: (in deregister_tm_clones() @ 000007A8 : void)
  Class: Eq_109
  DataType: void
  OrigDataType: void
T_110: (in 1<8> @ 000007B4 : byte)
  Class: Eq_76
  DataType: byte
  OrigDataType: byte
T_111: (in 0x10AF0<32> @ 000007B4 : word32)
  Class: Eq_111
  DataType: (ptr32 byte)
  OrigDataType: (ptr32 (struct (0 T_112 t0000)))
T_112: (in Mem76[0x10AF0<32>:byte] @ 000007B4 : byte)
  Class: Eq_76
  DataType: byte
  OrigDataType: byte
T_113: (in r2_47 @ 00000774 : Eq_84)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: uint32
T_114: (in 1<i32> @ 00000774 : int32)
  Class: Eq_114
  DataType: int32
  OrigDataType: (union (int32 u0) (up32 u1))
T_115: (in r2_40 + 1<i32> @ 00000774 : word32)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: up32
T_116: (in 0x10AF4<32> @ 0000077C : word32)
  Class: Eq_116
  DataType: (ptr32 Eq_84)
  OrigDataType: (ptr32 (struct (0 T_117 t0000)))
T_117: (in Mem50[0x10AF4<32>:word32] @ 0000077C : word32)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: word32
T_118: (in r2_52 @ 00000780 : (ptr32 (ptr32 code)))
  Class: Eq_118
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_126 t0000)))
T_119: (in 2<8> @ 00000780 : byte)
  Class: Eq_119
  DataType: byte
  OrigDataType: byte
T_120: (in r2_47 << 2<8> @ 00000000 : word32)
  Class: Eq_120
  DataType: ui32
  OrigDataType: ui32
T_121: (in 0x10A68<32> @ 00000780 : word32)
  Class: Eq_121
  DataType: word32
  OrigDataType: word32
T_122: (in (r2_47 << 2<8>) + 0x10A68<32> @ 00000000 : word32)
  Class: Eq_118
  DataType: (ptr32 (ptr32 code))
  OrigDataType: ui32
T_123: (in r4_60 @ 00000788 : word32)
  Class: Eq_123
  DataType: word32
  OrigDataType: word32
T_124: (in 0<32> @ 00000788 : word32)
  Class: Eq_124
  DataType: word32
  OrigDataType: word32
T_125: (in r2_52 + 0<32> @ 00000788 : word32)
  Class: Eq_125
  DataType: ui32
  OrigDataType: ui32
T_126: (in Mem50[r2_52 + 0<32>:word32] @ 00000788 : word32)
  Class: Eq_126
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_127: (in 0x10AF4<32> @ 00000790 : word32)
  Class: Eq_127
  DataType: (ptr32 Eq_84)
  OrigDataType: (ptr32 (struct (0 T_128 t0000)))
T_128: (in Mem50[0x10AF4<32>:word32] @ 00000790 : word32)
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: word32
T_129: (in r2_40 < r16_42 @ 00000000 : bool)
  Class: Eq_129
  DataType: bool
  OrigDataType: bool
T_130: (in CONVERT(r2_40 <u r16_42, bool, word32) @ 00000798 : word32)
  Class: Eq_130
  DataType: word32
  OrigDataType: word32
T_131: (in 0<32> @ 00000798 : word32)
  Class: Eq_130
  DataType: word32
  OrigDataType: word32
T_132: (in (word32) (r2_40 < r16_42) != 0<32> @ 00000000 : bool)
  Class: Eq_132
  DataType: bool
  OrigDataType: bool
T_133: (in register_tm_clones @ 000007E8 : ptr32)
  Class: Eq_133
  DataType: (ptr32 Eq_133)
  OrigDataType: (ptr32 (fn T_135 ()))
T_134: (in signature of register_tm_clones @ 000006A8 : void)
  Class: Eq_133
  DataType: (ptr32 Eq_133)
  OrigDataType: 
T_135: (in register_tm_clones() @ 000007E8 : void)
  Class: Eq_135
  DataType: void
  OrigDataType: void
T_136: (in memset @ 00000830 : ptr32)
  Class: Eq_136
  DataType: (ptr32 Eq_136)
  OrigDataType: (ptr32 (fn T_147 (T_143, T_144, T_146)))
T_137: (in signature of memset @ 00000000 : void)
  Class: Eq_136
  DataType: (ptr32 Eq_136)
  OrigDataType: 
T_138: (in r4 @ 00000830 : (ptr32 void))
  Class: Eq_138
  DataType: (ptr32 void)
  OrigDataType: 
T_139: (in value @ 00000830 : int32)
  Class: Eq_139
  DataType: int32
  OrigDataType: 
T_140: (in num @ 00000830 : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: 
T_141: (in fp @ 00000830 : ptr32)
  Class: Eq_141
  DataType: ptr32
  OrigDataType: ptr32
T_142: (in -20<i32> @ 00000830 : int32)
  Class: Eq_142
  DataType: int32
  OrigDataType: int32
T_143: (in fp + -20<i32> @ 00000000 : word32)
  Class: Eq_138
  DataType: (ptr32 void)
  OrigDataType: (ptr32 void)
T_144: (in 0<32> @ 00000830 : word32)
  Class: Eq_139
  DataType: int32
  OrigDataType: int32
T_145: (in 5<i32> @ 00000830 : int32)
  Class: Eq_145
  DataType: int32
  OrigDataType: int32
T_146: (in SLICE(5<i32>, size_t, 0) @ 00000830 : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: size_t
T_147: (in memset(fp + -20<i32>, 0<32>, (size_t) 5<i32>) @ 00000830 : (ptr32 void))
  Class: Eq_147
  DataType: (ptr32 void)
  OrigDataType: (ptr32 void)
T_148: (in r2_38 @ 0000084C : (ptr32 Eq_148))
  Class: Eq_148
  DataType: (ptr32 Eq_148)
  OrigDataType: (ptr32 (struct (0 T_158 t0000) (1 T_173 t0001) (4 T_165 t0004)))
T_149: (in calloc @ 0000084C : ptr32)
  Class: Eq_149
  DataType: ptr32
  OrigDataType: ptr32
T_150: (in signature of calloc @ 00000000 : void)
  Class: Eq_149
  DataType: ptr32
  OrigDataType: 
T_151: (in num @ 0000084C : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: 
T_152: (in size @ 0000084C : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: 
T_153: (in 1<i32> @ 0000084C : int32)
  Class: Eq_153
  DataType: int32
  OrigDataType: int32
T_154: (in SLICE(1<i32>, size_t, 0) @ 0000084C : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: size_t
T_155: (in 5<i32> @ 0000084C : int32)
  Class: Eq_155
  DataType: int32
  OrigDataType: int32
T_156: (in SLICE(5<i32>, size_t, 0) @ 0000084C : size_t)
  Class: Eq_140
  DataType: Eq_140
  OrigDataType: size_t
T_157: (in calloc((size_t) 1<i32>, (size_t) 5<i32>) @ 0000084C : (ptr32 void))
  Class: Eq_148
  DataType: (ptr32 Eq_148)
  OrigDataType: (ptr32 void)
T_158: (in dwLoc14 @ 00000868 : word32)
  Class: Eq_158
  DataType: Eq_158
  OrigDataType: word32
T_159: (in 0<32> @ 00000868 : word32)
  Class: Eq_159
  DataType: word32
  OrigDataType: word32
T_160: (in r2_38 + 0<32> @ 00000868 : word32)
  Class: Eq_160
  DataType: ptr32
  OrigDataType: ptr32
T_161: (in Mem45[r2_38 + 0<32>:word32] @ 00000868 : word32)
  Class: Eq_158
  DataType: Eq_158
  OrigDataType: word32
T_162: (in bLoc10 @ 00000870 : byte)
  Class: Eq_162
  DataType: byte
  OrigDataType: byte
T_163: (in 4<32> @ 00000870 : word32)
  Class: Eq_163
  DataType: word32
  OrigDataType: word32
T_164: (in r2_38 + 4<32> @ 00000870 : word32)
  Class: Eq_164
  DataType: ptr32
  OrigDataType: ptr32
T_165: (in Mem48[r2_38 + 4<32>:byte] @ 00000870 : byte)
  Class: Eq_162
  DataType: byte
  OrigDataType: byte
T_166: (in 0xC<8> @ 0000087C : byte)
  Class: Eq_158
  DataType: byte
  OrigDataType: byte
T_167: (in 0<32> @ 0000087C : word32)
  Class: Eq_167
  DataType: word32
  OrigDataType: word32
T_168: (in r2_38 + 0<32> @ 0000087C : word32)
  Class: Eq_168
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 word32)
T_169: (in Mem51[r2_38 + 0<32>:byte] @ 0000087C : byte)
  Class: Eq_158
  DataType: Eq_158
  OrigDataType: byte
T_170: (in 0<32> @ 00000888 : word32)
  Class: Eq_170
  DataType: word32
  OrigDataType: word32
T_171: (in 1<32> @ 00000888 : word32)
  Class: Eq_171
  DataType: word32
  OrigDataType: word32
T_172: (in r2_38 + 1<32> @ 00000888 : word32)
  Class: Eq_172
  DataType: ptr32
  OrigDataType: ptr32
T_173: (in Mem53[r2_38 + 1<32>:word32] @ 00000888 : word32)
  Class: Eq_170
  DataType: word32
  OrigDataType: word32
T_174: (in r2_43 @ 0000085C : word32)
  Class: Eq_148
  DataType: (ptr32 Eq_148)
  OrigDataType: (ptr32 (struct (0 T_158 t0000) (1 T_173 t0001) (4 T_165 t0004)))
T_175: (in r3_44 @ 00000860 : word32)
  Class: Eq_158
  DataType: Eq_158
  OrigDataType: word32
T_176: (in r2_52 @ 00000880 : word32)
  Class: Eq_148
  DataType: (ptr32 Eq_148)
  OrigDataType: (ptr32 (struct (0 T_158 t0000) (1 T_173 t0001) (4 T_165 t0004)))
T_177: (in r4 @ 000008B4 : word32)
  Class: Eq_177
  DataType: word32
  OrigDataType: word32
T_178: (in r5 @ 000008B4 : word32)
  Class: Eq_178
  DataType: word32
  OrigDataType: word32
T_179: (in r6 @ 000008B4 : word32)
  Class: Eq_179
  DataType: word32
  OrigDataType: word32
T_180: (in _init @ 000008FC : ptr32)
  Class: Eq_180
  DataType: (ptr32 Eq_180)
  OrigDataType: (ptr32 (fn T_182 ()))
T_181: (in signature of _init @ 00000588 : void)
  Class: Eq_180
  DataType: (ptr32 Eq_180)
  OrigDataType: 
T_182: (in _init() @ 000008FC : void)
  Class: Eq_182
  DataType: void
  OrigDataType: void
T_183: (in r16_35 @ 00000908 : (ptr32 (ptr32 code)))
  Class: Eq_183
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct 0004 (0 (ptr32 code) ptr0000)))
T_184: (in 0x10ABC<32> @ 00000908 : word32)
  Class: Eq_184
  DataType: (ptr32 (ptr32 (ptr32 code)))
  OrigDataType: (ptr32 (struct (0 T_185 t0000)))
T_185: (in Mem30[0x10ABC<32>:word32] @ 00000908 : word32)
  Class: Eq_183
  DataType: (ptr32 (ptr32 code))
  OrigDataType: word32
T_186: (in r18_37 @ 00000910 : int32)
  Class: Eq_186
  DataType: int32
  OrigDataType: int32
T_187: (in 0x10ABC<32> @ 00000910 : word32)
  Class: Eq_187
  DataType: (ptr32 (ptr32 (ptr32 code)))
  OrigDataType: (ptr32 (struct (0 T_188 t0000)))
T_188: (in Mem30[0x10ABC<32>:word32] @ 00000910 : word32)
  Class: Eq_183
  DataType: (ptr32 (ptr32 code))
  OrigDataType: word32
T_189: (in g_ptr10ABC - r16_35 @ 00000000 : word32)
  Class: Eq_186
  DataType: int32
  OrigDataType: word32
T_190: (in 2<8> @ 00000918 : byte)
  Class: Eq_190
  DataType: byte
  OrigDataType: byte
T_191: (in r18_37 >> 2<8> @ 00000000 : word32)
  Class: Eq_191
  DataType: int32
  OrigDataType: int32
T_192: (in 0<32> @ 00000918 : word32)
  Class: Eq_191
  DataType: int32
  OrigDataType: word32
T_193: (in r18_37 >> 2<8> == 0<32> @ 00000000 : bool)
  Class: Eq_193
  DataType: bool
  OrigDataType: bool
T_194: (in 0<32> @ 00000930 : word32)
  Class: Eq_194
  DataType: word32
  OrigDataType: word32
T_195: (in r16_35 + 0<32> @ 00000930 : word32)
  Class: Eq_195
  DataType: word32
  OrigDataType: word32
T_196: (in Mem30[r16_35 + 0<32>:word32] @ 00000930 : word32)
  Class: Eq_196
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_197: (in r17_40 @ 00000924 : int32)
  Class: Eq_197
  DataType: int32
  OrigDataType: word32
T_198: (in 1<i32> @ 00000924 : int32)
  Class: Eq_198
  DataType: int32
  OrigDataType: int32
T_199: (in r17_40 + 1<i32> @ 00000000 : word32)
  Class: Eq_197
  DataType: int32
  OrigDataType: word32
T_200: (in r18_37 >> 2<8> @ 00000000 : word32)
  Class: Eq_197
  DataType: int32
  OrigDataType: int32
T_201: (in r18_37 >> 2<8> != r17_40 @ 00000000 : bool)
  Class: Eq_201
  DataType: bool
  OrigDataType: bool
T_202: (in 0<32> @ 0000091C : word32)
  Class: Eq_197
  DataType: int32
  OrigDataType: word32
T_203: (in 4<i32> @ 0000093C : int32)
  Class: Eq_203
  DataType: int32
  OrigDataType: int32
T_204: (in r16_35 + 4<i32> @ 0000093C : word32)
  Class: Eq_183
  DataType: (ptr32 (ptr32 code))
  OrigDataType: ptr32
T_205: (in r25_18 @ 00000998 : (ptr32 code))
  Class: Eq_205
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_206: (in 0x10A60<32> @ 00000998 : word32)
  Class: Eq_206
  DataType: (ptr32 (ptr32 code))
  OrigDataType: (ptr32 (struct (0 T_207 t0000)))
T_207: (in Mem17[0x10A60<32>:word32] @ 00000998 : word32)
  Class: Eq_205
  DataType: (ptr32 code)
  OrigDataType: word32
T_208: (in -1<i32> @ 0000099C : int32)
  Class: Eq_205
  DataType: (ptr32 code)
  OrigDataType: int32
T_209: (in r25_18 == (<anonymous> *) -1<i32> @ 00000000 : bool)
  Class: Eq_209
  DataType: bool
  OrigDataType: bool
T_210: (in r16_21 @ 000009A4 : (ptr32 word32))
  Class: Eq_210
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct 0004 (0 word32 dw0000)))
T_211: (in 0x10A60<32> @ 000009A4 : word32)
  Class: Eq_210
  DataType: (ptr32 word32)
  OrigDataType: word32
T_212: (in -4<i32> @ 000009A8 : int32)
  Class: Eq_212
  DataType: int32
  OrigDataType: int32
T_213: (in r16_21 + -4<i32> @ 000009A8 : word32)
  Class: Eq_210
  DataType: (ptr32 word32)
  OrigDataType: word32
T_214: (in 0<32> @ 000009B0 : word32)
  Class: Eq_214
  DataType: word32
  OrigDataType: word32
T_215: (in r16_21 + 0<32> @ 000009B0 : word32)
  Class: Eq_215
  DataType: word32
  OrigDataType: word32
T_216: (in Mem17[r16_21 + 0<32>:word32] @ 000009B0 : word32)
  Class: Eq_205
  DataType: (ptr32 code)
  OrigDataType: word32
T_217: (in -1<i32> @ 000009B4 : int32)
  Class: Eq_205
  DataType: (ptr32 code)
  OrigDataType: int32
T_218: (in r25_18 != (<anonymous> *) -1<i32> @ 00000000 : bool)
  Class: Eq_218
  DataType: bool
  OrigDataType: bool
T_219: (in r28 @ 000009B4 : (ptr32 Eq_219))
  Class: Eq_219
  DataType: (ptr32 Eq_219)
  OrigDataType: (ptr32 (struct (FFFF8010 T_223 tFFFF8010)))
T_220: (in ra @ 000009B4 : word32)
  Class: Eq_220
  DataType: word32
  OrigDataType: word32
T_221: (in -32752<i32> @ 000009D8 : int32)
  Class: Eq_221
  DataType: int32
  OrigDataType: int32
T_222: (in r28 + -32752<i32> @ 000009D8 : word32)
  Class: Eq_222
  DataType: word32
  OrigDataType: word32
T_223: (in Mem0[r28 + -32752<i32>:word32] @ 000009D8 : word32)
  Class: Eq_223
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_224: (in r28 @ 000009D8 : (ptr32 Eq_224))
  Class: Eq_224
  DataType: (ptr32 Eq_224)
  OrigDataType: (ptr32 (struct (FFFF8010 T_228 tFFFF8010)))
T_225: (in ra @ 000009D8 : word32)
  Class: Eq_225
  DataType: word32
  OrigDataType: word32
T_226: (in -32752<i32> @ 000009E8 : int32)
  Class: Eq_226
  DataType: int32
  OrigDataType: int32
T_227: (in r28 + -32752<i32> @ 000009E8 : word32)
  Class: Eq_227
  DataType: word32
  OrigDataType: word32
T_228: (in Mem0[r28 + -32752<i32>:word32] @ 000009E8 : word32)
  Class: Eq_228
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_229: (in r28 @ 000009E8 : (ptr32 Eq_229))
  Class: Eq_229
  DataType: (ptr32 Eq_229)
  OrigDataType: (ptr32 (struct (FFFF8010 T_233 tFFFF8010)))
T_230: (in ra @ 000009E8 : word32)
  Class: Eq_230
  DataType: word32
  OrigDataType: word32
T_231: (in -32752<i32> @ 000009F8 : int32)
  Class: Eq_231
  DataType: int32
  OrigDataType: int32
T_232: (in r28 + -32752<i32> @ 000009F8 : word32)
  Class: Eq_232
  DataType: word32
  OrigDataType: word32
T_233: (in Mem0[r28 + -32752<i32>:word32] @ 000009F8 : word32)
  Class: Eq_233
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_234: (in _fini @ 00000A0C : ptr32)
  Class: Eq_234
  DataType: (ptr32 Eq_234)
  OrigDataType: (ptr32 (fn T_236 ()))
T_235: (in signature of _fini @ 00000A10 : void)
  Class: Eq_234
  DataType: (ptr32 Eq_234)
  OrigDataType: 
T_236: (in _fini() @ 00000A0C : void)
  Class: Eq_236
  DataType: void
  OrigDataType: void
T_237: (in r25_15 @ 00000A3C : ptr32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: ptr32
T_238: (in 00020A4C @ 00000A3C : ptr32)
  Class: Eq_238
  DataType: (ptr32 ptr32)
  OrigDataType: (ptr32 (struct (0 T_239 t0000)))
T_239: (in Mem10[0x00020A4C<p32>:word32] @ 00000A3C : word32)
  Class: Eq_6
  DataType: ptr32
  OrigDataType: word32
T_240: (in 1780<i32> @ 00000A44 : int32)
  Class: Eq_240
  DataType: int32
  OrigDataType: int32
T_241: (in r25_15 + 1780<i32> @ 00000000 : word32)
  Class: Eq_241
  DataType: (ptr32 code)
  OrigDataType: (ptr32 code)
T_242:
  Class: Eq_242
  DataType: word32
  OrigDataType: word32
T_243:
  Class: Eq_84
  DataType: Eq_84
  OrigDataType: word32
*/
typedef struct Globals {
	<anonymous> tFFFFFFFF;	// FFFFFFFF
	<anonymous> t0000;	// 0
	word32 _IO_stdin_used;	// A58
	<anonymous> * ptr10A60;	// 10A60
	<anonymous> * main_GOT;	// 10A98
	<anonymous> * __libc_csu_init_GOT;	// 10A9C
	<anonymous> * __libc_csu_fini_GOT;	// 10AA0
	int32 dw10AA4;	// 10AA4
	word32 dw10AAC;	// 10AAC
	int32 dw10AB0;	// 10AB0
	<anonymous> * _init_GOT;	// 10AB8
	<anonymous> ** ptr10ABC;	// 10ABC
	<anonymous> * calloc_GOT;	// 10AD0
	<anonymous> * ptr10AD4;	// 10AD4
	<anonymous> * memset_GOT;	// 10AD8
	<anonymous> * __libc_start_main_GOT;	// 10ADC
	<anonymous> * __gmon_start___GOT;	// 10AE0
	<anonymous> * ptr10AE4;	// 10AE4
	<anonymous> * __cxa_finalize_GOT;	// 10AE8
	byte b10AF0;	// 10AF0
	Eq_84 dtor_idx.6258;	// 10AF4
	<anonymous> * ptr20A24;	// 20A24
	ptr32 ptr20A4C;	// 20A4C
	word32 dw20A60;	// 20A60
	word32 dw20A64;	// 20A64
	word32 dw20A68;	// 20A68
} Eq_1;

typedef struct Eq_24 {
	word32 dw0010;	// 10
	word32 dw0014;	// 14
	struct Eq_24 * ptr0018;	// 18
} Eq_24;

typedef union Eq_25 {
	ui32 u0;
	ptr32 u1;
} Eq_25;

typedef union Eq_56 {
	int32 u0;
	uint32 u1;
} Eq_56;

typedef union Eq_64 {
	int32 u0;
	uint32 u1;
} Eq_64;

typedef union Eq_65 {
	int32 u0;
	uint32 u1;
} Eq_65;

typedef union Eq_84 {
	int32 u0;
	uint32 u1;
} Eq_84;

typedef void (Eq_107)();

typedef union Eq_114 {
	int32 u0;
	up32 u1;
} Eq_114;

typedef void (Eq_133)();

typedef void (Eq_136)(void, int32, size_t);

typedef size_t Eq_140;

typedef struct Eq_148 {
	Eq_158 t0000;	// 0
	word32 dw0001;	// 1
	byte b0004;	// 4
} Eq_148;

typedef union Eq_158 {
	byte u0;
	word32 u1;
} Eq_158;

typedef void (Eq_180)();

typedef struct Eq_219 {
	<anonymous> * ptrFFFF8010;	// FFFF8010
} Eq_219;

typedef struct Eq_224 {
	<anonymous> * ptrFFFF8010;	// FFFF8010
} Eq_224;

typedef struct Eq_229 {
	<anonymous> * ptrFFFF8010;	// FFFF8010
} Eq_229;

typedef void (Eq_234)();

