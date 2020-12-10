using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductionData
{
    [DataContract]
    public class UHF_Items
    {
        [DataMember(Name = "R", IsRequired = false)]
        public bool R { get; set; }

        [DataMember(Name = "W", IsRequired = false)]
        public bool W { get; set; }

        [DataMember(Name = "retagging", IsRequired = false)]
        public int retagging { get; set; }

        [DataMember(Name = "EPC", IsRequired = true)]
        public String EPC { get; set; }

        [DataMember(Name = "TID", IsRequired = false)]
        public String TID { get; set; }
    }
}
