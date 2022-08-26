// PIC18EggExtd.h
// Generated by decompiling PIC18EggExtd.hex
// using Reko decompiler version 0.11.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals"
		(1 byte b0001)
		(C0 cu8 b00C0)
		(C1 cu8 b00C1)
		(C2 cu8 b00C2)
		(C3 cu8 b00C3)
		(C4 cu8 b00C4)
		(C5 cu8 b00C5)
		(C6 cu8 b00C6)
		(C7 byte b00C7)
		(C8 byte b00C8)
		(C9 byte b00C9)
		(CA byte b00CA))
	globals_t (in globals : (ptr32 (struct "Globals")))
Eq_7: (fn void (cu8, Eq_10, word24))
	T_7 (in fn00000E @ 000144 : ptr32)
	T_8 (in signature of fn00000E @ 00000E : void)
Eq_10: (union "Eq_10" (word16 u0) ((ptr32 byte) u1))
	T_10 (in FSR0 @ 000144 : Eq_10)
	T_12 (in 0<16> @ 000144 : word16)
	T_115 (in FSR0 + 1<16> @ 00008A : word16)
Eq_15: (fn void (word24, byte))
	T_15 (in __tblrd @ 00001C : ptr32)
	T_16 (in signature of __tblrd : void)
	T_23 (in __tblrd @ 000022 : ptr32)
	T_37 (in __tblrd @ 000030 : ptr32)
	T_42 (in __tblrd @ 000036 : ptr32)
	T_47 (in __tblrd @ 00003C : ptr32)
	T_52 (in __tblrd @ 000042 : ptr32)
	T_55 (in __tblrd @ 000044 : ptr32)
	T_58 (in __tblrd @ 00004A : ptr32)
	T_61 (in __tblrd @ 000050 : ptr32)
	T_64 (in __tblrd @ 000052 : ptr32)
	T_67 (in __tblrd @ 000054 : ptr32)
	T_72 (in __tblrd @ 00005A : ptr32)
	T_77 (in __tblrd @ 000060 : ptr32)
	T_80 (in __tblrd @ 000062 : ptr32)
	T_102 (in __tblrd @ 000086 : ptr32)
Eq_149: (union "Eq_149" (bool u0) (byte u1))
	T_149 (in !(bool) cond(g_b00C5) @ 0000A6 : bool)
Eq_165: (struct "Eq_165" (FFFFFFFE byte bFFFFFFFE))
	T_165 (in FSR2 @ 0000AA : (ptr16 Eq_165))
Eq_199: (union "Eq_199" (word16 u0) ((ptr32 byte) u1))
	T_199 (in FSR0 @ 0000EC : Eq_199)
	T_206 (in FSR0 + 1<16> @ 00012C : word16)
	T_212 (in FSR0 + 1<16> @ 000136 : word16)
Eq_205: (union "Eq_205" (word16 u0) ((ptr32 byte) u1))
	T_205 (in 1<16> @ 00012C : word16)
Eq_209: (union "Eq_209" (word16 u0) ((ptr32 byte) u1))
	T_209 (in FSR0 + 0<16> @ 000136 : word16)
Eq_211: (union "Eq_211" (word16 u0) ((ptr32 byte) u1))
	T_211 (in 1<16> @ 000136 : word16)
Eq_214: (struct "Eq_214" 0001 (0 ptr32 ptr0000))
	T_214
// Type Variables ////////////
globals_t: (in globals : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in TABLAT : cu8)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_3: (in 000148 @ 000144 : ptr32)
  Class: Eq_3
  DataType: ptr32
  OrigDataType: ptr32
T_4: (in Stack @ 000144 : (arr Eq_214))
  Class: Eq_4
  DataType: (ptr32 (arr Eq_214))
  OrigDataType: (ptr32 (struct (0 (arr T_214) a0000)))
T_5: (in 1<8> @ 000144 : byte)
  Class: Eq_5
  DataType: byte
  OrigDataType: byte
T_6: (in Stack[1<8>] @ 000144 : ptr32)
  Class: Eq_3
  DataType: ptr32
  OrigDataType: ptr32
