using Autodesk.Revit.DB;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class SpaceMapper
    {
        public static Spaces MapAllSpaces(FilteredElementCollector allSpaces)
        {
            var spaces = new Spaces();

            foreach (SpatialElement space in allSpaces)
            {

                //We start of by giving the room its IDs
                var spaceId = space.UniqueId;
                var spaceTag = space.Id.ToString();

                IndoorClimateZone indoorClimateZone = IndoorClimateMapper.MapIndoorClimate();
                SpaceGeometry spaceGeometry = GeometricMapper.MapGeometry(space);

                var spaceToAdd = new Space(spaceId, spaceTag, indoorClimateZone, spaceGeometry);

                spaces.AddRoom(spaceToAdd);
            }

            return spaces;
        }
    }
}
