// RussianText.h
// Generated by decompiling RussianText.exe
// using Reko decompiler version 0.11.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals"
		(40208B uint32 dw40208B)
		(4020A4 char b4020A4)
		(4020E4 void v4020E4)
		(4020F8 word32 dw4020F8)
		(40503C word32 dw40503C)
		(405040 word32 dw405040)
		(405044 word32 dw405044)
		(405048 word32 dw405048)
		(40504C word32 dw40504C)
		(405054 (ptr32 code) __imp__GetModuleHandleA)
		(405058 (ptr32 code) __imp__GetProcAddress)
		(40505C (ptr32 code) __imp__GetProcessHeap)
		(405060 (ptr32 code) __imp__HeapAlloc)
		(405064 (ptr32 code) __imp__HeapFree)
		(40506C word32 dw40506C)
		(405070 word32 dw405070)
		(405074 word32 dw405074)
		(405078 word32 dw405078)
		(40507C word32 dw40507C)
		(405080 word32 dw405080)
		(405084 word32 dw405084)
		(405088 word32 dw405088)
		(40508C word32 dw40508C)
		(405090 word32 dw405090)
		(405094 word32 dw405094)
		(405098 word32 dw405098)
		(40509C word32 dw40509C)
		(4050A0 word32 dw4050A0)
		(4050A4 word32 dw4050A4)
		(4050A8 word32 dw4050A8)
		(4050AC word32 dw4050AC)
		(4050B0 word32 dw4050B0)
		(4050B4 word32 dw4050B4)
		(4050B8 word32 dw4050B8)
		(4050BC word32 dw4050BC)
		(4050C0 word32 dw4050C0)
		(4050C4 word32 dw4050C4)
		(4050CC (ptr32 code) __imp__@_InitTermAndUnexPtrs$qv)
		(4050D0 (ptr32 code) __imp_____CRTL_MEM_UseBorMM)
		(4050D4 (ptr32 code) __imp_____CRTL_TLS_Alloc)
		(4050D8 (ptr32 code) __imp_____CRTL_TLS_ExitThread)
		(4050DC (ptr32 code) __imp_____CRTL_TLS_Free)
		(4050E0 (ptr32 code) __imp_____CRTL_TLS_GetValue)
		(4050E4 (ptr32 code) __imp_____CRTL_TLS_InitThread)
		(4050E8 (ptr32 code) __imp_____CRTL_TLS_SetValue)
		(4050EC (ptr32 code) __imp____argc)
		(4050F0 (ptr32 code) __imp____argv)
		(4050F4 (ptr32 code) __imp____argv_default_expand)
		(4050F8 (ptr32 code) __imp____exitargv)
		(4050FC (ptr32 code) __imp____handle_exitargv)
		(405100 (ptr32 code) __imp____handle_setargv)
		(405104 (ptr32 code) __imp____handle_wexitargv)
		(405108 (ptr32 code) __imp____handle_wsetargv)
		(40510C (ptr32 code) __imp____matherr)
		(405110 (ptr32 code) __imp____matherrl)
		(405114 (ptr32 code) __imp____setargv)
		(405118 (ptr32 code) __imp____startup)
		(40511C (ptr32 code) __imp____wargv_default_expand)
		(405120 (ptr32 code) __imp___memcpy)
		(405124 (ptr32 code) __imp___printf))
	globals_t (in globals : (ptr32 (struct "Globals")))
Eq_2: (struct "Eq_2" (0 word32 dw0000) (4 (ptr32 void) ptr0004))
	T_2 (in dwArg04 : (ptr32 Eq_2))
	T_5 (in dwArg04 @ 00401071 : (ptr32 Eq_2))
	T_73 (in &tLoc0C @ 004011CE : (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004))))
Eq_3: (fn void ((ptr32 Eq_2)))
	T_3 (in fn004011FC @ 00401071 : ptr32)
	T_4 (in signature of fn004011FC @ 004011FC : void)
	T_72 (in fn004011FC @ 004011CE : ptr32)
