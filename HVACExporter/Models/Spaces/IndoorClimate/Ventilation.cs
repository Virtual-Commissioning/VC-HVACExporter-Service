using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class Ventilation
    {
        public ValueMatrix AirFlow { get; set; }
        public ValueMatrix AirTemp { get; set; }

        public Ventilation(ValueMatrix airFlow, ValueMatrix airTemp)
        {
            AirFlow = airFlow;
            AirTemp = airTemp;
        }
    }
}
