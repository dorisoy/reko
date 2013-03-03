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

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Decompiler.Core.Serialization
{
	[XmlRoot(ElementName="library", Namespace="http://schemata.jklnet.org/Decompiler")]
	public class SerializedLibrary
	{
		[XmlAttribute("case")]
		public string Case;

		[XmlElement("default")]
		public SerializedLibraryDefaults Defaults;

		[XmlElement("procedure", typeof (SerializedProcedure))]
		[XmlElement("service", typeof (SerializedService))]
		public List<SerializedProcedureBase> Procedures;

		public SerializedLibrary()
		{
			this.Procedures = new List<SerializedProcedureBase>();
		}

        public static SerializedLibrary LoadFromStream(Stream stm)
        {
            var ser = new XmlSerializer(typeof(SerializedLibrary));
            var rdr = new XmlTextReader(stm);
            return (SerializedLibrary)ser.Deserialize(rdr);
        }
	}
}
