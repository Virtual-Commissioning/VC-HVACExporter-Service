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
    class BuildingMapper
    {
        public static List<Dictionary<string, Building>> MapAllBuildings(Document doc, FilteredElementCollector allSpaces, FilteredElementCollector allAnalyticalSurfaces, FilteredElementCollector allAnalyticalSpaces, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            List<Dictionary<string, Building>> buildings = new List<Dictionary<string, Building>>();

            ProjectInfo projectInfo = doc.ProjectInformation;
            ProjectLocation plCurrent = doc.ActiveProjectLocation;
            if (plCurrent != null)
            {
                string name = projectInfo.BuildingName;
                XYZ origin = new XYZ(0,0,0);
                string northAxis = plCurrent.GetProjectPosition(origin).Angle.ToString();
                string terrain = "";
                string loadsConvergenceToleranceValue = "";
                string temperatureConvergenceToleranceValue = "";
                string solarDistribution = "";
                string maxNumberOfWarmupDays = "";
                string minNumberOfWarmupDays = "";
                List<Dictionary<string, Zone>> zones = ZoneMapper.MapAllZones(allSpaces, doc, allAnalyticalSurfaces, allAnalyticalSpaces, allAnalyticalSubSurfaces);
                Building building1 = new Building(name, northAxis, terrain, loadsConvergenceToleranceValue, temperatureConvergenceToleranceValue, solarDistribution, maxNumberOfWarmupDays, minNumberOfWarmupDays, zones);
                Dictionary<string, Building> linkedBuilding = new Dictionary<string, Building>();
                linkedBuilding.Add(name, building1);
                buildings.Add(linkedBuilding);
            }

            return buildings;
        }
    }
}
