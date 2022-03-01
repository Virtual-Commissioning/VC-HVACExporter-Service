using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    
    public enum SurfaceType
    {
        Wall,
        Floor,
        Ceiling,
        Roof
    }
    public class Type
    {
        public SurfaceType SurfaceType { get; set; }

    }
}
