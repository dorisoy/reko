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
using Decompiler.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Loading
{
    /// <summary>
    /// Loader that assembles assembler code from a file.
    /// </summary>
    public class AssemblerLoader : LoaderBase
    {
        private string asmfile;
        private Assembler asm;
        private DecompilerProject project;
        private Program prog;

        public AssemblerLoader(Assembler asm, string asmfile)
        {
            this.asm = asm;
            this.asmfile = asmfile;
        }

        public override DecompilerProject Project
        {
            get { return project; }
        }

        public override Program Program
        {
            get { return prog; }
        }

        public override void Load(Address addrLoad)
        {
            asm.Assemble(addrLoad, asmfile);
            prog = new Program();
            Program.Image = asm.Image;
            Program.Architecture = asm.Architecture;
            Program.Platform = asm.Platform;
            EntryPoints.AddRange(asm.EntryPoints);
            EntryPoints.Add(new EntryPoint(asm.StartAddress, Program.Architecture.CreateProcessorState()));
            CopyImportThunks(asm.ImportThunks, Program);
            project = new DecompilerProject();
            project.Input.BaseAddress = addrLoad;
        }

    }
}
