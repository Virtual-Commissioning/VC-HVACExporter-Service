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
        public string ZoneId { get; set; }
        public string HeatingSetpointSchedule { get; set; }
        public string CoolingSetpointSchedule { get; set; }

        public Thermostat(string id, string zoneId, string heatingSetpointSchedule, string coolingSetpointSchedule)
        {
            Id = id;
            ZoneId = zoneId;
            HeatingSetpointSchedule = heatingSetpointSchedule;
            CoolingSetpointSchedule = coolingSetpointSchedule;
        }
    }
}