using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    [DataContract]
    public class FSauthProperties
    {
        [DataMember(Name = "AuthorisationTypeId", IsRequired = false)]
        public String AuthorisationTypeId { get; set; }

        [DataMember(Name = "AuthorisationType", IsRequired = false)]
        public String AuthorisationType { get; set; }

    }
}
