// Rmm68jx.h
// Generated by decompiling Rmm68jx.bin
// using Reko decompiler version 0.10.0.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (13E byte b013E) (FBFE word16 wFBFE) (FEB0 ptr16 ptrFEB0) (FF12 word16 wFF12))
	globals_t (in globals @ 00000000 : (ptr16 (struct "Globals")))
Eq_2: (struct "Eq_2" (FFFFFFFA word16 wFFFFFFFA) (FFFFFFFC word16 wFFFFFFFC) (FFFFFFFE word16 wFFFFFFFE))
	T_2 (in SP @ 00000000 : (ptr16 Eq_2))
Eq_21: (fn void ())
	T_21 (in __disable_watchdog_timer @ 00000062 : ptr16)
	T_22 (in signature of __disable_watchdog_timer @ 00000000 : void)
Eq_24: (fn void ())
	T_24 (in __end_of_initialization @ 00000066 : ptr16)
	T_25 (in signature of __end_of_initialization @ 00000000 : void)
Eq_33: (fn word16 (word16))
	T_33 (in fn011C @ 00000098 : ptr16)
	T_34 (in signature of fn011C @ 0000011C : void)
	T_45 (in fn011C @ 0000008E : ptr16)
	T_46 (in fn011C @ 0000008E : ptr16)
	T_62 (in fn011C @ 00000072 : ptr16)
	T_69 (in fn011C @ 000000A2 : ptr16)
	T_74 (in fn011C @ 000000E6 : ptr16)
	T_75 (in fn011C @ 000000E6 : ptr16)
	T_76 (in fn011C @ 000000E6 : ptr16)
	T_77 (in fn011C @ 000000E6 : ptr16)
	T_92 (in fn011C @ 000000BC : ptr16)
	T_93 (in fn011C @ 000000BC : ptr16)
	T_94 (in fn011C @ 000000BC : ptr16)
	T_103 (in fn011C @ 000000C0 : ptr16)
	T_116 (in fn011C @ 000000CC : ptr16)
Eq_56: (fn void ((ptr16 byte), word16))
	T_56 (in fn0128 @ 0000006E : ptr16)
	T_57 (in signature of fn0128 @ 00000128 : void)
Eq_82: (fn word16 (word16))
	T_82 (in fn0110 @ 000000EE : ptr16)
	T_83 (in signature of fn0110 @ 00000110 : void)
	T_118 (in fn0110 @ 000000D4 : ptr16)
	T_148 (in fn0110 @ 00000132 : ptr16)
Eq_109: (union "Eq_109" (int16 u0) (byte u1))
	T_109 (in 1<8> @ 000000C6 : byte)
Eq_123: (fn bool (word16, int16))
	T_123 (in __bit @ 00000114 : ptr16)
	T_124 (in signature of __bit @ 00000000 : void)
	T_136 (in __bit @ 0000011C : ptr16)
Eq_130: (fn word16 (word16, int16))
	T_130 (in __bit_clear @ 0000011A : ptr16)
	T_131 (in signature of __bit_clear @ 00000000 : void)
	T_140 (in __bit_clear @ 00000126 : ptr16)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr16 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr16 Eq_1)
  OrigDataType: (ptr16 (struct "Globals"))
T_2: (in SP @ 00000000 : (ptr16 Eq_2))
  Class: Eq_2
  DataType: (ptr16 Eq_2)
  OrigDataType: (ptr16 (struct (FFFFFFFA T_20 tFFFFFFFA) (FFFFFFFC T_16 tFFFFFFFC) (FFFFFFFE T_12 tFFFFFFFE)))
T_3: (in 0x8004<16> @ 00000000 : word16)
  Class: Eq_3
  DataType: word16
  OrigDataType: word16
T_4: (in FF12 @ 00000000 : ptr16)
  Class: Eq_4
  DataType: (ptr16 word16)
  OrigDataType: (ptr16 (struct (0 T_5 t0000)))
