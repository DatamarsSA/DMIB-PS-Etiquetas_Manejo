using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductionData
{
    public class FSproducedlaser
    {
        [DataMember(Name = "Enabled", IsRequired = false)]
        public bool Enabled { get; set; }

        [DataMember(Name = "LaserType", IsRequired = false)]
        public Laser_type LaserType { get; set; }

        [DataMember(Name = "IsFront", IsRequired = false)]
        public bool IsFront { get; set; }

        [DataMember(Name = "LayoutName", IsRequired = true)]
        public String LayoutName { get; set; }
    }
}
