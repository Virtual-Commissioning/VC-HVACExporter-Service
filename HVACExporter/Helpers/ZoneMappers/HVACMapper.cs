
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
            (Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            Thermostat thermostat = ThermostatMapper.MapThermostat(associatedSpace);
            AirLoadSystem airLoadSystem = AirLoadSystemMapper.MapAirLoadSystem(associatedSpace);
            HVAC hvac = new HVAC(thermostat, airLoadSystem);

            return hvac;
        }

    }
}

