namespace STXControl.STXOutputs
{
    partial class STXQuickTag_Sheep
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
            this.gbTagFormat = new System.Windows.Forms.GroupBox();
            this.rbETags = new System.Windows.Forms.RadioButton();
            this.rbTagFasterP = new System.Windows.Forms.RadioButton();
            this.rbTagFasterS = new System.Windows.Forms.RadioButton();
            this.rbButton = new System.Windows.Forms.RadioButton();
            this.rbEDM = new System.Windows.Forms.RadioButton();
            this.pPos1 = new System.Windows.Forms.Panel();
            this.gbBarcode = new System.Windows.Forms.GroupBox();
            this.gbButtonTag = new System.Windows.Forms.GroupBox();
            this.cbIncSpace = new System.Windows.Forms.CheckBox();
            this.rbButtonTag2 = new System.Windows.Forms.RadioButton();
            this.rbButtonTag1 = new System.Windows.Forms.RadioButton();
            this.cbIncBarcode = new System.Windows.Forms.CheckBox();
            this.pPos2 = new System.Windows.Forms.Panel();
            this.gbEDM = new System.Windows.Forms.GroupBox();
            this.gbTagFasterS = new System.Windows.Forms.GroupBox();
            this.cbPrefixBarcode = new System.Windows.Forms.CheckBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.pPos3 = new System.Windows.Forms.Panel();
            this.gbPrefix = new System.Windows.Forms.GroupBox();
            this.cbPrefix = new System.Windows.Forms.CheckBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.pPos4 = new System.Windows.Forms.Panel();
            this.gbFixed = new System.Windows.Forms.GroupBox();
            this.nudFixedLength = new System.Windows.Forms.NumericUpDown();
            this.gbTagFormat.SuspendLayout();
            this.pPos1.SuspendLayout();
            this.gbBarcode.SuspendLayout();
            this.gbButtonTag.SuspendLayout();
            this.pPos2.SuspendLayout();
            this.gbEDM.SuspendLayout();
            this.gbTagFasterS.SuspendLayout();
            this.pPos3.SuspendLayout();
            this.gbPrefix.SuspendLayout();
            this.pPos4.SuspendLayout();
            this.gbFixed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedLength)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTagFormat
            // 
            this.gbTagFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTagFormat.Controls.Add(this.rbETags);
            this.gbTagFormat.Controls.Add(this.rbTagFasterP);
            this.gbTagFormat.Controls.Add(this.rbTagFasterS);
            this.gbTagFormat.Controls.Add(this.rbButton);
            this.gbTagFormat.Controls.Add(this.rbEDM);
            this.gbTagFormat.Location = new System.Drawing.Point(3, 3);
            this.gbTagFormat.Name = "gbTagFormat";
            this.gbTagFormat.Size = new System.Drawing.Size(200, 134);
            this.gbTagFormat.TabIndex = 0;
            this.gbTagFormat.TabStop = false;
            this.gbTagFormat.Text = "Tag Format";
            // 
            // rbETags
            // 
            this.rbETags.AutoSize = true;
            this.rbETags.Location = new System.Drawing.Point(6, 111);
            this.rbETags.Name = "rbETags";
            this.rbETags.Size = new System.Drawing.Size(75, 17);
            this.rbETags.TabIndex = 4;
            this.rbETags.TabStop = true;
            this.rbETags.Text = "Eezy Tags";
            this.rbETags.UseVisualStyleBackColor = true;
            this.rbETags.CheckedChanged += new System.EventHandler(this.rbETags_CheckedChanged);
            // 
            // rbTagFasterP
            // 
            this.rbTagFasterP.AutoSize = true;
            this.rbTagFasterP.Location = new System.Drawing.Point(6, 88);
            this.rbTagFasterP.Name = "rbTagFasterP";
            this.rbTagFasterP.Size = new System.Drawing.Size(114, 17);
            this.rbTagFasterP.TabIndex = 3;
            this.rbTagFasterP.TabStop = true;
            this.rbTagFasterP.Text = "Tag Faster [ Pairs ]";
            this.rbTagFasterP.UseVisualStyleBackColor = true;
            this.rbTagFasterP.CheckedChanged += new System.EventHandler(this.rbTagFasterP_CheckedChanged);
            // 
            // rbTagFasterS
            // 
            this.rbTagFasterS.AutoSize = true;
            this.rbTagFasterS.Location = new System.Drawing.Point(6, 65);
            this.rbTagFasterS.Name = "rbTagFasterS";
            this.rbTagFasterS.Size = new System.Drawing.Size(117, 17);
            this.rbTagFasterS.TabIndex = 2;
            this.rbTagFasterS.TabStop = true;
            this.rbTagFasterS.Text = "TagFaster [ Single ]";
            this.rbTagFasterS.UseVisualStyleBackColor = true;
            this.rbTagFasterS.CheckedChanged += new System.EventHandler(this.rbTagFasterS_CheckedChanged);
            // 
            // rbButton
            // 
            this.rbButton.AutoSize = true;
            this.rbButton.Location = new System.Drawing.Point(6, 42);
            this.rbButton.Name = "rbButton";
            this.rbButton.Size = new System.Drawing.Size(56, 17);
            this.rbButton.TabIndex = 1;
            this.rbButton.TabStop = true;
            this.rbButton.Text = "Button";
            this.rbButton.UseVisualStyleBackColor = true;
            this.rbButton.CheckedChanged += new System.EventHandler(this.rbButton_CheckedChanged);
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
            this.rbEDM.CheckedChanged += new System.EventHandler(this.rbEDM_CheckedChanged);
            // 
            // pPos1
            // 
            this.pPos1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPos1.Controls.Add(this.gbBarcode);
            this.pPos1.Location = new System.Drawing.Point(3, 143);
            this.pPos1.Name = "pPos1";
            this.pPos1.Size = new System.Drawing.Size(200, 40);
            this.pPos1.TabIndex = 1;
            // 
            // gbBarcode
            // 
            this.gbBarcode.Controls.Add(this.gbButtonTag);
            this.gbBarcode.Controls.Add(this.cbIncBarcode);
            this.gbBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBarcode.Location = new System.Drawing.Point(0, 0);
            this.gbBarcode.Name = "gbBarcode";
            this.gbBarcode.Size = new System.Drawing.Size(200, 40);
            this.gbBarcode.TabIndex = 0;
            this.gbBarcode.TabStop = false;
            this.gbBarcode.Text = "Barcode";
            // 
            // gbButtonTag
            // 
            this.gbButtonTag.Controls.Add(this.cbIncSpace);
            this.gbButtonTag.Controls.Add(this.rbButtonTag2);
            this.gbButtonTag.Controls.Add(this.rbButtonTag1);
            this.gbButtonTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbButtonTag.Location = new System.Drawing.Point(3, 16);
            this.gbButtonTag.Name = "gbButtonTag";
            this.gbButtonTag.Size = new System.Drawing.Size(194, 21);
            this.gbButtonTag.TabIndex = 5;
            this.gbButtonTag.TabStop = false;
            this.gbButtonTag.Text = "Button Tag";
            this.gbButtonTag.Visible = false;
            // 
            // cbIncSpace
            // 
            this.cbIncSpace.AutoSize = true;
            this.cbIncSpace.Checked = true;
            this.cbIncSpace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncSpace.Location = new System.Drawing.Point(90, 17);
            this.cbIncSpace.Name = "cbIncSpace";
            this.cbIncSpace.Size = new System.Drawing.Size(75, 17);
            this.cbIncSpace.TabIndex = 2;
            this.cbIncSpace.Text = "Inc Space";
            this.cbIncSpace.UseVisualStyleBackColor = true;
            this.cbIncSpace.CheckedChanged += new System.EventHandler(this.cbIncSpace_CheckedChanged);
            // 
            // rbButtonTag2
            // 
            this.rbButtonTag2.AutoSize = true;
            this.rbButtonTag2.Location = new System.Drawing.Point(48, 16);
            this.rbButtonTag2.Name = "rbButtonTag2";
            this.rbButtonTag2.Size = new System.Drawing.Size(36, 17);
            this.rbButtonTag2.TabIndex = 1;
            this.rbButtonTag2.Text = "x2";
            this.rbButtonTag2.UseVisualStyleBackColor = true;
            this.rbButtonTag2.CheckedChanged += new System.EventHandler(this.rbButtonTag2_CheckedChanged);
            // 
            // rbButtonTag1
            // 
            this.rbButtonTag1.AutoSize = true;
            this.rbButtonTag1.Checked = true;
            this.rbButtonTag1.Location = new System.Drawing.Point(6, 16);
            this.rbButtonTag1.Name = "rbButtonTag1";
            this.rbButtonTag1.Size = new System.Drawing.Size(36, 17);
            this.rbButtonTag1.TabIndex = 0;
            this.rbButtonTag1.TabStop = true;
            this.rbButtonTag1.Text = "x1";
            this.rbButtonTag1.UseVisualStyleBackColor = true;
            this.rbButtonTag1.CheckedChanged += new System.EventHandler(this.rbButtonTag1_CheckedChanged);
            // 
            // cbIncBarcode
            // 
            this.cbIncBarcode.AutoSize = true;
            this.cbIncBarcode.Location = new System.Drawing.Point(6, 17);
            this.cbIncBarcode.Name = "cbIncBarcode";
            this.cbIncBarcode.Size = new System.Drawing.Size(104, 17);
            this.cbIncBarcode.TabIndex = 0;
            this.cbIncBarcode.Text = "Include Barcode";
            this.cbIncBarcode.UseVisualStyleBackColor = true;
            this.cbIncBarcode.CheckedChanged += new System.EventHandler(this.cbIncBarcode_CheckedChanged);
            // 
            // pPos2
            // 
            this.pPos2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPos2.Controls.Add(this.gbEDM);
            this.pPos2.Location = new System.Drawing.Point(3, 189);
            this.pPos2.Name = "pPos2";
            this.pPos2.Size = new System.Drawing.Size(200, 40);
            this.pPos2.TabIndex = 2;
            // 
            // gbEDM
            // 
            this.gbEDM.Controls.Add(this.gbTagFasterS);
            this.gbEDM.Controls.Add(this.rb2);
            this.gbEDM.Controls.Add(this.rb1);
            this.gbEDM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEDM.Location = new System.Drawing.Point(0, 0);
            this.gbEDM.Name = "gbEDM";
            this.gbEDM.Size = new System.Drawing.Size(200, 40);
            this.gbEDM.TabIndex = 0;
            this.gbEDM.TabStop = false;
            this.gbEDM.Text = "Easy, Dual or Mini";
            // 
            // gbTagFasterS
            // 
            this.gbTagFasterS.Controls.Add(this.cbPrefixBarcode);
            this.gbTagFasterS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTagFasterS.Location = new System.Drawing.Point(3, 16);
            this.gbTagFasterS.Name = "gbTagFasterS";
            this.gbTagFasterS.Size = new System.Drawing.Size(194, 21);
            this.gbTagFasterS.TabIndex = 6;
            this.gbTagFasterS.TabStop = false;
            this.gbTagFasterS.Text = "Tag Faster Single";
            this.gbTagFasterS.Visible = false;
            // 
            // cbPrefixBarcode
            // 
            this.cbPrefixBarcode.AutoSize = true;
            this.cbPrefixBarcode.Location = new System.Drawing.Point(6, 17);
            this.cbPrefixBarcode.Name = "cbPrefixBarcode";
            this.cbPrefixBarcode.Size = new System.Drawing.Size(110, 17);
            this.cbPrefixBarcode.TabIndex = 2;
            this.cbPrefixBarcode.Text = "Prefix Barcode - 0";
            this.cbPrefixBarcode.UseVisualStyleBackColor = true;
            this.cbPrefixBarcode.CheckedChanged += new System.EventHandler(this.cbPrefixBarcode_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(48, 17);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(36, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "x2";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 17);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(36, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "x1";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // pPos3
            // 
            this.pPos3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPos3.Controls.Add(this.gbPrefix);
            this.pPos3.Location = new System.Drawing.Point(3, 235);
            this.pPos3.Name = "pPos3";
            this.pPos3.Size = new System.Drawing.Size(200, 40);
            this.pPos3.TabIndex = 3;
            // 
            // gbPrefix
            // 
            this.gbPrefix.Controls.Add(this.cbPrefix);
            this.gbPrefix.Controls.Add(this.txtPrefix);
            this.gbPrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPrefix.Location = new System.Drawing.Point(0, 0);
            this.gbPrefix.Name = "gbPrefix";
            this.gbPrefix.Size = new System.Drawing.Size(200, 40);
            this.gbPrefix.TabIndex = 0;
            this.gbPrefix.TabStop = false;
            this.gbPrefix.Text = "Prefix";
            // 
            // cbPrefix
            // 
            this.cbPrefix.AutoSize = true;
            this.cbPrefix.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPrefix.Location = new System.Drawing.Point(48, 16);
            this.cbPrefix.Name = "cbPrefix";
            this.cbPrefix.Size = new System.Drawing.Size(61, 17);
            this.cbPrefix.TabIndex = 1;
            this.cbPrefix.Text = "Include";
            this.cbPrefix.UseVisualStyleBackColor = true;
            this.cbPrefix.CheckedChanged += new System.EventHandler(this.cbPrefix_CheckedChanged);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(6, 14);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(36, 20);
            this.txtPrefix.TabIndex = 0;
            this.txtPrefix.TextChanged += new System.EventHandler(this.txtPrefix_TextChanged);
            // 
            // pPos4
            // 
            this.pPos4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPos4.Controls.Add(this.gbFixed);
            this.pPos4.Location = new System.Drawing.Point(3, 281);
            this.pPos4.Name = "pPos4";
            this.pPos4.Size = new System.Drawing.Size(200, 40);
            this.pPos4.TabIndex = 4;
            // 
            // gbFixed
            // 
            this.gbFixed.Controls.Add(this.nudFixedLength);
            this.gbFixed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFixed.Location = new System.Drawing.Point(0, 0);
            this.gbFixed.Name = "gbFixed";
            this.gbFixed.Size = new System.Drawing.Size(200, 40);
            this.gbFixed.TabIndex = 0;
            this.gbFixed.TabStop = false;
            this.gbFixed.Text = "Fixed Length";
            // 
            // nudFixedLength
            // 
            this.nudFixedLength.Location = new System.Drawing.Point(6, 14);
            this.nudFixedLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFixedLength.Name = "nudFixedLength";
            this.nudFixedLength.Size = new System.Drawing.Size(43, 20);
            this.nudFixedLength.TabIndex = 0;
            this.nudFixedLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFixedLength.ValueChanged += new System.EventHandler(this.nudFixedLength_ValueChanged);
            // 
            // STXQuickTag_Sheep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pPos4);
            this.Controls.Add(this.pPos3);
            this.Controls.Add(this.pPos2);
            this.Controls.Add(this.pPos1);
            this.Controls.Add(this.gbTagFormat);
            this.Name = "STXQuickTag_Sheep";
            this.Size = new System.Drawing.Size(210, 330);
            this.gbTagFormat.ResumeLayout(false);
            this.gbTagFormat.PerformLayout();
            this.pPos1.ResumeLayout(false);
            this.gbBarcode.ResumeLayout(false);
            this.gbBarcode.PerformLayout();
            this.gbButtonTag.ResumeLayout(false);
            this.gbButtonTag.PerformLayout();
            this.pPos2.ResumeLayout(false);
            this.gbEDM.ResumeLayout(false);
            this.gbEDM.PerformLayout();
            this.gbTagFasterS.ResumeLayout(false);
            this.gbTagFasterS.PerformLayout();
            this.pPos3.ResumeLayout(false);
            this.gbPrefix.ResumeLayout(false);
            this.gbPrefix.PerformLayout();
            this.pPos4.ResumeLayout(false);
            this.gbFixed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFixedLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTagFormat;
        private System.Windows.Forms.RadioButton rbETags;
        private System.Windows.Forms.RadioButton rbTagFasterP;
        private System.Windows.Forms.RadioButton rbTagFasterS;
        private System.Windows.Forms.RadioButton rbButton;
        private System.Windows.Forms.RadioButton rbEDM;
        private System.Windows.Forms.Panel pPos1;
        private System.Windows.Forms.GroupBox gbBarcode;
        private System.Windows.Forms.Panel pPos2;
        private System.Windows.Forms.GroupBox gbEDM;
        private System.Windows.Forms.Panel pPos3;
        private System.Windows.Forms.GroupBox gbPrefix;
        private System.Windows.Forms.Panel pPos4;
        private System.Windows.Forms.GroupBox gbFixed;
        private System.Windows.Forms.CheckBox cbIncBarcode;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.CheckBox cbPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.NumericUpDown nudFixedLength;
        private System.Windows.Forms.GroupBox gbButtonTag;
        private System.Windows.Forms.CheckBox cbIncSpace;
        private System.Windows.Forms.RadioButton rbButtonTag2;
        private System.Windows.Forms.RadioButton rbButtonTag1;
        private System.Windows.Forms.GroupBox gbTagFasterS;
        private System.Windows.Forms.CheckBox cbPrefixBarcode;
    }
}
