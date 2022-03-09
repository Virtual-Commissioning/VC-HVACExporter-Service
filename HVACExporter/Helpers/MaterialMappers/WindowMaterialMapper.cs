using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.MaterialMappers
{
    class WindowMaterialMapper
    {
        public static List<Dictionary<string, WindowMat>> MapAllWindows(FilteredElementCollector allWindows, Autodesk.Revit.DB.Document doc)
        {
            List<Dictionary<string, WindowMat>> windowMaterials = new List<Dictionary<string, WindowMat>>();

            foreach (FamilyInstance window in allWindows)
            {
                ElementId windowSymbol = window.Symbol.Id;
                FamilySymbol windowInfo = doc.GetElement(windowSymbol) as FamilySymbol;

                string id = window.UniqueId;
                double thermalResistance = windowInfo.GetThermalProperties().ThermalResistance;
                double solarHeatGain = windowInfo.GetThermalProperties().SolarHeatGainCoefficient;
                double visibleTransmittance = windowInfo.GetThermalProperties().VisualLightTransmittance;

                WindowMat windowMaterial = new WindowMat(id, thermalResistance,
                    solarHeatGain, visibleTransmittance);
                Dictionary<string, WindowMat> linkedWindowMaterial = new Dictionary<string, WindowMat>();
                linkedWindowMaterial.Add(windowMaterial.Id, windowMaterial);
                windowMaterials.Add(linkedWindowMaterial);

            }
            return windowMaterials;
        }
    }
}

