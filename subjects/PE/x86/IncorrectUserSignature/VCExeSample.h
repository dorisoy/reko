// VCExeSample.h
// Generated by decompiling VCExeSample.exe
// using Reko decompiler version 0.10.2.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (402000 (ptr32 code) __imp__UnhandledExceptionFilter) (402004 (ptr32 code) __imp__GetCurrentProcess) (402008 (ptr32 code) __imp__TerminateProcess) (40200C (ptr32 code) __imp__GetSystemTimeAsFileTime) (402010 (ptr32 code) __imp__GetCurrentProcessId) (402014 (ptr32 code) __imp__GetCurrentThreadId) (402018 (ptr32 code) __imp__GetTickCount) (40201C (ptr32 code) __imp__QueryPerformanceCounter) (402020 (ptr32 code) __imp__SetUnhandledExceptionFilter) (402024 (ptr32 code) __imp__InterlockedCompareExchange) (402028 (ptr32 code) __imp__Sleep) (40202C (ptr32 code) __imp__InterlockedExchange) (402030 (ptr32 code) __imp__IsDebuggerPresent) (402038 (ptr32 code) __imp____p__fmode) (40203C (ptr32 code) __imp___encode_pointer) (402040 (ptr32 code) __imp____set_app_type) (402044 (ptr32 code) __imp__?terminate@@YAXXZ) (402048 (ptr32 code) __imp___unlock) (40204C (ptr32 code) __imp____p__commode) (402050 (ptr32 code) __imp___lock) (402054 (ptr32 code) __imp___onexit) (402058 (ptr32 code) __imp___decode_pointer) (40205C (ptr32 code) __imp___except_handler4_common) (402060 (ptr32 code) __imp___invoke_watson) (402064 (ptr32 code) __imp___controlfp_s) (402068 (ptr32 code) __imp___crt_debugger_hook) (40206C (ptr32 code) __imp___adjust_fdiv) (402070 (ptr32 code) __imp____setusermatherr) (402074 (ptr32 code) __imp___configthreadlocale) (402078 (ptr32 code) __imp___initterm_e) (40207C (ptr32 code) __imp___initterm) (402080 (ptr32 code) __imp____initenv) (402084 (ptr32 code) __imp__exit) (402088 (ptr32 code) __imp___XcptFilter) (40208C (ptr32 code) __imp___exit) (402090 (ptr32 code) __imp___cexit) (402094 (ptr32 code) __imp____getmainargs) (402098 (ptr32 code) __imp___amsg_exit) (40209C (ptr32 code) __imp____dllonexit) (4020A0 (ptr32 code) __imp__printf) (402210 word32 dw402210) (402214 word32 dw402214) (402218 word32 dw402218) (40221C word32 dw40221C) (402220 word32 dw402220) (402224 word32 dw402224) (402228 word32 dw402228) (40222C word32 dw40222C) (402230 word32 dw402230) (402234 word32 dw402234) (402238 word32 dw402238) (40223C word32 dw40223C) (402240 word32 dw402240) (402248 word32 dw402248) (40224C word32 dw40224C) (402250 word32 dw402250) (402254 word32 dw402254) (402258 word32 dw402258) (40225C word32 dw40225C) (402260 word32 dw402260) (402264 word32 dw402264) (402268 word32 dw402268) (40226C word32 dw40226C) (402270 word32 dw402270) (402274 word32 dw402274) (402278 word32 dw402278) (40227C word32 dw40227C) (402280 word32 dw402280) (402284 word32 dw402284) (402288 word32 dw402288) (40228C word32 dw40228C) (402290 word32 dw402290) (402294 word32 dw402294) (402298 word32 dw402298) (40229C word32 dw40229C) (4022A0 word32 dw4022A0) (4022A4 word32 dw4022A4) (4022A8 word32 dw4022A8) (4022AC word32 dw4022AC) (4022B0 word32 dw4022B0))
	globals_t (in globals @ 00000000 : (ptr32 (struct "Globals")))
Eq_2: cdecl_class
	T_2 (in c @ 00000000 : (ptr32 Eq_2))
Eq_5: cdecl_class
	T_5 (in c @ 00401138 : (ptr32 cdecl_class))
Eq_7: cdecl_class_vtbl
	T_7 (in c + 0<32> @ 00401138 : word32)
Eq_8: cdecl_class_vtbl
	T_8 (in Mem19[c + 0<32>:word32] @ 00401138 : word32)
Eq_10: (fn void ((ptr32 cdecl_class), int32, int32))
	T_10 (in Mem19[c + 0<32>:word32] + 8<32> @ 00401138 : word32)
