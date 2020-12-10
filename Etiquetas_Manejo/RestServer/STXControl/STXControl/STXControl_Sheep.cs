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
using System.IO;
using DMServiceLibrary;

namespace STXControl
{
    public partial class STXControl_Sheep: UserControl
    {
        delegate void fillSTXData(DMProductionOrder order);
        delegate void showSTXCancellation(String id);
       
        private DMProductionOrder productionOrder = null;
        private ATagFormat tagFormat = null;
        private String password = null;
        private String username = null;
        private String encodedCredential = null;
        private String endpointProduced = null;
        private String endpointError = null;
        private bool produced = false;
        private bool release = false;

        // Controls GroupBoxes
        private GroupBox gbBarcode = null;
        private GroupBox gbEDM = null;
        private GroupBox gbPrefix = null;
        private GroupBox gbFixedLength = null;
        private GroupBox gbButtonTag = null;
        private GroupBox gbTagFasterSingle = null;


        // Controlls CheckBoxes
        private CheckBox cbIncludeBarcode = null;
        private CheckBox cbIncludePrefix = null;
        private CheckBox cbIncludeSpace = null;
        private CheckBox cbInclude = null;
        private CheckBox cbPrefixBarcode = null;


        // Controls RadioButtons
        private RadioButton rbEDMi = null;
        private RadioButton rbButtonTag = null;


        // Control NumericUpDown
        private NumericUpDown nudFixedLength = null;


        public STXControl_Sheep()
        {
            InitializeComponent();    
        }

