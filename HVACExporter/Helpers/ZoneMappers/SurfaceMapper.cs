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

namespace HVACExporter.Helpers
{
    public class SurfaceMapper
    {
        //Can find boundary walls to a room
        public static List<Models.Zone.Surface> MapSurfaces(SpatialElement zone, Document doc, FilteredElementCollector allAnalyticalSurfaces)
        {
            var allSurfaces = new List<Models.Zone.Surface>();

            var allWallSurfaces = WallSurfaceMapper.MapAllWallSurfaces(zone, doc, allAnalyticalSurfaces);
            foreach (Models.Zone.Surface wallSurface in allWallSurfaces)
            {
                allSurfaces.Add(wallSurface);
            }

            return allSurfaces;
        }

    }
}

