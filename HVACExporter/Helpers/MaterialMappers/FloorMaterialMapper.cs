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
    class FloorMaterialMapper
    {
        public static List<SurfaceMat> MapAllFloors(FilteredElementCollector allFloors, Autodesk.Revit.DB.Document doc)   
        {
            var layerFloorMaterials = new List<SurfaceMat>();
            
            foreach (Floor floor in allFloors)
            {
                CompoundStructure structure = floor.FloorType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    //Easy to access
                    string id = layer.MaterialId.ToString();
                    double thickness = layer.Width;


                    //Finding Id
                    Material layerFloorMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string name = layerFloorMaterial.Name;
                    //Roughness can only be found for the whole construction - default = 0
                    int roughness = 0;

                    //Function for thermal assets
                    Models.Zone.ThermalProperties thermalProperties = GetThermalProperties.MapThermalProperties(layerFloorMaterial, doc);

                    //Default values
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0; 

                    var layerFloorMaterialToAdd = new SurfaceMat(name, id, roughness, thickness,
                        thermalProperties, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerFloorMaterials.Add(layerFloorMaterialToAdd);
                }
            }

            return layerFloorMaterials;

        }
    }
}
