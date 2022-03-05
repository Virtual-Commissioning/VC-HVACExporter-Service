﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Zone
    {
        public string Id { get; set; }
        public GeometricTypes.Coordinate Point { get; set; }
        public string ZoneType { get; set; }
        public double CeilingHeight { get; set; }
        public double FloorArea { get; set; }
        public double ZoneVolume { get; set; }
        public string IntConvAlg { get; set; }
        public string OutConvAlg { get; set; }
        public bool IncludedInTotArea { get; set; }
        public string AnalyticalZoneId { get; set; }
        public List<Surface> Surfaces { get; set; }
        public InternalGains InternalGains { get; set; }
        public HVAC HVAC { get; set; }
        public Infiltration Infiltration { get; set; }
        public ShadingZone ShadingZone { get; set; }
        
        public Zone(string id, GeometricTypes.Coordinate point, string zoneType, double ceilingHeight, 
            double floorArea, double zoneVolume, string intConvAlg, string outConvAlg, string includedInTotArea,
            string analyticalZoneId, List<Surface> surfaces, InternalGains internalGains, HVAC hvac,
            Infiltration infiltration, ShadingZone shadingZone)
        {
            Id = id;
            Point = point;
            ZoneType = zoneType;
            CeilingHeight = ceilingHeight;
            FloorArea = floorArea;
            ZoneVolume = zoneVolume;
            IntConvAlg = intConvAlg;
            OutConvAlg = outConvAlg;
            AnalyticalZoneId = analyticalZoneId;
            Surfaces = surfaces;
            InternalGains = internalGains;
            HVAC = hvac;
            Infiltration = infiltration;
            ShadingZone = shadingZone;
        }
    }
}
