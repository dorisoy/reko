﻿#region License
/* 
 * Copyright (C) 1999-2015 John Källén.
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
using Decompiler.Core.Machine;
using Decompiler.Core.Operators;
using Decompiler.Core.Rtl;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.X86
{
    public partial class X86Rewriter
    {
        private int maxFpuStackWrite;

        public void EmitCommonFpuInstruction(
            BinaryOperator op,
            bool fReversed,
            bool fPopStack)
        {
            EmitCommonFpuInstruction(op, fReversed, fPopStack, null);
        }

        public void EmitCommonFpuInstruction(
            BinaryOperator op,
            bool fReversed,
            bool fPopStack,
            DataType cast)
        {
            switch (instrCur.Operands)
            {
            default:
                throw new ArgumentOutOfRangeException("di.Instruction", "Instruction must have 1 or 2 operands");
            case 1:
                {
                    // implicit st(0) operand.
                    Identifier opLeft = FpuRegister(0);
                    Expression opRight = SrcOp(instrCur.op1);
                    if (fReversed)
                    {
                        EmitCopy(
                            instrCur.op1, 
                            new BinaryExpression(op, instrCur.dataWidth, opRight, MaybeCast(cast, opLeft)),
                            CopyFlags.ForceBreak);
                    }
                    else
                    {
                        emitter.Assign(opLeft, new BinaryExpression(op, instrCur.dataWidth, opLeft, MaybeCast(cast, opRight)));
                    }
                    break;
                }
            case 2:
                {
                    Expression op1 = SrcOp(instrCur.op1);
                    Expression op2 = SrcOp(instrCur.op2);
                    emitter.Assign(
                        SrcOp(instrCur.op1),
                        new BinaryExpression(op,
                            instrCur.op1.Width,
                            fReversed ? op2 : op1,
                            fReversed ? op1 : op2));
                    break;
                }
            }

            if (fPopStack)
            {
                state.ShrinkFpuStack(1);
            }
        }

        private void EmitFchs()
        {
            emitter.Assign(
                orw.FpuRegister(0, state),
                emitter.Neg(orw.FpuRegister(0, state)));		//$BUGBUG: should be Real, since we don't know the actual size.
            WriteFpuStack(0);
        }

        private void RewriteFclex()
        {
            emitter.SideEffect(PseudoProc("__fclex", VoidType.Instance));
        }

        private void RewriteFcom(int pops)
        {
            Identifier op1 = FpuRegister(0);
            Expression op2 = (instrCur.code == Opcode.fcompp || instrCur.code == Opcode.fucompp)
                ? FpuRegister(1)
                : SrcOp(instrCur.op1);
            emitter.Assign(
                orw.FlagGroup(FlagM.FPUF),
                new ConditionOf(
                    new BinaryExpression(Operator.FSub, instrCur.dataWidth, op1, op2)));
            state.ShrinkFpuStack(pops);
        }

        private void RewriteFUnary(string name)
        {
            emitter.Assign(
                orw.FpuRegister(0, state),
                PseudoProc(name, PrimitiveType.Real64, orw.FpuRegister(0, state)));
            WriteFpuStack(0);
        }

        private void RewriteFild()
        {
            state.GrowFpuStack(instrCur.Address);
            var iType = PrimitiveType.Create(Domain.SignedInt, instrCur.op1.Width.Size);
            emitter.Assign(
                orw.FpuRegister(0, state),
                emitter.Cast(PrimitiveType.Real64, SrcOp(instrCur.op1, iType)));
            WriteFpuStack(0);
        }

        private void RewriteFistp()
        {
            instrCur.op1.Width = PrimitiveType.Create(Domain.SignedInt, instrCur.op1.Width.Size);
            emitter.Assign(SrcOp(instrCur.op1), emitter.Cast(instrCur.op1.Width, orw.FpuRegister(0, state)));
            state.ShrinkFpuStack(1);
        }

        public void RewriteFld()
        {
            state.GrowFpuStack(instrCur.Address);
            emitter.Assign(FpuRegister(0), SrcOp(instrCur.op1));
            WriteFpuStack(0);
        }

        private void RewriteFldConst(double constant)
        {
            RewriteFldConst(Constant.Real64(constant));
        }

        private void RewriteFldConst(Constant c)
        {
            state.GrowFpuStack(instrCur.Address);
            emitter.Assign(FpuRegister(0), c);
            WriteFpuStack(0);
        }
        private void RewriteFldcw()
        {
            emitter.SideEffect(PseudoProc(
                "__fldcw",
                VoidType.Instance,
                SrcOp(instrCur.op1)));
        }

        private void RewriteFpatan()
        {
            Expression op1 = FpuRegister(1);
            Expression op2 = FpuRegister(0);
            state.ShrinkFpuStack(1);
            emitter.Assign(FpuRegister(0), PseudoProc("atan", PrimitiveType.Real64, op1, op2));
            WriteFpuStack(0);
        }

        private void RewriteFsincos()
        {
            Identifier itmp = frame.CreateTemporary(PrimitiveType.Real64);
            emitter.Assign(itmp, FpuRegister(0));

            state.GrowFpuStack(instrCur.Address);
            emitter.Assign(FpuRegister(1), PseudoProc("cos", PrimitiveType.Real64, itmp));
            emitter.Assign(FpuRegister(0), PseudoProc("sin", PrimitiveType.Real64, itmp));
            WriteFpuStack(0);
            WriteFpuStack(1);
        }

        private void RewriteFst(bool pop)
        {
            emitter.Assign(SrcOp(instrCur.op1), FpuRegister(0));
            if (pop)
                state.ShrinkFpuStack(1);
        }

        private void RewriterFstcw()
        {
			emitter.Assign(
                SrcOp(instrCur.op1), 
                PseudoProc("__fstcw", PrimitiveType.UInt16));
        }

        private void RewriteFstsw()
        {
            if (MatchesFstswSequence())
                return;
            emitter.Assign(
                SrcOp(instrCur.op1),
                new BinaryExpression(Operator.Shl, PrimitiveType.Word16,
                        new Cast(PrimitiveType.Word16, orw.FlagGroup(FlagM.FPUF)),
                        Constant.Int16(8)));
        }

        public bool MatchesFstswSequence()
        {
            var nextInstr = dasm.Peek(1);
            if (nextInstr.code == Opcode.sahf)
            {
                ric.Length += (byte) nextInstr.Length;
                dasm.Skip(1);
                emitter.Assign(
                    orw.FlagGroup(FlagM.ZF | FlagM.CF | FlagM.SF | FlagM.OF),
                    orw.FlagGroup(FlagM.FPUF));
                return true;
            }
            if (nextInstr.code == Opcode.test)
            {
                RegisterOperand acc = nextInstr.op1 as RegisterOperand;
                ImmediateOperand imm = nextInstr.op2 as ImmediateOperand;
                if (imm == null || acc == null)
                    return false;
                int mask = imm.Value.ToInt32();
                if (acc.Register == Registers.ax || acc.Register == Registers.eax)
                    mask >>= 8;
                else if (acc.Register != Registers.ah)
                    return false;
                ric.Length += (byte) nextInstr.Length;
                dasm.Skip(1);
                emitter.Assign(
                    orw.FlagGroup(FlagM.ZF | FlagM.CF | FlagM.SF | FlagM.OF), orw.FlagGroup(FlagM.FPUF));
                if (!dasm.MoveNext())
                    throw new AddressCorrelatedException(nextInstr.Address, "Expected instruction after fstsw;test {0},{1}.", acc.Register, imm.Value);
                nextInstr = dasm.Current;
                ric.Length += (byte) nextInstr.Length;
                //var r = new RtlInstructionCluster(nextInstr.Address, nextInstr.Length);
                //r.Instructions.AddRange(ric.Instructions);
                //emitter = new RtlEmitter(r.Instructions);
                //ric = r;
                switch (nextInstr.code)
                {
                case Opcode.jpe:
                    if (mask == 0x05) { Branch(ConditionCode.LE, nextInstr.op1); return true; }
                    if (mask == 0x41) { Branch(ConditionCode.GE, nextInstr.op1); return true; }
                    if (mask == 0x44) { Branch(ConditionCode.NE, nextInstr.op1); return true; }
                    break;
                case Opcode.jpo:
                    if (mask == 0x44) { Branch(ConditionCode.EQ, nextInstr.op1); return true;}
                    if (mask == 0x41) { Branch(ConditionCode.GE, nextInstr.op1); return true;}
                    if (mask == 0x05) { Branch(ConditionCode.LT, nextInstr.op1); return true;}
                    break;
                case Opcode.jz:
                    if (mask == 0x40) { Branch(ConditionCode.NE, nextInstr.op1); return true; }
                    if (mask == 0x41) { Branch(ConditionCode.LT, nextInstr.op1); return true; }
                    break;
                case Opcode.jnz:
                    if (mask == 0x40) { Branch(ConditionCode.EQ, nextInstr.op1); return true; }
                    if (mask == 0x41) { Branch(ConditionCode.GE, nextInstr.op1); return true; }
                    if (mask == 0x01) { Branch(ConditionCode.GT, nextInstr.op1); return true; }
                    break;
                }

                return false;
            }
            return false;
        }

        private void Branch(ConditionCode code, MachineOperand op)
        {
            emitter.Branch(emitter.Test(code, orw.FlagGroup(FlagM.FPUF)), OperandAsCodeAddress( op), RtlClass.ConditionalTransfer);
        }

        private void RewriteFtst()
        {
            emitter.Assign(orw.FlagGroup(FlagM.CF),
                emitter.ISub(FpuRegister(0), Constant.Real64(0.0)));
        }

        private void RewriteFxam()
        {
            emitter.Assign(orw.FlagGroup(FlagM.FPUF), emitter.Cond(FpuRegister(0)));
        }

        private void RewriteFyl2x()
        {
            //$REVIEW: Candidate for idiom search.
            Identifier op1 = FpuRegister(0);
            Identifier op2 = FpuRegister(1);
            emitter.Assign(op1, emitter.ISub(op2, PseudoProc("lg2", PrimitiveType.Real64, op1)));
            state.ShrinkFpuStack(1);
            WriteFpuStack(0);
        }

        private Identifier FpuRegister(int reg)
        {
            return orw.FpuRegister(reg, state);
        }


        public Expression MaybeCast(DataType type, Expression e)
        {
            if (type != null)
                return new Cast(type, e);
            else
                return e;
        }

        private void WriteFpuStack(int offset)
        {
            int o = offset - state.FpuStackItems;
            if (o > maxFpuStackWrite)
                maxFpuStackWrite = o;
        }
    }
}
