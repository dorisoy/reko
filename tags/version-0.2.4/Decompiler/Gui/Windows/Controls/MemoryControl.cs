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
using Decompiler.Core;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Decompiler.Gui.Windows.Controls
{
	/// <summary>
	/// Displays the contents of memory and allows selection of memory ranges. 
	/// </summary>
	/// <remarks>
	/// Memory that has been identified is colored.
	/// <para>
	/// A memory cell is displayed with a one-pixel border on all sides to
	/// help present it with selections.
	/// </para>
	/// </remarks>
	public class MemoryControl : Control
	{
		public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

		private Address addrTopVisible;		// address of topmost visible row.
		private uint wordSize;
		private uint cbRow;
		private ProgramImage image;
		private Address addrSelected;
        private Address addrAnchor;
        private int iCtrl;          //$DEBUG

		private int cRows;				// total number of rows.
		private int yTopRow;			// index of topmost visible row
		private int cyPage;				// number of rows / page.
		private Size cellSize;			// size of cell in pixels.
		private Point ptDown;			 // point at which mouse was clicked.
		private VScrollBar vscroller;

        static int ctrlCount;

		public MemoryControl()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			vscroller = new VScrollBar();
			vscroller.Dock = DockStyle.Right;
			Controls.Add(vscroller);
			vscroller.Scroll += new ScrollEventHandler(vscroller_Scroll);
			wordSize = 1;
			cbRow = 16;
            this.iCtrl = ctrlCount++;
		}

        /// <summary>
        /// Returns the selection as an address range. Note that the range is 
        /// a closed interval in the address space.
        /// </summary>
        public AddressRange GetAddressRange()
        {
            Debug.WriteLine(string.Format("GetAddressRange: ctrl{2}: sel: {0}, anchor {1}", addrSelected, addrAnchor, iCtrl));

            if (addrSelected == null || addrAnchor == null)
            {
                return AddressRange.Empty;
            }
            else
            {
                if (addrSelected <= addrAnchor)
                {
                    return new AddressRange(addrSelected, addrAnchor);
                }
                else
                {
                    return new AddressRange(addrAnchor, addrSelected);
                }
            }
        }

		public uint BytesPerRow
		{
			get { return cbRow; }
			set 
			{
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("BytesPerRow must be positive.");
				UpdateScroll();
				cbRow = value;
			}
		}

		private void CacheCellSize()
		{
			using (Graphics g = this.CreateGraphics())
			{
				SizeF cellF = g.MeasureString("M", Font, Width, StringFormat.GenericTypographic);
				cellSize = new Size((int) (cellF.Width + 0.5F), (int) (cellF.Height + 0.5F));
			}
		}

		private Size CellSize
		{
			get { return cellSize; }
		}

		private Brush GetBackgroundBrush(ImageMapItem item, bool selected)
		{
			if (selected)
				return SystemBrushes.Highlight;
			if (item is ImageMapBlock)
				return Brushes.Pink;
            if (item.DataType != null && !(item.DataType is UnknownType))
                return Brushes.LightBlue;
			return SystemBrushes.Window;
		} 

		private Brush GetForegroundBrush(ImageMapItem item, bool selected)
		{
			if (selected)
				return SystemBrushes.HighlightText;
			return SystemBrushes.WindowText;
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
				return base.IsInputKey (keyData);
			}
		}



        public Point AddressToPoint(Address addr)
        {
            if (addr == null || TopAddress == null)
                return Point.Empty;
            int cbOffset = addr - TopAddress;
            int yRow = cbOffset / (int)cbRow;
            if (yTopRow <= yRow && yRow < yTopRow + cyPage)
            {
                return new Point(60, yRow * cellSize.Height);
            }
            else
                return Point.Empty;
        }

		private bool IsVisible(Address addr)
		{
			if (addr == null || TopAddress == null)
				return false;
			int cbOffset = addr - TopAddress;
			int yRow = cbOffset / (int)cbRow;
			return (yTopRow <= yRow && yRow < yTopRow + cyPage);
		}

		private void MoveSelection(int offset, Keys modifiers)
		{
            if (SelectedAddress == null)
                return;
            uint linAddr = (uint)(SelectedAddress.Linear + offset);
            if (!image.IsValidLinearAddress(linAddr))
                return;
            Address addr = image.Map.MapLinearAddressToAddress(linAddr);
			if (!IsVisible(SelectedAddress))
			{
                Address newTopAddress = TopAddress + offset;
                if (image.IsValidAddress(newTopAddress))
                {
                    TopAddress = newTopAddress;
                }
			}
            if ((modifiers & Keys.Shift) != Keys.Shift)
            {
                addrAnchor = addr;
            }
            addrSelected = addr;
            Invalidate();
            OnSelectionChanged();
		}


		protected override void OnKeyDown(KeyEventArgs e)
		{
//            Debug.WriteLine(string.Format("K: {0}, D: {1}, M: {2}", e.KeyCode, e.KeyData, e.Modifiers));
			switch (e.KeyCode)
			{
			case Keys.Down:
				MoveSelection((int)cbRow, e.Modifiers);
				break;
			case Keys.Up:
                MoveSelection(-(int)cbRow, e.Modifiers);
				break;
			case Keys.Left:
                MoveSelection(-(int)wordSize, e.Modifiers);
				break;
			case Keys.Right:
                MoveSelection((int)wordSize, e.Modifiers);
				break;
            default:
			    base.OnKeyDown(e);
                return;
            }
            e.Handled = true;
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            CacheCellSize();
            base.OnHandleCreated(e);
        }

		protected override void OnMouseDown(MouseEventArgs e)
		{
            if (image == null)
                return;
            ptDown = new Point(e.X, e.Y);
            Focus();
            CacheCellSize();

            AffectSelection(e);
            base.OnMouseDown(e);
		}

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (image == null)
                return;
            AffectSelection(e);
            base.OnMouseUp(e);
        }


        private void AffectSelection(MouseEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                var addrClicked = PaintWindow(g, false);
                if (ShouldChangeSelection(e, addrClicked))
                {
                    addrSelected = addrClicked;
                    if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
                    {
                        addrAnchor = addrSelected;
                    }
                    Debug.WriteLine(string.Format("MouseDown: ctrl{2}: sel: {0}, anchor {1}", addrSelected, addrAnchor, iCtrl));
                    Invalidate();
                    OnSelectionChanged();
                }
            }
        }

        private bool ShouldChangeSelection(MouseEventArgs e, Address addrClicked)
        {
            if (e.Button == MouseButtons.Left)
                return true;
            if (addrClicked == null)
                return true;

            return !IsAddressInSelection(addrClicked);
        }

        private bool IsAddressInSelection(Address addr)
        {
            if (addr == null || addrAnchor == null || addrSelected == null)
                return false;
            var linAddr = addr.Linear;
            var linAnch = addrAnchor.Linear;
            var linSel = addrSelected.Linear;
            if (linAnch <= linSel)
            {
                return linAnch <= linAddr && linAddr <= linSel;
            }
            else 
            {
                return linSel <= linAddr && linAddr <= linAnch;
            }
        }

		protected override void OnPaint(PaintEventArgs pea)
		{
            CacheCellSize();
			if (image == null)
			{
				pea.Graphics.FillRectangle(SystemBrushes.Window, ClientRectangle);
			}
			else
			{
				PaintWindow(pea.Graphics, true);
			}
		}

		protected virtual void OnSelectionChanged()
		{
            var eh = SelectionChanged;
            if (eh != null)
                eh(this, new SelectionChangedEventArgs(GetAddressRange()));
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			UpdateScroll();
		}
		
		/// <summary>
		/// Paints a line of the memory control, starting with the address. 
		/// </summary>
		/// <remarks>
		/// The strategy is to find any items present at the current address, and try
		/// to paint as many adjacent items as possible.
		/// </remarks>
		/// <param name="g"></param>
		/// <param name="rc"></param>
		/// <param name="rdr"></param>
		private Address PaintLine(Graphics g, Rectangle rc, ImageReader rdr, bool render)
		{
			StringBuilder sbCode = new StringBuilder(" ");

			// Draw the address part.

			rc.X = 0;
			string s = string.Format("{0}", rdr.Address);
			int cx = (int) g.MeasureString(s + "X", Font, rc.Width, StringFormat.GenericTypographic).Width;
			if (!render && new Rectangle(rc.X, rc.Y, cx, rc.Height).Contains(ptDown))
			{
				return rdr.Address;
			}
			else
			{
				g.FillRectangle(SystemBrushes.Window, rc.X, rc.Y, cx, rc.Height);
				g.DrawString(s, Font, SystemBrushes.ControlText, rc.X, rc.Y, StringFormat.GenericTypographic);
			}
			cx -= cellSize.Width / 2;
			rc = new Rectangle(cx, rc.Top, rc.Width - cx, rc.Height);

			uint rowBytesLeft = cbRow;
			uint linearSelected = addrSelected != null ? addrSelected.Linear : ~0U;
            uint linearAnchor = addrAnchor != null ? addrAnchor.Linear : ~0U;
            uint linearBeginSelection = Math.Min(linearSelected, linearAnchor);
            uint linearEndSelection = Math.Max(linearSelected, linearAnchor);

			do 
			{
				Address addr = rdr.Address;
				uint linear = addr.Linear;

				ImageMapItem item;
                if (!ProgramImage.Map.TryFindItem(addr, out item))
					break;
				uint cbIn = (linear - item.Address.Linear);			// # of bytes 'inside' the block we are.
				uint cbToDraw = 16; // item.Size - cbIn;

				// See if the chunk goes off the edge of the line. If so, clip it.
				if (cbToDraw > rowBytesLeft)
					cbToDraw = rowBytesLeft;

				// Now paint the bytes in this span.

				for (int i = 0; i < cbToDraw; ++i)
				{
					Address addrByte = rdr.Address;
					ProgramImage.Map.TryFindItem(addrByte, out item);
					bool isSelected = linearBeginSelection <= addrByte.Linear && addrByte.Linear <= linearEndSelection;
                    bool isCursor = addrByte.Linear == linearSelected;
					Brush fg = GetForegroundBrush(item, isSelected);
					Brush bg = GetBackgroundBrush(item, isSelected);

                    if (rdr.IsValid)
                    {
                        byte b = rdr.ReadByte();
                        s = string.Format("{0:X2}", b);
                        char ch = (char)b;
                        sbCode.Append(Char.IsControl(ch) ? '.' : ch);
                    }
                    else
                    {
                        s = "??";
                        sbCode.Append(' ');
                    }

					cx = cellSize.Width * 3;
					Rectangle rcByte = new Rectangle(
						rc.Left,
						rc.Top,
						cx,
						rc.Height);
	
					if (!render && rcByte.Contains(ptDown))
						return addrByte;

					g.FillRectangle(bg, rc.Left, rc.Top, cx, rc.Height);
					g.DrawString(s, Font, fg, rc.Left + cellSize.Width / 2, rc.Top, StringFormat.GenericTypographic);
                    if (isCursor)
                    {
                        ControlPaint.DrawFocusRectangle(g, rc);
                    }
					rc = new Rectangle(rc.X + cx, rc.Y, rc.Width - cx, rc.Height);
				}
				rowBytesLeft -= cbToDraw;
			} while (rowBytesLeft > 0);

			if (render)
			{
				g.FillRectangle(SystemBrushes.Window, rc);
				g.DrawString(sbCode.ToString(), Font, SystemBrushes.WindowText, rc.X + cellSize.Width, rc.Top, StringFormat.GenericTypographic);
			}
			return null;
		}

		/// <summary>
		/// Paints the control's window area. Strategy is to find the spans that make up
		/// the whole segment, and paint them one at a time.
		/// </summary>
		/// <param name="g"></param>
		public Address PaintWindow(Graphics g, bool render)
		{
			// Enumerate all segments visible on screen.

			ImageReader rdr = image.CreateReader(addrTopVisible);
			Rectangle rc = ClientRectangle;
			Size cell = CellSize;
			rc.Height = cell.Height;

			uint laEnd = image.BaseAddress.Linear + (uint) image.Bytes.Length;

			uint laSegEnd = 0;
			while (rc.Top < this.Height && rdr.Address.Linear < laEnd)
			{
                ImageMapSegment seg;
                if (!ProgramImage.Map.TryFindSegment(addrTopVisible, out seg))
                    return null;
                if (rdr.Address.Linear >= laSegEnd)
				{
					laSegEnd = seg.Address.Linear + seg.Size;
					rdr = image.CreateReader(seg.Address + (rdr.Address - seg.Address));
				}
				Address addr = PaintLine(g, rc, rdr, render);
				if (addr != null)
					return addr;
				rc.Offset(0, CellSize.Height);
			}
			return null;
		}


		[Browsable(false)]
		public ProgramImage ProgramImage
		{
			get { return image; }
			set { 
				image = value;
				if (image != null)
				{
					TopAddress = image.BaseAddress;
					UpdateScroll();
				}
				else
				{
					UpdateScroll();
					Invalidate();
				}
			}
		}

		private Address RoundToNearestRow(Address addr)
		{
			uint rows = addr.Linear / cbRow;
			return image.Map.MapLinearAddressToAddress(rows * cbRow);
		}

		[Browsable(false)]
		public Address SelectedAddress
		{
			get { return addrSelected; }
			set 
			{
				addrSelected = value;
                addrAnchor = value;
				if (IsVisible(value) || IsVisible(addrSelected))
					Invalidate();
				OnSelectionChanged();
			}
		}

		[Browsable(false)]
		public Address TopAddress
		{
			get { return addrTopVisible; }
			set
			{
				addrTopVisible = value;
				UpdateScroll();
				Invalidate();
			}
		}

		public void ShowAddress(Address addr)
		{
            if (image == null || addr < image.BaseAddress)
                return;

            uint cbOffset = (uint)(addr - image.BaseAddress);
			if (cbOffset < 0)
				return;

			if (!IsVisible(addr))
			{
				TopAddress = RoundToNearestRow(addr);
                yTopRow = (int)(cbOffset / cbRow);
				vscroller.Value = yTopRow;
				Invalidate();
			}
		}

		private void UpdateScroll()
		{
			if (addrTopVisible == null || image == null || CellSize.Height <= 0)
			{
				vscroller.Enabled = false;
				return;
			}

			vscroller.Enabled = true;
			cRows = (image.Bytes.Length + (int)cbRow - 1) / (int) cbRow;
			int nChunks = (int)(cbRow / wordSize);		// number of chunks per line.

			vscroller.Minimum = 0;
			int h = Font.Height;
			cyPage = Math.Max((Height / CellSize.Height) - 1, 1);
			vscroller.LargeChange = cyPage;
            vscroller.Maximum = cRows;
            int newValue = (int)((addrTopVisible.Linear - image.BaseAddress.Linear) / cbRow);
            vscroller.Value = Math.Max(Math.Min(newValue, vscroller.Maximum), vscroller.Minimum); 
		}

		public uint WordSize
		{
			get { return wordSize; }
			set 
			{	
				wordSize = value;
				UpdateScroll();
				Invalidate();
			}
		}

		private void vscroller_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.Type == ScrollEventType.ThumbTrack)
				return;
            Address newTopAddress;
			if (image.BaseAddress.Selector != 0)
			{
				newTopAddress = image.Map.MapLinearAddressToAddress(image.BaseAddress.Linear + (uint)e.NewValue * cbRow);
			}
			else
			{
				newTopAddress = image.BaseAddress + (uint)e.NewValue * cbRow;
			}
            if (image.IsValidAddress(newTopAddress))
            {
                TopAddress = newTopAddress;
            }
		}

    }
}