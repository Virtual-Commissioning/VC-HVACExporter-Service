using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Infiltration
    {
        public string Id { get; set; }
        public string ZoneId { get; set; }
        public string InfiltrationSchedule { get; set; }
        public string CalculationMethod { get; set; }
        public double DesignFlowRate { get; set; }
        public double FlowPerZoneFloorArea { get; set; }
        public double FlowPerExteriorSurfaceArea { get; set; }
        public double AirChangesPerHour { get; set; }
        public double ConstantTermCoefficient { get; set; }
        public double TempTermCoefficient { get; set; }
        public double VelocityTermCoefficient { get; set; }
        public double VelocityTermSqCoefficient { get; set; }


        public Infiltration(string id, string zoneId, string infiltrationSchedule, string calculationMethod, 
            double designFlowRate, double flowPerZoneFloorArea, double flowPrExteriorSurfaceArea, double airChangesPerHour,
            double constantTermCoefficient, double tempTermCoefficient, 
            double velocityTermCoefficient, double velocityTermSqCoefficient)
        {
            Id = id;
            ZoneId = zoneId;
            InfiltrationSchedule = infiltrationSchedule;
            CalculationMethod = calculationMethod;
            DesignFlowRate = designFlowRate;
            FlowPerZoneFloorArea = flowPerZoneFloorArea;
            FlowPerExteriorSurfaceArea = flowPrExteriorSurfaceArea;
            AirChangesPerHour = airChangesPerHour;
            ConstantTermCoefficient = constantTermCoefficient;
            TempTermCoefficient = tempTermCoefficient;
            VelocityTermCoefficient = velocityTermCoefficient;
            VelocityTermSqCoefficient = velocityTermSqCoefficient;
        }
    }
}