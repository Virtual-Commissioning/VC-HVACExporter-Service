using Autodesk.Revit.DB;
using System.Collections.Generic;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Zone;
using System.Linq;
using System;

namespace HVACExporter.Models.Zone
{
    public class MaterialsOfLayers
    {
        //public Dictionary<string, List<Surfaces>> MaterialsOfLayersInModel { get; set; } = new Dictionary<string, List<SurfaceMat>>();
        public List<SurfaceMat> MaterialsOfLayersInModel { get; set; } = new List<SurfaceMat>();

        public void AddMaterial(SurfaceMat mat)
        {
            if (!IsMaterialInList(mat))
            {
                MaterialsOfLayersInModel.Add(mat);
            }
        }

        public bool IsMaterialInList(SurfaceMat mat)
        {
            
            string id = mat.Tag;
            double thickness = mat.Thickness;

            foreach (SurfaceMat mat2 in MaterialsOfLayersInModel)
            {
                string id2 = mat2.Tag;
                double thickness2 = mat2.Thickness;

                double difference = Math.Abs(thickness2 - thickness);

                if ((id2 == id) && (difference < 1E-2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
            /*
            if (MaterialsOfLayersInModel.Contains(mat))
            {
                return true;
            }
            else
            {
                return false;
            }
            */
        }
    }
}
