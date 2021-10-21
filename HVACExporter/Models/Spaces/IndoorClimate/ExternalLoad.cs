using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class ExternalLoad
    {
        public double HeatLoad { get; set; }

        public ExternalLoad(double heatLoad)
        {
            HeatLoad = heatLoad;
        }
    }
}
