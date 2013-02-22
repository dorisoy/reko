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

using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decompiler.Arch.Arm
{
    public class ArmInstruction : MachineInstruction
    {
        public Opcode Opcode;
        public OpFlags OpFlags;
        public Condition Cond;
        public MachineOperand Dst;
        public MachineOperand Src1;
        public MachineOperand Src2;
        public MachineOperand Src3;

        public override string ToString()
        {
            var sb = new StringWriter();
            sb.Write(Opcode.ToString());
            if (Cond != Condition.al)
                sb.Write(Cond.ToString());
            if (OpFlags != OpFlags.None)
                sb.Write(OpFlags.ToString().ToLower());
            if (Dst != null)
            {
                sb.Write('\t');
                Write(Dst, sb);
                if (Src1 != null)
                {
                    sb.Write(",");
                    Write(Src1, sb);
                    if (Src2 != null)
                    {
                        sb.Write(",");
                        Write(Src2, sb);
                        if (Src3 != null)
                        {
                            sb.Write(",");
                            Write(Src3, sb);
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public void Write(MachineOperand op, StringWriter writer)
        {
            var imm = op as ImmediateOperand;
            if (imm != null)
            {
                writer.Write("#");
                int imm8 = imm.Value.ToInt32();
                if (imm8 > 256 && ((imm8 & (imm8 - 1)) == 0))
                {
                    /* only one bit set, and that later than bit 8.
                     * Represent as 1<<... .
                     */
                    writer.Write("1<<");
                    {
                        uint n = 0;
                        while ((imm8 & 15) == 0)
                        {
                            n += 4; imm8 = imm8 >> 4;
                        }
                        // Now imm8 is 1, 2, 4 or 8. 
                        n += (uint)((0x30002010 >> (int)(4 * (imm8 - 1))) & 15);
                        writer.Write(n);
                    }
                }
                else
                {
                    var fmt = (-9 <= imm8 && imm8 <= 9) ? "{0}{1}" : "&{0}{1:X}";
                    var sign = "";
                    if (((int)imm8) < 0 && ((int)imm8) > -100)
                    {
                        imm8 = -imm8;
                        sign = "-";
                    }
                    writer.Write(fmt,sign,imm8);
                }
                return;
            }
            var adr = op as AddressOperand;
            if (adr != null)
            {
                writer.Write("$");
                writer.Write("{0,8:X}", adr.Address);
                return;
            }
            var mem = op as ArmMemoryOperand;
            if (mem != null)
            {
                writer.Write('[');
                writer.Write(mem.Base);
                if (mem.Offset != null)
                {
                    if (mem.Preindexed)
                    {
                        writer.Write(",");
                        if (mem.Subtract)
                            writer.Write("-");
                        Write(mem.Offset, writer);
                        writer.Write("]");
                        if (mem.Writeback)
                            writer.Write("!");
                    }
                    else
                    {
                        writer.Write("],");
                        if (mem.Subtract)
                            writer.Write("-");
                        Write(mem.Offset, writer);
                    }
                }
                else
                    writer.Write(']');
                return;
            }
            var sh = op as ShiftOperand;
            if (sh != null)
            {
                Write(sh.Operand, writer);
                writer.Write(",");
                writer.Write(sh.Opcode);
                writer.Write(' ');
                Write(sh.Shift, writer);
                return;
            }
            op.Write(false, writer);
        }

        public override uint DefCc()
        {
            throw new NotImplementedException();
        }

        public override uint UseCc()
        {
            throw new NotImplementedException();
        }
    }
}
