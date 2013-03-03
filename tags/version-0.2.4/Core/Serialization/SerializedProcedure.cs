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

using System.ComponentModel;
using System.Xml.Serialization;

namespace Decompiler.Core.Serialization
{
	public class SerializedProcedure : SerializedProcedureBase
	{
        /// <summary>
        /// Address of the procedure.
        /// </summary>
		[XmlElement("address")]
		public string Address;

        /// <summary>
        /// Property that indicated whether the procedure body is to be decompiled or not. If false, it is recommended
        /// that the Signature property be set.
        /// </summary>
		[XmlElement("decompile")]
		[DefaultValue(true)]
		public bool Decompile = true;
	}
}

