#region License
/* 
 * Copyright (C) 1999-2015 John K�ll�n.
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.PowerPC
{
    public enum Opcode : ushort
    {
        illegal,

        add,
        addi,
        addic,
        addis,
        andi,
        andis,
        b,
        bc,
        bl,
        blr,
        blrl,
        bcl,
        cmp,
        cmpi,
        cmpli,
        crnor,
        cror,
        fadd,
        fadds,
        fdivs,
        fsubs,
        fmuls,
        fres,
        fmadds,
        fmsubs,
        fnmadds,
        fnmsubs,
        fsqrts,
        lbz,
        lbzu,
        lbzux,
        lbzx,
        lfd,
        lfdu,
        lfs,
        lfsu,
        lha,
        lhau,
        lhz,
        lhzu,
        lhzx,
        lmw,
        lwarx,
        lwzu,
        lwz,
        mflr,
        mtlr,
        mulli,
        or,
        ori,
        oris,
        rfi,
        sc,
        stb,
        stbu,
        stbux,
        stfd,
        stfdu,
        stfs,
        stfsu,
        sth,
        sthu,
        stmw,
        stw,
        stwu,
        subfic,
        tw,
        twi,
        xor,
        xori,
        xoris,
    }
}
