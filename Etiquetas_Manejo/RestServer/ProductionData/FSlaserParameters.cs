using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    [DataContract]
    public class FSlaserParameters
    {
        [DataMember(Name = "LayoutName", IsRequired = true)]
        public String LayoutName { get; set; }

        //[DataMember(Name = "Power", IsRequired = false)]
        //public String Power { get; set; }

        //[DataMember(Name = "Frequency", IsRequired = false)]
        //public String Frequency { get; set; }

        //[DataMember(Name = "Speed", IsRequired = false)]
        //public String Speed { get; set; }
    }
}