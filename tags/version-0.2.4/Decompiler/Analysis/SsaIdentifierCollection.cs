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

using Decompiler.Core;
using Decompiler.Core.Expressions;
using System;
using System.Collections.Generic;

namespace Decompiler.Analysis
{
	public class SsaIdentifierCollection : List<SsaIdentifier>
	{
		public SsaIdentifier Add(Identifier idOld, Statement stmDef, Expression exprDef, bool isSideEffect)
		{
			int i = Count;
			Identifier idNew;
			if (stmDef != null)
			{
				idNew = idOld is MemoryIdentifier
					? new MemoryIdentifier(i, idOld.DataType)
					: new Identifier(FormatSsaName(idOld.Name, i), i, idOld.DataType, idOld.Storage);
			}
			else
			{
				idNew = idOld;
			}
			var sid = new SsaIdentifier(idNew, idOld, stmDef, exprDef, isSideEffect);
			Add(sid);
			return sid;
		}

		public SsaIdentifier this[Identifier id]
		{
			get { return base[id.Number]; }
			set { base[id.Number] = value; }
		}

		public string FormatSsaName(string prefix, int v)
		{
			return string.Format("{0}_{1}", prefix, v);
		}
	}
}
