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

using Decompiler.Core.Expressions;
using Decompiler.Core.Types;
using System;
using System.Diagnostics;
using System.IO;

namespace Decompiler.Core
{
	/// <summary>
	/// Contains the bytes that are present in memory when a program is loaded.
	/// </summary>
	public class ProgramImage
	{
		private byte [] abImage;
		private ImageMap map;

		public ProgramImage(Address addrBase, byte [] ab)
		{
			this.BaseAddress = addrBase;
			this.abImage = ab;
			this.map = new ImageMap(addrBase, ab.Length);
			this.Relocations = new RelocationDictionary();
		}

        public Address BaseAddress { get; set; }        // Address of start of image.
        public byte[] Bytes { get { return abImage; } }
        public ImageMap Map { get { return map; } }
        public RelocationDictionary Relocations { get; private set; }


        public static bool CompareArrays(byte[] src, int iSrc, byte[] dst, int cb)
        {
            if (iSrc + cb > src.Length)
                return false;
            int iDst = 0;
            while (cb != 0)
            {
                if (src[iSrc++] != dst[iDst++])
                    return false;
                --cb;
            }
            return true;
        }

		public ImageReader CreateReader(Address addr)
		{
			return new ImageReader(this, addr);
		}

		public ImageReader CreateReader(int offset)
		{
			return new ImageReader(this, (uint) offset);
		}

		public ImageReader CreateReader(uint offset)
		{
			return new ImageReader(this, offset);
		}

		/// <summary>
		/// Adds the delta to the ushort at the given offset.
		/// </summary>
		/// <param name="imageOffset"></param>
		/// <param name="delta"></param>
		/// <returns>The new value of the ushort</returns>
		public ushort FixupLeUInt16(uint imageOffset, ushort delta)
		{
			ushort seg = ReadLeUInt16(abImage, imageOffset);
			seg = (ushort) (seg + delta);
			WriteLeUInt16(imageOffset, seg);
			return seg;
		}

		private static double IntPow(double b, int e)
		{
			double acc = 1.0;

			while (e != 0)
			{
				if ((e & 1) == 1)
				{
					acc *= b;
					--e;
				}
				else
				{
					b *= b;
					e >>= 1;
				}
			}
			return acc;
		}


		public bool IsValidAddress(Address addr)
		{
			if (addr == null)
				return false;
            return IsValidLinearAddress(addr.Linear);
        }

        public bool IsValidLinearAddress(uint linearAddr)
        {
            if (linearAddr < BaseAddress.Linear)
                return false;
            uint offset = (linearAddr - BaseAddress.Linear);
			return offset < abImage.Length;
        }

	
		/// <summary>
		/// Reads a little-endian word from image offset.
		/// </summary>
		/// <remarks>
		/// If the word being read was a relocation, it is returned with a [[pointer]]
		/// or [[segment]] data type. Otherwise a neutral [[word]] is returned.
		/// </remarks>
		/// <param name="imageOffset">Offset from image start, in bytes.</param>
		/// <param name="type">Size of the word being requested.</param>
		/// <returns>Typed constant from the image.</returns>
		public Constant ReadLe(uint imageOffset, PrimitiveType type)
		{
			Constant c = Relocations[imageOffset];
			if (c != null && c.DataType.Size == type.Size)
				return c;
			switch (type.Size)
			{
			case 1: return new Constant(type, abImage[imageOffset]);
			case 2: return new Constant(type, ReadLeUInt16(abImage, imageOffset));
			case 4: return new Constant(type, ReadLeUInt32(abImage, imageOffset));
			}
			throw new NotImplementedException(string.Format("Primitive type {0} not supported.", type));
		}

        public Constant ReadBe(uint imageOffset, PrimitiveType type)
        {
            Constant c = Relocations[imageOffset];
            if (c != null && c.DataType.Size == type.Size)
                return c;
            switch (type.Size)
            {
            case 1: return new Constant(type, abImage[imageOffset]);
            case 2: return new Constant(type, ReadBeUInt16(abImage, imageOffset));
            case 4: return new Constant(type, ReadBeUInt32(abImage, imageOffset));
            }
            throw new NotImplementedException(string.Format("Primitive type {0} not supported.", type));
        }



        public static long ReadBeInt64(byte[] image, uint off)
        {
            return ((long)image[off] << 56) |
                   ((long)image[off + 1] << 48) |
                   ((long)image[off + 2] << 40) |
                   ((long)image[off + 3] << 32) |
                   ((long)image[off + 4] << 24) |
                   ((long)image[off + 5] << 16) |
                   ((long)image[off + 6] << 8) |
                   ((long)image[off + 7]);
        }

        public static long ReadLeInt64(byte[] image, uint off)
        {
            return 
                (long) image[off] |
                ((long)image[off+1] << 8) |
                ((long)image[off+2] << 16) | 
                ((long)image[off+3] << 24) |
                ((long)image[off+4] << 32) |
                ((long)image[off+5] << 40) |
                ((long)image[off+6] << 48) |
                ((long)image[off+7] << 56);
        }


