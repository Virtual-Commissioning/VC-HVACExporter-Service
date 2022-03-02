using Autodesk.Revit.DB;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class RoofConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllRoofs(FilteredElementCollector allRoofs, Autodesk.Revit.DB.Document doc)
        {
            List<SurfaceConstruction> surfaceConstructions = new List<SurfaceConstruction>();

            foreach (RoofBase roof in allRoofs)
            {
                string constructionId = roof.UniqueId;
                string analyticalConstructionId = roof.GetAnalyticalModelId().ToString();
                string name = roof.RoofType.Name;

                CompoundStructure structure = roof.RoofType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                List<ConstructionLayer> constructionLayers = new List<ConstructionLayer>();
                foreach (CompoundStructureLayer layer in layers)
                {
                    string layerId = layer.LayerId.ToString();
                    string materialId = layer.MaterialId.ToString();
                    ConstructionLayer constructionLayerToAdd = new ConstructionLayer(materialId, layerId);
                    constructionLayers.Add(constructionLayerToAdd);

                    SurfaceConstruction surfaceConstructionToAdd = new SurfaceConstruction(constructionId, analyticalConstructionId, name, constructionLayers);
                    surfaceConstructions.Add(surfaceConstructionToAdd);
                }
            }

            return surfaceConstructions;

        }
    }
}
