// MachO-OSX-x64-ls_TEXT_stubs.c
// Generated by decompiling MachO-OSX-x64-ls
// using Reko decompiler version 0.11.1.0.

#include "MachO-OSX-x64-ls.h"

// 0000000100004DAE: void __error()
// Called from:
//      fn00000001000023B0
//      fn0000000100003AA8
void __error()
{
	__error();
}

// 0000000100004DB4: void __maskrune()
// Called from:
//      fn000000010000356F
//      fn0000000100004715
//      fn000000010000488B
//      fn0000000100004AFA
void __maskrune()
{
	__maskrune();
}

// 0000000100004DBA: void __snprintf_chk(Register Eq_n rcx, Register word32 edx, Register Eq_n rsi, Register Eq_n rdi, Register (ptr64 char) r8)
// Called from:
//      fn0000000100003AA8
void __snprintf_chk(Eq_n rcx, word32 edx, Eq_n rsi, Eq_n rdi, char * r8)
{
	word64 rdx;
	__snprintf_chk(rdi, rsi, (int32) rdx, rcx, r8, 0x00);
}

// 0000000100004DC0: void __stack_chk_fail()
// Called from:
//      fn0000000100001B4A
//      fn0000000100003AA8
void __stack_chk_fail()
{
	__stack_chk_fail();
}

// 0000000100004DC6: void __tolower()
// Called from:
//      fn000000010000328E
void __tolower()
{
	__tolower();
}

// 0000000100004DCC: void acl_free()
// Called from:
//      fn0000000100003AA8
void acl_free()
{
	acl_free();
}

// 0000000100004DD2: Register int32 acl_get_entry(Register (ptr64 Eq_n) rdx, Register int32 esi, Register Eq_n rdi)
// Called from:
//      fn0000000100003AA8
int32 acl_get_entry(struct acl_entry_t * rdx, int32 esi, Eq_n rdi)
{
	word64 rsi;
	return acl_get_entry(rdi, (int32) rsi, rdx);
}

// 0000000100004DD8: void acl_get_flag_np()
// Called from:
//      fn0000000100003AA8
void acl_get_flag_np()
{
	acl_get_flag_np();
}

// 0000000100004DDE: void acl_get_flagset_np()
// Called from:
//      fn0000000100003AA8
void acl_get_flagset_np()
{
	acl_get_flagset_np();
}

// 0000000100004DE4: void acl_get_link_np()
// Called from:
//      fn0000000100003AA8
void acl_get_link_np()
{
	acl_get_link_np();
}

// 0000000100004DEA: void acl_get_perm_np()
// Called from:
//      fn0000000100003AA8
void acl_get_perm_np()
{
	acl_get_perm_np();
}

// 0000000100004DF0: void acl_get_permset()
// Called from:
//      fn0000000100003AA8
void acl_get_permset()
{
	acl_get_permset();
}

// 0000000100004DF6: void acl_get_qualifier()
// Called from:
//      fn0000000100003AA8
void acl_get_qualifier()
{
	acl_get_qualifier();
}

// 0000000100004DFC: Register int32 acl_get_tag_type(Register (ptr64 Eq_n) rsi, Register word32 edi)
// Called from:
//      fn0000000100003AA8
int32 acl_get_tag_type(acl_tag_t * rsi, word32 edi)
{
	word64 rdi;
	return acl_get_tag_type((acl_entry_t) rdi, rsi);
}

// 0000000100004E02: Register int32 atoi(Register Eq_n rdi)
// Called from:
//      fn00000001000026A0
int32 atoi(Eq_n rdi)
{
	return atoi(rdi);
}

// 0000000100004E08: void compat_mode()
// Called from:
//      fn00000001000023B0
//      fn00000001000026A0
//      fn0000000100003AA8
void compat_mode()
{
	compat_mode();
}

// 0000000100004E0E: void err()
// Called from:
//      fn0000000100001B4A
//      fn00000001000023B0
//      fn0000000100003AA8
void err()
{
	err();
}

// 0000000100004E14: void exit(Register word32 edi)
// Called from:
//      fn0000000100001778
//      fn00000001000026A0
//      fn000000010000488B
void exit(word32 edi)
{
	word64 rdi;
	exit((int32) rdi);
}

