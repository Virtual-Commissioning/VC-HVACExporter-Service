using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.MaterialMappers
{
    class WindowMaterialMapper
    {
        public static List<WindowMat> MapAllWindows(FilteredElementCollector allWindows, Autodesk.Revit.DB.Document doc)
        {
            List<WindowMat> windowMaterials = new List<WindowMat>();

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

                windowMaterials.Add(windowMaterial);

            }
            return windowMaterials;
        }
    }
}

