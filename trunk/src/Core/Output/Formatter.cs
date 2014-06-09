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

using System;
using System.IO;
using System.Globalization;

namespace Decompiler.Core.Output
{
	/// <summary>
	/// Base class for all formatting classes. 
	/// </summary>
	public abstract class Formatter
	{
		public Formatter()
		{
			this.UseTabs = true;
			this.TabSize = 4;
			this.Indentation = 4;
		}

		public void Indent()
		{
			int n = Indentation;
			while (n >= TabSize)
			{
				if (UseTabs)
				{
					Write("\t");
				}
				else
				{
					WriteSpaces(TabSize);
				}
				n -= TabSize;
			}
			WriteSpaces(n);
		}

		public int Indentation { get; set; }
		public int TabSize  {get; set; }
        public bool UseTabs { get; set; }

        /// <summary>
        /// Terminate a line.
        /// </summary>
        public abstract void Terminate();

        /// <summary>
        /// Write the string <paramref name="s"/>, then terminate the line.
        /// </summary>
        /// <param name="s"></param>
		public void Terminate(string s)
		{
			Write(s);
            Terminate();
		}

        /// <summary>
        /// Write the string <paramref name="s"/> with no special formatting.
        /// </summary>
        /// <param name="s"></param>
        public abstract void Write(string s);

        public void Write(object o)
        {
            if (o != null)
                Write(o.ToString());
        }

        public abstract void Write(string format, params object[] arguments);

        public abstract void WriteComment(string comment);

        public abstract void WriteHyperlink(string text, object href);

        public abstract void WriteKeyword(string keyword);

        public abstract void WriteLine();

        public abstract void WriteLine(string s);

        public void WriteLine(object o)
        {
            if (o != null)
                Write(o);
            WriteLine();
        }

        public abstract void WriteLine(string format, params object[] arguments);

		public void WriteSpaces(int n)
		{
			while (n > 0)
			{
				Write(" ");
				--n;
			}
		}
    }
}
