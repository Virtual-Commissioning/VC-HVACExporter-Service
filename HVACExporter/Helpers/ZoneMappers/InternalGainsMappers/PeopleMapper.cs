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
        public static List<People> MapPeople(string analyticalZoneId)
        {
            List<People> people = new List<People>();
            string id = "Zone" + analyticalZoneId + "_" + "People";
            string zoneId = analyticalZoneId;
            string peopleSchedule = "";
            string calculationMethod = "";
            int? numberOfPeople = null;
            double? fractionRadiant = null;
            double? sensibleHeatFraction = null;
            string activitySchedule = "";
            double? co2GenerationRate = null;
            string enableAshare55ComfortWarnings = "";
            string mrtCalculationType = "";
            string surfaceId = "";
            string workEfficiencySchedule = "";
            string clothingInsulationCalculationMethod = "";
            string clothingInsulationSchedule = "";
            string airVelocitySchedule = "";
            string thermalComfortType = "";

            People peopleGains = new People(id, zoneId, peopleSchedule, calculationMethod,
                numberOfPeople, fractionRadiant, sensibleHeatFraction, activitySchedule,
                co2GenerationRate, enableAshare55ComfortWarnings, mrtCalculationType, surfaceId, workEfficiencySchedule,
                clothingInsulationCalculationMethod, clothingInsulationSchedule, airVelocitySchedule, thermalComfortType);
            people.Add(peopleGains);
            return people;
        }
    }
}
