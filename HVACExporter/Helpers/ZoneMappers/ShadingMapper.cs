using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class ZoneShadingMapper
    {
        public static ShadingZone MapZoneShading(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "Shading";
            string baseSurfId = associatedSpace.Id.ToString();
            string transmSchedule = "NA";
            VertexCoordinates vertexCoordinates = null;

            ShadingZone shadingZone = new ShadingZone(id, baseSurfId, transmSchedule, vertexCoordinates);
            return shadingZone;
        }
    }
}
