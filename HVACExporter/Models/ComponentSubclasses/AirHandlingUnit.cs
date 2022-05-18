using HVACExporter.Models.ComponentSubclasses.AirHandlingUnitComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses
{
    public class AirHandlingUnit : Component
    {
        ComponentsInAHU ComponentsInAHU { get; set; }
        public AirHandlingUnit(string id, string tag, string systemName, string systemType, ComponentsInAHU componentsInAHU)
            : base(id, tag, systemName, systemType)
        {
            ComponentsInAHU = componentsInAHU;
        }

    }
}
