using System.Collections.Generic;
using HVACExporter.Models.Spaces;

namespace HVACExporter.Models.Zone
{
    public class Materials
    {
        public List<SurfaceMat> MaterialsInModel { get; set; } = new List<SurfaceMat>();

        public void AddMaterial(SurfaceMat mat)
        {
            if (!IsMaterialInList(mat))
            {
                MaterialsInModel.Add(mat);
            }
        }

        public bool IsMaterialInList(SurfaceMat mat)
        {
            if (MaterialsInModel.Contains(mat))
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