using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
namespace ProductionData
{
    public enum Laser_type
    {
        Laser,
        Inkjet,
        Hotstamp,
        PureBlack,
        Undefined
    };

    [DataContract]
    public class FSlaser
    {
        [DataMember(Name = "Disabled", IsRequired = false)]
        public bool Disabled { get; set; }

        [DataMember(Name = "LaserType", IsRequired = false)]
        public Laser_type LaserType { get; set; }

        [DataMember(Name = "IsFront", IsRequired = false)]
        public bool IsFront { get; set; }

        [DataMember(Name = "LayoutName", IsRequired = true)]
        public String LayoutName { get; set; }

        [DataMember(Name = "LaserVars", IsRequired = false)]
        public List<FSlaserVars> LaserVars { get; set; }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSlaser>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSlaser));
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
