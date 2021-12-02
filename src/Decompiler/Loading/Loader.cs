#region License
/* 
 * Copyright (C) 1999-2021 John Källén.
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

using Reko.Core;
using Reko.Core.Assemblers;
using Reko.Core.Configuration;
using Reko.Core.Loading;
using Reko.Core.Memory;
using Reko.Core.Scripts;
using Reko.Core.Serialization;
using Reko.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reko.Loading
{
    /// <summary>
    /// Class that provides services for loading the "code", in whatever format it is in,
    /// into a Reko <see cref="Project" />.
    /// </summary>
    public class Loader : ILoader
    {
        private readonly IConfigurationService cfgSvc;
        private readonly UnpackingService unpackerSvc;

        public Loader(IServiceProvider services)
        {
            this.Services = services;
            this.cfgSvc = services.RequireService<IConfigurationService>();
            this.unpackerSvc = new UnpackingService(services);
            this.unpackerSvc.LoadSignatureFiles();
            Services.RequireService<IServiceContainer>().AddService(typeof(IUnpackerService), unpackerSvc);
        }

        public string? DefaultToFormat { get; set; }

        public IServiceProvider Services { get; private set; }

        public Program AssembleExecutable(ImageLocation asmFileLocation, IAssembler asm, IPlatform platform, Address addrLoad)
        {
            var bytes = LoadImageBytes(asmFileLocation);
            return AssembleExecutable(asmFileLocation, bytes, asm, platform, addrLoad);
        }

        public Program AssembleExecutable(ImageLocation asmFileLocation, byte[] image, IAssembler asm, IPlatform platform, Address addrLoad)
        {
            var program = asm.Assemble(addrLoad, new StreamReader(new MemoryStream(image), Encoding.UTF8));
            program.Name = asmFileLocation.GetFilename();
            program.Location = asmFileLocation;
            program.Platform = platform;
            foreach (var sym in asm.ImageSymbols)
            {
                program.ImageSymbols[sym.Address!] = sym;
            }
            foreach (var ep in asm.EntryPoints)
            {
                program.EntryPoints[ep.Address!] = ep;
            }
            program.EntryPoints[asm.StartAddress] =
                ImageSymbol.Procedure(program.Architecture, asm.StartAddress);
            CopyImportReferences(asm.ImportReferences, program);
            program.User.OutputFilePolicy = Program.SegmentFilePolicy;
            return program;
        }

        /// <summary>
        /// Loads (or assembles) a Reko decompiler project. If a binary file is
        /// specified instead, we create a simple project for the file.
        /// </summary>
        /// <param name="imageLocation">The location of the image to load.</param>
        /// <param name="loaderName">Optional .NET class name of a custom
        /// image loader</param>
        /// <param name="addrLoad">Optional address at which to load the image.
        /// </param>
        /// <returns>
        /// An <see cref="ILoadedImage"/> instance. In particular, if the
        /// file format wasn't recognized an instance of <see cref="Blob"/> is
        /// returned.
        /// </returns>
        public ILoadedImage Load(ImageLocation imageLocation, string? loaderName = null, Address? addrLoad = null)
        {
            byte[] image = LoadImageBytes(imageLocation);
            var projectLoader = new ProjectLoader(this.Services, this, Services.RequireService<DecompilerEventListener>());
            projectLoader.ProgramLoaded += (s, e) => { RunScriptOnProgramImage(e.Program, e.Program.User.OnLoadedScript); };
            var project = projectLoader.LoadProject(imageLocation, image);
            if (project is not null)
            {
                project.FireScriptEvent(ScriptEvent.OnProgramLoaded);
                return project;
            }

            var binaryImage = LoadBinaryImage(imageLocation, image, loaderName, addrLoad);
            foreach (var fragment in imageLocation.Fragments)
            {
                if (binaryImage is not IArchive archive)
                    throw new InvalidOperationException($"Image '{imageLocation}' expects an archive or file container, but none was loaded.");
                var item = archive[fragment];
                if (item is not ArchivedFile file)
                    throw new InvalidOperationException($"Fragment '{fragment}' does not refer to an archived file.");
                binaryImage = file.LoadImage(Services, addrLoad);
            }
            return binaryImage;
        }

        /// <summary>
        /// Loads a binary image into memory, if it has a recognized file format.
        /// </summary>
        /// <param name="imageLocation">The location of the loaded image.</param>
        /// <param name="image">The raw bytes fetched from <paramref name="imageLocation"/>.</param>
        /// <param name="loader">.NET Class name of a custom loader (may be null)</param>
        /// <param name="addrLoad">Address into which to load the file.</param>
        /// <returns>A <see cref="ILoadedImage"/> if the file format is recognized, or 
        /// an instance of <see cref="Blob"/> if the file cannot be recognized.</returns>
        public ILoadedImage LoadBinaryImage(ImageLocation imageLocation, byte[] image, string? loader, Address? addrLoad)
        {
            ImageLoader? imgLoader;
            if (!string.IsNullOrEmpty(loader))
            {
                imgLoader = CreateCustomImageLoader(Services, loader, imageLocation, image);
            }
            else
            {
                imgLoader = FindImageLoader<ImageLoader>(imageLocation, image);
                if (imgLoader is null)
                {
                    imgLoader = CreateDefaultImageLoader(imageLocation, image);
                }
            }

            if (imgLoader is null)
                return new Blob(image);

            if (addrLoad is null && imgLoader is ProgramImageLoader ploader)
            {
                addrLoad = ploader.PreferredBaseAddress;     //$REVIEW: Should be a configuration property.
            }

            var loadedImage = imgLoader.Load(addrLoad);
            if (loadedImage is Program program)
            {
                return PostProcessProgram(imageLocation, addrLoad!, imgLoader, program);
            }
            return loadedImage;
        }

        private Program PostProcessProgram(ImageLocation imageLocation, Address addrLoad, ImageLoader imgLoader, Program program)
        {
            // Sanity check of the 'Needs' properties.
            if (program.NeedsScanning && !program.NeedsSsaTransform)
                throw new InvalidOperationException(
                    "A programming error has been detected. " +
                    $"Image loader {imgLoader.GetType().FullName} has set the program.NeedsScanning " +
                    "and program.NeedsSsaTransform to inconsistent values.");

            program.Name = imageLocation.GetFilename();
            program.Location = imageLocation;
            if (program.NeedsScanning)
            {
                if (imgLoader is ProgramImageLoader piLoader)
                {
                    var relocations = piLoader.Relocate(program, addrLoad);
                    foreach (var sym in relocations.Symbols.Values)
                    {
                        program.ImageSymbols[sym.Address!] = sym;
                    }
                    foreach (var ep in relocations.EntryPoints)
                    {
                        program.EntryPoints[ep.Address!] = ep;
                    }
                }
                if (program.Architecture != null)
                {
                    program.Architecture.PostprocessProgram(program);
                }
                program.ImageMap = program.SegmentMap.CreateImageMap();
            }
            program.User.OutputFilePolicy = Program.SegmentFilePolicy;
            return program;
        }

        /// <summary>
        /// Loads a program from a file into memory using the additional information in 
        /// <paramref name="raw"/>. Use this to open files with insufficient or
        /// no metadata.
        /// </summary>
        /// <param name="fileName">Name of the file to be loaded.</param>
        /// <param name="raw">Extra metadata supllied by the user.</param>
        public Program LoadRawImage(ImageLocation location, LoadDetails raw)
        {
            raw.ArchitectureOptions ??= new Dictionary<string, object>();
            byte[] image = this.LoadImageBytes(location);
            var program = this.LoadRawImage(location, image, null, raw);
            return program;
        }

        /// <summary>
        /// Loads a program into memory using the additional information in 
        /// <paramref name="raw"/>. Use this to decompile raw blobs of data.
        /// </summary>
        /// <param name="fileName">Name of the file to be loaded.</param>
        /// <param name="raw">Extra metadata supllied by the user.</param>
        public Program LoadRawImage(byte[] image, LoadDetails raw)
        {
            raw.ArchitectureOptions ??= new Dictionary<string, object>();
            var inventedLocation = ImageLocation.FromUri("file:image");
            var program = this.LoadRawImage(inventedLocation, image, null, raw);
            return program;
        }

        /// <summary>
        /// Loads a <see cref="Program"/> from a flat image where all the metadata has been 
        /// supplied by the user in <paramref name="details"/>.
        /// </summary>
        /// <param name="imageLocation">The location of the loaded image</param>
        /// <param name="image"></param>
        /// <param name="addrLoad"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public Program LoadRawImage(ImageLocation imageLocation, byte[] image, Address? addrLoad, LoadDetails details)
        {
            if (details.ArchitectureName is null)
                throw new ApplicationException($"No processor architecture was specified.");
            var arch = cfgSvc.GetArchitecture(details.ArchitectureName);
            if (arch is null)
                throw new ApplicationException($"Unknown processor architecture '{details.ArchitectureName}");
            arch.LoadUserOptions(details.ArchitectureOptions);
            IPlatform platform;
            if (details.PlatformName is null)
                platform = new DefaultPlatform(Services, arch);
            else 
                platform = cfgSvc.GetEnvironment(details.PlatformName).Load(Services, arch);
            if (addrLoad is null)
            {
                if (!arch.TryParseAddress(details.LoadAddress, out addrLoad))
                {
                    throw new ApplicationException(
                        "Unable to determine base address for executable. A default address should have been present in the reko.config file.");
                }
            }
            if (addrLoad.DataType.BitSize == 16 && image.Length > 65535)
            {
                //$HACK: this works around issues when a large ROM image is read
                // for a 8- or 16-bit processor. Once we have a story for overlays
                // this can go away.
                var newImage = new byte[65535];
                Array.Copy(image, newImage, newImage.Length);
                image = newImage;
            }

            var imgLoader = CreateCustomImageLoader(Services, details.LoaderName, imageLocation, image);
            var program = imgLoader.LoadProgram(addrLoad, arch, platform);
            if (details.EntryPoint is not null && arch.TryParseAddress(details.EntryPoint.Address, out Address addrEp))
            {
                program.EntryPoints.Add(addrEp, ImageSymbol.Procedure(arch, addrEp));
            }
            program.Name = imageLocation.GetFilename();
            program.Location = imageLocation;
            program.User.Processor = arch.Name;
            program.User.Environment = platform.Name;
            program.User.Loader = details.LoaderName;
            program.User.LoadAddress = addrLoad;
            program.User.OutputFilePolicy = Program.SegmentFilePolicy;

            program.Architecture.PostprocessProgram(program);
            program.ImageMap = program.SegmentMap.CreateImageMap();

            return program;
        }

        public ImageLoader? CreateDefaultImageLoader(ImageLocation imageLocation, byte[] image)
        {
            var rawFile = DefaultToFormat is null
                ? null 
                : cfgSvc.GetRawFile(DefaultToFormat);
            if (rawFile is null)
            {
                this.Services.RequireService<DecompilerEventListener>().Warn(
                    new NullCodeLocation(imageLocation.FilesystemPath),
                    "The format of the file is unknown.");
                return null;
            }
            return CreateRawImageLoader(imageLocation, image, rawFile);
        }

        private ImageLoader? CreateRawImageLoader(ImageLocation imageLocation, byte[] image, RawFileDefinition rawFile)
        {
            if (rawFile.Architecture == null)
                return null;
            var arch = cfgSvc.GetArchitecture(rawFile.Architecture);
            if (arch is null)
                return null;

            PlatformDefinition? env = null;
            if (rawFile.Environment != null)
            {
                env = cfgSvc.GetEnvironment(rawFile.Environment);
            }
            IPlatform platform;
            if (env != null)
            {
                platform = env.Load(Services, arch);
            }
            else
            {
                platform = new DefaultPlatform(Services, arch);
            }

            Address? entryAddr = null;
            if (arch.TryParseAddress(rawFile.BaseAddress, out Address baseAddr))
            {
                entryAddr = GetRawBinaryEntryAddress(rawFile, image, arch, baseAddr);
            }
            var imgLoader = new NullImageLoader(Services, imageLocation, image)
            {
                Architecture = arch,
                Platform = platform,
                PreferredBaseAddress = entryAddr!,
            };
            Address addrEp;
            if (rawFile.EntryPoint != null)
            {
                if (!string.IsNullOrEmpty(rawFile.EntryPoint.Address))
                {
                    arch.TryParseAddress(rawFile.EntryPoint.Address, out addrEp);
                }
                else
                {
                    addrEp = baseAddr;
                }
                imgLoader.EntryPoints.Add(ImageSymbol.Procedure(arch, addrEp));
            }
            return imgLoader;
        }

        public static Address? GetRawBinaryEntryAddress(
            RawFileDefinition rawFile,
            byte[] image, 
            IProcessorArchitecture arch, 
            Address baseAddr)
        {
            if (!string.IsNullOrEmpty(rawFile.EntryPoint.Address))
            {
                if (arch.TryParseAddress(rawFile.EntryPoint.Address, out Address entryAddr))
                {
                    if (rawFile.EntryPoint.Follow)
                    {
                        var rdr = arch.CreateImageReader(new ByteMemoryArea(baseAddr, image), entryAddr);
                        var addr = arch.ReadCodeAddress(0, rdr, arch.CreateProcessorState());
                        return addr;
                    }
                    else
                    {
                        return entryAddr;
                    }
                }
                else
                {
                    return baseAddr;
                }
            }
            return baseAddr;
        }

        /// <summary>
        /// Loads a metadata file into a type library.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A <see cref="TypeLibrary" /> instance, or null if the format of the file
        /// wasn't recognized.</returns>
        public TypeLibrary? LoadMetadata(ImageLocation metadataLocation, IPlatform platform, TypeLibrary typeLib)
        {
            var rawBytes = LoadImageBytes(metadataLocation);
            var mdLoader = FindImageLoader<MetadataLoader>(metadataLocation, rawBytes);
            if (mdLoader is null)
                return null;
            var result = mdLoader.Load(platform, typeLib);
            return result;
        }

        public ScriptFile? LoadScript(ImageLocation scriptLocation)
        {
            var rawBytes = LoadImageBytes(scriptLocation);
            return FindImageLoader<ScriptFile>(scriptLocation, rawBytes);
        }

        /// <summary>
        /// Loads the contents of a file with the specified filename into an array 
        /// of bytes, optionally at the offset <paramref>offset</paramref>. No interpretation
        /// of those bytes is done.
        /// </summary>
        /// <param name="imageLocation">Location of the image whose bytes are to be loaded.</param>
        /// <returns>An array of bytes with the file contents.</returns>
        public virtual byte[] LoadImageBytes(ImageLocation imageLocation)
        {
            // The initial fragment is always a file system location.
            var fsSvc = Services.RequireService<IFileSystemService>();
            return fsSvc.ReadAllBytes(imageLocation.FilesystemPath);
        }

        /// <summary>
        /// Locates an image loader from the Decompiler configuration file, based on the magic
        /// number in the begining of the program image.
        /// </summary>
        /// <param name="imageLocation">The location from which the <paramref name="rawBytes"/> were 
        /// loaded.</param>
        /// <param name="rawBytes">Bytes used to find a suitable <see cref="ImageLoader"/>.</param>
        /// <returns>An appropriate image loader if one can be found, otherwise null.
        public T? FindImageLoader<T>(ImageLocation imageLocation, byte[] rawBytes)
            where T : class
        {
            foreach (LoaderDefinition e in cfgSvc.GetImageLoaders())
            {
                if (e.TypeName is null)
                    continue;
                if (!string.IsNullOrEmpty(e.MagicNumber) &&
                    ImageHasMagicNumber(rawBytes, e.MagicNumber!, e.Offset)
                    ||
                    (!string.IsNullOrEmpty(e.Extension) &&
                        imageLocation.EndsWith(e.Extension, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return CreateImageLoader<T>(Services, e.TypeName, imageLocation, rawBytes);
                }
            }
            return default;
        }

        public bool ImageHasMagicNumber(byte[] image, string magicNumber, long offset)
        {
            byte[] magic = BytePattern.FromHexBytes(magicNumber);
            if (image.Length < offset + magic.Length)
                return false;

            for (long i = 0, j = offset; i < magic.Length; ++i, ++j)
            {
                if (magic[i] != image[j])
                    return false;
            }
            return true;
        }

        public static uint HexDigit(char digit)
        {
            switch (digit)
            {
            case '0': case '1': case '2': case '3': case '4': 
            case '5': case '6': case '7': case '8': case '9':
                return (uint) (digit - '0');
            case 'A': case 'B': case 'C': case 'D': case 'E': case 'F':
                return (uint) ((digit - 'A') + 10);
            case 'a': case 'b': case 'c': case 'd': case 'e': case 'f':
                return (uint) ((digit - 'a') + 10);
            default:
                throw new ArgumentException(string.Format("Invalid hexadecimal digit '{0}'.", digit));
            }
        }

        /// <summary>
        /// Create an <see cref="ImageLoader"/> using the provided parameters.
        /// </summary>
        public static T CreateImageLoader<T>(
            IServiceProvider services,
            string typeName,
            ImageLocation imageLocation,
            byte[] bytes)
        {
            var svc = services.RequireService<IPluginLoaderService>();
            var t = svc.GetType(typeName);
            if (t == null)
                throw new ApplicationException(string.Format("Unable to find loader {0}.", typeName));
            return (T) Activator.CreateInstance(t, services, imageLocation, bytes);
        }

        /// <summary>
        /// Creates an <see cref="ImageLoader"/> that wraps an existing ImageLoader.
        /// </summary>
        public static T CreateOuterImageLoader<T>(IServiceProvider services, string typeName, ImageLoader innerLoader)
        {
            var svc = services.RequireService<IPluginLoaderService>();
            var type = svc.GetType(typeName);
            if (type == null)
                throw new ApplicationException(string.Format("Unable to find loader {0}.", typeName));
            return (T) Activator.CreateInstance(type, innerLoader);
        }

        /// <summary>
        /// Expects the provided assembly to contain exactly one type that implements
        /// ImageLoader, then loads that.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="typeName"></param>
        /// <param name="filename"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ProgramImageLoader CreateCustomImageLoader(IServiceProvider services, string? loader, ImageLocation imageLocation, byte[] bytes)
        {
            if (string.IsNullOrEmpty(loader))
            {
                return new NullImageLoader(services, imageLocation, bytes);
            }

            var cfgSvc = services.RequireService<IConfigurationService>();
            var ldrCfg = cfgSvc.GetImageLoader(loader!);
            if (ldrCfg != null && ldrCfg.TypeName != null)
            {
                return CreateImageLoader<ProgramImageLoader>(services, ldrCfg.TypeName, imageLocation, bytes);
            }

            //$TODO: detect file extensions and load appropriate interpreter.
            var ass = Assembly.LoadFrom(loader);
            var t = ass.GetTypes().SingleOrDefault(tt => typeof(ImageLoader).IsAssignableFrom(tt));
            if (t is null)
                throw new ApplicationException(string.Format("Unable to find image loader in {0}.", loader));
            return (ProgramImageLoader) Activator.CreateInstance(t, services, imageLocation, bytes);
        }

        protected void CopyImportReferences(Dictionary<Address, ImportReference> importReference, Program program)
        {
            if (importReference == null)
                return;

            foreach (var item in importReference)
            {
                program.ImportReferences.Add(item.Key, item.Value);
            }
        }

        protected void CopyInterceptedCalls(Dictionary<Address, ExternalProcedure> interceptedCalls, Program program)
        {
            foreach (var item in interceptedCalls)
            {
                program.InterceptedCalls.Add(item.Key, item.Value);
            }
        }

        public void RunScriptOnProgramImage(Program program, Script_v2? script)
        {
            if (script == null || !script.Enabled || script.Script == null)
                return;
            var eventListener = Services.RequireService<DecompilerEventListener>();
            IScriptInterpreter interpreter;
            try
            {
                //$TODO: should be in the config file, yeah.
                var svc = Services.RequireService<IPluginLoaderService>();
                var type = svc.GetType("Reko.ImageLoaders.OdbgScript.OllyLang,Reko.ImageLoaders.OdbgScript");
                interpreter = (IScriptInterpreter) Activator.CreateInstance(type, Services);
            }
            catch (Exception ex)
            {
                eventListener.Error(ex, "Unable to load OllyLang script interpreter.");
                return;
            }

            try
            {
                interpreter.LoadFromString(script.Script, program, Environment.CurrentDirectory);
                interpreter.Run();
            }
            catch (Exception ex)
            {
                eventListener.Error(ex, "An error occurred while running the script.");
            }
        }

    }
}
 