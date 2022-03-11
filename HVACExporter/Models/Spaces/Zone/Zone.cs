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
        public string Name { get; set; }
        public double X_Origin { get; set; }
        public double Y_Origin { get; set; }
        public double Z_Origin { get; set; }
        public string Type { get; set; }
        public double Ceiling_Height { get; set; }
        public double Floor_Area { get; set; }
        public double Volume { get; set; }
        public string Zone_Inside_Convection_Algorithm { get; set; }
        public string Zone_Outside_Convection_Algorithm { get; set; }
        public bool Part_of_Total_Floor_Area { get; set; }
        public List<Dictionary<string, Surface>> Surfaces { get; set; }
        public InternalGains InternalGains { get; set; }
        public HVAC HVAC { get; set; }
        public Infiltration Infiltration { get; set; }
        public List<ShadingZone> ZoneShadings { get; set; }
        
        public Zone(string zoneId, double xOrigin, double yOrigin, double zOrigin, string zoneType, 
            double ceilingHeight, double floorArea, double zoneVolume, string intConvAlg, string outConvAlg, 
            bool includedInTotArea, List<Dictionary<string, Surface>> surfaces, InternalGains internalGains, HVAC hvac,
            Infiltration infiltration, List<ShadingZone> shadingZone)
        {
            Name = zoneId;
            X_Origin = xOrigin;
            Y_Origin = yOrigin;
            Z_Origin = zOrigin;
            Type = zoneType;
            Ceiling_Height = ceilingHeight;
            Floor_Area = floorArea;
            Volume = zoneVolume;
            Zone_Inside_Convection_Algorithm = intConvAlg;
            Zone_Outside_Convection_Algorithm = outConvAlg;
            Part_of_Total_Floor_Area = includedInTotArea;
            Surfaces = surfaces;
            InternalGains = internalGains;
            HVAC = hvac;
            Infiltration = infiltration;
            ZoneShadings = shadingZone;
        }
    }
}
