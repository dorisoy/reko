﻿#region License
/* 
 * Copyright (C) 1999-2015 John Källén.
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

using Decompiler.Arch.Mos6502;
using Decompiler.Core;
using Decompiler.Core.Archives;
using Decompiler.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Decompiler.Environments.C64
{
    // http://petlibrary.tripod.com/D64.HTM
    // PRG files have 2 bytes load address and data.
    // https://hkn.eecs.berkeley.edu/~mcmartin/ophis/manual/x51.html
    // 
    public class D64Loader : ImageLoader
    {
#if NILZ
                        this.rsrcFork = new ResourceFork(image, arch);
 Track #Sect #SectorsIn D64 Offset   Track #Sect #SectorsIn D64 Offset
  ----- ----- ---------- ----------   ----- ----- ---------- ----------
    1     21       0       $00000      21     19     414       $19E00
    2     21      21       $01500      22     19     433       $1B100
    3     21      42       $02A00      23     19     452       $1C400
    4     21      63       $03F00      24     19     471       $1D700
    5     21      84       $05400      25     18     490       $1EA00
    6     21     105       $06900      26     18     508       $1FC00
    7     21     126       $07E00      27     18     526       $20E00
    8     21     147       $09300      28     18     544       $22000
    9     21     168       $0A800      29     18     562       $23200
   10     21     189       $0BD00      30     18     580       $24400
   11     21     210       $0D200      31     17     598       $25600
   12     21     231       $0E700      32     17     615       $26700
   13     21     252       $0FC00      33     17     632       $27800
   14     21     273       $11100      34     17     649       $28900
   15     21     294       $12600      35     17     666       $29A00
   16     21     315       $13B00      36*    17     683       $2AB00
   17     21     336       $15000      37*    17     700       $2BC00
   18     19     357       $16500      38*    17     717       $2CD00
   19     19     376       $17800      39*    17     734       $2DE00
   20     19     395       $18B00      40*    17     751       $2EF00
#endif
        private static int [] sectorCount = new int[] {
            -1,
            21, 21, 21, 21, 21,  21, 21, 21, 21, 21, 
            21, 21, 21, 21, 21,  21, 21, 19, 19, 19,
            19, 19, 19, 19, 18,  18, 18, 18, 18, 18, 
            17, 17, 17, 17, 17,  17, 17, 17, 17, 17, 
        };

        private static int [] sectorsIn = new int[] {
            -1,
            0  ,21 ,42 ,63 ,84 , 105,126,147,168,189,
            210,231,252,273,294, 315,336,357,376,395,
            414,433,452,471,490, 508,526,544,562,580,
            598,615,632,649,666, 683,700,717,734,751,
        };

        private static int [] trackOffset = new int[] {
            -1,
            0x00000,0x01500,0x02A00,0x03F00,0x05400,  0x06900,0x07E00,0x09300,0x0A800,0x0BD00,
            0x0D200,0x0E700,0x0FC00,0x11100,0x12600,  0x13B00,0x15000,0x16500,0x17800,0x18B00,
            0x19E00,0x1B100,0x1C400,0x1D700,0x1EA00,  0x1FC00,0x20E00,0x22000,0x23200,0x24400,
            0x25600,0x26700,0x27800,0x28900,0x29A00,  0x2AB00,0x2BC00,0x2CD00,0x2DE00,0x2EF00,
        };
        private LoaderResults lr;

        public D64Loader(IServiceProvider services, byte[] rawImage)
            : base(services, rawImage)
        {
        }


        public override Address PreferredBaseAddress
        {
            get { return Address.Ptr16(2048); }
        }

        public override LoaderResults Load(Address addrLoad)
        {
            var arch = new Mos6502ProcessorArchitecture();
            LoadedImage image;
            List<ArchiveDirectoryEntry> entries = LoadDirectory();
            IArchiveBrowserService abSvc = Services.GetService<IArchiveBrowserService>();
            if (abSvc != null)
            {
                var selectedFile = abSvc.UserSelectFileFromArchive(entries) as D64FileEntry;
                if (selectedFile != null)
                {
                    image = LoadImage(addrLoad, selectedFile);
                    this.lr = new LoaderResults(
                        image, 
                        image.CreateImageMap(),
                        arch, new C64Platform(Services, arch));
                    return lr;
                }
            }
            image = new LoadedImage(new Address(0), RawImage);
            return new LoaderResults(
                image,
                image.CreateImageMap(),
                arch,
                new DefaultPlatform(Services, arch));
        }

        private LoadedImage LoadImage(Address addrPreferred, D64FileEntry selectedFile)
        {
            byte[] imageBytes = selectedFile.GetBytes();
            switch (selectedFile.FileType & FileType.FileTypeMask)
            {
            case FileType.PRG:
                return LoadPrg(imageBytes);
            case FileType.SEQ:
                return new LoadedImage(addrPreferred, imageBytes);
            default:
                throw new NotImplementedException();
            }
        }

        private LoadedImage LoadPrg(byte[] imageBytes)
        {
            var stm = new MemoryStream();
            ushort preferredAddress = LoadedImage.ReadLeUInt16(imageBytes, 0);
            ushort alignedAddress = (ushort) (preferredAddress & ~0xF);
            int pad = preferredAddress - alignedAddress;
            while (pad-- > 0)
                stm.WriteByte(0);
            stm.Write(imageBytes, 2, imageBytes.Length - 2);
            var loadedBytes = stm.ToArray();
            return new LoadedImage(
                Address.Ptr16(alignedAddress),
                loadedBytes);
        }

        public override RelocationResults Relocate(Address addrLoad)
        {
            return new RelocationResults(
                new List<EntryPoint>(),
                new RelocationDictionary());
        }

        public List<ArchiveDirectoryEntry> LoadDirectory()
        {
            var entries = new List<ArchiveDirectoryEntry>();
            var rdr = new LeImageReader(RawImage, (uint)SectorOffset(18, 0));
            byte track = rdr.ReadByte();
            if (track == 0)
                return entries;
            byte sector = rdr.ReadByte();
            rdr.Offset = (uint) D64Loader.SectorOffset(track, sector);
            while (ReadDirectorySector(rdr, entries))
                ;
            return entries;
        }

        public bool ReadDirectorySector(LeImageReader rdr, List<ArchiveDirectoryEntry> entries)
        {
            byte nextDirTrack = 0;
            byte nextDirSector = 0;
            for (int i = 0; i < 8; ++i)
            {
                if (i == 0)
                {
                    nextDirTrack = rdr.ReadByte();
                    nextDirSector = rdr.ReadByte();
                }
                else
                {
                    rdr.Seek(2);
                }
                var fileType = (FileType) rdr.ReadByte();
                var fileTrack = rdr.ReadByte();
                var fileSector = rdr.ReadByte();
                var sName = Encoding.ASCII.GetString(rdr.ReadBytes(16))
                    .TrimEnd((char) 0xA0);
                var relTrack = rdr.ReadByte();
                var relSector = rdr.ReadByte();
                var rel = rdr.ReadByte();
                rdr.Seek(6);
                var sectorSize = rdr.ReadLeInt16();
                if ((fileType & FileType.FileTypeMask) != FileType.DEL)
                {
                    entries.Add(new D64FileEntry(
                        sName,
                        RawImage, 
                        SectorOffset(fileTrack, fileSector), 
                        fileType));
                }
            }
            if (nextDirTrack != 0)
            {
                rdr.Offset = (uint) SectorOffset(nextDirTrack, nextDirSector);
                return true;
            }
            else
            {
                return false;
            }
        }

        public class D64FileEntry : ArchivedFile
        {
            private byte[] image;
            private int offset;

            public D64FileEntry(string name, byte[] diskImage, int offset, FileType fileType)
            {
                this.Name = name;
                this.image = diskImage;
                this.offset = offset;
                this.FileType = fileType;   
            }

            public string Name { get; private set; }
            public FileType FileType { get; private set; }

            public byte[] GetBytes()
            {
                byte[] data;
                var stm = new MemoryStream();
                var rdr = new LeImageReader(image, (uint) offset);
                byte trackNext = rdr.ReadByte();
                while (trackNext != 0)
                {
                    byte sectorNext = rdr.ReadByte();
                    data = rdr.ReadBytes(0xFE);
                    stm.Write(data, 0, data.Length);

                    rdr.Offset = (uint) SectorOffset(trackNext, sectorNext);
                    trackNext = rdr.ReadByte();
                }
                byte lastUsed = rdr.ReadByte();
                data = rdr.ReadBytes(lastUsed - 2);
                stm.Write(data, 0, data.Length);
                return stm.ToArray();
            }
        }

        public static int SectorOffset(byte track, byte sector)
        {
            return trackOffset[track] + sector * 256;
        }
    }
}
