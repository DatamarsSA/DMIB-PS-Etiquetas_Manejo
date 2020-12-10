using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionData
{
    interface IResponseData
    {
        string serialize();
        void deserialize(string message);
    }
}
