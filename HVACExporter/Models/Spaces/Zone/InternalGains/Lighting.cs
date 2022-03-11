using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Lighting
    {
        public string Name { get; set; }
        public string Zone_or_ZoneList_or_Space_or_SpaceList_Name { get; set; }
        public string Schedule_Name { get; set; }
        public string Design_Level_Calculation_Method { get; set; }
        public double Lighting_Level { get; set; }
        public double Return_Air_Fraction { get; set; }
        public double Fraction_Radiant { get; set; }
        public double Fraction_Visible { get; set; }
        public double Fraction_Replaceable { get; set; }
        public string EndUse_Subcategory { get; set; }

        public Lighting(string id, string zoneId, string lightingSchedule, string calculationMethod, 
            double lightingLevel, double returnAirFraction, double fractionRadiant, 
            double fractionVisible, double fractionReplaceable, string endUseSubCategory)
        {
            Name = id;
            Zone_or_ZoneList_or_Space_or_SpaceList_Name = zoneId;
            Schedule_Name = lightingSchedule;
            Design_Level_Calculation_Method = calculationMethod;
            Lighting_Level = lightingLevel;
            Return_Air_Fraction = returnAirFraction;
            Fraction_Radiant = fractionRadiant;
            Fraction_Visible = fractionVisible;
            Fraction_Replaceable = fractionReplaceable;
            EndUse_Subcategory = endUseSubCategory;
        }
    }
}