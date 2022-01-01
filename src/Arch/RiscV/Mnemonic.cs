#region License
/* 
 * Copyright (C) 1999-2022 John Källén.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

namespace Reko.Arch.RiscV
{
    public enum Mnemonic
    {
        invalid,

        add,
        addi,
        addiw,
        addw,
        and,
        andi,
        auipc,
        beq,
        bge,
        bgeu,
        blt,
        bltu,
        bne,
        c_add,
        c_addi,
        c_addi16sp,
        c_addi4spn,
        c_addiw,
        c_addw,
        c_and,
        c_andi,
        c_beqz,
        c_bnez,
        c_ebreak,
        c_fld,
        c_fldsp,
        c_flw,
        c_flwsp,
        c_fsd,
        c_fsdsp,
        c_fsw,
        c_j,
        c_jal,
        c_jalr,
        c_jr,
        c_ld,
        c_ldsp,
        c_li,
        c_lqsp,
        c_lui,
        c_lw,
        c_lwsp,
        c_mv,
        c_nop,
        c_or,
        c_sd,
        c_sdsp,
        c_slli,
        c_srai,
        c_srli,
        c_sub,
        c_subw,
        c_sw,
        c_swsp,
        c_xor,
        csrrc,
        csrrci,
        csrrs,
        csrrsi,
        csrrw,
        csrrwi,
        divuw,
        divw,
        ebreak,
        ecall,
        fabs_d,
        fabs_q,
        fabs_s,
        fadd_d,
        fadd_q,
        fadd_s,
        fclass_q,
        fcvt_d_l,
        fcvt_d_lu,
        fcvt_d_q,
        fcvt_d_s,
        fcvt_d_w,
        fcvt_d_wu,
        fcvt_l_d,
        fcvt_l_q,
        fcvt_l_s,
        fcvt_lu_d,
        fcvt_lu_q,
        fcvt_lu_s,
        fcvt_q_d,
        fcvt_q_l,
        fcvt_q_lu,
        fcvt_q_s,
        fcvt_q_w,
        fcvt_q_wu,
        fcvt_s_d,
        fcvt_s_l,
        fcvt_s_lu,
        fcvt_s_q,
        fcvt_s_w,
        fcvt_s_wu,
        fcvt_w_d,
        fcvt_w_q,
        fcvt_w_s,
        fcvt_wu_d,
        fcvt_wu_q,
        fcvt_wu_s,
        fdiv_d,
        fdiv_q,
        fdiv_s,
        feq_d,
        feq_q,
        feq_s,
        fld,
        fle_d,
        fle_q,
        fle_s,
        flq,
        flt_d,
        flt_q,
        flt_s,
        flw,
        fmadd_s,
        fmax_d,
        fmax_q,
        fmax_s,
        fmin_d,
        fmin_q,
        fmin_s,
        fmsub_s,
        fmul_d,
        fmul_q,
        fmul_s,
        fmv_d,
        fmv_d_x,
        fmv_q,
        fmv_s,
        fmv_s_x,
        fmv_w_x,
        fmv_x_w,
        fneg_d,
        fneg_q,
        fneg_s,
        fnmadd_s,
        fnmsub_s,
        fsd,
        fsgnj_d,
        fsgnj_q,
        fsgnj_s,
        fsgnjn_d,
        fsgnjn_q,
        fsgnjn_s,
        fsgnjx_d,
        fsgnjx_q,
        fsgnjx_s,
        fsqrt_d,
        fsqrt_q,
        fsqrt_s,
        fsub_d,
        fsub_q,
        fsub_s,
        fsw,
        jal,
        jalr,
        lb,
        lbu,
        ld,
        lh,
        lhu,
        lui,
        lw,
        lwu,
        mret,
        mulw,
        or,
        ori,
        remuw,
        remw,
        sb,
        sd,
        sh,
        sll,
        slli,
        slliw,
        sllw,
        slt,
        slti,
        sltiu,
        sltu,
        sra,
        srai,
        sraiw,
        sraw,
        sret,
        srl,
        srli,
        srliw,
        srlw,
        sub,
        subw,
        sw,
        uret,
        wfi,
        xor,
        xori,

        lr_w,
        sc_w, 
        amoswap_w,
        amoadd_w, 
        amoxor_w, 
        amoand_w, 
        amoor_w, 
        amomin_w, 
        amomax_w, 
        amominu_w,
        amomaxu_w,

        lr_d,
        sc_d,
        amoswap_d,
        amoadd_d,
        amoxor_d,
        amoand_d,
        amoor_d,
        amomin_d,
        amomax_d,
        amominu_d,
        amomaxu_d,

    }
}