// animals_mips.c
// Generated by decompiling animals_mips
// using Reko decompiler version 0.8.0.0.

#include "animals_mips.h"

<anonymous> g_tFFFFFFFF;
<anonymous> g_t0001 = <code>;
<anonymous> g_t0002 = <code>;
<anonymous> g_t0003 = <code>;
<anonymous> g_t0004 = <code>;
<anonymous> g_t001C = <code>;
<anonymous> g_t40C0 = <code>;
<anonymous> g_t4534 = <code>;
<anonymous> g_t4674 = <code>;
<anonymous> g_t472C = <code>;
<anonymous> g_t4798 = <code>;
<anonymous> g_t49CC = <code>;
<anonymous> g_t4A38 = <code>;
<anonymous> g_t4C94 = <code>;
<anonymous> g_t52E8 = <code>;
<anonymous> g_t53B4 = <code>;
<anonymous> g_t55F8 = <code>;
<anonymous> g_t584C = <code>;
<anonymous> g_t58D8 = <code>;
<anonymous> g_t5AB0 = <code>;
<anonymous> g_t5C0C = <code>;
<anonymous> g_t5CBC = <code>;
<anonymous> g_t5D14 = <code>;
<anonymous> g_t5EA0 = <code>;
<anonymous> g_t73C0 = <code>;
<anonymous> g_t73D0 = <code>;
<anonymous> g_t73E0 = <code>;
<anonymous> g_t73F0 = <code>;
<anonymous> g_t7440 = <code>;
<anonymous> g_t7450 = <code>;
<anonymous> g_t7470 = <code>;
<anonymous> g_t7490 = <code>;
word32 g_dw18C70 = 0x000043D8;
<anonymous> g_t18C84 = <code>;
<anonymous> g_t18C90 = <code>;
<anonymous> g_t18C9C = <code>;
word32 g_dw18D24 = 0x00018D04;
ptr32 g_ptr18D28 = 0x00020000;
int32 g_dw18D30 = 101504;
word32 g_dw18D34 = 0x00000000;
<anonymous> * g_ptr18D38 = _ZSt11make_uniqueI3DogJEENSt9_MakeUniqIT_E15__single_objectEDpOT0_;
<anonymous> * g_ptr18D3C = _ZNSt10unique_ptrI6AnimalSt14default_deleteIS0_EEaSI3DogS1_IS5_EEENSt9enable_ifIXsrSt6__and_IJS8_IJSt14is_convertibleINS_IT_T0_E7pointerEPS0_ESt6__not_ISt8is_arrayISA_EESt5__or_IJS8_IJSt12is_referenceIS2_ESt7is_sameIS2_SB_EEES8_IJSG_ISM_ES9_ISB_S2_EEEEEEESt13is_assignableIRS2_OSB_EEE5valueERS3_E4typeEOSC_;
<anonymous> * g_ptr18D40 = _ZNSt10unique_ptrI3DogSt14default_deleteIS0_EED1Ev;
<anonymous> * g_ptr18D44 = _ZSt11make_uniqueI3CatJEENSt9_MakeUniqIT_E15__single_objectEDpOT0_;
<anonymous> * g_ptr18D48 = _ZNSt10unique_ptrI6AnimalSt14default_deleteIS0_EEaSI3CatS1_IS5_EEENSt9enable_ifIXsrSt6__and_IJS8_IJSt14is_convertibleINS_IT_T0_E7pointerEPS0_ESt6__not_ISt8is_arrayISA_EESt5__or_IJS8_IJSt12is_referenceIS2_ESt7is_sameIS2_SB_EEES8_IJSG_ISM_ES9_ISB_S2_EEEEEEESt13is_assignableIRS2_OSB_EEE5valueERS3_E4typeEOSC_;
<anonymous> * g_ptr18D4C = _ZNSt10unique_ptrI3CatSt14default_deleteIS0_EED1Ev;
<anonymous> * g_ptr18D50 = _ZSt11make_uniqueI5HumanJRPcEENSt9_MakeUniqIT_E15__single_objectEDpOT0_;
<anonymous> * g_ptr18D54 = _ZNSt10unique_ptrI6AnimalSt14default_deleteIS0_EEaSI5HumanS1_IS5_EEENSt9enable_ifIXsrSt6__and_IJS8_IJSt14is_convertibleINS_IT_T0_E7pointerEPS0_ESt6__not_ISt8is_arrayISA_EESt5__or_IJS8_IJSt12is_referenceIS2_ESt7is_sameIS2_SB_EEES8_IJSG_ISM_ES9_ISB_S2_EEEEEEESt13is_assignableIRS2_OSB_EEE5valueERS3_E4typeEOSC_;
<anonymous> * g_ptr18D58 = _ZNSt10unique_ptrI5HumanSt14default_deleteIS0_EED1Ev;
<anonymous> * g_ptr18D5C = _ZNKSt10unique_ptrI6AnimalSt14default_deleteIS0_EEptEv;
<anonymous> * g_ptr18D60 = _ZNSt10unique_ptrI6AnimalSt14default_deleteIS0_EED1Ev;
word32 g_dw18D64 = 0x00018CA8;
<anonymous> * g_ptr18D68 = Animal::Animal;
<anonymous> * g_ptr18D6C = &g_t18C84;
<anonymous> * g_ptr18D70 = _ZNSt15__uniq_ptr_implI6AnimalSt14default_deleteIS0_EE6_M_ptrEv;
<anonymous> * g_ptr18D74 = _ZNSt10unique_ptrI6AnimalSt14default_deleteIS0_EE11get_deleterEv;
<anonymous> * g_ptr18D78 = _ZNKSt14default_deleteI6AnimalEclEPS0_;
<anonymous> * g_ptr18D7C = &g_t18C9C;
<anonymous> * g_ptr18D80 = Dog::Dog;
<anonymous> * g_ptr18D84 = _ZNSt10unique_ptrI3DogSt14default_deleteIS0_EEC1IS2_vEEPS0_;
<anonymous> * g_ptr18D88 = _ZNSt15__uniq_ptr_implI3DogSt14default_deleteIS0_EE6_M_ptrEv;
<anonymous> * g_ptr18D94 = _ZNSt10unique_ptrI3DogSt14default_deleteIS0_EE7releaseEv;
<anonymous> * g_ptr18D9C = _ZSt7forwardISt14default_deleteI3DogEEOT_RNSt16remove_referenceIS3_E4typeE;
<anonymous> * g_ptr18DA4 = &g_t18C90;
<anonymous> * g_ptr18DA8 = Cat::Cat;
<anonymous> * g_ptr18DAC = _ZNSt10unique_ptrI3CatSt14default_deleteIS0_EEC1IS2_vEEPS0_;
<anonymous> * g_ptr18DB0 = _ZNSt15__uniq_ptr_implI3CatSt14default_deleteIS0_EE6_M_ptrEv;
<anonymous> * g_ptr18DBC = _ZNSt10unique_ptrI3CatSt14default_deleteIS0_EE7releaseEv;
<anonymous> * g_ptr18DC0 = _ZSt7forwardISt14default_deleteI3CatEEOT_RNSt16remove_referenceIS3_E4typeE;
<anonymous> * g_ptr18DC8 = _ZSt7forwardIRPcEOT_RNSt16remove_referenceIS2_E4typeE;
<anonymous> * g_ptr18DCC = _ZN5HumanC1ENSt7__cxx1112basic_stringIcSt11char_traitsIcESaIcEEE;
<anonymous> * g_ptr18DD0 = _ZNSt10unique_ptrI5HumanSt14default_deleteIS0_EEC1IS2_vEEPS0_;
<anonymous> * g_ptr18DD4 = _ZNSt15__uniq_ptr_implI5HumanSt14default_deleteIS0_EE6_M_ptrEv;
<anonymous> * g_ptr18DE0 = _ZNSt10unique_ptrI5HumanSt14default_deleteIS0_EE7releaseEv;
<anonymous> * g_ptr18DE4 = _ZSt7forwardISt14default_deleteI5HumanEEOT_RNSt16remove_referenceIS3_E4typeE;
<anonymous> * g_ptr18E04 = _ZSt4swapIP6AnimalENSt9enable_ifIXsrSt6__and_IJSt6__not_ISt15__is_tuple_likeIT_EESt21is_move_constructibleIS6_ESt18is_move_assignableIS6_EEE5valueEvE4typeERS6_SG_;
<anonymous> * g_ptr18E08 = _ZNKSt10unique_ptrI3DogSt14default_deleteIS0_EE3getEv;
<anonymous> * g_ptr18E18 = _ZNKSt10unique_ptrI3CatSt14default_deleteIS0_EE3getEv;
<anonymous> * g_ptr18E28 = Human::~Human;
<anonymous> * g_ptr18E2C = _ZNKSt10unique_ptrI5HumanSt14default_deleteIS0_EE3getEv;
<anonymous> * g_ptr18E3C = _ZNSt5tupleIJP3DogSt14default_deleteIS0_EEEC1IS1_S3_Lb1EEEv;
<anonymous> * g_ptr18E48 = _ZSt4moveIRP6AnimalEONSt16remove_referenceIT_E4typeEOS4_;
<anonymous> * g_ptr18E4C = _ZNKSt15__uniq_ptr_implI3DogSt14default_deleteIS0_EE6_M_ptrEv;
<anonymous> * g_ptr18E50 = _ZNSt5tupleIJP3CatSt14default_deleteIS0_EEEC1IS1_S3_Lb1EEEv;
<anonymous> * g_ptr18E60 = _ZNSt5tupleIJP5HumanSt14default_deleteIS0_EEEC1IS1_S3_Lb1EEEv;
word32 g_dw18F28 = 0x0000725C;
word32 * g_ptr18F34 = &g_dw18C70;
int32 g_dw18F38 = 101492;
<anonymous> * g_ptr18F4C = null;
<anonymous> * g_ptr18F50 = null;
<anonymous> * g_ptr18F54 = &g_t7490;
<anonymous> * g_ptr18F5C = null;
<anonymous> * g_ptr18F60 = &g_t7470;
<anonymous> * g_ptr18F68 = &g_t7450;
<anonymous> * g_ptr18F70 = &g_t7440;
<anonymous> * g_ptr18F84 = &g_t73F0;
<anonymous> * g_ptr18F88 = &g_t73E0;
<anonymous> * g_ptr18F8C = null;
<anonymous> * g_ptr18F90 = &g_t73D0;
<anonymous> * g_ptr18F94 = &g_t73C0;

