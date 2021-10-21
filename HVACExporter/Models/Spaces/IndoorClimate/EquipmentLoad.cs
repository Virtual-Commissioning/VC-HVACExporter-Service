using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class EquipmentLoad
    {
        public ValueMatrix AmountOfEquipment { get; set; }
        public double HeatloadPrEquipment { get; set; }

        public EquipmentLoad(ValueMatrix amountOfEquipment, double wattPrEquipment)
        {
            AmountOfEquipment = amountOfEquipment;
            HeatloadPrEquipment = wattPrEquipment;
        }
    }
}
