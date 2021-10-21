using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.Geometry
{
    public class SpaceGeometry
    {
        public double SpaceBottomElevation { get; set; }
        public double SpaceHeight { get; set; }
        public List<Edge> Footprint { get; set; }

        public SpaceGeometry(double spaceBottomElevation, double spaceHeight, List<Edge> footprint)
        {
            SpaceBottomElevation = spaceBottomElevation;
            SpaceHeight = spaceHeight;
            Footprint = footprint;
        }
    }
}
