// varargs_test.globals.c
// Generated by decompiling varargs_test.exe
// using Reko decompiler version 0.9.4.0.

#include "varargs_test.h"

word16 g_w40000000; // 0000000040000000
word32 g_dw4000003C; // 000000004000003C
int32 g_t40001ABC(struct _exception * rcx); // 0000000040001ABC
LONG g_t40001B24(struct _EXCEPTION_POINTERS * ExceptionInfo); // 0000000040001B24
<anonymous> * __imp__RtlLookupFunctionEntry; // 0000000040002000
<anonymous> * __imp__RtlVirtualUnwind; // 0000000040002008
<anonymous> * __imp__UnhandledExceptionFilter; // 0000000040002010
<anonymous> * __imp__GetModuleHandleW; // 0000000040002018
<anonymous> * __imp__IsDebuggerPresent; // 0000000040002020
<anonymous> * __imp__InitializeSListHead; // 0000000040002028
<anonymous> * __imp__GetSystemTimeAsFileTime; // 0000000040002030
<anonymous> * __imp__GetCurrentThreadId; // 0000000040002038
<anonymous> * __imp__GetCurrentProcessId; // 0000000040002040
<anonymous> * __imp__QueryPerformanceCounter; // 0000000040002048
<anonymous> * __imp__IsProcessorFeaturePresent; // 0000000040002050
<anonymous> * __imp__TerminateProcess; // 0000000040002058
<anonymous> * __imp__GetCurrentProcess; // 0000000040002060
<anonymous> * __imp__SetUnhandledExceptionFilter; // 0000000040002068
<anonymous> * __imp__RtlCaptureContext; // 0000000040002070
<anonymous> * __imp__memset; // 0000000040002080
<anonymous> * __imp____C_specific_handler; // 0000000040002088
<anonymous> * __imp___set_new_mode; // 0000000040002098
<anonymous> * __imp___configthreadlocale; // 00000000400020A8
<anonymous> * __imp____setusermatherr; // 00000000400020B8
<anonymous> * __imp___cexit; // 00000000400020C8
<anonymous> * __imp___register_onexit_function; // 00000000400020D0
<anonymous> * __imp___crt_atexit; // 00000000400020D8
<anonymous> * __imp__terminate; // 00000000400020E0
<anonymous> * __imp___set_app_type; // 00000000400020E8
<anonymous> * __imp___seh_filter_exe; // 00000000400020F0
<anonymous> * __imp___register_thread_local_exe_atexit_callback; // 00000000400020F8
<anonymous> * __imp____p___argv; // 0000000040002100
<anonymous> * __imp____p___argc; // 0000000040002108
<anonymous> * __imp___c_exit; // 0000000040002110
<anonymous> * __imp___exit; // 0000000040002118
<anonymous> * __imp__exit; // 0000000040002120
<anonymous> * __imp___initterm_e; // 0000000040002128
<anonymous> * __imp___initterm; // 0000000040002130
<anonymous> * __imp___get_initial_narrow_environment; // 0000000040002138
<anonymous> * __imp___initialize_narrow_environment; // 0000000040002140
<anonymous> * __imp___configure_narrow_argv; // 0000000040002148
<anonymous> * __imp___initialize_onexit_table; // 0000000040002150
<anonymous> * __imp____p__commode; // 0000000040002160
<anonymous> * __imp____stdio_common_vfscanf; // 0000000040002168
<anonymous> * __imp____stdio_common_vfprintf; // 0000000040002170
<anonymous> * __imp____acrt_iob_func; // 0000000040002178
<anonymous> * __imp___set_fmode; // 0000000040002180
<anonymous> * g_ptr40002190; // 0000000040002190
PVFV g_t400021A0; // 00000000400021A0
PVFV g_t400021B0; // 00000000400021B0
PVFV g_t400021B8; // 00000000400021B8
PVFV g_t400021D0; // 00000000400021D0
struct _EXCEPTION_POINTERS g_t40002200;
word64 g_qw40002680; // 0000000040002680
word64 g_qw40002690; // 0000000040002690
word64 g_qw40002830; // 0000000040002830
word64 g_qw40002838; // 0000000040002838
word64 g_qw40002840; // 0000000040002840
word64 g_qw40002848; // 0000000040002848
word64 g_qw40002850; // 0000000040002850
word64 g_qw40002858; // 0000000040002858
word64 g_qw40002860; // 0000000040002860
word64 g_qw40002868; // 0000000040002868
word64 g_qw40002870; // 0000000040002870
word64 g_qw40002878; // 0000000040002878
word64 g_qw40002880; // 0000000040002880
word64 g_qw40002888; // 0000000040002888
word64 g_qw40002890; // 0000000040002890
word64 g_qw40002898; // 0000000040002898
word64 g_qw400028A0; // 00000000400028A0
word64 g_qw400028B0; // 00000000400028B0
word64 g_qw400028B8; // 00000000400028B8
word64 g_qw400028C8; // 00000000400028C8
word64 g_qw400028D8; // 00000000400028D8
word64 g_qw400028E8; // 00000000400028E8
word64 g_qw400028F8; // 00000000400028F8
word64 g_qw40002900; // 0000000040002900
word64 g_qw40002908; // 0000000040002908
word64 g_qw40002910; // 0000000040002910
word64 g_qw40002918; // 0000000040002918
word64 g_qw40002920; // 0000000040002920
word64 g_qw40002928; // 0000000040002928
word64 g_qw40002930; // 0000000040002930
word64 g_qw40002938; // 0000000040002938
word64 g_qw40002940; // 0000000040002940
word64 g_qw40002948; // 0000000040002948
word64 g_qw40002950; // 0000000040002950
word64 g_qw40002958; // 0000000040002958
word64 g_qw40002960; // 0000000040002960
word64 g_qw40002968; // 0000000040002968
word64 g_qw40002970; // 0000000040002970
word64 g_qw40002978; // 0000000040002978
word64 g_qw40002980; // 0000000040002980
word64 g_qw40002990; // 0000000040002990
word64 g_qw40002998; // 0000000040002998
word64 g_qw400029A0; // 00000000400029A0
word64 g_qw400029A8; // 00000000400029A8
word64 g_qw400029B0; // 00000000400029B0
ui64 g_qw40003000; // 0000000040003000
word64 g_qw40003008; // 0000000040003008
word32 g_dw40003014; // 0000000040003014
word32 g_dw40003018; // 0000000040003018
ui32 g_dw4000301C; // 000000004000301C
word64 g_qw40003020; // 0000000040003020
word32 g_dw40003030; // 0000000040003030
word32 g_dw40003040; // 0000000040003040
word32 g_dw40003044; // 0000000040003044
word64 g_qw40003050; // 0000000040003050
word32 g_dw40003058; // 0000000040003058
word64 g_qw40003060; // 0000000040003060
CONTEXT g_t400030E0;
ui64 g_qw40003160; // 0000000040003160
ptr64 g_ptr40003178; // 0000000040003178
word64 g_qw400031D8; // 00000000400031D8
word32 g_dw400035B0; // 00000000400035B0
uint64 g_qw400035B8; // 00000000400035B8
Eq_n g_t400035C0;
real64 g_r400035D0; // 00000000400035D0
uint128 g_ow400035D8;
real64 g_r400035E8; // 00000000400035E8
byte g_b400035F0; // 00000000400035F0
union _SLIST_HEADER g_u40003600;
ui32 g_dw40003610; // 0000000040003610
ui32 g_dw40003614; // 0000000040003614
