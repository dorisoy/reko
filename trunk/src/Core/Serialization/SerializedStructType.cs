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

using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Decompiler.Core.Serialization
{
	public class SerializedStructType : SerializedTaggedType
	{
		[XmlAttribute("size")]
        [DefaultValue(0)]
		public int ByteSize;

		public SerializedStructType()
		{
		}

		[XmlElement("field", typeof (SerializedStructField))]
		public SerializedStructField[]  Fields;

        public override T Accept<T>(ISerializedTypeVisitor<T> visitor)
        {
            return visitor.VisitStructure(this);
        }

		public override DataType BuildDataType(TypeFactory factory)
		{
			StructureType str = factory.CreateStructureType(null, 0);
			foreach (SerializedStructField f in Fields)
			{
				str.Fields.Add(new StructureField(f.Offset, f.Type.BuildDataType(factory), f.Name));
			}
			return str;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
            sb.Append("struct(");
            if (!string.IsNullOrEmpty(Name))
                sb.AppendFormat("{0}, ", Name);
            if (ByteSize > 0)
                sb.AppendFormat("{0}, ", ByteSize);
			foreach (SerializedStructField f in Fields)
			{
				sb.AppendFormat("({0}, {1}, {2})", f.Offset, f.Name != null?f.Name: "?", f.Type);
			}
			sb.Append(")");
			return sb.ToString();
		}
	}

	public class SerializedStructField
	{
		[XmlAttribute("offset")]
		public int Offset;

		[XmlAttribute("name")]
		public string Name;

		[XmlElement("prim", typeof (SerializedPrimitiveType))]
		[XmlElement("ptr", typeof (SerializedPointerType))]
		public SerializedType Type;

		public SerializedStructField()
		{
		}

		public SerializedStructField(int offset, string name, SerializedType type)
		{
			this.Offset = offset;
			this.Name = name;
			this.Type = type;
		}
	}
}
