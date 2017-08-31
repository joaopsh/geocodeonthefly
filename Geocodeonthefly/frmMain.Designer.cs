namespace Geocodeonthefly
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
            this.tboxFileLocation = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tboxFileLocation
            // 
            this.tboxFileLocation.Enabled = false;
            this.tboxFileLocation.Location = new System.Drawing.Point(12, 15);
            this.tboxFileLocation.Name = "tboxFileLocation";
            this.tboxFileLocation.Size = new System.Drawing.Size(306, 20);
            this.tboxFileLocation.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(322, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(97, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Select file";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // openFileDialogCsv
            // 
            this.openFileDialogCsv.FileName = "openFileDialog1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 51);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tboxFileLocation);
            this.Name = "frmMain";
            this.Text = "Geocodeonthefly";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxFileLocation;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.OpenFileDialog openFileDialogCsv;
    }
}

