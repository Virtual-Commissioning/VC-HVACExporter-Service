using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Thermostat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string HeatingSetpointSchedule { get; set; }
        public string CoolingSetpointSchedule { get; set; }

        public Thermostat(string id, string tag, string heatingSetpointSchedule, string coolingSetpointSchedule)
        {
            Id = id;
            Tag = tag;
            HeatingSetpointSchedule = heatingSetpointSchedule;
            CoolingSetpointSchedule = coolingSetpointSchedule;
        }
    }
}