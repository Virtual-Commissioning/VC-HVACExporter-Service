using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ThermalProperties
    {
        public double Conductivity { get; set; }
        public double Density { get; set; }
        public double SpecificHeat { get; set; }
        
        public ThermalProperties(double conductivity, double density, double specificHeat)
        {
            Conductivity = conductivity;
            Density = density;
            SpecificHeat = specificHeat;
        }
    }
}