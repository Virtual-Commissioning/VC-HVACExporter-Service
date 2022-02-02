using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IES;

namespace HVACExporter.Models.Spaces
{
    public class Space
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        
        public Space(string id, string tag)
        {
            Id = id;
            Tag = tag;
        }
    }
}