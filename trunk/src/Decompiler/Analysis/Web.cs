#region License
/* 
 * Copyright (C) 1999-2010 John K�ll�n.
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
using Decompiler.Core.Expressions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Decompiler.Analysis
{
	public class Web
	{
        private Identifier id;
		private List<SsaIdentifier> members;
		private List<Statement> defs;
        private List<Statement> uses;
		private LinearInductionVariable iv;

		public Web()
		{
			members = new List<SsaIdentifier>();
			defs = new List<Statement>();
			uses = new List<Statement>();
		}

        public void Add(SsaIdentifier sid)
		{
            if (members.Contains(sid))		// should be a set!
                return;

			members.Add(sid);
			if (this.id == null)
			{
				this.id = sid.Identifier;
			}
			else
			{
				if (sid.Identifier.Number < this.Identifier.Number)
				{
					this.id = sid.Identifier;
				}

				if (iv == null)
				{
					iv = sid.InductionVariable;
				}
				else if (sid.InductionVariable == null)
				{
					sid.InductionVariable = iv;
				}
				else 
				{
					iv = LinearInductionVariable.Merge(sid.InductionVariable, iv);
					if (iv == null)
					{
						// Warning(string.Format("{0} and {1} are conflicting induction variables: {2} {3}", 
					}
					sid.InductionVariable = iv;
				}
			}
			defs.Add(sid.DefStatement);
			foreach (Statement u in sid.Uses)
				uses.Add(u);
		}

        public List<Statement> Definitions
        {
            get { return defs; }
        }

        public Identifier Identifier
        {
            get { return id; }
        }
        
		public LinearInductionVariable InductionVariable
		{
			get { return iv; }
		}

		public List<SsaIdentifier> Members
		{
			get { return members; }
		}

        public List<Statement> Uses
        {
            get { return uses; }
        }

		public void Write(TextWriter writer)
		{
			writer.Write("{0}: {{ ", Identifier.Name);
			foreach (SsaIdentifier m in members)
			{
				writer.Write("{0} ", m.Identifier.Name);
			}
			writer.WriteLine("}");
		}
	}
}
