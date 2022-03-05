using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class PeopleMapper
    {
        public static People MapPeople(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "People";
            string zoneId = associatedSpace.Id.ToString();
            string peopleSchedule = "NA";
            string calculationMethod = "NA";
            int numberOfPeople = 1;
            double fractionRadiant = 0;
            double sensibleHeatFraction = 0;
            string activitySchedule = "NA";
            double co2GenerationRate = 0;
            string mrtCalculationType = "NA";
            string surfaceId = "NA";
            string workEfficiencySchedule = "NA";
            string clothingInsulationSchedule = "NA";
            string airVelocitySchedule = "NA";
            string thermalComfortType = "NA";

            People peopleGains = new People(id, zoneId, peopleSchedule, calculationMethod,
                numberOfPeople, fractionRadiant, sensibleHeatFraction, activitySchedule,
                co2GenerationRate, mrtCalculationType, surfaceId, workEfficiencySchedule,
                clothingInsulationSchedule, airVelocitySchedule, thermalComfortType);
            return peopleGains;
        }
    }
}