Eq_11: LPVOID
	T_11 (in eax_11 @ 0040111A : Eq_11)
	T_16 (in __CRTL_TLS_GetValue(g_dw40208B) @ 0040111A : void)
	T_17 (in 0<32> @ 00401121 : word32)
	T_23 (in lpMem @ 0040112C : LPVOID)
Eq_12: (fn Eq_11 (uint32))
	T_12 (in __CRTL_TLS_GetValue @ 0040111A : ptr32)
Eq_19: (fn Eq_28 (Eq_21, Eq_22, Eq_11))
	T_19 (in HeapFree @ 0040112C : ptr32)
	T_20 (in signature of HeapFree : void)
Eq_21: HANDLE
	T_21 (in hHeap @ 0040112C : HANDLE)
	T_26 (in GetProcessHeap() @ 0040112C : HANDLE)
Eq_22: DWORD
	T_22 (in dwFlags @ 0040112C : DWORD)
	T_27 (in 8<32> @ 0040112C : word32)
Eq_24: (fn Eq_21 ())
	T_24 (in GetProcessHeap @ 0040112C : ptr32)
	T_25 (in signature of GetProcessHeap : void)
Eq_28: BOOL
	T_28 (in HeapFree(GetProcessHeap(), 8<32>, eax_11) @ 0040112C : BOOL)
Eq_29: (fn void (uint32))
	T_29 (in __CRTL_TLS_ExitThread @ 00401137 : ptr32)
Eq_35: (segment "Eq_35" (2C (ptr32 (arr word32)) ptr002C))
	T_35 (in fs @ 00401158 : (ptr16 Eq_35))
Eq_46: (fn int32 ((ptr32 char)))
	T_46 (in printf @ 00401170 : ptr32)
	T_47 (in signature of printf : void)
Eq_53: (struct "Eq_53" (0 word32 dw0000) (4 (ptr32 void) ptr0004))
	T_53 (in tLoc0C @ 004011B0 : Eq_53)
Eq_57: (fn (ptr32 void) ((ptr32 void), (ptr32 void), Eq_61))
	T_57 (in memcpy @ 004011E9 : ptr32)
	T_58 (in signature of memcpy : void)
Eq_61: size_t
	T_61 (in _Size @ 004011E9 : size_t)
	T_65 (in 0x9C<32> @ 004011E9 : word32)
Eq_62: (fn (ptr32 void) ())
	T_62 (in fn00401158 @ 004011E9 : ptr32)
	T_63 (in signature of fn00401158 @ 00401158 : void)
	T_79 (in fn00401158 @ 0040120E : ptr32)
Eq_67: (fn void ())
	T_67 (in _InitTermAndUnexPtrs @ 004011F1 : ptr32)
	T_68 (in signature of _InitTermAndUnexPtrs : void)
Eq_75: (struct "Eq_75" (0 word32 dw0000) (4 (ptr32 void) ptr0004))
	T_75 (in &tLoc0C @ 004011D4 : (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004))))
// Type Variables ////////////
globals_t: (in globals : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in dwArg04 : (ptr32 Eq_2))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: word32
T_3: (in fn004011FC @ 00401071 : ptr32)
  Class: Eq_3
  DataType: (ptr32 Eq_3)
  OrigDataType: (ptr32 (fn T_6 (T_2)))
T_4: (in signature of fn004011FC @ 004011FC : void)
  Class: Eq_3
  DataType: (ptr32 Eq_3)
  OrigDataType: 
T_5: (in dwArg04 @ 00401071 : (ptr32 Eq_2))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 (struct (0 T_88 t0000) (4 T_92 t0004)))
T_6: (in fn004011FC(dwArg04) @ 00401071 : void)
  Class: Eq_6
  DataType: void
  OrigDataType: void
