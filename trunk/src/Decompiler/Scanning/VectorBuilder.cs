/* 
 * Copyright (C) 1999-2008 John K�ll�n.
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
using Decompiler.Core.Types;
using System;
using System.Collections;

namespace Decompiler.Scanning
{
	/// <summary>
	/// Builds a jump or call table by backtracking from the call site to find a comparison with a constant.
	/// This is (usually!) the upper bound of the size of the table.
	/// </summary>
	public class VectorBuilder : IBackWalkHost
	{
		private Program prog;
		private ImageMap imageMap;
		private int cbTable;
		private BackWalker bw;
		private DirectedGraph<object> jumpGraph;        //$TODO:

		public VectorBuilder(Program prog, ImageMap imageMap, DirectedGraph<object> jumpGraph)
		{
			this.prog = prog;
			this.imageMap = imageMap;
			this.jumpGraph = jumpGraph;
		}

		public Address [] Build(Address addrTable, Address addrFrom, ushort segBase, PrimitiveType stride)
		{
			bw = prog.Architecture.CreateBackWalker(prog.Image);
			if (bw == null) 
				return null;
			ArrayList operations = bw.BackWalk(addrFrom, this);
			if (operations == null)
				return PostError("Unable to determine limit", addrFrom, addrTable);
			int limit = 0;
			int [] permutation = null;
			foreach (BackwalkOperation op in operations)
			{
				BackwalkError err = op as BackwalkError;
				if (err != null)
					return PostError(err.ErrorMessage, addrFrom, addrTable);
				BackwalkDereference deref = op as BackwalkDereference;
				if (deref != null)
				{
					permutation = BuildMapping(deref, limit);
				}
				limit = op.Apply(limit);
			}
			if (limit == 0)
				return PostError("Unable to determine limit", addrFrom, addrTable);

			return BuildTable(addrTable, limit, permutation, stride, segBase);
		}

		private int [] BuildMapping(BackwalkDereference deref, int limit)
		{
			int [] map = new int[limit];
			ImageReader rdr = this.prog.Image.CreateReader(new Address((uint)deref.TableOffset));
			for (int i = 0; i < limit; ++i)
			{
				map[i] = rdr.ReadByte();
			}
			return map;
		}

		private Address [] BuildTable(Address addrTable, int limit, int [] permutation, PrimitiveType stride, ushort segBase)
		{
			Address [] vector;
			if (permutation != null)
			{
				int cbEntry = (int) stride.Size;
				int iMax = 0;
				vector = new Address[permutation.Length];
				for (int i = 0; i < permutation.Length; ++i)
				{
					if (permutation[i] > iMax)
						iMax = permutation[i];
					vector[i] = new Address(prog.Image.ReadLeUint32(addrTable + permutation[i]*cbEntry));
				}
			}
			else
			{
				ImageReader rdr = prog.Image.CreateReader(addrTable);
				int cItems = limit / (int) stride.Size;
				vector = new Address[cItems];
				for (int i = 0; i < vector.Length; ++i)
				{
					vector[i] = bw.MakeAddress(stride, rdr, segBase);
				}
				cbTable = limit;
			}
			return vector;

		}

		public AddressRange GetSinglePredecessorAddressRange(Address addr)
		{
#if GOG
			ImageMapBlock block = imageMap.FindItem(addr) as ImageMapBlock;
			if (block == null) return null;
			block = imageMap.FindItem(block.Address-1) as ImageMapBlock;
			if (block == null) return null;
			return new AddressRange(block.Address, block.Address + block.Size);
#else
			ImageMapBlock block = null;
			foreach (Address addrPred in this.jumpGraph.Predecessors(addr))
			{
				if (block != null)
					return null;
				block = imageMap.FindItem(addrPred) as ImageMapBlock;
			}
			if (block == null)
				return null;
			else
				return new AddressRange(block.Address, block.Address + block.Size);
#endif
		}

		public Address GetBlockStartAddress(Address addr)
		{
			ImageMapBlock block = imageMap.FindItem(addr) as ImageMapBlock;
			if (block == null) return null;
			return block.Address;
		}

		public MachineRegister IndexRegister
		{
			get { return bw != null ? bw.IndexRegister : null; }
		}

		private Address [] PostError(string err, Address addrInstr, Address addrTable)
		{
			System.Diagnostics.Trace.WriteLine(string.Format("Instruction at {0}, table at {1}: {2}", addrInstr, addrTable, err));
			return null;
		}

		public int TableByteSize
		{
			get { return cbTable; }
		}
	}
}
