// Demo.h
// Generated by decompiling Demo.exe
// using Reko decompiler version 0.10.0.0.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (403000 CHAR t403000) (403007 CHAR t403007))
	globals_t (in globals @ 00000000 : (ptr32 (struct "Globals")))
Eq_2: (fn void (Eq_4))
	T_2 (in ExitProcess @ 00401014 : ptr32)
	T_3 (in signature of ExitProcess @ 00000000 : void)
Eq_4: (union "Eq_4" (int32 u0) (UINT u1))
	T_4 (in uExitCode @ 00401014 : UINT)
	T_10 (in uType @ 00401014 : UINT)
	T_14 (in 0<32> @ 00401014 : word32)
	T_15 (in MessageBoxA(null, &g_t403000, &g_t403007, 0<32>) @ 00401014 : int32)
Eq_5: (fn Eq_4 (Eq_7, Eq_8, Eq_8, Eq_4))
	T_5 (in MessageBoxA @ 00401014 : ptr32)
	T_6 (in signature of MessageBoxA @ 00000000 : void)
Eq_7: HWND
	T_7 (in hWnd @ 00401014 : HWND)
	T_11 (in 0<32> @ 00401014 : word32)
Eq_8: LPCSTR
	T_8 (in lpText @ 00401014 : LPCSTR)
	T_9 (in lpCaption @ 00401014 : LPCSTR)
	T_12 (in 0x403000<32> @ 00401014 : word32)
	T_13 (in 0x403007<32> @ 00401014 : word32)
// Type Variables ////////////
globals_t: (in globals @ 00000000 : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in ExitProcess @ 00401014 : ptr32)
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: (ptr32 (fn T_16 (T_15)))
T_3: (in signature of ExitProcess @ 00000000 : void)
  Class: Eq_2
  DataType: (ptr32 Eq_2)
  OrigDataType: 
T_4: (in uExitCode @ 00401014 : UINT)
  Class: Eq_4
  DataType: Eq_4
  OrigDataType: 
T_5: (in MessageBoxA @ 00401014 : ptr32)
  Class: Eq_5
  DataType: (ptr32 Eq_5)
  OrigDataType: (ptr32 (fn T_15 (T_11, T_12, T_13, T_14)))
T_6: (in signature of MessageBoxA @ 00000000 : void)
  Class: Eq_5
  DataType: (ptr32 Eq_5)
  OrigDataType: 
T_7: (in hWnd @ 00401014 : HWND)
  Class: Eq_7
  DataType: Eq_7
  OrigDataType: 
T_8: (in lpText @ 00401014 : LPCSTR)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: 
T_9: (in lpCaption @ 00401014 : LPCSTR)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: 
T_10: (in uType @ 00401014 : UINT)
  Class: Eq_4
  DataType: Eq_4
  OrigDataType: 
T_11: (in 0<32> @ 00401014 : word32)
  Class: Eq_7
  DataType: Eq_7
  OrigDataType: HWND
T_12: (in 0x403000<32> @ 00401014 : word32)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: LPCSTR
T_13: (in 0x403007<32> @ 00401014 : word32)
  Class: Eq_8
  DataType: Eq_8
  OrigDataType: LPCSTR
T_14: (in 0<32> @ 00401014 : word32)
  Class: Eq_4
  DataType: int32
  OrigDataType: UINT
T_15: (in MessageBoxA(null, &g_t403000, &g_t403007, 0<32>) @ 00401014 : int32)
  Class: Eq_4
  DataType: Eq_4
  OrigDataType: (union (int32 u0) (UINT u2))
T_16: (in ExitProcess(MessageBoxA(null, &g_t403000, &g_t403007, 0<32>)) @ 00401014 : void)
  Class: Eq_16
  DataType: void
  OrigDataType: void
*/
typedef struct Globals {
	CHAR t403000;	// 403000
	CHAR t403007;	// 403007
} Eq_1;

typedef void (Eq_2)(Eq_4);

typedef union Eq_4 {
	int32 u0;
	UINT u1;
} Eq_4;

typedef Eq_4 (Eq_5)(HWND, LPCSTR, LPCSTR, Eq_4);

typedef HWND Eq_7;

typedef LPCSTR Eq_8;

