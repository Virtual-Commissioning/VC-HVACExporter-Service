﻿
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
            (Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            List<People> people = PeopleMapper.MapPeople(associatedSpace);
            List<Lighting> lighting = LightingMapper.MapLighting(associatedSpace);
            List<Equipment> equipment = EquipmentMapper.MapEquipment(associatedSpace);

            InternalGains allInternalGains = new InternalGains(people, lighting, equipment);

            return allInternalGains;
        }

    }
}

