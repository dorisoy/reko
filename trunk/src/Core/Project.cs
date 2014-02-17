﻿#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
using Decompiler.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Decompiler.Core
{
    public class Project
    {
        public Project()
        {
            UserGlobalData = new SortedList<Address, SerializedType>();
            InputFiles = new List<InputFile>();
        }

        public List<InputFile> InputFiles { get; private set; }

        /// <summary>
        /// Global data identified by the user.
        /// </summary>
        public SortedList<Address, SerializedType> UserGlobalData { get; private set; }

        public Project_v2 Save()
        {
            var inputs = this.InputFiles.Select(i => new DecompilerInput_v1
            {
                Address = i.BaseAddress.ToString(),
                Filename = i.Filename,
                UserProcedures = i.UserProcedures
                    .Select(de => { de.Value.Address = de.Key.ToString(); return de.Value; })
                    .ToList(),
                UserCalls = i.UserCalls
                    .Select(uc => uc.Value)
                    .ToList(),
                DisassemblyFilename = i.DisassemblyFilename,
                IntermediateFilename = i.IntermediateFilename,
                OutputFilename = i.OutputFilename,
                TypesFilename = i.TypesFilename,
            }).ToList();
            var sp = new Project_v2()
            {
                Inputs = inputs,
            };
            foreach (var de in UserGlobalData)
            {
            }
            return sp;
        }

        public void Load(SerializedProject_v1 sp)
        {
            var serializer = new ProjectSerializer();
            var project = serializer.LoadProject(sp);
        }
    }
}
