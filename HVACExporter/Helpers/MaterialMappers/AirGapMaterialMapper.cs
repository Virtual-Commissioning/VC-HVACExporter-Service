
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
    public class AirGapMaterialMapper
    {
        public static List<Dictionary<string, SurfaceMat>> MapAllMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            List<Dictionary<string, SurfaceMat>> airGapMaterials = new List<Dictionary<string, SurfaceMat>>();

            List<SurfaceMat> layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            foreach (SurfaceMat surfaceMat in layerWallMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceMat surfaceMat in layerRoofMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceMat surfaceMat in layerFloorMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    Dictionary<string, SurfaceMat> linkedSurfaceMat = new Dictionary<string, SurfaceMat>();
                    linkedSurfaceMat.Add(surfaceMat.Name, surfaceMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            return airGapMaterials;
        }
    }
}
