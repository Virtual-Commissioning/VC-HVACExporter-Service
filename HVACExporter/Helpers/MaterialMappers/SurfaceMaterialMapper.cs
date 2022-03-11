
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
    class SurfaceMaterialMapper
    {
        public static List<Dictionary<string, SurfaceMat>> MapAllSurfaceMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            List<Dictionary<string, SurfaceMat>> allSurfaceMaterials = new List<Dictionary<string, SurfaceMat>>();

            List<SurfaceMat> layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            foreach (SurfaceMat surfaceMat in layerWallMaterials)
            {
                if (surfaceMat.Name != "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    allSurfaceMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceMat surfaceMat in layerRoofMaterials)
            {
                if (surfaceMat.Name != "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    allSurfaceMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceMat surfaceMat in layerFloorMaterials)
            {
                if (surfaceMat.Name != "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    allSurfaceMaterials.Add(linkedSurfaceMat);
                }
            }
            

            return allSurfaceMaterials;
        }
    }
}
