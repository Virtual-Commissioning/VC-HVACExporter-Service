using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class EquipmentMapper
    {
        public static List<Equipment> MapEquipment(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            List<Equipment> equipment = new List<Equipment>();
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "Equipment";
            string zoneId = associatedSpace.Id.ToString();
            string equipmentSchedule = "";
            string calculationMethod = "";
            double designLevel = 0;
            double wattM2 = 0;
            double fractionLatent = 0;
            double fractionRadiant = 0;
            double fractionLost = 0;
            string endUseSubCategory = "";

            Equipment equipmentGains = new Equipment(id, zoneId, equipmentSchedule, calculationMethod,
                designLevel, wattM2, fractionLatent, fractionRadiant,
                fractionLost, endUseSubCategory);
            equipment.Add(equipmentGains);
            return equipment;
        }
    }
}
