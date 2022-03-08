using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.MaterialMappers
{
    class DoorMaterialMapper
    {
        public static List<DoorMat> MapAllDoors(FilteredElementCollector allDoors, Autodesk.Revit.DB.Document doc)
        {
            List<DoorMat> doorMaterials = new List<DoorMat>();

            foreach (FamilyInstance door in allDoors)
            {
                ElementId doorSymbol = door.Symbol.Id;
                FamilySymbol doorInfo = doc.GetElement(doorSymbol) as FamilySymbol;

                string id = door.UniqueId;
                int roughness = 0;
                double thermalResistance = doorInfo.GetThermalProperties().ThermalResistance;
                double thermalAbsorbtance = 0;
                double solarAbsorbtance = 0;
                double visibleTransmittance = 0;

                DoorMat doorMaterial = new DoorMat(id, roughness, thermalResistance,
                    thermalAbsorbtance, solarAbsorbtance, visibleTransmittance);

                doorMaterials.Add(doorMaterial);

            }
            return doorMaterials;
        }
    }
}

