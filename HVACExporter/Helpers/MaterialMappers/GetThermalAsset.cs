using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.MaterialMappers
{
    internal class GetThermalProperties
    {
        public static Models.Zone.ThermalProperties MapThermalProperties(Material material, Document doc)
        {
            ElementId thermalAssetId = material.ThermalAssetId;
            
            PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
            if (pse == null) { return null; }
                
            Autodesk.Revit.DB.ThermalAsset asset = pse.GetThermalAsset();
            
                    // Check the thermal material type and only read if solid
            
            double conductivity = asset.ThermalConductivity;
            double density = asset.Density;
            double specificHeat = asset.SpecificHeat;

            var thermalAsset = new Models.Zone.ThermalProperties(conductivity, density, specificHeat);

            return thermalAsset;
            
                

            

            /*ElementId thermalAssetId = material.ThermalAssetId;
            if (thermalAssetId != ElementId.InvalidElementId)
            {
                PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                if (pse != null)
                {
                    Autodesk.Revit.DB.ThermalAsset asset = pse.GetThermalAsset();

                    // Check the thermal material type and only read if solid
                    if (asset.ThermalMaterialType == ThermalMaterialType.Solid)
                    {
                        double conductivity = asset.ThermalConductivity;
                        double density = asset.Density;
                        double specificHeat = asset.SpecificHeat;

                        var thermalAsset = ThermalAsset(conductivity, density, specificHeat);

                        return thermalAsset;
                    }
                }
                
            }*/
        }
    }
}
