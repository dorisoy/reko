// LocalStackVariables.h
// Generated by decompiling LocalStackVariables.exe
// using Reko decompiler version 0.9.4.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (402000 (ptr32 code) __imp__UnhandledExceptionFilter) (402004 (ptr32 code) __imp__GetCurrentProcess) (402008 (ptr32 code) __imp__TerminateProcess) (40200C (ptr32 code) __imp__GetSystemTimeAsFileTime) (402010 (ptr32 code) __imp__GetCurrentProcessId) (402014 (ptr32 code) __imp__GetCurrentThreadId) (402018 (ptr32 code) __imp__GetTickCount) (40201C (ptr32 code) __imp__QueryPerformanceCounter) (402020 (ptr32 code) __imp__SetUnhandledExceptionFilter) (402024 (ptr32 code) __imp__InterlockedCompareExchange) (402028 (ptr32 code) __imp__Sleep) (40202C (ptr32 code) __imp__InterlockedExchange) (402030 (ptr32 code) __imp__IsDebuggerPresent) (402038 (ptr32 code) __imp____p__fmode) (40203C (ptr32 code) __imp___encode_pointer) (402040 (ptr32 code) __imp____set_app_type) (402044 (ptr32 code) __imp__?terminate@@YAXXZ) (402048 (ptr32 code) __imp___unlock) (40204C (ptr32 code) __imp____p__commode) (402050 (ptr32 code) __imp___lock) (402054 (ptr32 code) __imp___onexit) (402058 (ptr32 code) __imp___decode_pointer) (40205C (ptr32 code) __imp___except_handler4_common) (402060 (ptr32 code) __imp___invoke_watson) (402064 (ptr32 code) __imp___controlfp_s) (402068 (ptr32 code) __imp___crt_debugger_hook) (40206C (ptr32 code) __imp___adjust_fdiv) (402070 (ptr32 code) __imp____setusermatherr) (402074 (ptr32 code) __imp___configthreadlocale) (402078 (ptr32 code) __imp___initterm_e) (40207C (ptr32 code) __imp___initterm) (402080 (ptr32 code) __imp____initenv) (402084 (ptr32 code) __imp__exit) (402088 (ptr32 code) __imp___XcptFilter) (40208C (ptr32 code) __imp___exit) (402090 (ptr32 code) __imp___cexit) (402094 (ptr32 code) __imp____getmainargs) (402098 (ptr32 code) __imp___amsg_exit) (40209C (ptr32 code) __imp____dllonexit) (4020A0 (ptr32 code) __imp__printf) (4020C8 (str char) str4020C8) (4020D8 (str char) str4020D8) (4020E0 real64 r4020E0) (4020E8 real64 r4020E8) (4020F0 real64 r4020F0) (4020F8 real64 r4020F8) (402200 word32 dw402200) (402204 word32 dw402204) (402208 word32 dw402208) (40220C word32 dw40220C) (402210 word32 dw402210) (402214 word32 dw402214) (402218 word32 dw402218) (40221C word32 dw40221C) (402220 word32 dw402220) (402224 word32 dw402224) (402228 word32 dw402228) (40222C word32 dw40222C) (402230 word32 dw402230) (402238 word32 dw402238) (40223C word32 dw40223C) (402240 word32 dw402240) (402244 word32 dw402244) (402248 word32 dw402248) (40224C word32 dw40224C) (402250 word32 dw402250) (402254 word32 dw402254) (402258 word32 dw402258) (40225C word32 dw40225C) (402260 word32 dw402260) (402264 word32 dw402264) (402268 word32 dw402268) (40226C word32 dw40226C) (402270 word32 dw402270) (402274 word32 dw402274) (402278 word32 dw402278) (40227C word32 dw40227C) (402280 word32 dw402280) (402284 word32 dw402284) (402288 word32 dw402288) (40228C word32 dw40228C) (402290 word32 dw402290) (402294 word32 dw402294) (402298 word32 dw402298) (40229C word32 dw40229C) (4022A0 word32 dw4022A0) (403018 (ptr32 Eq_41) ptr403018))
	globals_t (in globals : (ptr32 (struct "Globals")))