T_7: (in fn00000E @ 000144 : ptr32)
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: (ptr32 (fn T_14 (T_2, T_12, T_13)))
T_8: (in signature of fn00000E @ 00000E : void)
  Class: Eq_7
  DataType: (ptr32 Eq_7)
  OrigDataType: 
T_9: (in TABLAT @ 000144 : cu8)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_10: (in FSR0 @ 000144 : Eq_10)
  Class: Eq_10
  DataType: Eq_10
  OrigDataType: (union ((ptr32 (struct 0001 (0 byte b0000))) u0) ((ptr32 byte) u1))
T_11: (in TBLPTR @ 000144 : word24)
  Class: Eq_11
  DataType: word24
  OrigDataType: word24
T_12: (in 0<16> @ 000144 : word16)
  Class: Eq_10
  DataType: word16
  OrigDataType: word16
T_13: (in 0<24> @ 000144 : word24)
  Class: Eq_11
  DataType: word24
  OrigDataType: word24
T_14: (in fn00000E(TABLAT, 0<16>, 0<24>) @ 000144 : void)
  Class: Eq_14
  DataType: void
  OrigDataType: void
T_15: (in __tblrd @ 00001C : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_20 (T_11, T_19)))
T_16: (in signature of __tblrd : void)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: 
T_17: (in  @ 00001C : word24)
  Class: Eq_11
  DataType: word24
  OrigDataType: 
