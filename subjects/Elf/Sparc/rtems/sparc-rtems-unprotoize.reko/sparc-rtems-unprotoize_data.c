// sparc-rtems-unprotoize_data.c
// Generated by decompiling sparc-rtems-unprotoize
// using Reko decompiler version 0.10.2.0.

#include "sparc-rtems-unprotoize.h"

Eq_n g_t27ED0 = // 00027ED0
	{
		&g_str17040
	};
word32 errors = 0x00; // 00027F20
word32 compiler_file_name = 0x00017098; // 00027F24
word32 version_flag = 0x00; // 00027F28
word32 quiet_flag = 0x00; // 00027F2C
word32 nochange_flag = 0x00; // 00027F30
word32 nosave_flag = 0x00; // 00027F34
word32 keep_flag = 0x00; // 00027F38
Eq_n compile_params = // 00027F3C
	{
		null
	};
word32 indent_string = 0x000170A0; // 00027F40
word32 input_file_name_index = 0x00; // 00027F44
ui32 aux_info_file_name_index = 0x00; // 00027F48
ui32 n_base_source_files = 0x00; // 00027F4C
Eq_n line_buf.78 = // 00027F50
	{
		null
	};
Eq_n line_buf_size.79 = // 00027F54
	{
		null
	};
Eq_n g_t28000 = // 00028000
	{
		null,
	};
char * version_string = &g_str178B0; // 00028028
<anonymous> * obstack_alloc_failed_handler = print_and_abort; // 0002802C
int32 obstack_exit_failure = 1; // 00028030
Eq_n optarg = // 00028064
	{
		null
	};
ptr32 * optind = &g_ptr0001; // 00028068
word32 __getopt_initialized = 0x00; // 0002806C
word32 opterr = 0x01; // 00028070
Eq_n optopt = // 00028074
	{
		'\0'
	};
char * install_error_msg = &g_str17AF0; // 00028078
