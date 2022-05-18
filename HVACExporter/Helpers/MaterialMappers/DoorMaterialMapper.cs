using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.MaterialMappers
{
    class DoorMaterialMapper
    {
        public static List<Dictionary<string, DoorMat>> MapAllDoors(FilteredElementCollector allDoors, Autodesk.Revit.DB.Document doc)
        {
            List<Dictionary<string, DoorMat>> doorMaterials = new List<Dictionary<string, DoorMat>>();

            foreach (FamilyInstance door in allDoors)
            {
                ElementId doorSymbol = door.Symbol.Id;
                FamilySymbol doorInfo = doc.GetElement(doorSymbol) as FamilySymbol;

                //string id = door.Id.ToString();
                string id = door.Symbol.GetThermalProperties().AnalyticConstructionTypeId.ToString();
                int? roughness = null;
                double? thermalResistance = Math.Round(ImperialToMetricConverter.ConvertThermalResistanceImpToMet(doorInfo.GetThermalProperties().ThermalResistance),3);
                double? thermalAbsorbtance = null;
                double? solarAbsorbtance = null;
                double? visibleTransmittance = null;
                DoorMat doorMaterial = new DoorMat(id, roughness, thermalResistance,
                    thermalAbsorbtance, solarAbsorbtance, visibleTransmittance);
                Dictionary<string, DoorMat> linkedDoorMaterial = new Dictionary<string, DoorMat>();

                linkedDoorMaterial.Add(doorMaterial.Name, doorMaterial);
                doorMaterials.Add(linkedDoorMaterial);
            }
            List<Dictionary<string, DoorMat>> filteredDictionary =
                doorMaterials.GroupBy(x => string.Join("", x.Select(i => string.Format("{0}{1}", i.Key, i.Value)))).Select(x => x.First()).ToList();

            return filteredDictionary;
        }
    }
}

