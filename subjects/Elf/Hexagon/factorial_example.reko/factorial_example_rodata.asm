;;; Segment .rodata (0000D000)
0000D000 55 73 65 72 20 69 6E 70 75 74 20 69 73 20 3A 20 User input is : 
0000D010 25 64 00 49 6E 76 61 6C 69 64 20 6E 75 6D 62 65 %d.Invalid numbe
0000D020 72 20 6F 66 20 61 72 67 75 6D 65 6E 74 73 00 49 r of arguments.I
0000D030 6E 76 61 6C 69 64 20 69 6E 70 75 74 20 2D 20 4D nvalid input - M
0000D040 75 73 74 20 62 65 20 70 6F 73 69 74 69 76 65 00 ust be positive.
0000D050 0A 46 61 63 74 6F 72 69 61 6C 20 6F 66 20 25 64 .Factorial of %d
0000D060 20 69 73 20 25 64 00 0A 49 6E 76 61 6C 69 64 20  is %d..Invalid 
0000D070 63 6F 6D 6D 61 6E 64 20 4C 69 6E 65 20 73 74 72 command Line str
0000D080 69 6E 67 21 0A 00 00 00                         ing!....        
_Printf.fchar		; 0000D088
	db	0x20, 0x2B, 0x2D, 0x23, 0x30, 0x2C, 0x3B, 0x3A
	db	0x5F, 0x00
0000D092       00 00 00 00 00 00                           ......        
_Printf.fbit		; 0000D098
	db	0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00
	db	0x04, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
