using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    [DataContract]
    public class DProperties
    {
        [DataMember(Name = "TagIdentity", IsRequired = false)]
        public String TagIdentity { get; set; }

        [DataMember(Name = "TagNo", IsRequired = false)]
        public String TagNo { get; set; }

        [DataMember(Name = "FlockNo", IsRequired = false)]
        public String FlockNo { get; set; }
    }
}
