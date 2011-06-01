﻿#region License
/* 
 * Copyright (C) 1999-2011 John Källén.
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

using Decompiler.Scanning;
using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.UnitTests.Scanning
{
    [TestFixture]
    public class ScannerEvaluatorTests
    {
        private MachineRegister sp;
        private FakeArchitecture arch;
        private FakeProcessorState state;
        private ScannerEvaluator sce;
        private Identifier idSp;
        private ExpressionEmitter m;

        [SetUp]
        public void Setup()
        {
            sp = new MachineRegister("sp", 42, PrimitiveType.Pointer32);
            arch = new FakeArchitecture();
            arch.StackRegister = sp;

            arch = new FakeArchitecture();
            state = new FakeProcessorState();
            sce = new ScannerEvaluator(arch, state);

            idSp = new Identifier(sp.Name, 1, sp.DataType, new RegisterStorage(sp));
            m = new ExpressionEmitter();
        }

        [Test]
        public void SetValue()
        {
            sce.SetValue(idSp, m.Sub(idSp, 4));

            Assert.AreEqual("sp - 0x00000004", sce.GetValue(idSp).ToString());
        }

        [Test]
        [Ignore()]
        public void PushLittleEndianValueOnstack()
        {
            sce.SetValue(idSp, m.Sub(idSp, 4));
            sce.SetValueEa(idSp, Constant.Word32(0x12345678));

            Assert.AreEqual("@@@", sce.GetValue(m.LoadDw(idSp)).ToString());
        }

        public class FakeArchitecture : IProcessorArchitecture
        {
            #region IProcessorArchitecture Members

            public Disassembler CreateDisassembler(ImageReader imageReader)
            {
                throw new NotImplementedException();
            }

            public Dumper CreateDumper()
            {
                throw new NotImplementedException();
            }

            public ProcessorState CreateProcessorState()
            {
                throw new NotImplementedException();
            }

            public CodeWalker CreateCodeWalker(ProgramImage img, Platform platform, Address addr, ProcessorState st)
            {
                throw new NotImplementedException();
            }

            public Decompiler.Core.Lib.BitSet CreateRegisterBitset()
            {
                throw new NotImplementedException();
            }

            public RewriterOld CreateRewriterOld(IProcedureRewriter prw, Procedure proc, IRewriterHost host)
            {
                throw new NotImplementedException();
            }

            public Rewriter CreateRewriter(ImageReader rdr, ProcessorState state, Frame frame, IRewriterHost2 host)
            {
                throw new NotImplementedException();
            }

            public Frame CreateFrame()
            {
                throw new NotImplementedException();
            }

            public MachineRegister GetRegister(int i)
            {
                throw new NotImplementedException();
            }

            public MachineRegister GetRegister(string name)
            {
                throw new NotImplementedException();
            }

            public bool TryGetRegister(string name, out MachineRegister reg)
            {
                throw new NotImplementedException();
            }

            public MachineFlags GetFlagGroup(uint grf)
            {
                throw new NotImplementedException();
            }

            public MachineFlags GetFlagGroup(string name)
            {
                throw new NotImplementedException();
            }

            public Expression CreateStackAccess(Frame frame, int cbOffset, Decompiler.Core.Types.DataType dataType)
            {
                throw new NotImplementedException();
            }

            public Address ReadCodeAddress(int size, ImageReader rdr, ProcessorState state)
            {
                throw new NotImplementedException();
            }

            public Decompiler.Core.Lib.BitSet ImplicitArgumentRegisters
            {
                get { throw new NotImplementedException(); }
            }

            public string GrfToString(uint grf)
            {
                throw new NotImplementedException();
            }

            public PrimitiveType FramePointerType
            {
                get { throw new NotImplementedException(); }
            }

            public PrimitiveType PointerType
            {
                get { throw new NotImplementedException(); }
            }

            public PrimitiveType WordWidth
            {
                get { throw new NotImplementedException(); }
            }

            public MachineRegister StackRegister { get; set; }

            public uint CarryFlagMask
            {
                get { throw new NotImplementedException(); }
            }

            #endregion
        }

        public class FakeProcessorState : ProcessorState
        {
            private Dictionary<MachineRegister, Constant> regs = new Dictionary<MachineRegister, Constant>();
            #region ProcessorState Members

            public ProcessorState Clone()
            {
                throw new NotImplementedException();
            }

            public Constant Get(MachineRegister r)
            {
                Constant c;
                if (!regs.TryGetValue(r, out c))
                    c = Constant.Invalid;
                return c;
            }

            public void Set(MachineRegister r, Constant v)
            {
                throw new NotImplementedException();
            }

            public void SetInstructionPointer(Address addr)
            {
                throw new NotImplementedException();
            }

            public void OnProcedureEntered()
            {
                throw new NotImplementedException();
            }

            public void OnProcedureLeft(ProcedureSignature procedureSignature)
            {
                throw new NotImplementedException();
            }

            public CallSite OnBeforeCall(int returnAddressSize)
            {
                throw new NotImplementedException();
            }

            public void OnAfterCall(ProcedureSignature sigCallee)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
