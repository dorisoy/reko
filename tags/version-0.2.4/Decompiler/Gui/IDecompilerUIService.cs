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
using System.Text;
using System.Windows.Forms;

namespace Decompiler.Gui
{
    /// <summary>
    /// Provides services for displaying items in the user interface.
    /// </summary>
    public interface IDecompilerUIService
    {
        void ShowError(Exception ex, string format, params object[] args);
        DialogResult ShowModalDialog(IDialog dlg);
        string ShowOpenFileDialog(string fileName);
        string ShowSaveFileDialog(string fileName);
    }

    public interface IDecompilerShellUiService : IDecompilerUIService
    {
        ContextMenu GetContextMenu(int p);

        IWindowFrame FindWindow(string windowType);
        IWindowFrame FindDocumentWindow(string documentType, object docItem);
        IWindowFrame CreateWindow(string windowType, string windowTitle, IWindowPane pane);
        IWindowFrame CreateDocumentWindow(string documentType, string documentTitle, object docItem, IWindowPane pane);

    }
}
