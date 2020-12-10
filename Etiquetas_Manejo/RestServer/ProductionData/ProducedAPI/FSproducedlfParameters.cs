using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductionData
{
    public class FSproducedlfParameters
    {
        [DataMember(Name = "Enabled", IsRequired = false)]
        public bool Enabled { get; set; }
    }
}
