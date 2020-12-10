using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;


namespace ProductionData
{
    class OSComponentSet
    {
        [DataMember(Name = "id", IsRequired = true)]
        public long id { get; set; }

        [DataMember(Name = "name", IsRequired = true)]
        public String name { get; set; }

       
    }
}
