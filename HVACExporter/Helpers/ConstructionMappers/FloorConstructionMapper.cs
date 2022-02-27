using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class FloorConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllFloors(FilteredElementCollector allFloors, Autodesk.Revit.DB.Document doc)   //(Autodesk.Revit.DB.Document doc, Wall walls)    
        {
            var surfaceConstructions = new List<SurfaceConstruction>();

            foreach (Floor floor in allFloors)
            {
                string constructionId = floor.UniqueId;
                string analyticalConstructionId = floor.GetAnalyticalModelId().ToString();
                string name = floor.FloorType.Name;

                CompoundStructure structure = floor.FloorType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();


                var constructionLayers = new List<ConstructionLayer>();
                foreach (CompoundStructureLayer layer in layers)
                {
                    string layerId = layer.LayerId.ToString();

                    Material layerWallMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string materialId = layerWallMaterial.UniqueId;

                    var constructionLayerToAdd = new ConstructionLayer(materialId, layerId);

                    constructionLayers.Add(constructionLayerToAdd);

                    var surfaceConstructionToAdd = new SurfaceConstruction(constructionId, analyticalConstructionId, name, constructionLayers);

                    surfaceConstructions.Add(surfaceConstructionToAdd);
                }
            }

            return surfaceConstructions;
        }
    }
}
