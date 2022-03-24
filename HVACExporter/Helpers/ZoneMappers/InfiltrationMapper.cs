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
            double? designFlowRate = null;
            double? flowPerZoneFloorArea = null;
            double? flowPrExteriorSurfaceArea = null;
            double? airChangesPerHour = null;
            double? ConstantTermCoefficient = null;
            double? tempTermCoefficient = null;
            double? velocityTermCoefficient = null;
            double? velocityTermSqCoefficient = null;

            Infiltration infiltration = new Infiltration(id, zoneId, infiltrationSchedule, calculationMethod,
                designFlowRate, flowPerZoneFloorArea, flowPrExteriorSurfaceArea, airChangesPerHour,
                ConstantTermCoefficient, tempTermCoefficient, velocityTermCoefficient,
                velocityTermSqCoefficient);
            return infiltration;
        }
    }
}
