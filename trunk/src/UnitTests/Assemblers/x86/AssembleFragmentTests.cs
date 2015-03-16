#region License
/* 
 * Copyright (C) 1999-2015 John K�ll�n.
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

using Decompiler.Arch.X86;
using Decompiler.Assemblers.x86;
using Decompiler.Core;
using Decompiler.Core.Types;
using Decompiler.UnitTests.Arch.Intel;
using Decompiler.UnitTests.Arch.Intel.Fragments;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.UnitTests.Assemblers.x86
{
    [TestFixture]
    public class AssembleFragmentTests
    {
        private string nl = Environment.NewLine;

        [Test]
        public void Factorial()
        {
            RunTest(new Factorial(), 
                "0C00:0000	mov	cx,0100" + nl +
                "0C00:0003	push	cx" + nl +
                "0C00:0004	call	000F" + nl +
                "0C00:0007	add	sp,02" + nl +
                "0C00:000A	mov	[0100],ax" + nl +
                "0C00:000E	ret	" + nl +
                "0C00:000F	push	bp" + nl +
                "0C00:0010	mov	bp,sp" + nl +
                "0C00:0012	mov	ax,[bp+04]" + nl +
                "0C00:0015	dec	ax" + nl +
                "0C00:0016	jz	0026" + nl +
                "0C00:0018	push	ax" + nl +
                "0C00:0019	call	000F" + nl +
                "0C00:001C	inc	sp" + nl +
                "0C00:001D	inc	sp" + nl +
                "0C00:001E	mov	dx,[bp+04]" + nl +
                "0C00:0021	imul	dx" + nl +
                "0C00:0023	jmp	0029" + nl +
                "0C00:0026	mov	ax,0001" + nl +
                "0C00:0029	pop	bp" + nl +
                "0C00:002A	ret	" + nl);
        }


        private void RunTest(AssemblerFragment fragment, string sExp)
        {
            Address addrBase=  Address.SegPtr(0xC00, 0);
            IntelAssembler asm = new IntelAssembler(new IntelArchitecture(ProcessorMode.Real), addrBase, new List<EntryPoint>());
            fragment.Build(asm);
            Program lr = asm.GetImage();

            X86Disassembler dasm = new X86Disassembler(
                lr.Image.CreateLeReader(lr.Image.BaseAddress),
                PrimitiveType.Word16,
                PrimitiveType.Word16,
                false);
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (var instr in dasm)
                {
                    sb.AppendFormat("{0}\t{1}", instr.Address, instr);
                    sb.AppendLine();
                }
                Assert.AreEqual(sExp, sb.ToString());
            }
            catch
            {
                Console.WriteLine(sb.ToString());
                throw;
            }
        }
    }
}
