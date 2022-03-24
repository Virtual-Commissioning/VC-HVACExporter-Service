using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class People
    {
        public string Name { get; set; }
        public string Zone_or_ZoneList_or_Space_or_SpaceList_Name { get; set; }
        public string Number_of_People_Schedule_Name { get; set; }
        public string Number_of_People_Calculation_Method { get; set; }
        public int? Number_of_People { get; set; }
        public double? Fraction_Radiant { get; set; }
        public double? Sensible_Heat_Fraction { get; set; }
        public string Activity_Level_Schedule_Name { get; set; }
        public double? Carbon_Dioxide_Generation_Rate { get; set; }
        public string Enable_ASHRAE_55_Comfort_Warnings { get; set; }
        public string Mean_Radiant_Temperature_Calculation_Type { get; set; }
        public string Surface_NameAngle_Factor_List_Name { get; set; }
        public string Work_Efficiency_Schedule_Name { get; set; }
        public string Clothing_Insulation_Calculation_Method { get; set; }
        public string Clothing_Insulation_Schedule_Name { get; set; }
        public string Air_Velocity_Schedule_Name { get; set; }
        public string Thermal_Comfort_Model_1_Type { get; set; }

        public People(string id, string zoneName, string peopleSchedule, string calculationMethod, int? numberOfPeople, 
            double? fractionRadiant, double? sensibleHeatFraction, string activitySchedule, double? co2GenerationRate, 
            string enableAshare55ComfortWarnings, string mRTCalculationType, string surfaceId, string workEfficiencySchedule, 
            string clothingInsulationCalculationMethod, string clothingInsulationSchedule, string airVelocitySchedule, string thermalComfortType)
        {
            Name = id;
            Zone_or_ZoneList_or_Space_or_SpaceList_Name = zoneName;
            Number_of_People_Schedule_Name = peopleSchedule;
            Number_of_People_Calculation_Method = calculationMethod;
            Number_of_People = numberOfPeople;
            Fraction_Radiant = fractionRadiant;
            Sensible_Heat_Fraction = sensibleHeatFraction;
            Activity_Level_Schedule_Name = activitySchedule;
            Carbon_Dioxide_Generation_Rate = co2GenerationRate;
            Enable_ASHRAE_55_Comfort_Warnings = enableAshare55ComfortWarnings;
            Mean_Radiant_Temperature_Calculation_Type = mRTCalculationType;
            Surface_NameAngle_Factor_List_Name = surfaceId;
            Work_Efficiency_Schedule_Name = workEfficiencySchedule;
            Clothing_Insulation_Calculation_Method = clothingInsulationCalculationMethod;
            Clothing_Insulation_Schedule_Name = clothingInsulationSchedule;
            Air_Velocity_Schedule_Name = airVelocitySchedule;
            Thermal_Comfort_Model_1_Type = thermalComfortType;
        }
    }
}