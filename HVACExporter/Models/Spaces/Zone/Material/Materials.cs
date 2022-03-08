using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Materials
    {
        public List<SurfaceMat> SurfaceMaterials { get; set; }
        public List<SurfaceMat> AirGapMaterials { get; set; }
        public List<DoorMat> DoorMaterials { get; set; }
        public List<WindowMat> WindowMaterials { get; set; }

        public Materials(List<SurfaceMat> surfaceMaterials, List<SurfaceMat> airGapMaterials, 
            List<DoorMat> doorMaterials, List<WindowMat> windowMaterials)
        {
            SurfaceMaterials = surfaceMaterials;
            AirGapMaterials = airGapMaterials;
            DoorMaterials = doorMaterials;
            WindowMaterials = windowMaterials;
        }
    }
}