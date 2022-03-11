using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;

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

                string id = door.Id.ToString();
                int roughness = 0;
                double thermalResistance = Math.Round(ImperialToMetricConverter.ConvertThermalResistanceImpToMet(doorInfo.GetThermalProperties().ThermalResistance),3);
                double thermalAbsorbtance = 0;
                double solarAbsorbtance = 0;
                double visibleTransmittance = 0;
                DoorMat doorMaterial = new DoorMat(id, roughness, thermalResistance,
                    thermalAbsorbtance, solarAbsorbtance, visibleTransmittance);
                Dictionary<string, DoorMat> linkedDoorMaterial = new Dictionary<string, DoorMat>();

                linkedDoorMaterial.Add(doorMaterial.Name, doorMaterial);
                doorMaterials.Add(linkedDoorMaterial);
            }
            return doorMaterials;
        }
    }
}

