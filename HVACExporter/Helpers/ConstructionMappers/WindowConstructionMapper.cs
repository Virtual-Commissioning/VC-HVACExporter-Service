using Autodesk.Revit.DB;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class WindowConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllWindows(FilteredElementCollector allWindows, Autodesk.Revit.DB.Document doc)   //(Autodesk.Revit.DB.Document doc, Wall walls)    
        {
            var surfaceConstructions = new List<SurfaceConstruction>();

            foreach (FamilyInstance window in allWindows)
            {
                ElementId windowSymbol = window.Symbol.Id;

                string constructionId = window.UniqueId;
                string analyticalConstructionId = window.GetAnalyticalModelId().ToString();
                string name = window.Name;

                string materialId = window.UniqueId;
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
