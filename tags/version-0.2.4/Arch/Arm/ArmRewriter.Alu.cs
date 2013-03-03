﻿#region License
/* 
 * Copyright (C) 1999-2013 John Källén.
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

using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Lib;
using Decompiler.Core.Machine;
using Decompiler.Core.Rtl;
using Decompiler.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.Arm
{
    public partial class ArmRewriter
    {
        private void RewriteBinOp(Operator op)
        {
            var opDst = this.Operand(di.Instruction.Dst);
            var opSrc1 = this.Operand(di.Instruction.Src1);
            var opSrc2 = this.Operand(di.Instruction.Src2);
            AddConditional(new RtlAssignment(opDst, new BinaryExpression(op, PrimitiveType.Word32, opSrc1, opSrc2)));
            if (di.Instruction.OpFlags == OpFlags.S)
            {
                emitter.Assign(frame.EnsureFlagGroup(0x1111, "SZCO", PrimitiveType.Byte), emitter.Cond(opDst));
            }
        }
    }
}