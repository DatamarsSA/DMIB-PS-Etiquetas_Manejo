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
    public class FSproducedItems
    {
        [DataMember(Name = "LineNumber", IsRequired = false)]
        public int LineNumber { get; set; }

        [DataMember(Name = "ItemType", IsRequired = false)]
        public String ItemType { get; set; }

        [DataMember(Name = "AuthCode", IsRequired = false)]
        public String AuthCode { get; set; }

        [DataMember(Name = "Auth_retagging", IsRequired = false)]
        public int Auth_retagging { get; set; }

        [DataMember(Name = "LF_Items", IsRequired = false)]
        public LF_Items LF_Items { get; set; }

        [DataMember(Name = "UHF_Items", IsRequired = false)]
        public UHF_Items UHF_Items { get; set; }

        [DataMember(Name = "LaserVars", IsRequired = false)]
        public List<FSlaserVars> LaserVars { get; set; }

        [DataMember(Name = "ReworkReason", IsRequired = false)]
        public string ReworkReason { get; set; }


        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSproducedItems>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSproducedItems));
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