T_5: (in Mem3[0xFF12<p16>:word16] @ 00000000 : word16)
  Class: Eq_3
  DataType: word16
  OrigDataType: word16
T_6: (in 0x8004<16> @ 00000006 : word16)
  Class: Eq_3
  DataType: word16
  OrigDataType: word16
T_7: (in FF12 @ 00000006 : ptr16)
  Class: Eq_7
  DataType: (ptr16 word16)
  OrigDataType: (ptr16 (struct (0 T_8 t0000)))
T_8: (in Mem4[0xFF12<p16>:word16] @ 00000006 : word16)
  Class: Eq_3
  DataType: word16
  OrigDataType: word16
T_9: (in 0<16> @ 00000028 : word16)
  Class: Eq_9
  DataType: word16
  OrigDataType: word16
T_10: (in -2<i16> @ 00000028 : int16)
  Class: Eq_10
  DataType: int16
  OrigDataType: int16
T_11: (in SP + -2<i16> @ 00000028 : word16)
  Class: Eq_11
  DataType: word16
  OrigDataType: word16
T_12: (in Mem20[SP + -2<i16>:word16] @ 00000028 : word16)
  Class: Eq_9
  DataType: word16
  OrigDataType: word16
T_13: (in 0<16> @ 0000002A : word16)
  Class: Eq_13
  DataType: word16
  OrigDataType: word16
T_14: (in -4<i16> @ 0000002A : int16)
  Class: Eq_14
  DataType: int16
  OrigDataType: int16
T_15: (in SP + -4<i16> @ 0000002A : word16)
  Class: Eq_15
  DataType: ptr16
  OrigDataType: ptr16
T_16: (in Mem23[SP + -4<i16>:word16] @ 0000002A : word16)
  Class: Eq_13
  DataType: word16
  OrigDataType: word16
T_17: (in 0x34<16> @ 00000030 : word16)
  Class: Eq_17
  DataType: word16
  OrigDataType: word16
T_18: (in -6<i16> @ 00000030 : int16)
  Class: Eq_18
  DataType: int16
  OrigDataType: int16
T_19: (in SP + -6<i16> @ 00000030 : word16)
  Class: Eq_19
  DataType: ptr16
  OrigDataType: ptr16
T_20: (in Mem27[SP + -6<i16>:word16] @ 00000030 : word16)
  Class: Eq_17
  DataType: word16
  OrigDataType: word16
T_21: (in __disable_watchdog_timer @ 00000062 : ptr16)
  Class: Eq_21
  DataType: (ptr16 Eq_21)
  OrigDataType: (ptr16 (fn T_23 ()))
T_22: (in signature of __disable_watchdog_timer @ 00000000 : void)
  Class: Eq_21
  DataType: (ptr16 Eq_21)
  OrigDataType: 
T_23: (in __disable_watchdog_timer() @ 00000062 : void)
  Class: Eq_23
  DataType: void
  OrigDataType: void
T_24: (in __end_of_initialization @ 00000066 : ptr16)
  Class: Eq_24
  DataType: (ptr16 Eq_24)
  OrigDataType: (ptr16 (fn T_26 ()))
T_25: (in signature of __end_of_initialization @ 00000000 : void)
  Class: Eq_24
  DataType: (ptr16 Eq_24)
  OrigDataType: 
T_26: (in __end_of_initialization() @ 00000066 : void)
  Class: Eq_26
  DataType: void
  OrigDataType: void
