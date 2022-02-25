using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class OutsideBCObject // NEED REVISION
    {
        public bool Surface { get; set; } // 
        public bool Adiabatic { get; set; } // 
        public bool Outdoors { get; set; } // 
        public bool Ground { get; set; } // 


        public OutsideBCObject(bool surface, bool adiabatic, bool outdoors, bool ground)
        {
            Surface = surface;
            Adiabatic = adiabatic;
            Outdoors = outdoors;
            Ground = ground;
        }

    }
}
