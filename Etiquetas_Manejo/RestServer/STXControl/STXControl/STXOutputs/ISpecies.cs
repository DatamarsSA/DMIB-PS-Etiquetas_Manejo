using ProductionData;
using STXControl.TagFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.STXOutputs
{
    public delegate void SetDVGSource(ATagFormat tagformat);

    public enum Species
    {
        APHIS_Cattle,
        ETAS_Sheep,
        AIMs
    }

    public interface ISpecies
    {
        void setSourceCallback(SetDVGSource callback);
        void setProductionOrder(DMProductionOrder order);
        void clearAll();
    }
}
