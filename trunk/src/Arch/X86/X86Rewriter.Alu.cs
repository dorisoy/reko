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
using Decompiler.Core.Machine;
using Decompiler.Core.Operators;
using Decompiler.Core.Rtl;
using Decompiler.Core.Serialization;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Decompiler.Arch.X86
{
    public partial class X86Rewriter
    {
        private void RewriteAaa()
        {
            emitter.Assign(
                orw.FlagGroup(FlagM.CF),
                PseudoProc("__aaa", PrimitiveType.Bool,
                    orw.AluRegister(Registers.al),
                    orw.AluRegister(Registers.ah),
                            orw.AddrOf(orw.AluRegister(Registers.al)),
                            orw.AddrOf(orw.AluRegister(Registers.ah))));
        }

        private void RewriteHlt()
        {
            var ppp = host.EnsurePseudoProcedure("__hlt", PrimitiveType.Void, 0);
            ppp.Characteristics = new ProcedureCharacteristics
            {
                Terminates = true,
            };
            emitter.SideEffect(PseudoProc(ppp, PrimitiveType.Void));
        }

        private void RewriteAam()
        {
            emitter.Assign(
                orw.AluRegister(Registers.ax),
                PseudoProc("__aam", PrimitiveType.Word16,
                    orw.AluRegister(Registers.al)));
        }
        
        /// <summary>
        /// Doesn't handle the x86 idiom add ... adc => long add (and 
        /// sub ..sbc => long sub)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public Expression RewriteAddSub(BinaryOperator op)
        {
            //LongAddRewriter larw = new LongAddRewriter(this.frame, orw, state);
            //int iUse = larw.IndexOfUsingOpcode(instrs, i, next);
            //if (iUse >= 0 && larw.Match(di.Instruction, instrs[iUse]))
            //{
            //    instrs[iUse].code = Opcode.nop;
            //    larw.EmitInstruction(op, emitter);
            //    return larw.Dst;
            //}
            RtlAssignment ass = EmitBinOp(
                op,
                di.Instruction.op1,
                di.Instruction.op1.Width,
                SrcOp(di.Instruction.op1),
                SrcOp(di.Instruction.op2));
            var ccSrc = ass.Dst;
            if (ccSrc is MemoryAccess)
                ccSrc = ass.Src;
            EmitCcInstr(ccSrc, IntelInstruction.DefCc(di.Instruction.code));
            return ass.Dst;
        }

        public Expression RewriteAdcSbb(BinaryOperator opr)
        {
            // We do not take the trouble of widening the CF to the word size
            // to simplify code analysis in later stages. 
            var c = orw.FlagGroup(FlagM.CF);       
            var ass = EmitCopy(
                di.Instruction.op1, 
                new BinaryExpression(
                    opr, 
                    di.Instruction.dataWidth,
                    new BinaryExpression(
                        opr,
                        di.Instruction.dataWidth, 
                        SrcOp(di.Instruction.op1),
                        SrcOp(di.Instruction.op2)),
                    c), true);
            var ccSrc = ass.Dst;
            if (ccSrc is MemoryAccess)
                ccSrc = ass.Src;
            EmitCcInstr(ccSrc, IntelInstruction.DefCc(di.Instruction.code));
            return ass.Dst;
        }

        private void RewriteArpl()
        {
            emitter.Assign(
                orw.FlagGroup(FlagM.ZF),
                PseudoProc("__arpl", PrimitiveType.Bool, 
                    SrcOp(di.Instruction.op1),
                    SrcOp(di.Instruction.op2),
                    orw.AddrOf(SrcOp(di.Instruction.op1))));
        }

        public void RewriteBinOp(BinaryOperator opr)
        {
            var ass = EmitBinOp(opr, di.Instruction.op1, di.Instruction.dataWidth, SrcOp(di.Instruction.op1), SrcOp(di.Instruction.op2));
            EmitCcInstr(ass.Dst, IntelInstruction.DefCc(di.Instruction.code));
        }

        private void RewriteBsr()
        {
            Expression src = SrcOp(di.Instruction.op2);
            emitter.Assign(orw.FlagGroup(FlagM.ZF), emitter.Eq0(src));
            EmitCopy(di.Instruction.op1, PseudoProc("__bsr", di.Instruction.op1.Width, src), false);
        }

        private void RewriteBt()
        {
		    emitter.Assign(
                orw.FlagGroup(FlagM.CF),
				PseudoProc("__bt", PrimitiveType.Bool, SrcOp(di.Instruction.op1), SrcOp(di.Instruction.op2)));
        }

        public void RewriteBswap()
        {
            Identifier reg = (Identifier)orw.AluRegister(((RegisterOperand)di.Instruction.op1).Register);
            emitter.Assign(reg, PseudoProc("__bswap", (PrimitiveType)reg.DataType, reg));
        }

        public void RewriteCbw()
        {
            if (di.Instruction.dataWidth == PrimitiveType.Word32)
            {
                emitter.Assign(
                    orw.AluRegister(Registers.eax),
                    emitter.Cast(PrimitiveType.Int32, orw.AluRegister(Registers.ax)));
            }
            else
            {
                emitter.Assign(
                    orw.AluRegister(Registers.ax),
                    emitter.Cast(PrimitiveType.Int16, orw.AluRegister(Registers.al)));
            }
        }

        public RtlAssignment EmitBinOp(BinaryOperator binOp, MachineOperand dst, DataType dtDst, Expression left, Expression right)
        {
            Constant c = right as Constant;
            if (c != null)
            {
                if (c.DataType == PrimitiveType.Byte && left.DataType != c.DataType)
                {
                    right = emitter.Const(left.DataType, c.ToInt32());
                }
            }
            return EmitCopy(dst, new BinaryExpression(binOp, dtDst, left, right), true);
        }

        /// <summary>
        /// Emits an assignment to a flag-group pseudoregister.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="defFlags">flags defined by the intel instruction</param>
        private void EmitCcInstr(Expression expr, FlagM defFlags)
        {
            emitter.Assign(orw.FlagGroup(defFlags), new ConditionOf(expr.CloneExpression()));
        }

        private void RewriteCmp()
        {
            Expression op1 = SrcOp(di.Instruction.op1);
            Expression op2 = SrcOp(di.Instruction.op2, di.Instruction.op1.Width);
            emitter.Assign(
                orw.FlagGroup(IntelInstruction.DefCc(Opcode.cmp)),
                new ConditionOf(emitter.Sub(op1, op2)));
        }

        private void RewriteCwd()
        {
            if (di.Instruction.dataWidth == PrimitiveType.Word32)
            {
                Identifier edx_eax = frame.EnsureSequence(
                    orw.AluRegister(Registers.edx),
                    orw.AluRegister(Registers.eax),
                    PrimitiveType.Int64);
                emitter.Assign(
                    edx_eax, emitter.Cast(edx_eax.DataType, orw.AluRegister(Registers.eax)));
            }
            else
            {
                Identifier dx_ax = frame.EnsureSequence(
                    orw.AluRegister(Registers.dx),
                    orw.AluRegister(Registers.ax),
                    PrimitiveType.Int32);
                emitter.Assign(
                    dx_ax, emitter.Cast(dx_ax.DataType, orw.AluRegister(Registers.ax)));
            }
        }

        private void EmitDaaDas(string fnName)
        {
            emitter.Assign(orw.FlagGroup(FlagM.CF), PseudoProc(
                fnName,
                PrimitiveType.Bool,
                orw.AluRegister(Registers.al),
                orw.AddrOf(orw.AluRegister(Registers.al))));
        }

        private void RewriteDivide(BinaryOperator op, Domain domain)
        {
            if (di.Instruction.Operands != 1)
                throw new ArgumentOutOfRangeException("Intel DIV/IDIV instructions only take one operand");
            Identifier regDividend;
            Identifier regQuotient;
            Identifier regRemainder;

            switch (di.Instruction.dataWidth.Size)
            {
            case 1:
                regQuotient = orw.AluRegister(Registers.al);
                regDividend = orw.AluRegister(Registers.ax);
                regRemainder = orw.AluRegister(Registers.ah);
                break;
            case 2:
                regQuotient = orw.AluRegister(Registers.ax);
                regRemainder = orw.AluRegister(Registers.dx);
                regDividend = frame.EnsureSequence(regRemainder, regQuotient, PrimitiveType.Word32);
                break;
            case 4:
                regQuotient = orw.AluRegister(Registers.eax);
                regRemainder = orw.AluRegister(Registers.edx);
                regDividend = frame.EnsureSequence(regRemainder, regQuotient, PrimitiveType.Word64);
                break;
            default:
                throw new ArgumentOutOfRangeException(string.Format("{0}-byte divisions not supported", di.Instruction.dataWidth.Size));
            };
            PrimitiveType p = ((PrimitiveType)regRemainder.DataType).MaskDomain(domain);
            emitter.Assign(
                regRemainder, new BinaryExpression(Operator.Mod, p,
                regDividend,
                SrcOp(di.Instruction.op1)));
            var ass = emitter.Assign(
                regQuotient, new BinaryExpression(op, p, regDividend,
                SrcOp(di.Instruction.op1)));
            EmitCcInstr(ass.Dst, IntelInstruction.DefCc(di.Instruction.code));
        }

        private void RewriteEnter()
        {
            var bp = orw.AluRegister(Registers.ebp.GetPart(di.Instruction.dataWidth));
            RewritePush(di.Instruction.dataWidth, bp);
            var sp = StackPointer();
            emitter.Assign(bp, sp);
            var cbExtraSavedBytes = 
                di.Instruction.dataWidth.Size * ((ImmediateOperand)di.Instruction.op2).Value.ToInt32() +
                ((ImmediateOperand)di.Instruction.op1).Value.ToInt32();
            if (cbExtraSavedBytes != 0)
            {
                emitter.Assign(sp, emitter.Sub(sp, cbExtraSavedBytes));
            }
        }

        private void RewriteExchange()
        {
            Identifier itmp = frame.CreateTemporary(di.Instruction.dataWidth);
            emitter.Assign(itmp, SrcOp(di.Instruction.op1));
            EmitCopy(di.Instruction.op1, SrcOp(di.Instruction.op2), false);
            EmitCopy(di.Instruction.op2, itmp, false);
        }

        private void RewriteIncDec(int amount)
        {
            var op = Operator.Add;
            if (amount < 0)
            {
                op= Operator.Sub;
                amount = -amount;
            }

            var ass = EmitBinOp(op,
                di.Instruction.op1,
                di.Instruction.op1.Width,
                SrcOp(di.Instruction.op1),
                emitter.Const(di.Instruction.op1.Width, amount));
            EmitCcInstr(ass.Dst, IntelInstruction.DefCc(di.Instruction.code));
        }

        private void RewriteLogical(BinaryOperator op)
        {
            if (di.Instruction.code == Opcode.and)
            {
                var r = di.Instruction.op1 as RegisterOperand;
                if (r != null && r.Register == arch.StackRegister &&
                    di.Instruction.op2 is ImmediateOperand)
                {
                    emitter.SideEffect(PseudoProc("__align", PrimitiveType.Void, SrcOp(di.Instruction.op1)));
                    return;
                }
            }

            var ass = EmitBinOp(
                op,
                di.Instruction.op1,
                di.Instruction.op1.Width,
                SrcOp(di.Instruction.op1),
                SrcOp(di.Instruction.op2));
            EmitCcInstr(ass.Dst, (IntelInstruction.DefCc(di.Instruction.code) & ~FlagM.CF));
            emitter.Assign(orw.FlagGroup(FlagM.CF), Constant.False());
        }

        private void RewriteMultiply(BinaryOperator op, Domain resultDomain)
        {
            RtlAssignment ass;
            switch (di.Instruction.Operands)
            {
            case 1:
                {
                    Identifier multiplicator;
                    Identifier product;

                    switch (di.Instruction.op1.Width.Size)
                    {
                    case 1:
                        multiplicator = orw.AluRegister(Registers.al);
                        product = orw.AluRegister(Registers.ax);
                        break;
                    case 2:
                        multiplicator = orw.AluRegister(Registers.ax);
                        product = frame.EnsureSequence(
                            orw.AluRegister(Registers.dx), multiplicator, PrimitiveType.Word32);
                        break;
                    case 4:
                        multiplicator = orw.AluRegister(Registers.eax);
                        product = frame.EnsureSequence(
                            orw.AluRegister(Registers.edx), multiplicator, PrimitiveType.Word64);
                        break;
                    default:
                        throw new ApplicationException(string.Format("Unexpected operand size: {0}", di.Instruction.op1.Width));
                    };
                    ass = emitter.Assign(product,
                        new BinaryExpression(op, PrimitiveType.Create(resultDomain, product.DataType.Size), SrcOp(di.Instruction.op1), multiplicator));
                }
                break;
            case 2:
                ass = EmitBinOp(op, di.Instruction.op1, di.Instruction.op1.Width.MaskDomain(resultDomain), SrcOp(di.Instruction.op1), SrcOp(di.Instruction.op2));
                break;
            case 3:
                ass = EmitBinOp(op, di.Instruction.op1, di.Instruction.op1.Width.MaskDomain(resultDomain), SrcOp(di.Instruction.op2), SrcOp(di.Instruction.op3));
                break;
            default:
                throw new ArgumentException("Invalid number of operands");
            }
            EmitCcInstr(ass.Dst, IntelInstruction.DefCc(di.Instruction.code));
        }

        private void RewriteIn()
        {
            var ppName = "__in" + IntelSizeSuffix(di.Instruction.op1.Width.Size);
            EmitCopy(
                di.Instruction.op1,
                PseudoProc(ppName, di.Instruction.op1.Width, SrcOp(di.Instruction.op2)), false);
        }

        private string IntelSizeSuffix(int size)
        {
            switch (size)
            {
            case 1: return "b";
            case 2: return "w";
            case 4: return "dw";
            case 8: return "qw";
            default: throw new ArgumentOutOfRangeException("Size is not 1,2,4 or 8");
            }
        }

        public void RewriteLahf()
        {
            emitter.Assign(orw.AluRegister(Registers.ah), orw.FlagGroup(FlagM.FPUF));
        }

        public void RewriteLea()
        {
            Expression src;
            MemoryOperand mem = (MemoryOperand)di.Instruction.op2;
            if (mem.Base == RegisterStorage.None && mem.Index == RegisterStorage.None)
            {
                src = mem.Offset;
            }
            else
            {
                src = SrcOp(di.Instruction.op2);
                MemoryAccess load = src as MemoryAccess;
                if (load != null)
                {
                    src = load.EffectiveAddress;
                }
                else
                {
                    src = orw.AddrOf(src);
                }
            }
            EmitCopy(di.Instruction.op1, src, false);
        }

        private void RewriteLeave()
        {
            var sp = orw.AluRegister(arch.StackRegister);
            var bp = orw.AluRegister(Registers.ebp.GetPart(arch.StackRegister.DataType));
            emitter.Assign(sp, bp);
            emitter.Assign(bp, orw.StackAccess(sp, bp.DataType));
            emitter.Assign(sp, emitter.Add(sp, bp.DataType.Size));
        }

        private void RewriteLxs(RegisterStorage seg)
        {
            var reg = (RegisterOperand)di.Instruction.op1;
            MemoryOperand mem = (MemoryOperand)di.Instruction.op2;
            if (!mem.Offset.IsValid)
            {
                mem = new MemoryOperand(mem.Width, mem.Base, mem.Index, mem.Scale, new Constant(di.Instruction.addrWidth, 0));
            }

            var ass = emitter.Assign(
                frame.EnsureSequence(orw.AluRegister(seg), orw.AluRegister(reg.Register),
                PrimitiveType.Pointer32),
                SrcOp(mem));
            ass.Src.DataType = PrimitiveType.Pointer32;
        }

        private void RewriteMov()
        {
            EmitCopy(di.Instruction.op1, SrcOp(di.Instruction.op2, di.Instruction.op1.Width), false);
        }

        private void RewritePush()
        {
            RegisterOperand reg = di.Instruction.op1 as RegisterOperand;
            if (reg != null && reg.Register == Registers.cs)
            {
                if (dasm.Peek(1).Instruction.code == Opcode.call &&
                    dasm.Peek(1).Instruction.op1.Width == PrimitiveType.Word16)
                {
                    dasm.MoveNext();
                    emitter.Assign(StackPointer(), emitter.Sub(StackPointer(), reg.Register.DataType.Size));
                    RewriteCall(dasm.Current.Instruction.op1, dasm.Current.Instruction.op1.Width);
                    return;
                }

                if (
                    dasm.Peek(1).Instruction.code == Opcode.push && (dasm.Peek(1).Instruction.op1 is ImmediateOperand) &&
                    dasm.Peek(2).Instruction.code == Opcode.push && (dasm.Peek(2).Instruction.op1 is ImmediateOperand) &&
                    dasm.Peek(3).Instruction.code == Opcode.jmp && (dasm.Peek(3).Instruction.op1 is AddressOperand))
                {
                    // That's actually a far call, but the callee thinks its a near call.
                    RewriteCall(dasm.Peek(3).Instruction.op1, di.Instruction.op1.Width);
                    dasm.MoveNext();
                    dasm.MoveNext();
                    dasm.MoveNext();
                    return;
                }
            }
            Debug.Assert(dasm.Current.Instruction.dataWidth == PrimitiveType.Word16 || dasm.Current.Instruction.dataWidth == PrimitiveType.Word32);
            RewritePush(dasm.Current.Instruction.dataWidth, SrcOp(dasm.Current.Instruction.op1));
        }

        private void RewritePush(IntelRegister reg)
        {
            RewritePush(di.Instruction.dataWidth, orw.AluRegister(reg));
        }

        private void RewritePusha()
        {
            if (di.Instruction.dataWidth == PrimitiveType.Word16)
            {
                RewritePush(Registers.ax);
                RewritePush(Registers.cx);
                RewritePush(Registers.dx);
                RewritePush(Registers.bx);
                RewritePush(Registers.sp);
                RewritePush(Registers.bp);
                RewritePush(Registers.si);
                RewritePush(Registers.di);
            }
            else
            {
                RewritePush(Registers.eax);
                RewritePush(Registers.ecx);
                RewritePush(Registers.edx);
                RewritePush(Registers.ebx);
                RewritePush(Registers.esp);
                RewritePush(Registers.ebp);
                RewritePush(Registers.esi);
                RewritePush(Registers.edi);
            }
        }

        private void RewritePushf()
        {
            RewritePush(
                dasm.Current.Instruction.dataWidth,
                frame.EnsureFlagGroup(
                    (uint)(FlagM.SF | FlagM.CF | FlagM.ZF | FlagM.DF | FlagM.OF | FlagM.PF),
                    "SCZDOP", 
                    PrimitiveType.Byte));
        }

        private void RewriteNeg()
        {
            Expression tmp = RewriteUnaryOperator(Operator.Neg, di.Instruction.op1, di.Instruction.op1);
            EmitCcInstr(tmp, IntelInstruction.DefCc(di.Instruction.code));
            emitter.Assign(orw.FlagGroup(FlagM.CF), emitter.Eq0(tmp));
        }

        private void RewriteNot()
        {
            Expression tmp = RewriteUnaryOperator(Operator.Comp, di.Instruction.op1, di.Instruction.op1);
        }

        private void RewriteOut()
        {
            var ppp = host.EnsurePseudoProcedure("__out" + di.Instruction.op2.Width.Prefix, PrimitiveType.Void, 2);
            emitter.SideEffect(emitter.Fn(ppp, 
                SrcOp(di.Instruction.op1),
                SrcOp(di.Instruction.op2)));
        }
        private void RewritePop()
        {
            RewritePop(dasm.Current.Instruction.op1, dasm.Current.Instruction.op1.Width);
        }

        private void RewritePop(MachineOperand op, PrimitiveType width)
        {
            var sp = StackPointer();
            EmitCopy(op, orw.StackAccess(sp, width), false);
            emitter.Assign(sp, emitter.Add(sp, width.Size));
        }

        private void RewritePop(Identifier dst, PrimitiveType width)
        {
            var sp = StackPointer();
            emitter.Assign(dst, orw.StackAccess(sp, width));
            emitter.Assign(sp, emitter.Add(sp, width.Size));
        }

        private void EmitPop(IntelRegister reg)
        {
            RewritePop(orw.AluRegister(reg), di.Instruction.dataWidth);
        }

        private void RewritePopa()
        {
            Debug.Assert(di.Instruction.dataWidth == PrimitiveType.Word16 || di.Instruction.dataWidth == PrimitiveType.Word32);
            var sp = StackPointer();
            if (di.Instruction.dataWidth == PrimitiveType.Word16)
            {
                EmitPop(Registers.di);
                EmitPop(Registers.si);
                EmitPop(Registers.bp);
                emitter.Assign(sp, emitter.Add(sp, di.Instruction.dataWidth.Size));
                EmitPop(Registers.bx);
                EmitPop(Registers.dx);
                EmitPop(Registers.cx);
                EmitPop(Registers.ax);
            }
            else
            {
                EmitPop(Registers.edi);
                EmitPop(Registers.esi);
                EmitPop(Registers.ebp);
                emitter.Assign(sp, emitter.Add(sp, di.Instruction.dataWidth.Size));
                EmitPop(Registers.ebx);
                EmitPop(Registers.edx);
                EmitPop(Registers.ecx);
                EmitPop(Registers.eax);
            }
        }

        private void RewritePopf()
        {
            var width = di.Instruction.dataWidth;
            var sp = StackPointer();
            emitter.Assign(frame.EnsureFlagGroup(
                    (uint)(FlagM.SF | FlagM.CF | FlagM.ZF | FlagM.DF | FlagM.OF | FlagM.PF),
                    "SCZDOP",
                    PrimitiveType.Byte),
                    orw.StackAccess(sp, width));
            emitter.Assign(sp, emitter.Add(sp, width.Size));
        }

        private void RewritePush(PrimitiveType dataWidth, Expression expr)
        {
            Constant c = expr as Constant;
            if (c != null && c.DataType != dataWidth)
            {
                expr = new Constant(dataWidth, c.ToInt64());
            }

            // Allocate an local variable for the push.

            var sp = StackPointer();
            emitter.Assign(sp, emitter.Sub(sp, dataWidth.Size));
            emitter.Assign(orw.StackAccess(sp, dataWidth), expr);
        }

        private void RewriteRotation(string operation, bool useCarry, bool left)
        {
            Identifier t = null;
            Expression sh;
            if (left)
            {
                sh = new BinaryExpression(
                    Operator.Sub,
                    di.Instruction.op2.Width,
                    new Constant(di.Instruction.op2.Width, di.Instruction.op1.Width.BitSize),
                    SrcOp(di.Instruction.op2));
            }
            else
            {
                sh = SrcOp(di.Instruction.op2);
            }
            sh = new BinaryExpression(
                Operator.Shl,
                di.Instruction.op1.Width,
                new Constant(di.Instruction.op1.Width, 1),
                sh);
            t = frame.CreateTemporary(PrimitiveType.Bool);
            emitter.Assign(t, emitter.Ne0(emitter.And(SrcOp(di.Instruction.op1), sh)));
            Expression p;
            if (useCarry)
            {
                p = PseudoProc(operation, di.Instruction.op1.Width, SrcOp(di.Instruction.op1), SrcOp(di.Instruction.op2), orw.FlagGroup(FlagM.CF));
            }
            else
            {
                p = PseudoProc(operation, di.Instruction.op1.Width, SrcOp(di.Instruction.op1), SrcOp(di.Instruction.op2));
            }
            EmitCopy(di.Instruction.op1, p, false);
            if (t != null)
                emitter.Assign(orw.FlagGroup(FlagM.CF), t);
        }

        private void RewriteSet( ConditionCode cc)
        {
            EmitCopy(di.Instruction.op1, new TestCondition(cc, orw.FlagGroup(IntelInstruction.UseCc(di.Instruction.code))), false);
        }

        private void RewriteShxd(string name)
        {
            var ppp = host.EnsurePseudoProcedure(name, di.Instruction.op1.Width, 3);
            EmitCopy(di.Instruction.op1, emitter.Fn(ppp,
                            SrcOp(di.Instruction.op1),
                            SrcOp(di.Instruction.op2),
                            SrcOp(di.Instruction.op3)), false);
        }

        public MemoryAccess MemDi()
		{
			if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
			{
				return new SegmentedAccess(MemoryIdentifier.GlobalMemory, orw.AluRegister(Registers.es), RegDi, di.Instruction.dataWidth);
			}
			else
				return new MemoryAccess(MemoryIdentifier.GlobalMemory, RegDi, di.Instruction.dataWidth);
		}

		public MemoryAccess MemSi()
		{
			if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
			{
				return new SegmentedAccess(MemoryIdentifier.GlobalMemory, orw.AluRegister(Registers.ds), RegSi, di.Instruction.dataWidth);
			}
			else
				return new MemoryAccess(MemoryIdentifier.GlobalMemory, RegSi, di.Instruction.dataWidth);
		}

        public MemoryAccess Mem(Expression defaultSegment, Expression effectiveAddress)
        {
            if (arch.ProcessorMode != ProcessorMode.ProtectedFlat)
            {
                return new SegmentedAccess(MemoryIdentifier.GlobalMemory, defaultSegment, effectiveAddress, di.Instruction.dataWidth);
            }
            else
                return new MemoryAccess(MemoryIdentifier.GlobalMemory, effectiveAddress, di.Instruction.dataWidth);
        }

		public Identifier RegAl
		{
			get { return orw.AluRegister(Registers.eax, di.Instruction.dataWidth); }
		}

		public Identifier RegDi
		{
			get { return orw.AluRegister(Registers.edi, di.Instruction.addrWidth); }
		}

		public Identifier RegSi
		{
			get { return orw.AluRegister(Registers.esi, di.Instruction.addrWidth); }
		}
	
        private void RewriteStringInstruction()
        {
            bool incSi = false;
            bool incDi = false;
            Identifier regDX;
            PseudoProcedure ppp;
            switch (di.Instruction.code)
            {
            default:
                throw new NotSupportedException(string.Format("'{0}' is not an x86 string instruction.", di.Instruction.code));
            case Opcode.cmps:
            case Opcode.cmpsb:
                emitter.Assign(
                    orw.FlagGroup(IntelInstruction.DefCc(Opcode.cmp)),
                    new ConditionOf(
                    new BinaryExpression(Operator.Sub, di.Instruction.dataWidth, MemSi(), MemDi())));
                incSi = true;
                incDi = true;
                break;
            case Opcode.lods:
            case Opcode.lodsb:
                emitter.Assign(RegAl, MemSi());
                incSi = true;
                break;
            case Opcode.movs:
            case Opcode.movsb:
                Identifier tmp = frame.CreateTemporary(di.Instruction.dataWidth);
                emitter.Assign(tmp, MemSi());
                emitter.Assign(MemDi(), tmp);
                incSi = true;
                incDi = true;
                break;
            case Opcode.ins:
            case Opcode.insb:
                regDX = orw.AluRegister(Registers.edx, di.Instruction.addrWidth);
                ppp = host.EnsurePseudoProcedure("__in", di.Instruction.dataWidth, 1);
                emitter.Assign(MemDi(), emitter.Fn(ppp, regDX));
                incDi = true;
                break;
            case Opcode.outs:
            case Opcode.outsb:
                regDX = orw.AluRegister(Registers.edx, di.Instruction.addrWidth);
                ppp = host.EnsurePseudoProcedure("__out" + RegAl.DataType.Prefix, PrimitiveType.Void, 2);
                emitter.SideEffect(emitter.Fn(ppp, regDX, RegAl));
                incSi = true;
                break;
            case Opcode.scas:
            case Opcode.scasb:
                emitter.Assign(
                    orw.FlagGroup(IntelInstruction.DefCc(Opcode.cmp)),
                    new ConditionOf(
                    new BinaryExpression(Operator.Sub,
                    di.Instruction.dataWidth,
                    RegAl,
                    MemDi())));
                incDi = true;
                break;
            case Opcode.stos:
            case Opcode.stosb:
                emitter.Assign(MemDi(), RegAl);
                incDi = true;
                break;
            }

            if (incSi)
            {
                emitter.Assign(RegSi,
                    new BinaryExpression(Operator.Add,
                    di.Instruction.addrWidth,
                    RegSi,
                    new Constant(di.Instruction.addrWidth, di.Instruction.dataWidth.Size)));
            }

            if (incDi)
            {
                emitter.Assign(RegDi,
                    new BinaryExpression(Operator.Add,
                    di.Instruction.addrWidth,
                    RegDi,
                    new Constant(di.Instruction.addrWidth, di.Instruction.dataWidth.Size)));
            }
        }

        private void RewriteTest()
        {
            var src = new BinaryExpression(Operator.And,
                di.Instruction.op1.Width,
                SrcOp(di.Instruction.op1),
                                SrcOp(di.Instruction.op2));

            EmitCcInstr(src, (IntelInstruction.DefCc(di.Instruction.code) & ~FlagM.CF));
            emitter.Assign(orw.FlagGroup(FlagM.CF), Constant.False());
        }

        private Expression RewriteUnaryOperator(UnaryOperator op, MachineOperand opDst, MachineOperand opSrc)
        {
            Expression src = SrcOp(opSrc);
            if (src is MemoryAccess)
            {
                Identifier tmp = frame.CreateTemporary(opDst.Width);
                emitter.Assign(tmp, src);
                var acc = orw.CreateMemoryAccess((MemoryOperand)opDst, state);
                emitter.Assign(acc, new UnaryExpression(op, opSrc.Width, tmp));
                return tmp;
            }
            else
            {
                EmitCopy(opDst, new UnaryExpression(op, opSrc.Width, src), false);
                return src;
            }
        }

        private void RewriteXlat()
        {
            var al = orw.AluRegister(Registers.al);
            var bx = orw.AluRegister(Registers.ebx, di.Instruction.addrWidth);
            var offsetType = PrimitiveType.Create(Domain.UnsignedInt, bx.DataType.Size); 
            emitter.Assign(
                al,
                Mem(
                    orw.AluRegister(Registers.ds),
                    emitter.Add(
                        bx,
                        emitter.Cast(offsetType, al))));
        }

        private Identifier StackPointer()
        {
            return frame.EnsureRegister(arch.ProcessorMode.StackRegister);
        }
    }
}