T_18: (in  @ 00001C : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: 
T_19: (in 1<8> @ 00001C : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_20: (in __tblrd(TBLPTR, 1<8>) @ 00001C : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_21: (in 00C5 @ 000020 : ptr16)
  Class: Eq_21
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_22 t0000)))
T_22: (in Data13[0x00C5<p16>:byte] @ 000020 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_23: (in __tblrd @ 000022 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_25 (T_11, T_24)))
T_24: (in 1<8> @ 000022 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_25: (in __tblrd(TBLPTR, 1<8>) @ 000022 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_26: (in 00C6 @ 000026 : ptr16)
  Class: Eq_26
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_27 t0000)))
T_27: (in Data16[0x00C6<p16>:byte] @ 000026 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_28: (in TBLPTRL_4 @ 000010 : byte)
  Class: Eq_28
  DataType: byte
  OrigDataType: byte
T_29: (in 6<8> @ 000010 : byte)
  Class: Eq_28
  DataType: byte
  OrigDataType: byte
T_30: (in TBLPTRH_46 @ 000014 : byte)
  Class: Eq_30
  DataType: byte
  OrigDataType: byte
T_31: (in 0<8> @ 000014 : byte)
  Class: Eq_30
  DataType: byte
  OrigDataType: byte
T_32: (in TBLPTRU_49 @ 000018 : byte)
  Class: Eq_32
  DataType: byte
  OrigDataType: byte
T_33: (in 0<8> @ 000018 : byte)
  Class: Eq_32
  DataType: byte
  OrigDataType: byte
T_34: (in v20_98 @ 000024 : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_35: (in 0<8> @ 000024 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_36: (in TABLAT != 0<8> @ 000024 : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_37: (in __tblrd @ 000030 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_39 (T_11, T_38)))
T_38: (in 1<8> @ 000030 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_39: (in __tblrd(TBLPTR, 1<8>) @ 000030 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_40: (in 00C0 @ 000034 : ptr16)
  Class: Eq_40
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_41 t0000)))
T_41: (in Data29[0x00C0<p16>:byte] @ 000034 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_42: (in __tblrd @ 000036 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_44 (T_11, T_43)))
T_43: (in 1<8> @ 000036 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_44: (in __tblrd(TBLPTR, 1<8>) @ 000036 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_45: (in 00C1 @ 00003A : ptr16)
  Class: Eq_45
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_46 t0000)))
T_46: (in Data31[0x00C1<p16>:byte] @ 00003A : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_47: (in __tblrd @ 00003C : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_49 (T_11, T_48)))
T_48: (in 1<8> @ 00003C : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_49: (in __tblrd(TBLPTR, 1<8>) @ 00003C : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_50: (in 00C2 @ 000040 : ptr16)
  Class: Eq_50
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_51 t0000)))
T_51: (in Data33[0x00C2<p16>:byte] @ 000040 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_52: (in __tblrd @ 000042 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_54 (T_11, T_53)))
T_53: (in 1<8> @ 000042 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_54: (in __tblrd(TBLPTR, 1<8>) @ 000042 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_55: (in __tblrd @ 000044 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_57 (T_11, T_56)))
T_56: (in 1<8> @ 000044 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_57: (in __tblrd(TBLPTR, 1<8>) @ 000044 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_58: (in __tblrd @ 00004A : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_60 (T_11, T_59)))
T_59: (in 1<8> @ 00004A : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_60: (in __tblrd(TBLPTR, 1<8>) @ 00004A : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_61: (in __tblrd @ 000050 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_63 (T_11, T_62)))
T_62: (in 1<8> @ 000050 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_63: (in __tblrd(TBLPTR, 1<8>) @ 000050 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_64: (in __tblrd @ 000052 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_66 (T_11, T_65)))
T_65: (in 1<8> @ 000052 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_66: (in __tblrd(TBLPTR, 1<8>) @ 000052 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_67: (in __tblrd @ 000054 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_69 (T_11, T_68)))
T_68: (in 1<8> @ 000054 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_69: (in __tblrd(TBLPTR, 1<8>) @ 000054 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_70: (in 00C3 @ 000058 : ptr16)
  Class: Eq_70
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_71 t0000)))
T_71: (in Data39[0x00C3<p16>:byte] @ 000058 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_72: (in __tblrd @ 00005A : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_74 (T_11, T_73)))
T_73: (in 1<8> @ 00005A : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_74: (in __tblrd(TBLPTR, 1<8>) @ 00005A : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_75: (in 00C4 @ 00005E : ptr16)
  Class: Eq_75
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_76 t0000)))
T_76: (in Data41[0x00C4<p16>:byte] @ 00005E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_77: (in __tblrd @ 000060 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_79 (T_11, T_78)))
T_78: (in 1<8> @ 000060 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_79: (in __tblrd(TBLPTR, 1<8>) @ 000060 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_80: (in __tblrd @ 000062 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_82 (T_11, T_81)))
T_81: (in 1<8> @ 000062 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_82: (in __tblrd(TBLPTR, 1<8>) @ 000062 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_83: (in 00C7 @ 000064 : ptr16)
  Class: Eq_83
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_84 t0000)))
T_84: (in Data44[0x00C7<p16>:byte] @ 000064 : byte)
  Class: Eq_28
  DataType: byte
  OrigDataType: byte
T_85: (in 00C8 @ 000068 : ptr16)
  Class: Eq_85
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_86 t0000)))
T_86: (in Data47[0x00C8<p16>:byte] @ 000068 : byte)
  Class: Eq_30
  DataType: byte
  OrigDataType: byte
T_87: (in 00C9 @ 00006C : ptr16)
  Class: Eq_87
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_88 t0000)))
T_88: (in Data50[0x00C9<p16>:byte] @ 00006C : byte)
  Class: Eq_32
  DataType: byte
  OrigDataType: byte
