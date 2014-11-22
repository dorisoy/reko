#region License
/* 
 * Copyright (C) 1999-2014 John K�ll�n.
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
using Decompiler.Core.Machine;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Decompiler.Core
{
	/// <summary>
	/// Contains information about one input file, gathered during loading, scanning and data analysis,
	/// as well as storing any user-specified information.
	/// </summary>
    /// <remarks>
    /// A Decompiler project may consist of several of these Programs.
    /// </remarks>
    [Designer("Decompiler.Gui.Design.ProgramDesigner,Decompiler")]
    public class Program
	{
		private SortedList<Address,Procedure> procedures;
        private SortedList<Address, ImageMapVectorTable> vectors;
        private Dictionary<uint, PseudoProcedure> mpuintfn;
        private Dictionary<uint, PseudoProcedure> trampolines;
		private Identifier globals;
        private StructureType globalFields;
		private Dictionary<string, PseudoProcedure> pseudoProcs;
        private Dictionary<Identifier, LinearInductionVariable> ivs;
		private TypeFactory typefactory;

		public Program()
		{
            this.EntryPoints = new List<EntryPoint>();
			this.procedures = new SortedList<Address,Procedure>();
            this.vectors = new SortedList<Address, ImageMapVectorTable>();
			this.CallGraph = new CallGraph();
            this.mpuintfn = new Dictionary<uint, PseudoProcedure>();		// uint (offset) -> string
			this.trampolines = new Dictionary<uint, PseudoProcedure>();	// linear address -> string
            this.pseudoProcs = new Dictionary<string, PseudoProcedure>();
            this.ivs = new Dictionary<Identifier, LinearInductionVariable>();
			this.typefactory = new TypeFactory();
			this.TypeStore = new TypeStore();
		}

        public Program(LoadedImage image, ImageMap imageMap, IProcessorArchitecture arch, Platform platform) : this()
        {
            this.Image = image;
            this.ImageMap = imageMap;
            this.Architecture = arch;
            this.Platform = platform;
        }

        public string Name { get; set; }

        /// <summary>
        /// Project file that was used to load this program -- if any.
        /// </summary>
        public InputFile InputFile { get; set; }

        /// <summary>
        /// The processor architecture to use for decompilation
        /// </summary>
		public IProcessorArchitecture Architecture { get; set; }

        /// <summary>
        /// The callgraph expresses the relationships between the callers (statements and procedures)
        /// and their callees (procedures).
        /// </summary>
        public CallGraph CallGraph { get; private set; }

        public PseudoProcedure EnsurePseudoProcedure(string name, DataType returnType, int arity)
		{
            PseudoProcedure p;
            if (!pseudoProcs.TryGetValue(name, out p))
            {
                p = new PseudoProcedure(name, returnType, arity);
				pseudoProcs[name] = p;
			}
			return p;
		}

        public Identifier Globals
        {
            get
            {
                if (globals == null)
                {
                    EnsureGlobals();
                }
                return globals;
            }
        }

        private void EnsureGlobals()
        {
            if (Architecture == null)
                throw new InvalidOperationException("The program's Architecture property must be set before accessing the Globals property.");
            globalFields = TypeFactory.CreateStructureType(null, 0);
            var ptrGlobals = TypeFactory.CreatePointer(globalFields, Architecture.PointerType.Size);
            globals = new Identifier("globals", 0,  ptrGlobals, new MemoryStorage());
        }
		
        /// <summary>
        /// The unpacked, relocated, in-memory image of the program to be decompiled.
        /// </summary>
		public LoadedImage Image { get; set; }

        public ImageMap ImageMap { get; set; }

        /// <summary>
        /// The list of known entry points to the program.
        /// </summary>
        public List<EntryPoint> EntryPoints { get; private set; }

		public Dictionary<uint, PseudoProcedure> ImportThunks
		{
			get { return mpuintfn; }
		}

        public Dictionary<Identifier, LinearInductionVariable> InductionVariables
        {
            get { return ivs; }
        }

		public Platform Platform { get; set; }

		/// <summary>
		/// Provides access to the program's procedures, indexed by address.
		/// </summary>
		public SortedList<Address, Procedure> Procedures
		{
			get { return procedures; }
		}

		/// <summary>
		/// Provides access to the program's pseudo procedures, indexed by name.
		/// </summary>
		public Dictionary<string,PseudoProcedure> PseudoProcedures
		{
			get { return pseudoProcs; }
		}

        public Dictionary<uint, PseudoProcedure> Trampolines
		{
			get { return trampolines; }
		}

		public TypeFactory TypeFactory
		{
			get { return typefactory; }
		}
		
		public TypeStore TypeStore { get; private set; }

		/// <summary>
		/// Provides access to the program's jump and call tables, sorted by address.
		/// </summary>
		public SortedList<Address, ImageMapVectorTable> Vectors
		{
			get { return vectors; }
		}

        // Mutators /////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method is called when the user has created a global item.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public ImageMapItem AddUserGlobalItem(Address address, DataType dataType)
        {
            var size = GetDataSize(address, dataType);
            var item = new ImageMapItem
            {
                Address = address,
                Size = size,
                DataType = dataType,
            };
            if (size != 0)
                this.ImageMap.AddItemWithSize(address, item);
            else
                this.ImageMap.AddItem(address, item);
            this.InputFile.UserGlobalData.Add(address, new Serialization.GlobalDataItem_v2
            {
                Address = address.ToString(),
                DataType = dataType.Accept(new  Serialization.DataTypeSerializer()),
            });
            return item;
        }

        public uint GetDataSize(Address addr, DataType dt)
        {
            var strDt = dt as StringType;
            if (strDt == null)
                return (uint)dt.Size;
            if (strDt.LengthPrefixType == null)
            {
                // Zero-terminated string.
                var rdr = this.Architecture.CreateImageReader(this.Image, addr);
                while (rdr.IsValid)
                {
                    var ch = rdr.ReadChar(strDt.ElementType);
                    if (ch == 0)
                        break;
                }
                return (uint)(rdr.Address - addr);
            }
            throw new NotImplementedException();
        }

    } 

	public class VectorUse
	{
		public Address TableAddress;
		public RegisterStorage IndexRegister;

		public VectorUse(Address tblAddr, RegisterStorage idxReg)
		{
			TableAddress = tblAddr;
			IndexRegister = idxReg;
		}
	}
}