T_7: (in 0040208B @ 00401112 : ptr32)
  Class: Eq_7
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_8 t0000)))
T_8: (in Mem0[0x0040208B<p32>:word32] @ 00401112 : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: up32
T_9: (in 0<32> @ 00401112 : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: up32
T_10: (in g_dw40208B < 0<32> @ 00401112 : bool)
  Class: Eq_10
  DataType: bool
  OrigDataType: bool
T_11: (in eax_11 @ 0040111A : Eq_11)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: LPVOID
T_12: (in __CRTL_TLS_GetValue @ 0040111A : ptr32)
  Class: Eq_12
  DataType: (ptr32 Eq_12)
  OrigDataType: (ptr32 (fn T_16 (T_15)))
T_13: (in signature of __CRTL_TLS_GetValue : void)
  Class: Eq_13
  DataType: Eq_13
  OrigDataType: 
T_14: (in 0040208B @ 0040111A : ptr32)
  Class: Eq_14
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_15 t0000)))
T_15: (in Mem0[0x0040208B<p32>:word32] @ 0040111A : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: word32
T_16: (in __CRTL_TLS_GetValue(g_dw40208B) @ 0040111A : void)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: void
T_17: (in 0<32> @ 00401121 : word32)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: word32
T_18: (in eax_11 == null @ 00401121 : bool)
  Class: Eq_18
  DataType: bool
  OrigDataType: bool
T_19: (in HeapFree @ 0040112C : ptr32)
  Class: Eq_19
  DataType: (ptr32 Eq_19)
  OrigDataType: (ptr32 (fn T_28 (T_26, T_27, T_11)))
T_20: (in signature of HeapFree : void)
  Class: Eq_19
  DataType: (ptr32 Eq_19)
  OrigDataType: 
T_21: (in hHeap @ 0040112C : HANDLE)
  Class: Eq_21
  DataType: Eq_21
  OrigDataType: 
T_22: (in dwFlags @ 0040112C : DWORD)
  Class: Eq_22
  DataType: Eq_22
  OrigDataType: 
T_23: (in lpMem @ 0040112C : LPVOID)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: 
T_24: (in GetProcessHeap @ 0040112C : ptr32)
  Class: Eq_24
  DataType: (ptr32 Eq_24)
  OrigDataType: (ptr32 (fn T_26 ()))
T_25: (in signature of GetProcessHeap : void)
  Class: Eq_24
  DataType: (ptr32 Eq_24)
  OrigDataType: 
T_26: (in GetProcessHeap() @ 0040112C : HANDLE)
  Class: Eq_21
  DataType: Eq_21
  OrigDataType: (union (HANDLE u1))
T_27: (in 8<32> @ 0040112C : word32)
  Class: Eq_22
  DataType: Eq_22
  OrigDataType: DWORD
T_28: (in HeapFree(GetProcessHeap(), 8<32>, eax_11) @ 0040112C : BOOL)
  Class: Eq_28
  DataType: Eq_28
  OrigDataType: BOOL
T_29: (in __CRTL_TLS_ExitThread @ 00401137 : ptr32)
  Class: Eq_29
  DataType: (ptr32 Eq_29)
  OrigDataType: (ptr32 (fn T_33 (T_32)))
T_30: (in signature of __CRTL_TLS_ExitThread : void)
  Class: Eq_30
  DataType: Eq_30
  OrigDataType: 
T_31: (in 0040208B @ 00401137 : ptr32)
  Class: Eq_31
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_32 t0000)))
T_32: (in Mem24[0x0040208B<p32>:word32] @ 00401137 : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: word32
T_33: (in __CRTL_TLS_ExitThread(g_dw40208B) @ 00401137 : void)
  Class: Eq_33
  DataType: void
  OrigDataType: void
T_34: (in eax @ 00401137 : word32)
  Class: Eq_34
  DataType: word32
  OrigDataType: word32
T_35: (in fs @ 00401158 : (ptr16 Eq_35))
  Class: Eq_35
  DataType: (ptr16 Eq_35)
  OrigDataType: (ptr16 (segment (2C T_37 t002C)))
T_36: (in 0x2C<16> @ 00401166 : word16)
  Class: Eq_36
  DataType: (memptr (ptr16 Eq_35) (ptr32 (arr word32)))
  OrigDataType: (memptr T_35 (struct (0 T_37 t0000)))
T_37: (in Mem0[fs:0x2C<16>:word32] @ 00401166 : word32)
  Class: Eq_37
  DataType: (ptr32 (arr word32))
  OrigDataType: (ptr32 (struct (0 (arr T_121) a0000)))
T_38: (in 0040208B @ 00401166 : ptr32)
  Class: Eq_38
  DataType: (ptr32 uint32)
  OrigDataType: (ptr32 (struct (0 T_39 t0000)))
T_39: (in Mem0[0x0040208B<p32>:word32] @ 00401166 : word32)
  Class: Eq_8
  DataType: uint32
  OrigDataType: ui32
T_40: (in 4<32> @ 00401166 : word32)
  Class: Eq_40
  DataType: ui32
  OrigDataType: ui32
T_41: (in g_dw40208B * 4<32> @ 00401166 : word32)
  Class: Eq_41
  DataType: ui32
  OrigDataType: ui32
T_42: (in Mem0[fs:0x2C<16>:word32][Mem0[0x0040208B<p32>:word32] * 4<32>] @ 00401166 : word32)
  Class: Eq_34
  DataType: word32
  OrigDataType: word32
T_43: (in eax @ 00401166 : int32)
  Class: Eq_43
  DataType: int32
  OrigDataType: int32
T_44: (in argc @ 00401166 : int32)
  Class: Eq_44
  DataType: int32
  OrigDataType: int32
T_45: (in argv @ 00401166 : (ptr32 (ptr32 char)))
  Class: Eq_45
  DataType: (ptr32 (ptr32 char))
  OrigDataType: (ptr32 (ptr32 char))
T_46: (in printf @ 00401170 : ptr32)
  Class: Eq_46
  DataType: (ptr32 Eq_46)
  OrigDataType: (ptr32 (fn T_50 (T_49)))
T_47: (in signature of printf : void)
  Class: Eq_46
  DataType: (ptr32 Eq_46)
  OrigDataType: 
T_48: (in ptrArg04 @ 00401170 : (ptr32 char))
  Class: Eq_48
  DataType: (ptr32 char)
  OrigDataType: 
T_49: (in 0x4020A4<32> @ 00401170 : word32)
  Class: Eq_48
  DataType: (ptr32 char)
  OrigDataType: (ptr32 char)
T_50: (in printf(&g_b4020A4) @ 00401170 : int32)
  Class: Eq_50
  DataType: int32
  OrigDataType: int32
T_51: (in 0<32> @ 00401179 : word32)
  Class: Eq_43
  DataType: int32
  OrigDataType: word32
T_52: (in dwArg04 @ 00401180 : (ptr32 void))
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: word32
T_53: (in tLoc0C @ 004011B0 : Eq_53)
  Class: Eq_53
  DataType: Eq_53
  OrigDataType: (struct (0 T_4 t0000) (4 T_7 t0004))
T_54: (in ebx_12 @ 004011B7 : (ptr32 void))
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: (ptr32 void)
T_55: (in 0<32> @ 004011C4 : word32)
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: word32
T_56: (in dwArg04 != null @ 004011C4 : bool)
  Class: Eq_56
  DataType: bool
  OrigDataType: bool
T_57: (in memcpy @ 004011E9 : ptr32)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: (ptr32 (fn T_66 (T_64, T_54, T_65)))
T_58: (in signature of memcpy : void)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: 
T_59: (in _Dst @ 004011E9 : (ptr32 void))
  Class: Eq_59
  DataType: (ptr32 void)
  OrigDataType: 
T_60: (in _Src @ 004011E9 : (ptr32 void))
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: 
T_61: (in _Size @ 004011E9 : size_t)
  Class: Eq_61
  DataType: Eq_61
  OrigDataType: 
T_62: (in fn00401158 @ 004011E9 : ptr32)
  Class: Eq_62
  DataType: (ptr32 Eq_62)
  OrigDataType: (ptr32 (fn T_64 ()))
T_63: (in signature of fn00401158 @ 00401158 : void)
  Class: Eq_62
  DataType: (ptr32 Eq_62)
  OrigDataType: 
T_64: (in fn00401158() @ 004011E9 : word32)
  Class: Eq_59
  DataType: (ptr32 void)
  OrigDataType: (ptr32 void)
T_65: (in 0x9C<32> @ 004011E9 : word32)
  Class: Eq_61
  DataType: Eq_61
  OrigDataType: size_t
T_66: (in memcpy(fn00401158(), ebx_12, 0x9C<32>) @ 004011E9 : (ptr32 void))
  Class: Eq_66
  DataType: (ptr32 void)
  OrigDataType: (ptr32 void)
T_67: (in _InitTermAndUnexPtrs @ 004011F1 : ptr32)
  Class: Eq_67
  DataType: (ptr32 Eq_67)
  OrigDataType: (ptr32 (fn T_69 ()))
T_68: (in signature of _InitTermAndUnexPtrs : void)
  Class: Eq_67
  DataType: (ptr32 Eq_67)
  OrigDataType: 
T_69: (in _InitTermAndUnexPtrs() @ 004011F1 : void)
  Class: Eq_69
  DataType: void
  OrigDataType: void
T_70: (in 0<32> @ 004011C8 : word32)
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: word32
T_71: (in dwArg04 != null @ 004011C8 : bool)
  Class: Eq_71
  DataType: bool
  OrigDataType: bool
T_72: (in fn004011FC @ 004011CE : ptr32)
  Class: Eq_3
  DataType: (ptr32 Eq_3)
  OrigDataType: (ptr32 (fn T_74 (T_73)))
T_73: (in &tLoc0C @ 004011CE : (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004))))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004)))
T_74: (in fn004011FC(&tLoc0C) @ 004011CE : void)
  Class: Eq_6
  DataType: void
  OrigDataType: void