Eq_11: (fn void ((ptr32 cdecl_class), int32, int32))
	T_11 (in Mem19[Mem19[c + 0<32>:word32] + 8<32>:word32] @ 00401138 : word32)
Eq_19: (struct "Eq_19" (4 (ptr32 Eq_22) ptr0004))
	T_19 (in Mem37[c + 0<32>:word32] @ 00401150 : word32)
Eq_22: (fn void ((ptr32 Eq_5), word32))
	T_22 (in Mem37[Mem37[c + 0<32>:word32] + 4<32>:word32] @ 00401150 : word32)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in c @ 00000000 : (ptr32 Eq_2))
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 cdecl_class)
T_3: (in a @ 00000000 : int32)
  Class: Eq_3
  DataType: int32
  OrigDataType: int32
T_4: (in b @ 00000000 : int32)
  Class: Eq_4
  DataType: int32
  OrigDataType: int32
T_5: (in c @ 00401138 : (ptr32 cdecl_class))
  Class: Eq_5
  DataType: (ptr32 Eq_5)
  OrigDataType: (ptr32 cdecl_class)
T_6: (in 0<32> @ 00401138 : word32)
  Class: Eq_6
  DataType: word32
  OrigDataType: word32
T_7: (in c + 0<32> @ 00401138 : word32)
  Class: Eq_7
  DataType: (ptr32 (ptr32 Eq_7))
  OrigDataType: (ptr32 (ptr32 cdecl_class_vtbl))
T_8: (in Mem19[c + 0<32>:word32] @ 00401138 : word32)
  Class: Eq_8
  DataType: (ptr32 Eq_8)
  OrigDataType: (ptr32 (union (cdecl_class_vtbl u1)))
T_9: (in 8<32> @ 00401138 : word32)
  Class: Eq_9
  DataType: word32
  OrigDataType: word32
T_10: (in Mem19[c + 0<32>:word32] + 8<32> @ 00401138 : word32)
  Class: Eq_10
  DataType: (ptr32 (ptr32 Eq_10))
  OrigDataType: (ptr32 (ptr32 (fn void ((ptr32 cdecl_class), int32, int32))))
T_11: (in Mem19[Mem19[c + 0<32>:word32] + 8<32>:word32] @ 00401138 : word32)
  Class: Eq_11
  DataType: (ptr32 Eq_11)
  OrigDataType: (ptr32 (fn T_14 ((ptr32 cdecl_class), int32, int32)))
T_12: (in a @ 00401138 : int32)
  Class: Eq_12
  DataType: int32
  OrigDataType: int32
T_13: (in b @ 00401138 : int32)
  Class: Eq_13
  DataType: int32
  OrigDataType: int32
T_14: (in c->vtbl->sum(c, a, b) @ 00401138 : void)
  Class: Eq_14
  DataType: void
  OrigDataType: void
T_15: (in eax_25 @ 00401138 : word32)
  Class: Eq_15
  DataType: word32
  OrigDataType: word32
T_16: (in <invalid> @ 00401138 : word32)
  Class: Eq_15
  DataType: word32
  OrigDataType: word32
T_17: (in 0<32> @ 00401150 : word32)
  Class: Eq_17
  DataType: word32
  OrigDataType: word32
T_18: (in c + 0<32> @ 00401150 : word32)
  Class: Eq_18
  DataType: ptr32
  OrigDataType: ptr32
T_19: (in Mem37[c + 0<32>:word32] @ 00401150 : word32)
  Class: Eq_19
  DataType: (ptr32 Eq_19)
  OrigDataType: (ptr32 (struct (4 T_22 t0004)))
T_20: (in 4<32> @ 00401150 : word32)
  Class: Eq_20
  DataType: word32
  OrigDataType: word32
T_21: (in Mem37[c + 0<32>:word32] + 4<32> @ 00401150 : word32)
  Class: Eq_21
  DataType: word32
  OrigDataType: word32
T_22: (in Mem37[Mem37[c + 0<32>:word32] + 4<32>:word32] @ 00401150 : word32)
  Class: Eq_22
  DataType: (ptr32 Eq_22)
  OrigDataType: (ptr32 (fn T_23 (T_5, T_15)))
T_23: (in c->vtbl->method04(c, eax_25) @ 00401150 : void)
  Class: Eq_23
  DataType: void
  OrigDataType: void
T_24:
  Class: Eq_24
  DataType: word32
  OrigDataType: word32
T_25:
  Class: Eq_25
  DataType: word32
  OrigDataType: word32
