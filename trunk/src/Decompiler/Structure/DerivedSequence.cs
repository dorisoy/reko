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
using Decompiler.Core.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Decompiler.Structure
{
	public class DerivedSequence
	{
		public StructureNode G;			// graph entry
		public StructureNode [] nodes;	// storage for graph nodes.
		public List<Interval> I;				// Intervals.

		public DerivedSequence()
		{
			I = new List<Interval>();
		}

		public StructureNode NewNode(int i, Block entry, BitSet blocks)
		{
			StructureNode n = new StructureNode(i, entry);
			return n;
		}

#if DEBUG
		public void DumpIntervals()
		{
			StringWriter sw = new StringWriter();
			Write(sw);
			Debug.Write(sw.ToString());
		}

		public void DumpNodes()
		{
			StringWriter sw = new StringWriter();
			WriteNodes(sw);
			Debug.Write(sw.ToString());
		}

		public void DumpGraphIf(bool enabled)
		{
			if (enabled)
			{
				foreach (StructureNode n in nodes)
				{
					Debug.Write(n.Ident + ": [ ");
					foreach (StructureNode s in n.Succ)
					{
						Debug.Write(s.Ident + " ");
					}
					Debug.WriteLine("]");
				}
			}
		}



#else
		public void DumpIntervals() {}
		public void DumpNodes() {}
		private void DumpGraphIf(bool enabled, DerivedSequence ds) {}		
#endif

		public void Write(TextWriter tw)
		{
			foreach (Interval i in I)
			{
				i.Write(tw);
			}
			tw.WriteLine();
		}

		public void WriteNodes(TextWriter tw)
		{
			for (int i = 0; i < this.nodes.Length; ++i)
			{
				nodes[i].Write(tw);
			}
		}
	}
}
