using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class LightingLoad
    {
        public ValueMatrix HeatloadPrSqM { get; set; }

        public LightingLoad(ValueMatrix heatloadPrSqM)
        {
            HeatloadPrSqM = heatloadPrSqM;
        }
    }
}