T_89: (in 00C3 @ 00007E : ptr16)
  Class: Eq_89
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_90 t0000)))
T_90: (in Data50[0x00C3<p16>:byte] @ 00007E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_91: (in 00C3 @ 00007E : ptr16)
  Class: Eq_91
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_92 t0000)))
T_92: (in Data55[0x00C3<p16>:byte] @ 00007E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_93: (in v23_101 @ 00007E : bool)
  Class: Eq_93
  DataType: bool
  OrigDataType: bool
T_94: (in 00C3 @ 00007E : ptr16)
  Class: Eq_94
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_95 t0000)))
T_95: (in Data55[0x00C3<p16>:byte] @ 00007E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_96: (in 0<8> @ 00007E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_97: (in g_b00C3 != 0<8> @ 00007E : bool)
  Class: Eq_93
  DataType: bool
  OrigDataType: bool
T_98: (in 00C5 @ 00002A : ptr16)
  Class: Eq_98
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_99 t0000)))
T_99: (in Data19[0x00C5<p16>:byte] @ 00002A : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_100: (in 0<8> @ 00002A : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_101: (in g_b00C5 == 0<8> @ 00002A : bool)
  Class: Eq_101
  DataType: bool
  OrigDataType: bool
T_102: (in __tblrd @ 000086 : ptr32)
  Class: Eq_15
  DataType: (ptr32 Eq_15)
  OrigDataType: (ptr32 (fn T_104 (T_11, T_103)))
T_103: (in 1<8> @ 000086 : byte)
  Class: Eq_18
  DataType: byte
  OrigDataType: byte
T_104: (in __tblrd(TBLPTR, 1<8>) @ 000086 : void)
  Class: Eq_20
  DataType: void
  OrigDataType: void
T_105: (in 0<16> @ 00008A : word16)
  Class: Eq_105
  DataType: word16
  OrigDataType: word16
T_106: (in FSR0 + 0<16> @ 00008A : word16)
  Class: Eq_106
  DataType: word16
  OrigDataType: word16
T_107: (in Data77[FSR0 + 0<16>:byte] @ 00008A : byte)
  Class: Eq_2
  DataType: Eq_10
  OrigDataType: cu8
T_108: (in 00C3 @ 00008C : ptr16)
  Class: Eq_108
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_109 t0000)))
T_109: (in Data77[0x00C3<p16>:byte] @ 00008C : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_110: (in 1<8> @ 00008C : byte)
  Class: Eq_110
  DataType: byte
  OrigDataType: byte
T_111: (in g_b00C3 - 1<8> @ 00008C : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_112: (in 00C3 @ 00008C : ptr16)
  Class: Eq_112
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_113 t0000)))
T_113: (in Data80[0x00C3<p16>:byte] @ 00008C : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_114: (in 1<16> @ 00008A : word16)
  Class: Eq_114
  DataType: (ptr32 byte)
  OrigDataType: (union ((ptr32 (struct 0001 (0 byte b0000))) u0) ((ptr32 byte) u1))
T_115: (in FSR0 + 1<16> @ 00008A : word16)
  Class: Eq_10
  DataType: Eq_10
  OrigDataType: (union ((ptr32 (struct 0001 (0 byte b0000))) u0) ((ptr32 byte) u1))
T_116: (in 00C3 @ 00008C : ptr16)
  Class: Eq_116
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_2 t0000)))
T_117: (in Data80[0x00C3<p16>:byte] @ 00008C : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_118: (in 0<8> @ 00008C : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_119: (in g_b00C3 != 0<8> @ 00008C : bool)
  Class: Eq_93
  DataType: bool
  OrigDataType: bool
T_120: (in Data80[0x00C3<p16>:byte] @ 00008E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: cu8
T_121: (in 0<8> @ 00008E : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: cu8
T_122: (in g_b00C3 < 0<8> @ 00008E : bool)
  Class: Eq_122
  DataType: bool
  OrigDataType: bool
T_123: (in 00C4 @ 000082 : ptr16)
  Class: Eq_123
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_124 t0000)))
T_124: (in Data59[0x00C4<p16>:byte] @ 000082 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_125: (in 00C4 @ 000082 : ptr16)
  Class: Eq_125
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_126 t0000)))
T_126: (in Data60[0x00C4<p16>:byte] @ 000082 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_127: (in 00C4 @ 000084 : ptr16)
  Class: Eq_127
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_128 t0000)))
T_128: (in Data60[0x00C4<p16>:byte] @ 000084 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_129: (in 0<8> @ 000084 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_130: (in g_b00C4 == 0<8> @ 000084 : bool)
  Class: Eq_130
  DataType: bool
  OrigDataType: bool
T_131: (in 00C7 @ 000094 : ptr16)
  Class: Eq_131
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_132 t0000)))
T_132: (in Data60[0x00C7<p16>:byte] @ 000094 : byte)
  Class: Eq_28
  DataType: byte
  OrigDataType: byte
T_133: (in 00C8 @ 000098 : ptr16)
  Class: Eq_133
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_134 t0000)))
T_134: (in Data60[0x00C8<p16>:byte] @ 000098 : byte)
  Class: Eq_30
  DataType: byte
  OrigDataType: byte
