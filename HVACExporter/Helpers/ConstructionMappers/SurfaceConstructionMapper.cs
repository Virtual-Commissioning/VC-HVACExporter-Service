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
            var allSurfaceConstructions = new List<SurfaceConstruction>();

            var wallConstructions = WallConstructionMapper.MapAllWalls(allSpaces, doc);
            foreach (SurfaceConstruction surfaceConstruction in wallConstructions)
            {
                allSurfaceConstructions.Add(surfaceConstruction);
            }

            var roofConstructions = RoofConstructionMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceConstruction surfaceConstruction in roofConstructions)
            {
                allSurfaceConstructions.Add(surfaceConstruction);
            }

            var floorConstructions = FloorConstructionMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceConstruction surfaceConstruction in floorConstructions)
            {
                allSurfaceConstructions.Add(surfaceConstruction);
            }

            var windowConstructions = WindowConstructionMapper.MapAllWindows(allWindows, doc);
            foreach (SurfaceConstruction surfaceConstruction in windowConstructions)
            {
                allSurfaceConstructions.Add(surfaceConstruction);
            }

            var doorConstructions = DoorConstructionMapper.MapAllDoors(allDoors, doc);
            foreach (SurfaceConstruction surfaceConstruction in doorConstructions)
            {
                allSurfaceConstructions.Add(surfaceConstruction);
            }

            return allSurfaceConstructions;
         }

    }
}
