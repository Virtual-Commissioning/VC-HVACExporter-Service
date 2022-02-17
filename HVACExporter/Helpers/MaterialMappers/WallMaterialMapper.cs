using Autodesk.Revit.DB;
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
        public static LayerMaterials MapAllWalls(FilteredElementCollector allWalls)
        {
            var layerMaterials = new LayerMaterials();

            foreach (WallType wall in allWalls)
            {
                IList<CompoundStructureLayer> layers = wall.GetCompoundStructure().GetLayers();
                foreach (CompoundStructureLayer layer in layers)
                {
                    //Easy to access
                    string tag = layer.MaterialId.ToString();
                    double thickness = layer.Width;

                    //Access through list - MaterialsInModel
                    //or somehow do this:
                    //CompoundStructureLayer -> MaterialId -> ThermalAssetId -> GetThermalAsset
                    string id = layer.MaterialId.ToString(); //Temporary mapping
                    int roughness = 1; //Temporary mapping
                    double conductivity = layer.Width; //Temporary mapping
                    double density = layer.Width; //Temporary mapping
                    double specificHeat = layer.Width; //Temporary mapping

                    //Default values
                    double thermalAbsorbtance = 0.7; 
                    double solarAbsorbtance = 0.7; 
                    double visibleAbsorbtance = 0.7; 

                    var layerMaterialToAdd = new SurfaceMat(id, tag, roughness, thickness,
                        conductivity, density, specificHeat, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerMaterials.AddLayerMaterial(layerMaterialToAdd);

                    var materialToAdd = new SurfaceMat(id, tag, roughness, thickness,
                    conductivity, density, specificHeat, thermalAbsorbtance,
                    solarAbsorbtance, visibleAbsorbtance);

                    layerMaterials.AddLayerMaterial(materialToAdd);
                }
                
            }

            return layerMaterials;

        }
    }
}
