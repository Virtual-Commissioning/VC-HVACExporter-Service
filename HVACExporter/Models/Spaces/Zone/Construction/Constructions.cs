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
        public List<Dictionary<string, SurfaceConstruction>> SurfaceConstructions { get; set; }
        public List<Dictionary<string, OpeningConstruction>> OpeningConstructions { get; set; }

        public Constructions(List<Dictionary<string, SurfaceConstruction>> surfaceConstructions, List<Dictionary<string, OpeningConstruction>> openingConstructions)
        {
            SurfaceConstructions = surfaceConstructions;
            OpeningConstructions = openingConstructions;
        }
    }
}