using Autodesk.Revit.DB;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class DoorConstructionMapper
    {
        public static List<Dictionary<string, SurfaceConstruction>> MapAllDoors(FilteredElementCollector allDoors, Autodesk.Revit.DB.Document doc)  
        {
            List<Dictionary<string, SurfaceConstruction>> surfaceConstructions = new List<Dictionary<string, SurfaceConstruction>>();

            foreach (FamilyInstance door in allDoors)
            {
                string constructionId = door.Id.ToString();
                string materialId = door.Id.ToString();
                string layerId = "Layer1";

                List<Dictionary<string, string>> constructionLayers = new List<Dictionary<string, string>>();
                Dictionary<string, string> constructionLayerToAdd = new Dictionary<string, string>();
                constructionLayerToAdd.Add(layerId, materialId);
                constructionLayers.Add(constructionLayerToAdd);
                SurfaceConstruction surfaceConstructionToAdd = new SurfaceConstruction(constructionId, constructionLayers);

                Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction = new Dictionary<string, SurfaceConstruction>();
                linkedSurfaceConstruction.Add(constructionId, surfaceConstructionToAdd);
                surfaceConstructions.Add(linkedSurfaceConstruction);
            }

            return surfaceConstructions;
        }
    }
}
