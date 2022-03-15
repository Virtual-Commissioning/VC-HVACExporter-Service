
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
    public class InternalGainsMapper
    {
        public static InternalGains MapInternalGains
            (string analyticalZoneId)
        {
            List<People> people = PeopleMapper.MapPeople(analyticalZoneId);
            List<Lighting> lighting = LightingMapper.MapLighting(analyticalZoneId);
            List<Equipment> equipment = EquipmentMapper.MapEquipment(analyticalZoneId);

            InternalGains allInternalGains = new InternalGains(people, lighting, equipment);

            return allInternalGains;
        }

    }
}

