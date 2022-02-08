using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Equiptment
{
    public class Equiptment
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string LightingSchedule { get; set; }
        public string CalculationMethod { get; set; }
        public double LightingLevel { get; set; }
        public double WattM2 { get; set; }
        public double ReturnAirFraction { get; set; }
        public double FractionRadiant { get; set; }
        public double FractionLost { get; set; }
        public string EndUseSubCategory { get; set; }

        public Equiptment(string id, string tag, string lightingSchedule, CalculationMethod calculationMethod, double lightingLevel, double wattM2, double returnAirFraction, double fractionRadiant, double fractionLost, string endUseSubCategory)
        {
            Id = id;
            Tag = tag;
            LightingSchedule = lightingSchedule;
            CalculationMethod = calculationMethod;
            LightingLevel = lightingLevel;
            WattM2 = wattM2;
            ReturnAirFraction = returnAirFraction;
            FractionRadiant = fractionRadiant;
            FractionVisible = fractionLost;
            EndUseSubCategory = endUseSubCategory;
        }
    }
}