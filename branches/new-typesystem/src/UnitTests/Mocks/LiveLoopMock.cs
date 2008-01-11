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

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Types;
using System;

namespace Decompiler.UnitTests.Mocks
{
	public class LiveLoopMock : ProcedureMock
	{
		protected override void BuildBody()
		{
			Identifier i = Local32("i");
			Identifier y = Local32("y");

			Label("loop");
			Assign(y, i);
			Add(i, i, Int32(1));
			BranchIf(Ne(new MemoryAccess(i, PrimitiveType.Byte), Int8(0)), "loop");

			Return(y);
		}
	}
}
