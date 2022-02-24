
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
        public static MaterialsOfLayers MapAllMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            var airGapMaterials = new MaterialsOfLayers();

            var layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            foreach (SurfaceMat surfaceMat in layerWallMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.AddMaterial(surfaceMat);
                }
            }
            
            var layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceMat surfaceMat in layerRoofMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.AddMaterial(surfaceMat);
                }
            }

            var layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceMat surfaceMat in layerFloorMaterials)
            {
                if (surfaceMat.Name == "Air")
                {
                    airGapMaterials.AddMaterial(surfaceMat);
                }
            }

            return airGapMaterials;
        }
    }
}
