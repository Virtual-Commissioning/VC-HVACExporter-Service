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

namespace HVACExporter.Helpers
{
    public class SurfaceMapper
    {
        //Can find boundary walls to a room
        public static Models.Zone.Surface MapSurface(Room room)
        {
            IList<IList<Autodesk.Revit.DB.BoundarySegment>> roomWalls = room.GetBoundarySegments(new SpatialElementBoundaryOptions());

            //FilteredElementCollector collector = new FilteredElementCollector(doc);

            //Create a list with walls. Then check if the wall Id matches the Id of the boundary segment. If it does, map Surface information.


            foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in roomWalls)
            {
                foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                {

                    string id = room.Document.GetElement(boundarySegment.ElementId).UniqueId;

                    
                    //if (wallIds.Contains(id) = true)

                    string tag = room.Document.GetElement(boundarySegment.ElementId).Name;

                    string constructionName = room.Document.GetElement(boundarySegment.ElementId).Name;

                    string surfType = "NA"; //room.Document.GetElement(wall.ElementId).CompuundStructure;

                    string zoneTag = room.UniqueId;

                    string outsideBC = "NA";
                    
                    string OutsideBCObj = "NA";

                    bool sunExposure = true;
                    bool windExposure = true;
                    string viewFactorToGround = "NA";

                    VertexCoordinates vertexCoordinates = WallGeometryMapper.MapWallGeometry(boundarySegment);

                    Models.Zone.Surface surface = new Models.Zone.Surface(id, tag, constructionName,
                        surfType, zoneTag, outsideBC, sunExposure, windExposure,
                        viewFactorToGround, vertexCoordinates);
                }
            }

            return (Models.Zone.Surface)roomWalls;
        }

        /*internal static Models.Zone.Surface MapSurface(Models.Zone.Surface surface)
        {
            throw new NotImplementedException();
        }
        */

    }
}

