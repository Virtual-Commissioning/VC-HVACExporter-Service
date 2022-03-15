using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class AirGapMat
    {
        public string Name { get; set; }
        public double Thermal_Resistance { get; set; }

        public AirGapMat(string name, double thermalResistance)
        {
            Name = name;
            Thermal_Resistance = thermalResistance;
        }
    }
}