#region License
/* 
 * Copyright (C) 1999-2013 John K�ll�n.
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
using Decompiler.Core.Types;
using System;

namespace Decompiler.Arch.X86
{
    public abstract class ProcessorMode
    {
        private PrimitiveType wordSize;
        private PrimitiveType framePtrSize;
        private PrimitiveType pointerType;

        //public static readonly ProcessorMode None = new ProcessorMode(null, null, null);
        public static readonly ProcessorMode Real = new RealMode();
        public static readonly ProcessorMode ProtectedSegmented = new SegmentedMode();
        public static readonly ProcessorMode ProtectedFlat = new FlatMode();
        public static readonly ProcessorMode Protected64 = new FlatMode64();

        protected ProcessorMode(PrimitiveType wordSize, PrimitiveType framePointerType, PrimitiveType pointerType)
        {
            this.wordSize = wordSize;
            this.framePtrSize = framePointerType;
            this.pointerType = pointerType;
        }

        public virtual Address AddressFromSegOffset(X86State state, RegisterStorage seg, uint offset)
        {
            return state.AddressFromSegOffset(seg, offset);
        }

        public PrimitiveType FramePointerType
        {
            get { return framePtrSize; }
        }

        public PrimitiveType PointerType
        {
            get { return pointerType; }
        }

        public PrimitiveType WordWidth
        {
            get { return wordSize; }
        }

        public virtual bool IsPointerRegister(RegisterStorage machineRegister)
        {
            return machineRegister == Registers.bx ||
                machineRegister == Registers.sp ||
                machineRegister == Registers.bp ||
                machineRegister == Registers.si ||
                machineRegister == Registers.di;
        }

        public virtual RegisterStorage StackRegister
        {
            get { return Registers.sp; }
        }

        public virtual Expression CreateStackAccess(Frame frame, int offset, DataType dataType)
        {
            var sp = frame.EnsureRegister(Registers.sp);
            var ss = frame.EnsureRegister(Registers.ss);
            return SegmentedAccess.Create(ss, sp, offset, dataType);
        }

        public abstract Address ReadCodeAddress(int byteSize, ImageReader rdr, ProcessorState state);

        protected Address ReadSegmentedCodeAddress(int byteSize, ImageReader rdr, ProcessorState state)
        {
            if (byteSize == PrimitiveType.Word16.Size)
            {
                return new Address(state.GetRegister(Registers.cs).ToUInt16(), rdr.ReadLeUInt16());
            }
            else
            {
                ushort off = rdr.ReadLeUInt16();
                ushort seg = rdr.ReadLeUInt16();
                return new Address(seg, off);
            }
        }
    }

    internal class RealMode : ProcessorMode
    {
        public RealMode()
            : base(PrimitiveType.Word16, PrimitiveType.Ptr16, PrimitiveType.Pointer32)
        {
        }

        public override Address ReadCodeAddress(int byteSize, ImageReader rdr, ProcessorState state)
        {
            return ReadSegmentedCodeAddress(byteSize, rdr, state);
        }
    }

    internal class SegmentedMode : ProcessorMode
    {
        public SegmentedMode()
            : base(PrimitiveType.Word16, PrimitiveType.Ptr16, PrimitiveType.Pointer32)
        {
        }

        public override Address ReadCodeAddress(int byteSize, ImageReader rdr, ProcessorState state)
        {
            return ReadSegmentedCodeAddress(byteSize, rdr, state);
        }
    }

    internal class FlatMode : ProcessorMode
    {
        internal FlatMode()
            : base(PrimitiveType.Word32, PrimitiveType.Pointer32, PrimitiveType.Pointer32)
        {
        }

        public override RegisterStorage StackRegister
        {
            get { return Registers.esp; }
        }

        public override Address AddressFromSegOffset(X86State state, RegisterStorage seg, uint offset)
        {
            return new Address(offset);
        }

        public override Expression CreateStackAccess(Frame frame, int offset, DataType dataType)
        {
            var esp = frame.EnsureRegister(Registers.esp);
            return MemoryAccess.Create(esp, offset, dataType);
        }

        public override bool IsPointerRegister(RegisterStorage machineRegister)
        {
            return machineRegister.DataType.BitSize == PointerType.BitSize;
        }

        public override Address ReadCodeAddress(int byteSize, ImageReader rdr, ProcessorState state)
        {
            return new Address(rdr.ReadLeUInt32());
        }
    }

    internal class FlatMode64 : ProcessorMode
    {
        internal FlatMode64()
            : base(PrimitiveType.Word64, PrimitiveType.Pointer64, PrimitiveType.Pointer64)
        {
        }

        public override RegisterStorage StackRegister
        {
            get { return Registers.rsp; }
        }

        public override Address AddressFromSegOffset(X86State state, RegisterStorage seg, uint offset)
        {
            return new Address(offset);
        }

        public override Expression CreateStackAccess(Frame frame, int offset, DataType dataType)
        {
            var rsp = frame.EnsureRegister(Registers.rsp);
            return MemoryAccess.Create(rsp, offset, dataType);
        }

        public override bool IsPointerRegister(RegisterStorage machineRegister)
        {
            return machineRegister.DataType.BitSize == PointerType.BitSize;
        }

        public override Address ReadCodeAddress(int byteSize, ImageReader rdr, ProcessorState state)
        {
            throw new NotImplementedException("Address constants need to be 64-bit //return new Address(rdr.ReadLeUInt64());");
        }
    }
}