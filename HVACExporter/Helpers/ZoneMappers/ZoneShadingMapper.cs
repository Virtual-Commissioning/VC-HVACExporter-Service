using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class ZoneShadingMapper
    {
        public static List<ShadingZone> MapZoneShading(string analyticalZoneId)
        {
            List<ShadingZone> shadingZones = new List<ShadingZone>();
            string id = "Zone" + analyticalZoneId + "_" + "Shading";
            string baseSurfId = "";
            string transmSchedule = "";
            VertexCoordinates vertexCoordinates = null;

            ShadingZone shadingZone = new ShadingZone(id, baseSurfId, transmSchedule, vertexCoordinates);
            shadingZones.Add(shadingZone);
            return shadingZones;
        }
    }
}
