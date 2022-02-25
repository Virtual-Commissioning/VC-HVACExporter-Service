/*
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Helpers.SpaceMappers;
//using HVACExporter.Helpers.ZoneMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Surface = HVACExporter.Models.Zone.Surface;

namespace HVACExporter.Helpers
{
    class ZoneMapper
    {
        //private static Zone zoneToAdd;

        public static Zones MapAllZones(IList<Room> allRooms)
        {
            var zones = new Zones();

            foreach (Room room in allRooms)
            {
                //We start of by giving the room its IDs
                string id = room.UniqueId;
                string tag = room.Id.ToString();

                //Finding the coordinates of origin point
                double x = ((LocationPoint)room.Location).Point.X;
                double y = ((LocationPoint)room.Location).Point.Y;
                double z = ((LocationPoint)room.Location).Point.Z;
                Models.GeometricTypes.Coordinate point = new Models.GeometricTypes.Coordinate(x, y, z);

                string zoneType = "NA";
                double ceilingHeight = room.UnboundedHeight; //- room.Level.Elevation;
                double floorArea = room.Area;
                double zoneVolume = (room.UnboundedHeight - room.Level.Elevation) * floorArea;  //room.Volume;
                string intConvAlg = "NA";
                string outConvAlg = "NA";
                string includedInTotArea = "NA";

                
                //Surface surface = SurfaceMapper.MapSurface(room);
                
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
                                     tag,
                                     point,
                                     zoneType,
                                     ceilingHeight,
                                     floorArea,
                                     zoneVolume,
                                     intConvAlg,
                                     outConvAlg,
                                     includedInTotArea);

                zones.AddRoom(zoneToAdd);
            }

            return zones;
        }
    }
}
*/