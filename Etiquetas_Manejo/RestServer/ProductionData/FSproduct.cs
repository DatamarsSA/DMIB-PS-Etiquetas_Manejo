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
    public class product
    {
        public enum business_line_enum  // Product in OS
        {
            PID,
            LID,
            TID,
            OTHER
        };


        [DataMember(Name = "name", IsRequired = false)]
        public string name { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "aliases", IsRequired = false)]
        public List<string> aliases { get; set; }

        [DataMember(Name = "family", IsRequired = false)]
        public ProductFamily family { get; set; }

        [DataMember(Name = "business_line", IsRequired = false)]
        public business_line_enum business_line { get; set; }

        [DataMember(Name = "dimension", IsRequired = false)]
        public string dimension { get; set; }

        [DataMember(Name = "shape", IsRequired = false)]
        public ProductShape shape { get; set; }

        [DataMember(Name = "identification_type", IsRequired = false)]
        public string identification_type { get; set; }

        [DataMember(Name = "electronic_type", IsRequired = false)]
        public string electronic_type { get; set; }

        [DataMember(Name = "colors", IsRequired = false)]
        public List<ProductColor> colors { get; set; }

        [DataMember(Name = "image_url", IsRequired = false)]
        public string image_url { get; set; }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<product>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(product));
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
