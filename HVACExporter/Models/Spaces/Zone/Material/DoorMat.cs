using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class DoorMat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public int Roughness { get; set; }
        public double ThermalResistance { get; set; }
        public double ThermalAbsorbtance { get; set; }
        public double SolarAbsorbtance { get; set; }
        public double VisibleAbsorbtance { get; set; }

        public DoorMat(string id, string tag, int roughness, double thermalResistance, double thermalAbsorbtance, double solarAbsorbtance, double visibleAbsorbtance)
        {
            Id = id;
            Tag = tag;
            Roughness = roughness;
            ThermalResistance = thermalResistance;
            ThermalAbsorbtance = thermalAbsorbtance;
            SolarAbsorbtance = solarAbsorbtance;
            VisibleAbsorbtance = visibleAbsorbtance;
        }
    }
}