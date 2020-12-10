namespace STXControl
{
    partial class STXControl_Sheep
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
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnProduced = new System.Windows.Forms.Button();
            this.txtNoTags = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtTagType = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDispatch = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblTagType = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.lblNoTags = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.gbSTXOutput = new System.Windows.Forms.GroupBox();
            this.lblSTXOutput = new System.Windows.Forms.Label();
            this.btnAppendSTX = new System.Windows.Forms.Button();
            this.btnExportSTX = new System.Windows.Forms.Button();
            this.dgvSTX = new System.Windows.Forms.DataGridView();
            this.gbTagFormat = new System.Windows.Forms.GroupBox();
            this.rbTFP = new System.Windows.Forms.RadioButton();
            this.rbET = new System.Windows.Forms.RadioButton();
            this.rbTFS = new System.Windows.Forms.RadioButton();
            this.rbBT = new System.Windows.Forms.RadioButton();
            this.rbEDM = new System.Windows.Forms.RadioButton();
            this.sfdCreate = new System.Windows.Forms.SaveFileDialog();
            this.sfdAppend = new System.Windows.Forms.SaveFileDialog();
            this.bgwProduced = new System.ComponentModel.BackgroundWorker();
            this.bgwRelease = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbSTXOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTX)).BeginInit();
            this.gbTagFormat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.gbInfo);
            this.spcMain.Panel1MinSize = 210;
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.spcMain.Panel2.Controls.Add(this.gbSTXOutput);
            this.spcMain.Size = new System.Drawing.Size(600, 667);
            this.spcMain.SplitterDistance = 233;
            this.spcMain.SplitterWidth = 2;
            this.spcMain.TabIndex = 0;
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.btnRelease);
            this.gbInfo.Controls.Add(this.btnProduced);
            this.gbInfo.Controls.Add(this.txtNoTags);
            this.gbInfo.Controls.Add(this.txtComments);
            this.gbInfo.Controls.Add(this.txtTagType);
            this.gbInfo.Controls.Add(this.txtSource);
            this.gbInfo.Controls.Add(this.txtDispatch);
            this.gbInfo.Controls.Add(this.txtCustomer);
            this.gbInfo.Controls.Add(this.txtOrderID);
            this.gbInfo.Controls.Add(this.lblComment);
            this.gbInfo.Controls.Add(this.lblTagType);
            this.gbInfo.Controls.Add(this.lblSource);
            this.gbInfo.Controls.Add(this.lblReceipt);
            this.gbInfo.Controls.Add(this.lblNoTags);
            this.gbInfo.Controls.Add(this.lblCustomer);
            this.gbInfo.Controls.Add(this.lblOrderId);
            this.gbInfo.Location = new System.Drawing.Point(3, 3);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(594, 227);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Enabled = false;
            this.btnRelease.Location = new System.Drawing.Point(432, 198);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 14;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnProduced
            // 
            this.btnProduced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduced.Enabled = false;
            this.btnProduced.Location = new System.Drawing.Point(513, 198);
            this.btnProduced.Name = "btnProduced";
            this.btnProduced.Size = new System.Drawing.Size(75, 23);
            this.btnProduced.TabIndex = 13;
            this.btnProduced.Text = "Produced";
            this.btnProduced.UseVisualStyleBackColor = true;
            this.btnProduced.Click += new System.EventHandler(this.btnProduced_Click);
            // 
            // txtNoTags
            // 
            this.txtNoTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoTags.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNoTags.Enabled = false;
            this.txtNoTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoTags.Location = new System.Drawing.Point(414, 16);
            this.txtNoTags.Name = "txtNoTags";
            this.txtNoTags.ReadOnly = true;
            this.txtNoTags.Size = new System.Drawing.Size(126, 31);
            this.txtNoTags.TabIndex = 12;
            this.txtNoTags.TabStop = false;
            // 
            // txtComments
            // 
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtComments.Enabled = false;
            this.txtComments.Location = new System.Drawing.Point(81, 171);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            this.txtComments.Size = new System.Drawing.Size(223, 26);
            this.txtComments.TabIndex = 0;
            this.txtComments.TabStop = false;
            // 
            // txtTagType
            // 
            this.txtTagType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTagType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTagType.Enabled = false;
            this.txtTagType.Location = new System.Drawing.Point(81, 120);
            this.txtTagType.Multiline = true;
            this.txtTagType.Name = "txtTagType";
            this.txtTagType.ReadOnly = true;
            this.txtTagType.Size = new System.Drawing.Size(223, 35);
            this.txtTagType.TabIndex = 11;
            this.txtTagType.TabStop = false;
            // 
            // txtSource
            // 
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSource.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSource.Enabled = false;
            this.txtSource.Location = new System.Drawing.Point(81, 94);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(223, 13);
            this.txtSource.TabIndex = 10;
            this.txtSource.TabStop = false;
            // 
            // txtDispatch
            // 
            this.txtDispatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDispatch.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtDispatch.Enabled = false;
            this.txtDispatch.Location = new System.Drawing.Point(81, 68);
            this.txtDispatch.Name = "txtDispatch";
            this.txtDispatch.ReadOnly = true;
            this.txtDispatch.Size = new System.Drawing.Size(223, 13);
            this.txtDispatch.TabIndex = 9;
            this.txtDispatch.TabStop = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(81, 42);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(223, 13);
            this.txtCustomer.TabIndex = 8;
            this.txtCustomer.TabStop = false;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Location = new System.Drawing.Point(81, 16);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(223, 13);
            this.txtOrderID.TabIndex = 1;
            this.txtOrderID.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(5, 169);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(70, 15);
            this.lblComment.TabIndex = 5;
            this.lblComment.Text = "Comments:";
            // 
            // lblTagType
            // 
            this.lblTagType.AutoSize = true;
            this.lblTagType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagType.Location = new System.Drawing.Point(6, 118);
            this.lblTagType.Name = "lblTagType";
            this.lblTagType.Size = new System.Drawing.Size(60, 15);
            this.lblTagType.TabIndex = 4;
            this.lblTagType.Text = "Tag Type:";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(6, 92);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(49, 15);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Source:";
            // 
            // lblReceipt
            // 
            this.lblReceipt.AutoSize = true;
            this.lblReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceipt.Location = new System.Drawing.Point(6, 66);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(58, 15);
            this.lblReceipt.TabIndex = 2;
            this.lblReceipt.Text = "Dispatch:";
            // 
            // lblNoTags
            // 
            this.lblNoTags.AutoSize = true;
            this.lblNoTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTags.Location = new System.Drawing.Point(310, 13);
            this.lblNoTags.Name = "lblNoTags";
            this.lblNoTags.Size = new System.Drawing.Size(98, 15);
            this.lblNoTags.TabIndex = 6;
            this.lblNoTags.Text = "Number of Tags:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(6, 40);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 15);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderId.Location = new System.Drawing.Point(6, 14);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(56, 15);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Order ID:";
            // 
            // gbSTXOutput
            // 
            this.gbSTXOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSTXOutput.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbSTXOutput.Controls.Add(this.groupBox1);
            this.gbSTXOutput.Controls.Add(this.lblSTXOutput);
            this.gbSTXOutput.Controls.Add(this.btnAppendSTX);
            this.gbSTXOutput.Controls.Add(this.btnExportSTX);
            this.gbSTXOutput.Controls.Add(this.dgvSTX);
            this.gbSTXOutput.Controls.Add(this.gbTagFormat);
            this.gbSTXOutput.Location = new System.Drawing.Point(3, 3);
            this.gbSTXOutput.Name = "gbSTXOutput";
            this.gbSTXOutput.Size = new System.Drawing.Size(594, 442);
            this.gbSTXOutput.TabIndex = 1;
            this.gbSTXOutput.TabStop = false;
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
            this.btnAppendSTX.Location = new System.Drawing.Point(17, 405);
            this.btnAppendSTX.Name = "btnAppendSTX";
            this.btnAppendSTX.Size = new System.Drawing.Size(203, 23);
            this.btnAppendSTX.TabIndex = 4;
            this.btnAppendSTX.Text = "APPEND TO CURRENT STX";
            this.btnAppendSTX.UseVisualStyleBackColor = true;
            this.btnAppendSTX.Click += new System.EventHandler(this.btnAppendSTX_Click);
            // 
            // btnExportSTX
            // 
            this.btnExportSTX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportSTX.Enabled = false;
            this.btnExportSTX.Location = new System.Drawing.Point(17, 376);
            this.btnExportSTX.Name = "btnExportSTX";
            this.btnExportSTX.Size = new System.Drawing.Size(203, 23);
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
            this.dgvSTX.Size = new System.Drawing.Size(349, 377);
            this.dgvSTX.TabIndex = 5;
            // 
            // gbTagFormat
            // 
            this.gbTagFormat.Controls.Add(this.rbTFP);
            this.gbTagFormat.Controls.Add(this.rbET);
            this.gbTagFormat.Controls.Add(this.rbTFS);
            this.gbTagFormat.Controls.Add(this.rbBT);
            this.gbTagFormat.Controls.Add(this.rbEDM);
            this.gbTagFormat.Location = new System.Drawing.Point(17, 54);
            this.gbTagFormat.Name = "gbTagFormat";
            this.gbTagFormat.Size = new System.Drawing.Size(203, 136);
            this.gbTagFormat.TabIndex = 0;
            this.gbTagFormat.TabStop = false;
            this.gbTagFormat.Text = "Tag Format";
            // 
            // rbTFP
            // 
            this.rbTFP.AutoSize = true;
            this.rbTFP.Location = new System.Drawing.Point(6, 88);
            this.rbTFP.Name = "rbTFP";
            this.rbTFP.Size = new System.Drawing.Size(106, 17);
            this.rbTFP.TabIndex = 4;
            this.rbTFP.Text = "TagFaster [ Pair ]";
            this.rbTFP.UseVisualStyleBackColor = true;
            // 
            // rbET
            // 
            this.rbET.AutoSize = true;
            this.rbET.Location = new System.Drawing.Point(6, 111);
            this.rbET.Name = "rbET";
            this.rbET.Size = new System.Drawing.Size(75, 17);
            this.rbET.TabIndex = 3;
            this.rbET.Text = "Easy Tags";
            this.rbET.UseVisualStyleBackColor = true;
            // 
            // rbTFS
            // 
            this.rbTFS.AutoSize = true;
            this.rbTFS.Location = new System.Drawing.Point(6, 65);
            this.rbTFS.Name = "rbTFS";
            this.rbTFS.Size = new System.Drawing.Size(117, 17);
            this.rbTFS.TabIndex = 2;
            this.rbTFS.Text = "TagFaster [ Single ]";
            this.rbTFS.UseVisualStyleBackColor = true;
            // 
            // rbBT
            // 
            this.rbBT.AutoSize = true;
            this.rbBT.Location = new System.Drawing.Point(6, 42);
            this.rbBT.Name = "rbBT";
            this.rbBT.Size = new System.Drawing.Size(56, 17);
            this.rbBT.TabIndex = 1;
            this.rbBT.Text = "Button";
            this.rbBT.UseVisualStyleBackColor = true;
            // 
            // rbEDM
            // 
            this.rbEDM.AutoSize = true;
            this.rbEDM.Checked = true;
            this.rbEDM.Location = new System.Drawing.Point(6, 19);
            this.rbEDM.Name = "rbEDM";
            this.rbEDM.Size = new System.Drawing.Size(110, 17);
            this.rbEDM.TabIndex = 0;
            this.rbEDM.TabStop = true;
            this.rbEDM.Text = "Easy, Dual or Mini";
            this.rbEDM.UseVisualStyleBackColor = true;
            // 
            // sfdCreate
            // 
            this.sfdCreate.DefaultExt = "txt";
            this.sfdCreate.FileName = "output.stx.txt";
            this.sfdCreate.Filter = "Text|*.txt";
            this.sfdCreate.Title = "Create/Save STX file";
            // 
            // sfdAppend
            // 
            this.sfdAppend.CheckFileExists = true;
            this.sfdAppend.DefaultExt = "txt";
            this.sfdAppend.FileName = "output.stx.txt";
            this.sfdAppend.Filter = "Text|*.txt";
            this.sfdAppend.OverwritePrompt = false;
            this.sfdAppend.Title = "Append to current STX";
            // 
            // bgwProduced
            // 
            this.bgwProduced.WorkerSupportsCancellation = true;
            this.bgwProduced.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProduced_DoWork);
            this.bgwProduced.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProduced_RunWorkerCompleted);
            // 
            // bgwRelease
            // 
            this.bgwRelease.WorkerSupportsCancellation = true;
            this.bgwRelease.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRelease_DoWork);
            this.bgwRelease.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRelease_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(17, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 45);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // STXControl_Sheep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "STXControl_Sheep";
            this.Size = new System.Drawing.Size(600, 667);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbSTXOutput.ResumeLayout(false);
            this.gbSTXOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTX)).EndInit();
            this.gbTagFormat.ResumeLayout(false);
            this.gbTagFormat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbSTXOutput;
        private System.Windows.Forms.DataGridView dgvSTX;
        private System.Windows.Forms.GroupBox gbTagFormat;
        private System.Windows.Forms.RadioButton rbET;
        private System.Windows.Forms.RadioButton rbTFS;
        private System.Windows.Forms.RadioButton rbBT;
        private System.Windows.Forms.RadioButton rbEDM;
        private System.Windows.Forms.Label lblSTXOutput;
        private System.Windows.Forms.Button btnAppendSTX;
        private System.Windows.Forms.Button btnExportSTX;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblTagType;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.Label lblNoTags;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtTagType;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDispatch;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtNoTags;
        private System.Windows.Forms.SaveFileDialog sfdCreate;
        private System.Windows.Forms.SaveFileDialog sfdAppend;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnProduced;
        private System.ComponentModel.BackgroundWorker bgwProduced;
        private System.ComponentModel.BackgroundWorker bgwRelease;
        private System.Windows.Forms.RadioButton rbTFP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
