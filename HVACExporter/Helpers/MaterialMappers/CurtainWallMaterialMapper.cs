using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers
{
    class CurtainWallMaterialMapper
    {
        public static List<SurfaceMat> MapAllCurtainWalls(FilteredElementCollector allWalls, Autodesk.Revit.DB.Document doc)  
        {
            List<SurfaceMat> layerWallMaterials = new List<SurfaceMat>();

            foreach (Wall wall in allWalls)
            {
                if (wall.WallType.Kind.ToString() != "Curtain") continue;
                    string name = "CW_Mat_" + wall.Id.ToString();
                    double? thickness = null;
                    string readableName = wall.WallType.Name;
                    int? roughness = null;
                    double? thermalAbsorbtance = null; 
                    double? solarAbsorbtance = null; 
                    double? visibleAbsorbtance = null;
                    double? conductivity = null;
                    double? density = null;
                    double? specificHeat = null;

                    SurfaceMat layerWallMaterialToAdd = new SurfaceMat(readableName, name, roughness, thickness,
                        conductivity, density, specificHeat, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerWallMaterials.Add(layerWallMaterialToAdd);
            }

            return layerWallMaterials;
        }
    }
}
