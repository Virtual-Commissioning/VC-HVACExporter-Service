using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.OpeningConstruction
{
    public class OpeningConstruction
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string AirExchangeMethod { get; set; }
        public double SimpleMixingACPrHour { get; set; }

        public OpeningConstruction(string id, string tag, string airExchangeMethod, double simpleMixingPrHour)
        {
            Id = id;
            Tag = tag;
            AirExchangeMethod = airExchangeMethod;
            SimpleMixingACPrHour = simpleMixingPrHour;
        }
    }
}