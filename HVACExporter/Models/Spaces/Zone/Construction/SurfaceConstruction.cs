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
        public string Name { get; set; }
        public List<Dictionary<string, string>> Layers { get; set; }

        public SurfaceConstruction(string name, List<Dictionary<string, string>> layers)
        {
            Name = name;
            Layers = layers;
        }
    }
}