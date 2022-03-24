
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
    public class AirGapMaterialMapper
    {
        public static List<Dictionary<string, AirGapMat>> MapAllMaterials(FilteredElementCollector allWalls, 
            FilteredElementCollector allRoofs, FilteredElementCollector allFloors, Document doc)
        {
            List<Dictionary<string, AirGapMat>> airGapMaterials = new List<Dictionary<string, AirGapMat>>();

            List<SurfaceMat> layerWallMaterials = WallMaterialMapper.MapAllWalls(allWalls, doc);
            foreach (SurfaceMat surfaceMat in layerWallMaterials)
            {
                if (surfaceMat.ReadableName == "Air")
                {
                    Dictionary<string, AirGapMat> linkedSurfaceMat = new Dictionary<string, AirGapMat>();
                    string name = surfaceMat.Name;
                    double? thermalResistance = 1/surfaceMat.Conductivity;
                    AirGapMat airGapMat = new AirGapMat(name, thermalResistance);
                    linkedSurfaceMat.Add(surfaceMat.Name, airGapMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerRoofMaterials = RoofMaterialMapper.MapAllRoofs(allRoofs, doc);
            foreach (SurfaceMat surfaceMat in layerRoofMaterials)
            {
                if (surfaceMat.ReadableName == "Air")
                {
                    Dictionary<string, AirGapMat> linkedSurfaceMat = new Dictionary<string, AirGapMat>();
                    string name = surfaceMat.Name;
                    double? thermalResistance = 1 / surfaceMat.Conductivity;
                    AirGapMat airGapMat = new AirGapMat(name, thermalResistance);
                    linkedSurfaceMat.Add(surfaceMat.Name, airGapMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            List<SurfaceMat> layerFloorMaterials = FloorMaterialMapper.MapAllFloors(allFloors, doc);
            foreach (SurfaceMat surfaceMat in layerFloorMaterials)
            {
                if (surfaceMat.ReadableName == "Air")
                {
                    Dictionary<string, AirGapMat> linkedSurfaceMat = new Dictionary<string, AirGapMat>();
                    string name = surfaceMat.Name;
                    double? thermalResistance = 1 / surfaceMat.Conductivity;
                    AirGapMat airGapMat = new AirGapMat(name, thermalResistance);
                    linkedSurfaceMat.Add(surfaceMat.Name, airGapMat);
                    airGapMaterials.Add(linkedSurfaceMat);
                }
            }

            List<Dictionary<string, AirGapMat>> filteredDictionary =
                airGapMaterials.GroupBy(x => string.Join("", x.Select(i => string.Format("{0}{1}", i.Key, i.Value)))).Select(x => x.First()).ToList();
            List<Dictionary<string, AirGapMat>> airGapMaterial = new List<Dictionary<string, AirGapMat>>();
            
            return filteredDictionary;
        }
    }
}
