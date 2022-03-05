using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Equipment
    {
        public string Id { get; set; }
        public string ZoneId { get; set; }
        public string EquipmentSchedule { get; set; }
        public string CalculationMethod { get; set; }
        public double DesignLevel { get; set; }
        public double WattM2 { get; set; }
        public double FractionLatent { get; set; }
        public double FractionRadiant { get; set; }
        public double FractionLost { get; set; }
        public string EndUseSubCategory { get; set; }

        public Equipment(string id, string zoneId, string equipmentSchedule,
            string calculationMethod, double designLevel, double wattM2,
            double fractionLatent, double fractionRadiant, double fractionLost,
            string endUseSubCategory)
        {
            Id = id;
            ZoneId = zoneId;
            EquipmentSchedule = equipmentSchedule;
            CalculationMethod = calculationMethod;
            DesignLevel = designLevel;
            WattM2 = wattM2;
            FractionLatent = fractionLatent;
            FractionRadiant = fractionRadiant;
            FractionLost = fractionLost;
            EndUseSubCategory = endUseSubCategory;
        }
    }
}