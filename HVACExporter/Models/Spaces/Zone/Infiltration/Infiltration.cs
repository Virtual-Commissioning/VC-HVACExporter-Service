using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Infiltration
{
    public class Infiltration
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string ZoneId { get; set; }
        public string InfiltrationSchedule { get; set; }
        public string CalculationMethod { get; set; }
        public double FlowPrExhaustSurfaceArea { get; set; }
        public double ConstantTermCoefficient { get; set; }
        public double TempTermCoefficient { get; set; }
        public double VelocityTermCoefficient { get; set; }
        public double VelocityTermSqCoefficient { get; set; }


        public Infiltration(string id, string tag, string zoneId, string infiltrationSchedule, string calculationMethod, double flowPrExhaustSurfaceArea, double constantTermCoefficient, double tempTermCoefficient, double velocityTermCoefficient, double velocityTermSqCoefficient)
        {
            Id = id;
            Tag = tag;
            ZoneId = zoneId;
            InfiltrationSchedule = infiltrationSchedule;
            CalculationMethod = calculationMethod;
            FlowPrExhaustSurfaceArea = flowPrExhaustSurfaceArea;
            ConstantTermCoefficient = constantTermCoefficient;
            TempTermCoefficient = tempTermCoefficient;
            VelocityTermCoefficient = velocityTermCoefficient;
            VelocityTermSqCoefficient = velocityTermSqCoefficient;
        }
    }
}