T_135: (in 00C9 @ 00009C : ptr16)
  Class: Eq_135
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_136 t0000)))
T_136: (in Data60[0x00C9<p16>:byte] @ 00009C : byte)
  Class: Eq_32
  DataType: byte
  OrigDataType: byte
T_137: (in 00C5 @ 0000A2 : ptr16)
  Class: Eq_137
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_138 t0000)))
T_138: (in Data60[0x00C5<p16>:byte] @ 0000A2 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_139: (in 1<8> @ 0000A2 : byte)
  Class: Eq_139
  DataType: byte
  OrigDataType: byte
T_140: (in g_b00C5 - 1<8> @ 0000A2 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_141: (in 00C5 @ 0000A2 : ptr16)
  Class: Eq_141
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_142 t0000)))
T_142: (in Data67[0x00C5<p16>:byte] @ 0000A2 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_143: (in 00C6 @ 0000A6 : ptr16)
  Class: Eq_143
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_144 t0000)))
T_144: (in Data67[0x00C6<p16>:byte] @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_145: (in 00C5 @ 0000A6 : ptr16)
  Class: Eq_145
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_146 t0000)))
T_146: (in Data67[0x00C5<p16>:byte] @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_147: (in cond(Data67[0x00C5<p16>:byte]) @ 0000A6 : byte)
  Class: Eq_147
  DataType: byte
  OrigDataType: byte
T_148: (in SLICE(cond(Data67[0x00C5<p16>:byte]), bool, 0) @ 0000A6 : bool)
  Class: Eq_148
  DataType: bool
  OrigDataType: bool
T_149: (in !(bool) cond(g_b00C5) @ 0000A6 : bool)
  Class: Eq_149
  DataType: Eq_149
  OrigDataType: (union (bool u0) (byte u1))
T_150: (in g_b00C6 - !((bool) cond(g_b00C5)) @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_151: (in 00C6 @ 0000A6 : ptr16)
  Class: Eq_151
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_152 t0000)))
T_152: (in Data71[0x00C6<p16>:byte] @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_153: (in 00C6 @ 0000A6 : ptr16)
  Class: Eq_153
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_154 t0000)))
T_154: (in Data71[0x00C6<p16>:byte] @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_155: (in 0<8> @ 0000A6 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_156: (in g_b00C6 != 0<8> @ 0000A6 : bool)
  Class: Eq_34
  DataType: bool
  OrigDataType: bool
T_157: (in 00C4 @ 000090 : ptr16)
  Class: Eq_157
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_158 t0000)))
T_158: (in Data80[0x00C4<p16>:byte] @ 000090 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_159: (in 1<8> @ 000090 : byte)
  Class: Eq_159
  DataType: byte
  OrigDataType: byte
T_160: (in g_b00C4 - 1<8> @ 000090 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_161: (in 00C4 @ 000090 : ptr16)
  Class: Eq_161
  DataType: (ptr16 cu8)
  OrigDataType: (ptr16 (struct (0 T_162 t0000)))
T_162: (in Data83[0x00C4<p16>:byte] @ 000090 : byte)
  Class: Eq_2
  DataType: cu8
  OrigDataType: byte
T_163: (in LATB @ 0000AA : byte)
  Class: Eq_163
  DataType: byte
  OrigDataType: byte
T_164: (in FSR2L @ 0000AA : byte)
  Class: Eq_164
  DataType: byte
  OrigDataType: byte
T_165: (in FSR2 @ 0000AA : (ptr16 Eq_165))
  Class: Eq_165
  DataType: (ptr16 Eq_165)
  OrigDataType: (ptr16 (struct (FFFFFFFE T_188 tFFFFFFFE)))
T_166: (in FSR1 @ 0000AA : (ptr16 byte))
  Class: Eq_166
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_169 t0000)))
T_167: (in 0<16> @ 0000D0 : word16)
  Class: Eq_167
  DataType: word16
  OrigDataType: word16
T_168: (in FSR1 + 0<16> @ 0000D0 : word16)
  Class: Eq_168
  DataType: word16
  OrigDataType: word16
