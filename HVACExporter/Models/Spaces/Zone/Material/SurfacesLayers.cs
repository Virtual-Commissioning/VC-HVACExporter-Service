using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.Zone
{
    internal class SurfaceLayers
    {
        public List<SurfaceMat> SurfaceLayer { get; set; }

        public SurfaceLayers(List<SurfaceMat> surfaceLayer)
        {
            SurfaceLayer = surfaceLayer;
        }
    }
}
