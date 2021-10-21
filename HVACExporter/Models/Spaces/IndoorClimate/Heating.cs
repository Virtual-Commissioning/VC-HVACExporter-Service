using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class Heating
    {
        public ValueMatrix MaxTemp { get; set; }
        public ValueMatrix MinTemp { get; set; }
        public ValueMatrix HeatingDemand { get; set; }

        public Heating(ValueMatrix maxTemp, ValueMatrix minTemp, ValueMatrix heatingDemand)
        {
            MaxTemp = maxTemp;
            MinTemp = minTemp;
            HeatingDemand = heatingDemand;
        }
    }
}
