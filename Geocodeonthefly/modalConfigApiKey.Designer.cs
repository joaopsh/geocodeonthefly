namespace Geocodeonthefly
{
    partial class ModalConfigApiKey
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
            this.txtBoxApiKey = new System.Windows.Forms.TextBox();
            this.btnSaveApiKey = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxApiKey
            // 
            this.txtBoxApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxApiKey.Location = new System.Drawing.Point(12, 27);
            this.txtBoxApiKey.Name = "txtBoxApiKey";
            this.txtBoxApiKey.Size = new System.Drawing.Size(265, 20);
            this.txtBoxApiKey.TabIndex = 0;
            // 
            // btnSaveApiKey
            // 
            this.btnSaveApiKey.Location = new System.Drawing.Point(283, 25);
            this.btnSaveApiKey.Name = "btnSaveApiKey";
            this.btnSaveApiKey.Size = new System.Drawing.Size(75, 23);
            this.btnSaveApiKey.TabIndex = 1;
            this.btnSaveApiKey.Text = "Salvar";
            this.btnSaveApiKey.UseVisualStyleBackColor = true;
            this.btnSaveApiKey.Click += new System.EventHandler(this.btnSaveApiKey_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Google Maps Geocoding API key:";
            // 
            // ModalConfigApiKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 59);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSaveApiKey);
            this.Controls.Add(this.txtBoxApiKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ModalConfigApiKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API Key Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxApiKey;
        private System.Windows.Forms.Button btnSaveApiKey;
        private System.Windows.Forms.Label lblTitle;
    }
}