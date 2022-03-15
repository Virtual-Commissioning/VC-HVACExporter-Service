﻿using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class EquipmentMapper
    {
        public static List<Equipment> MapEquipment(string analyticalZoneId)
        {
            List<Equipment> equipment = new List<Equipment>();
            string name = "Zone" + analyticalZoneId + "_" + "Equipment";
            string zoneId = analyticalZoneId;
            string equipmentSchedule = "";
            string calculationMethod = "";
            double designLevel = 0;
            double fractionLatent = 0;
            double fractionRadiant = 0;
            double fractionLost = 0;
            string endUseSubCategory = "";

            Equipment equipmentGains = new Equipment(name, zoneId, equipmentSchedule, calculationMethod,
                designLevel, fractionLatent, fractionRadiant,
                fractionLost, endUseSubCategory);
            equipment.Add(equipmentGains);
            return equipment;
        }
    }
}
