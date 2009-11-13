﻿/* 
 * Copyright (C) 1999-2009 John Källén.
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
using Decompiler.Core.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.M68k
{
    public class M68kArchitecture : IProcessorArchitecture
    {
        #region IProcessorArchitecture Members

        public Disassembler CreateDisassembler(ImageReader rdr)
        {
            return new M68kDisassembler(rdr);
        }

        public Dumper CreateDumper()
        {
            return new Dumper();
        }

        public ProcessorState CreateProcessorState()
        {
            throw new NotImplementedException();
        }

        public BackWalker CreateBackWalker(ProgramImage img)
        {
            throw new NotImplementedException();
        }

        public CodeWalker CreateCodeWalker(ProgramImage img, Platform platform, Address addr, ProcessorState st, ICodeWalkerListener list)
        {
            throw new NotImplementedException();
        }

        public BitSet CreateRegisterBitset()
        {
            throw new NotImplementedException();
        }

        public Decompiler.Core.Rewriter CreateRewriter(IProcedureRewriter prw, Procedure proc, IRewriterHost host)
        {
            return new Rewriter(this, prw);
        }

        public Frame CreateFrame()
        {
            throw new NotImplementedException();
        }

        public MachineRegister GetRegister(int i)
        {
            return Registers.GetRegister(i);
        }

        public MachineRegister GetRegister(string name)
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

        public Decompiler.Core.Lib.BitSet ImplicitArgumentRegisters
        {
            get { throw new NotImplementedException(); }
        }

        public string GrfToString(uint grf)
        {
            throw new NotImplementedException();
        }

        public Decompiler.Core.Types.PrimitiveType FramePointerType
        {
            get { throw new NotImplementedException(); }
        }

        public Decompiler.Core.Types.PrimitiveType PointerType
        {
            get { throw new NotImplementedException(); }
        }

        public Decompiler.Core.Types.PrimitiveType WordWidth
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
