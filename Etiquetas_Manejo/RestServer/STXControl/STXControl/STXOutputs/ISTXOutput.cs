using ProductionData;
using STXControl.TagFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.STXOutputs
{
    public enum Driver
    {
        QuickTag
    }

    public interface ISTXOutput
    {
        void fillData(DMProductionOrder order, Formatter formatter, string parserFile);
        void setOrderProducedCallback(STXOutputQuickTag.orderProduced callback);
        void clearAll();
    }
}
