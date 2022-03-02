using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models.Spaces.Zone;

namespace HVACExporter.Models.Zone
{
    public class SurfaceConstruction
    {
        public string ConstructionId { get; set; }
        public string AnalyticalConstructionId { get; set; }
        public List<ConstructionLayer> ConstructionLayers { get; set; }
        public string Name { get; set; }

        public SurfaceConstruction(string constructionId, string analyticalConstructionId, string name, List<ConstructionLayer> constructionLayers)
        {
            ConstructionId = constructionId;
            AnalyticalConstructionId = analyticalConstructionId;
            Name = name;
            ConstructionLayers = constructionLayers;
        }
    }
}