using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Zone
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public XYZOrigin XYZOrigin { get; set; }
        public double CeilingHeight { get; set; }
        public double FloorArea { get; set; }
        public double ZoneVolume { get; set; }
        public bool IncludedInTotArea { get; set; }

        public Zone(string id, string tag, XYZOrigin xyzOrigin, double ceilingHeight, double floorArea, double zoneVolume, bool includedInTotArea)
        {
            Id = id;
            Tag = tag;
            XYZOrigin = xyzOrigin;
            CeilingHeight = ceilingHeight;
            FloorArea = floorArea;
            ZoneVolume = zoneVolume;
            IncludedInTotArea = includedInTotArea;
        }

    }
}
