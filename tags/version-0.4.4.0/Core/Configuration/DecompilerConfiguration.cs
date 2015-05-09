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

using Decompiler.Core.Assemblers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Decompiler.Core.Configuration
{
    /// <summary>
    /// Provides access to information stored in the app.config file.
    /// </summary>
    public interface IDecompilerConfigurationService
    {
         ICollection GetImageLoaders();
         ICollection GetArchitectures();
         ICollection GetEnvironments();
         ICollection GetSignatureFiles();
         ICollection GetAssemblers();

         OperatingEnvironment GetEnvironment(string envName);
         IProcessorArchitecture GetArchitecture(string archLabel);
         Assembler GetAssembler(string assemblerName);

         DefaultPreferences GetDefaultPreferences ();

         string GetPath(string path);
    }

    public class DecompilerConfiguration : IDecompilerConfigurationService
    {
        public virtual ICollection GetImageLoaders()
        {
            var handler = (LoaderSectionHandler) ConfigurationManager.GetSection("Decompiler/Loaders");
            if (handler == null)
                return new LoaderElement[0];
            return handler.ImageLoaders;
        }

        public virtual ICollection GetSignatureFiles()
        {
            var handler = (SignatureFileSectionHandler)ConfigurationManager.GetSection("Decompiler/SignatureFiles");
            if (handler == null)
                return new SignatureFileElement[0];
            return handler.SignatureFiles;
        }

        public virtual ICollection GetArchitectures()
        {
            var handler = (ArchitectureSectionHandler) ConfigurationManager.GetSection("Decompiler/Architectures");
            if (handler == null)
                return new ArchitectureElement[0];
            return handler.Architectures;
        }

        public virtual ICollection GetAssemblers()
        {
            var handler = (AssemblerSectionHandler)ConfigurationManager.GetSection("Decompiler/Assemblers");
            if (handler == null)
                return new AssemblerElement[0];
            return handler.Environments;
        }

        public IProcessorArchitecture GetArchitecture(string archLabel)
        {
            var elem = GetArchitectures().OfType<ArchitectureElement>()
                .Where(e => e.Name == archLabel).SingleOrDefault();
            if (elem == null)
                return null;

            Type t = Type.GetType(elem.TypeName, false);
            if (t == null)
                return null;
            return (IProcessorArchitecture)t.GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public virtual Assembler GetAssembler(string asmLabel)
        {
            var elem = GetAssemblers().OfType<AssemblerElement>()
                .Where(e => e.Name == asmLabel).SingleOrDefault();
            if (elem == null)
                return null;
            Type t = Type.GetType(elem.TypeName, true);
            return (Assembler)t.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
   
        public virtual ICollection GetEnvironments()
        {
            var handler = (OperatingEnvironmentSectionHandler) ConfigurationManager.GetSection("Decompiler/Environments");
            if (handler == null)
                return new OperatingEnvironmentElement[0];
            return handler.Environments;
        }

        public OperatingEnvironment GetEnvironment(string envName)
        {
            return GetEnvironments().OfType<OperatingEnvironment>().Where(e => e.Name == envName).Single();
        }

        public DefaultPreferences GetDefaultPreferences()
        {
            var handler = (UiPreferencesSectionHandler) ConfigurationManager.GetSection("Decompiler/UiPreferences");
            if (handler == null)
                handler = new UiPreferencesSectionHandler();
            return handler.GetPreferences();
        }

        public string GetPath(string filename)
        {
            if (!Path.IsPathRooted(filename))
            {
                return Path.Combine(
                    Path.GetDirectoryName(GetType().Assembly.Location),
                    filename);
            }
            return filename;
        }
    }
}
