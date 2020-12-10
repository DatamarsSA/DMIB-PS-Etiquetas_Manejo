using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    [DataContract]
    public class DMProductionOrder : IResponseData
    {
        [DataMember(Name = "NoOfTags", IsRequired = true)]
        public long NoOfTags { get; set; }

        [DataMember(Name = "Type", IsRequired = true)]
        public String Type { get; set; }

        [DataMember(Name = "Id", IsRequired = true)]
        public String Id { get; set; }

        [DataMember(Name = "Address", IsRequired = true)]
        public String Address { get; set; }

        [DataMember(Name = "Customer", IsRequired = true)]
        public String Customer { get; set; }

        [DataMember(Name = "FarmerId", IsRequired = true)]
        public String FarmerId { get; set; }

        [DataMember(Name = "ComponentSet", IsRequired = true)]
        public String ComponentSet { get; set; }

        [DataMember(Name = "Species", IsRequired = true)]
        public String Species { get; set; }

        [DataMember(Name = "Region", IsRequired = true)]
        public String Region { get; set; }

        [DataMember(Name = "Identifiers", IsRequired = true)]
        public List<CreateOrderIdentifiers> Identifiers { get; set; }

        [DataMember(Name = "Properties", IsRequired = true)]
        public CreateOrderProperties Properties { get; set; }

        [DataMember(Name = "ID", IsRequired = true)]
        public String ID { get; set; }


        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<DMProductionOrder>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DMProductionOrder));
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
