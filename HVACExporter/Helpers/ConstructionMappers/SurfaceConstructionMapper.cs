using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace HVACExporter.Helpers
{
    public class SurfaceConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllSurfaceConstructions(FilteredElementCollector allSpaces, FilteredElementCollector allWalls,
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, FilteredElementCollector allWindows, 
            FilteredElementCollector allDoors, Document doc)
        {
            List<SurfaceConstruction> allSurfaceConstructions = new List<SurfaceConstruction>();
            var wallConstructions = WallConstructionMapper.MapAllWalls(allSpaces, doc);
            var roofConstructions = RoofConstructionMapper.MapAllRoofs(allRoofs, doc);
            var floorConstructions = FloorConstructionMapper.MapAllFloors(allFloors, doc);
            var windowConstructions = WindowConstructionMapper.MapAllWindows(allWindows, doc);
            var doorConstructions = DoorConstructionMapper.MapAllDoors(allDoors, doc);

            allSurfaceConstructions.AddRange(wallConstructions);
            allSurfaceConstructions.AddRange(roofConstructions);
            allSurfaceConstructions.AddRange(floorConstructions);
            allSurfaceConstructions.AddRange(windowConstructions);
            allSurfaceConstructions.AddRange(doorConstructions);

            return allSurfaceConstructions;
         }

    }
}
