using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses
{
    public class Radiator : EnergyConversionDevice
    {
        public double? NomPower { get; set; }
        public double? NomSupplyTemperature { get; set; }
        public double? NomReturnTemperature { get; set; }
        public double? NomRoomTemperature { get; set; }
        public double? NomDp { get; set; }

        public Radiator(string id, string tag, string systemName, string systemType, 
                        double? nomPower, double? nomSupplyTemperature, double? nomReturnTemperature,
                        double? nomRoomTemperature, double? nomDp)
            : base(id, tag, systemName, systemType)
        {
            NomPower = nomPower;
            NomSupplyTemperature = nomSupplyTemperature;
            NomReturnTemperature = nomReturnTemperature;
            NomRoomTemperature = nomRoomTemperature;
            NomDp = nomDp;
            ComponentType = this.GetType().Name;
        }
    }
}
