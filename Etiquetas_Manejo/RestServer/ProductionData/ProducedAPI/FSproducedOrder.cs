using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ProductionData
{

    [DataContract]
    public class FSproducedOrder
    {
        [DataMember(Name = "ProdLineItemNum", IsRequired = true)]
        public String ProdLineItemNum { get; set; }

        [DataMember(Name = "AssignmentID", IsRequired = false)]
        public String AssignmentID { get; set; }

        [DataMember(Name = "User", IsRequired = false)]
        public string User { get; set; }

        [DataMember(Name = "ProdMachine", IsRequired = false)]
        public string ProdMachine { get; set; }

        [DataMember(Name = "ItemType", IsRequired = false)]
        public String ItemType { get; set; }

        /*[DataMember(Name = "LfParameters", IsRequired = false)]
        public FSproducedlfParameters LfParameters { get; set; }

        [DataMember(Name = "UhfParameters", IsRequired = false)]
        public FSproduceduhfParameters UhfParameters { get; set; }

        [DataMember(Name = "Lasers", IsRequired = false)]
        public List<FSproducedlaser> Lasers { get; set; }

        [DataMember(Name = "Printers", IsRequired = false)]
        public List<FSproducedprinter> Printers { get; set; }*/

        [DataMember(Name = "ProducedItems", IsRequired = true)]
        public List<FSproducedItems> ProducedItems { get; set; }


        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSproducedOrder>));

                using (MemoryStream stream = new MemoryStream())
                {
                    ser.WriteObject(stream, this);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        ret = sr.ReadToEnd();
                    }
                }
                return ret;
            }
            catch (Exception ex)
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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSproducedOrder));
                using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