Eq_8: (struct "Eq_8" (0 word32 dw0000) (8 real64 r0008))
	T_8 (in eax_26 : (ptr32 Eq_8))
	T_18 (in GetMin(fp - 0x2C<32>, fp - 0x1C<32>) : word32)
Eq_9: (fn (ptr32 Eq_8) ((ptr32 Eq_11), (ptr32 Eq_11)))
	T_9 (in GetMin : ptr32)
	T_10 (in signature of GetMin : void)
Eq_11: (struct "Eq_11" (0 int32 dw0000) (8 real64 r0008))
	T_11 (in dwArg04 : (ptr32 Eq_11))
	T_12 (in dwArg08 : (ptr32 Eq_11))
	T_15 (in fp - 0x2C<32> : word32)
	T_17 (in fp - 0x1C<32> : word32)
	T_68 (in eax : (ptr32 Eq_11))
	T_69 (in eax_25 : (ptr32 Eq_11))
Eq_28: (fn int32 ((ptr32 char), int32, real64, int32, real64))
	T_28 (in printf : ptr32)
	T_29 (in signature of printf : void)
Eq_41: (struct "Eq_41" (0 word32 dw0000) (8 real64 r0008))
	T_41 (in fp - 0x1C<32> : word32)
	T_43 (in Mem65[0x00403018<p32>:word32] : word32)
	T_49 (in Mem69[0x00403018<p32>:word32] : word32)
	T_56 (in Mem72[0x00403018<p32>:word32] : word32)
Eq_60: (fn int32 ((ptr32 char), int32, real64))
	T_60 (in printf : ptr32)
	T_61 (in signature of printf : void)
// Type Variables ////////////
globals_t: (in globals : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in eax : int32)
  Class: Eq_2
  DataType: int32
  OrigDataType: int32
