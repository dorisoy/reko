/* 
 * Copyright (C) 1999-2008 John K�ll�n.
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
using Decompiler.Gui;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Windows.Forms;

namespace Decompiler.WindowsGui.Forms
{
	public class LoadedPageInteractor : PhasePageInteractor
	{
		private ILoadedPage pageLoaded;
		private Hashtable mpCmdidToCommand;

		public LoadedPageInteractor(ILoadedPage page, MainFormInteractor form, DecompilerMenus dm) : base(form)
		{
			this.pageLoaded = page;
            page.MemoryControl.SelectionChanged += new System.EventHandler(this.memctl_SelectionChanged);
            page.Disassembly.Resize += new System.EventHandler(this.txtDisassembly_Resize);

			mpCmdidToCommand = new Hashtable();
            AddCommand(ref CmdSets.GuidDecompiler, CmdIds.EditFind);
			AddCommand(ref CmdSets.GuidDecompiler, CmdIds.ViewShowAllFragments);
			AddCommand(ref CmdSets.GuidDecompiler, CmdIds.ViewShowUnscanned);
			AddCommand(ref CmdSets.GuidDecompiler, CmdIds.ViewFindFragments);
			pageLoaded.MemoryControl.ContextMenu = dm.GetContextMenu(MenuIds.CtxMemoryControl);
		}

		protected MenuCommand AddCommand(ref Guid cmdSet, int cmdId)
		{
			MenuCommand mc = new MenuCommand(null, new CommandID(cmdSet, cmdId));
			mpCmdidToCommand.Add(mc.CommandID.ID, mc);
			return mc;
		}

		public void BrowserItemSelected()
		{
			ImageMapSegment segment = (ImageMapSegment) MainForm.BrowserList.FocusedItem.Tag;
			pageLoaded.MemoryControl.TopAddress = segment.Address;
			pageLoaded.MemoryControl.SelectedAddress = segment.Address;
		}

		public override bool Execute(ref Guid cmdSet, int cmdId)
		{
			if (cmdSet == CmdSets.GuidDecompiler)
			{
				switch (cmdId)
				{
				case CmdIds.BrowserItemSelected:
					BrowserItemSelected(); return true;
				case CmdIds.ViewGoToAddress:
					GotoAddress(); return true;
				case CmdIds.ActionMarkProcedure:
					MarkAndScanProcedure(); return true;
				}
			}
			return base.Execute(ref cmdSet, cmdId);
		}


		public void GotoAddress()
		{
			using (GotoDialog dlg = new GotoDialog())
			{
				GotoDialogInteractor i = new GotoDialogInteractor(dlg);
				if (ShowModalDialog(dlg) == DialogResult.OK)
				{
					pageLoaded.MemoryControl.SelectedAddress = i.Address;
					pageLoaded.MemoryControl.TopAddress = i.Address;
				}
			}
		}




        public void DumpAssembler()
        {
            if (Decompiler.Program.Architecture == null || Decompiler.Program.Image == null || pageLoaded.MemoryControl.SelectedAddress == null)
            {
                pageLoaded.Disassembly.Text = "";
                return;
            }
            int lines = (pageLoaded.Disassembly.Height + pageLoaded.Disassembly.Font.Height - 1) / pageLoaded.Disassembly.Font.Height;
            if (lines < 1)
                lines = 1;
            StringWriter writer = new StringWriter();
            Dumper dumper = Decompiler.Program.Architecture.CreateDumper();
            Disassembler dasm = Decompiler.Program.Architecture.CreateDisassembler(Decompiler.Program.Image, pageLoaded.MemoryControl.SelectedAddress);
            while (lines != 0)
            {
                dumper.DumpAssemblerLine(Decompiler.Program.Image, dasm, true, true, writer);
                --lines;
            }
            pageLoaded.Disassembly.Text = writer.ToString();
        }

		public override void EnterPage()
		{
			Decompiler.ScanProgram();

			pageLoaded.MemoryControl.ProgramImage = Decompiler.Program.Image;
			pageLoaded.Disassembly.Text = "";

			MainForm.BrowserList.Visible = true;
			MainForm.BrowserList.Enabled = true;
			PopulateBrowser();
		}

		public override bool LeavePage()
		{
			return true;
		}

        public void MarkAndScanProcedure()
        {
            Address addr = pageLoaded.MemoryControl.SelectedAddress;
            if (addr != null)
            {
                Procedure proc = Decompiler.ScanProcedure(addr);
                SerializedProcedure userp = new SerializedProcedure();
                userp.Address = addr.ToString();
                userp.Name = proc.Name;
                Decompiler.Project.UserProcedures.Add(userp);
                pageLoaded.MemoryControl.Invalidate();
            }
        }

        public override object Page
        {
            get { return pageLoaded; }
        }

		public void PopulateBrowser()
		{
			MainForm.BrowserList.Items.Clear();
			foreach (ImageMapSegment seg in Decompiler.Program.Image.Map.Segments.Values)
			{
				ListViewItem node = new ListViewItem(seg.Name);
				node.Tag = seg;
				MainForm.BrowserList.Items.Add(node);
			}
		}

		public override bool QueryStatus(ref Guid cmdSet, int cmdId, CommandStatus status, CommandText text)
		{
			if (cmdSet == CmdSets.GuidDecompiler)
			{
				MenuCommand cmd = (MenuCommand) mpCmdidToCommand[cmdId];
				if (cmd == null)
					return false;
				status.Status = (MenuStatus) cmd.OleStatus;
				return true;
			}
			return false;
		}

        // Event handlers /////////////////////////

        private void memctl_SelectionChanged(object sender, System.EventArgs e)
        {
            DumpAssembler();
        }

        private void txtDisassembly_Resize(object sender, System.EventArgs e)
        {
            DumpAssembler();
        }

	}
}
