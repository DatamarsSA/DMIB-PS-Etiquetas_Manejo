using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    [DataContract]
    public class CreateOrderProperties
    {
        [DataMember(Name = "AuthorisationTypeId", IsRequired = true)]
        public String AuthorisationTypeId { get; set; }

        [DataMember(Name = "AuthorisationType", IsRequired = true)]
        public String AuthorisationType { get; set; }

        [DataMember(Name = "SalesDescriptor", IsRequired = false)]
        public String SalesDescriptor { get; set; }
    }
}