T_75: (in &tLoc0C @ 004011D4 : (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004))))
  Class: Eq_75
  DataType: (ptr32 Eq_75)
  OrigDataType: (ptr32 (struct (0 T_4 t0000) (4 T_7 t0004)))
T_76: (in 4<i32> @ 004011D4 : int32)
  Class: Eq_76
  DataType: int32
  OrigDataType: int32
T_77: (in &tLoc0C + 4<i32> @ 004011D4 : word32)
  Class: Eq_77
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 word32)
T_78: (in Mem27[&tLoc0C + 4<i32>:word32] @ 004011D4 : word32)
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: word32
T_79: (in fn00401158 @ 0040120E : ptr32)
  Class: Eq_62
  DataType: (ptr32 Eq_62)
  OrigDataType: (ptr32 (fn T_80 ()))
T_80: (in fn00401158() @ 0040120E : word32)
  Class: Eq_59
  DataType: (ptr32 void)
  OrigDataType: word32
T_81: (in 0x1C<32> @ 0040120E : word32)
  Class: Eq_81
  DataType: word32
  OrigDataType: word32
T_82: (in fn00401158() + 0x1C<32> @ 0040120E : word32)
  Class: Eq_82
  DataType: word32
  OrigDataType: word32
T_83: (in 004020F8 @ 0040120E : ptr32)
  Class: Eq_83
  DataType: (ptr32 word32)
  OrigDataType: (ptr32 (struct (0 T_84 t0000)))
