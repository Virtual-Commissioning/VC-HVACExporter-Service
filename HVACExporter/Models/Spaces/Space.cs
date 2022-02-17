using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IES;

namespace HVACExporter.Models.Spaces
{
    public class Space
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public IndoorClimateZone IndoorClimateZone { get; set; }
        public SpaceGeometry SpaceGeometry { get; set; }
        
        public Space(string id, string tag, IndoorClimateZone indoorClimateZone, SpaceGeometry spaceGeometry)
        {
            Id = id;
            Tag = tag;
            IndoorClimateZone = indoorClimateZone;
            SpaceGeometry = spaceGeometry;
        }
    }
}