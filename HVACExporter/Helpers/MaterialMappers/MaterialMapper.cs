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
    class MaterialMapper
    {
        public static Materials MapAllMaterials(FilteredElementCollector allMaterials)
        {
            var materials = new Materials();

            foreach (Material material in allMaterials)
            {
                if (material.GetMaterialArea(material.Id,false) > 0) continue;
                string id = material.UniqueId;
                string tag = material.Id.ToString();
                int roughness = material.Smoothness;
                double thickness = material.Name.Length; //Temporary mapping
                double conductivity = material.Name.Length; //Temporary mapping
                double density = material.Name.Length;
                double specificHeat = material.Name.Length; //Temporary mapping
                double thermalAbsorbtance = material.Name.Length; //Temporary mapping
                double solarAbsorbtance = material.Name.Length; //Temporary mapping
                double visibleAbsorbtance = material.Name.Length; //Temporary mapping

                var materialToAdd = new SurfaceMat(id, tag, roughness, thickness, 
                    conductivity, density, specificHeat, thermalAbsorbtance, 
                    solarAbsorbtance, visibleAbsorbtance);

                materials.AddMaterial(materialToAdd);
            }

            return materials;

        }
    }
}
