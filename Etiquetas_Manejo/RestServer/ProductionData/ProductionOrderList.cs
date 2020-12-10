using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    static public class ProductionOrderList
    {
        static public List<ProductionOrder> deserialize(string list)
        {
            try
            {
                if (list  == String.Empty)
                    return null;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<ProductionOrder>));
                using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(list)))
                {
                    ms.Position = 0;
                    List<ProductionOrder> orderList = (List<ProductionOrder>)ser.ReadObject(ms);
                    return orderList;       
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public string toString(List<ProductionOrder> list)
        {
            string ret = string.Empty;
            foreach(ProductionOrder order in list)
            {
                ret += order.toString();
            }
            return ret;
        }
    }
}
