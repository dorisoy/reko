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

using Decompiler.Core;
using Decompiler.Core.Machine;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Decompiler.Gui.Windows.Controls
{
	public class DisassemblyControl : Control
	{
        private VScrollBar vscroll;

        public DisassemblyControl()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            ImageChanged += DisassemblyControl_StateChange;
            ArchitectureChanged += DisassemblyControl_StateChange;
            StartAddressChanged += DisassemblyControl_StateChange;
            TopAddressChanged += DisassemblyControl_StateChange;
     
            vscroll = new VScrollBar();
            vscroll.Margin = new Padding(10);

            vscroll.Enabled = false;
            vscroll.Visible = true;
            vscroll.Value = 0;
            vscroll.Minimum = 0;
            vscroll.Maximum = 10000;
            vscroll.MinimumSize = new Size(0, 20);
            vscroll.Dock = DockStyle.Right;
            Controls.Add(vscroll);
            vscroll.ValueChanged += vscroll_ValueChanged;
        }

        [Browsable(false)]
        public LoadedImage Image { get { return image; } set { image = value; ImageChanged.Fire(this); } }
        public event EventHandler ImageChanged;
        private LoadedImage image;

        [Browsable(false)]
        public IProcessorArchitecture Architecture { get { return arch; } set { arch = value; ArchitectureChanged.Fire(this); } }
        public event EventHandler ArchitectureChanged;
        private IProcessorArchitecture arch;

        [Browsable(false)]
        public Address StartAddress { get { return startAddress; } set { startAddress = value; StartAddressChanged.Fire(this); } }
        public event EventHandler StartAddressChanged;
        private Address startAddress;

        [Browsable(false)]
        public Address TopAddress { get { return topAddress; } set { topAddress = value; TopAddressChanged.Fire(this); } }
        public event EventHandler TopAddressChanged;
        private Address topAddress;

        [Browsable(false)]
        public Address SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                TopAddress = value;
                Invalidate();
                SelectedAddressChanged.Fire(this);
            }
        }
        public event EventHandler SelectedAddressChanged;
        private Address selectedAddress;

        private void vscroll_ValueChanged(object sender, EventArgs e)
        {
            if (image == null || arch == null || !image.IsValidAddress(startAddress))
                return;
            TopAddress = image.BaseAddress + vscroll.Value * (arch.InstructionBitSize / 8);
        }

        void DisassemblyControl_StateChange(object sender, EventArgs e)
        {
            if (arch == null || image == null || !image.IsValidAddress(startAddress))
            {
                vscroll.Enabled = false;
            }
            else
            {
                vscroll.Enabled = true;
                vscroll.Minimum = 0;
                vscroll.Maximum = (image.Bytes.Length - 1) / (arch.InstructionBitSize / 8);

                using (var g = CreateGraphics())
                {
                    var cyRow = g.MeasureString("M", Font).Height;
                    int EstimateRows = (int) Math.Ceiling(Height / cyRow);
                    int estimateByteSize = EstimateRows * 3;
                }
            }
            Invalidate();
        }

        public void DumpAssembler(Graphics g)
        {
            var rcClient = ClientRectangle;
            g.Clear(BackColor);
            if (arch == null || image == null || !image.IsValidAddress(topAddress))
            {
                return;
            }

            var dumper = new Dumper(arch);
            dumper.ShowAddresses = true;
            dumper.ShowCodeBytes = true;
            var addrStart = TopAddress;
            var rdr = arch.CreateImageReader(image, addrStart);
            var dasm = arch.CreateDisassembler(rdr);
            var cyRow = GetRowHeight(g);
            var rc = new RectangleF(g.ClipBounds.Left, g.ClipBounds.Top, rcClient.Width, cyRow);
            for (; rc.Top < rcClient.Bottom; rc.Offset(0, cyRow))
            {
                var instr = NextInstruction(dasm);
                if (instr == null)
                    break;
                var writer = new StringWriter();
                dumper.DumpAssemblerLine(image, instr, writer);
                var s = writer.ToString();
                Brush brText;
                if (instr.Address == selectedAddress)
                {
                    Debug.Print("NILZ");    //$DEBUG
                    g.FillRectangle(SystemBrushes.Highlight, rc);
                    brText = SystemBrushes.HighlightText;
                }
                else
                {
                    brText = SystemBrushes.ControlText;
                }
                g.DrawString(s, Font, brText, rc);
            }
        }

        private MachineInstruction NextInstruction(IEnumerator<MachineInstruction> dasm)
        {
            try
            {
                if (!dasm.MoveNext())
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            return dasm.Current;
        }

        private int GetRowHeight(Graphics g)
        {
            return (int) g.MeasureString("M", Font).Height;
        }

        private void UpdateScrollbar(Address addrBegin, Address addrEnd)
        {
            //vscroll.Enabled = true;
            //vscroll.Minimum = 0;
            //vscroll.Maximum = Image.Bytes.Length - 0x10;
            //vscroll.LargeChange = 100;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData & ~Keys.Modifiers)
            {
            case Keys.Down:
            case Keys.Up:
            case Keys.Left:
            case Keys.Right:
                return true;
            default:
                return base.IsInputKey(keyData);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Debug.Print("Disassembly control: Down:  c:{0} d:{1} v:{2}", e.KeyCode, e.KeyData, e.KeyValue);
            switch (e.KeyCode)
            {
            case Keys.Down:
                DiffMove(arch.InstructionBitSize / 8);
                break;
            case Keys.Up:
                DiffMove(-arch.InstructionBitSize / 8);
                break;
            default:
                base.OnKeyDown(e);
                return;
            }
            e.Handled = true;
        }

        private void DiffMove(int bytesToMove)
        {
            var topAddr = TopAddress + bytesToMove;
            if (topAddr < this.image.BaseAddress)
                return;
            TopAddress = topAddr;
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DumpAssembler(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            base.OnMouseDown(e);
        }

        //public Control CreateControl()
        //{
        //    txtDisassembly = new TextBox
        //    {
        //        Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0))),
        //        Multiline = true,
        //        Name = "txtDisassembly",
        //        ReadOnly = true,
        //        WordWrap = false,
        //    };
        //    txtDisassembly.Resize += txtDisassembly_Resize;
        //    txtDisassembly.KeyDown += txtDisassembly_KeyDown;
        //    txtDisassembly.KeyPress += txtDisassembly_KeyPress;
        //    return txtDisassembly;
        //}

	}
}
