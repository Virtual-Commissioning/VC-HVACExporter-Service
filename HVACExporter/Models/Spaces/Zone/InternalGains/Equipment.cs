using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Zone_or_ZoneList_or_Space_or_SpaceList_Name { get; set; }
        public string Schedule_Name { get; set; }
        public string Design_Level_Calculation_Method { get; set; }
        public double Design_Level { get; set; }
        public double Fraction_Latent { get; set; }
        public double Fraction_Radiant { get; set; }
        public double Fraction_Lost { get; set; }
        public string EndUse_Subcategory { get; set; }

        public Equipment(string id, string zoneId, string equipmentSchedule,
            string calculationMethod, double designLevel,
            double fractionLatent, double fractionRadiant, double fractionLost,
            string endUseSubCategory)
        {
            Name = id;
            Zone_or_ZoneList_or_Space_or_SpaceList_Name = zoneId;
            Schedule_Name = equipmentSchedule;
            Design_Level_Calculation_Method = calculationMethod;
            Design_Level = designLevel;
            Fraction_Latent = fractionLatent;
            Fraction_Radiant = fractionRadiant;
            Fraction_Lost = fractionLost;
            EndUse_Subcategory = endUseSubCategory;
        }
    }
}