/* 
 * Copyright (C) 1999-2010 John K�ll�n.
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

using Decompiler.Core;
using Decompiler.Core.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Decompiler.Gui.Windows.Forms
{
    public interface IFinalPageInteractor : IPhasePageInteractor
    {
    }

    public class FinalPageInteractor : PhasePageInteractorImpl, IFinalPageInteractor
    {
        IProgramImageBrowserService browserService;

        public FinalPageInteractor()
        {
        }

        void DataTypeDefinitionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplorerWindow(Decompiler.Project.Output.TypesFilename);
        }

        void ProgramCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplorerWindow(Decompiler.Project.Output.OutputFilename);
        }

        private void ShowExplorerWindow(string filePath)
        {
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
        }


        public void ConnectToBrowserService()
        {
            browserService = GetService<IProgramImageBrowserService>();
            browserService.SelectionChanged += browserService_SelectionChanged;
            browserService.Caption = "Procedures";
            browserService.SelectionChanged += new EventHandler(browserService_SelectionChanged);
        }

        public void DisconnectFromBrowserService()
        {
            browserService.SelectionChanged -= browserService_SelectionChanged;
        }

        public override void PerformWork(IWorkerDialogService workerDialogSvc)
        {
            try
            {
                workerDialogSvc.StartBackgroundWork("Reconstructing datatypes.", delegate()
                {
                    Decompiler.ReconstructTypes();
                });
                workerDialogSvc.StartBackgroundWork("Structuring program.", delegate()
                {
                    Decompiler.StructureProgram();
                });
            }
            catch (Exception ex)
            {
                UIService.ShowError(ex, "An error occurred while reconstructing types.");
            }
        }

        public override void EnterPage()
        {
            ConnectToBrowserService();
            PopulateBrowserService();
        }

        private void PopulateBrowserService()
        {
            browserService.Populate(Decompiler.Program.Procedures.Values, delegate(object o, IListViewItem item)
            {
                item.Text = o.ToString();
            });
        }


        public override bool LeavePage()
        {
            DisconnectFromBrowserService();
            return true;
        }

        void browserService_SelectionChanged(object sender, EventArgs e)
        {
            var proc = (Procedure) browserService.SelectedItem;
            var codeSvc = GetService<ICodeViewerService>();
            codeSvc.DisplayProcedure(proc);
        }
    }
}
