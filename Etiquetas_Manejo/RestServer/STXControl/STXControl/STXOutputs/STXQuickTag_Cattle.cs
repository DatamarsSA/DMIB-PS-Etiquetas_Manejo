using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STXControl.TagFormats;
using ProductionData;
using STXControl.TagOptions;

namespace STXControl.STXOutputs
{
    public partial class STXQuickTag_Cattle : UserControl, ISpecies
    {    
        private ATagFormat tagFormat = null;
        private DMProductionOrder productionOrder = null;
        private CheckBox cbT1PF = null;
        private CheckBox cbT1PM = null;
        private CheckBox cbT2SF = null;
        private CheckBox cbT2SM = null;
        private CheckBox cbSample = null;
        private SetDVGSource setSource = null;

        public STXQuickTag_Cattle()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // generate cbT1PF
            this.cbT1PF = new CheckBox();
            cbT1PF.AutoSize = true;
            cbT1PF.Location = new System.Drawing.Point(6, 20);
            cbT1PF.Text = "Tag 1 Primary Female";
            cbT1PF.CheckedChanged += new EventHandler(cbT1PF_CheckedChanged);
            this.gbBarcodes.Controls.Add(this.cbT1PF);
            this.cbT1PF.Enabled = true;

            // generate cbT1PM
            this.cbT1PM = new CheckBox();
            cbT1PM.AutoSize = true;
            cbT1PM.Location = new System.Drawing.Point(6, 40);
            cbT1PM.Text = "Tag 1 Primary Male";
            cbT1PM.CheckedChanged += new EventHandler(cbT1PM_CheckedChanged);
            this.gbBarcodes.Controls.Add(this.cbT1PM);
            this.cbT1PM.Enabled = true;

            // generate cbT2SF
            this.cbT2SF = new CheckBox();
            cbT2SF.AutoSize = true;
            cbT2SF.Location = new System.Drawing.Point(6, 60);
            cbT2SF.Text = "Tag 2 Secondary Female";
            cbT2SF.CheckedChanged += new EventHandler(cbT2SF_CheckedChanged);
            this.gbBarcodes.Controls.Add(this.cbT2SF);
            this.cbT2SF.Enabled = true;

            // generate cbT2SF
            this.cbT2SM = new CheckBox();
            cbT2SM.AutoSize = true;
            cbT2SM.Location = new System.Drawing.Point(6, 80);
            cbT2SM.Text = "Tag 2 Secondary Male";
            cbT2SM.CheckedChanged += new EventHandler(cbT2SM_CheckedChanged);
            this.gbBarcodes.Controls.Add(this.cbT2SM);
            this.cbT2SM.Enabled = true;

            // generate cbSample
            this.cbSample = new CheckBox();
            cbSample.AutoSize = true;
            cbSample.Location = new System.Drawing.Point(6, 60);
            cbSample.Text = "Sample";
            cbSample.CheckedChanged += new EventHandler(cbSample_CheckedChanged);
            this.gbBarcodes.Controls.Add(this.cbSample);
            this.cbSample.Enabled = false;
        }

        public void setProductionOrder(DMProductionOrder order)
        {
            this.productionOrder = order;
            this.rbMMTVT_CheckedChanged(this.rbMMTVT, null);
        }

