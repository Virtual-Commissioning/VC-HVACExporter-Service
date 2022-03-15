using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class InfiltrationMapper
    {
        public static Infiltration MapInfiltration(string analyticalZoneId)
        {
            string id = "Zone" + analyticalZoneId + "_" + "Infiltration";
            string zoneId = analyticalZoneId;
            string infiltrationSchedule = "";
            string calculationMethod = "";
            double designFlowRate = 0;
            double flowPerZoneFloorArea = 0;
            double flowPrExteriorSurfaceArea = 0;
            double airChangesPerHour = 0;
            double ConstantTermCoefficient = 0;
            double tempTermCoefficient = 0;
            double velocityTermCoefficient = 0;
            double velocityTermSqCoefficient = 0;

            Infiltration infiltration = new Infiltration(id, zoneId, infiltrationSchedule, calculationMethod,
                designFlowRate, flowPerZoneFloorArea, flowPrExteriorSurfaceArea, airChangesPerHour,
                ConstantTermCoefficient, tempTermCoefficient, velocityTermCoefficient,
                velocityTermSqCoefficient);
            return infiltration;
        }
    }
}
