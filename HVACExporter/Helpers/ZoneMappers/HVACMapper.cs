
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Helpers.ZoneMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Zone;
using HVACExporter;
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Helpers.ZoneMappers.InternalGainsMappers;

namespace HVACExporter.Helpers
{
    public class HVACMapper
    {
        public static HVAC MapHVAC
            (string analyticalZoneId)
        {
            Thermostat thermostat = ThermostatMapper.MapThermostat(analyticalZoneId);
            AirLoadSystem airLoadSystem = AirLoadSystemMapper.MapAirLoadSystem(analyticalZoneId);
            HVAC hvac = new HVAC(thermostat, airLoadSystem);

            return hvac;
        }

    }
}