T_169: (in Data5[FSR1 + 0<16>:byte] @ 0000D0 : byte)
  Class: Eq_164
  DataType: byte
  OrigDataType: byte
T_170: (in 00CA @ 0000E0 : ptr16)
  Class: Eq_170
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_171 t0000)))
T_171: (in Data12[0x00CA<p16>:byte] @ 0000E0 : byte)
  Class: Eq_171
  DataType: byte
  OrigDataType: byte
T_172: (in 1<8> @ 0000E0 : byte)
  Class: Eq_172
  DataType: byte
  OrigDataType: byte
T_173: (in g_b00CA & 1<8> @ 0000E0 : byte)
  Class: Eq_173
  DataType: byte
  OrigDataType: byte
T_174: (in 0<8> @ 0000E0 : byte)
  Class: Eq_173
  DataType: byte
  OrigDataType: byte
T_175: (in (g_b00CA & 1<8>) != 0<8> @ 0000E0 : bool)
  Class: Eq_175
  DataType: bool
  OrigDataType: bool
T_176: (in 00CA @ 0000E4 : ptr16)
  Class: Eq_176
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_177 t0000)))
T_177: (in Data12[0x00CA<p16>:byte] @ 0000E4 : byte)
  Class: Eq_171
  DataType: byte
  OrigDataType: byte
T_178: (in 0xFE<8> @ 0000E4 : byte)
  Class: Eq_178
  DataType: byte
  OrigDataType: byte
T_179: (in g_b00CA & 0xFE<8> @ 0000E4 : byte)
  Class: Eq_171
  DataType: byte
  OrigDataType: byte
T_180: (in 00CA @ 0000E4 : ptr16)
  Class: Eq_180
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct (0 T_181 t0000)))
T_181: (in Data23[0x00CA<p16>:byte] @ 0000E4 : byte)
  Class: Eq_171
  DataType: byte
  OrigDataType: byte
T_182: (in 1<8> @ 0000EA : byte)
  Class: Eq_182
  DataType: byte
  OrigDataType: byte
T_183: (in LATB & 1<8> @ 0000EA : byte)
  Class: Eq_183
  DataType: byte
  OrigDataType: byte
T_184: (in 0<8> @ 0000EA : byte)
  Class: Eq_183
  DataType: byte
  OrigDataType: byte
T_185: (in (LATB & 1<8>) == 0<8> @ 0000EA : bool)
  Class: Eq_185
  DataType: bool
  OrigDataType: bool
T_186: (in -2<i8> @ 0000DC : int8)
  Class: Eq_186
  DataType: int8
  OrigDataType: int8
T_187: (in FSR2 + -2<i8> @ 0000DC : word16)
  Class: Eq_187
  DataType: word16
  OrigDataType: word16
T_188: (in Data12[FSR2 + -2<i8>:byte] @ 0000DC : byte)
  Class: Eq_188
  DataType: byte
  OrigDataType: byte
T_189: (in 0<8> @ 0000DC : byte)
  Class: Eq_188
  DataType: byte
  OrigDataType: byte
T_190: (in FSR2->bFFFFFFFE == 0<8> @ 0000DC : bool)
  Class: Eq_190
  DataType: bool
  OrigDataType: bool
T_191: (in 0x7F<8> @ 0000F0 : byte)
  Class: Eq_191
  DataType: byte
  OrigDataType: byte
T_192: (in LATB & 0x7F<8> @ 0000F0 : byte)
  Class: Eq_163
  DataType: byte
  OrigDataType: byte
T_193: (in 0x80<8> @ 0000EC : byte)
  Class: Eq_193
  DataType: byte
  OrigDataType: byte
T_194: (in LATB | 0x80<8> @ 0000EC : byte)
  Class: Eq_163
  DataType: byte
  OrigDataType: byte
T_195: (in WREG @ 0000EC : cu8)
  Class: Eq_195
  DataType: cu8
  OrigDataType: cu8
T_196: (in FSR0L @ 0000EC : cu8)
  Class: Eq_196
  DataType: cu8
  OrigDataType: cu8
T_197: (in FSR0H @ 0000EC : cu8)
  Class: Eq_195
  DataType: cu8
  OrigDataType: cu8
