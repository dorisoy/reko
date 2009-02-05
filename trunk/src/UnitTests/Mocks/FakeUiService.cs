/* 
 * Copyright (C) 1999-2009 John K�ll�n.
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

using Decompiler.Gui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Decompiler.UnitTests.Mocks
{
    public class FakeUiService: IDecompilerUIService
    {
        private bool simulateUserCancel;
        private string lastFileName;
        private Form lastDialogShown;

        public ContextMenu GetContextMenu(int menuId)
        {
            return new ContextMenu();
        }

        public void ShowError(string format, params object[] args)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DialogResult ShowModalDialog(Form dlg)
        {
            lastDialogShown = dlg;
            return  simulateUserCancel
                    ? DialogResult.Cancel
                    : DialogResult.OK;
        }

        public string ShowOpenFileDialog(string fileName)
        {
            if (!simulateUserCancel)
            {
                return lastFileName;
            }
            else
                return null;
        }

        public string ShowSaveFileDialog(string fileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Fake members ///////

        public string OpenFileResult
        {
            get { return lastFileName; }
            set { lastFileName = value; }
        }


        public bool SimulateUserCancel
        {
            get { return simulateUserCancel; }
            set { simulateUserCancel = value; }
        }


        public Form ProbeLastShownDialog
        {
            get { return lastDialogShown; }
        }
    }
}
