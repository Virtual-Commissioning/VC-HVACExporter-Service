using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class InfiltrationMapper
    {
        public static Infiltration MapInfiltration(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "Infiltration";
            string zoneId = associatedSpace.Id.ToString();
            string infiltrationSchedule = "NA";
            string calculationMethod = "NA";
            double flowPrExhaustSurfaceArea = 0;
            double ConstantTermCoefficient = 0;
            double tempTermCoefficient = 0;
            double velocityTermCoefficient = 0;
            double velocityTermSqCoefficient = 0;

            Infiltration infiltration = new Infiltration(id, zoneId, infiltrationSchedule, calculationMethod,
                flowPrExhaustSurfaceArea, ConstantTermCoefficient, tempTermCoefficient, velocityTermCoefficient,
                velocityTermSqCoefficient);
            return infiltration;
        }
    }
}
