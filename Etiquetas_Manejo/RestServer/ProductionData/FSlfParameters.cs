using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProductionData
{
    public enum LF_technology
    {
        EM4x05,
        HTu,
        HDXplus,
        SIC7999,
        HDX,
        FDXB,
        NotDetected
    };


    public enum LF_lockType
    {
        NotApplicable = 0,
        Cerrado = 1,
        Abierto_Normal = 2,
        Vethica_RW_I = 4,
        Cerrado_DM = 8
    };

    public class FSlfParameters
    {
        [DataMember(Name = "Disabled", IsRequired = false)]
        public bool Disabled { get; set; }

        [DataMember(Name = "Reading", IsRequired = false)]
        public bool Reading { get; set; }

        [DataMember(Name = "Programming", IsRequired = false)]
        public bool Programming { get; set; }

        [DataMember(Name = "Technology", IsRequired = false)]
        public LF_technology Technology { get; set; }

        [DataMember(Name = "LockMask", IsRequired = false)]
        public LF_lockType LockMask { get; set; }
    }
}
