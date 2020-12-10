namespace STXControl
{
    partial class STXControl
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
            this.bgwProduced = new System.ComponentModel.BackgroundWorker();
            this.bgwRelease = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.gbInfo.SuspendLayout();
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
            this.spcMain.Size = new System.Drawing.Size(604, 690);
            this.spcMain.SplitterDistance = 214;
            this.spcMain.SplitterWidth = 2;
            this.spcMain.TabIndex = 0;
            // 
            // gbInfo
            // 
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
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(604, 214);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.BackColor = System.Drawing.SystemColors.Control;
            this.btnRelease.Enabled = false;
            this.btnRelease.Location = new System.Drawing.Point(414, 185);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 14;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnProduced
            // 
            this.btnProduced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduced.BackColor = System.Drawing.SystemColors.Control;
            this.btnProduced.Enabled = false;
            this.btnProduced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduced.Location = new System.Drawing.Point(495, 171);
            this.btnProduced.Name = "btnProduced";
            this.btnProduced.Size = new System.Drawing.Size(103, 37);
            this.btnProduced.TabIndex = 13;
            this.btnProduced.Text = "Produced";
            this.btnProduced.UseVisualStyleBackColor = false;
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
            // STXControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "STXControl";
            this.Size = new System.Drawing.Size(604, 690);
            this.spcMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblSTXOutput;
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
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnProduced;
        private System.ComponentModel.BackgroundWorker bgwProduced;
        private System.ComponentModel.BackgroundWorker bgwRelease;
    }
}
