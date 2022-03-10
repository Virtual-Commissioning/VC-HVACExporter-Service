using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class ZoneShadingMapper
    {
        public static List<ShadingZone> MapZoneShading(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            List<ShadingZone> shadingZones = new List<ShadingZone>();
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "Shading";
            string baseSurfId = "NA";
            string transmSchedule = "NA";
            VertexCoordinates vertexCoordinates = null;

            ShadingZone shadingZone = new ShadingZone(id, baseSurfId, transmSchedule, vertexCoordinates);
            shadingZones.Add(shadingZone);
            return shadingZones;
        }
    }
}
