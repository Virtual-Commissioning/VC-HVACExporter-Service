using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.WindowMat
{
    public class WindowMat
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public double ThermalConductivity { get; set; }
        public double SolarHeatGain { get; set; }
        public double VisibleTransmittance { get; set; }


        public WindowMat(string id, string tag, double thermalConductivity, double solarHeatGain, double visibleTransmittance)
        {
            Id = id;
            Tag = tag;
            ThermalConductivity = thermalConductivity;
            SolarHeatGain = solarHeatGain;
            VisibleTransmittance = visibleTransmittance;
        }
    }
}