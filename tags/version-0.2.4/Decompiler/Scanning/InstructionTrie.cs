#region License
/* 
 * Copyright (C) 1999-2013 John K�ll�n.
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

using System;
using IComparer = System.Collections.IComparer;
#if MONO
using IHashCodeProvider = System.Collections.IHashCodeProvider;
#else
using IEqualityComparer = System.Collections.IEqualityComparer;
#endif
using Hashtable = System.Collections.Hashtable;

namespace Decompiler.Scanning
{
	/// <summary>
	/// An InstructionTrie tallies instruction frequencies and instruction sequence lengths.
	/// </summary>
	public class InstructionTrie
	{
		private int count;
		private TrieNode root;


#if MONO
		public InstructionTrie(IHashCodeProvider hasher, IComparer comparer)
#else
		public InstructionTrie(IEqualityComparer hasher, IComparer comparer)
#endif
		{
			this.root = new TrieNode(hasher, comparer);
		}

		public int Count
		{
			get { return count; }
		}

		public void AddInstructions(object [] instrs)
		{
			TrieNode node = root;
			foreach (object instr in instrs)
			{
				node = node.Add(instr);
				++node.Tally;
				++count;
			}
		}

		public long ScoreInstructions(object [] instrs)
		{
			TrieNode node = root;
			long score = 0;
			foreach (object instr in instrs)
			{
				TrieNode subNode = node.Next(instr);
				if (subNode == null)
					break;
				score = score * node.Successors.Count + subNode.Tally;
				node = subNode;
			}
			return score;
		}

		private class TrieNode
		{
			public object Instruction;
			public Hashtable Successors;
#if MONO
			public IHashCodeProvider hasher;
#else
			public IEqualityComparer hasher;
#endif
			public IComparer cmp;
			public int Tally;

#if MONO
			public TrieNode(IHashCodeProvider hasher, IComparer cmp)
#else
			public TrieNode(IEqualityComparer hasher, IComparer cmp)
#endif
			{
				Init(hasher, cmp);
			}

#if MONO
			public TrieNode(object instruction, IHashCodeProvider hasher, IComparer cmp)
#else
			public TrieNode(object instruction, IEqualityComparer hasher, IComparer cmp)
#endif
			{
				Instruction = instruction;
				Init(hasher, cmp);
			}

			public TrieNode Add(object instr)
			{
				TrieNode subNode = Next(instr);
				if (subNode == null)
				{
					subNode = new TrieNode(instr, hasher, cmp);
					Successors.Add(instr, subNode);
				}
				return subNode;
			}

#if MONO
			private void Init(IHashCodeProvider hasher, IComparer cmp)
#else
			private void Init(IEqualityComparer hasher, IComparer cmp)
#endif
			{
				this.hasher = hasher;
				this.cmp = cmp;
#if MONO
				Successors = new Hashtable(hasher, cmp);
#else
				Successors = new Hashtable(hasher);
#endif
			}

			public TrieNode Next(object instr)
			{
				return (TrieNode) Successors[instr];
			}
		}
	}
}