T_27: (in S0TIC_160 @ 00000056 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_28: (in 0<16> @ 00000056 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_29: (in S0RIC_151 @ 0000005A : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_30: (in 0<16> @ 0000005A : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_31: (in r0_45 @ 00000098 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_32: (in <invalid> @ 00000098 : word16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_33: (in fn011C @ 00000098 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_36 (T_29)))
T_34: (in signature of fn011C @ 0000011C : void)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: 
T_35: (in S0RIC @ 00000098 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_36: (in fn011C(S0RIC_151) @ 00000098 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_37: (in SLICE(r0_45, byte, 0) @ 000000A0 : byte)
  Class: Eq_37
  DataType: byte
  OrigDataType: byte
T_38: (in 0x3A<8> @ 000000A0 : byte)
  Class: Eq_37
  DataType: byte
  OrigDataType: byte
T_39: (in (byte) r0_45 == 0x3A<8> @ 00000000 : bool)
  Class: Eq_39
  DataType: bool
  OrigDataType: bool
T_40: (in r0_34 @ 00000084 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: cui16
T_41: (in 0xDF<16> @ 00000084 : word16)
  Class: Eq_41
  DataType: cui16
  OrigDataType: cui16
T_42: (in r0_34 & 0xDF<16> @ 00000000 : word16)
  Class: Eq_42
  DataType: cui16
  OrigDataType: cui16
T_43: (in 0x47<16> @ 00000084 : word16)
  Class: Eq_42
  DataType: cui16
  OrigDataType: word16
T_44: (in (r0_34 & 0xDF<16>) == 0x47<16> @ 00000000 : bool)
  Class: Eq_44
  DataType: bool
  OrigDataType: bool
T_45: (in fn011C @ 0000008E : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_48 (T_47)))
T_46: (in fn011C @ 0000008E : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_47 (T_29)))
T_47: (in fn011C(S0RIC_151) @ 0000008E : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_48: (in fn011C(fn011C(S0RIC_151)) @ 0000008E : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_49: (in r0_168 @ 00000088 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_50: (in SLICE(r0_168, byte, 0) @ 00000094 : byte)
  Class: Eq_50
  DataType: byte
  OrigDataType: byte
T_51: (in fp @ 00000094 : ptr16)
  Class: Eq_51
  DataType: ptr16
  OrigDataType: ptr16
T_52: (in SLICE(fp, byte, 0) @ 00000094 : byte)
  Class: Eq_52
  DataType: byte
  OrigDataType: byte
T_53: (in SEQ(SLICE(r0_168, byte, 0), SLICE(fp, byte, 0)) @ 00000094 : word16)
  Class: Eq_53
  DataType: word16
  OrigDataType: word16
T_54: (in 0xFBFE<16> @ 00000094 : word16)
  Class: Eq_54
  DataType: (ptr16 word16)
  OrigDataType: (ptr16 (struct (0 T_55 t0000)))
T_55: (in Mem191[0xFBFE<16>:word16] @ 00000094 : word16)
  Class: Eq_53
  DataType: word16
  OrigDataType: word16
T_56: (in fn0128 @ 0000006E : ptr16)
  Class: Eq_56
  DataType: (ptr16 Eq_56)
  OrigDataType: (ptr16 (fn T_61 (T_60, T_27)))
T_57: (in signature of fn0128 @ 00000128 : void)
  Class: Eq_56
  DataType: (ptr16 Eq_56)
  OrigDataType: 
T_58: (in r1 @ 0000006E : (ptr16 byte))
  Class: Eq_58
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct 0001 (0 byte b0000)))
T_59: (in S0TIC @ 0000006E : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_60: (in 0x13E<16> @ 0000006E : word16)
  Class: Eq_58
  DataType: (ptr16 byte)
  OrigDataType: word16
T_61: (in fn0128(&g_b013E, S0TIC_160) @ 0000006E : void)
  Class: Eq_61
  DataType: void
  OrigDataType: void
T_62: (in fn011C @ 00000072 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_63 (T_29)))
T_63: (in fn011C(S0RIC_151) @ 00000072 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_64: (in r0_34 & 0xDF<16> @ 00000000 : word16)
  Class: Eq_64
  DataType: cui16
  OrigDataType: cui16
T_65: (in 0x44<16> @ 0000007E : word16)
  Class: Eq_64
  DataType: cui16
  OrigDataType: word16
T_66: (in (r0_34 & 0xDF<16>) == 0x44<16> @ 00000000 : bool)
  Class: Eq_66
  DataType: bool
  OrigDataType: bool
T_67: (in r0_55 @ 000000A2 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: cui16
T_68: (in S0RIC_56 @ 000000A2 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_69: (in fn011C @ 000000A2 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_70 (T_29)))
T_70: (in fn011C(S0RIC_151) @ 000000A2 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_71: (in SLICE(r0_55, byte, 0) @ 000000A8 : byte)
  Class: Eq_71
  DataType: byte
  OrigDataType: byte
T_72: (in 0<8> @ 000000A8 : byte)
  Class: Eq_71
  DataType: byte
  OrigDataType: byte
T_73: (in (byte) r0_55 == 0<8> @ 00000000 : bool)
  Class: Eq_73
  DataType: bool
  OrigDataType: bool
T_74: (in fn011C @ 000000E6 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_81 (T_80)))
T_75: (in fn011C @ 000000E6 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_80 (T_79)))
T_76: (in fn011C @ 000000E6 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_79 (T_78)))
T_77: (in fn011C @ 000000E6 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_78 (T_68)))
T_78: (in fn011C(S0RIC_56) @ 000000E6 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_79: (in fn011C(fn011C(S0RIC_56)) @ 000000E6 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_80: (in fn011C(fn011C(fn011C(S0RIC_56))) @ 000000E6 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_81: (in fn011C(fn011C(fn011C(fn011C(S0RIC_56)))) @ 000000E6 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_82: (in fn0110 @ 000000EE : ptr16)
  Class: Eq_82
  DataType: (ptr16 Eq_82)
  OrigDataType: (ptr16 (fn T_85 (T_27)))
T_83: (in signature of fn0110 @ 00000110 : void)
  Class: Eq_82
  DataType: (ptr16 Eq_82)
  OrigDataType: 
T_84: (in S0TIC @ 000000EE : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_85: (in fn0110(S0TIC_160) @ 000000EE : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_86: (in r0_107 @ 000000B0 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_87: (in r0_117 @ 000000B6 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_88: (in r2_103 @ 000000AC : cu16)
  Class: Eq_88
  DataType: cu16
  OrigDataType: cui16
T_89: (in 0xFF<16> @ 000000AC : word16)
  Class: Eq_89
  DataType: cui16
  OrigDataType: cui16
T_90: (in r0_55 & 0xFF<16> @ 00000000 : word16)
  Class: Eq_88
  DataType: cu16
  OrigDataType: cui16
T_91: (in S0RIC_128 @ 000000BC : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_92: (in fn011C @ 000000BC : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_97 (T_96)))
T_93: (in fn011C @ 000000BC : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_96 (T_95)))
T_94: (in fn011C @ 000000BC : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_95 (T_68)))
T_95: (in fn011C(S0RIC_56) @ 000000BC : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_96: (in fn011C(fn011C(S0RIC_56)) @ 000000BC : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_97: (in fn011C(fn011C(fn011C(S0RIC_56))) @ 000000BC : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_98: (in r1_143 @ 000000BC : (ptr16 byte))
  Class: Eq_98
  DataType: (ptr16 byte)
  OrigDataType: (ptr16 (struct 0001 (0 byte b0000)))
T_99: (in SLICE(r0_107, byte, 0) @ 000000BC : byte)
  Class: Eq_99
  DataType: byte
  OrigDataType: byte
T_100: (in SLICE(r0_117, byte, 0) @ 000000BC : byte)
  Class: Eq_100
  DataType: byte
  OrigDataType: byte
T_101: (in SEQ(SLICE(r0_107, byte, 0), SLICE(r0_117, byte, 0)) @ 000000BC : word16)
  Class: Eq_98
  DataType: (ptr16 byte)
  OrigDataType: word16
T_102: (in r0_135 @ 000000C0 : cui16)
  Class: Eq_31
  DataType: cui16
  OrigDataType: word16
T_103: (in fn011C @ 000000C0 : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_104 (T_91)))
T_104: (in fn011C(S0RIC_128) @ 000000C0 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_105: (in SLICE(r0_135, byte, 0) @ 000000C4 : byte)
  Class: Eq_105
  DataType: byte
  OrigDataType: byte
T_106: (in 0<16> @ 000000C4 : word16)
  Class: Eq_106
  DataType: word16
  OrigDataType: word16
T_107: (in r1_143 + 0<16> @ 000000C4 : word16)
  Class: Eq_107
  DataType: word16
  OrigDataType: word16
T_108: (in Mem144[r1_143 + 0<16>:byte] @ 000000C4 : byte)
  Class: Eq_105
  DataType: byte
  OrigDataType: byte
T_109: (in 1<8> @ 000000C6 : byte)
  Class: Eq_109
  DataType: int16
  OrigDataType: (union (int16 u0) (byte u1))
T_110: (in r1_143 + 1<8> @ 000000C6 : word16)
  Class: Eq_98
  DataType: (ptr16 byte)
  OrigDataType: ptr16
T_111: (in r2_229 @ 000000C8 : word16)
  Class: Eq_88
  DataType: cu16
  OrigDataType: cu16
T_112: (in 1<i16> @ 000000C8 : int16)
  Class: Eq_112
  DataType: int16
  OrigDataType: int16
T_113: (in r2_229 - 1<i16> @ 00000000 : word16)
  Class: Eq_88
  DataType: cu16
  OrigDataType: word16
T_114: (in 1<16> @ 000000CA : word16)
  Class: Eq_88
  DataType: cu16
  OrigDataType: cup16
T_115: (in r2_229 > 1<16> @ 00000000 : bool)
  Class: Eq_115
  DataType: bool
  OrigDataType: bool
T_116: (in fn011C @ 000000CC : ptr16)
  Class: Eq_33
  DataType: (ptr16 Eq_33)
  OrigDataType: (ptr16 (fn T_117 (T_91)))
T_117: (in fn011C(S0RIC_128) @ 000000CC : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_118: (in fn0110 @ 000000D4 : ptr16)
  Class: Eq_82
  DataType: (ptr16 Eq_82)
  OrigDataType: (ptr16 (fn T_119 (T_27)))
T_119: (in fn0110(S0TIC_160) @ 000000D4 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_120: (in fp @ 00000110 : ptr16)
  Class: Eq_120
  DataType: ptr16
  OrigDataType: ptr16
T_121: (in FEB0 @ 00000110 : ptr16)
  Class: Eq_121
  DataType: (ptr16 ptr16)
  OrigDataType: (ptr16 (struct (0 T_122 t0000)))
T_122: (in Mem3[0xFEB0<p16>:word16] @ 00000110 : word16)
  Class: Eq_120
  DataType: ptr16
  OrigDataType: word16
T_123: (in __bit @ 00000114 : ptr16)
  Class: Eq_123
  DataType: (ptr16 Eq_123)
  OrigDataType: (ptr16 (fn T_128 (T_84, T_127)))
T_124: (in signature of __bit @ 00000000 : void)
  Class: Eq_123
  DataType: (ptr16 Eq_123)
  OrigDataType: 
T_125: (in  @ 00000114 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: 
T_126: (in  @ 00000114 : int16)
  Class: Eq_126
  DataType: int16
  OrigDataType: 
T_127: (in 7<i16> @ 00000114 : int16)
  Class: Eq_126
  DataType: int16
  OrigDataType: int16
T_128: (in __bit(S0TIC, 7<i16>) @ 00000114 : bool)
  Class: Eq_128
  DataType: bool
  OrigDataType: bool
T_129: (in !__bit(S0TIC, 7<i16>) @ 00000114 : bool)
  Class: Eq_129
  DataType: bool
  OrigDataType: bool
T_130: (in __bit_clear @ 0000011A : ptr16)
  Class: Eq_130
  DataType: (ptr16 Eq_130)
  OrigDataType: (ptr16 (fn T_135 (T_84, T_134)))
T_131: (in signature of __bit_clear @ 00000000 : void)
  Class: Eq_130
  DataType: (ptr16 Eq_130)
  OrigDataType: 
T_132: (in  @ 0000011A : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: 
T_133: (in  @ 0000011A : int16)
  Class: Eq_133
  DataType: int16
  OrigDataType: 
T_134: (in 7<i16> @ 0000011A : int16)
  Class: Eq_133
  DataType: int16
  OrigDataType: int16
T_135: (in __bit_clear(S0TIC, 7<i16>) @ 0000011A : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_136: (in __bit @ 0000011C : ptr16)
  Class: Eq_123
  DataType: (ptr16 Eq_123)
  OrigDataType: (ptr16 (fn T_138 (T_35, T_137)))
T_137: (in 7<i16> @ 0000011C : int16)
  Class: Eq_126
  DataType: int16
  OrigDataType: int16
T_138: (in __bit(S0RIC, 7<i16>) @ 0000011C : bool)
  Class: Eq_128
  DataType: bool
  OrigDataType: bool
T_139: (in !__bit(S0RIC, 7<i16>) @ 0000011C : bool)
  Class: Eq_139
  DataType: bool
  OrigDataType: bool
T_140: (in __bit_clear @ 00000126 : ptr16)
  Class: Eq_130
  DataType: (ptr16 Eq_130)
  OrigDataType: (ptr16 (fn T_142 (T_35, T_141)))
T_141: (in 7<i16> @ 00000126 : int16)
  Class: Eq_133
  DataType: int16
  OrigDataType: int16
T_142: (in __bit_clear(S0RIC, 7<i16>) @ 00000126 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_143: (in 0<16> @ 0000012E : word16)
  Class: Eq_143
  DataType: word16
  OrigDataType: word16
T_144: (in r1 + 0<16> @ 0000012E : word16)
  Class: Eq_144
  DataType: word16
  OrigDataType: word16
T_145: (in Mem0[r1 + 0<16>:byte] @ 0000012E : byte)
  Class: Eq_145
  DataType: byte
  OrigDataType: byte
T_146: (in 0<8> @ 0000012E : byte)
  Class: Eq_145
  DataType: byte
  OrigDataType: byte
T_147: (in *r1 == 0<8> @ 00000000 : bool)
  Class: Eq_147
  DataType: bool
  OrigDataType: bool
T_148: (in fn0110 @ 00000132 : ptr16)
  Class: Eq_82
  DataType: (ptr16 Eq_82)
  OrigDataType: (ptr16 (fn T_149 (T_59)))
T_149: (in fn0110(S0TIC) @ 00000132 : word16)
  Class: Eq_27
  DataType: word16
  OrigDataType: word16
T_150: (in 1<16> @ 00000136 : word16)
  Class: Eq_150
  DataType: int16
  OrigDataType: int16
T_151: (in r1 + 1<16> @ 00000136 : word16)
  Class: Eq_58
  DataType: (ptr16 byte)
  OrigDataType: ptr16
*/
typedef struct Globals {
	byte b013E;	// 13E
	word16 wFBFE;	// FBFE
	ptr16 ptrFEB0;	// FEB0
	word16 wFF12;	// FF12
} Eq_1;

typedef struct Eq_2 {
	word16 wFFFFFFFA;	// FFFFFFFA
	word16 wFFFFFFFC;	// FFFFFFFC
	word16 wFFFFFFFE;	// FFFFFFFE
} Eq_2;

typedef void (Eq_21)();

typedef void (Eq_24)();

typedef word16 (Eq_33)(word16);

typedef void (Eq_56)(byte *, word16);

typedef word16 (Eq_82)(word16);

typedef union Eq_109 {
	int16 u0;
	byte u1;
} Eq_109;

typedef bool (Eq_123)(word16, int16);

typedef word16 (Eq_130)(word16, int16);

