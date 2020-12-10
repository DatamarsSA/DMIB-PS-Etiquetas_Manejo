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
using DMServiceLibrary;
using System.IO;
using STXControl.STXOutputs;

namespace STXControl
{


    public partial class STXOutputQuickTag : UserControl, ISTXOutput
    {
        delegate void fillSTXData(DMProductionOrder order, Formatter formatter);
        public delegate void orderProduced();
       // delegate void showSTXCancellation(String id);

        private DMProductionOrder productionOrder = null;
        private ATagFormat tagFormat = null;
        private ISpecies speciesControl = null;
        private orderProduced orderProd = null;
        private string _defaultPath;

        public STXOutputQuickTag(string defaultPath)
        {
            InitializeComponent();
            _defaultPath = defaultPath;
            this.Dock = DockStyle.Fill;
        }

        private void setSpecies(Species species)
        {
            try
            {
                switch (species)
                {
                    case Species.APHIS_Cattle:
                        this.speciesControl = new STXQuickTag_Cattle();
                        break;
                    case Species.ETAS_Sheep:
                        this.speciesControl = new STXQuickTag_Sheep();
                        break;
                    case Species.AIMs:
                        this.speciesControl = new STXQuickTag_Aims();
                        break;
                    default:
                        break;
                }
                if (this.speciesControl != null)
                {
                    this.speciesControl.setSourceCallback(this.setSource);
                    this.pSpecies.Controls.Add((UserControl)this.speciesControl);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setSource(ATagFormat tagFormat)
        {
            try
            {
                SetDVGSource setdvg = new SetDVGSource(this.setdgvSource);
                this.Invoke(setdvg, new object[] { tagFormat });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setdgvSource(ATagFormat tagFormat)
        {
            try
            {
                if (tagFormat == null)
                    return;
                this.tagFormat = tagFormat;
                this.dgvSTX.DataSource = this.tagFormat.getSource();
                this.dgvSTX.Columns[0].Width = 476;
                this.dgvSTX.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void fillData(DMProductionOrder order, Formatter formatter, string parseFile)
        {
            try
            {
                Parser parser = new Parser(parseFile, ref order);
                parser.Parse();
                fillSTXData fstxd = new fillSTXData(fill);
                this.Invoke(fstxd, new object[] { order, formatter });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void fill(DMProductionOrder order, Formatter formatter)
        {
            try
            {
                this.setSpecies(formatter.Species);
                this.speciesControl.setProductionOrder(order);
                this.productionOrder = order;
                this.btnExportSTX.Enabled = true;
                this.btnAppendSTX.Enabled = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearAll()
        {
            try
            {
                if(this.speciesControl != null)
                    this.speciesControl.clearAll();
                this.tagFormat = null;
                this.dgvSTX.DataSource = null;
                this.productionOrder = null;
                this.disableButtons();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void disableButtons()
        {
            this.btnExportSTX.Enabled = false;
            this.btnAppendSTX.Enabled = false;
        }

        protected void btnExportSTX_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    throw new Exception("Nothing to save!");

                //DialogResult result = this.sfdCreate.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                string path = this._defaultPath + @"\newjob.txt";
                //string path = @"C:\Lasercad\STX\newjob.stx"; // here we need the configured path
                    if (path != String.Empty && path != "")
                    {
                        using (StreamWriter sw = new StreamWriter(path,false))
                        {
                            foreach (String line in this.tagFormat.print())
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                MessageBox.Show(path + Environment.NewLine + " succesfully written", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.orderProd();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnAppendSTX_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    throw new Exception("Nothing to save!");

                string path = this._defaultPath + @"\newjob.txt";
                //DialogResult result = this.sfdAppend.ShowDialog();
                //if (result == DialogResult.OK)
                {
                    if (path != String.Empty && path != "")
                    {
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            foreach (String line in this.tagFormat.print())
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    MessageBox.Show(path + Environment.NewLine + " succesfully appended", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.orderProd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setOrderProducedCallback(orderProduced callback)
        {
            try
            {
                this.orderProd = callback;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
