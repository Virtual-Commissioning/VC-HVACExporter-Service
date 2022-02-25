using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Materials
    {
        public MaterialsOfLayers SurfaceMaterials { get; set; }
        public MaterialsOfLayers AirGapMaterials { get; set; }
        public List<DoorMat> DoorMaterials { get; set; }
        public List<WindowMat> WindowMaterials { get; set; }

        public Materials(MaterialsOfLayers surfaceMaterials, MaterialsOfLayers airGapMaterials, 
            List<DoorMat> doorMaterials, List<WindowMat> windowMaterials)
        {
            SurfaceMaterials = surfaceMaterials;
            AirGapMaterials = airGapMaterials;
            DoorMaterials = doorMaterials;
            WindowMaterials = windowMaterials;
        }
    }
}