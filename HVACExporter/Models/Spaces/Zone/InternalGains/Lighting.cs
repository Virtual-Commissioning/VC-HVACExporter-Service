using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Lighting
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string LightingSchedule { get; set; }
        public string CalculationMethod { get; set; }
        public double LightingLevel { get; set; }
        public double WattM2 { get; set; }
        public double ReturnAirFraction { get; set; }
        public double FractionRadiant { get; set; }
        public double FractionVisible { get; set; }
        public double FractionReplaceable { get; set; }
        public string EndUseSubCategory { get; set; }

        public Lighting(string id, string tag, string lightingSchedule, string calculationMethod, double lightingLevel, double wattM2, double returnAirFraction, double fractionRadiant, double fractionVisible, double fractionReplaceable, string endUseSubCategory)
        {
            Id = id;
            Tag = tag;
            LightingSchedule = lightingSchedule;
            CalculationMethod = calculationMethod;
            LightingLevel = lightingLevel;
            WattM2 = wattM2;
            ReturnAirFraction = returnAirFraction;
            FractionRadiant = fractionRadiant;
            FractionVisible = fractionVisible;
            FractionReplaceable = fractionReplaceable;
            EndUseSubCategory = endUseSubCategory;
        }
    }
}