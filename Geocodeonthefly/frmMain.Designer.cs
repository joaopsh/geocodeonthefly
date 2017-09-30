namespace Geocodeonthefly
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tboxSourceFileLocation = new System.Windows.Forms.TextBox();
            this.btnFindSourceFile = new System.Windows.Forms.Button();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tboxDestinationFileLocation = new System.Windows.Forms.TextBox();
            this.btnFindDestinationLocation = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.saveFileDialogDestination = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialogExcelModel = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tboxSourceFileLocation
            // 
            this.tboxSourceFileLocation.Enabled = false;
            this.tboxSourceFileLocation.Location = new System.Drawing.Point(12, 36);
            this.tboxSourceFileLocation.Name = "tboxSourceFileLocation";
            this.tboxSourceFileLocation.Size = new System.Drawing.Size(306, 20);
            this.tboxSourceFileLocation.TabIndex = 0;
            // 
            // btnFindSourceFile
            // 
            this.btnFindSourceFile.Location = new System.Drawing.Point(322, 34);
            this.btnFindSourceFile.Name = "btnFindSourceFile";
            this.btnFindSourceFile.Size = new System.Drawing.Size(97, 23);
            this.btnFindSourceFile.TabIndex = 1;
            this.btnFindSourceFile.Text = "Select file";
            this.btnFindSourceFile.UseVisualStyleBackColor = true;
            this.btnFindSourceFile.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // openFileDialogCsv
            // 
            this.openFileDialogCsv.Filter = "Excel Files|*.xlsx;";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tboxDestinationFileLocation
            // 
            this.tboxDestinationFileLocation.Enabled = false;
            this.tboxDestinationFileLocation.Location = new System.Drawing.Point(12, 62);
            this.tboxDestinationFileLocation.Name = "tboxDestinationFileLocation";
            this.tboxDestinationFileLocation.Size = new System.Drawing.Size(306, 20);
            this.tboxDestinationFileLocation.TabIndex = 2;
            // 
            // btnFindDestinationLocation
            // 
            this.btnFindDestinationLocation.Location = new System.Drawing.Point(324, 60);
            this.btnFindDestinationLocation.Name = "btnFindDestinationLocation";
            this.btnFindDestinationLocation.Size = new System.Drawing.Size(95, 23);
            this.btnFindDestinationLocation.TabIndex = 3;
            this.btnFindDestinationLocation.Text = "Select output";
            this.btnFindDestinationLocation.UseVisualStyleBackColor = true;
            this.btnFindDestinationLocation.Click += new System.EventHandler(this.btnFindDestinationLocation_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 88);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(407, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // saveFileDialogDestination
            // 
            this.saveFileDialogDestination.Filter = "Excel Files|*.xlsx;";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(431, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveModelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.toolsToolStripMenuItem.Text = "File";
            // 
            // saveModelToolStripMenuItem
            // 
            this.saveModelToolStripMenuItem.Name = "saveModelToolStripMenuItem";
            this.saveModelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveModelToolStripMenuItem.Text = "Save model";
            this.saveModelToolStripMenuItem.Click += new System.EventHandler(this.saveModelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIKeyToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configs";
            // 
            // aPIKeyToolStripMenuItem
            // 
            this.aPIKeyToolStripMenuItem.Name = "aPIKeyToolStripMenuItem";
            this.aPIKeyToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aPIKeyToolStripMenuItem.Text = "API Key";
            this.aPIKeyToolStripMenuItem.Click += new System.EventHandler(this.aPIKeyToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 121);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnFindDestinationLocation);
            this.Controls.Add(this.tboxDestinationFileLocation);
            this.Controls.Add(this.btnFindSourceFile);
            this.Controls.Add(this.tboxSourceFileLocation);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geocodeonthefly";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxSourceFileLocation;
        private System.Windows.Forms.Button btnFindSourceFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogCsv;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox tboxDestinationFileLocation;
        private System.Windows.Forms.Button btnFindDestinationLocation;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDestination;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogExcelModel;
    }
}

