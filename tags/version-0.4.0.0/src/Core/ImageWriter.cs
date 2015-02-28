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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decompiler.Core
{
    /// <summary>
    /// This class is used to write bytes to arrays of bytes. It knows all about endian conventions.
    /// </summary>
    public abstract class ImageWriter
    {
        public ImageWriter() : this(new byte[16])
        {
        }

        public ImageWriter(byte[] image)
        {
            this.Bytes = image;
            this.Position = 0;
        }

        public ImageWriter(byte[] image, uint offset)
        {
            this.Bytes = image;
            this.Position = (int) offset;
        }

        public byte[] Bytes { get; private set;}
        public int Position { get; set; }

        public ImageWriter WriteByte(byte b)
        {
            if (Position >= Bytes.Length)
            {
                var bytes = Bytes;
                Array.Resize<byte>(ref bytes, (Bytes.Length + 1) * 2);
                Bytes = bytes;
            }
            Bytes[Position++] = b;
            return this;
        }

        public ImageWriter WriteBytes(byte b, uint count)
        {
            while (count > 0)
            {
                WriteByte(b);
                --count;
            }
            return this;
        }

        public ImageWriter WriteBytes(byte[] bytes)
        {
            foreach (byte b in bytes)
                WriteByte(b);
            return this;
        }

        public ImageWriter WriteString(string str, Encoding enc)
        {
            WriteBytes(enc.GetBytes(str));
            return this;
        }

        public ImageWriter WriteLeInt16(short us)
        {
            return WriteLeUInt16((ushort) us);
        }

        public ImageWriter WriteLeUInt16(ushort us)
        {
            WriteByte((byte) us);
            WriteByte((byte) (us >> 8));
            return this;
        }

        public ImageWriter WriteBeUInt16(ushort us)
        {
            WriteByte((byte)(us >> 8));
            WriteByte((byte)us);
            return this;
        }

        public ImageWriter WriteBeUInt32(uint offset, uint ui)
        {
            LoadedImage.WriteBeUInt32(Bytes, offset, ui);
            return this;
        }

        public ImageWriter WriteBeUInt32(uint ui)
        {
            WriteByte((byte) (ui >> 24));
            WriteByte((byte) (ui >> 16));
            WriteByte((byte) (ui >> 8));
            WriteByte((byte) ui);
            return this;
        }

        public ImageWriter WriteLeUInt32(uint offset, uint ui)
        {
            Bytes[offset] = (byte)ui;
            Bytes[offset+1] = (byte)(ui >> 8);
            Bytes[offset+2] = (byte)(ui >> 16);
            Bytes[offset+3] = (byte)(ui >> 24);
            return this;
        }

        public abstract ImageWriter WriteUInt32(uint offset, uint w);

        public ImageWriter WriteLeUInt32(uint ui)
        {
            WriteLeUInt32((uint) Position, ui);
            Position += 4;
            return this;
        }

        public ImageWriter WriteLeInt32(int i)
        {
            return WriteLeUInt32((uint)i);
        }
    }

    public class BeImageWriter : ImageWriter
    {
        public BeImageWriter()
            : base()
        {
        }

        public BeImageWriter(byte [] image) : base(image)
        {
        }

        public BeImageWriter(byte[] image, uint offset)
            : base(image, offset)
        {
        }

        public override ImageWriter WriteUInt32(uint offset, uint w) { return WriteBeUInt32(offset, w); }
    }

    public class LeImageWriter : ImageWriter
    {
        public LeImageWriter()
            : base()
        {
        }

        public LeImageWriter(byte [] image) :base(image)
        {
        }

        public LeImageWriter(byte[] image, uint offset)
            : base(image, offset)
        {
        }

        public override ImageWriter WriteUInt32(uint offset, uint w) { return WriteLeUInt32(offset, w); }
    }
}
