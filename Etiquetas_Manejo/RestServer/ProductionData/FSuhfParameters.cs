using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    public class FSuhfParameters
    {
        //[DataMember(Name = "UHFstationType", IsRequired = false)]
        //public int UHFstationType { get; set; }

        [DataMember(Name = "Disabled", IsRequired = false)]
        public bool Disabled { get; set; }

        [DataMember(Name = "Reading", IsRequired = false)]
        public bool Reading { get; set; }

        [DataMember(Name = "Programming", IsRequired = false)]
        public bool Programming { get; set; }

        [DataMember(Name = "AccessPassword", IsRequired = false)]
        public string AccessPassword { get; set; }

        [DataMember(Name = "KillPassword", IsRequired = false)]
        public string KillPassword { get; set; }
    }
}
