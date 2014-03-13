﻿#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
using Decompiler.Gui;
using Decompiler.Gui.Forms;
using Decompiler.Gui.Windows;
using Decompiler.Gui.Windows.Controls;
using Decompiler.Gui.Windows.Forms;
using Decompiler.UnitTests.Mocks;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Windows.Forms;

namespace Decompiler.UnitTests.Gui.Windows
{
    [TestFixture]
    public class MemoryViewInteractorTests
    {
        private MemoryViewInteractor interactor;
        private MockRepository mr;
        private IDecompilerShellUiService uiSvc;
        private IDialogFactory dlgFactory;
        private ServiceContainer sp;
        private Address addrBase;
        private LowLevelView control;
        private LoadedImage image;
        private ImageMap imageMap;

        [SetUp]
        public void Setup()
        {
            mr = new MockRepository();
            sp = new ServiceContainer();
            uiSvc = mr.DynamicMock<IDecompilerShellUiService>();
			dlgFactory = mr.DynamicMock<IDialogFactory>();
            sp.AddService(typeof(IDecompilerShellUiService), uiSvc);
			sp.AddService(typeof(IDialogFactory), dlgFactory);
            addrBase = new Address(0x1000);
        }

        private void Given_Interactor()
        {
            interactor = new MemoryViewInteractor();
            interactor.SetSite(sp);
            control = (LowLevelView) interactor.CreateControl();
        }

        [Test]
        public void MVI_GotoAddressEnabled()
        {
            interactor = new MemoryViewInteractor();
            var status = new CommandStatus();
            Assert.IsTrue(interactor.QueryStatus(ref CmdSets.GuidDecompiler, CmdIds.ViewGoToAddress, status, null));
            Assert.AreEqual(status.Status, MenuStatus.Enabled | MenuStatus.Visible);
        }

        [Test]
        public void MVI_SelectAddress()
        {
            Given_Interactor();
            mr.ReplayAll();

            interactor.Control.MemoryView.SelectedAddress = new Address(0x12321);

            Assert.AreEqual(0x12321, interactor.Control.DisassemblyView.TopAddress.Linear);
            Assert.AreEqual(0x12321, interactor.Control.DisassemblyView.SelectedAddress.Linear);
        }

        [Test]
        public void MVI_GotoAddress()
        {
            var dlg = mr.Stub<IAddressPromptDialog>();
            dlgFactory.Expect(d => d.CreateAddressPromptDialog()).Return(dlg);
            dlg.Stub(x => dlg.Address).Return(new Address(0x12345678));
            uiSvc.Expect(x => x.ShowModalDialog(
                    Arg<IAddressPromptDialog>.Is.Same(dlg)))
                .Return(DialogResult.OK);
            dlg.Expect(x => x.Dispose());
            mr.ReplayAll();

            Given_Interactor();
            interactor.ProgramImage = new LoadedImage(new Address(0x12345670), new byte[16]);
            interactor.ImageMap = new ImageMap(interactor.ProgramImage);
            interactor.Execute(ref CmdSets.GuidDecompiler, CmdIds.ViewGoToAddress);

            mr.VerifyAll();
            Assert.AreEqual(0x12345670, interactor.Control.MemoryView.TopAddress.Linear);
        }

        [Test]
        public void MVI_MarkAreaWithType()
        {
            Given_Interactor();
            Given_Image();
            interactor.SetTypeAtAddressRange(addrBase, "i32");

            ImageMapItem item;
            Assert.IsTrue(imageMap.TryFindItemExact(addrBase, out item));
            Assert.AreEqual(addrBase, item.Address);
            Assert.AreEqual("int32", item.DataType.ToString());
        }

        private void Given_Image()
        {
            image = new LoadedImage(addrBase, new byte[0x100]);
            imageMap = new ImageMap(image);
            interactor.ProgramImage = image;
            interactor.ImageMap = imageMap;
        }

        [Test]
        public void MVI_NavigateToAddress()
        {
            Given_Interactor();
            Given_Image();

            When_EnterAddressInBar("100");
            When_GoPushed();
            Assert.IsNull(control.MemoryView.SelectedAddress);
            When_EnterAddressInBar("1000");
            When_GoPushed();
            Assert.AreEqual(0x01000, control.MemoryView.SelectedAddress.Linear);
            When_EnterAddressInBar("1004");
            When_GoPushed();
            Assert.AreEqual(0x01004, control.MemoryView.SelectedAddress.Linear);
            When_EnterAddressInBar("10010");
            When_GoPushed();
            Assert.AreEqual(0x01004, control.MemoryView.SelectedAddress.Linear);
        }

        private void When_EnterAddressInBar(string address)
        {
            control.ToolBarAddressTextbox.Text = address;
        }

        private void When_GoPushed()
        {
            control.ToolBarGoButton.PerformClick();
        }
    }
}
