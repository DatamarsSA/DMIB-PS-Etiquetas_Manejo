using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductionData
{
    [DataContract]
    public class LF_Items
    {
        [DataMember(Name = "R", IsRequired = false)]
        public bool R { get; set; }

        [DataMember(Name = "W", IsRequired = false)]
        public bool W { get; set; }

        [DataMember(Name = "retagging", IsRequired = false)]
        public int retagging { get; set; }

        [DataMember(Name = "EID", IsRequired = true)]
        public String EID { get; set; }

        [DataMember(Name = "UID", IsRequired = false)]
        public String UID { get; set; }
    }
}
