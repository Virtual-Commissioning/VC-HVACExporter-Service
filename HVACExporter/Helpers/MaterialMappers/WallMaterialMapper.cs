using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class WallMaterialMapper
    {
        public static List<SurfaceMat> MapAllWalls(FilteredElementCollector allWalls, Autodesk.Revit.DB.Document doc)   //(Autodesk.Revit.DB.Document doc, Wall walls)    
        {
            //var layerWallMaterials = new MaterialsOfLayers();
            List<SurfaceMat> layerWallMaterials = new List<SurfaceMat>();

            foreach (Wall wall in allWalls)
            {
                CompoundStructure structure = wall.WallType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    string id = layer.MaterialId.ToString();
                    double thickness = layer.Width;
                    Material layerWallMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string name = layerWallMaterial.Name;
                    int roughness = 0;
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0;
                    // Getting thermal assets:
                    ElementId thermalAssetId = layerWallMaterial.ThermalAssetId;
                    PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                    if (pse == null) { return null; }
                    ThermalAsset asset = pse.GetThermalAsset();
                    double conductivity = asset.ThermalConductivity;
                    double density = asset.Density;
                    double specificHeat = asset.SpecificHeat;

                    SurfaceMat layerWallMaterialToAdd = new SurfaceMat(name, id, roughness, thickness,
                        conductivity, density, specificHeat, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerWallMaterials.Add(layerWallMaterialToAdd);
                }
            }

            return layerWallMaterials;

        }
    }
}
