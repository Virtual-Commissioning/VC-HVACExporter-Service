using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.Zone
{
    public class ConstructionLayer
    {
        public string MaterialId { get; set; }
        public string LayerId { get; set; }

        public ConstructionLayer(string materialId, string layerId)
        {
            MaterialId = materialId;
            LayerId = layerId;
        }


        /*
        public Dictionary<string, string> Layer { get; set; }

        public ConstructionLayer(Dictionary<string, string> layer)
        {
            Layer = layer;
        }
        
        */
    }
}