T_198: (in PRODL @ 0000EC : cu8)
  Class: Eq_196
  DataType: cu8
  OrigDataType: cu8
T_199: (in FSR0 @ 0000EC : Eq_199)
  Class: Eq_199
  DataType: Eq_199
  OrigDataType: word32
T_200: (in FSR0H < WREG @ 000128 : bool)
  Class: Eq_200
  DataType: bool
  OrigDataType: bool
T_201: (in 0<8> @ 00012C : byte)
  Class: Eq_201
  DataType: byte
  OrigDataType: byte
T_202: (in 0<16> @ 00012C : word16)
  Class: Eq_202
  DataType: word16
  OrigDataType: word16
T_203: (in FSR0 + 0<16> @ 00012C : word16)
  Class: Eq_203
  DataType: word16
  OrigDataType: word16
T_204: (in Data6[FSR0 + 0<16>:byte] @ 00012C : byte)
  Class: Eq_201
  DataType: Eq_199
  OrigDataType: byte
T_205: (in 1<16> @ 00012C : word16)
  Class: Eq_205
  DataType: word16
  OrigDataType: (union (word16 u2) ((ptr32 byte) u1))
T_206: (in FSR0 + 1<16> @ 00012C : word16)
  Class: Eq_199
  DataType: Eq_199
  OrigDataType: (union (word16 u2) ((ptr32 byte) u1))
T_207: (in 0<8> @ 000136 : byte)
  Class: Eq_207
  DataType: byte
  OrigDataType: byte
T_208: (in 0<16> @ 000136 : word16)
  Class: Eq_208
  DataType: word16
  OrigDataType: word16
T_209: (in FSR0 + 0<16> @ 000136 : word16)
  Class: Eq_209
  DataType: Eq_209
  OrigDataType: (union (word16 u2) ((ptr32 byte) u1))
T_210: (in Data16[FSR0 + 0<16>:byte] @ 000136 : byte)
  Class: Eq_207
  DataType: Eq_199
  OrigDataType: byte
T_211: (in 1<16> @ 000136 : word16)
  Class: Eq_211
  DataType: word16
  OrigDataType: (union (word16 u2) ((ptr32 byte) u1))
T_212: (in FSR0 + 1<16> @ 000136 : word16)
  Class: Eq_199
  DataType: Eq_199
  OrigDataType: (union (word16 u2) ((ptr32 byte) u1))
T_213: (in FSR0L < PRODL @ 000132 : bool)
  Class: Eq_213
  DataType: bool
  OrigDataType: bool
T_214:
  Class: Eq_214
  DataType: Eq_214
  OrigDataType: (struct 0001 (0 T_6 t0000))
T_215:
  Class: Eq_215
  DataType: (arr Eq_214)
  OrigDataType: (arr T_214)
*/
typedef struct Globals {
	byte b0001;	// 1
	cu8 b00C0;	// C0
	cu8 b00C1;	// C1
	cu8 b00C2;	// C2
	cu8 b00C3;	// C3
	cu8 b00C4;	// C4
	cu8 b00C5;	// C5
	cu8 b00C6;	// C6
	byte b00C7;	// C7
	byte b00C8;	// C8
	byte b00C9;	// C9
	byte b00CA;	// CA
} Eq_1;

typedef void (Eq_7)(cu8, Eq_10, word24);

typedef union Eq_10 {
	word16 u0;
	byte * u1;
} Eq_10;

typedef void (Eq_15)(word24, byte);

typedef union Eq_149 {
	bool u0;
	byte u1;
} Eq_149;

typedef struct Eq_165 {
	byte bFFFFFFFE;	// FFFFFFFE
} Eq_165;

typedef union Eq_199 {
	word16 u0;
	byte * u1;
} Eq_199;

typedef union Eq_205 {
	word16 u0;
	byte * u1;
} Eq_205;

typedef union Eq_209 {
	word16 u0;
	byte * u1;
} Eq_209;

typedef union Eq_211 {
	word16 u0;
	byte * u1;
} Eq_211;

typedef struct Eq_214 {	// size: 1 1
	ptr32 ptr0000;	// 0
} Eq_214;

