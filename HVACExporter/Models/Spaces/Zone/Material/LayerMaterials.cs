using System.Collections.Generic;
using HVACExporter.Models.Spaces;

namespace HVACExporter.Models.Zone
{
    public class LayerMaterials
    {
        public List<SurfaceMat> LayerMaterialsInModel { get; set; } = new List<SurfaceMat>();

        public void AddLayerMaterial(SurfaceMat mat)
        {
            if (!IsLayerMaterialInList(mat))
            {
                LayerMaterialsInModel.Add(mat);
            }
        }

        public bool IsLayerMaterialInList(SurfaceMat mat)
        {
            if (LayerMaterialsInModel.Contains(mat))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}