T_3: (in argc : int32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_4: (in argv : (ptr32 (ptr32 char)))
  Class: Eq_4
  DataType: (ptr32 (ptr32 char))
  OrigDataType: (ptr32 (ptr32 char))
T_5: (in rLoc1_101 : real64)
  Class: Eq_5
  DataType: real64
  OrigDataType: real64
T_6: (in 004020F8 : ptr32)
  Class: Eq_6
  DataType: (ptr32 real64)
  OrigDataType: (ptr32 (struct (0 T_7 t0000)))
T_7: (in Mem15[0x004020F8<p32>:real64] : real64)
  Class: Eq_5
  DataType: real64
  OrigDataType: real64
T_8: (in eax_26 : (ptr32 Eq_8))
  Class: Eq_8
  DataType: (ptr32 Eq_8)
  OrigDataType: (ptr32 (struct (0 T_22 t0000) (8 T_27 t0008)))
T_9: (in GetMin : ptr32)
  Class: Eq_9
  DataType: (ptr32 Eq_9)
  OrigDataType: (ptr32 (fn T_18 (T_15, T_17)))
T_10: (in signature of GetMin : void)
  Class: Eq_9
  DataType: (ptr32 Eq_9)
  OrigDataType: 
T_11: (in dwArg04 : (ptr32 Eq_11))
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: (ptr32 (struct (0 T_72 t0000) (8 T_89 t0008)))
T_12: (in dwArg08 : (ptr32 Eq_11))
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: (ptr32 (struct (0 T_72 t0000) (8 T_86 t0008)))
T_13: (in fp : ptr32)
  Class: Eq_13
  DataType: ptr32
  OrigDataType: ptr32
T_14: (in 0x2C<32> : word32)
  Class: Eq_14
  DataType: ui32
  OrigDataType: ui32
T_15: (in fp - 0x2C<32> : word32)
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: ptr32
T_16: (in 0x1C<32> : word32)
  Class: Eq_16
  DataType: ui32
  OrigDataType: ui32
T_17: (in fp - 0x1C<32> : word32)
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: ptr32
T_18: (in GetMin(fp - 0x2C<32>, fp - 0x1C<32>) : word32)
  Class: Eq_8
  DataType: (ptr32 Eq_8)
  OrigDataType: word32
T_19: (in 5<32> : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_20: (in 0<32> : word32)
  Class: Eq_20
  DataType: word32
  OrigDataType: word32
T_21: (in eax_26 + 0<32> : word32)
  Class: Eq_21
  DataType: word32
  OrigDataType: word32
T_22: (in Mem38[eax_26 + 0<32>:word32] : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_23: (in 004020F0 : ptr32)
  Class: Eq_23
  DataType: (ptr32 real64)
  OrigDataType: (ptr32 (struct (0 T_24 t0000)))
T_24: (in Mem38[0x004020F0<p32>:real64] : real64)
  Class: Eq_24
  DataType: real64
  OrigDataType: real64
T_25: (in 8<32> : word32)
  Class: Eq_25
  DataType: word32
  OrigDataType: word32
T_26: (in eax_26 + 8<32> : word32)
  Class: Eq_26
  DataType: ptr32
  OrigDataType: ptr32
T_27: (in Mem42[eax_26 + 8<32>:real64] : real64)
  Class: Eq_24
  DataType: real64
  OrigDataType: real64
T_28: (in printf : ptr32)
  Class: Eq_28
  DataType: (ptr32 Eq_28)
  OrigDataType: (ptr32 (fn T_39 (T_35, T_36, T_37, T_38, T_5)))
T_29: (in signature of printf : void)
  Class: Eq_28
  DataType: (ptr32 Eq_28)
  OrigDataType: 
T_30: (in ptrArg04 : (ptr32 char))
  Class: Eq_30
  DataType: (ptr32 char)
  OrigDataType: 
T_31: (in  : int32)
  Class: Eq_31
  DataType: int32
  OrigDataType: 
T_32: (in  : real64)
  Class: Eq_32
  DataType: real64
  OrigDataType: 
T_33: (in  : int32)
  Class: Eq_33
  DataType: int32
  OrigDataType: 
T_34: (in  : real64)
  Class: Eq_5
  DataType: real64
  OrigDataType: 
T_35: (in 0x4020C8<32> : word32)
  Class: Eq_30
  DataType: (ptr32 char)
  OrigDataType: (ptr32 char)
T_36: (in 0x64<32> : word32)
  Class: Eq_31
  DataType: int32
  OrigDataType: int32
T_37: (in 1.0 : real64)
  Class: Eq_32
  DataType: real64
  OrigDataType: real64
T_38: (in 0xA<32> : word32)
  Class: Eq_33
  DataType: int32
  OrigDataType: int32
T_39: (in printf("%d %f %d %f\n", 0x64<32>, 1.0, 0xA<32>, rLoc1_101) : int32)
  Class: Eq_39
  DataType: int32
  OrigDataType: int32
T_40: (in 0x1C<32> : word32)
  Class: Eq_40
  DataType: ui32
  OrigDataType: ui32
T_41: (in fp - 0x1C<32> : word32)
  Class: Eq_41
  DataType: (ptr32 Eq_41)
  OrigDataType: ptr32
T_42: (in 00403018 : ptr32)
  Class: Eq_42
  DataType: (ptr32 (ptr32 Eq_41))
  OrigDataType: (ptr32 (struct (0 T_43 t0000)))
T_43: (in Mem65[0x00403018<p32>:word32] : word32)
  Class: Eq_41
  DataType: (ptr32 Eq_41)
  OrigDataType: word32
T_44: (in rLoc1_116 : real64)
  Class: Eq_44
  DataType: real64
  OrigDataType: real64
T_45: (in 004020E8 : ptr32)
  Class: Eq_45
  DataType: (ptr32 real64)
  OrigDataType: (ptr32 (struct (0 T_46 t0000)))
T_46: (in Mem66[0x004020E8<p32>:real64] : real64)
  Class: Eq_44
  DataType: real64
  OrigDataType: real64
T_47: (in 3<32> : word32)
  Class: Eq_47
  DataType: word32
  OrigDataType: word32
T_48: (in 00403018 : ptr32)
  Class: Eq_48
  DataType: (ptr32 (ptr32 Eq_41))
  OrigDataType: (ptr32 (struct (0 T_49 t0000)))
T_49: (in Mem69[0x00403018<p32>:word32] : word32)
  Class: Eq_41
  DataType: (ptr32 Eq_41)
  OrigDataType: (ptr32 (struct (0 T_52 t0000)))
T_50: (in 0<32> : word32)
  Class: Eq_50
  DataType: word32
  OrigDataType: word32
T_51: (in Mem69[0x00403018<p32>:word32] + 0<32> : word32)
  Class: Eq_51
  DataType: word32
  OrigDataType: word32
T_52: (in Mem72[Mem69[0x00403018<p32>:word32] + 0<32>:word32] : word32)
  Class: Eq_47
  DataType: word32
  OrigDataType: word32
T_53: (in 004020E0 : ptr32)
  Class: Eq_53
  DataType: (ptr32 real64)
  OrigDataType: (ptr32 (struct (0 T_54 t0000)))
T_54: (in Mem72[0x004020E0<p32>:real64] : real64)
  Class: Eq_54
  DataType: real64
  OrigDataType: real64
T_55: (in 00403018 : ptr32)
  Class: Eq_55
  DataType: (ptr32 (ptr32 Eq_41))
  OrigDataType: (ptr32 (struct (0 T_56 t0000)))
T_56: (in Mem72[0x00403018<p32>:word32] : word32)
  Class: Eq_41
  DataType: (ptr32 Eq_41)
  OrigDataType: (ptr32 (struct (8 real64 r0008)))
T_57: (in 8<32> : word32)
  Class: Eq_57
  DataType: word32
  OrigDataType: word32
T_58: (in Mem72[0x00403018<p32>:word32] + 8<32> : word32)
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_59: (in Mem76[Mem72[0x00403018<p32>:word32] + 8<32>:real64] : real64)
  Class: Eq_54
  DataType: real64
  OrigDataType: real64
T_60: (in printf : ptr32)
  Class: Eq_60
  DataType: (ptr32 Eq_60)
  OrigDataType: (ptr32 (fn T_66 (T_64, T_65, T_44)))
T_61: (in signature of printf : void)
  Class: Eq_60
  DataType: (ptr32 Eq_60)
  OrigDataType: 
T_62: (in  : int32)
  Class: Eq_62
  DataType: int32
  OrigDataType: 
T_63: (in  : real64)
  Class: Eq_44
  DataType: real64
  OrigDataType: 
T_64: (in 0x4020D8<32> : word32)
  Class: Eq_30
  DataType: (ptr32 char)
  OrigDataType: (ptr32 char)
T_65: (in 2<32> : word32)
  Class: Eq_62
  DataType: int32
  OrigDataType: int32
T_66: (in printf("%d %f\n", 2<32>, rLoc1_116) : int32)
  Class: Eq_66
  DataType: int32
  OrigDataType: int32
T_67: (in 0<32> : word32)
  Class: Eq_2
  DataType: int32
  OrigDataType: word32
T_68: (in eax : (ptr32 Eq_11))
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: word32
T_69: (in eax_25 : (ptr32 Eq_11))
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: (ptr32 (struct (0 T_72 t0000) (8 T_86 t0008)))
T_70: (in 0<32> : word32)
  Class: Eq_70
  DataType: word32
  OrigDataType: word32
T_71: (in dwArg04 + 0<32> : word32)
  Class: Eq_71
  DataType: word32
  OrigDataType: word32
T_72: (in Mem6[dwArg04 + 0<32>:word32] : word32)
  Class: Eq_72
  DataType: int32
  OrigDataType: int32
T_73: (in 0<32> : word32)
  Class: Eq_73
  DataType: word32
  OrigDataType: word32
T_74: (in dwArg08 + 0<32> : word32)
  Class: Eq_74
  DataType: word32
  OrigDataType: word32
T_75: (in Mem6[dwArg08 + 0<32>:word32] : word32)
  Class: Eq_72
  DataType: int32
  OrigDataType: int32
T_76: (in dwArg04->dw0000 >= dwArg08->dw0000 : bool)
  Class: Eq_76
  DataType: bool
  OrigDataType: bool
T_77: (in 0<32> : word32)
  Class: Eq_77
  DataType: word32
  OrigDataType: word32
T_78: (in dwArg04 + 0<32> : word32)
  Class: Eq_78
  DataType: (ptr32 int32)
  OrigDataType: (ptr32 int32)
T_79: (in Mem6[dwArg04 + 0<32>:word32] : word32)
  Class: Eq_72
  DataType: int32
  OrigDataType: int32
T_80: (in 0<32> : word32)
  Class: Eq_80
  DataType: word32
  OrigDataType: word32
T_81: (in dwArg08 + 0<32> : word32)
  Class: Eq_81
  DataType: (ptr32 int32)
  OrigDataType: (ptr32 int32)
T_82: (in Mem6[dwArg08 + 0<32>:word32] : word32)
  Class: Eq_72
  DataType: int32
  OrigDataType: int32
T_83: (in dwArg04->dw0000 >= dwArg08->dw0000 : bool)
  Class: Eq_83
  DataType: bool
  OrigDataType: bool
T_84: (in 8<32> : word32)
  Class: Eq_84
  DataType: word32
  OrigDataType: word32
T_85: (in dwArg08 + 8<32> : word32)
  Class: Eq_85
  DataType: ptr32
  OrigDataType: ptr32
T_86: (in Mem6[dwArg08 + 8<32>:real64] : real64)
  Class: Eq_86
  DataType: real64
  OrigDataType: real64
T_87: (in 8<32> : word32)
  Class: Eq_87
  DataType: word32
  OrigDataType: word32
T_88: (in dwArg04 + 8<32> : word32)
  Class: Eq_88
  DataType: ptr32
  OrigDataType: ptr32
T_89: (in Mem6[dwArg04 + 8<32>:real64] : real64)
  Class: Eq_86
  DataType: real64
  OrigDataType: real64
T_90: (in dwArg08->r0008 <= dwArg04->r0008 : bool)
  Class: Eq_90
  DataType: bool
  OrigDataType: bool
T_91:
  Class: Eq_91
  DataType: word32
  OrigDataType: word32
T_92:
  Class: Eq_92
  DataType: word32
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
  OrigDataType: word32
T_122:
  Class: Eq_122
  DataType: word32
  OrigDataType: word32
T_123:
  Class: Eq_123
  DataType: word32
  OrigDataType: word32
T_124:
  Class: Eq_124
  DataType: word32
  OrigDataType: word32
T_125:
  Class: Eq_125
  DataType: word32
  OrigDataType: word32
T_126:
  Class: Eq_126
  DataType: word32
  OrigDataType: word32
T_127:
  Class: Eq_127
  DataType: word32
  OrigDataType: word32
T_128:
  Class: Eq_128
  DataType: word32
  OrigDataType: word32
T_129:
  Class: Eq_129
  DataType: word32
  OrigDataType: word32
T_130:
  Class: Eq_130
  DataType: word32
  OrigDataType: word32
*/
typedef struct Globals {
	<anonymous> * __imp__UnhandledExceptionFilter;	// 402000
	<anonymous> * __imp__GetCurrentProcess;	// 402004
	<anonymous> * __imp__TerminateProcess;	// 402008
	<anonymous> * __imp__GetSystemTimeAsFileTime;	// 40200C
	<anonymous> * __imp__GetCurrentProcessId;	// 402010
	<anonymous> * __imp__GetCurrentThreadId;	// 402014
	<anonymous> * __imp__GetTickCount;	// 402018
	<anonymous> * __imp__QueryPerformanceCounter;	// 40201C
	<anonymous> * __imp__SetUnhandledExceptionFilter;	// 402020
	<anonymous> * __imp__InterlockedCompareExchange;	// 402024
	<anonymous> * __imp__Sleep;	// 402028
	<anonymous> * __imp__InterlockedExchange;	// 40202C
	<anonymous> * __imp__IsDebuggerPresent;	// 402030
	<anonymous> * __imp____p__fmode;	// 402038
	<anonymous> * __imp___encode_pointer;	// 40203C
	<anonymous> * __imp____set_app_type;	// 402040
	<anonymous> * __imp__?terminate@@YAXXZ;	// 402044
	<anonymous> * __imp___unlock;	// 402048
	<anonymous> * __imp____p__commode;	// 40204C
	<anonymous> * __imp___lock;	// 402050
	<anonymous> * __imp___onexit;	// 402054
	<anonymous> * __imp___decode_pointer;	// 402058
	<anonymous> * __imp___except_handler4_common;	// 40205C
	<anonymous> * __imp___invoke_watson;	// 402060
	<anonymous> * __imp___controlfp_s;	// 402064
	<anonymous> * __imp___crt_debugger_hook;	// 402068
	<anonymous> * __imp___adjust_fdiv;	// 40206C
	<anonymous> * __imp____setusermatherr;	// 402070
	<anonymous> * __imp___configthreadlocale;	// 402074
	<anonymous> * __imp___initterm_e;	// 402078
	<anonymous> * __imp___initterm;	// 40207C
	<anonymous> * __imp____initenv;	// 402080
	<anonymous> * __imp__exit;	// 402084
	<anonymous> * __imp___XcptFilter;	// 402088
	<anonymous> * __imp___exit;	// 40208C
	<anonymous> * __imp___cexit;	// 402090
	<anonymous> * __imp____getmainargs;	// 402094
	<anonymous> * __imp___amsg_exit;	// 402098
	<anonymous> * __imp____dllonexit;	// 40209C
	<anonymous> * __imp__printf;	// 4020A0
	char str4020C8[];	// 4020C8
	char str4020D8[];	// 4020D8
	real64 r4020E0;	// 4020E0
	real64 r4020E8;	// 4020E8
	real64 r4020F0;	// 4020F0
	real64 r4020F8;	// 4020F8
	word32 dw402200;	// 402200
	word32 dw402204;	// 402204
	word32 dw402208;	// 402208
	word32 dw40220C;	// 40220C
	word32 dw402210;	// 402210
	word32 dw402214;	// 402214
	word32 dw402218;	// 402218
	word32 dw40221C;	// 40221C
	word32 dw402220;	// 402220
	word32 dw402224;	// 402224
	word32 dw402228;	// 402228
	word32 dw40222C;	// 40222C
	word32 dw402230;	// 402230
	word32 dw402238;	// 402238
	word32 dw40223C;	// 40223C
	word32 dw402240;	// 402240
	word32 dw402244;	// 402244
	word32 dw402248;	// 402248
	word32 dw40224C;	// 40224C
	word32 dw402250;	// 402250
	word32 dw402254;	// 402254
	word32 dw402258;	// 402258
	word32 dw40225C;	// 40225C
	word32 dw402260;	// 402260
	word32 dw402264;	// 402264
	word32 dw402268;	// 402268
	word32 dw40226C;	// 40226C
	word32 dw402270;	// 402270
	word32 dw402274;	// 402274
	word32 dw402278;	// 402278
	word32 dw40227C;	// 40227C
	word32 dw402280;	// 402280
	word32 dw402284;	// 402284
	word32 dw402288;	// 402288
	word32 dw40228C;	// 40228C
	word32 dw402290;	// 402290
	word32 dw402294;	// 402294
	word32 dw402298;	// 402298
	word32 dw40229C;	// 40229C
	word32 dw4022A0;	// 4022A0
	struct Eq_41 * ptr403018;	// 403018
} Eq_1;

typedef struct Eq_8 {
	word32 dw0000;	// 0
	real64 r0008;	// 8
} Eq_8;

typedef Eq_8 * (Eq_9)(Eq_11 *, Eq_11 *);

typedef struct Eq_11 {
	int32 dw0000;	// 0
	real64 r0008;	// 8
} Eq_11;

typedef int32 (Eq_28)(char *, int32, real64, int32, real64);

typedef struct Eq_41 {
	word32 dw0000;	// 0
	real64 r0008;	// 8
} Eq_41;

typedef int32 (Eq_60)(char *, int32, real64);

