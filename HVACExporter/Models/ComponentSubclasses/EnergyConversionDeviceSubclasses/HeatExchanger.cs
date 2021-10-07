using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses
{
    public class HeatExchanger : EnergyConversionDevice
    {
        public double NomPower { get; set; }
        public double NomSupplyTemperaturePrimary { get; set; }
        public double NomReturnTemperaturePrimary { get; set; }
        public double NomSupplyTemperatureSecondary { get; set; }
        public double NomReturnTemperatureSecondary { get; set; }
        public double NomFlowPrimary { get; set; }
        public double NomFlowSecondary { get; set; }
        public double NomDpPrimary { get; set; }
        public double NomDpSecondary { get; set; }

        public HeatExchanger(string id, string tag, string systemName, string systemType,
                        double nomPower, 
                        double nomSupplyTemperaturePrimary, double nomSupplyTemperatureSecondary,
                        double nomReturnTemperaturePrimary, double nomReturnTemperatureSecondary,
                        double nomFlowPrimary, double nomFlowSecondary,
                        double nomDpPrimary, double nomDpSecondary)
            : base(id, tag, systemName, systemType)
        {
            NomPower =
            NomSupplyTemperaturePrimary = nomSupplyTemperaturePrimary;
            NomReturnTemperaturePrimary = nomSupplyTemperatureSecondary;
            NomSupplyTemperatureSecondary = nomReturnTemperaturePrimary;
            NomReturnTemperatureSecondary = nomReturnTemperatureSecondary;
            NomFlowPrimary = nomFlowPrimary;
            NomFlowSecondary = nomFlowSecondary;
            NomDpPrimary = nomDpPrimary;
            NomDpSecondary = nomDpSecondary;
            ComponentType = this.GetType().Name;
        }
    }
}
