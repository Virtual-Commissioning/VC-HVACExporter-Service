﻿using Autodesk.Revit.DB;
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
    class WallConstructionMapper
    {
        public static List<SurfaceConstruction> MapAllWalls(FilteredElementCollector allSpaces, Autodesk.Revit.DB.Document doc)   //(Autodesk.Revit.DB.Document doc, Wall walls)    
        {
            var surfaceConstructions = new List<SurfaceConstruction>();

            foreach (SpatialElement space in allSpaces)
            {
                if (space.Category.Name == "Spaces") continue;

                IList<IList<Autodesk.Revit.DB.BoundarySegment>> segments = space.GetBoundarySegments(new SpatialElementBoundaryOptions());

                foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in segments)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                    {
                        Wall wall = doc.GetElement(boundarySegment.ElementId) as Wall;

                        if (wall != null)
                        {
                            string constructionId = wall.WallType.UniqueId.ToString();
                            string analyticalConstructionId = wall.WallType.GetAnalyticalModelId().ToString();
                            string name = wall.WallType.Name;

                            CompoundStructure structure = wall.WallType.GetCompoundStructure();
                            IList<CompoundStructureLayer> layers = structure.GetLayers();


                            var constructionLayers = new List<ConstructionLayer>();
                            foreach (CompoundStructureLayer layer in layers)
                            {
                                string layerId = layer.LayerId.ToString();

                                Material layerWallMaterial = doc.GetElement(layer.MaterialId) as Material;
                                string materialId = layerWallMaterial.UniqueId;

                                var constructionLayerToAdd = new ConstructionLayer(materialId, layerId);

                                constructionLayers.Add(constructionLayerToAdd);
                            }
                            var surfaceConstructionToAdd = new SurfaceConstruction(constructionId, analyticalConstructionId, name, constructionLayers);

                            surfaceConstructions.Add(surfaceConstructionToAdd);
                        }

                    }
                }
            }

            return surfaceConstructions;

        }
    }
}