        public void setCredentials(String username, String password)
        {
            try
            {
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                {
                    this.username = username;
                    this.password = password;
                }
                else
                    throw new Exception("No Credentials given!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setCredentials(String encodedCredential)
        {
            try
            {
                if (!String.IsNullOrEmpty(encodedCredential))
                {
                    this.encodedCredential = encodedCredential;
                }
                else
                    throw new Exception("No Credentials given!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setEnpointProduced(String endpoint)
        {
            try
            {
                if (!String.IsNullOrEmpty(endpoint))
                    this.endpointProduced = endpoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setEnpointError(String endpoint)
        {
            try
            {
                if (!String.IsNullOrEmpty(endpoint))
                    this.endpointError = endpoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showCancellation(String id)
        {
            try
            {
                showSTXCancellation cancel = new showSTXCancellation(showCancel);
                this.Invoke(cancel, new object[] { id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void showCancel(String id)
        {
            try
            {
                this.clearAll();
                this.disableButtons();
                MessageBox.Show("Order: " + id + "\nhas been canceled.", "Order Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fillData(DMProductionOrder order)
        {
            try
            {
                fillSTXData fstxd = new fillSTXData(fill);
                this.Invoke(fstxd, new object[] { order });
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void fill(DMProductionOrder order)
        {
            try
            {
                this.productionOrder = order;
                this.setInfo();
                this.tagFormat = null;
                this.rbEDM.Checked = true;
                this.btnExportSTX.Enabled = true;
                this.btnAppendSTX.Enabled = true;
                this.btnRelease.Enabled = true;
                this.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setInfo()
        {
            try
            {
                this.txtOrderID.Text = this.productionOrder.Id;
                this.txtCustomer.Text = this.productionOrder.Customer;
                this.txtDispatch.Text = DateTime.Now.ToLongDateString();
                this.txtSource.Text = this.productionOrder.Properties.AuthorisationType;
                this.txtTagType.Text = this.productionOrder.ComponentSet;
                this.txtComments.Text = "";
                this.txtNoTags.Text = this.productionOrder.NoOfTags.ToString();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setDgvSource()
        {
            try
            {
                this.setOptions();
                this.dgvSTX.DataSource = this.tagFormat.getSource();
                this.dgvSTX.Columns[0].Width = 476;
                this.dgvSTX.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void clearAll()
        {
            try
            {
                this.txtOrderID.Text = String.Empty;
                this.txtCustomer.Text = String.Empty;
                this.txtDispatch.Text = String.Empty;
                this.txtSource.Text = String.Empty;
                this.txtTagType.Text = String.Empty;
                this.txtComments.Text = String.Empty;
                this.txtNoTags.Text = String.Empty;
                this.rbEDM.Checked = true;
                this.tagFormat = null;
                this.dgvSTX.DataSource = null;
                this.productionOrder = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void disableButtons()
        {
            this.btnProduced.Enabled = false;
            this.btnRelease.Enabled = false;
            this.btnExportSTX.Enabled = false;
            this.btnAppendSTX.Enabled = false;
        }

        private void setOptions()
        {
            try
            {
                foreach(ATagOption option in this.tagFormat.getOptions())
                {
                    //TODO
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void setRestCredential(RestClient client)
        {
            if (!String.IsNullOrEmpty(this.username) && !String.IsNullOrEmpty(this.password))
                client.setCredentials(this.username, this.password);
            if (!String.IsNullOrEmpty(this.encodedCredential))
                client.setCredentials(this.encodedCredential);
        }

        private void btnExportSTX_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    throw new Exception("Nothing to save!");

                DialogResult result = this.sfdCreate.ShowDialog();
                if (result == DialogResult.OK) { 
                    if (this.sfdCreate.FileName != String.Empty && this.sfdCreate.FileName != "")
                    {
                        using (StreamWriter sw = new StreamWriter(this.sfdCreate.FileName))
                        {
                            foreach (String line in this.tagFormat.print())
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    this.btnProduced.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAppendSTX_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tagFormat == null)
                    throw new Exception("Nothing to save!");

                DialogResult result = this.sfdAppend.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.sfdAppend.FileName != String.Empty && this.sfdAppend.FileName != "")
                    {
                        using (StreamWriter sw = new StreamWriter(this.sfdAppend.FileName, true))
                        {
                            foreach (String line in this.tagFormat.print())
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    this.btnProduced.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProduced_Click(object sender, EventArgs e)
        {
            try
            {
                this.bgwProduced.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                this.bgwRelease.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwProduced_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.productionOrder == null)
                {
                    throw new Exception("No Order available");
                }
                
                String id = "[\"" + this.productionOrder.Id + "\"]";
                RestClient client = new RestClient(this.endpointProduced, RestClient.HttpVerb.POST, id);
                this.setRestCredential(client);
                client.MakeRequest();
                this.produced = true;
            }
            catch (Exception ex)
            {
                this.produced = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwProduced_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.produced)
            {
                return;
            }
            this.disableButtons();
            this.clearAll();
            MessageBox.Show("Order successfully produced.", "Production Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bgwRelease_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.productionOrder == null)
                    throw new Exception("No Order available");
                
                String id = "[\"id\":\"" + this.productionOrder.Id + "\",\"message\":\"manual error\"]";
                RestClient client = new RestClient(this.endpointError, RestClient.HttpVerb.POST, id);
                this.setRestCredential(client);
                client.MakeRequest();
                this.release = true;
            }
            catch (Exception ex)
            {
                this.release = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bgwRelease_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.release)
                return;

            this.disableButtons();
            this.clearAll();
            MessageBox.Show("An error was successfully reported.", "Error Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Tagformat Easy Dual Mini
        private void createControlsForTFEDM()
        {
            try
            {
                this.gbBarcode = new GroupBox();
                this.gbBarcode.Text = "Barcode";
                this.gbBarcode.Location = new Point(17, 196);
                this.gbBarcode.Size = new Size(203, 45);
                this.cbIncludeBarcode = new CheckBox();
                this.cbIncludeBarcode.Text = "Include Barcode";
                this.cbIncludeBarcode.Location = new Point(6, 19);
                this.cbIncludeBarcode.Size = new Size(80, 17);
                this.gbBarcode.Controls.Add(this.cbIncludeBarcode);
                this.Controls.Add(this.gbBarcode);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void destroyControlForTFEDM()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Tagformat Button
        private void createControlsForBT()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void destroyControlForBT()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tagformat TagFaster Single
        private void createControlsForTFTFS()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void destroyControlForTFTFS()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tagformat TagFaster Pairs
        private void createControlsForTFTFP()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void destroyControlForTFTFP()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tagformat Eazy Tags
        private void createControlsForTFET()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void destroyControlForTFET()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
