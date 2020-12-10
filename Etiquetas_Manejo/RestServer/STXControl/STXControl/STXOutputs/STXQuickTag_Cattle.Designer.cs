namespace STXControl.STXOutputs
{
    partial class STXQuickTag_Cattle
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbBarcodes = new System.Windows.Forms.GroupBox();
            this.gbReapeat = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.gbTagFormat = new System.Windows.Forms.GroupBox();
            this.rbMMTVT = new System.Windows.Forms.RadioButton();
            this.rbBT = new System.Windows.Forms.RadioButton();
            this.rbTST = new System.Windows.Forms.RadioButton();
            this.rbMMTBT = new System.Windows.Forms.RadioButton();
            this.gbReapeat.SuspendLayout();
            this.gbTagFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBarcodes
            // 
            this.gbBarcodes.Location = new System.Drawing.Point(3, 183);
            this.gbBarcodes.Name = "gbBarcodes";
            this.gbBarcodes.Size = new System.Drawing.Size(200, 100);
            this.gbBarcodes.TabIndex = 0;
            this.gbBarcodes.TabStop = false;
            this.gbBarcodes.Text = "BARCODES";
            // 
            // gbReapeat
            // 
            this.gbReapeat.Controls.Add(this.rb2);
            this.gbReapeat.Controls.Add(this.rb4);
            this.gbReapeat.Location = new System.Drawing.Point(3, 123);
            this.gbReapeat.Name = "gbReapeat";
            this.gbReapeat.Size = new System.Drawing.Size(200, 55);
            this.gbReapeat.TabIndex = 0;
            this.gbReapeat.TabStop = false;
            this.gbReapeat.Text = "Reapeat";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(6, 19);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(42, 24);
            this.rb2.TabIndex = 0;
            this.rb2.Text = "x2";
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb4
            // 
            this.rb4.Location = new System.Drawing.Point(54, 19);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(50, 24);
            this.rb4.TabIndex = 0;
            this.rb4.Text = "x4";
            this.rb4.CheckedChanged += new System.EventHandler(this.rb4_CheckedChanged);
            // 
            // gbTagFormat
            // 
            this.gbTagFormat.Controls.Add(this.rbMMTVT);
            this.gbTagFormat.Controls.Add(this.rbBT);
            this.gbTagFormat.Controls.Add(this.rbTST);
            this.gbTagFormat.Controls.Add(this.rbMMTBT);
            this.gbTagFormat.Location = new System.Drawing.Point(3, 0);
            this.gbTagFormat.Name = "gbTagFormat";
            this.gbTagFormat.Size = new System.Drawing.Size(200, 120);
            this.gbTagFormat.TabIndex = 0;
            this.gbTagFormat.TabStop = false;
            this.gbTagFormat.Text = "Tag Format";
            // 
            // rbMMTVT
            // 
            this.rbMMTVT.AutoSize = true;
            this.rbMMTVT.Checked = true;
            this.rbMMTVT.Location = new System.Drawing.Point(11, 19);
            this.rbMMTVT.Name = "rbMMTVT";
            this.rbMMTVT.Size = new System.Drawing.Size(178, 17);
            this.rbMMTVT.TabIndex = 0;
            this.rbMMTVT.TabStop = true;
            this.rbMMTVT.Text = "Maxi, Midi or TypiFix Visual Tags";
            this.rbMMTVT.UseVisualStyleBackColor = true;
            this.rbMMTVT.CheckedChanged += new System.EventHandler(this.rbMMTVT_CheckedChanged);
            // 
            // rbBT
            // 
            this.rbBT.Location = new System.Drawing.Point(11, 42);
            this.rbBT.Name = "rbBT";
            this.rbBT.Size = new System.Drawing.Size(78, 17);
            this.rbBT.TabIndex = 0;
            this.rbBT.Text = "Button Tag";
            this.rbBT.CheckedChanged += new System.EventHandler(this.rbBT_CheckedChanged);
            // 
            // rbTST
            // 
            this.rbTST.Location = new System.Drawing.Point(11, 65);
            this.rbTST.Name = "rbTST";
            this.rbTST.Size = new System.Drawing.Size(124, 17);
            this.rbTST.TabIndex = 0;
            this.rbTST.Text = "Tissue Sampling Tag";
            this.rbTST.CheckedChanged += new System.EventHandler(this.rbTST_CheckedChanged);
            // 
            // rbMMTBT
            // 
            this.rbMMTBT.Location = new System.Drawing.Point(11, 88);
            this.rbMMTBT.Name = "rbMMTBT";
            this.rbMMTBT.Size = new System.Drawing.Size(168, 24);
            this.rbMMTBT.TabIndex = 0;
            this.rbMMTBT.Text = "Maxi or Midi Tag + Button Tag";
            this.rbMMTBT.CheckedChanged += new System.EventHandler(this.rbMMTBT_CheckedChanged);
            // 
            // STXQuickTag_Cattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTagFormat);
            this.Controls.Add(this.gbBarcodes);
            this.Controls.Add(this.gbReapeat);
            this.Name = "STXQuickTag_Cattle";
            this.Size = new System.Drawing.Size(210, 290);
            this.gbReapeat.ResumeLayout(false);
            this.gbTagFormat.ResumeLayout(false);
            this.gbTagFormat.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.GroupBox gbBarcodes;
        private System.Windows.Forms.GroupBox gbReapeat;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.GroupBox gbTagFormat;
        private System.Windows.Forms.RadioButton rbMMTBT;
        private System.Windows.Forms.RadioButton rbTST;
        private System.Windows.Forms.RadioButton rbBT;
        private System.Windows.Forms.RadioButton rbMMTVT;
    }
}
