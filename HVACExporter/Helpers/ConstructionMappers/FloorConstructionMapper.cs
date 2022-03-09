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
        public static List<Dictionary<string, SurfaceConstruction>> MapAllFloors(FilteredElementCollector allFloors, Autodesk.Revit.DB.Document doc)
        {
            List<Dictionary<string, SurfaceConstruction>> surfaceConstructions = new List<Dictionary<string, SurfaceConstruction>>();

            foreach (Floor floor in allFloors)
            {
                string constructionId = floor.Id.ToString();

                CompoundStructure structure = floor.FloorType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                List<Dictionary<string, string>> constructionLayers = new List<Dictionary<string, string>>();
                foreach (CompoundStructureLayer layer in layers)
                {
                    int layerId = layer.LayerId + 1;
                    string layerName = "Layer" + layerId.ToString();
                    string materialId = layer.MaterialId.ToString();
                    Dictionary<string, string> layerValues = new Dictionary<string, string>();
                    layerValues.Add(layerName, materialId);
                    constructionLayers.Add(layerValues);

                    SurfaceConstruction surfaceConstructionToAdd = new SurfaceConstruction(constructionId, constructionLayers);
                    Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction = new Dictionary<string, SurfaceConstruction>();
                    linkedSurfaceConstruction.Add(constructionId, surfaceConstructionToAdd);
                    surfaceConstructions.Add(linkedSurfaceConstruction);
                }
            }

            return surfaceConstructions;
        }
    }
}