        public static int ReadBeInt32(byte[] abImage, uint off)
        {
            int u =
                ((int)abImage[off] << 24) |
                ((int)abImage[off + 1] << 16) |
                ((int)abImage[off + 2] << 8) |
                abImage[off + 3];
            return u;
        }

        public static int ReadLeInt32(byte[] abImage, uint off)
        {
            int u = abImage[off] |
                ((int)abImage[off + 1] << 8) |
                ((int)abImage[off + 2] << 16) |
                ((int)abImage[off + 3] << 24);
            return u;
        }


        public static short ReadBeInt16(byte[] img, uint offset)
        {
            return (short)(img[offset] << 8 | img[offset + 1]);
        }

        public static short ReadLeInt16(byte[] abImage, uint offset)
        {
            return (short)(abImage[offset] + ((short)abImage[offset + 1] << 8));
        }

        public static Constant ReadLeDouble(byte[] abImage, uint off)
        {
            return Constant.DoubleFromBitpattern(ReadLeInt64(abImage, off));
        }

        public static Constant ReadLeFloat(byte[] abImage, uint off)
        {
            return Constant.FloatFromBitpattern(ReadLeInt32(abImage, off));
        }

        public static ulong ReadBeUInt64(byte[] abImage, uint off)
        {
            return (ulong)ReadBeInt64(abImage, off);
        }

        public static ulong ReadLeUInt64(byte[] img, uint off)
        {
            return (ulong)ReadLeInt64(img, off);
        }

        public static uint ReadBeUInt32(byte[] abImage, uint off)
        {
            return (uint)ReadBeInt32(abImage, off);
        }

        public static uint ReadLeUInt32(byte[] img, uint off)
        {
            return (uint)ReadLeInt32(img, off);
        }

        public static ushort ReadBeUInt16(byte[] abImage, uint off)
        {
            return (ushort) ReadBeInt16(abImage, off);
        }

        public static ushort ReadLeUInt16(byte[] img, uint off)
        {
            return (ushort)ReadLeInt16(img, off);
        }

        public Constant ReadLeDouble(uint off) { return ReadLeDouble(abImage, off); }
        public Constant ReadLeFloat(uint off) { return ReadLeFloat(abImage, off); }
		public long ReadLeInt64(uint off) {  return ReadLeInt64(this.abImage, off); }
		public ulong ReadLeUint64(uint off) { return ReadLeUInt64(this.abImage, off); }
        public int ReadLeInt32(uint off) { return ReadLeInt32(this.abImage, off); }
        public uint ReadLeUInt32(uint off) { return ReadLeUInt32(this.abImage, off); }
        public short ReadLeInt16(uint off) { return ReadLeInt16(this.abImage, off); }
        public ushort ReadLeUInt16(uint off) { return ReadLeUInt16(this.abImage, off); }


        public Constant ReadLeDouble(Address addr) { return ReadLeDouble(abImage, ToOffset(addr)); }
        public Constant ReadLeFloat(Address addr) { return ReadLeFloat(abImage, ToOffset(addr)); }
        public long ReadLeInt64(Address addr) { return ReadLeInt64(this.abImage, ToOffset(addr)); }
        public ulong ReadLeUint64(Address addr) { return ReadLeUInt64(this.abImage, ToOffset(addr)); }
        public int ReadLeInt32(Address addr) { return ReadLeInt32(this.abImage, ToOffset(addr)); }
        public uint ReadLeUInt32(Address addr) { return ReadLeUInt32(this.abImage, ToOffset(addr)); }
        public short ReadLeInt16(Address addr) { return ReadLeInt16(this.abImage, ToOffset(addr)); }
        public ushort ReadLeUInt16(Address addr) { return ReadLeUInt16(this.abImage, ToOffset(addr)); }

        private uint ToOffset(Address addr)
        {
            return addr.Linear - this.BaseAddress.Linear;
        }

        public void WriteLeUInt16(uint offset, ushort w)
		{
			abImage[offset] = (byte) (w & 0xFF);
			abImage[offset+1] = (byte) (w >> 8);
		}

        public void WriteBeUint32(uint offset, uint dw)
        {
            abImage[offset + 0] = (byte) (dw >> 24);
            abImage[offset + 1] = (byte) (dw >> 16);
            abImage[offset + 2] = (byte) (dw >> 8);
            abImage[offset + 3] = (byte) (dw & 0xFF);
        }

        public void WriteLeUint32(uint offset, uint dw)
        {
            abImage[offset] = (byte) (dw & 0xFF);
            abImage[offset + 1] = (byte) (dw >> 8);
            abImage[offset + 2] = (byte) (dw >> 16);
            abImage[offset + 3] = (byte) (dw >> 24);
        }
    }
}
