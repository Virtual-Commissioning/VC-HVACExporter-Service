using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class OpeningConstructionParameters
    {
        public string AirExchangeMethod { get; set; }
        public string AirMixingChangesPerHour { get; set; }
        public string SimpleMixingACPerHour { get; set; }

        public OpeningConstructionParameters(string airExchangeMethod, string airMixingChangesPerHour, string simpleMixingPerHour)
        {
            AirExchangeMethod = airExchangeMethod;
            AirMixingChangesPerHour = airMixingChangesPerHour;
            SimpleMixingACPerHour = simpleMixingPerHour;
        }
    }
}