// 0000000100004E1A: void fflagstostr()
// Called from:
//      fn0000000100001B4A
void fflagstostr()
{
	fflagstostr();
}

// 0000000100004E20: void fprintf(Register (ptr64 char) rsi, Register (ptr64 Eq_n) rdi)
// Called from:
//      fn000000010000328E
//      fn0000000100003AA8
void fprintf(char * rsi, FILE * rdi)
{
	fprintf(rdi, rsi, 0x00);
}

// 0000000100004E26: void fputs(Register (ptr64 Eq_n) rsi, Register (ptr64 char) rdi)
// Called from:
//      fn000000010000328E
//      fn0000000100003AA8
//      fn000000010000488B
void fputs(FILE * rsi, char * rdi)
{
	fputs(rdi, rsi);
}

// 0000000100004E2C: void free(Register Eq_n rdi)
// Called from:
//      fn0000000100001B4A
//      fn0000000100003AA8
void free(Eq_n rdi)
{
	free(rdi);
}

// 0000000100004E32: void fts_children$INODE64()
// Called from:
//      fn00000001000023B0
void fts_children$INODE64()
{
	fts_children$INODE64();
}

// 0000000100004E38: void fts_close$INODE64()
// Called from:
//      fn00000001000023B0
void fts_close$INODE64()
{
	fts_close$INODE64();
}

// 0000000100004E3E: void fts_open$INODE64()
// Called from:
//      fn00000001000023B0
void fts_open$INODE64()
{
	fts_open$INODE64();
}

// 0000000100004E44: void fts_read$INODE64()
// Called from:
//      fn00000001000023B0
void fts_read$INODE64()
{
	fts_read$INODE64();
}

// 0000000100004E4A: void fts_set$INODE64()
// Called from:
//      fn00000001000023B0
void fts_set$INODE64()
{
	fts_set$INODE64();
}

// 0000000100004E50: void getbsize()
// Called from:
//      fn00000001000026A0
void getbsize()
{
	getbsize();
}

// 0000000100004E56: Register (ptr64 char) getenv(Register (ptr64 char) rdi)
// Called from:
//      fn0000000100001B4A
//      fn00000001000026A0
char * getenv(char * rdi)
{
	return getenv(rdi);
}

// 0000000100004E5C: Register (ptr64 Eq_n) getgrgid(Register word32 edi)
// Called from:
//      fn0000000100003AA8
struct group * getgrgid(word32 edi)
{
	word64 rdi;
	return getgrgid((gid_t) rdi);
}

// 0000000100004E62: Register int32 getopt(Register (ptr64 char) rdx, Register (ptr64 (ptr64 char)) rsi, Register int32 edi)
// Called from:
//      fn00000001000026A0
int32 getopt(char * rdx, char ** rsi, int32 edi)
{
	word64 rdi;
	return getopt((int32) rdi, rsi, rdx);
}

// 0000000100004E68: void getpid()
void getpid()
{
	getpid();
}

// 0000000100004E6E: Register (ptr64 Eq_n) getpwuid(Register word32 edi)
// Called from:
//      fn0000000100003AA8
struct passwd * getpwuid(word32 edi)
{
	word64 rdi;
	return getpwuid((uid_t) rdi);
}

// 0000000100004E74: Register Eq_n getuid()
// Called from:
//      fn00000001000026A0
Eq_n getuid()
{
	return getuid();
}

// 0000000100004E7A: void getxattr()
// Called from:
//      fn0000000100003AA8
void getxattr()
{
	getxattr();
}

// 0000000100004E80: void group_from_gid()
// Called from:
//      fn0000000100001B4A
void group_from_gid()
{
	group_from_gid();
}

// 0000000100004E86: void humanize_number()
// Called from:
//      fn0000000100003786
void humanize_number()
{
	humanize_number();
}

// 0000000100004E8C: Register int32 ioctl(Register word32 esi, Register word32 edi)
// Called from:
//      fn00000001000026A0
int32 ioctl(word32 esi, word32 edi)
{
	word64 rdi;
	word64 rsi;
	return ioctl((int32) rdi, (uint32) rsi, 0x00);
}

