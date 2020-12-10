namespace STXControl
{
    partial class STXOutputQuickTag
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
            this.gbSTXOutput = new System.Windows.Forms.GroupBox();
            this.pSpecies = new System.Windows.Forms.Panel();
            this.lblSTXOutput = new System.Windows.Forms.Label();
            this.btnAppendSTX = new System.Windows.Forms.Button();
            this.btnExportSTX = new System.Windows.Forms.Button();
            this.dgvSTX = new System.Windows.Forms.DataGridView();
            this.sfdCreate = new System.Windows.Forms.SaveFileDialog();
            this.sfdAppend = new System.Windows.Forms.SaveFileDialog();
            this.gbSTXOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTX)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSTXOutput
            // 
            this.gbSTXOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSTXOutput.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbSTXOutput.Controls.Add(this.pSpecies);
            this.gbSTXOutput.Controls.Add(this.lblSTXOutput);
            this.gbSTXOutput.Controls.Add(this.btnAppendSTX);
            this.gbSTXOutput.Controls.Add(this.btnExportSTX);
            this.gbSTXOutput.Controls.Add(this.dgvSTX);
            this.gbSTXOutput.Location = new System.Drawing.Point(0, 0);
            this.gbSTXOutput.Name = "gbSTXOutput";
            this.gbSTXOutput.Size = new System.Drawing.Size(600, 484);
            this.gbSTXOutput.TabIndex = 1;
            this.gbSTXOutput.TabStop = false;
            // 
            // pSpecies
            // 
            this.pSpecies.Location = new System.Drawing.Point(19, 50);
            this.pSpecies.Name = "pSpecies";
            this.pSpecies.Size = new System.Drawing.Size(210, 330);
            this.pSpecies.TabIndex = 6;
            // 
            // lblSTXOutput
            // 
            this.lblSTXOutput.AutoSize = true;
            this.lblSTXOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTXOutput.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSTXOutput.Location = new System.Drawing.Point(14, 22);
            this.lblSTXOutput.Name = "lblSTXOutput";
            this.lblSTXOutput.Size = new System.Drawing.Size(117, 25);
            this.lblSTXOutput.TabIndex = 5;
            this.lblSTXOutput.Text = "STX Output";
            // 
            // btnAppendSTX
            // 
            this.btnAppendSTX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAppendSTX.Enabled = false;
            this.btnAppendSTX.Location = new System.Drawing.Point(19, 448);
            this.btnAppendSTX.Name = "btnAppendSTX";
            this.btnAppendSTX.Size = new System.Drawing.Size(206, 23);
            this.btnAppendSTX.TabIndex = 4;
            this.btnAppendSTX.Text = "APPEND TO CURRENT STX";
            this.btnAppendSTX.UseVisualStyleBackColor = true;
            this.btnAppendSTX.Click += new System.EventHandler(this.btnAppendSTX_Click);
            // 
            // btnExportSTX
            // 
            this.btnExportSTX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportSTX.Enabled = false;
            this.btnExportSTX.Location = new System.Drawing.Point(19, 419);
            this.btnExportSTX.Name = "btnExportSTX";
            this.btnExportSTX.Size = new System.Drawing.Size(206, 23);
            this.btnExportSTX.TabIndex = 3;
            this.btnExportSTX.Text = "CREATE NEW STX";
            this.btnExportSTX.UseVisualStyleBackColor = true;
            this.btnExportSTX.Click += new System.EventHandler(this.btnExportSTX_Click);
            // 
            // dgvSTX
            // 
            this.dgvSTX.AllowUserToAddRows = false;
            this.dgvSTX.AllowUserToDeleteRows = false;
            this.dgvSTX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSTX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSTX.Location = new System.Drawing.Point(239, 51);
            this.dgvSTX.Name = "dgvSTX";
            this.dgvSTX.ReadOnly = true;
            this.dgvSTX.Size = new System.Drawing.Size(355, 420);
            this.dgvSTX.TabIndex = 5;
            // 
            // sfdCreate
            // 
            this.sfdCreate.DefaultExt = "txt";
            this.sfdCreate.FileName = "newjob.txt";
            this.sfdCreate.Filter = "Text|*.txt";
            this.sfdCreate.Title = "Create/Save STX file";
            // 
            // sfdAppend
            // 
            this.sfdAppend.CheckFileExists = true;
            this.sfdAppend.DefaultExt = "txt";
            this.sfdAppend.FileName = "newjob.txt";
            this.sfdAppend.Filter = "Text|*.txt";
            this.sfdAppend.OverwritePrompt = false;
            this.sfdAppend.Title = "Append to current STX";
            // 
            // STXOutputQuickTag
            // 
            this.Controls.Add(this.gbSTXOutput);
            this.Name = "STXOutputQuickTag";
            this.Size = new System.Drawing.Size(600, 484);
            this.gbSTXOutput.ResumeLayout(false);
            this.gbSTXOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
         

        private System.Windows.Forms.GroupBox gbSTXOutput;
        private System.Windows.Forms.DataGridView dgvSTX;
        private System.Windows.Forms.Label lblSTXOutput;
        private System.Windows.Forms.Button btnAppendSTX;
        private System.Windows.Forms.Button btnExportSTX;
        private System.Windows.Forms.SaveFileDialog sfdCreate;
        private System.Windows.Forms.SaveFileDialog sfdAppend;
        private System.Windows.Forms.Panel pSpecies;

    }
}
