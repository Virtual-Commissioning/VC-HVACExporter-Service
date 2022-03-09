using Autodesk.Revit.DB;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using HVACExporter.Models.Zones;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class SiteMapper
    {
        public static Site MapSite(Document doc, FilteredElementCollector allSpaces, FilteredElementCollector allAnalyticalSurfaces, FilteredElementCollector allAnalyticalSpaces, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            string name = "";
            string latitude = "";
            string longitude = "";
            string timeZone = "";
            string elevation = "";
            List<Dictionary<string, Building>> buildings = BuildingMapper.MapAllBuildings(doc, allSpaces, allAnalyticalSurfaces, allAnalyticalSpaces, allAnalyticalSubSurfaces);
            List<ShadingSite> shadingSite = SiteShadingMapper.MapSiteShading(doc);
            Site site = new Site(name, latitude, longitude, timeZone, elevation, buildings, shadingSite);

            return site;
        }
    }
}
