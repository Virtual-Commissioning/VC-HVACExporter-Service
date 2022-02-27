using Autodesk.Revit.DB;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class DoorConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllDoors(FilteredElementCollector allDoors, Autodesk.Revit.DB.Document doc)   //(Autodesk.Revit.DB.Document doc, Wall walls)    
        {
            var surfaceConstructions = new List<SurfaceConstruction>();

            foreach (FamilyInstance door in allDoors)
            {
                string constructionId = door.UniqueId;
                string analyticalConstructionId = door.GetAnalyticalModelId().ToString();
                string name = door.Name;

                string materialId = door.UniqueId;
                string layerId = "0";

                var constructionLayers = new List<ConstructionLayer>();
                var constructionLayerToAdd = new ConstructionLayer(materialId, layerId);
                constructionLayers.Add(constructionLayerToAdd);

                var surfaceConstructionToAdd = new SurfaceConstruction(constructionId, analyticalConstructionId, name, constructionLayers);
                surfaceConstructions.Add(surfaceConstructionToAdd);

            }

            return surfaceConstructions;
        }
    }
}
