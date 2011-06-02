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

using BitSet = Decompiler.Core.Lib.BitSet;
using Block = Decompiler.Core.Block;
using Expression = Decompiler.Core.Expressions.Expression;
using IProcessorArchitecture = Decompiler.Core.IProcessorArchitecture;
using Storage = Decompiler.Core.Storage;
using StringWriter = System.IO.StringWriter;
using SymbolicEvaluationContext = Decompiler.Evaluation.SymbolicEvaluationContext;
using TextWriter = System.IO.TextWriter;
using System;
using System.Collections.Generic;

namespace Decompiler.Analysis
{
	/// <summary>
	/// Summary information about the dataflow of a basic block.
	/// </summary>
	public class BlockFlow : DataFlow
	{
		public Block Block;
		public BitSet DataOut;						    // each bit corresponds to a register that is live at the end of the
		public uint grfOut;							    // each bit corresponds to a condition code register that is live at the end of the block
		public Dictionary<Storage,int> StackVarsOut;    // stack-based storages that are live at the end of the block.
		public uint grfTrashedIn;					    // each bit corresnpots to a condition code register that is trashed on entrance.
        [Obsolete] public Dictionary<Storage, Storage> TrashedIn;  
        public SymbolicEvaluationContext SymbolicAuxIn;
        public Dictionary<Storage, Expression> SymbolicIn;        // maps identifiers to symbolic values on entrance to the block.
        public bool TerminatesProcess;                  // True if entering this block means the process/thread is terminated.

		public BlockFlow(Block block, BitSet dataOut, SymbolicEvaluationContext ctx)
		{
			this.Block = block;
			this.DataOut = dataOut;
			this.StackVarsOut = new Dictionary<Storage,int>();
			this.TrashedIn = new Dictionary<Storage, Storage>();
            this.SymbolicIn = new Dictionary<Storage, Expression>();
            this.SymbolicAuxIn = ctx;
		}

		public override void Emit(IProcessorArchitecture arch, TextWriter writer)
		{
			EmitRegisters(arch, "// DataOut:", DataOut, writer);
            writer.WriteLine();
			EmitFlagGroup(arch, "// DataOut (flags):", grfOut, writer);
            writer.WriteLine();

            EmitLocals("// LocalsOut:", writer);
            if (TerminatesProcess)
                writer.WriteLine("// Terminates process");
		}

        private void EmitLocals(string caption, TextWriter writer)
        {
            if (StackVarsOut.Count <= 0)
                return;

            writer.Write(caption);
            SortedList<string, string> list = new SortedList<string, string>();
            foreach (KeyValuePair<Storage, int> de in StackVarsOut)
            {
                Storage id = (Storage)de.Key;
                StringWriter sb = new StringWriter();
                id.Write(sb);
                string sName = sb.ToString();

                list[sName] = string.Format("{0}({1})", sName, de.Value);
            }
            foreach (string s in list.Values)
            {
                writer.Write(" ");
                writer.Write(s);
            }
            writer.WriteLine();

        }

    }
}
