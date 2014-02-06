﻿#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
using Decompiler.Core.Rtl;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.Arch.Mos6502
{
    public class Rewriter : IEnumerable<RtlInstructionCluster>
    {
        private ProcessorState state;
        private Frame frame;
        private IRewriterHost host;
        private Mos6502ProcessorArchitecture arch;
        private IEnumerator<Instruction> instrs;
        private Instruction instrCur;
        private RtlInstructionCluster ric;
        private RtlEmitter emitter;

        public Rewriter(Mos6502ProcessorArchitecture arch, ImageReader rdr, ProcessorState state, Frame frame)
        {
            this.arch = arch;
            this.state = state;
            this.frame = frame;
            this.instrs = new Disassembler(rdr.CreateLeReader());
        }

        private AddressCorrelatedException NYI()
        {
            return new AddressCorrelatedException(
                instrCur.Address,
                "Rewriting 6502 opcode '{0}' is not supported yet.",
                instrCur.Code);
        }

        public IEnumerator<RtlInstructionCluster> GetEnumerator()
        {
            while (instrs.MoveNext())
            {
                this.instrCur = instrs.Current;
                this.ric = new RtlInstructionCluster(instrCur.Address, (byte) instrCur.Length);
                this.emitter = new RtlEmitter(ric.Instructions);
                switch (instrCur.Code)
                {
                default: throw NYI();
                case Opcode.sbc: Sbc(); break;
                case Opcode.tax: Copy(Registers.x, Registers.a); break;
                }
                yield return ric;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Copy(RegisterStorage regDst, RegisterStorage regSrc)
        {
            var dst = frame.EnsureRegister(regDst);
            var src = frame.EnsureRegister(regSrc);
            emitter.Assign(dst, src);
            emitter.Assign(
                frame.EnsureFlagGroup(
                    (uint) (FlagM.NF | FlagM.ZF),
                    "NZ",
                    PrimitiveType.Byte),
                emitter.Cond(dst));
        }

        private void Sbc()
        {
            var mem = RewriteOperand(instrCur.Operand);
            var a = frame.EnsureRegister(Registers.a);
            var c = frame.EnsureFlagGroup((uint) FlagM.CF, "C", PrimitiveType.Bool);
            emitter.Assign(
                a,
                emitter.ISub(
                    emitter.ISub(a, mem),
                    emitter.Not(c)));
            emitter.Assign(
                frame.EnsureFlagGroup((uint) Instruction.DefCc(instrCur.Code), "NVZC", PrimitiveType.Byte),
                emitter.Cond(a));
        }

        private Expression RewriteOperand(Operand op)
        {
            switch (op.Mode)
            {
            default: throw new NotImplementedException("Unimplemented address mode " + op.Mode);
            case AddressMode.IndirectIndexed:
                var y = frame.EnsureRegister(Registers.y);
                var offset = Constant.Word16((ushort) op.Offset.ToByte());
                return
                    emitter.LoadB(
                        emitter.IAdd(
                            emitter.Load(PrimitiveType.Ptr16, offset),
                            emitter.Cast(PrimitiveType.UInt16, y)));
            }
        }
    }
}
