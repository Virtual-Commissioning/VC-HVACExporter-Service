using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.MaterialMappers
{
    class WindowMaterialMapper
    {
        public static List<WindowMat> MapAllWindows(FilteredElementCollector allWindows, Autodesk.Revit.DB.Document doc)
        {
            var windowMaterials = new List<WindowMat>();

            foreach (FamilyInstance window in allWindows)
            {
                ElementId windowSymbol = window.Symbol.Id;
                FamilySymbol windowInfo = doc.GetElement(windowSymbol) as FamilySymbol;

                string id = window.UniqueId;
                string tag = window.Id.ToString();
                double thermalResistance = windowInfo.GetThermalProperties().ThermalResistance;
                double solarHeatGain = windowInfo.GetThermalProperties().SolarHeatGainCoefficient;
                double visibleTransmittance = windowInfo.GetThermalProperties().VisualLightTransmittance;

                var windowMaterial = new WindowMat(id, tag, thermalResistance,
                    solarHeatGain, visibleTransmittance);

                windowMaterials.Add(windowMaterial);

            }
            return windowMaterials;
        }
    }
}

