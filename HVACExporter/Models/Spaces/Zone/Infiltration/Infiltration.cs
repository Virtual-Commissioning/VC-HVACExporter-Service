using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Infiltration
    {
        public string Name { get; set; }
        public string Zone_or_ZoneList_Name { get; set; }
        public string Schedule_Name { get; set; }
        public string Design_Flow_Rate_Calculation_Method { get; set; }
        public double Design_Flow_Rate { get; set; }
        public double Flow_per_Zone_Floor_Area { get; set; }
        public double Flow_per_Exterior_Surface_Area { get; set; }
        public double Air_Changes_per_Hour { get; set; }
        public double Constant_Term_Coefficient { get; set; }
        public double Temperature_Term_Coefficient { get; set; }
        public double Velocity_Term_Coefficient { get; set; }
        public double Velocity_Squared_Term_Coefficient { get; set; }


        public Infiltration(string name, string zoneId, string infiltrationSchedule, string calculationMethod, 
            double designFlowRate, double flowPerZoneFloorArea, double flowPrExteriorSurfaceArea, double airChangesPerHour,
            double constantTermCoefficient, double tempTermCoefficient, 
            double velocityTermCoefficient, double velocityTermSqCoefficient)
        {
            Name = name;
            Zone_or_ZoneList_Name = zoneId;
            Schedule_Name = infiltrationSchedule;
            Design_Flow_Rate_Calculation_Method = calculationMethod;
            Design_Flow_Rate = designFlowRate;
            Flow_per_Zone_Floor_Area = flowPerZoneFloorArea;
            Flow_per_Exterior_Surface_Area = flowPrExteriorSurfaceArea;
            Air_Changes_per_Hour = airChangesPerHour;
            Constant_Term_Coefficient = constantTermCoefficient;
            Temperature_Term_Coefficient = tempTermCoefficient;
            Velocity_Term_Coefficient = velocityTermCoefficient;
            Velocity_Squared_Term_Coefficient = velocityTermSqCoefficient;
        }
    }
}