using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ProductionData
{

    [DataContract]
    public class ProductionOrder : IResponseData
    {

        [DataMember(Name = "orderId", IsRequired = false)]
        public int OrderId { get; set; }
     

        [DataMember(Name = "orderName", IsRequired = false)]
        public string OrderName { get; set; }


        // -1 -> canceled, 0 -> pending, 1 -> started
        [DataMember(Name = "orderStatus", IsRequired = false)]
        public int OrderStatus { get; set; }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ProductionOrder));

                using (MemoryStream stream = new MemoryStream())
                {
                    ser.WriteObject(stream, this);
                    using(StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        ret = sr.ReadToEnd();
                    }
                }
                return ret;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deserialize(string message)
        {
            try
            {
                if (message == string.Empty)
                    return;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ProductionOrder));
                using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                {
                    ms.Position = 0;
                    ProductionOrder order = (ProductionOrder)ser.ReadObject(ms);
                    this.OrderId = order.OrderId;
                    this.OrderName = order.OrderName;
                    this.OrderStatus = order.OrderStatus;
                    order = null;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string toString()
        {
            string ret = "";
            ret = "Order id:\t" + this.OrderId + "\nOrder name:\t" + this.OrderName +  "\nOrder Status:\t" + this.OrderStatus +"\n\n";
            return ret;
        }
    }
}
