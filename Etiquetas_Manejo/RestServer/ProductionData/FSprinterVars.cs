using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ProductionData
{
    [DataContract]
    public class FSprinterVars
    {

        [DataMember(Name = "VarType", IsRequired = true)]
        public String VarType { get; set; }

        [DataMember(Name = "VarName", IsRequired = false)]
        public String VarName { get; set; }

        [DataMember(Name = "VarValue", IsRequired = true)]
        public String VarValue { get; set; }



        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSprinterVars>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSprinterVars));
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