T_84: (in Mem17[0x004020F8<p32>:word32] @ 0040120E : word32)
  Class: Eq_82
  DataType: word32
  OrigDataType: word32
T_85: (in 0x82727349<32> @ 00401213 : word32)
  Class: Eq_4
  DataType: word32
  OrigDataType: word32
T_86: (in 0<32> @ 00401213 : word32)
  Class: Eq_86
  DataType: word32
  OrigDataType: word32
T_87: (in dwArg04 + 0<32> @ 00401213 : word32)
  Class: Eq_87
  DataType: word32
  OrigDataType: word32
T_88: (in Mem18[dwArg04 + 0<32>:word32] @ 00401213 : word32)
  Class: Eq_4
  DataType: word32
  OrigDataType: word32
T_89: (in 0x004020E4<p32> @ 00401219 : ptr32)
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: ptr32
T_90: (in 4<i32> @ 00401219 : int32)
  Class: Eq_90
  DataType: int32
  OrigDataType: int32
T_91: (in dwArg04 + 4<i32> @ 00401219 : word32)
  Class: Eq_91
  DataType: ptr32
  OrigDataType: ptr32
T_92: (in Mem19[dwArg04 + 4<i32>:word32] @ 00401219 : word32)
  Class: Eq_7
  DataType: (ptr32 void)
  OrigDataType: word32
