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
        public static List<People> MapPeople(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            List<People> people = new List<People>();
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "People";
            string zoneId = associatedSpace.Id.ToString();
            string peopleSchedule = "";
            string calculationMethod = "";
            int numberOfPeople = 0;
            double fractionRadiant = 0;
            double sensibleHeatFraction = 0;
            string activitySchedule = "";
            double co2GenerationRate = 0;
            string mrtCalculationType = "";
            string surfaceId = "";
            string workEfficiencySchedule = "";
            string clothingInsulationSchedule = "";
            string airVelocitySchedule = "";
            string thermalComfortType = "";

            People peopleGains = new People(id, zoneId, peopleSchedule, calculationMethod,
                numberOfPeople, fractionRadiant, sensibleHeatFraction, activitySchedule,
                co2GenerationRate, mrtCalculationType, surfaceId, workEfficiencySchedule,
                clothingInsulationSchedule, airVelocitySchedule, thermalComfortType);
            people.Add(peopleGains);
            return people;
        }
    }
}
