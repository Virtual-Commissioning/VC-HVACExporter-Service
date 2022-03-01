using Autodesk.Revit.DB;
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

        public static Zones MapAllZones(FilteredElementCollector allSpaces, Document doc, FilteredElementCollector allAnalyticalSurfaces)
        {
            var allZones = new Zones();

            foreach (SpatialElement zone in allSpaces)
            {
                if (zone.Category.Name != "Spaces") continue;

                var associatedSpace = (Autodesk.Revit.DB.Mechanical.Space)zone;
                
                if (associatedSpace.Location == null) continue;


                //We start of by giving the room its IDs
                string id = associatedSpace.UniqueId;

                //Finding the coordinates of origin point
                double x = ((LocationPoint)associatedSpace.Location).Point.X;
                double y = ((LocationPoint)associatedSpace.Location).Point.Y;
                double z = ((LocationPoint)associatedSpace.Location).Point.Z;
                Models.GeometricTypes.Coordinate point = new Models.GeometricTypes.Coordinate(x, y, z);

                //if (zone.SpaceType != null) continue;
                string zoneType = "NA";

                double ceilingHeight = associatedSpace.UnboundedHeight; //- room.Level.Elevation;
                double floorArea = associatedSpace.Area;
                double zoneVolume = (associatedSpace.UnboundedHeight - associatedSpace.Level.Elevation) * floorArea;  //room.Volume;
                string intConvAlg = "0";
                string outConvAlg = "0";
                string includedInTotArea = "0";

                
                List<Surface> surface = SurfaceMapper.MapSurfaces(zone, doc, allAnalyticalSurfaces);
                
                //Surface surface = RoomGeometryMapper.MapRoomGeometry(room);
                //SubSurface subSurface = SubSurfaceMapper.MapSubSurface(room);

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
                                     includedInTotArea);

                allZones.AddZone(zoneToAdd);
            }

            return allZones;
        }
    }
}