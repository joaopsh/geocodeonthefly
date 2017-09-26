﻿namespace Geocodeonthefly
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tboxSourceFileLocation = new System.Windows.Forms.TextBox();
            this.btnFindSourceFile = new System.Windows.Forms.Button();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tboxDestinationFileLocation = new System.Windows.Forms.TextBox();
            this.btnFindDestinationLocation = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.saveFileDialogDestination = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxSourceFileLocation
            // 
            this.tboxSourceFileLocation.Enabled = false;
            this.tboxSourceFileLocation.Location = new System.Drawing.Point(9, 14);
            this.tboxSourceFileLocation.Name = "tboxSourceFileLocation";
            this.tboxSourceFileLocation.Size = new System.Drawing.Size(306, 20);
            this.tboxSourceFileLocation.TabIndex = 0;
            // 
            // btnFindSourceFile
            // 
            this.btnFindSourceFile.Location = new System.Drawing.Point(319, 12);
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
            this.tboxDestinationFileLocation.Location = new System.Drawing.Point(9, 40);
            this.tboxDestinationFileLocation.Name = "tboxDestinationFileLocation";
            this.tboxDestinationFileLocation.Size = new System.Drawing.Size(306, 20);
            this.tboxDestinationFileLocation.TabIndex = 2;
            // 
            // btnFindDestinationLocation
            // 
            this.btnFindDestinationLocation.Location = new System.Drawing.Point(321, 38);
            this.btnFindDestinationLocation.Name = "btnFindDestinationLocation";
            this.btnFindDestinationLocation.Size = new System.Drawing.Size(95, 23);
            this.btnFindDestinationLocation.TabIndex = 3;
            this.btnFindDestinationLocation.Text = "Select output";
            this.btnFindDestinationLocation.UseVisualStyleBackColor = true;
            this.btnFindDestinationLocation.Click += new System.EventHandler(this.btnFindDestinationLocation_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(9, 66);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 97);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnFindDestinationLocation);
            this.Controls.Add(this.tboxDestinationFileLocation);
            this.Controls.Add(this.btnFindSourceFile);
            this.Controls.Add(this.tboxSourceFileLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Geocodeonthefly";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
    }
}