// 0000000100004E92: Register int32 isatty(Register word32 edi)
// Called from:
//      fn00000001000026A0
int32 isatty(word32 edi)
{
	word64 rdi;
	return isatty((int32) rdi);
}

// 0000000100004E98: void kill()
void kill()
{
	kill();
}

// 0000000100004E9E: void listxattr()
// Called from:
//      fn0000000100003AA8
void listxattr()
{
	listxattr();
}

// 0000000100004EA4: Register (ptr64 Eq_n) localtime(Register word32 edi)
// Called from:
//      fn0000000100003AA8
struct tm * localtime(word32 edi)
{
	word64 rdi;
	return localtime((time_t) rdi);
}

// 0000000100004EAA: Register (ptr64 void) malloc(Register Eq_n rdi)
// Called from:
//      fn0000000100001B4A
//      fn0000000100003AA8
void * malloc(Eq_n rdi)
{
	return malloc(rdi);
}

// 0000000100004EB0: void mbr_uuid_to_id()
// Called from:
//      fn0000000100003AA8
void mbr_uuid_to_id()
{
	mbr_uuid_to_id();
}

// 0000000100004EB6: void mbr_uuid_to_string()
// Called from:
//      fn0000000100003AA8
void mbr_uuid_to_string()
{
	mbr_uuid_to_string();
}

// 0000000100004EBC: Register Eq_n mbrtowc(Register (ptr64 Eq_n) rcx, Register Eq_n rdx, Register Eq_n rsi, Register (ptr64 wchar_t) rdi)
// Called from:
//      fn000000010000356F
//      fn0000000100004715
//      fn000000010000488B
//      fn0000000100004AFA
Eq_n mbrtowc(mbstate_t * rcx, Eq_n rdx, Eq_n rsi, wchar_t * rdi)
{
	return mbrtowc(rdi, rsi, rdx, rcx);
}

// 0000000100004EC2: void memchr()
// Called from:
//      fn000000010000488B
void memchr()
{
	memchr();
}

// 0000000100004EC8: Register (ptr64 char) nl_langinfo(Register word32 edi)
// Called from:
//      fn0000000100003AA8
char * nl_langinfo(word32 edi)
{
	word64 rdi;
	return nl_langinfo((nl_item) rdi);
}

// 0000000100004ECE: Register int32 printf(Register (ptr64 char) rdi)
// Called from:
//      fn00000001000023B0
//      fn00000001000035A9
//      fn0000000100003786
//      fn0000000100003AA8
//      fn0000000100004715
int32 printf(char * rdi)
{
	return printf(rdi, 0x00);
}

// 0000000100004ED4: Register int32 putchar(Register int32 edi)
// Called from:
//      fn0000000100003201
//      fn000000010000356F
//      fn0000000100003AA8
//      fn0000000100004715
//      fn000000010000488B
int32 putchar(int32 edi)
{
	word64 rdi;
	return putchar((int32) rdi);
}

// 0000000100004EDA: Register Eq_n readlink(Register Eq_n rdx, Register (ptr64 char) rsi, Register (ptr64 char) rdi)
// Called from:
//      fn0000000100003AA8
Eq_n readlink(Eq_n rdx, char * rsi, char * rdi)
{
	return readlink(rdi, rsi, rdx);
}

// 0000000100004EE0: void realloc(Register Eq_n rsi, Register (ptr64 void) rdi)
void realloc(Eq_n rsi, void * rdi)
{
	realloc(rdi, rsi);
}

// 0000000100004EE6: void setenv()
// Called from:
//      fn00000001000026A0
void setenv()
{
	setenv();
}

// 0000000100004EEC: void setlocale(Register (ptr64 char) rsi, Register word32 edi)
// Called from:
//      fn00000001000026A0
void setlocale(char * rsi, word32 edi)
{
	word64 rdi;
	setlocale((int32) rdi, rsi);
}

// 0000000100004EF2: void signal(Register Eq_n rsi, Register word32 edi)
// Called from:
//      fn00000001000026A0
void signal(Eq_n rsi, word32 edi)
{
	word64 rdi;
	signal((int32) rdi, rsi);
}

