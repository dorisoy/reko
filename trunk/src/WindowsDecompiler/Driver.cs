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

using Decompiler;
using Decompiler.Loading;
using Decompiler.Core;
using Decompiler.Core.Services;
using Decompiler.Configuration;
using Decompiler.Gui;
using Decompiler.Gui.Forms;
using Decompiler.Gui.Windows;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace WindowsDecompiler
{
	public class Driver
	{
		[STAThread]
		public static void Main(string [] args)
		{
			if (args.Length == 0)
			{
                var services = new ServiceContainer();
                services.AddService(typeof(IServiceFactory), new ServiceFactory(services));
                services.AddService(typeof(IDialogFactory), new WindowsFormsDialogFactory());
                var interactor = new MainFormInteractor(services);
                interactor.Run();
            }
			else
			{
                var host = NullDecompilerHost.Instance;
                var listener = NullDecompilerEventListener.Instance;

                var sc = new ServiceContainer();
                sc.AddService(typeof (DecompilerEventListener), listener);
                var ldr = new Loader(new DecompilerConfiguration(), sc);
				var dec = new DecompilerDriver(ldr, host, sc);
				dec.Decompile(args[0]);
			}
		}
	}
}
