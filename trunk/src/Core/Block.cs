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

using Decompiler.Core.Output;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Decompiler.Core
{
	/// <summary>
	/// Represents a basic block of statements.
	/// </summary>
	public class Block
	{
        [Obsolete]
		public int RpoNumber;			// Reverse post order number.

		private List<Block> pred = new List<Block>();
        private List<Block> succ = new List<Block>(2);
		private StatementList stms;

		public Block(Procedure proc, string name)
		{
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Blocks must have a valid name.", "name"); 
			this.Procedure = proc;
			this.Name = name;
			this.stms = new StatementList(this);
		}

        public string Name { get; private set; }
        public Procedure Procedure { get; set; }

		public static void Coalesce(Block block, Block next)
		{
			foreach (Statement stm in next.Statements)
			{
				block.Statements.Add(stm);
			}

			block.succ = new List<Block>(next.succ);
			ReplaceJumpsFrom(next, block);
			next.Pred.Clear();
			next.Statements.Clear();
			next.Succ.Clear();
		}


		public static bool ReplaceJumpsFrom(Block block, Block next)
		{
			bool change = false;
			foreach (Block s in block.Succ)
			{
				for (int i = 0; i < s.Pred.Count; ++i)
				{
					if (s.Pred[i] == block)
					{
						s.Pred[i] = next;
						change = true;
					}
				}
			}
			return change;
		}

		/// <summary>
		/// Replaces all jumps to <paramref name="block"/> with jumps to <paramref name="next"/>.
		/// </summary>
		/// <param name="block"></param>
		/// <param name="next"></param>
		/// <returns>Whether a replacement was actually made or not.</returns>
		public static bool ReplaceJumpsTo(Block block, Block next)
		{
			bool change = false;
			foreach (Block p in block.Pred)
			{
				for (int i = 0; i < p.Succ.Count; ++i)
				{
					if (p.Succ[i] == block)
					{
						p.Succ[i] = next;
						change = true;
					}
				}
				if (!next.Pred.Contains(p))
				{
					next.Pred.Add(p);
					change = true;
				}
			}
			next.Pred.Remove(block);
			block.Pred.Clear();
			return change;
		}

		public Block ElseBlock
		{
			get { return succ[0]; }
			set { succ[0] = value; }
		}

		public List<Block> Pred
		{
			get { return pred; }
		}

        //public Procedure Procedure
        //{
        //    get { return proc; }
        //}

		public List<Block> Succ
		{
			get { return succ; }
		}

		public StatementList Statements
		{
			get { return stms; }
		}

		public Block ThenBlock
		{
			get { return succ[1]; }
			set { succ[1] = value; }
		}

        public override string ToString()
        {
            return Name;
        }

		public void Write(TextWriter sb)
		{
			if (pred.Count == 0 && succ.Count == 0)
			{
				sb.WriteLine("{0}:", Name);
				WriteStatements(sb);
			}
			else
			{
				sb.Write("{0}:\t\t// pred:", Name);
				foreach (Block p in Pred)
				{
					sb.Write(" {0}", p.Name);
				}
				sb.WriteLine();
				WriteStatements(sb);
				sb.Write("\t// succ: ");
				foreach (Block s in Succ)
				{
					sb.Write(" {0}", s.Name);
				}
				sb.WriteLine();
			}
		}

		public void WriteStatements(TextWriter writer)
		{
            Formatter f = new Formatter(writer);
            f.UseTabs = true;
            f.TabSize = 4;
            CodeFormatter cf = new CodeFormatter(f);
			int i = 0;
			foreach (Statement s in Statements)
			{
				s.Instruction.Accept(cf);
				++i;
			}
		}
	}
}
