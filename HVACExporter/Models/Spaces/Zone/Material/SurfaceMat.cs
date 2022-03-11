using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SurfaceMat
    {

        public string Name { get; set; }
        public int Roughness { get; set; }
        public double Thickness { get; set; }
        public double Conductivity { get; set; }
        public double Density { get; set; }
        public double Specific_Heat { get; set; }
        //public ThermalProperties ThermalProperties { get; set; }
        public double Thermal_Absorptance { get; set; }
        public double Solar_Absorptance { get; set; }
        public double Visible_Absorptance { get; set; }

        public SurfaceMat(string name, int roughness, double thickness, 
            double conductivity, double density, double specificHeat, double thermalAbsorptance, 
            double solarAbsorptance, double visibleAbsorptance)
        {
            Name = name;
            Roughness = roughness;
            Thickness = thickness;
            Conductivity = conductivity;
            Density = density;
            Specific_Heat = specificHeat;
            Thermal_Absorptance = thermalAbsorptance;
            Solar_Absorptance = solarAbsorptance;
            Visible_Absorptance = visibleAbsorptance;
        }
    }
}