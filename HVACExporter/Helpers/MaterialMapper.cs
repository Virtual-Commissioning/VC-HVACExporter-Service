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
            var allMaterials = new List<Materials>();

            var surfaceMaterials = SurfaceMaterialMapper.MapAllSurfaceMaterials(allWalls, allRoofs, allFloors, doc);
            var airGapMaterials = AirGapMaterialMapper.MapAllMaterials(allWalls, allRoofs, allFloors, doc);
            var doorMaterials = DoorMaterialMapper.MapAllDoors(allDoors, doc);
            var windowMaterials = WindowMaterialMapper.MapAllWindows(allWindows, doc);

            var materialsToAdd = new Materials(surfaceMaterials, airGapMaterials, doorMaterials, windowMaterials);

            allMaterials.Add(materialsToAdd);

            return allMaterials;
        }
    }
}
