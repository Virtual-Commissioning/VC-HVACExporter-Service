using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Spaces.Zone;
using HVACExporter.Models.Zone;
using System;
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
                string constructionId2 = floor.Id.ToString() + "_Adjacent";

                CompoundStructure structure = floor.FloorType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                List<Dictionary<string, string>> constructionLayers = new List<Dictionary<string, string>>();
                List<Dictionary<string, string>> constructionLayers2 = new List<Dictionary<string, string>>();
                foreach (CompoundStructureLayer layer in layers)
                {
                    //Filtering away materials without thermal properties
                    Material layerMaterial = doc.GetElement(layer.MaterialId) as Material;
                    ElementId thermalAssetId = layerMaterial.ThermalAssetId;
                    PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                    if (pse == null) continue;
                    int layerId = layer.LayerId + 1;
                    int layerId2 = layers.Count - layerId + 1;
                    string layerName = "Layer" + layerId.ToString();
                    string layerName2 = "Layer" + layerId2;
                    double thickness;
                    if (layer.Width == 0)
                    {
                        thickness = 0.001;
                    }
                    else
                    {
                        thickness = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(layer.Width), 3);
                    }
                    string preMaterialId = layer.MaterialId.ToString() + "_" + thickness;
                    string materialId = preMaterialId.Replace(',', '.');
                    Dictionary<string, string> layerValues = new Dictionary<string, string>();
                    Dictionary<string, string> layerValues2 = new Dictionary<string, string>();
                    layerValues.Add(layerName, materialId);
                    layerValues2.Add(layerName2, materialId);
                    constructionLayers.Add(layerValues);
                    constructionLayers2.Insert(0, layerValues2);

                    SurfaceConstruction surfaceConstructionToAdd = new SurfaceConstruction(constructionId, constructionLayers);
                    SurfaceConstruction surfaceConstructionToAdd2 = new SurfaceConstruction(constructionId2, constructionLayers2);
                    Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction = new Dictionary<string, SurfaceConstruction>();
                    Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction2 = new Dictionary<string, SurfaceConstruction>();
                    linkedSurfaceConstruction.Add(constructionId, surfaceConstructionToAdd);
                    linkedSurfaceConstruction2.Add(constructionId2, surfaceConstructionToAdd2);
                    surfaceConstructions.Add(linkedSurfaceConstruction);
                    surfaceConstructions.Add(linkedSurfaceConstruction2);
                }
            }
            return surfaceConstructions;
        }
    }
}
