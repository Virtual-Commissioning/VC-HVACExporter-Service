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

            List<SurfaceMat> surfaceMaterials = SurfaceMaterialMapper.MapAllSurfaceMaterials(allWalls, allRoofs, allFloors, doc);
            List<SurfaceMat> airGapMaterials = AirGapMaterialMapper.MapAllMaterials(allWalls, allRoofs, allFloors, doc);
            List<DoorMat> doorMaterials = DoorMaterialMapper.MapAllDoors(allDoors, doc);
            List<WindowMat> windowMaterials = WindowMaterialMapper.MapAllWindows(allWindows, doc);

            Materials materialsToAdd = new Materials(surfaceMaterials, airGapMaterials, doorMaterials, windowMaterials);

            allMaterials.Add(materialsToAdd);

            return allMaterials;
        }
    }
}
