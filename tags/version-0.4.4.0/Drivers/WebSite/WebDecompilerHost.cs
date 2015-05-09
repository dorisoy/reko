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

using Decompiler;
using Decompiler.Core;
using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace Decompiler.WebSite
{
	public class WebDecompilerHost : DecompilerHost
	{
		private StringWriter assembler;
		private StringWriter writer; 
		private StringWriter discard;

		public WebDecompilerHost()
		{
			assembler = new StringWriter();
			writer = new StringWriter();
			discard = new StringWriter();
		}

		public string FetchSample(HttpServerUtility server, string file)
		{
			StringWriter sw = new StringWriter();
			string filename = server.MapPath(Path.Combine("SampleFiles", file));
			using (StreamReader rdr = new StreamReader(filename))
			{
				string line = rdr.ReadLine();
				while (line != null)
				{
					sw.WriteLine(line);
					line = rdr.ReadLine();
				}
			}
			return sw.ToString();
		}

		public void PopulateSampleFiles(HttpServerUtility server, string wildcard, DropDownList ddl)
		{
			string sampleDir = server.MapPath("SampleFiles");
			ddl.Items.Add(new ListItem("Choose sample", ""));
			DirectoryInfo di = new DirectoryInfo(sampleDir);
			foreach (FileInfo f in di.GetFiles(wildcard))
			{
				ddl.Items.Add(new ListItem(Path.GetFileNameWithoutExtension(f.Name), f.Name));
			}
		}


		public TextWriter DecompiledCodeWriter
		{
			get { return writer; }
		}

		public TextWriter DisassemblyWriter
		{
			get { return assembler; }
		}

		public TextWriter IntermediateCodeWriter
		{
			get { return discard; }
		}

		public TextWriter TypesWriter
		{
			get { return writer; }
		}


		public void WriteDiagnostic(Diagnostic d, string format, params object[] args)
		{
			writer.Write("{0}: ", d);
			writer.Write(format, args);
			writer.WriteLine("<br>");
		}

        public void WriteDisassembly(Program program, Action<TextWriter> writer)
        {
            throw new NotImplementedException();
        }

        public void WriteIntermediateCode(Program program, Action<TextWriter> writer)
        {
            throw new NotImplementedException();
        }

        public void WriteTypes(Program program, Action<TextWriter> writer)
        {
            throw new NotImplementedException();
        }

        public void WriteDecompiledCode(Program program, Action<TextWriter> writer)
        {
            throw new NotImplementedException();
        }

        public void WriteGlobals(Program program, Action<TextWriter> writer)
        {
            throw new NotImplementedException();
        }

        public Decompiler.Core.Configuration.IDecompilerConfigurationService Configuration
        {
            get { throw new NotImplementedException(); }
        }
    }
}
