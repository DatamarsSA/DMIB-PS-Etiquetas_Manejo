using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductionData;
using STXControl.TagFormats;
using STXControl.TagOptions;

namespace STXControl.STXOutputs
{

    public partial class STXQuickTag_Aims: UserControl, ISpecies
    {
        private ATagFormat tagFormat = null;
        private DMProductionOrder productionOrder = null;
        private SetDVGSource setSource = null;

        public STXQuickTag_Aims()
        {
            InitializeComponent();
            this.rbEDM.Checked = true;
            this.rb1.Checked = true;
            this.nudFixedLength.Value = 5;
        }

        public void clearAll()
        {
            try
            {
                // alle Optionen löschen
                this.tagFormat = null;
                this.productionOrder = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setProductionOrder(DMProductionOrder order)
        {
            try
            {
                this.productionOrder = order;
                this.setInitialValues();
                this.rbEDM_CheckedChanged(this.rbEDM, null);
                this.cbPrefix_CheckedChanged(this.cbPrefix, null);
                this.nudFixedLength_ValueChanged(this.nudFixedLength, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        private void setInitialValues()
        {
            try
            {
                if(this.productionOrder != null)
                {
                    String[] temp = this.productionOrder.Identifiers[0].FormattedTag.Split(' ');
                    this.txtPrefix.Text = temp[0].Trim();
                    this.cbPrefix.Checked = true;
                    this.nudFixedLength.Value = 5; // John request, defaulting to fixed 5 //temp[2].Length;
                }
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

        protected void setOptions()
        {
            try
            {
                foreach (ATagOption option in this.tagFormat.getOptions())
                {
                    if (option.GetType() == typeof(TagOptionPrefix))
                    {
                        TagOptionPrefix op = (TagOptionPrefix)option;
                        if (this.cbPrefix.Checked)
                        {
                            op.Include = true;
                            op.Prefix = this.txtPrefix.Text;
                            op.Active = true;
                        }
                        else
                        {
                            op.Include = false;
                            op.Prefix = string.Empty;
                            op.Active = false;
                        }
                    }
                    if(option.GetType() == typeof(TagOptionEDM))
                    {
                        TagOptionEDM op = (TagOptionEDM)option;
                        if (this.rb1.Checked)
                            op.Repeat = 1;
                        else
                            op.Repeat = 2;
                        op.Active = true;
                    }
                    if (option.GetType() == typeof(TagOptionBT))
                    {
                        TagOptionBT op = (TagOptionBT)option;
                        if (this.cbIncSpace.Checked)
                        {
                            op.Space = true;
                            op.Active = true;
                        }
                        else
                        {
                            op.Space = false;
                            op.Active = false;
                        }
                        if (this.rbButtonTag1.Checked)
                            op.Repeat = 1;
                        else if (this.rbButtonTag2.Checked)
                            op.Repeat = 2;
                        else
                            op.Repeat = 1;
                    }
                    if(option.GetType() == typeof(TagOptionFixL))
                    {
                        TagOptionFixL op = (TagOptionFixL)option;
                        op.Length = (int)this.nudFixedLength.Value;
                        op.Active = true;
                    }
                    if (option.GetType() == typeof(TagOptionBarcode))
                    {
                        TagOptionBarcode op = (TagOptionBarcode)option;
                        if (this.cbIncBarcode.Checked)
                        {
                            op.LeadingRegio = true;
                            if (this.tagFormat.GetType() == typeof(TagFormatEDM))
                            {
                                if (this.cbPrefix.Checked)
                                {
                                    op.Prefix = this.txtPrefix.Text;
                                    op.LeadingRegio = true;
                                }
                                else
                                {
                                    op.Prefix = string.Empty;
                                    op.LeadingRegio = false;
                                }
                            }
                            else if (this.tagFormat.GetType() == typeof(TagFormatTFS))
                            {
                                if (this.cbPrefixBarcode.Checked)
                                {
                                    op.Prefix = "0";
                                    op.LeadingPrefix = true;
                                }
                                else
                                {
                                    op.LeadingPrefix = false;
                                }
                            }
                            op.Active = true;
                        }
                        else
                        {
                            op.Active = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbEDM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    this.setVisualsEDM();
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatEDM))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatEDM(this.productionOrder);
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    this.setVisualsButton();
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatBT2))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatBT2(this.productionOrder);
                        this.setDgvSource();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbTagFasterS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    this.setVisualsTagFasterS();
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatTFS))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatTFS(this.productionOrder);
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbTagFasterP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    this.setVisualsTagFasterP();
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatTFP))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatTFP(this.productionOrder);
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbETags_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    this.setVisualsETags();
                    if (this.tagFormat == null || this.tagFormat.GetType() != typeof(TagFormatET))
                    {
                        this.tagFormat = null;
                        this.tagFormat = new TagFormatET(this.productionOrder);
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbIncBarcode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                this.setDgvSource();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    //if (this.tagFormat.GetType() == typeof(TagFormatEDM))
                    //{
                    //    foreach (ATagOption op in this.tagFormat.getOptions())
                    //    {
                    //        if (op.GetType() == typeof(TagOptionEDM))
                    //        {
                    //            TagOptionEDM temp = (TagOptionEDM)op;
                    //            temp.Repeat = 1;
                    //            temp.Active = true;
                    //        }
                    //    }
                    //}
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    //if (this.tagFormat.GetType() == typeof(TagFormatEDM))
                    //{
                    //    foreach (ATagOption op in this.tagFormat.getOptions())
                    //    {
                    //        if (op.GetType() == typeof(TagOptionEDM))
                    //        {
                    //            TagOptionEDM temp = (TagOptionEDM)op;
                    //            temp.Repeat = 2;
                    //            temp.Active = true;
                    //        }
                    //    }
                    //}
                    this.setDgvSource();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                TextBox txt = (TextBox)sender;
                if (this.tagFormat != null)
                {
                    //if (this.tagFormat.GetType() == typeof(TagFormatBT2))
                    //{
                    //    foreach (ATagOption op in this.tagFormat.getOptions())
                    //    {
                    //        if (op.GetType() == typeof(TagOptionPrefix))
                    //        {
                    //            TagOptionPrefix temp = (TagOptionPrefix)op;
                    //            temp.Prefix = txt.Text.Trim();
                    //            temp.Active = true;
                    //        }
                    //    }
                    //}
                    //else if (this.tagFormat.GetType() == typeof(TagFormatEDM))
                    //{
                    //    foreach (ATagOption op in this.tagFormat.getOptions())
                    //    {
                    //        if (op.GetType() == typeof(TagOptionPrefix))
                    //        {
                    //            TagOptionPrefix temp = (TagOptionPrefix)op;
                    //            temp.Prefix = txt.Text.Trim(); ;
                    //            temp.Active = true;
                    //        }
                    //    }
                    //}
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbPrefix_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;

                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void nudFixedLength_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown nud = (NumericUpDown)sender;
                if (nud.Value > 0 && this.tagFormat != null)
                {
                    this.setDgvSource();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbButtonTag1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat != null)
                    {
                        //if(this.tagFormat.GetType() == typeof(TagFormatBT2))
                        //{
                        //    //foreach(ATagOption op in this.tagFormat.getOptions())
                        //    //{
                        //    //    if(op.GetType() == typeof(TagOptionBT))
                        //    //    {
                        //    //        TagOptionBT temp = (TagOptionBT)op;
                        //    //        temp.Repeat = 1;
                        //    //        temp.Active = true;
                        //    //    }
                        //    //}
                            
                        //}
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void rbButtonTag2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                    if (this.tagFormat != null)
                    {
                        //if (this.tagFormat.GetType() == typeof(TagFormatBT2))
                        //{
                        //    //foreach (ATagOption op in this.tagFormat.getOptions())
                        //    //{
                        //    //    if (op.GetType() == typeof(TagOptionBT))
                        //    //    {
                        //    //        TagOptionBT temp = (TagOptionBT)op;
                        //    //        temp.Repeat = 2;
                        //    //        temp.Active = true;
                        //    //    }
                        //    //}
                            
                        //}
                        this.setDgvSource();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbIncSpace_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                if (this.tagFormat != null)
                {
                    //if (this.tagFormat.GetType() == typeof(TagFormatBT2))
                    //{
                    //    //foreach (ATagOption op in this.tagFormat.getOptions())
                    //    //{
                    //    //    if (op.GetType() == typeof(TagOptionBT))
                    //    //    {
                    //    //        TagOptionBT temp = (TagOptionBT)op;
                    //    //        if (cb.Checked)
                    //    //            temp.Space = true;
                    //    //        else
                    //    //            temp.Space = false;
                    //    //        temp.Active = true;
                    //    //    }
                    //    //}
                        
                    //}
                    this.setDgvSource();
                }
                this.setDgvSource();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbPrefixBarcode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    return;
                this.setDgvSource();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Visuals

        private void clearPanels()
        {
            try
            {
                this.pPos1.Controls.Clear();
                this.pPos2.Controls.Clear();
                this.pPos3.Controls.Clear();
                this.pPos4.Controls.Clear();
                this.gbEDM.Visible = false;
                this.gbBarcode.Visible = false;
                this.gbButtonTag.Visible = false;
                this.gbFixed.Visible = false;
                this.gbPrefix.Visible = false;
                this.gbTagFasterS.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setVisualsEDM()
        {
            try
            {
                this.clearPanels();
                this.pPos1.Controls.Add(this.gbEDM);
                this.pPos2.Controls.Add(this.gbBarcode);
                this.gbBarcode.Visible = true;
                this.gbEDM.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setVisualsButton()
        {
            try
            {
                this.clearPanels();

                this.pPos1.Controls.Add(this.gbButtonTag);
                this.gbButtonTag.Visible = true;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setVisualsTagFasterS()
        {
            try
            {
                this.clearPanels();
                this.pPos1.Controls.Add(this.gbTagFasterS);
                this.pPos2.Controls.Add(this.gbBarcode);
                this.gbBarcode.Visible = true;
                this.gbTagFasterS.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setVisualsTagFasterP()
        {
            try
            {
                this.clearPanels();
                this.pPos1.Controls.Add(this.gbBarcode);
                this.gbBarcode.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setVisualsETags()
        {
            try
            {
                this.clearPanels();
                this.pPos1.Controls.Add(this.gbBarcode);
                this.gbBarcode.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