T_26:
  Class: Eq_26
  DataType: word32
  OrigDataType: word32
T_27:
  Class: Eq_27
  DataType: word32
  OrigDataType: word32
T_28:
  Class: Eq_28
  DataType: word32
  OrigDataType: word32
T_29:
  Class: Eq_29
  DataType: word32
  OrigDataType: word32
T_30:
  Class: Eq_30
  DataType: word32
  OrigDataType: word32
T_31:
  Class: Eq_31
  DataType: word32
  OrigDataType: word32
T_32:
  Class: Eq_32
  DataType: word32
  OrigDataType: word32
T_33:
  Class: Eq_33
  DataType: word32
  OrigDataType: word32
T_34:
  Class: Eq_34
  DataType: word32
  OrigDataType: word32
T_35:
  Class: Eq_35
  DataType: word32
  OrigDataType: word32
T_36:
  Class: Eq_36
  DataType: word32
  OrigDataType: word32
T_37:
  Class: Eq_37
  DataType: word32
  OrigDataType: word32
T_38:
  Class: Eq_38
  DataType: word32
  OrigDataType: word32
T_39:
  Class: Eq_39
  DataType: word32
  OrigDataType: word32
T_40:
  Class: Eq_40
  DataType: word32
  OrigDataType: word32
T_41:
  Class: Eq_41
  DataType: word32
  OrigDataType: word32
T_42:
  Class: Eq_42
  DataType: word32
  OrigDataType: word32
T_43:
  Class: Eq_43
  DataType: word32
  OrigDataType: word32
T_44:
  Class: Eq_44
  DataType: word32
  OrigDataType: word32
T_45:
  Class: Eq_45
  DataType: word32
  OrigDataType: word32
T_46:
  Class: Eq_46
  DataType: word32
  OrigDataType: word32
T_47:
  Class: Eq_47
  DataType: word32
  OrigDataType: word32
T_48:
  Class: Eq_48
  DataType: word32
  OrigDataType: word32
T_49:
  Class: Eq_49
  DataType: word32
  OrigDataType: word32
T_50:
  Class: Eq_50
  DataType: word32
  OrigDataType: word32
T_51:
  Class: Eq_51
  DataType: word32
  OrigDataType: word32
T_52:
  Class: Eq_52
  DataType: word32
  OrigDataType: word32
T_53:
  Class: Eq_53
  DataType: word32
  OrigDataType: word32
T_54:
  Class: Eq_54
  DataType: word32
  OrigDataType: word32
T_55:
  Class: Eq_55
  DataType: word32
  OrigDataType: word32
T_56:
  Class: Eq_56
  DataType: word32
  OrigDataType: word32
T_57:
  Class: Eq_57
  DataType: word32
  OrigDataType: word32
T_58:
  Class: Eq_58
  DataType: word32
  OrigDataType: word32
T_59:
  Class: Eq_59
  DataType: word32
  OrigDataType: word32
T_60:
  Class: Eq_60
  DataType: word32
  OrigDataType: word32
T_61:
  Class: Eq_61
  DataType: word32
  OrigDataType: word32
T_62:
  Class: Eq_62
  DataType: word32
  OrigDataType: word32
T_63:
  Class: Eq_63
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
	word32 dw402210;	// 402210
	word32 dw402214;	// 402214
	word32 dw402218;	// 402218
	word32 dw40221C;	// 40221C
	word32 dw402220;	// 402220
	word32 dw402224;	// 402224
	word32 dw402228;	// 402228
	word32 dw40222C;	// 40222C
	word32 dw402230;	// 402230
	word32 dw402234;	// 402234
	word32 dw402238;	// 402238
	word32 dw40223C;	// 40223C
	word32 dw402240;	// 402240
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
	word32 dw4022A4;	// 4022A4
	word32 dw4022A8;	// 4022A8
	word32 dw4022AC;	// 4022AC
	word32 dw4022B0;	// 4022B0
} Eq_1;

typedef cdecl_class Eq_2;

typedef cdecl_class Eq_5;

typedef cdecl_class_vtbl Eq_7;

typedef cdecl_class_vtbl Eq_8;

typedef void (Eq_10)(cdecl_class * ptrArg04, int32 dwArg08, int32 dwArg0C);

typedef void (Eq_11)(cdecl_class * ptrArg04, int32 dwArg08, int32 dwArg0C);

typedef struct Eq_19 {
	void (* ptr0004)(cdecl_class *, word32);	// 4
} Eq_19;

typedef void (Eq_22)(cdecl_class *, word32);

