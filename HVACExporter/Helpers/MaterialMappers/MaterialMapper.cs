using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using HVACExporter.Helpers;


namespace HVACExporter.Helpers
{
    public class MaterialMapper
    {
        public static List<Materials> MapAllMaterials(FilteredElementCollector allWalls,
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, 
            FilteredElementCollector allDoors, FilteredElementCollector allWindows,  Document doc)
        {
            List<Materials> allMaterials = new List<Materials>();

            List<Dictionary<string, SurfaceMat>> surfaceMaterials = SurfaceMaterialMapper.MapAllSurfaceMaterials(allWalls, allRoofs, allFloors, doc);
            List<Dictionary<string, AirGapMat>> airGapMaterials = AirGapMaterialMapper.MapAllMaterials(allWalls, allRoofs, allFloors, doc);
            List<Dictionary<string, DoorMat>> doorMaterials = DoorMaterialMapper.MapAllDoors(allDoors, doc);
            List<Dictionary<string, WindowMat>> windowMaterials = WindowMaterialMapper.MapAllWindows(allWindows, allWalls, doc);

            Materials materialsToAdd = new Materials(surfaceMaterials, airGapMaterials, doorMaterials, windowMaterials);

            allMaterials.Add(materialsToAdd);

            return allMaterials;
        }
    }
}
