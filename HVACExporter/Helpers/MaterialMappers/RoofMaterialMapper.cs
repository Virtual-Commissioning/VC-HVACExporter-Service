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
    class RoofMaterialMapper
    {
        public static List<SurfaceMat> MapAllRoofs(FilteredElementCollector allRoofs, Autodesk.Revit.DB.Document doc)   
        {
            List<SurfaceMat> layerRoofMaterials = new List<SurfaceMat>();
            
            foreach (RoofBase roof in allRoofs)
            {
                CompoundStructure structure = roof.RoofType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    string id = layer.MaterialId.ToString();
                    double thickness = layer.Width;
                    Material layerRoofMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string name = layerRoofMaterial.Name;
                    int roughness = 0;
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0;
                    // Getting thermal assets:
                    ElementId thermalAssetId = layerRoofMaterial.ThermalAssetId;
                    PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                    if (pse == null) { return null; }
                    ThermalAsset asset = pse.GetThermalAsset();
                    double conductivity = asset.ThermalConductivity;
                    double density = asset.Density;
                    double specificHeat = asset.SpecificHeat;

                    SurfaceMat layerRoofMaterialToAdd = new SurfaceMat(name, id, roughness, thickness,
                        conductivity, density, specificHeat, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerRoofMaterials.Add(layerRoofMaterialToAdd);
                }
            }

            return layerRoofMaterials;

        }
    }
}
