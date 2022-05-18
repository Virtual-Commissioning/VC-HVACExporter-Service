using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses.AirHandlingUnitComponents
{
    public class ComponentsInAHU
    {
        public bool ContainsSupplyCooling;
        public bool ContainsSupplyHeating;
        public bool ContainsSupplyFilter;
        public bool ContainsExtractFilter;
        public bool ContainsHeatExchanger;
        public bool ContainsSupplyFan;
        public bool ContainsExtractFan;

        public ComponentsInAHU(bool containsSupplyCooling,
                               bool containsSupplyHeating,
                               bool containsSupplyFilter,
                               bool containsExtractFilter,
                               bool containsHeatExchanger,
                               bool containsSupplyFan,
                               bool containsExtractFan)
        {
            ContainsSupplyCooling = containsSupplyCooling;
            ContainsSupplyHeating = containsSupplyHeating;
            ContainsSupplyFilter = containsSupplyFilter;
            ContainsExtractFilter = containsExtractFilter;
            ContainsHeatExchanger = containsHeatExchanger;
            ContainsSupplyFan = containsSupplyFan;
            ContainsExtractFan = containsExtractFan;
        }
    }
}
