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
        public string Id { get; set; }
        public int Roughness { get; set; }
        public double Thickness { get; set; }
        public ThermalProperties ThermalProperties { get; set; }
        public double ThermalAbsorbtance { get; set; }
        public double SolarAbsorbtance { get; set; }
        public double VisibleAbsorbtance { get; set; }

        public SurfaceMat(string name, string id, int roughness, double thickness, 
            ThermalProperties thermalProperties, double thermalAbsorbtance, 
            double solarAbsorbtance, double visibleAbsorbtance)
        {
            Name = name;
            Id = id;
            Roughness = roughness;
            Thickness = thickness;
            ThermalProperties = thermalProperties;
            ThermalAbsorbtance = thermalAbsorbtance;
            SolarAbsorbtance = solarAbsorbtance;
            VisibleAbsorbtance = visibleAbsorbtance;
        }
    }
}