0000D0B0 68 6A 6C 74 7A 4C 00 00 A0 5B 00 00 48 5C 00 00 hjltzL...[..H\..
0000D0C0 48 5C 00 00 48 5C 00 00 48 5C 00 00 48 5C 00 00 H\..H\..H\..H\..
0000D0D0 48 5C 00 00 48 5C 00 00 48 5C 00 00 1C 5B 00 00 H\..H\..H\...[..
0000D0E0 48 5C 00 00 C0 5D 00 00 08 5D 00 00 1C 5B 00 00 H\...]...]...[..
0000D0F0 1C 5B 00 00 1C 5B 00 00 48 5C 00 00 08 5D 00 00 .[...[..H\...]..
0000D100 48 5C 00 00 48 5C 00 00 48 5C 00 00 48 5C 00 00 H\..H\..H\..H\..
0000D110 10 5E 00 00 A0 5B 00 00 4C 5E 00 00 48 5C 00 00 .^...[..L^..H\..
0000D120 48 5C 00 00 8C 5E 00 00 48 5C 00 00 A0 5B 00 00 H\...^..H\...[..
0000D130 48 5C 00 00 48 5C 00 00 A0 5B 00 00 00 00 00 00 H\..H\...[......
spaces		; 0000D140
	db	0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20
	db	0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20
	db	0x00
0000D161    00 00 00 00 00 00 00                          .......        
zeroes		; 0000D168
	db	0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30
	db	0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30
	db	0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00
0000D189                            00 00 00                      ...    
_Tls_init__Mbstate		; 0000D18C
	db	0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
0000D1CC                                     00 00 00 00             ....
digits		; 0000D1D0
	db	0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66
	db	0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76
	db	0x77, 0x78, 0x79, 0x7A, 0x00
0000D1F5                00 00 00                              ...        
ndigs		; 0000D1F8
	db	0x00, 0x00, 0x21, 0x15, 0x11, 0x0E, 0x0D, 0x0C
	db	0x0B, 0x0B, 0x0A, 0x0A, 0x09, 0x09, 0x09, 0x09, 0x09, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08
	db	0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07
0000D21D                                        00 00 00              ...
tolow_tab		; 0000D220
	db	0xFF, 0xFF, 0x00, 0x00, 0x01, 0x00, 0x02, 0x00, 0x03, 0x00, 0x04, 0x00, 0x05, 0x00, 0x06, 0x00
	db	0x07, 0x00, 0x08, 0x00, 0x09, 0x00, 0x0A, 0x00, 0x0B, 0x00, 0x0C, 0x00, 0x0D, 0x00, 0x0E, 0x00
	db	0x0F, 0x00, 0x10, 0x00, 0x11, 0x00, 0x12, 0x00, 0x13, 0x00, 0x14, 0x00, 0x15, 0x00, 0x16, 0x00
	db	0x17, 0x00, 0x18, 0x00, 0x19, 0x00, 0x1A, 0x00, 0x1B, 0x00, 0x1C, 0x00, 0x1D, 0x00, 0x1E, 0x00
	db	0x1F, 0x00, 0x20, 0x00, 0x21, 0x00, 0x22, 0x00, 0x23, 0x00, 0x24, 0x00, 0x25, 0x00, 0x26, 0x00
	db	0x27, 0x00, 0x28, 0x00, 0x29, 0x00, 0x2A, 0x00, 0x2B, 0x00, 0x2C, 0x00, 0x2D, 0x00, 0x2E, 0x00
	db	0x2F, 0x00, 0x30, 0x00, 0x31, 0x00, 0x32, 0x00, 0x33, 0x00, 0x34, 0x00, 0x35, 0x00, 0x36, 0x00
	db	0x37, 0x00, 0x38, 0x00, 0x39, 0x00, 0x3A, 0x00, 0x3B, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3E, 0x00
	db	0x3F, 0x00, 0x40, 0x00, 0x61, 0x00, 0x62, 0x00, 0x63, 0x00, 0x64, 0x00, 0x65, 0x00, 0x66, 0x00
	db	0x67, 0x00, 0x68, 0x00, 0x69, 0x00, 0x6A, 0x00, 0x6B, 0x00, 0x6C, 0x00, 0x6D, 0x00, 0x6E, 0x00
	db	0x6F, 0x00, 0x70, 0x00, 0x71, 0x00, 0x72, 0x00, 0x73, 0x00, 0x74, 0x00, 0x75, 0x00, 0x76, 0x00
	db	0x77, 0x00, 0x78, 0x00, 0x79, 0x00, 0x7A, 0x00, 0x5B, 0x00, 0x5C, 0x00, 0x5D, 0x00, 0x5E, 0x00
	db	0x5F, 0x00, 0x60, 0x00, 0x61, 0x00, 0x62, 0x00, 0x63, 0x00, 0x64, 0x00, 0x65, 0x00, 0x66, 0x00
	db	0x67, 0x00, 0x68, 0x00, 0x69, 0x00, 0x6A, 0x00, 0x6B, 0x00, 0x6C, 0x00, 0x6D, 0x00, 0x6E, 0x00
	db	0x6F, 0x00, 0x70, 0x00, 0x71, 0x00, 0x72, 0x00, 0x73, 0x00, 0x74, 0x00, 0x75, 0x00, 0x76, 0x00
	db	0x77, 0x00, 0x78, 0x00, 0x79, 0x00, 0x7A, 0x00, 0x7B, 0x00, 0x7C, 0x00, 0x7D, 0x00, 0x7E, 0x00
	db	0x7F, 0x00, 0x80, 0x00, 0x81, 0x00, 0x82, 0x00, 0x83, 0x00, 0x84, 0x00, 0x85, 0x00, 0x86, 0x00
	db	0x87, 0x00, 0x88, 0x00, 0x89, 0x00, 0x8A, 0x00, 0x8B, 0x00, 0x8C, 0x00, 0x8D, 0x00, 0x8E, 0x00
	db	0x8F, 0x00, 0x90, 0x00, 0x91, 0x00, 0x92, 0x00, 0x93, 0x00, 0x94, 0x00, 0x95, 0x00, 0x96, 0x00
	db	0x97, 0x00, 0x98, 0x00, 0x99, 0x00, 0x9A, 0x00, 0x9B, 0x00, 0x9C, 0x00, 0x9D, 0x00, 0x9E, 0x00
	db	0x9F, 0x00, 0xA0, 0x00, 0xA1, 0x00, 0xA2, 0x00, 0xA3, 0x00, 0xA4, 0x00, 0xA5, 0x00, 0xA6, 0x00
	db	0xA7, 0x00, 0xA8, 0x00, 0xA9, 0x00, 0xAA, 0x00, 0xAB, 0x00, 0xAC, 0x00, 0xAD, 0x00, 0xAE, 0x00
	db	0xAF, 0x00, 0xB0, 0x00, 0xB1, 0x00, 0xB2, 0x00, 0xB3, 0x00, 0xB4, 0x00, 0xB5, 0x00, 0xB6, 0x00
	db	0xB7, 0x00, 0xB8, 0x00, 0xB9, 0x00, 0xBA, 0x00, 0xBB, 0x00, 0xBC, 0x00, 0xBD, 0x00, 0xBE, 0x00
	db	0xBF, 0x00, 0xC0, 0x00, 0xC1, 0x00, 0xC2, 0x00, 0xC3, 0x00, 0xC4, 0x00, 0xC5, 0x00, 0xC6, 0x00
	db	0xC7, 0x00, 0xC8, 0x00, 0xC9, 0x00, 0xCA, 0x00, 0xCB, 0x00, 0xCC, 0x00, 0xCD, 0x00, 0xCE, 0x00
	db	0xCF, 0x00, 0xD0, 0x00, 0xD1, 0x00, 0xD2, 0x00, 0xD3, 0x00, 0xD4, 0x00, 0xD5, 0x00, 0xD6, 0x00
	db	0xD7, 0x00, 0xD8, 0x00, 0xD9, 0x00, 0xDA, 0x00, 0xDB, 0x00, 0xDC, 0x00, 0xDD, 0x00, 0xDE, 0x00
	db	0xDF, 0x00, 0xE0, 0x00, 0xE1, 0x00, 0xE2, 0x00, 0xE3, 0x00, 0xE4, 0x00, 0xE5, 0x00, 0xE6, 0x00
	db	0xE7, 0x00, 0xE8, 0x00, 0xE9, 0x00, 0xEA, 0x00, 0xEB, 0x00, 0xEC, 0x00, 0xED, 0x00, 0xEE, 0x00
	db	0xEF, 0x00, 0xF0, 0x00, 0xF1, 0x00, 0xF2, 0x00, 0xF3, 0x00, 0xF4, 0x00, 0xF5, 0x00, 0xF6, 0x00
	db	0xF7, 0x00, 0xF8, 0x00, 0xF9, 0x00, 0xFA, 0x00, 0xFB, 0x00, 0xFC, 0x00, 0xFD, 0x00, 0xFE, 0x00
	db	0xFF, 0x00
0000D422       00 00 18 78 00 00 8C 77 00 00 24 78 00 00   ...x...w..$x..
0000D430 8C 77 00 00 50 78 00 00 8C 77 00 00 30 78 00 00 .w..Px...w..0x..
0000D440 8C 77 00 00 8C 77 00 00 3C 78 00 00 8C 77 00 00 .w...w..<x...w..
0000D450 8C 77 00 00 8C 77 00 00 48 78 00 00 61 62 6F 72 .w...w..Hx..abor
0000D460 74 00 61 72 69 74 68 6D 65 74 69 63 20 65 72 72 t.arithmetic err
0000D470 6F 72 00 69 6E 76 61 6C 69 64 20 65 78 65 63 75 or.invalid execu
0000D480 74 61 62 6C 65 20 63 6F 64 65 00 69 6E 74 65 72 table code.inter
0000D490 72 75 70 74 69 6F 6E 00 69 6E 76 61 6C 69 64 20 ruption.invalid 
0000D4A0 73 74 6F 72 61 67 65 20 61 63 63 65 73 73 00 74 storage access.t
0000D4B0 65 72 6D 69 6E 61 74 69 6F 6E 20 72 65 71 75 65 ermination reque
0000D4C0 73 74 00 73 69 67 6E 61 6C 20 23 00 20 2D 2D 20 st.signal #. -- 
0000D4D0 74 65 72 6D 69 6E 61 74 69 6E 67 0A 00 00 00 00 terminating.....
ctyp_tab		; 0000D4E0
	db	0x00, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00
	db	0x80, 0x00, 0x80, 0x00, 0xC0, 0x04, 0xC0, 0x00, 0xC0, 0x00, 0xC0, 0x00, 0xC0, 0x00, 0x80, 0x00
	db	0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00
	db	0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00
	db	0x80, 0x00, 0x04, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00
	db	0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00
	db	0x08, 0x00, 0x21, 0x00, 0x21, 0x00, 0x21, 0x00, 0x21, 0x00, 0x21, 0x00, 0x21, 0x00, 0x21, 0x00
	db	0x21, 0x00, 0x21, 0x00, 0x21, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00
	db	0x08, 0x00, 0x08, 0x00, 0x03, 0x00, 0x03, 0x00, 0x03, 0x00, 0x03, 0x00, 0x03, 0x00, 0x03, 0x00
	db	0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00
	db	0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00
	db	0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00
	db	0x08, 0x00, 0x08, 0x00, 0x11, 0x00, 0x11, 0x00, 0x11, 0x00, 0x11, 0x00, 0x11, 0x00, 0x11, 0x00
	db	0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00
	db	0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00
	db	0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00
	db	0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00
0000D6E2       6E 61 6E 00 4E 41 4E 00 69 6E 66 00 49 4E   nan.NAN.inf.IN
0000D6F0 46 00 30 31 32 33 34 35 36 37 38 39 61 62 63 64 F.0123456789abcd
0000D700 65 66 00 30 31 32 33 34 35 36 37 38 39 41 42 43 ef.0123456789ABC
0000D710 44 45 46 00 00 00 00 00                         DEF.....        
udigs		; 0000D718
	db	0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37
	db	0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x00
0000D729                            00 00 00 00 00 00 00          .......
ldigs		; 0000D730
	db	0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66
	db	0x00
0000D741    00 00 00 00 00 00 00                          .......        
_Tls_init__Wcstate		; 0000D748
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
0000D788                         30 00 00 00 00 00 00 00         0.......
table		; 0000D790
	db	0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9C, 0x75, 0x00, 0x88, 0x3C, 0xE4, 0x37, 0x7E
	db	0x59, 0xF3, 0xF8, 0xC2, 0x1F, 0x6E, 0xA5, 0x01, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
	db	0x59, 0xF3, 0xF8, 0xC2, 0x1F, 0x6E, 0xA5, 0x01, 0x9C, 0x75, 0x00, 0x88, 0x3C, 0xE4, 0x37, 0x7E
	db	0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40
	db	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x40
_Tls_init__Locale		; 0000D808
	db	0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00
	db	0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00
	db	0x58, 0xD8, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
	db	0xFF, 0xFF, 0x00, 0x00, 0x59, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00
	db	0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00, 0x5B, 0xD8, 0x00, 0x00, 0x61, 0xD8, 0x00, 0x00
	db	0x58, 0xD8, 0x00, 0x00, 0x58, 0xD8, 0x00, 0x00
null		; 0000D858
	db	0x00
0000D859                            2E 00 66 61 6C 73 65          ..false
0000D860 00 74 72 75 65 00 00 00                         .true...        
_Dint.mask		; 0000D868
	db	0x00, 0x00, 0x01, 0x00, 0x03, 0x00, 0x07, 0x00
	db	0x0F, 0x00, 0x1F, 0x00, 0x3F, 0x00, 0x7F, 0x00, 0xFF, 0x00, 0xFF, 0x01, 0xFF, 0x03, 0xFF, 0x07
	db	0xFF, 0x0F, 0xFF, 0x1F, 0xFF, 0x3F, 0xFF, 0x7F
_Dint.sub		; 0000D888
	db	0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
	db	0x02, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00
