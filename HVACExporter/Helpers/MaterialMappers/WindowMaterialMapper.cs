using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.MaterialMappers
{
    class WindowMaterialMapper
    {
        public static List<Dictionary<string, WindowMat>> MapAllWindows(FilteredElementCollector allWindows, FilteredElementCollector allWalls, Autodesk.Revit.DB.Document doc)
        {
            List<Dictionary<string, WindowMat>> windowMaterials = new List<Dictionary<string, WindowMat>>();

            foreach (FamilyInstance window in allWindows)
            {
                ElementId windowSymbol = window.Symbol.Id;
                FamilySymbol windowInfo = doc.GetElement(windowSymbol) as FamilySymbol;
                string name = window.Symbol.GetThermalProperties().AnalyticConstructionTypeId.ToString();
                double uFactor = Math.Round(1 / windowInfo.GetThermalProperties().ThermalResistance,3);
                double solarHeatGain = Math.Round(windowInfo.GetThermalProperties().SolarHeatGainCoefficient,3);
                double visibleTransmittance = Math.Round(windowInfo.GetThermalProperties().VisualLightTransmittance,3);

                WindowMat windowMaterial = new WindowMat(name, uFactor,
                    solarHeatGain, visibleTransmittance);
                Dictionary<string, WindowMat> linkedWindowMaterial = new Dictionary<string, WindowMat>();
                linkedWindowMaterial.Add(windowMaterial.Name, windowMaterial);
                windowMaterials.Add(linkedWindowMaterial);
            }
            List<Dictionary<string, WindowMat>> curtainWallWindowMaterials = CurtainWallWindowMaterialMapper.MapAllCurtainWallWindows(allWalls);
            windowMaterials.AddRange(curtainWallWindowMaterials);

            List<Dictionary<string, WindowMat>> filteredDictionary =
                windowMaterials.GroupBy(x => string.Join("", x.Select(i => string.Format("{0}{1}", i.Key, i.Value)))).Select(x => x.First()).ToList();

            return filteredDictionary;
        }
    }
}

