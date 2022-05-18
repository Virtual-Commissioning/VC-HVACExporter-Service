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
    class WallConstructionMapper
    {
        public static List<Dictionary<string, SurfaceConstruction>> MapAllWalls(FilteredElementCollector allSpaces, Autodesk.Revit.DB.Document doc)
        {
            List<Dictionary<string, SurfaceConstruction>> surfaceConstructions = new List<Dictionary<string, SurfaceConstruction>>();

            foreach (SpatialElement space in allSpaces)
            {
                if (space.Category.Name != "Spaces") continue;

                IList<IList<Autodesk.Revit.DB.BoundarySegment>> segments = space.GetBoundarySegments(new SpatialElementBoundaryOptions());

                foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in segments)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                    {
                        Wall wall = doc.GetElement(boundarySegment.ElementId) as Wall;

                        if (wall != null)
                        {
                            string constructionId, constructionId2, layerName, layerName2, preMaterialId, materialId, name;
                            double thickness;
                            
                            List<Dictionary<string, string>> constructionLayers = new List<Dictionary<string, string>>();
                            List<Dictionary<string, string>> constructionLayers2 = new List<Dictionary<string, string>>();
                            if (wall.WallType.Kind.ToString() == "Curtain")
                            {
                                constructionId = "CW_" + wall.Id.ToString();
                                constructionId2 = "CW_" + wall.Id.ToString() + "_Adjacent";
                                layerName = "Layer1";
                                layerName2 = "Layer1";
                                thickness = 0;
                                name = "CW_" + wall.Id.ToString();
                                materialId = "CW_Mat_" + wall.Id.ToString();
                                Dictionary<string, string> layerValues = new Dictionary<string, string>();
                                Dictionary<string, string> layerValues2 = new Dictionary<string, string>();
                                layerValues.Add(layerName, materialId);
                                layerValues2.Add(layerName2, materialId);
                                constructionLayers.Add(layerValues);
                                constructionLayers2.Insert(0, layerValues2);
                            }
                            else
                            {
                                constructionId = wall.Id.ToString();
                                constructionId2 = wall.Id.ToString() + "_Adjacent";
                                CompoundStructure structure = wall.WallType.GetCompoundStructure();
                                IList<CompoundStructureLayer> layers = structure.GetLayers();

                                foreach (CompoundStructureLayer layer in layers)
                                {
                                    //Filtering away materials without thermal properties
                                    Material layerMaterial = doc.GetElement(layer.MaterialId) as Material;
                                    ElementId thermalAssetId = layerMaterial.ThermalAssetId;
                                    PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                                    if (pse == null) continue;
                                    Dictionary<string, string> layerValues = new Dictionary<string, string>();
                                    Dictionary<string, string> layerValues2 = new Dictionary<string, string>();
                                    int layerId = layer.LayerId + 1;
                                    int layerId2 = layers.Count - layerId + 1;
                                    layerName = "Layer" + layerId.ToString();
                                    layerName2 = "Layer" + layerId2.ToString();
                                    if (layer.Width == 0)
                                    {
                                        thickness = 0.001;
                                    }
                                    else
                                    {
                                        thickness = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(layer.Width), 3);
                                    }
                                    preMaterialId = layer.MaterialId.ToString() + "_" + thickness;
                                    materialId = preMaterialId.Replace(',', '.');
                                    layerValues.Add(layerName, materialId);
                                    layerValues2.Add(layerName2, materialId);
                                    constructionLayers.Add(layerValues);
                                    constructionLayers2.Insert(0, layerValues2);
                                }
                            }
                            SurfaceConstruction surfaceConstructionToAdd = new SurfaceConstruction(constructionId, constructionLayers);
                            SurfaceConstruction surfaceConstructionToAdd2 = new SurfaceConstruction(constructionId2, constructionLayers2);
                            Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction = new Dictionary<string, SurfaceConstruction>();
                            Dictionary<string, SurfaceConstruction> linkedSurfaceConstruction2 = new Dictionary<string, SurfaceConstruction>();
                            linkedSurfaceConstruction.Add(constructionId, surfaceConstructionToAdd);
                            linkedSurfaceConstruction2.Add(constructionId2, surfaceConstructionToAdd2);
                            if (wall.WallType.Function.ToString() == "Interior")
                            {
                                surfaceConstructions.Add(linkedSurfaceConstruction);
                                surfaceConstructions.Add(linkedSurfaceConstruction2);
                            }
                            else
                            {
                                surfaceConstructions.Add(linkedSurfaceConstruction);
                            }
                        }
                        else continue;

                    }
                }
            }

            return surfaceConstructions;
        }
    }
}
