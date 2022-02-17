using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class AirGapMat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public double ThermalResistance { get; set; }

        public AirGapMat(string id, string tag, double thermalResistance)
        {
            Id = id;
            Tag = tag;
            ThermalResistance = thermalResistance;
        }
    }
}