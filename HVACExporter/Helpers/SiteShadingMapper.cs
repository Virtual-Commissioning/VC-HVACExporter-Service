using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace HVACExporter.Helpers
{
    public class SiteShadingMapper
    {
        public static List<ShadingSite> MapSiteShading(Document doc)
        {
            List <ShadingSite> shadingSite = new List<ShadingSite>();
            string id = "Shading_Building";
            string transmSchedule = "NA";
            VertexCoordinates vertexCoordinates = null;
            ShadingSite shadingSite1 = new ShadingSite(id, transmSchedule, vertexCoordinates);
            shadingSite.Add(shadingSite1);

            return shadingSite;
        }
    }
}
