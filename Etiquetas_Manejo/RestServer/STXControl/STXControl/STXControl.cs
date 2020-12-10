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
using STXControl.STXOutputs;
using System.IO;
using DMServiceLibrary;

namespace STXControl
{


    public partial class STXControl: UserControl
    {
        delegate void fillSTXData(DMProductionOrder order, Formatter formatter, string parseFile);
        delegate void showSTXCancellation(String id);
        delegate void orderProduced();
        public delegate void ProductionOrderProduced();

        private DMProductionOrder productionOrder = null;
        private String password = null;
        private String username = null;
        private String encodedCredential = null;
        private String endpointProduced = null;
        private String endpointError = null;
        private bool produced = false;
        private bool release = false;
        private ISTXOutput STXOutput = null;
        private ProductionOrderProduced signalOrderProduced = null;
        private string _defaultPath;


        public STXControl()
        {
            InitializeComponent();
            
        }
        public void setSTXpath(string defaultPath)
        {
            _defaultPath = defaultPath;
        }
        private void setSTXOutput(Driver output)
        {
            try
            {
                if (this.spcMain.Panel2.Controls.Count != 0)
                    this.spcMain.Panel2.Controls.Clear();
                switch (output)
                {
                    case Driver.QuickTag:
                        this.STXOutput = new STXOutputQuickTag(_defaultPath);
                        this.spcMain.Panel2.Controls.Add((STXOutputQuickTag)this.STXOutput);
                        this.STXOutput.setOrderProducedCallback(this.enableProducedButton);
                        break;
                    default:
                        break;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public void setOrderProduced(ProductionOrderProduced callback)
        {
            try
            {
                this.signalOrderProduced = callback;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
                //if (this.productionOrder != null)
                //{
                //    if (this.productionOrder.Id == id)
                //    {
                //        this.clearAll();
                //        this.disableButtons();
                //        MessageBox.Show("Order: " + id + "\nhas been canceled.", "Order Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //        throw new Exception("Order: " + id + " can not be canceled. Current Order Id is different!");
                //}
                //else
                //    throw new Exception("Order: " + id + " can not be canceled. No Order loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableProducedButton()
        {
            try
            {
                orderProduced prod = new orderProduced(this.enableProduced);
                this.Invoke(prod, new object[] {});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void enableProduced()
        {
            try
            {
                this.btnProduced.Enabled = true;
                this.btnProduced.BackColor = Color.ForestGreen;
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
                if (parseFile == string.Empty)
                    throw new Exception("No rule file available!");
                fillSTXData fstxd = new fillSTXData(fill);
                this.Invoke(fstxd, new object[] { order, formatter, parseFile });
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void fill(DMProductionOrder order, Formatter formatter, string parseFile)
        {
            try
            {
                this.setSTXOutput(formatter.OutputControlName);
                this.productionOrder = order;
                this.STXOutput.fillData(order, formatter, parseFile);
                this.setInfo();
                this.btnProduced.Enabled = false;
                this.btnProduced.BackColor = SystemColors.Control;
                this.btnRelease.Enabled = true;
                this.btnRelease.BackColor = Color.Orange;
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

        private void clearAll()
        {
            try
            {
                if(this.STXOutput != null)
                    this.STXOutput.clearAll();
                this.txtOrderID.Text = String.Empty;
                this.txtCustomer.Text = String.Empty;
                this.txtDispatch.Text = String.Empty;
                this.txtSource.Text = String.Empty;
                this.txtTagType.Text = String.Empty;
                this.txtComments.Text = String.Empty;
                this.txtNoTags.Text = String.Empty;
                this.productionOrder = null;
                this.spcMain.Panel2.Controls.Remove((UserControl)this.STXOutput);
                this.STXOutput = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void disableButtons()
        {
            this.btnProduced.Enabled = false;
            this.btnProduced.BackColor = SystemColors.Control;
            this.btnRelease.Enabled = false;
            this.btnRelease.BackColor = SystemColors.Control;
        }

        private void setRestCredential(RestClient client)
        {
            if (!String.IsNullOrEmpty(this.username) && !String.IsNullOrEmpty(this.password))
                client.setCredentials(this.username, this.password);
            else if (!String.IsNullOrEmpty(this.encodedCredential))
                client.setCredentials(this.encodedCredential);
        }

        private void btnProduced_Click(object sender, EventArgs e)
        {
            try
            {
                if(!this.bgwRelease.IsBusy)
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
                // FZ 20170705 given Paddy API call for release is not implemented @PS level,
                //             and we do not have the correct ID, ask user to cancel the order on PS
                if (!this.bgwRelease.IsBusy)
                    //this.bgwRelease.RunWorkerAsync();
                    MessageBox.Show("Production Lines can be released from Production Server only",
                        "Warning !",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification,
                        false);
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
                if (this.signalOrderProduced != null)
                    this.signalOrderProduced();
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

            //this.disableButtons();
            //this.clearAll();
            MessageBox.Show("An error was successfully reported.", "Error Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