T_93:
  Class: Eq_93
  DataType: word32
  OrigDataType: word32
T_94:
  Class: Eq_94
  DataType: word32
  OrigDataType: word32
T_95:
  Class: Eq_95
  DataType: word32
  OrigDataType: word32
T_96:
  Class: Eq_96
  DataType: word32
  OrigDataType: word32
T_97:
  Class: Eq_97
  DataType: word32
  OrigDataType: word32
T_98:
  Class: Eq_98
  DataType: word32
  OrigDataType: word32
T_99:
  Class: Eq_99
  DataType: word32
  OrigDataType: word32
T_100:
  Class: Eq_100
  DataType: word32
  OrigDataType: word32
T_101:
  Class: Eq_101
  DataType: word32
  OrigDataType: word32
T_102:
  Class: Eq_102
  DataType: word32
  OrigDataType: word32
T_103:
  Class: Eq_103
  DataType: word32
  OrigDataType: word32
T_104:
  Class: Eq_104
  DataType: word32
  OrigDataType: word32
T_105:
  Class: Eq_105
  DataType: word32
  OrigDataType: word32
T_106:
  Class: Eq_106
  DataType: word32
  OrigDataType: word32
T_107:
  Class: Eq_107
  DataType: word32
  OrigDataType: word32
T_108:
  Class: Eq_108
  DataType: word32
  OrigDataType: word32
T_109:
  Class: Eq_109
  DataType: word32
  OrigDataType: word32
T_110:
  Class: Eq_110
  DataType: word32
  OrigDataType: word32
T_111:
  Class: Eq_111
  DataType: word32
  OrigDataType: word32
T_112:
  Class: Eq_112
  DataType: word32
  OrigDataType: word32
T_113:
  Class: Eq_113
  DataType: word32
  OrigDataType: word32
T_114:
  Class: Eq_114
  DataType: word32
  OrigDataType: word32
T_115:
  Class: Eq_115
  DataType: word32
  OrigDataType: word32
T_116:
  Class: Eq_116
  DataType: word32
  OrigDataType: word32
T_117:
  Class: Eq_117
  DataType: word32
  OrigDataType: word32
T_118:
  Class: Eq_118
  DataType: word32
  OrigDataType: word32
T_119:
  Class: Eq_119
  DataType: word32
  OrigDataType: word32
T_120:
  Class: Eq_120
  DataType: word32
  OrigDataType: word32
T_121:
  Class: Eq_121
  DataType: word32
  OrigDataType: (struct 0004 (0 T_42 t0000))
T_122:
  Class: Eq_122
  DataType: (arr word32)
  OrigDataType: (arr T_121)
