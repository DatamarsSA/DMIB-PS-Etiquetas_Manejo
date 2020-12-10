using ProductionData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DMServiceLibrary
{
    public delegate void NewOrderDataAvailable();
    public delegate void OrderCancellation(string id);
    public class WCFRestServer : IWCFRestServer
    {
        private static bool _inProduction = false;
        private static bool _inPause = true;
        private static List<DMProductionOrder> productionOrders = new List<DMProductionOrder>();
        private static List<FSProductionOrder> FSproductionOrders = new List<FSProductionOrder>();
        private WebServiceHost _host = null;
        private static NewOrderDataAvailable newData = null;
        private static NewOrderDataAvailable FSnewData = null;
        private static OrderCancellation orderCancel = null;
        private static OrderCancellation FSorderCancel = null;

        public WCFRestServer()
        {
            try
            {
                this._host = new WebServiceHost(typeof(DMServiceLibrary.WCFRestServer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void open()
        {
            this._host.Open();
        }

        public void close()
        {
            if (this._host != null)
                this._host.Close();
        }

        public void setNewOrderDataAvailableCallback(NewOrderDataAvailable callback)
        {
            newData = callback;
        }

        public void setNewFSOrderDataAvailableCallback(NewOrderDataAvailable callback)
        {
            FSnewData = callback;
        }

        public void setOrderCancellationCallback(OrderCancellation callback)
        {
            orderCancel = callback;
        }

        public void setFSOrderCancellationCallback(OrderCancellation callback)
        {
            FSorderCancel = callback;
        }

        public bool CreateProduction(DMProductionOrder[] orders)
        {
            try
            {
                if(_inProduction)
                    throw new WebFaultException(System.Net.HttpStatusCode.Forbidden);

                productionOrders.Clear();
                foreach(DMProductionOrder order in orders)
                {
                    productionOrders.Add(order);
                }
                if (newData != null)
                {
                    _inProduction = true;
                    new Task(callNewData).Start();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CancelProduction(string[] ids)
        {
            try
            {
                if (orderCancel != null)
                {
                    _inProduction = false;
                    new Task(() => { orderCancel(ids[0]); }).Start();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool FS_CreateProduction(FSProductionOrder[] orders)
        {
            try
            {
                if (_inProduction)
                    throw new WebFaultException(System.Net.HttpStatusCode.Forbidden);

                FSproductionOrders.Clear();
                foreach (FSProductionOrder order in orders)
                {
                    FSproductionOrders.Add(order);
                }
                if (FSnewData != null)
                {
                    _inProduction = true;
                    _inPause = true; // the job is not started yet
                    new Task(FScallNewData).Start();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool FS_CancelProduction(string[] ids)
        {
            try
            {
                if (_inPause == false)
                    throw new WebFaultException(System.Net.HttpStatusCode.Forbidden);
                if (FSorderCancel != null)
                {
                    _inProduction = false;
                    _inPause = true;
                    new Task(() => { FSorderCancel(ids[0]); }).Start();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DMProductionOrder> getProductionOrders()
        {
            if (productionOrders.Count == 0)
                return null;
            return productionOrders;
        }

        public List<FSProductionOrder> FSgetProductionOrders()
        {
            if (FSproductionOrders.Count == 0)
                return null;
            return FSproductionOrders;
        }

        public bool InProduction
        {
            get
            {
                return _inProduction;
            }
            set
            {
                _inProduction = value;
            }
        }

        public bool InPause
        {
            get
            {
                return _inPause;
            }
            set
            {
                _inPause = value;
            }
        }

        private void callNewData()
        {
            newData();
        }

        private void FScallNewData()
        {
            FSnewData();
        }

        private void callOrderCancel(string id)
        {
            orderCancel(id);
        }
    }
}

