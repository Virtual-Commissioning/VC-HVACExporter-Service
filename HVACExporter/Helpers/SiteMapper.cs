using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
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
        public static Site MapSite(Document doc, FilteredElementCollector allSpaces, FilteredElementCollector allAnalyticalSurfaces, 
            FilteredElementCollector allAnalyticalSpaces, FilteredElementCollector allAnalyticalSubSurfaces,
            FilteredElementCollector allMasses, FilteredElementCollector allWalls, ExternalCommandData commandData)
        {
            string name = "";
            string latitude = "";
            string longitude = "";
            string timeZone = "";
            string elevation = "";
            List<Dictionary<string, Building>> buildings = BuildingMapper.MapAllBuildings
                (doc, allSpaces, allAnalyticalSurfaces, allAnalyticalSpaces, allAnalyticalSubSurfaces, allMasses, allWalls, commandData);
            List<Dictionary<string, ShadingSite>> shadingSite = SiteShadingMapper.MapSiteShading(allMasses);
            Site site = new Site(name, latitude, longitude, timeZone, elevation, buildings, shadingSite);

            return site;
        }
    }
}
