using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public enum OutBCObj
    {
        IntWallBetweenZones,
        IntWallInZone,
        IntFloor,
        ExtFloor,
        Roof,
        ExtWall
    }
    
    public class OutsideBCObj
    {
        public string OutsideBCObjType { get; set; }

        public OutsideBCObj(string outsideBCObjType)
        {
            OutsideBCObjType = outsideBCObjType;
        }
    }
    
}
