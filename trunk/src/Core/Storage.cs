#region License
/* 
 * Copyright (C) 1999-2011 John K�ll�n.
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

using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using Decompiler.Core.Serialization;
using System;
using System.IO;

namespace Decompiler.Core
{
	/// <summary>
	/// Encapsulates architecture-dependent storage mechanism for an identifier.
	/// </summary>
	public abstract class Storage
	{
		public Storage(string storageKind)
		{
			this.Kind = storageKind;
		}


		public string Kind { get; private set; }
		public abstract int OffsetOf(Storage storage);

        public abstract T Accept<T>(StorageVisitor<T> visitor);

		public virtual SerializedKind Serialize()
		{
			throw new NotImplementedException(this.GetType().Name + ".Serialize not implemented.");
		}

		public override string ToString()
		{
			StringWriter w = new StringWriter();
			Write(w);
			return w.ToString();
		}

		public abstract void Write(TextWriter writer);

        [Obsolete("Moved to ApplicationBuilder")]
        public Expression BindFormalArgumentToFrame(IProcessorArchitecture iProcessorArchitecture, Frame frame, CallSite callSite)
        {
            throw new NotImplementedException();
        }
    }


	public class FlagGroupStorage : Storage
	{
		public FlagGroupStorage(uint grfMask, string name) : base("FlagGroup")
		{
			this.FlagGroup = grfMask;
			this.Name = name;
		}

        public uint FlagGroup { get; private set; }
        public string Name { get; private set; }

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitFlagGroupStorage(this);
		}

		public override bool Equals(object obj)
		{
			FlagGroupStorage fgs = obj as FlagGroupStorage;
			if (fgs == null)
				return false;
			return FlagGroup == fgs.FlagGroup;
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ FlagGroup.GetHashCode();
		}

		public override int OffsetOf(Storage stgSub)
		{
			FlagGroupStorage f = stgSub as FlagGroupStorage;
			if (f == null)
				return -1;
			return ((f.FlagGroup & FlagGroup) != 0) ? 0 : -1;
		}

		public override SerializedKind Serialize()
		{
			return new SerializedFlag(Name);
		}

		public override void Write(TextWriter writer)
		{
			writer.Write("Flags");
		}
	}

	public class FpuStackStorage : Storage
	{

		public FpuStackStorage(int depth, DataType dataType) : base("FpuStack")
		{
			this.FpuStackOffset = depth;
			this.DataType = dataType;
		}

        public DataType DataType { get; private set; }
        public int FpuStackOffset { get; private set; }

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitFpuStackStorage(this);
		}


		public override bool Equals(object obj)
		{
			FpuStackStorage fss = obj as FpuStackStorage;
			if (fss == null)
				return false;
			return FpuStackOffset == fss.FpuStackOffset;
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ FpuStackOffset.GetHashCode();
		}

		public override int OffsetOf(Storage stgSub)
		{
			return -1;
		}

		public override void Write(TextWriter writer)
		{
			writer.Write("FPU stack");
		}
	}

	/// <summary>
	/// Storage is some unspecified part of global memory.
	/// </summary>
	public class MemoryStorage : Storage
	{
		public MemoryStorage() : base("Global")
		{
		}

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitMemoryStorage(this);
		}

		public override int OffsetOf(Storage stgSub)
		{
			return -1;
		}

		public override void Write(TextWriter writer)
		{
			writer.Write("Global memory");
		}
	}

	/// <summary>
	/// Storage for registers or other identifiers that are live-out of a procedure.
	/// </summary>
	public class OutArgumentStorage : Storage
	{

		public OutArgumentStorage(Identifier originalId) : base("out")
		{
			this.OriginalIdentifier = originalId;
		}

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitOutArgumentStorage(this);
		}


		public override bool Equals(object obj)
		{
			OutArgumentStorage oas = obj as OutArgumentStorage;
			if (oas == null)
				return false;
			return oas.OriginalIdentifier.Equals(OriginalIdentifier);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ OriginalIdentifier.GetHashCode();
		}

		public override int OffsetOf(Storage stgSub)
		{
			return -1;
		}

		public Identifier OriginalIdentifier { get; private set; }

        public override SerializedKind Serialize()
        {
            return OriginalIdentifier.Storage.Serialize();
        }

		public override void Write(TextWriter writer)
		{
			writer.Write("Out:");
			OriginalIdentifier.Storage.Write(writer);
		}
	}

	public class RegisterStorage : Storage
	{
		public RegisterStorage(MachineRegister reg) : base("Register")
		{
			this.Register = reg;
		}

        public MachineRegister Register { get; private set; }


		public override T Accept<T>(StorageVisitor<T> visitor)
		{
			return visitor.VisitRegisterStorage(this);
		}

		public override bool Equals(object obj)
		{
			var rs = obj as RegisterStorage;
			if (rs == null)
				return false;
			return Register.Number == rs.Register.Number;
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ Register.Number;
		}

		public override int OffsetOf(Storage stgSub)
		{
			var regSub = stgSub as RegisterStorage;
			if (regSub == null)
				return -1;
			if (regSub.Register == Register)
				return 0;
			return regSub.Register.IsSubRegisterOf(Register)
				? regSub.Register.AliasOffset
				: -1;
		}


		public override SerializedKind Serialize()
		{
			return new SerializedRegister(Register.Name);
		}


		public override void Write(TextWriter writer)
		{
			writer.Write("Register ");
			writer.Write(Register.Name);
		}
	}

	public class SequenceStorage : Storage
	{
		//$REFACTOR: make this params Identifier [], to support arbitrarily long identifiers
		public SequenceStorage(Identifier head, Identifier tail) 
			: base("Sequence")		
		{
			this.Head = head;
			this.Tail = tail;
		}

        public Identifier Head { get; private set; }
        public Identifier Tail { get; private set; }

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitSequenceStorage(this);
		}


		public override bool Equals(object obj)
		{
			SequenceStorage ss = obj as SequenceStorage;
			if (ss == null)
				return false;
			return Head.Equals(ss.Head) && Tail.Equals(ss.Tail);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ Head.GetHashCode() ^ (3 * Tail.GetHashCode());
		}


		public override int OffsetOf(Storage stgSub)
		{
			int off = Tail.Storage.OffsetOf(stgSub);
			if (off != -1)
				return off;
			off = Head.Storage.OffsetOf(stgSub);
			if (off != -1)
				return off + Tail.DataType.BitSize;
			return -1;
		}

		public override SerializedKind Serialize()
		{
			return new SerializedSequence(this);
		}

		public override void Write(TextWriter writer)
		{
			writer.Write("Sequence {0}:{1}", Head.Name, Tail.Name);
		}
	}

	public class StackArgumentStorage : Storage
	{
		public StackArgumentStorage(int cbOffset, DataType dataType) : base("Stack")
		{
			this.StackOffset = cbOffset;
			this.DataType = dataType;
		}

        /// <summary>
        /// Offset from stack pointer as it was when the procedure was entered.
        /// </summary>
        /// <remarks>
        /// If the architecture stores the return address on the stack, the return address will be at offset 0 and
        /// any stack arguments will have offsets > 0. If the architecture passes the return address in a
        /// register or a separate return stack, there may be stack arguments with offset 0. Depending on which
        /// direction the stack grows, there may be negative stack offsets for parameters, although most popular
        /// general purpose processors (x86, PPC, m68K) grown their stacks down toward lower memory addresses.
        /// </remarks>
        public int StackOffset { get; private set; }
        public DataType DataType { get; private set; }

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitStackArgumentStorage(this);
		}


		public override bool Equals(object obj)
		{
			StackArgumentStorage sas = obj as StackArgumentStorage;
			if (sas == null)
				return false;
			return StackOffset == sas.StackOffset;
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ StackOffset;
		}

		public override int OffsetOf(Storage stgSub)
		{
			StackArgumentStorage arg = stgSub as StackArgumentStorage;
			if (arg == null)
				return -1;
            if (arg.StackOffset >= StackOffset && arg.StackOffset + arg.DataType.Size <= StackOffset + DataType.Size)
                return (arg.StackOffset - StackOffset) * DataType.BitsPerByte;
			return -1;
		}

        public override SerializedKind Serialize()
        {
            SerializedStackVariable svar = new SerializedStackVariable();
            svar.ByteSize = DataType.Size;
            return svar;
        }

		public override void Write(TextWriter writer)
		{
            writer.Write("{0} +{1:X4}", Kind, StackOffset);
		}
	}

    public class StackLocalStorage : Storage
    {
        public StackLocalStorage(int cbOffset, DataType dataType)
            : base("Local")
        {
            this.StackOffset = cbOffset;
            this.DataType = dataType;
        }

        public DataType DataType { get; private set; }
        public int StackOffset { get; private set; }

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
            return visitor.VisitStackLocalStorage(this);
        }

        public override bool Equals(object obj)
        {
            StackLocalStorage sas = obj as StackLocalStorage;
            if (sas == null)
                return false;
            return StackOffset == sas.StackOffset;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ StackOffset;
        }


        public override int OffsetOf(Storage stgSub)
        {
            StackLocalStorage local = stgSub as StackLocalStorage;
            if (local == null)
                return -1;
            if (local.StackOffset >= StackOffset && local.StackOffset + local.DataType.Size <= StackOffset + DataType.Size)
                return (local.StackOffset - StackOffset) * DataType.BitsPerByte;
            return -1;
        }


        public override void Write(TextWriter writer)
        {
            writer.Write("{0} -{1:X4}", base.Kind, Math.Abs(StackOffset));
        }
    }

	public class TemporaryStorage : Storage
	{
		public TemporaryStorage() : base("Temporary")
		{
		}

        public override T Accept<T>(StorageVisitor<T> visitor)
        {
			return visitor.VisitTemporaryStorage(this);
		}

		public override int OffsetOf(Storage stgSub)
		{
			return -1;
		}

		public override void Write(TextWriter writer)
		{
			writer.Write("Temporary");
		}
	}
}

