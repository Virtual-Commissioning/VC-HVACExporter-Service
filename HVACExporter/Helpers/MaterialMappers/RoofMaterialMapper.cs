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
            var layerRoofMaterials = new List<SurfaceMat>();
            
            foreach (RoofBase roof in allRoofs)
            {
                CompoundStructure structure = roof.RoofType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    //Easy to access
                    string tag = layer.MaterialId.ToString();
                    double thickness = layer.Width;


                    //Finding Id
                    Material layerRoofMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string id = layerRoofMaterial.UniqueId.ToString();
                    string name = layerRoofMaterial.Name;
                    //Roughness can only be found for the whole construction - default = 0
                    int roughness = 0;

                    //Function for thermal assets
                    Models.Zone.ThermalProperties thermalProperties = GetThermalProperties.MapThermalProperties(layerRoofMaterial, doc);

                    //Default values
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0; 

                    var layerRoofMaterialToAdd = new SurfaceMat(name, id, tag, roughness, thickness,
                        thermalProperties, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    //layerRoofMaterials.AddLayerRoofMaterial(layerRoofMaterialToAdd);
                    layerRoofMaterials.Add(layerRoofMaterialToAdd);
                }
            }

            return layerRoofMaterials;

        }
    }
}
