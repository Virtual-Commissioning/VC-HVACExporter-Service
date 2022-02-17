using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SurfaceMat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public int Roughness { get; set; }
        public double Thickness { get; set; }
        public double Conductivity { get; set; }
        public double Density { get; set; }
        public double SpecificHeat { get; set; }
        public double ThermalAbsorbtance { get; set; }
        public double SolarAbsorbtance { get; set; }
        public double VisibleAbsorbtance { get; set; }

        public SurfaceMat(string id, string tag, int roughness, double thickness, double conductivity, double density, double specificHeat, double thermalAbsorbtance, double solarAbsorbtance, double visibleAbsorbtance)
        {
            Id = id;
            Tag = tag;
            Roughness = roughness;
            Thickness = thickness;
            Conductivity = conductivity;
            Density = density;
            SpecificHeat = specificHeat;
            ThermalAbsorbtance = thermalAbsorbtance;
            SolarAbsorbtance = solarAbsorbtance;
            VisibleAbsorbtance = visibleAbsorbtance;
        }
    }
}