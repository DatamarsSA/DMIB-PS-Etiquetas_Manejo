using DMServiceLibrary;
using ProductionData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private WCFRestServer host = null;
        List<DMProductionOrder> orders = null;
        public Form1()
        {
            InitializeComponent();
            host = new WCFRestServer();
            host.setNewOrderDataAvailableCallback(getData);
            host.setOrderCancellationCallback(orderCancel);
            
            this.stxControl.setCredentials("bm9ydGhlcm4uaXJlbGFuZDo5OGFzZDg5Z2d4cmV6MDkyNDIz");
            this.stxControl.setEnpointProduced(@"http://192.168.0.28:11001/production/v1/uk/produced");
            this.stxControl.setEnpointError(@"http://192.168.0.28:11001/production/v1/uk/error");
            this.stxControl.setOrderProduced(orderProduced);
            host.open();
        }

        private void getData()
        {
            orders = this.host.getProductionOrders();
            if (orders != null)
            {
                if(orders[0].Properties.AuthorisationTypeId == "5")
                    this.stxControl.fillData(orders[0],new STXControl.STXOutputs.Formatter(STXControl.STXOutputs.Species.Cattle, STXControl.STXOutputs.Driver.QuickTag));
                else
                    this.stxControl.fillData(orders[0], new STXControl.STXOutputs.Formatter(STXControl.STXOutputs.Species.Sheep, STXControl.STXOutputs.Driver.QuickTag));
            }
            this.orders.Clear();
        }

        private void orderCancel(String id)
        {
            host.InProduction = false;
            this.stxControl.showCancellation(id);
        }

        private void orderProduced()
        {
            host.InProduction = false;
        }
    }
}
