#region License
/* 
 * Copyright (C) 1999-2021 John Källén.
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

using Reko.Gui;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reko.Environments.AmigaOS.Design
{
    public class AmigaOSPropertiesInteractor : IWindowPane
    {
        private AmigaOSPlatform platform;

        public AmigaOSPropertiesInteractor(AmigaOSPlatform platform)
        {
            this.platform = platform;
        }

        public AmigaOSProperties Control { get; private set; }
        public IWindowFrame Frame { get; set; }
        public IServiceProvider Services { get; private set; }

        public void SetSite(IServiceProvider sp)
        {
            this.Services = sp;
        }

        /// <summary>
        /// Creates the user interface control and connects all event handlers.
        /// </summary>
        /// <returns></returns>
        public object CreateControl()
        {
            Control = new AmigaOSProperties();
            var mapKickstartToListOfLibraries = platform.MapKickstartToListOfLibraries;
            if (mapKickstartToListOfLibraries != null)
            {
                this.Control.KickstartVersionList.DataSource =
                    mapKickstartToListOfLibraries
                    .Select(kv => new ListOption(
                        string.Format("Kickstart {0}", kv.Key),
                        kv.Value))
                    .ToList();
                this.Control.KickstartVersionList.SelectedIndex = 0;
            }
            PopulateLoadedLibraryList();

            this.Control.KickstartVersionList.SelectedIndexChanged += KickstartVersionList_SelectedIndexChanged;
            this.Control.ImportButton.Click += ImportButton_Click;
            return Control;
        }

        public void Close()
        {
            if (Control != null)
            {
                Control.Dispose();
                Control = null;
            }
        }

        private void KickstartVersionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateLoadedLibraryList();
        }
        private void ImportButton_Click(object sender, EventArgs e)
        {
            platform.SetKickstartVersion(33 + this.Control.KickstartVersionList.SelectedIndex);
        }
        private void PopulateLoadedLibraryList()
        {
            var listOption = (ListOption)Control.KickstartVersionList.SelectedValue;
            if (listOption != null)
            {
                var libList = (List<object>)listOption.Value;
                Control.LoadedLibraryList.Items.Clear();
                foreach (object lib in libList)
                {
                    Control.LoadedLibraryList.Items.Add(lib.ToString()); //$TODO: mark available library definition files ?
                }
            }
        }
    }
}
