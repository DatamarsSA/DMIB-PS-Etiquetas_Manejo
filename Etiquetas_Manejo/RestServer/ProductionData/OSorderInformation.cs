using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    [DataContract]
    public class OSorderInformation
    {
        [DataMember(Name = "id", IsRequired = false)]
        public String id { get; set; }

        [DataMember(Name = "number", IsRequired = false)]
        public String number { get; set; }

        [DataMember(Name = "content", IsRequired = false)]
        public List<OSorderInformation> content{ get; set; }


        //[DataMember(Name = "FarmerId", IsRequired = false)]
        //public String FarmerId { get; set; }

        //[DataMember(Name = "Region", IsRequired = false)]
        //public String Region { get; set; }

        //[DataMember(Name = "Species", IsRequired = false)]
        //public String Species { get; set; }
    }
}
