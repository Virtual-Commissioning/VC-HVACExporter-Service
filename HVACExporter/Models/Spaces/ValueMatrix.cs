using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces
{
    public class ValueMatrix
    {
        public float ClientRequirement { get; set; }
        public float DesignerRequirement { get; set; }

        public ValueMatrix(float clientRequirement, float designerRequirement)
        {
            ClientRequirement = clientRequirement;
            DesignerRequirement = designerRequirement;
        }
    }
}
