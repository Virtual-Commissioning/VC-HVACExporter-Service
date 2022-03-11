using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Thermostat
    {
        public string Name { get; set; }
        public string Heating_Setpoint_Schedule_Name { get; set; }
        public string Constant_Heating_Setpoint { get; set; }
        public string Cooling_Setpoint_Schedule_Name { get; set; }
        public string Constant_Cooling_Setpoint { get; set; }

        public Thermostat(string name, string heatingSetpointSchedule, string constantHeatingSetpoint, 
            string coolingSetpointSchedule, string constantCoolingSetpoint)
        {
            Name = name;
            Heating_Setpoint_Schedule_Name = heatingSetpointSchedule;
            Constant_Heating_Setpoint = constantHeatingSetpoint;
            Cooling_Setpoint_Schedule_Name=coolingSetpointSchedule;
            Constant_Cooling_Setpoint = constantCoolingSetpoint;
        }
    }
}