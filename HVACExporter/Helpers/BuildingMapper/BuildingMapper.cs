using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using HVACExporter.Models.Zones;
using System;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class BuildingMapper
    {
        public static List<Dictionary<string, Building>> MapAllBuildings(Document doc, FilteredElementCollector allSpaces, 
            FilteredElementCollector allAnalyticalSurfaces, FilteredElementCollector allAnalyticalSpaces, 
            FilteredElementCollector allAnalyticalSubSurfaces, FilteredElementCollector allMasses,
            FilteredElementCollector allWalls, ExternalCommandData commandData)
        {
            List<Dictionary<string, Building>> buildings = new List<Dictionary<string, Building>>();

            ProjectInfo projectInfo = doc.ProjectInformation;
            ProjectLocation plCurrent = doc.ActiveProjectLocation;
            if (plCurrent != null)
            {
                string name = projectInfo.BuildingName;
                XYZ origin = new XYZ(0,0,0);
                double? rotation = Math.Round(plCurrent.GetProjectPosition(origin).Angle * 180 / Math.PI, 1);
                string northAxis;
                if (rotation < 0)
                {
                    northAxis = (360 + rotation).ToString().Replace(',', '.');
                }
                else
                {
                    northAxis = rotation.ToString().Replace(',', '.');
                }
                string terrain = "";
                string loadsConvergenceToleranceValue = "";
                string temperatureConvergenceToleranceValue = "";
                string solarDistribution = "";
                string maxNumberOfWarmupDays = "";
                string minNumberOfWarmupDays = "";
                List<Dictionary<string, Zone>> zones = ZoneMapper.MapAllZones(allSpaces, doc, allAnalyticalSurfaces, allAnalyticalSpaces, allAnalyticalSubSurfaces);
                List<Dictionary<string, ShadingBuilding>> buildingShadings = BuildingShadingMapper.MapBuildingShading(allSpaces, allWalls, doc, commandData);

                Building building1 = new Building(name, northAxis, terrain, loadsConvergenceToleranceValue, 
                    temperatureConvergenceToleranceValue, solarDistribution, maxNumberOfWarmupDays, minNumberOfWarmupDays, zones, buildingShadings);
                Dictionary<string, Building> linkedBuilding = new Dictionary<string, Building>();
                linkedBuilding.Add(name, building1);
                buildings.Add(linkedBuilding);
            }

            return buildings;
        }
    }
}
