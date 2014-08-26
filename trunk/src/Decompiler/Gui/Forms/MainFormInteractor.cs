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

using Decompiler.Core.Configuration;
using Decompiler.Core;
using Decompiler.Core.Services;
using Decompiler.Core.Serialization;
using Decompiler.Gui;
using Decompiler.Loading;
using Decompiler.Gui.Windows;
using Decompiler.Gui.Windows.Controls;
using Decompiler.Gui.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decompiler.Gui.Forms
{
    /// <summary>
    /// Provices a component Container implementation, and specifically handles interactions 
    /// with the MainForm. This decouples platform-specific code from the user interaction 
    /// code. This will make it easier to port to other GUI platforms.
    /// </summary>
    public class MainFormInteractor :
        ICommandTarget,
        DecompilerHost,
        IStatusBarService
    {
        private IMainForm form;
        private IDecompilerService decompilerSvc;
        private IDecompilerShellUiService uiSvc;
        private IDiagnosticsService diagnosticsSvc;
        private ISearchResultService srSvc;
        private IWorkerDialogService workerDlgSvc;
        private IDialogFactory dlgFactory;
        private ITabControlHostService searchResultsTabControl;

        private IPhasePageInteractor currentPhase;
        private InitialPageInteractor pageInitial;
        private ILoadedPageInteractor pageLoaded;
        private IAnalyzedPageInteractor pageAnalyzed;
        private IFinalPageInteractor pageFinal;
        private Dictionary<IPhasePageInteractor, IPhasePageInteractor> nextPage;

        private MruList mru;
        private DecompilerMenus dm;
        private string projectFileName;
        private IServiceContainer sc;
        private IDecompilerConfigurationService config;
        private ICommandTarget subWindowCommandTarget;
        private static string dirSettings;

        private const int MaxMruItems = 9;

        public MainFormInteractor(IServiceProvider services)
        {
            this.dlgFactory = services.RequireService<IDialogFactory>();
            this.mru = new MruList(MaxMruItems);
            this.mru.Load(MruListFile);
            this.sc = services.RequireService<IServiceContainer>();
            this.nextPage = new Dictionary<IPhasePageInteractor, IPhasePageInteractor>();
        }

        private void CreatePhaseInteractors(IServiceFactory svcFactory)
        {
            pageInitial =  svcFactory.CreateInitialPageInteractor();
            pageLoaded = svcFactory.CreateLoadedPageInteractor();
            pageAnalyzed = new AnalyzedPageInteractorImpl(sc);
            pageFinal = new FinalPageInteractor(sc);

            nextPage[pageInitial] = pageLoaded;
            nextPage[pageLoaded] = pageAnalyzed;
            nextPage[pageAnalyzed] = pageFinal;
        }

        public virtual IDecompiler CreateDecompiler(LoaderBase ldr)
        {
            return new DecompilerDriver(ldr, this, sc);
        }

        public IMainForm LoadForm()
        {
            this.form = dlgFactory.CreateMainForm();

            dm = new DecompilerMenus(this);
            form.Menu = dm.MainMenu;
            dm.MainToolbar.Text = "";
            dm.MainToolbar.ImageList = form.ImageList;
            form.AddToolbar(dm.MainToolbar);

            var svcFactory = sc.RequireService<IServiceFactory>();
            CreateServices(svcFactory, sc, dm);
            CreatePhaseInteractors(svcFactory);

            form.Load += this.MainForm_Loaded;
            form.Closed += this.MainForm_Closed;
            form.ProcessCommandKey += this.MainForm_ProcessCommandKey;

            form.ToolBar.ItemClicked += toolBar_ItemClicked;
            //form.InitialPage.IsDirtyChanged += new EventHandler(InitialPage_IsDirtyChanged);//$REENABLE
            //MainForm.InitialPage.IsDirty = false;         //$REENABLE

            return form;
        }


        private void CreateServices(IServiceFactory svcFactory, IServiceContainer sc, DecompilerMenus dm)
        {
            config = svcFactory.CreateDecompilerConfiguration();
            sc.AddService(typeof(IDecompilerConfigurationService), config);

            sc.AddService(typeof(IStatusBarService), (IStatusBarService)this);

            diagnosticsSvc = svcFactory.CreateDiagnosticsService(form.DiagnosticsList);
            sc.AddService(typeof(IDiagnosticsService), diagnosticsSvc);

            decompilerSvc = svcFactory.CreateDecompilerService();
            sc.AddService(typeof(IDecompilerService), decompilerSvc);

            uiSvc = svcFactory.CreateShellUiService(form, dm);
            subWindowCommandTarget = uiSvc;
            sc.AddService(typeof(IDecompilerShellUiService), uiSvc);
            sc.AddService(typeof(IDecompilerUIService), uiSvc);

            var codeViewSvc = new CodeViewerServiceImpl(sc);
            sc.AddService(typeof(ICodeViewerService), codeViewSvc);

            var del = svcFactory.CreateDecompilerEventListener();
            workerDlgSvc = (IWorkerDialogService)del;
            sc.AddService(typeof(IWorkerDialogService), workerDlgSvc);
            sc.AddService(typeof(DecompilerEventListener), del);

            var abSvc = svcFactory.CreateArchiveBrowserService();
            sc.AddService(typeof(IArchiveBrowserService), abSvc);

            sc.AddService(typeof(ILowLevelViewService), svcFactory.CreateMemoryViewService());
            sc.AddService(typeof(IDisassemblyViewService), svcFactory.CreateDisassemblyViewService());

            var tlSvc = svcFactory.CreateTypeLibraryLoaderService();
            sc.AddService(typeof(ITypeLibraryLoaderService), tlSvc);

            var brSvc = svcFactory.CreateProjectBrowserService(form.ProjectBrowser);
            sc.AddService<IProjectBrowserService>(brSvc);

            var upSvc = svcFactory.CreateUiPreferencesService();
            sc.AddService<IUiPreferencesService>(upSvc);

            var fsSvc = svcFactory.CreateFileSystemService();
            sc.AddService<IFileSystemService>(fsSvc);

            this.searchResultsTabControl = svcFactory.CreateTabControlHost(form.TabControl);
            sc.AddService<ITabControlHostService>(this.searchResultsTabControl);

            srSvc = new SearchResultServiceImpl(sc, form.FindResultsList);
            sc.AddService(typeof(ISearchResultService), srSvc);
            searchResultsTabControl.Attach((IWindowPane) srSvc, form.FindResultsPage);
        }

        public virtual TextWriter CreateTextWriter(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return StreamWriter.Null;
            return new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write), new UTF8Encoding(false));
        }

        public IPhasePageInteractor CurrentPhase
        {
            get { return currentPhase; }
            set { currentPhase = value; }
        }

        [Obsolete]
        protected object GetService(Type service)
        {
            return sc.GetService(service);
        }

        [Obsolete]
        private T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public IMainForm MainForm
        {
            get { return form; }
        }

        public void OpenBinary(string file)
        {
            OpenBinary(file, delegate { pageInitial.OpenBinary(file, this); });
        }

        public void OpenBinary(string file, Action openAction)
        {
            try
            {
                diagnosticsSvc.ClearDiagnostics();
                form.CloseAllDocumentWindows();
                SwitchInteractor(InitialPageInteractor);
                openAction();
            }
            catch (Exception ex)
            {
                uiSvc.ShowError(ex, "Couldn't open file '{0}'.", file);
            }
        }

        public void OpenBinaryWithPrompt()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (form.ShowDialog(form.OpenFileDialog) == DialogResult.OK)
                {
                    mru.Use(form.OpenFileDialog.FileName);
                    OpenBinary(form.OpenFileDialog.FileName, delegate
                    {
                        pageInitial.OpenBinary(form.OpenFileDialog.FileName, this);
                    });
                }
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
                form.SetStatus("");
            }
        }

        public void AddMetadataFile()
        {
            var fileName = uiSvc.ShowOpenFileDialog(null);
            if (fileName == null)
                return;
            mru.Use(fileName);
            var loader = decompilerSvc.Decompiler.LoadMetadata(fileName);
        }

        public bool OpenBinaryAs()
        {
            IOpenAsDialog dlg = null;
            IProcessorArchitecture arch = null;
            Platform platform = null;
            try
            {
                dlg = dlgFactory.CreateOpenAsDialog();
                dlg.Services = sc;
                if (uiSvc.ShowModalDialog(dlg) != DialogResult.OK)
                    return true;

                mru.Use(dlg.FileName.Text);

                var typeName = (string)((ListOption)dlg.Architectures.SelectedValue).Value;
                Type t = Type.GetType(typeName, true);
                arch = (IProcessorArchitecture)t.GetConstructor(Type.EmptyTypes).Invoke(null);

                typeName = (string)((ListOption)dlg.Platforms.SelectedValue).Value;
                t = Type.GetType(typeName);
                if (t == null)
                    throw new TypeLoadException(string.Format("Unable to load type {0}.", typeName));
                platform = (Platform)t.GetConstructor(new Type[] { 
                        typeof(IServiceProvider),
                        typeof(IProcessorArchitecture)
                    })
                    .Invoke(new object[] { sc, arch });

                OpenBinary(dlg.FileName.Text, delegate
                {
                    pageInitial.OpenBinaryAs(
                        dlg.FileName.Text,
                        arch,
                        platform,
                        new Address(0x0000000),
                        this);
                });
            }
            catch (Exception ex)
            {
                uiSvc.ShowError(ex, "An error occurred when opening the binary.");
            }
            return true;
        }

        public InitialPageInteractor InitialPageInteractor
        {
            get { return pageInitial; }
        }

        public ILoadedPageInteractor LoadedPageInteractor
        {
            get { return pageLoaded; }
        }

        public IAnalyzedPageInteractor AnalyzedPageInteractor
        {
            get { return pageAnalyzed; }
        }

        public IFinalPageInteractor FinalPageInteractor
        {
            get { return pageFinal; }
        }

        private static string MruListFile
        {
            get { return SettingsDirectory + "\\mru.txt"; }
        }

        public void NextPhase()
        {
            try
            {
                IPhasePageInteractor next;
                if (nextPage.TryGetValue(CurrentPhase, out next))
                {
                    SwitchInteractor(next);
                }
            }
            catch (Exception ex)
            {
                uiSvc.ShowError(ex, "Unable to proceed.");
            }
            workerDlgSvc.FinishBackgroundWork();
        }

        public void FinishDecompilation()
        {
            try
            {
                IPhasePageInteractor prev = CurrentPhase;
                workerDlgSvc.StartBackgroundWork("Finishing decompilation.", delegate()
                {
                    IPhasePageInteractor next;
                    while (nextPage.TryGetValue(prev, out next))
                    {
                        next.PerformWork(workerDlgSvc);
                        prev = next;
                    }
                });
                prev.EnterPage();
            }
            catch (Exception ex)
            {
                uiSvc.ShowError(ex, "An error occurred while finishing decompilation.");
            }
            workerDlgSvc.FinishBackgroundWork();
        }

        public void LayoutMdi(DocumentWindowLayout layout)
        {
            form.LayoutMdi(layout);
        }

        public void ShowAboutBox()
        {
            using (AboutDialog dlg = new AboutDialog())
            {
                uiSvc.ShowModalDialog(dlg);
            }
        }

        public string ProjectFileName
        {
            get { return projectFileName; }
            set { projectFileName = value; }
        }

        public void EditFind()
        {
            using (ISearchDialog dlg = dlgFactory.CreateSearchDialog())
            {
                if (uiSvc.ShowModalDialog(dlg) == DialogResult.OK)
                {
                    var re = Scanning.Dfa.Automaton.CreateFromPattern(dlg.Patterns.Text);
                    var program = this.decompilerSvc.Decompiler.Program;
                    var hits = re.GetMatches(program.Image.Bytes, 0);
                    var srSvc = GetService<ISearchResultService>();
                    var baseLin = program.Image.BaseAddress.Linear;
                    srSvc.ShowSearchResults(new AddressSearchResult(
                        this.sc,
                        program,
                        hits.Select(h => (uint) (baseLin + h))));
                }
            }
        }

        public void FindProcedures(ISearchResultService svc)
        {
            svc.ShowSearchResults(new ProcedureSearchResult(this.sc, this.decompilerSvc.Decompiler.Program.Procedures));
        }

        public void ViewDisassemblyWindow()
        {
            var dasmService = GetService<IDisassemblyViewService>();
            dasmService.ShowWindow();
        }

        public void ViewMemoryWindow()
        {
            var memService = GetService<ILowLevelViewService>();
            memService.ViewImage(this.decompilerSvc.Decompiler.Program);
            memService.ShowWindow();
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(this.ProjectFileName))
            {
                string newName = PromptForFilename(
                    Path.ChangeExtension(
                        decompilerSvc.Decompiler.Project.InputFiles[0].Filename,
                        Project_v1.FileExtension));
                if (newName == null)
                    return;
                ProjectFileName = newName;
                mru.Use(newName);
            }

            using (TextWriter sw = CreateTextWriter(ProjectFileName))
            {
                //$REFACTOR: rule of demeter, push this into a Save() method.
                var sp = decompilerSvc.Decompiler.Project.Save();
                new ProjectSerializer().Save(sp, sw);
            }
        }

        protected virtual string PromptForFilename(string suggestedName)
        {
            form.SaveFileDialog.FileName = suggestedName;
            if (DialogResult.OK != form.ShowDialog(form.SaveFileDialog))
                return null;
            else
                return form.SaveFileDialog.FileName;
        }

        private static string SettingsDirectory
        {
            get
            {
                if (dirSettings == null)
                {
                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\jkl\\grovel";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    dirSettings = dir;
                }
                return dirSettings;
            }
        }

        public void SwitchInteractor(IPhasePageInteractor interactor)
        {
            if (interactor == CurrentPhase)
                return;

            if (CurrentPhase != null)
            {
                if (!CurrentPhase.LeavePage())
                    return;
            }
            CurrentPhase = interactor;
            workerDlgSvc.StartBackgroundWork("Entering next phase...", delegate()
            {
                interactor.PerformWork(workerDlgSvc);
            });
            interactor.EnterPage();
        }

        public void UpdateWindowTitle()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(decompilerSvc.ProjectName))
            {
                sb.Append(decompilerSvc.ProjectName);
                //$REFACTOR: dirtiness of project is not limited to first page.
                //if (MainForm.InitialPage.IsDirty)
                //    sb.Append('*');
                sb.Append(" - ");
            }
            sb.Append("Decompiler");
            MainForm.TitleText = sb.ToString();
        }

        #region ICommandTarget members

        public bool QueryStatus(CommandID cmdId, CommandStatus cmdStatus, CommandText cmdText)
        {
            if (searchResultsTabControl.QueryStatus(cmdId, cmdStatus, cmdText))
                return true;
            if (subWindowCommandTarget.QueryStatus(cmdId, cmdStatus, cmdText))
                return true;
            if (currentPhase != null && currentPhase.QueryStatus(cmdId, cmdStatus, cmdText))
                return true;
            if (cmdId.Guid == CmdSets.GuidDecompiler)
            {
                if (QueryMruItem(cmdId.ID, cmdStatus, cmdText))
                    return true;

                switch (cmdId.ID)
                {
                case CmdIds.FileOpen:
                case CmdIds.FileExit:
                case CmdIds.FileSave:
                case CmdIds.FileOpenAs:
                case CmdIds.WindowsCascade: 
                case CmdIds.WindowsTileVertical:
                case CmdIds.WindowsTileHorizontal:
                case CmdIds.WindowsCloseAll: 
                case CmdIds.HelpAbout: 
                    cmdStatus.Status = MenuStatus.Enabled | MenuStatus.Visible;
                    return true;
                case CmdIds.FileMru:
                    cmdStatus.Status = MenuStatus.Visible;
                    return true;
                case CmdIds.ActionNextPhase:
                    cmdStatus.Status = currentPhase.CanAdvance
                        ? MenuStatus.Enabled | MenuStatus.Visible
                        : MenuStatus.Visible;
                    return true;
                case CmdIds.FileAddBinary:
                case CmdIds.FileAddMetadata:
                case CmdIds.ViewFindAllProcedures:
                case CmdIds.EditFind:
                    cmdStatus.Status = IsDecompilerLoaded
                        ? MenuStatus.Enabled | MenuStatus.Visible
                        : MenuStatus.Visible;
                    return true;
                }
            }
            return false;
        }

        private bool QueryMruItem(int cmdId, CommandStatus cmdStatus, CommandText cmdText)
        {
            int iMru = cmdId - CmdIds.FileMru;
            if (0 <= iMru && iMru < mru.Items.Count)
            {
                cmdStatus.Status = MenuStatus.Visible | MenuStatus.Enabled;
                cmdText.Text = string.Format("&{0} {1}", iMru+1, mru.Items[iMru]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Dispatches menu commands.
        /// </summary>
        /// <param name="cmdSet"></param>
        /// <param name="cmdId"></param>
        /// <returns></returns>
        public bool Execute(CommandID cmdId)
        {
            if (searchResultsTabControl.Execute(cmdId))
                return true;
            if (subWindowCommandTarget.Execute(cmdId))
                return true;
            if (currentPhase != null && currentPhase.Execute(cmdId))
                return true;
            if (cmdId.Guid == CmdSets.GuidDecompiler)
            {
                if (ExecuteMruFile(cmdId.ID))
                    return false;

                switch (cmdId.ID)
                {
                case CmdIds.FileOpen: OpenBinaryWithPrompt(); return true;
                case CmdIds.FileOpenAs: return OpenBinaryAs();
                case CmdIds.FileSave: Save(); return true;
                case CmdIds.FileAddMetadata: AddMetadataFile(); return true;
                case CmdIds.FileExit: form.Close(); return true;

                case CmdIds.ActionNextPhase: NextPhase(); return true;
                case CmdIds.ActionFinishDecompilation: FinishDecompilation(); return true;

                case CmdIds.EditFind: EditFind(); return true;

                case CmdIds.ViewDisassembly: ViewDisassemblyWindow(); return true;
                case CmdIds.ViewMemory: ViewMemoryWindow(); return true;
                case CmdIds.ViewFindAllProcedures: FindProcedures(srSvc); return true;

                case CmdIds.WindowsCascade: LayoutMdi(DocumentWindowLayout.None); return true;
                case CmdIds.WindowsTileVertical: LayoutMdi(DocumentWindowLayout.TiledVertical); return true;
                case CmdIds.WindowsTileHorizontal: LayoutMdi(DocumentWindowLayout.TiledHorizontal); return true;
                case CmdIds.WindowsCloseAll: form.CloseAllDocumentWindows(); return true;

                case CmdIds.HelpAbout: ShowAboutBox(); return true;
                }
            }
            return false;
        }

        private bool ExecuteMruFile(int cmdId)
        {
            int iMru = cmdId - CmdIds.FileMru;
            if (0 <= iMru && iMru < mru.Items.Count)
            {
                string file = (string)mru.Items[iMru];
                OpenBinary(file, delegate
                {
                    pageInitial.OpenBinary(file, this);
                });
                mru.Use(file);
                return true;
            }
            return false;
        }

        private bool IsDecompilerLoaded
        {
            get
            {
                if (decompilerSvc.Decompiler == null)
                    return false;
                return decompilerSvc.Decompiler.Program != null;
            }
        }
        #endregion


        #region IStatusBarService Members ////////////////////////////////////

        public void SetText(string text)
        {
            form.StatusStrip.Items[0].Text = text;
        }

        #endregion


        #region DecompilerHost Members //////////////////////////////////

        public IDecompilerConfigurationService Configuration
        {
            get { return config; }
        }

        public TextWriter CreateDecompiledCodeWriter(string fileName)
        {
            return new StreamWriter(fileName, false, new UTF8Encoding(false));
        }

        public void WriteDisassembly(Action<TextWriter> writer)
        {
            foreach (var inputFile in decompilerSvc.Decompiler.Project.InputFiles.OfType<InputFile>())
            {
                using (TextWriter output = CreateTextWriter(inputFile.DisassemblyFilename))
                {
                    writer(output);
                }
            }
        }

        public void WriteIntermediateCode(Action<TextWriter> writer)
        {
            foreach (var inputFile in decompilerSvc.Decompiler.Project.InputFiles.OfType<InputFile>())
            {
                using (TextWriter output = CreateTextWriter(inputFile.IntermediateFilename))
                {
                    writer(output);
                }
            }
        }

        public void WriteTypes(Action<TextWriter> writer)
        {
            foreach (var inputFile in decompilerSvc.Decompiler.Project.InputFiles.OfType<InputFile>())
            {
                using (TextWriter output = CreateTextWriter(inputFile.TypesFilename))
                {
                    writer(output);
                }
            }
        }

        public void WriteDecompiledCode(Action<TextWriter> writer)
        {
            foreach (var inputFile in decompilerSvc.Decompiler.Project.InputFiles.OfType<InputFile>())
            {
                using (TextWriter output = CreateTextWriter(inputFile.OutputFilename))
                {
                    writer(output);
                }
            }
        }

        #endregion ////////////////////////////////////////////////////


        // Event handlers //////////////////////////////

        private void miFileExit_Click(object sender, System.EventArgs e)
        {
            form.Close();
        }

        private void MainForm_Loaded(object sender, System.EventArgs e)
        {
            var uiPrefsSvc = sc.RequireService<IUiPreferencesService>();
            // It's ok if we can't load settings, just proceed with defaults.
            try
            {
                uiPrefsSvc.Load();
                if (uiPrefsSvc.WindowSize != new System.Drawing.Size())
                    form.Size = uiPrefsSvc.WindowSize;
                form.WindowState = uiPrefsSvc.WindowState;
            }
            catch { };
            SwitchInteractor(pageInitial);
        }

        private void MainForm_Closed(object sender, System.EventArgs e)
        {
            var uiPrefsSvc = sc.RequireService<IUiPreferencesService>();
            // It's OK if we can't save settings, just discard them.
            try
            {
                uiPrefsSvc.WindowSize = form.Size;
                uiPrefsSvc.WindowState = form.WindowState;
                uiPrefsSvc.Save();
                mru.Save(MruListFile);
            }
            catch { }
        }

        private void MainForm_ProcessCommandKey(object sender, KeyEventArgs e)
        {
            dm.ProcessKey(uiSvc, e);
        }


        private void statusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
        {

        }

        private void txtLog_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void toolBar_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            MenuCommand cmd = e.ClickedItem.Tag as MenuCommand;
            if (cmd == null) throw new NotImplementedException("Button not hooked up.");
            Execute(cmd.CommandID);
        }

        public void OnBrowserTreeItemSelected(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard ||
                e.Action == TreeViewAction.ByMouse)
            {
                throw new NotImplementedException();
            }
        }

        private void InitialPage_IsDirtyChanged(object sender, EventArgs e)
        {
            UpdateWindowTitle();
        }

        public virtual void Run()
        {
            Application.Run((Form)LoadForm());
        }
    }
}
