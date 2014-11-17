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
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Loading
{
    /// <summary>
    /// The NullLoader is used when the decompiler is unable to determine what image loader to use.
    /// It supports no disassembly.
    /// </summary>
    public class NullImageLoader : ImageLoader
    {
        private byte[] imageBytes;

        public NullImageLoader(IServiceProvider services, byte[] image) : base(services, image)
        {
            this.imageBytes = image;
        }

        public override LoaderResults Load(Address addrLoad)
        {
            var image = new LoadedImage(addrLoad, imageBytes);
            return new LoaderResults(
                image,
                new ImageMap(image),
                null,
                new DefaultPlatform(Services, null));
        }

        public override Address PreferredBaseAddress
        {
            get { return new Address(0); }
        }

        public override RelocationResults Relocate(Address addrLoad)
        {
            return new RelocationResults(new List<EntryPoint>(), new RelocationDictionary());
        }
    }
}