        public void setSourceCallback(SetDVGSource callback)
        {
            try
            {
                this.setSource = callback;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setDgvSource()
        {
            try
            {
                this.setOptions();
                this.setSource(this.tagFormat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void clearAll()
        {
            try
            {
                this.cbT1PM.Checked = false;
                this.cbT1PF.Checked = false;
                this.cbT2SF.Checked = false;
                this.cbT2SM.Checked = false;
                this.cbSample.Checked = false;
                this.rb2.Checked = true;
                this.rbMMTVT.Checked = true;
                this.tagFormat = null;
                this.productionOrder = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void setOptions()
        {
            try
            {
                foreach (ATagOption option in this.tagFormat.getOptions())
                {
                    if (option.GetType() == typeof(TagOptionT1PF) && this.cbT1PF.Checked)
                    {
                        option.Active = true;
                    }
                    if (option.GetType() == typeof(TagOptionT1PM) && this.cbT1PM.Checked)
                    {
                        option.Active = true;
                    }
                    if (option.GetType() == typeof(TagOptionT2SF) && this.cbT2SF.Checked)
                    {
                        if (int.Parse(this.productionOrder.Properties.AuthorisationTypeId) == 1 && this.tagFormat.Multiplier >= 2)
                            option.Active = true;
                        else
                            option.Active = false;
                    }
                    if (option.GetType() == typeof(TagOptionT2SM) && this.cbT2SM.Checked)
                    {
                        option.Active = true;
                    }
                    if (option.GetType() == typeof(TagOptionSample) && this.cbSample.Checked)
                    {
                        option.Active = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbMMTVT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatMMTVT))
                        this.tagFormat = new TagFormatMMTVT(this.productionOrder);

                    this.cbT1PF.Enabled = true;
                    this.cbT1PM.Enabled = true;
                    if (this.tagFormat.Multiplier == 4 || this.tagFormat.Multiplier == 6)
                    {
                        this.cbT2SF.Visible = true;
                        this.cbT2SF.Enabled = true;
                        this.cbT2SM.Visible = true;
                        this.cbT2SM.Enabled = true;
                    }
                    else
                    {
                        this.cbT2SF.Visible = true;
                        this.cbT2SF.Checked = false;
                        this.cbT2SF.Enabled = false;
                        this.cbT2SM.Visible = true;
                        this.cbT2SM.Checked = false;
                        this.cbT2SM.Enabled = false;
                    }
                    this.cbSample.Visible = false;
                    this.gbBarcodes.Visible = true;
                    this.rb2.Checked = true;
                    this.tagFormat.Multiplier = 2;
                    this.setDgvSource();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbBT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatBT))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatBT(this.productionOrder);
                    }

                    this.cbT1PF.Enabled = true;
                    this.cbT1PM.Enabled = true;
                    this.cbT2SF.Enabled = true;
                    this.cbT2SM.Enabled = true;
                    this.cbSample.Visible = false;
                    this.gbBarcodes.Visible = false;

                    this.rb2.Checked = true;
                    this.tagFormat.Multiplier = 2;
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbTST_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatTST))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatTST(this.productionOrder);
                    }
                    this.cbT1PF.Enabled = true;
                    this.cbT1PM.Enabled = true;
                    this.cbT2SF.Visible = false;
                    this.cbT2SM.Visible = false;
                    this.cbSample.Visible = true;
                    this.cbSample.Enabled = true;
                    this.gbBarcodes.Visible = true;
                    this.rb2.Checked = true;
                    this.tagFormat.Multiplier = 3;
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbMMTBT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatMMTBT))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatMMTBT(this.productionOrder);
                    }
                    this.cbSample.Visible = false;
                    this.cbT1PF.Enabled = true;
                    this.cbT1PM.Checked = false;
                    this.cbT1PM.Enabled = false;
                    this.cbT1PM.Visible = true;
                    this.cbT2SF.Visible = true;
                    this.cbT2SF.Enabled = true;
                    this.cbT2SM.Checked = false;
                    this.cbT2SM.Visible = true;
                    this.cbT2SM.Enabled = false;
                    this.gbBarcodes.Visible = true;
                    this.rb4.Checked = true;
                    this.tagFormat.Multiplier = 2;
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat.GetType() == typeof(TagFormatMMTVT))
                    {
                        this.cbT2SF.Checked = false;
                        this.cbT2SF.Enabled = false;
                        this.cbT2SM.Checked = false;
                        this.cbT2SM.Enabled = false;
                    }
                    if (this.tagFormat.GetType() == typeof(TagFormatMMTBT))
                    {
                        this.tagFormat.Multiplier = 1;
                    }
                    else if (this.tagFormat.GetType() == typeof(TagFormatTST))
                    {
                        this.tagFormat.Multiplier = 3;
                    }
                    else
                    {
                        this.tagFormat.Multiplier = 2;
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat.GetType() == typeof(TagFormatMMTVT))
                    {
                        this.cbT2SF.Enabled = true;
                        this.cbT2SM.Enabled = true;
                    }
                    if (this.tagFormat.GetType() == typeof(TagFormatMMTBT))
                    {
                        this.tagFormat.Multiplier = 2;
                    }
                    else if (this.tagFormat.GetType() == typeof(TagFormatTST))
                    {
                        this.tagFormat.Multiplier = 6;
                    }
                    else
                    {
                        this.tagFormat.Multiplier = 4;
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbT1PF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    foreach (ATagOption op in this.tagFormat.getOptions())
                    {
                        if (op.GetType() == typeof(TagOptionT1PF))
                        {
                            if (cb.Checked)
                                op.Active = true;
                            else
                                op.Active = false;
                        }
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbT1PM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    foreach (ATagOption op in this.tagFormat.getOptions())
                    {
                        if (op.GetType() == typeof(TagOptionT1PM))
                        {
                            if (cb.Checked)
                                op.Active = true;
                            else
                                op.Active = false;
                        }
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbT2SF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    foreach (ATagOption op in this.tagFormat.getOptions())
                    {
                        if (op.GetType() == typeof(TagOptionT2SF))
                        {
                            if (cb.Checked)
                                op.Active = true;
                            else
                                op.Active = false;
                        }
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbT2SM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    foreach (ATagOption op in this.tagFormat.getOptions())
                    {
                        if (op.GetType() == typeof(TagOptionT2SM))
                        {
                            if (cb.Checked)
                                op.Active = true;
                            else
                                op.Active = false;
                        }
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSample_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    foreach (ATagOption op in this.tagFormat.getOptions())
                    {
                        if (op.GetType() == typeof(TagOptionSample))
                        {
                            if (cb.Checked)
                                op.Active = true;
                            else
                                op.Active = false;
                        }
                    }
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
