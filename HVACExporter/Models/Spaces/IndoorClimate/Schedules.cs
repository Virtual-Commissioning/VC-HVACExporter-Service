using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class Schedules
    {
        public Schedule PeopleSchedule { get; set; }
        public Schedule EquipmentSchedule { get; set; }
        public Schedule LightingSchedule { get; set; }
        public Schedule ExternalSchedule { get; set; }

        public Schedules(Schedule peopleSchedule, Schedule equipmentSchedule, Schedule lightingSchedule, Schedule externalSchedule)
        {
            PeopleSchedule = peopleSchedule;
            EquipmentSchedule = equipmentSchedule;
            LightingSchedule = lightingSchedule;
            ExternalSchedule = externalSchedule;
        }
    }
}
