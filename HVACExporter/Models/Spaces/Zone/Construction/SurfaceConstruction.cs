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
        public List<Dictionary<string, string>> ConstructionLayers { get; set; }

        public SurfaceConstruction(string constructionId, List<Dictionary<string, string>> constructionLayers)
        {
            ConstructionId = constructionId;
            ConstructionLayers = constructionLayers;
        }
    }
}