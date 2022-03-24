using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public enum OutBC
    {
        Surface,
        Adiabatic,
        Zone,
        Outdoors,
        Ground
    }
    
    public class OutsideBC
    {
        public string OutsideBCType { get; set; }

        public OutsideBC(string outsideBCType)
        {
            OutsideBCType = outsideBCType;
        }
    }
    
}
