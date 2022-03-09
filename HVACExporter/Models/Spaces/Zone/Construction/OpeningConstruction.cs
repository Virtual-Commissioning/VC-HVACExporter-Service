using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class OpeningConstruction
    {
        public string Id { get; set; }
        public string AirExchangeMethod { get; set; }
        public string SimpleMixingAirChangesPerHour { get; set; }
        public string SimpleMixingScheduleName { get; set; }

        public OpeningConstruction(string id,string airExchangeMethod, string simpleMixingAirChangesPerHour, string simpleMixingScheduleName)
        {
            Id = id;
            AirExchangeMethod = airExchangeMethod;
            SimpleMixingAirChangesPerHour = simpleMixingAirChangesPerHour;
            SimpleMixingScheduleName = simpleMixingScheduleName;
        }
    }
}