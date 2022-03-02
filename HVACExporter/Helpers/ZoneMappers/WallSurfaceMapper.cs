/*
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
    public class WallSurfaceMapper
    {
        //Can find boundary walls to a room
        public static List<Models.Zone.Surface> MapAllWallSurfaces(SpatialElement zone, Document doc, FilteredElementCollector allAnalyticalSurfaces)
        {
            var allSpaceWalls = new List<Models.Zone.Surface>();

            IList<IList<Autodesk.Revit.DB.BoundarySegment>> spaceWalls = zone.GetBoundarySegments(new SpatialElementBoundaryOptions());

            foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in spaceWalls)
            {
                foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                {
                    Wall wall = doc.GetElement(boundarySegment.ElementId) as Wall;

                    string id = wall.UniqueId;

                    string constructionName = wall.WallType.UniqueId.ToString();

                    string surfType = SurfaceType.Wall.ToString(); //room.Document.GetElement(wall.ElementId).CompuundStructure;

                    string zoneTag = zone.UniqueId;

                    string outsideBC = "NA";

                    string OutsideBCObj = "NA";

                    bool sunExposure;
                    bool windExposure;
                    if (wall.WallType.Function.ToString() == "Exterior")
                    {
                        sunExposure = true;
                        windExposure = true;
                    }
                    else
                    {
                        sunExposure = false;
                        windExposure = false;
                    }
                    string viewFactorToGround = "NA";

                    List<VertexCoordinates> vertexCoordinates = WallSurfaceGeometryMapper.MapWallSurfaceGeometry(boundarySegment, doc);

                    Models.Zone.Surface surface = new Models.Zone.Surface(id, constructionName,
                        surfType, zoneTag, outsideBC, OutsideBCObj, sunExposure, windExposure,
                        viewFactorToGround, vertexCoordinates);

                    allSpaceWalls.Add(surface);
                }
            }
                
            //}
            return allSpaceWalls;
        }

    }
}*/

