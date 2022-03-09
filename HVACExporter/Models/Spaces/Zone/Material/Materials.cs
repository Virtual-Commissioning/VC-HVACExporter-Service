using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Materials
    {
        public List<Dictionary<string, SurfaceMat>> SurfaceMaterials { get; set; }
        public List<Dictionary<string, SurfaceMat>> AirGapMaterials { get; set; }
        public List<Dictionary<string, DoorMat>> DoorMaterials { get; set; }
        public List<Dictionary<string, WindowMat>> WindowMaterials { get; set; }

        public Materials(List<Dictionary<string, SurfaceMat>> surfaceMaterials, List<Dictionary<string, SurfaceMat>> airGapMaterials,
            List<Dictionary<string, DoorMat>> doorMaterials, List<Dictionary<string, WindowMat>> windowMaterials)
        {
            SurfaceMaterials = surfaceMaterials;
            AirGapMaterials = airGapMaterials;
            DoorMaterials = doorMaterials;
            WindowMaterials = windowMaterials;
        }
    }
}