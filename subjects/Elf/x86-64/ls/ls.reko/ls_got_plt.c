// ls_got_plt.c
// Generated by decompiling ls
// using Reko decompiler version 0.10.2.0.

#include "ls.h"

<anonymous> * __ctype_toupper_loc_GOT = &g_t4021A6; // 000000000061A018
<anonymous> * __uflow_GOT = &g_t4021B6; // 000000000061A020
<anonymous> * getenv_GOT = &g_t4021C6; // 000000000061A028
<anonymous> * sigprocmask_GOT = &g_t4021D6; // 000000000061A030
<anonymous> * raise_GOT = &g_t4021E6; // 000000000061A038
<anonymous> * free_GOT = &g_t4021F6; // 000000000061A040
<anonymous> * localtime_GOT = &g_t402206; // 000000000061A048
<anonymous> * __mempcpy_chk_GOT = &g_t402216; // 000000000061A050
<anonymous> * abort_GOT = &g_t402226; // 000000000061A058
<anonymous> * __errno_location_GOT = &g_t402236; // 000000000061A060
<anonymous> * strncmp_GOT = &g_t402246; // 000000000061A068
<anonymous> * _exit_GOT = &g_t402256; // 000000000061A070
<anonymous> * strcpy_GOT = &g_t402266; // 000000000061A078
<anonymous> * __fpending_GOT = &g_t402276; // 000000000061A080
<anonymous> * isatty_GOT = &g_t402286; // 000000000061A088
<anonymous> * sigaction_GOT = &g_t402296; // 000000000061A090
<anonymous> * iswcntrl_GOT = &g_t4022A6; // 000000000061A098
<anonymous> * wcswidth_GOT = &g_t4022B6; // 000000000061A0A0
<anonymous> * localeconv_GOT = &g_t4022C6; // 000000000061A0A8
<anonymous> * mbstowcs_GOT = &g_t4022D6; // 000000000061A0B0
<anonymous> * readlink_GOT = &g_t4022E6; // 000000000061A0B8
<anonymous> * clock_gettime_GOT = &g_t4022F6; // 000000000061A0C0
<anonymous> * textdomain_GOT = &g_t402306; // 000000000061A0C8
<anonymous> * fclose_GOT = &g_t402316; // 000000000061A0D0
<anonymous> * opendir_GOT = &g_t402326; // 000000000061A0D8
<anonymous> * getpwuid_GOT = &g_t402336; // 000000000061A0E0
<anonymous> * bindtextdomain_GOT = &g_t402346; // 000000000061A0E8
<anonymous> * stpcpy_GOT = &g_t402356; // 000000000061A0F0
<anonymous> * dcgettext_GOT = &g_t402366; // 000000000061A0F8
<anonymous> * __ctype_get_mb_cur_max_GOT = &g_t402376; // 000000000061A100
<anonymous> * strlen_GOT = &g_t402386; // 000000000061A108
<anonymous> * __lxstat_GOT = &g_t402396; // 000000000061A110
<anonymous> * __stack_chk_fail_GOT = &g_t4023A6; // 000000000061A118
<anonymous> * getopt_long_GOT = &g_t4023B6; // 000000000061A120
<anonymous> * mbrtowc_GOT = &g_t4023C6; // 000000000061A128
<anonymous> * strchr_GOT = &g_t4023D6; // 000000000061A130
<anonymous> * getgrgid_GOT = &g_t4023E6; // 000000000061A138
<anonymous> * _obstack_begin_GOT = &g_t4023F6; // 000000000061A140
<anonymous> * __overflow_GOT = &g_t402406; // 000000000061A148
<anonymous> * strrchr_GOT = &g_t402416; // 000000000061A150
<anonymous> * fgetfilecon_GOT = &g_t402426; // 000000000061A158
<anonymous> * lseek_GOT = &g_t402436; // 000000000061A160
<anonymous> * gettimeofday_GOT = &g_t402446; // 000000000061A168
<anonymous> * __assert_fail_GOT = &g_t402456; // 000000000061A170
<anonymous> * __strtoul_internal_GOT = &g_t402466; // 000000000061A178
<anonymous> * fnmatch_GOT = &g_t402476; // 000000000061A180
<anonymous> * memset_GOT = &g_t402486; // 000000000061A188
<anonymous> * acl_get_tag_type_GOT = &g_t402496; // 000000000061A190
<anonymous> * fscanf_GOT = &g_t4024A6; // 000000000061A198
<anonymous> * ioctl_GOT = &g_t4024B6; // 000000000061A1A0
<anonymous> * close_GOT = &g_t4024C6; // 000000000061A1A8
<anonymous> * acl_extended_file_GOT = &g_t4024D6; // 000000000061A1B0
<anonymous> * closedir_GOT = &g_t4024E6; // 000000000061A1B8
<anonymous> * __libc_start_main_GOT = &g_t4024F6; // 000000000061A1C0
<anonymous> * memcmp_GOT = &g_t402506; // 000000000061A1C8
<anonymous> * _setjmp_GOT = &g_t402516; // 000000000061A1D0
<anonymous> * fputs_unlocked_GOT = &g_t402526; // 000000000061A1D8
<anonymous> * calloc_GOT = &g_t402536; // 000000000061A1E0
<anonymous> * lgetfilecon_GOT = &g_t402546; // 000000000061A1E8
<anonymous> * strcmp_GOT = &g_t402556; // 000000000061A1F0
<anonymous> * signal_GOT = &g_t402566; // 000000000061A1F8
<anonymous> * dirfd_GOT = &g_t402576; // 000000000061A200
<anonymous> * getpwnam_GOT = &g_t402586; // 000000000061A208
<anonymous> * __memcpy_chk_GOT = &g_t402596; // 000000000061A210
<anonymous> * sigemptyset_GOT = &g_t4025A6; // 000000000061A218
<anonymous> * __gmon_start___GOT = &g_t4025B6; // 000000000061A220
<anonymous> * memcpy_GOT = &g_t4025C6; // 000000000061A228
<anonymous> * getgrnam_GOT = &g_t4025D6; // 000000000061A230
<anonymous> * getfilecon_GOT = &g_t4025E6; // 000000000061A238
<anonymous> * fileno_GOT = &g_t4025F6; // 000000000061A240
<anonymous> * tcgetpgrp_GOT = &g_t402606; // 000000000061A248
<anonymous> * __xstat_GOT = &g_t402616; // 000000000061A250
<anonymous> * readdir_GOT = &g_t402626; // 000000000061A258
<anonymous> * wcwidth_GOT = &g_t402636; // 000000000061A260
<anonymous> * malloc_GOT = &g_t402646; // 000000000061A268
<anonymous> * fflush_GOT = &g_t402656; // 000000000061A270
<anonymous> * nl_langinfo_GOT = &g_t402666; // 000000000061A278
<anonymous> * ungetc_GOT = &g_t402676; // 000000000061A280
<anonymous> * __fxstat_GOT = &g_t402686; // 000000000061A288
<anonymous> * strcoll_GOT = &g_t402696; // 000000000061A290
<anonymous> * mktime_GOT = &g_t4026A6; // 000000000061A298
<anonymous> * __freading_GOT = &g_t4026B6; // 000000000061A2A0
<anonymous> * fwrite_unlocked_GOT = &g_t4026C6; // 000000000061A2A8
<anonymous> * acl_get_entry_GOT = &g_t4026D6; // 000000000061A2B0
<anonymous> * realloc_GOT = &g_t4026E6; // 000000000061A2B8
<anonymous> * stpncpy_GOT = &g_t4026F6; // 000000000061A2C0
<anonymous> * fdopen_GOT = &g_t402706; // 000000000061A2C8
<anonymous> * setlocale_GOT = &g_t402716; // 000000000061A2D0
<anonymous> * _obstack_newchunk_GOT = &g_t402726; // 000000000061A2D8
<anonymous> * __printf_chk_GOT = &g_t402736; // 000000000061A2E0
<anonymous> * strftime_GOT = &g_t402746; // 000000000061A2E8
<anonymous> * mempcpy_GOT = &g_t402756; // 000000000061A2F0
<anonymous> * memmove_GOT = &g_t402766; // 000000000061A2F8
<anonymous> * error_GOT = &g_t402776; // 000000000061A300
<anonymous> * open_GOT = &g_t402786; // 000000000061A308
<anonymous> * fseeko_GOT = &g_t402796; // 000000000061A310
<anonymous> * strtoul_GOT = &g_t4027A6; // 000000000061A318
<anonymous> * __cxa_atexit_GOT = &g_t4027B6; // 000000000061A320
<anonymous> * wcstombs_GOT = &g_t4027C6; // 000000000061A328
<anonymous> * freecon_GOT = &g_t4027D6; // 000000000061A330
<anonymous> * sigismember_GOT = &g_t4027E6; // 000000000061A338
<anonymous> * exit_GOT = &g_t4027F6; // 000000000061A340
<anonymous> * fwrite_GOT = &g_t402806; // 000000000061A348
<anonymous> * __fprintf_chk_GOT = &g_t402816; // 000000000061A350
<anonymous> * fflush_unlocked_GOT = &g_t402826; // 000000000061A358
<anonymous> * mbsinit_GOT = &g_t402836; // 000000000061A360
<anonymous> * iswprint_GOT = &g_t402846; // 000000000061A368
<anonymous> * sigaddset_GOT = &g_t402856; // 000000000061A370
<anonymous> * strstr_GOT = &g_t402866; // 000000000061A378
<anonymous> * __ctype_tolower_loc_GOT = &g_t402876; // 000000000061A380
<anonymous> * __ctype_b_loc_GOT = &g_t402886; // 000000000061A388
<anonymous> * __sprintf_chk_GOT = &g_t402896; // 000000000061A390
