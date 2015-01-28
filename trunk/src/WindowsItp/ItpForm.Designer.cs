﻿namespace Decompiler.WindowsItp
{
    partial class ItpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disassemblyControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ollyScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.dialogsToolStripMenuItem,
            this.loadingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryControlToolStripMenuItem,
            this.rTFToolStripMenuItem,
            this.webControlToolStripMenuItem,
            this.treeViewToolStripMenuItem,
            this.disassemblyControlToolStripMenuItem});
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.controlsToolStripMenuItem.Text = "&Controls";
            // 
            // memoryControlToolStripMenuItem
            // 
            this.memoryControlToolStripMenuItem.Name = "memoryControlToolStripMenuItem";
            this.memoryControlToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.memoryControlToolStripMenuItem.Text = "&Memory Control";
            this.memoryControlToolStripMenuItem.Click += new System.EventHandler(this.memoryControlToolStripMenuItem_Click);
            // 
            // rTFToolStripMenuItem
            // 
            this.rTFToolStripMenuItem.Name = "rTFToolStripMenuItem";
            this.rTFToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rTFToolStripMenuItem.Text = "&RTF ";
            this.rTFToolStripMenuItem.Click += new System.EventHandler(this.rtfToolStripMenuItem_Click);
            // 
            // webControlToolStripMenuItem
            // 
            this.webControlToolStripMenuItem.Name = "webControlToolStripMenuItem";
            this.webControlToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.webControlToolStripMenuItem.Text = "&Web Control";
            this.webControlToolStripMenuItem.Click += new System.EventHandler(this.webControlToolStripMenuItem_Click);
            // 
            // treeViewToolStripMenuItem
            // 
            this.treeViewToolStripMenuItem.Name = "treeViewToolStripMenuItem";
            this.treeViewToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.treeViewToolStripMenuItem.Text = "&Tree View";
            this.treeViewToolStripMenuItem.Click += new System.EventHandler(this.treeViewToolStripMenuItem_Click);
            // 
            // disassemblyControlToolStripMenuItem
            // 
            this.disassemblyControlToolStripMenuItem.Name = "disassemblyControlToolStripMenuItem";
            this.disassemblyControlToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.disassemblyControlToolStripMenuItem.Text = "&Disassembly Control";
            this.disassemblyControlToolStripMenuItem.Click += new System.EventHandler(this.disassemblyControlToolStripMenuItem_Click);
            // 
            // dialogsToolStripMenuItem
            // 
            this.dialogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.projectBrowserToolStripMenuItem,
            this.activationToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.dialogsToolStripMenuItem.Name = "dialogsToolStripMenuItem";
            this.dialogsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.dialogsToolStripMenuItem.Text = "&Dialogs";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.searchToolStripMenuItem.Text = "&Search...";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // projectBrowserToolStripMenuItem
            // 
            this.projectBrowserToolStripMenuItem.Name = "projectBrowserToolStripMenuItem";
            this.projectBrowserToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.projectBrowserToolStripMenuItem.Text = "&Project Browser...";
            this.projectBrowserToolStripMenuItem.Click += new System.EventHandler(this.projectBrowserToolStripMenuItem_Click);
            // 
            // activationToolStripMenuItem
            // 
            this.activationToolStripMenuItem.Name = "activationToolStripMenuItem";
            this.activationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.activationToolStripMenuItem.Text = "&Activation...";
            this.activationToolStripMenuItem.Click += new System.EventHandler(this.activationToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // loadingToolStripMenuItem
            // 
            this.loadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulatorToolStripMenuItem,
            this.ollyScriptToolStripMenuItem});
            this.loadingToolStripMenuItem.Name = "loadingToolStripMenuItem";
            this.loadingToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.loadingToolStripMenuItem.Text = "&Loading";
            // 
            // emulatorToolStripMenuItem
            // 
            this.emulatorToolStripMenuItem.Name = "emulatorToolStripMenuItem";
            this.emulatorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emulatorToolStripMenuItem.Text = "X86 &Emulator";
            this.emulatorToolStripMenuItem.Click += new System.EventHandler(this.emulatorToolStripMenuItem_Click);
            // 
            // ollyScriptToolStripMenuItem
            // 
            this.ollyScriptToolStripMenuItem.Name = "ollyScriptToolStripMenuItem";
            this.ollyScriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ollyScriptToolStripMenuItem.Text = "&OllyScript";
            this.ollyScriptToolStripMenuItem.Click += new System.EventHandler(this.ollyScriptToolStripMenuItem_Click);
            // 
            // ItpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ItpForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disassemblyControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ollyScriptToolStripMenuItem;
    }
}

