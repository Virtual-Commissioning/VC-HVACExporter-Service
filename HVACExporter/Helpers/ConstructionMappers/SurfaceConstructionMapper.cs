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
        public static List<Dictionary<string, SurfaceConstruction>> MapAllSurfaceConstructions(FilteredElementCollector allSpaces, FilteredElementCollector allWalls,
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, FilteredElementCollector allWindows, 
            FilteredElementCollector allDoors, Document doc)
        {
            List<Dictionary<string, SurfaceConstruction>> allSurfaceConstructions = new List<Dictionary<string, SurfaceConstruction>>();
            List<Dictionary<string, SurfaceConstruction>> wallConstructions = WallConstructionMapper.MapAllWalls(allSpaces, doc);
            List<Dictionary<string, SurfaceConstruction>> roofConstructions = RoofConstructionMapper.MapAllRoofs(allRoofs, doc);
            List<Dictionary<string, SurfaceConstruction>> floorConstructions = FloorConstructionMapper.MapAllFloors(allFloors, doc);
            List<Dictionary<string, SurfaceConstruction>> windowConstructions = WindowConstructionMapper.MapAllWindows(allWindows, doc);
            List<Dictionary<string, SurfaceConstruction>> doorConstructions = DoorConstructionMapper.MapAllDoors(allDoors, doc);

            allSurfaceConstructions.AddRange(wallConstructions);
            allSurfaceConstructions.AddRange(roofConstructions);
            allSurfaceConstructions.AddRange(floorConstructions);
            allSurfaceConstructions.AddRange(windowConstructions);
            allSurfaceConstructions.AddRange(doorConstructions);

            return allSurfaceConstructions;
         }

    }
}
