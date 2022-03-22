
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
using System.Linq;

namespace HVACExporter.Helpers
{
    class SurfaceMaterialMapper
    {
        public static List<Dictionary<string, SurfaceMat>> MapAllSurfaceMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            List<Dictionary<string, SurfaceMat>> allSurfaceMaterials = new List<Dictionary<string, SurfaceMat>>();

            List<SurfaceMat> layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            if (layerWallMaterials.Count != 0)
            {
                foreach (SurfaceMat surfaceMat in layerWallMaterials)
                {
                    if (surfaceMat.ReadableName != "Air")
                    {
                        Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                        linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                        allSurfaceMaterials.Add(linkedSurfaceMat);
                    }
                }
            }

            List<SurfaceMat> layerCurtainWallMaterials = CurtainWallMaterialMapper.MapAllCurtainWalls(allWalls, doc);
            if (layerCurtainWallMaterials.Count != 0)
            {
                foreach (SurfaceMat surfaceMat in layerCurtainWallMaterials)
                {
                    if (surfaceMat.ReadableName != "Air")
                    {
                        Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                        linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                        allSurfaceMaterials.Add(linkedSurfaceMat);
                    }
                }
            }

            List<SurfaceMat> layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            if (layerRoofMaterials.Count != 0)
            {
                foreach (SurfaceMat surfaceMat in layerRoofMaterials)
                {
                    if (surfaceMat.Name != "Air")
                    {
                        Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                        linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                        allSurfaceMaterials.Add(linkedSurfaceMat);
                    }
                }
            }

            List<SurfaceMat> layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            if (layerFloorMaterials.Count != 0)
            {
                foreach (SurfaceMat surfaceMat in layerFloorMaterials)
                {
                    if (surfaceMat.Name != "Air")
                    {
                        Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                        linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                        allSurfaceMaterials.Add(linkedSurfaceMat);
                    }
                }
            }
            
            List<Dictionary<string, SurfaceMat>> filteredDictionary = 
                allSurfaceMaterials.GroupBy(x => string.Join("", x.Select(i => string.Format("{0}{1}", i.Key, i.Value)))).Select(x => x.First()).ToList();

            return filteredDictionary;
        }
    }
}
