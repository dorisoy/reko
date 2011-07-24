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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Arch.M68k
{
    public class M68kState : ProcessorState
    {
        #region ProcessorState Members

        public ProcessorState Clone()
        {
            return new M68kState();
        }

        public void SetRegister(MachineRegister r, Constant v)
        {
            throw new NotImplementedException();
        }

        public void SetInstructionPointer(Address addr)
        {
        }

        public Constant GetRegister(MachineRegister r)
        {
            throw new NotImplementedException();
        }

        public void OnProcedureEntered()
        {
        }

        public void OnProcedureLeft(ProcedureSignature sig)
        {
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
