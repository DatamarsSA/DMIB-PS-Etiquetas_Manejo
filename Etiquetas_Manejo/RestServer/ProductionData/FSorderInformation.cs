using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    [DataContract]
    public class FSorderInformation
    {
        [DataMember(Name = "Address", IsRequired = true)]
        public String Address { get; set; }

        [DataMember(Name = "Customer", IsRequired = true)]
        public String Customer { get; set; }

        //[DataMember(Name = "FarmerId", IsRequired = false)]
        //public String FarmerId { get; set; }

        //[DataMember(Name = "Region", IsRequired = false)]
        //public String Region { get; set; }

        //[DataMember(Name = "Species", IsRequired = false)]
        //public String Species { get; set; }
    }
}
