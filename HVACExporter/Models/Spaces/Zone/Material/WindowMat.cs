using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class WindowMat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public double ThermalResistance { get; set; }
        public double SolarHeatGain { get; set; }
        public double VisibleTransmittance { get; set; }


        public WindowMat(string id, string tag, double thermalResistance, double solarHeatGain, double visibleTransmittance)
        {
            Id = id;
            Tag = tag;
            ThermalResistance = thermalResistance;
            SolarHeatGain = solarHeatGain;
            VisibleTransmittance = visibleTransmittance;
        }
    }
}