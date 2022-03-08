
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
        public static List<SurfaceMat> MapAllMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            List<SurfaceMat> airGapMaterials = new List<SurfaceMat>();

            List<SurfaceMat> layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            foreach (SurfaceMat surfaceMat in layerWallMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.Add(surfaceMat);
                }
            }

            List<SurfaceMat> layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceMat surfaceMat in layerRoofMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.Add(surfaceMat);
                }
            }

            List<SurfaceMat> layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceMat surfaceMat in layerFloorMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.Add(surfaceMat);
                }
            }

            return airGapMaterials;
        }
    }
}
