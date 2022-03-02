using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Helpers.SpaceMappers;
//using HVACExporter.Helpers.ZoneMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using HVACExporter.Models.Zones;
using System.Collections.Generic;
using Surface = HVACExporter.Models.Zone.Surface;

namespace HVACExporter.Helpers
{
    class ZoneMapper
    {
        //private static Zone zoneToAdd;

        public static Zones MapAllZones
            (FilteredElementCollector allSpaces, Document doc, FilteredElementCollector allAnalyticalSurfaces, 
            FilteredElementCollector allAnalyticalSpaces, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            var allZones = new Zones();

            int n = 0;
            List<EnergyAnalysisSpace> energyAnalysisSpaces = new List<EnergyAnalysisSpace>();
            foreach (EnergyAnalysisSpace space in allAnalyticalSpaces)
            {
                energyAnalysisSpaces.Add(space);
            }

            foreach (SpatialElement zone in allSpaces)
            {
                if (zone.Category.Name != "Spaces") continue;

                var associatedSpace = (Autodesk.Revit.DB.Mechanical.Space)zone;

                Coordinate point;
                if (associatedSpace.Location == null)
                {
                    point = null;
                }
                else
                {
                    double x = ((LocationPoint)associatedSpace.Location).Point.X;
                    double y = ((LocationPoint)associatedSpace.Location).Point.Y;
                    double z = ((LocationPoint)associatedSpace.Location).Point.Z;
                    point = new Coordinate(x, y, z);
                }

                string zoneType;
                if (associatedSpace.SpaceType.ToString() == string.Empty)
                {
                    zoneType = "NA";
                }
                else
                {
                    zoneType = associatedSpace.SpaceType.ToString();
                }

                string id = associatedSpace.UniqueId;
                double ceilingHeight = associatedSpace.UnboundedHeight;
                double floorArea = associatedSpace.Area;
                double zoneVolume = (associatedSpace.UnboundedHeight - associatedSpace.Level.Elevation) * floorArea;
                string intConvAlg = "0";
                string outConvAlg = "0";
                string includedInTotArea = "0";
                string analyticalZoneId = energyAnalysisSpaces[n].Id.ToString();

                List<Surface> surfaces = SurfaceMapper.MapSurfaces(analyticalZoneId, doc, allAnalyticalSurfaces, allAnalyticalSubSurfaces);
                
                //Internal Gains:
                //Equiptment equiptment = EquiptmentMapper.MapEquiptment(room);
                //Lighting lighting = LightingMapper.MapLighting(room);
                //People people = PeopleMapper.MapPeople(room);

                //HVAC:
                //AirLoadSystem airLoadSystem = AirLoadSystemMapper.MapAirLoadSystem(room);
                //Thermostat thermostat = ThermostatMapper.MapThermostat(room);

                //Infiltration infiltration = InfiltrationMapper.MapInfiltration(room);
                //ShadingBuilding shadingBuilding = ShadingBuildingMapper.MapShadingBuilding(room);


                var zoneToAdd = new Zone(id, 
                                     point,
                                     zoneType,
                                     ceilingHeight,
                                     floorArea,
                                     zoneVolume,
                                     intConvAlg,
                                     outConvAlg,
                                     includedInTotArea, 
                                     analyticalZoneId,
                                     surfaces);

                allZones.AddZone(zoneToAdd);

                n++;
            }

            return allZones;
        }
    }
}