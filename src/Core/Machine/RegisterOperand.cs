#region License
/* 
 * Copyright (C) 1999-2022 John Källén.
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

using Reko.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reko.Core.Machine
{
    /// <summary>
    /// Represents a register operand of a <see cref="MachineInstruction"/>. Most
    /// modern architectures support this.
    /// </summary>
    public class RegisterOperand : AbstractMachineOperand
    {
        public RegisterOperand(RegisterStorage reg) :
            base(reg.DataType)
        {
            this.Register = reg;
        }

        public RegisterStorage Register { get; }

        protected override void DoRender(MachineInstructionRenderer renderer, MachineInstructionRendererOptions options)
        {
            renderer.WriteString(Register.Name);
        }
    }

    public class FlagGroupOperand : AbstractMachineOperand
    {
        public FlagGroupOperand(FlagGroupStorage grf) : base((PrimitiveType)grf.DataType)
        {
            this.FlagGroup = grf;
        }

        public FlagGroupStorage FlagGroup { get; }

        protected override void DoRender(MachineInstructionRenderer renderer, MachineInstructionRendererOptions options)
        {
            renderer.WriteString(FlagGroup.Name);
        }
    }

    public class SequenceOperand : AbstractMachineOperand
    {
        public SequenceOperand(SequenceStorage seq) : base((PrimitiveType) seq.DataType)
        {
            this.Sequence = seq;
        }

        public SequenceStorage Sequence { get; }

        protected override void DoRender(MachineInstructionRenderer renderer, MachineInstructionRendererOptions options)
        {
            renderer.WriteString(Sequence.Name);
        }
    }

}
