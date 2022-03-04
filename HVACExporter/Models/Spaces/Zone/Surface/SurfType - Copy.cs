using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SurfType 
    {
        public bool Wall { get; set; }
        public bool Floor { get; set; }
        public bool Ceiling { get; set; }
        public bool Roof { get; set; }


        public SurfType(bool wall, bool floor, bool ceiling, bool roof)
        {
            Wall = wall;
            Floor = floor;
            Ceiling = ceiling;
            Roof = roof;
        }

    }
}
