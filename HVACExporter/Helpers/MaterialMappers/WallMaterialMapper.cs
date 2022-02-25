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
            var layerWallMaterials = new List<SurfaceMat>();

            foreach (Wall wall in allWalls)
            {
                CompoundStructure structure = wall.WallType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    //Easy to access
                    
                    string tag = layer.MaterialId.ToString();
                    double thickness = layer.Width;


                    //Finding Id
                    Material layerWallMaterial = doc.GetElement(layer.MaterialId) as Material;
                    string id = layerWallMaterial.UniqueId;
                    string name = layerWallMaterial.Name;
                    //Roughness can only be found for the whole construction - default = 0
                    int roughness = 0;

                    //Function for thermal assets
                    Models.Zone.ThermalProperties thermalProperties = GetThermalProperties.MapThermalProperties(layerWallMaterial, doc);

                    //Default values
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0; 

                    var layerWallMaterialToAdd = new SurfaceMat(name, id, tag, roughness, thickness,
                        thermalProperties, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerWallMaterials.Add(layerWallMaterialToAdd);
                }
            }

            return layerWallMaterials;

        }
    }
}
