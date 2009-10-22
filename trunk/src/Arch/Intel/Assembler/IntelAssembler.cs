/* 
 * Copyright (C) 1999-2009 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Decompiler.Arch.Intel.Assembler
{
    /// <summary>
	/// A crude MASM-style assembler for x86 opcodes.
	/// </summary>
    public class IntelAssembler
    {
        private Program prog;
        private Address addrBase;
        private ModRmBuilder modRm;
        private Emitter emitter;
        private SymbolTable symtab;
        private List<EntryPoint> entryPoints;
        private SortedDictionary<string, SignatureLibrary> importLibraries;

        public IntelAssembler(Program prog, PrimitiveType defaultWordSize, Address addrBase, Emitter emitter, List<EntryPoint> entryPoints)
        {
            this.prog = prog;
            this.addrBase = addrBase;
            this.emitter = emitter;
            this.entryPoints = entryPoints;
            modRm = new ModRmBuilder(defaultWordSize, emitter);
            symtab = new SymbolTable();
            importLibraries = new SortedDictionary<string, SignatureLibrary>();

            SetDefaultWordWidth(defaultWordSize);
        }

        public ProgramImage GetImage()
        {
            return new ProgramImage(addrBase, emitter.Bytes);
        }

        public void Mov(ParsedOperand op, int constant)
        {
            ProcessMov(
                op,
                new ParsedOperand(new ImmediateOperand(IntelAssembler.IntegralConstant(constant, op.Operand.Width))));
        }

        public void Mov(ParsedOperand dst, ParsedOperand src)
        {
            ProcessMov(dst, src);
        }


        public ParsedOperand BytePtr(int offset)
        {
            return new ParsedOperand(
                new MemoryOperand(PrimitiveType.Byte, new Constant(emitter.AddressWidth, offset)));
        }

        internal void ProcessComm(string sym)
        {
            DefineSymbol(sym);
            emitter.EmitDword(0);
        }

        public void ProcessImul(params ParsedOperand[] ops)
        {
            PrimitiveType dataWidth;
            if (ops.Length == 1)
            {
                dataWidth = EnsureValidOperandSize(ops[0]);
                emitter.EmitOpcode(0xF6 | IsWordWidth(ops[0].Operand), dataWidth);
                EmitModRM(0x05, ops[0]);
            }
            else
            {
                dataWidth = EnsureValidOperandSizes(ops, 2);
                RegisterOperand regOp = ops[0].Operand as RegisterOperand;
                if (regOp == null)
                    throw new ApplicationException("First operand must be a register");
                if (IsWordWidth(regOp) == 0)
                    throw new ApplicationException("Destination register must be word-width");

                if (ops.Length == 2)
                {
                    emitter.EmitOpcode(0x0F, dataWidth);
                    emitter.EmitByte(0xAF);
                    EmitModRM(RegisterEncoding(regOp.Register), ops[1]);
                }
                else
                {
                    ImmediateOperand op3 = ops[2].Operand as ImmediateOperand;
                    if (op3 == null)
                        throw new ApplicationException("Third operand must be an immediate value");
                    if (IsSignedByte(op3.Value.ToInt32()))
                    {
                        emitter.EmitOpcode(0x6B, dataWidth);
                        EmitModRM(RegisterEncoding(regOp.Register), ops[1]);
                        emitter.EmitByte(op3.Value.ToInt32());
                    }
                    else
                    {
                        emitter.EmitOpcode(0x69, dataWidth);
                        EmitModRM(RegisterEncoding(regOp.Register), ops[1]);
                        emitter.EmitImmediate(op3.Value, dataWidth);
                    }
                }
            }
        }

        internal void ProcessIncDec(bool fDec, ParsedOperand op)
        {
            PrimitiveType dataWidth = EnsureValidOperandSize(op);
            RegisterOperand regOp = op.Operand as RegisterOperand;
            if (regOp != null)
            {
                if (IsWordWidth(dataWidth) != 0)
                {
                    emitter.EmitOpcode((fDec ? 0x48 : 0x40) | RegisterEncoding(regOp.Register), dataWidth);
                }
                else
                {
                    emitter.EmitOpcode(0xFE | IsWordWidth(dataWidth), dataWidth);
                    EmitModRM(fDec ? 1 : 0, op);
                }
                return;
            }

            MemoryOperand memOp = op.Operand as MemoryOperand;
            if (memOp != null)
            {
                emitter.EmitOpcode(0xFE | IsWordWidth(dataWidth), dataWidth);
                EmitModRM(fDec ? 1 : 0, op);
            }
            else
            {
                throw new ApplicationException("constant operator illegal");
            }
        }

        public void ProcessInOut(bool fOut, ParsedOperand[] ops)
        {
            ParsedOperand opPort;
            ParsedOperand opData;

            if (fOut)
            {
                opPort = ops[0];
                opData = ops[1];
            }
            else
            {
                opData = ops[0];
                opPort = ops[1];
            }

            RegisterOperand regOpData = opData.Operand as RegisterOperand;
            if (regOpData == null || IsAccumulator(regOpData.Register) == 0)
                throw new ApplicationException("invalid register for in or out instruction");

            int opcode = IsWordWidth(regOpData) | (fOut ? 0xE6 : 0xE4);

            RegisterOperand regOpPort = opPort.Operand as RegisterOperand;
            if (regOpPort != null)
            {
                if (regOpPort.Register == Registers.dx || regOpPort.Register == Registers.edx)
                {
                    emitter.EmitOpcode(8 | opcode, regOpPort.Width);
                }
                else
                    throw new ApplicationException("port must be specified with 'immediate', dx, or edx register");
                return;
            }

            ImmediateOperand immOp = opPort.Operand as ImmediateOperand;
            if (immOp != null)
            {
                if (immOp.Value.ToUInt32() > 0xFF)
                {
                    throw new ApplicationException("port number must be between 0 and 255");
                }
                else
                {
                    emitter.EmitOpcode(opcode, regOpPort.Width);
                    emitter.EmitByte(immOp.Value.ToInt32());
                }
            }
            else
            {
                throw new ApplicationException("port must be specified with 'immediate', dx, or edx register");
            }
        }

        internal void ProcessLongBranch(int cc, string destination)
        {
            emitter.EmitOpcode(0x0F, null);
            emitter.EmitByte(0x80 | cc);
            EmitRelativeTarget(destination, emitter.SegmentAddressWidth);
        }

        internal void ProcessShortBranch(int cc, string destination)
        {
            emitter.EmitOpcode(0x70 | cc, null);
            EmitRelativeTarget(destination, PrimitiveType.Byte);
        }

        internal void ProcessLoop(int opcode, string destination)
        {
            emitter.EmitOpcode(0xE0 | opcode, null);
            emitter.EmitByte(-(emitter.Length + 1));
            ReferToSymbol(symtab.CreateSymbol(destination),
                emitter.Length - 1, PrimitiveType.Byte);
        }

        public void ProcessLxs(int prefix, int b, params ParsedOperand[] ops)
        {
            RegisterOperand opDst = (RegisterOperand) ops[0].Operand;

            if (prefix > 0)
            {
                emitter.EmitOpcode(prefix, opDst.Width);
                emitter.EmitByte(b);
            }
            else
                emitter.EmitOpcode(b, emitter.SegmentDataWidth);
            EmitModRM(RegisterEncoding(opDst.Register), ops[1]);
        }


        internal void ProcessMov(params ParsedOperand[] ops)
        {
            PrimitiveType dataWidth = EnsureValidOperandSizes(ops, 2);

            RegisterOperand regOpSrc = ops[1].Operand as RegisterOperand;
            RegisterOperand regOpDst = ops[0].Operand as RegisterOperand;
            if (regOpDst != null)	//$BUG: what about segment registers?
            {
                byte reg = RegisterEncoding(regOpDst.Register);
                if (regOpDst.Register is SegmentRegister)
                {
                    if (regOpSrc.Register is SegmentRegister)
                        Error("Cannot assign between two segment registers");
                    if (ops[1].Operand.Width != PrimitiveType.Word16)
                        Error(string.Format("Values assigned to/from segment registers must be 16 bits wide"));
                    emitter.EmitOpcode(0x8E, PrimitiveType.Word16);
                    EmitModRM(reg, ops[1]);
                    return;
                }

                if (regOpSrc != null && regOpSrc.Register is SegmentRegister)
                {
                    if (regOpDst.Register is SegmentRegister)
                        Error("Cannot assign between two segment registers");
                    if (ops[0].Operand.Width != PrimitiveType.Word16)
                        Error(string.Format("Values assigned to/from segment registers must be 16 bits wide"));
                    emitter.EmitOpcode(0x8C, PrimitiveType.Word16);
                    EmitModRM(RegisterEncoding(regOpSrc.Register), ops[0]);
                    return;
                }

                int isWord = IsWordWidth(regOpDst);
                if (regOpSrc != null)
                {
                    if (regOpSrc.Width != regOpDst.Width)
                        this.Error(string.Format("size mismatch between {0} and {1}", regOpSrc.Register, regOpDst.Register));
                    emitter.EmitOpcode(0x8A | (isWord & 1), dataWidth);
                    modRm.EmitModRM(reg, regOpSrc);
                    return;
                }

                MemoryOperand memOpSrc = ops[1].Operand as MemoryOperand;
                if (memOpSrc != null)
                {
                    emitter.EmitOpcode(0x8A | (isWord & 1), dataWidth);
                    EmitModRM(reg, memOpSrc, ops[1].Symbol);
                    return;
                }

                ImmediateOperand immOpSrc = ops[1].Operand as ImmediateOperand;
                if (immOpSrc != null)
                {
                    emitter.EmitOpcode(0xB0 | (isWord << 3) | reg, dataWidth);
                    if (isWord != 0)
                        emitter.EmitInteger(dataWidth, immOpSrc.Value.ToInt32());
                    else
                        emitter.EmitByte(immOpSrc.Value.ToInt32());

                    if (ops[1].Symbol != null && isWord != 0)
                    {
                        ReferToSymbol(ops[1].Symbol, emitter.Length - (int) immOpSrc.Width.Size, immOpSrc.Width);
                    }
                    return;
                }
                throw new ApplicationException("unexpected");
            }

            MemoryOperand memOpDst = (MemoryOperand) ops[0].Operand;
            regOpSrc = ops[1].Operand as RegisterOperand;
            if (regOpSrc != null)
            {
                if (regOpSrc.Register is SegmentRegister)
                {
                    emitter.EmitOpcode(0x8C, PrimitiveType.Word16);
                }
                else
                {
                    emitter.EmitOpcode(0x88 | IsWordWidth(ops[1].Operand), dataWidth);
                }
                EmitModRM(RegisterEncoding(regOpSrc.Register), memOpDst, ops[0].Symbol);
            }
            else
            {
                ImmediateOperand immOpSrc = (ImmediateOperand) ops[1].Operand;
                int isWord = (dataWidth != PrimitiveType.Byte) ? 1 : 0;
                emitter.EmitOpcode(0xC6 | IsWordWidth(dataWidth), dataWidth);
                EmitModRM(0, memOpDst, ops[0].Symbol);
                emitter.EmitImmediate(immOpSrc.Value, dataWidth);
            }
        }

        internal void ProcessPushPop(bool fPop, ParsedOperand op)
        {
            int imm;
			ImmediateOperand immOp = op.Operand as ImmediateOperand;
			if (immOp != null)
			{
				if (fPop)
					throw new ApplicationException("Can't pop an immediate value");
				imm = immOp.Value.ToInt32();
				if (IsSignedByte(imm))
				{
					emitter.EmitOpcode(0x6A, PrimitiveType.Byte);
					emitter.EmitByte(imm);
				}
				else
				{
					emitter.EmitOpcode(0x68, emitter.SegmentDataWidth);
					emitter.EmitInteger(emitter.SegmentDataWidth, imm);
				}
				return;
			}

			PrimitiveType dataWidth = EnsureValidOperandSize(op);
			RegisterOperand regOp = op.Operand as RegisterOperand;
			if (regOp != null)
			{
                IntelRegister rrr = (IntelRegister) regOp.Register;
				if (rrr.IsBaseRegister)
				{
					emitter.EmitOpcode(0x50 | (fPop ? 8 : 0) | RegisterEncoding(regOp.Register), dataWidth);
				}
				else
				{
					int mask = (fPop ? 1 : 0);
					if (regOp.Register == Registers.es) emitter.EmitByte(0x06|mask); else
						if (regOp.Register == Registers.cs) emitter.EmitByte(0x0E|mask); else
						if (regOp.Register == Registers.ss) emitter.EmitByte(0x16|mask); else
						if (regOp.Register == Registers.ds) emitter.EmitByte(0x1E|mask); else
						if (regOp.Register == Registers.fs) { emitter.EmitByte(0x0F); emitter.EmitByte(0xA0|mask); } else
						if (regOp.Register == Registers.gs) { emitter.EmitByte(0x0F); emitter.EmitByte(0xA8|mask); } 
				}
				return;
			}

			emitter.EmitOpcode(fPop ? 0x8F : 0xFF, dataWidth);
            EmitModRM(fPop ? 0 : 6, op);
		}

        internal PrimitiveType EnsureValidOperandSize(ParsedOperand op)
        {
            PrimitiveType w = op.Operand.Width;
            if (w == null)
                Error("Width of the operand is unknown");
            return w;
        }


        internal void ProcessTest(params ParsedOperand[] ops)
        {
            PrimitiveType dataWidth = EnsureValidOperandSizes(ops, 2);

            RegisterOperand regOpSrc;

            byte isWord = (byte) ((dataWidth != PrimitiveType.Byte) ? 0xFF : 0);

            RegisterOperand regOpDst = ops[0].Operand as RegisterOperand;
            if (regOpDst != null)	//$BUG: what about segment registers?
            {
                byte reg = RegisterEncoding(regOpDst.Register);
                regOpSrc = ops[1].Operand as RegisterOperand;
                if (regOpSrc != null)
                {
                    if (regOpSrc.Width != regOpDst.Width)
                        Error("Operand size mismatch");
                    emitter.EmitOpcode(0x84 | (isWord & 1), dataWidth);
                    modRm.EmitModRM(reg, regOpSrc);
                    return;
                }

                MemoryOperand memOpSrc = ops[1].Operand as MemoryOperand;
                if (memOpSrc != null)
                {
                    emitter.EmitOpcode(0x84 | (isWord & 1), dataWidth);
                    EmitModRM(reg, ops[1]);
                    return;
                }

                ImmediateOperand immOpSrc = ops[1].Operand as ImmediateOperand;
                if (immOpSrc != null)
                {
                    emitter.EmitOpcode(0xF6 | (isWord & 1), dataWidth);
                    EmitModRM(0, ops[0]);
                    if (isWord != 0)
                        emitter.EmitInteger(dataWidth, immOpSrc.Value.ToInt32());
                    else
                        emitter.EmitByte(immOpSrc.Value.ToInt32());

                    if (ops[1].Symbol != null && isWord != 0)
                    {
                        Debug.Assert(immOpSrc.Value.ToUInt32() == 0);
                        ReferToSymbol(ops[1].Symbol, emitter.Length - 2, PrimitiveType.Word16);
                    }
                    return;
                }
                throw new ApplicationException("unexpected");
            }

            ImmediateOperand immOp = (ImmediateOperand) ops[1].Operand;
            emitter.EmitOpcode(0xF6 | (isWord & 1), dataWidth);
            EmitModRM(0, ops[0]);
            if (isWord != 0)
                emitter.EmitImmediate(immOp.Value, dataWidth);
            else
                emitter.EmitByte(immOp.Value.ToInt32());

            if (ops[1].Symbol != null && isWord != 0)
            {
                ReferToSymbol(ops[1].Symbol, emitter.Length - 2, PrimitiveType.Word16);
            }
        }

        internal void DefineSymbol(string pstr)
        {
            ResolveSymbol(symtab.DefineSymbol(pstr, emitter.Position));
        }


        internal void EmitModRM(int reg, ParsedOperand op)
        {
            RegisterOperand regOp = op.Operand as RegisterOperand;
            if (regOp != null)
            {
                modRm.EmitModRM(reg, regOp);
                return;
            }
            FpuOperand fpuOp = op.Operand as FpuOperand;
            if (fpuOp != null)
            {
                modRm.EmitModRM(reg, fpuOp);
            }
            else
            {
                EmitModRM(reg, (MemoryOperand) op.Operand, op.Symbol);
            }
        }

        internal void EmitModRM(int reg, ParsedOperand op, byte b)
        {
            RegisterOperand regOp = op.Operand as RegisterOperand;
            if (regOp != null)
            {
                modRm.EmitModRM(reg, regOp);
                emitter.EmitByte(b);
            }
            else
            {
                EmitModRM(reg, (MemoryOperand) op.Operand, b, op.Symbol);
            }
        }


        internal void EmitModRM(int reg, MemoryOperand memOp, Symbol sym)
        {
            Constant offset = modRm.EmitModRMPrefix(reg, memOp);
            int offsetPosition = emitter.Position;
            EmitOffset(offset);
            if (sym != null)
                ReferToSymbol(sym, offsetPosition, offset.DataType);
        }

        internal void EmitModRM(int reg, MemoryOperand memOp, byte b, Symbol sym)
        {
            Constant offset = modRm.EmitModRMPrefix(reg, memOp);
            emitter.EmitByte(b);
            int offsetPosition = emitter.Position;
            EmitOffset(offset);
            if (sym != null)
                ReferToSymbol(sym, emitter.Position, offset.DataType);
        }

        private void EmitOffset(Constant v)
        {
            if (v == null)
                return;
            emitter.EmitInteger((PrimitiveType) v.DataType, v.ToInt32());
        }

        private void EmitRelativeTarget(string target, PrimitiveType offsetSize)
        {
            int offBytes = (int) offsetSize.Size;
            switch (offBytes)
            {
            case 1: emitter.EmitByte(-(emitter.Length + 1)); break;
            case 2: emitter.EmitWord(-(emitter.Length + 2)); break;
            case 4: emitter.EmitDword((uint) -(emitter.Length + 4)); break;
            }
            ReferToSymbol(symtab.CreateSymbol(target),
                emitter.Length - offBytes, offsetSize);
        }




        [Obsolete("Should be private")]
        internal PrimitiveType EnsureValidOperandSizes(ParsedOperand [] ops, int count)
		{
			if (count == 0)
				return null;
			PrimitiveType w = ops[0].Operand.Width;
			if (count == 1 && ops[0].Operand.Width == null)
				Error("Width of the first operand is unknown");
			if (count == 2)
			{
				if (w == null)
				{
					w = ops[1].Operand.Width;
					if (w == null)
						Error("Width of the first operand is unknown");
					else
						ops[0].Operand.Width = w;
				}
				else
				{
					if (ops[1].Operand.Width == null)
						ops[1].Operand.Width = w;
					else if (ops[0].Operand.Width != ops[0].Operand.Width)
						Error("Operand widths don't match");
				}
			}
			return w;
		}

        private int IsAccumulator(MachineRegister reg)
        {
            return (reg == Registers.eax || reg == Registers.ax || reg == Registers.al) ? 1 : 0;
        }

        private bool IsSignedByte(int n)
        {
            return -128 <= n && n < 128;
        }


        private int IsWordWidth(MachineOperand op)
        {
            return IsWordWidth(op.Width);
        }

        internal void SetDefaultWordWidth(PrimitiveType width)
        {
            emitter.SegmentDataWidth = width;
            emitter.SegmentAddressWidth = width;
            modRm = new ModRmBuilder(width, emitter);
            modRm.Error += modRm_Error;
        }



        private int IsWordWidth(PrimitiveType width)
        {
            if (width == null)
                Error("Operand width is undefined");
            if (width.Size == 1)
                return 0;
            return 1;
        }



        private bool Error(string pstr)
        {
            throw new ApplicationException(pstr);
        }


        private void ReferToSymbol(Symbol psym, int off, DataType width)
        {
            if (psym.fResolved)
            {
                emitter.Patch(off, psym.offset, width);
            }
            else
            {
                // Add forward references to the backpatch list.
                psym.AddForwardReference(off, width);
            }
        }

        public static byte RegisterEncoding(byte b)
        {
            return registerEncodings[b];
        }

        public static byte RegisterEncoding(MachineRegister reg)
        {
            return registerEncodings[reg.Number];
        }

        public void ResolveSymbol(Symbol psym)
        {
            Debug.Assert(psym.fResolved);
            foreach (BackPatch patch in psym.patches)
            {
                emitter.Patch(patch.offset, psym.offset, patch.Size);
            }
        }

        public static Constant IntegralConstant(int i, PrimitiveType width)
        {
            if (-0x80 <= i && i < 0x80)
                width = PrimitiveType.SByte;
            else if (width == null)
            {
                if (-0x8000 <= i && i < 0x8000)
                    width = PrimitiveType.Word16;
                else
                    width = PrimitiveType.Word32;
            }
            return new Constant(width, i);
        }

        public static Constant IntegralConstant(int i)
        {
            PrimitiveType width;
            if (-0x80 <= i && i < 0x80)
                width = PrimitiveType.Byte;
            else if (-0x8000 <= i && i < 0x8000)
                width = PrimitiveType.Word16;
            else
                width = PrimitiveType.Word32;
            return new Constant(width, i);
        }


        private void modRm_Error(object sender, ErrorEventArgs args)
        {
            Error(args.Message);
        }

        private static readonly byte[] registerEncodings = 
		{
			0x00, // eax
			0x01, // ecx
			0x02, // edx
			0x03, // ebx
			0x04, // esp
			0x05, // ebp
			0x06, // esi
			0x07, // edi

			0x00, // ax
			0x01, // cx
			0x02, // dx
			0x03, // bx
			0x04, // sp
			0x05, // bp
			0x06, // si
			0x07, // di

			0x00, // al
			0x01, // cl
			0x02, // dl
			0x03, // bl
			0x04, // ah
			0x05, // ch
			0x06, // dh
			0x07, // bh

			0x00, // es
			0x01, // cs
			0x02, // ss
			0x03, // ds
			0x04, // fs
			0x05, // gs
		};




        public void i86()
        {
            IntelArchitecture arch = new IntelArchitecture(ProcessorMode.Real);
            prog.Architecture = arch;
            prog.Platform = new MsDos.MsdosPlatform(arch);
            SetDefaultWordWidth(PrimitiveType.Word16);
        }

        public void Call(string destination)
        {
            ProcessCallJmp(0xE8, destination);
        }

        public void Ret()
        {
            emitter.EmitOpcode(0xC3, null);
        }

        public void Ret(int n)
        {
            emitter.EmitOpcode(0xC2, null);
            emitter.EmitWord(n);
        }

        public void Proc(string procName)
        {
            DefineSymbol(procName);
            if (entryPoints != null && entryPoints.Count == 0)
                entryPoints.Add(new EntryPoint(addrBase + emitter.Position, new IntelState()));
        }

        public void Push(ParsedOperand op)
        {
            ProcessPushPop(false, op);
        }

        public IntelRegister Mem16(object bp, int p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Add(IntelRegister reg, int constant)
        {
            ProcessBinop(
                0x00,
                new ParsedOperand(new RegisterOperand(reg)),
                new ParsedOperand(new ImmediateOperand(IntelAssembler.IntegralConstant(constant))));
        }

        public ParsedOperand WordPtr(int directOffset)
        {
            return new ParsedOperand(new MemoryOperand(
                PrimitiveType.Word16,
                IntegralConstant(directOffset, emitter.AddressWidth)));
        }

        public ParsedOperand WordPtr(ParsedOperand reg, int offset)
        {
            return new ParsedOperand(new MemoryOperand(
                PrimitiveType.Word16,
                ((RegisterOperand) reg.Operand).Register,
                IntegralConstant(offset, emitter.AddressWidth)));
        }

        public void Jz(string destination)
        {
            ProcessShortBranch(0x04, destination);
        }

        public void Dec(ParsedOperand op)
        {
            ProcessIncDec(true, op);
        }

        public void Import(string s, string fnName, string dllName)
        {
            DefineSymbol(s);
            SignatureLibrary lib;
            if (!importLibraries.TryGetValue(dllName, out lib))
            {
                lib = new SignatureLibrary(prog.Architecture);
                lib.Load(Path.ChangeExtension(dllName, ".xml"));
                importLibraries[dllName] = lib;
            }
            AddImport(fnName, lib.Lookup(fnName));
        }

        public void Imul(ParsedOperand dx)
        {
            ProcessImul(dx);
        }

        public void Inc(ParsedOperand op)
        {
            ProcessIncDec(false, op);
        }


        public void Jcxz(string destination)
        {
            emitter.EmitOpcode(0xE3, null);
            EmitRelativeTarget(destination, PrimitiveType.Byte);
        }

        public void Jmp(string destination)
        {
            ProcessCallJmp(0xE9, destination);
        }

        public void Label(string label)
        {
            DefineSymbol(label);
        }

        public void Endp(string p)
        {
        }

        public void Equ(string s, int value)
        {
            symtab.Equates[s] = value;
        }

        internal void Extern(string externSymbol)
        {
            DefineSymbol(externSymbol);
            AddImport(externSymbol, null);
        }

        public void Pop(ParsedOperand op)
        {
            ProcessPushPop(true, op);
        }

        internal void ProcessBinop(int binop, params ParsedOperand[] ops)
        {
            PrimitiveType dataWidth = EnsureValidOperandSizes(ops, 2);
            ImmediateOperand immOp = ops[1].Operand as ImmediateOperand;
            if (immOp != null)
            {
                int imm = immOp.Value.ToInt32();
                RegisterOperand regOpDst = ops[0].Operand as RegisterOperand;
                if (regOpDst != null && IsAccumulator(regOpDst.Register) != 0)
                {
                    emitter.EmitOpcode((binop << 3) | 0x04 | IsWordWidth(ops[0].Operand), dataWidth);
                    emitter.EmitImmediate(immOp.Value, dataWidth);
                    return;
                }

                switch (dataWidth.Size)
                {
                default:
                    Error("Must specify operand width");
                    return;
                case 1:
                    emitter.EmitOpcode(0x80, dataWidth);
                    EmitModRM(binop, ops[0]);
                    emitter.EmitByte(imm);
                    break;
                case 2:
                case 4:
                    if (IsSignedByte(imm))
                    {
                        emitter.EmitOpcode(0x83, dataWidth);
                        EmitModRM(binop, ops[0]);
                        emitter.EmitByte(imm);
                    }
                    else
                    {
                        emitter.EmitOpcode(0x81, dataWidth);
                        EmitModRM(binop, ops[0]);
                        emitter.EmitImmediate(immOp.Value, dataWidth);
                    }
                    break;
                }
                return;
            }

            MemoryOperand memOpDst = ops[0].Operand as MemoryOperand;
            if (memOpDst != null)
            {
                RegisterOperand regOpSrc = (RegisterOperand) ops[1].Operand;
                emitter.EmitOpcode((binop << 3) | 0x00 | IsWordWidth(ops[1].Operand), dataWidth);
                EmitModRM(RegisterEncoding(regOpSrc.Register), ops[0]);
            }
            else
            {
                RegisterOperand regOpDst = ops[0].Operand as RegisterOperand;
                emitter.EmitOpcode((binop << 3) | 0x02 | IsWordWidth(regOpDst), dataWidth);
                EmitModRM(RegisterEncoding(regOpDst.Register), ops[1]);
            }
        }


        internal void ProcessCallJmp(int direct, string destination)
        {
            emitter.EmitOpcode(direct, null);
            EmitRelativeTarget(destination, emitter.SegmentAddressWidth);
        }

        [Obsolete]
        public SymbolTable SymbolTable
        {
            get { return symtab; }
        }

        public void AddImport(string fnName, ProcedureSignature sig)
        {
            uint u = (uint) (addrBase.Linear + emitter.Position);
            prog.ImportThunks.Add(u, new PseudoProcedure(fnName, sig));
            emitter.EmitDword(0);
        }

        internal OperandParser CreateOperandParser(Lexer lexer)
        {
            return new OperandParser(lexer, symtab, addrBase, emitter.SegmentDataWidth, emitter.SegmentAddressWidth);
        }


        internal void Dw(string symbolText)
        {
            DefineWord(PrimitiveType.Word16, symbolText);
        }
        
        internal void DefineWord(PrimitiveType width, string symbolText)
        {
            Symbol sym = symtab.CreateSymbol(symbolText);
            emitter.EmitInteger(width, (int) addrBase.Offset);
            ReferToSymbol(sym, emitter.Length - (int) width.Size, emitter.SegmentAddressWidth);
        }
    }
}