// 0000000100004EF8: Register int32 snprintf(Register (ptr64 char) rdx, Register Eq_n rsi, Register (ptr64 char) rdi)
// Called from:
//      fn0000000100001B4A
//      fn0000000100003AA8
int32 snprintf(char * rdx, Eq_n rsi, char * rdi)
{
	return snprintf(rdi, rsi, rdx, 0x00);
}

// 0000000100004EFE: void sscanf()
// Called from:
//      fn0000000100001B4A
void sscanf()
{
	sscanf();
}

// 0000000100004F04: void strcoll(Register (ptr64 char) rsi, Register (ptr64 char) rdi)
void strcoll(char * rsi, char * rdi)
{
	strcoll(rdi, rsi);
}

// 0000000100004F0A: void strcpy(Register Eq_n rsi, Register Eq_n rdi)
// Called from:
//      fn0000000100001B4A
void strcpy(Eq_n rsi, Eq_n rdi)
{
	strcpy(rdi, rsi);
}

// 0000000100004F10: Register (ptr64 char) strdup(Register (ptr64 char) rdi)
// Called from:
//      fn0000000100001B4A
char * strdup(char * rdi)
{
	return strdup(rdi);
}

// 0000000100004F16: Register (ptr64 char) strerror(Register word32 edi)
// Called from:
//      fn0000000100001B4A
//      fn00000001000023B0
//      fn0000000100003AA8
char * strerror(word32 edi)
{
	word64 rdi;
	return strerror((int32) rdi);
}

// 0000000100004F1C: void strftime(Register (ptr64 Eq_n) rcx, Register (ptr64 char) rdx, Register Eq_n rsi, Register (ptr64 char) rdi)
// Called from:
//      fn0000000100003AA8
void strftime(struct tm * rcx, char * rdx, Eq_n rsi, char * rdi)
{
	strftime(rdi, rsi, rdx, rcx);
}

// 0000000100004F22: Register Eq_n strlen(Register Eq_n rdi)
// Called from:
//      fn0000000100001B4A
//      fn000000010000328E
//      fn0000000100003AA8
//      fn000000010000488B
Eq_n strlen(Eq_n rdi)
{
	return strlen(rdi);
}

// 0000000100004F28: void strmode()
// Called from:
//      fn0000000100003AA8
void strmode()
{
	strmode();
}

// 0000000100004F2E: void tgetent()
// Called from:
//      fn00000001000026A0
void tgetent()
{
	tgetent();
}

// 0000000100004F34: void tgetstr()
// Called from:
//      fn00000001000026A0
void tgetstr()
{
	tgetstr();
}

// 0000000100004F3A: void tgoto()
// Called from:
//      fn00000001000033F4
void tgoto()
{
	tgoto();
}

// 0000000100004F40: Register Eq_n time(Register (ptr64 Eq_n) rdi)
// Called from:
//      fn0000000100003AA8
Eq_n time(time_t * rdi)
{
	return time(rdi);
}

// 0000000100004F46: void tputs()
// Called from:
//      fn00000001000033F4
//      fn00000001000035A9
//      fn0000000100003AA8
void tputs()
{
	tputs();
}

// 0000000100004F4C: void user_from_uid()
// Called from:
//      fn0000000100001B4A
void user_from_uid()
{
	user_from_uid();
}

// 0000000100004F52: void warn()
void warn()
{
	warn();
}

// 0000000100004F58: void warnx()
// Called from:
//      fn0000000100001B4A
//      fn00000001000023B0
void warnx()
{
	warnx();
}

// 0000000100004F5E: Register int32 wcwidth(Register word16 di)
// Called from:
//      fn000000010000356F
//      fn0000000100004715
//      fn000000010000488B
int32 wcwidth(word16 di)
{
	word64 rdi;
	return wcwidth((wchar_t) rdi);
}

// 0000000100004F64: void write(Register Eq_n rdx, Register (ptr64 void) rsi, Register word32 edi)
void write(Eq_n rdx, void * rsi, word32 edi)
{
	word64 rdi;
	write((int32) rdi, rsi, rdx);
}

