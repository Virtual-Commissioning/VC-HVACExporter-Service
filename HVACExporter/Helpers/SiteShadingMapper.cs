using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class SiteShadingMapper
    {
        public static ShadingSite MapSiteShading(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "Shading_Site";
            string transmSchedule = "NA";
            VertexCoordinates vertexCoordinates = null;

            ShadingSite shadingSite = new ShadingSite(id, transmSchedule, vertexCoordinates);
            return shadingSite;
        }
    }
}
