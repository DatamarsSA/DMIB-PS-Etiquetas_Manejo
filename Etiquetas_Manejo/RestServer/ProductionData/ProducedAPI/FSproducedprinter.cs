using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductionData
{
    public class FSproducedprinter
    {
        [DataMember(Name = "Enabled", IsRequired = false)]
        public bool Enabled { get; set; }

        [DataMember(Name = "PrinterType", IsRequired = false)]
        public Printer_type PrinterType { get; set; }

        [DataMember(Name = "PrinterLayout", IsRequired = true)]
        public String PrinterLayout { get; set; }
    }
}
