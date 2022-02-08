using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.People
{
    public class People
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string PeopleSchedule { get; set; }
        public string CalculatinMethod { get; set; }
        public int NumberOfPeople { get; set; }
        public double FractionRadiant { get; set; }
        public double SensibleHeatFraction { get; set; }
        public string ActivitySchedule { get; set; }
        public double CO2GenerationRate { get; set; }
        public string MRTCalculationType { get; set; }
        public string SurfaceId { get; set; }
        public string WorkEfficiencySchedule { get; set; }
        public string ClothingInsulationSchedule { get; set; }
        public string AirVelocitySchedule { get; set; }
        public string ThermalComfortType { get; set; }

        public People(string id, string tag, string peopleSchedule, CalculationMethod calculationMethod, int numberOfPeople, double fractionRadiant, double sensibleHeatFraction, string activitySchedule, double co2GenerationRate, MRTCalculationType mRTCalculationType, string surfaceId, string workEfficiencySchedule, string clothingInsulationSchedule, string airVelocitySchedule, string thermalComfortType)
        {
            Id = id;
            Tag = tag;
            PeopleSchedule = peopleSchedule;
            CalculatinMethod = calculationMethod;
            NumberOfPeople = numberOfPeople;
            FractionRadiant = fractionRadiant;
            SensibleHeatFraction = sensibleHeatFraction;
            ActivitySchedule = activitySchedule;
            MRTCalculationType = mRTCalculationType;
            SurfaceId = surfaceId;
            WorkEfficiencySchedule = workEfficiencySchedule;
            ClothingInsulationSchedule = clothingInsulationSchedule;
            AirVelocitySchedule = airVelocitySchedule;
            ThermalComfortType = thermalComfortType;
        }
    }
}