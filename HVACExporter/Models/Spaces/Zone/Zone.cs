using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Zone
    {
        //public string Id { get; set; }
        public string ZoneId { get; set; }
        public double XOrigin { get; set; }
        public double YOrigin { get; set; }
        public double ZOrigin { get; set; }
        public string ZoneType { get; set; }
        public double CeilingHeight { get; set; }
        public double FloorArea { get; set; }
        public double ZoneVolume { get; set; }
        public string IntConvAlg { get; set; }
        public string OutConvAlg { get; set; }
        public bool IncludedInTotArea { get; set; }
        public List<Surface> Surfaces { get; set; }
        public InternalGains InternalGains { get; set; }
        public HVAC HVAC { get; set; }
        public Infiltration Infiltration { get; set; }
        public ShadingZone ShadingZone { get; set; }
        
        public Zone(string zoneId, double xOrigin, double yOrigin, double zOrigin, string zoneType, 
            double ceilingHeight, double floorArea, double zoneVolume, string intConvAlg, string outConvAlg, 
            bool includedInTotArea, List<Surface> surfaces, InternalGains internalGains, HVAC hvac,
            Infiltration infiltration, ShadingZone shadingZone)
        {
            ZoneId = zoneId;
            XOrigin = xOrigin;
            YOrigin = yOrigin;
            ZOrigin = zOrigin;
            ZoneType = zoneType;
            CeilingHeight = ceilingHeight;
            FloorArea = floorArea;
            ZoneVolume = zoneVolume;
            IntConvAlg = intConvAlg;
            OutConvAlg = outConvAlg;
            IncludedInTotArea = includedInTotArea;
            Surfaces = surfaces;
            InternalGains = internalGains;
            HVAC = hvac;
            Infiltration = infiltration;
            ShadingZone = shadingZone;
        }
    }
}
