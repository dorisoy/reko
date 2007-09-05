/* 
 * Copyright (C) 1999-2007 John K�ll�n.
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

using Decompiler.Core.Code;
using Decompiler.Core.Types;
using System;

namespace Decompiler.Core.Serialization
{
	public class ArgumentSerializer
	{
		private SignatureSerializer sig;
		private IProcessorArchitecture arch;
		private Frame frame;
		private SerializedArgument argCur;
		private Identifier idArg;

		public ArgumentSerializer(SignatureSerializer sig, IProcessorArchitecture arch, Frame frame)
		{
			this.sig = sig;
			this.arch = arch;
			this.frame = frame;
		}

		public string ArgumentName(string argName, string argName2)
		{
			if (argName != null)
				return argName;
			else
				return argName2;
		}

		public void Deserialize(SerializedRegister reg)
		{
			idArg = frame.EnsureRegister(arch.GetRegister(reg.Name.Trim()));
			if (argCur.OutParameter)
			{
				idArg = frame.EnsureOutArgument(idArg);
			}
		}

		public void Deserialize(SerializedStackVariable ss)
		{
			PrimitiveType dt = PrimitiveType.Create(Domain.Integral, ss.ByteSize, Sign.Unknown);
			idArg = sig.CreateId(
				ArgumentName(argCur.Name, "arg" + sig.StackOffset), 
				dt,
				new StackArgumentStorage(sig.StackOffset, dt));
			sig.StackOffset += ss.ByteSize;
		}

		public void Deserialize(SerializedFpuStackVariable fs)
		{
			idArg = sig.CreateId(ArgumentName(argCur.Name, "fpArg" + sig.FpuStackOffset), PrimitiveType.Real64, new FpuStackStorage(sig.FpuStackOffset, PrimitiveType.Real64));
			++sig.FpuStackOffset;
		}

		public void Deserialize(SerializedFlag flag)
		{
			MachineFlags flags = arch.GetFlagGroup(flag.Name);
			idArg = frame.EnsureFlagGroup(flags.FlagGroupBits, flags.Name, flags.DataType);
		}
			
		public void Deserialize(SerializedSequence sq)
		{
			MachineRegister h = arch.GetRegister(sq.Registers[0].Name.Trim());
			MachineRegister t = arch.GetRegister(sq.Registers[1].Name.Trim());
			Identifier head = frame.EnsureRegister(h);
			Identifier tail = frame.EnsureRegister(t);
			idArg = frame.EnsureSequence(head, tail, 
				PrimitiveType.Create(Domain.Integral, head.DataType.Size + tail.DataType.Size, Sign.Unknown));
		}

		public Identifier Deserialize(SerializedArgument arg)
		{
			argCur = arg;
			arg.Kind.Accept(this);
			return idArg;
		}
	}
}
