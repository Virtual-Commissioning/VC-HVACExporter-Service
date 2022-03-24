using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class ThermostatMapper
    {
        public static Thermostat MapThermostat(string analyticalZoneId)
        {
            string id = "Zone" + analyticalZoneId + "_" + "Thermostat";
            string heatingSetpointSchedule = "";
            string constantHeatingSetpoint = "";
            string coolingSetpointSchedule = "";
            string constantCoolingSetpoint = "";

            Thermostat equipmentGains = new Thermostat(id, heatingSetpointSchedule, constantHeatingSetpoint, 
                coolingSetpointSchedule, constantCoolingSetpoint);
            return equipmentGains;
        }
    }
}
