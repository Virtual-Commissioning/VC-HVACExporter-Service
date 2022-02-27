using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models.Spaces.Zone;

namespace HVACExporter.Models.Zone
{
    public class Constructions
    {
        public List<SurfaceConstruction> SurfaceConstructions { get; set; }
        public List<OpeningConstruction> OpeningConstructions { get; set; }

        public Constructions(List<SurfaceConstruction> surfaceConstructions, List<OpeningConstruction> openingConstructions)
        {
            SurfaceConstructions = surfaceConstructions;
            OpeningConstructions = openingConstructions;
        }
    }
}