*/
typedef struct Globals {
	uint32 dw40208B;	// 40208B
	char b4020A4;	// 4020A4
	void v4020E4;	// 4020E4
	word32 dw4020F8;	// 4020F8
	word32 dw40503C;	// 40503C
	word32 dw405040;	// 405040
	word32 dw405044;	// 405044
	word32 dw405048;	// 405048
	word32 dw40504C;	// 40504C
	<anonymous> * __imp__GetModuleHandleA;	// 405054
	<anonymous> * __imp__GetProcAddress;	// 405058
	<anonymous> * __imp__GetProcessHeap;	// 40505C
	<anonymous> * __imp__HeapAlloc;	// 405060
	<anonymous> * __imp__HeapFree;	// 405064
	word32 dw40506C;	// 40506C
	word32 dw405070;	// 405070
	word32 dw405074;	// 405074
	word32 dw405078;	// 405078
	word32 dw40507C;	// 40507C
	word32 dw405080;	// 405080
	word32 dw405084;	// 405084
	word32 dw405088;	// 405088
	word32 dw40508C;	// 40508C
	word32 dw405090;	// 405090
	word32 dw405094;	// 405094
	word32 dw405098;	// 405098
	word32 dw40509C;	// 40509C
	word32 dw4050A0;	// 4050A0
	word32 dw4050A4;	// 4050A4
	word32 dw4050A8;	// 4050A8
	word32 dw4050AC;	// 4050AC
	word32 dw4050B0;	// 4050B0
	word32 dw4050B4;	// 4050B4
	word32 dw4050B8;	// 4050B8
	word32 dw4050BC;	// 4050BC
	word32 dw4050C0;	// 4050C0
	word32 dw4050C4;	// 4050C4
	<anonymous> * __imp__@_InitTermAndUnexPtrs$qv;	// 4050CC
	<anonymous> * __imp_____CRTL_MEM_UseBorMM;	// 4050D0
	<anonymous> * __imp_____CRTL_TLS_Alloc;	// 4050D4
	<anonymous> * __imp_____CRTL_TLS_ExitThread;	// 4050D8
	<anonymous> * __imp_____CRTL_TLS_Free;	// 4050DC
	<anonymous> * __imp_____CRTL_TLS_GetValue;	// 4050E0
	<anonymous> * __imp_____CRTL_TLS_InitThread;	// 4050E4
	<anonymous> * __imp_____CRTL_TLS_SetValue;	// 4050E8
	<anonymous> * __imp____argc;	// 4050EC
	<anonymous> * __imp____argv;	// 4050F0
	<anonymous> * __imp____argv_default_expand;	// 4050F4
	<anonymous> * __imp____exitargv;	// 4050F8
	<anonymous> * __imp____handle_exitargv;	// 4050FC
	<anonymous> * __imp____handle_setargv;	// 405100
	<anonymous> * __imp____handle_wexitargv;	// 405104
	<anonymous> * __imp____handle_wsetargv;	// 405108
	<anonymous> * __imp____matherr;	// 40510C
	<anonymous> * __imp____matherrl;	// 405110
	<anonymous> * __imp____setargv;	// 405114
	<anonymous> * __imp____startup;	// 405118
	<anonymous> * __imp____wargv_default_expand;	// 40511C
	<anonymous> * __imp___memcpy;	// 405120
	<anonymous> * __imp___printf;	// 405124
} Eq_1;

typedef struct Eq_2 {
	word32 dw0000;	// 0
	void * ptr0004;	// 4
} Eq_2;

typedef void (Eq_3)(Eq_2 *);

typedef LPVOID Eq_11;

typedef LPVOID (Eq_12)(uint32);

typedef BOOL (Eq_19)(HANDLE, DWORD, LPVOID);

typedef HANDLE Eq_21;

typedef DWORD Eq_22;

typedef HANDLE (Eq_24)();

typedef BOOL Eq_28;

typedef void (Eq_29)(uint32);

typedef struct Eq_35 {
	word32 (* ptr002C)[];	// 2C
} Eq_35;

typedef int32 (Eq_46)(char *);

typedef struct Eq_53 {
	word32 dw0000;	// 0
	void * ptr0004;	// 4
} Eq_53;

typedef void (Eq_57)(void, void, size_t);

typedef size_t Eq_61;

typedef void (Eq_62)();

typedef void (Eq_67)();

typedef struct Eq_75 {
	word32 dw0000;	// 0
	void * ptr0004;	// 4
} Eq_75;

