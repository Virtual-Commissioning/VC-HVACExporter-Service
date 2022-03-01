using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.DirectContext3D;
using Autodesk.Revit.DB.Structure;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Surface = HVACExporter.Models.Zone.Surface;
using System;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SurfaceGeometryMapper
    {
        public static List<VertexCoordinates> MapSurfaceGeometry(BoundarySegment boundarySegment, FilteredElementCollector allAnalyticalSurfaces, Document doc)
        {
            List<VertexCoordinates> allVertices = new List<VertexCoordinates>();
            
            Wall wall = doc.GetElement(boundarySegment.ElementId) as Wall;


            //Figure out how to take the center line of interior walls
            if (wall.WallType.Function.ToString() != "Interior")
            {
                // Get the side faces

                IList<Reference> sideFaces =

                    HostObjectUtils.GetSideFaces(wall, ShellLayerType.Exterior);

                // access the side face

                Face face = doc.GetElement(sideFaces[0]).GetGeometryObjectFromReference(sideFaces[0]) as Face;

                EdgeArray loop = face.EdgeLoops.get_Item(0);

                foreach (Autodesk.Revit.DB.Edge vertex in loop)
                {
                    IList<XYZ> edgePts = vertex.Tessellate();

                    List<Coordinate> coordinates = new List<Coordinate>();

                    foreach (XYZ curve in edgePts)
                    {
                        Coordinate point = new Coordinate(curve.X, curve.Y, curve.Z);

                        coordinates.Add(point);
                    }
                    var vertexCoordinatesToAdd = new VertexCoordinates(coordinates);

                    allVertices.Add(vertexCoordinatesToAdd);
                }
            }
            else
            {
                // Get the side faces

                IList<Reference> sideFaces =

                    HostObjectUtils.GetSideFaces(wall, ShellLayerType.Exterior);

                // access the side face

                Face face = doc.GetElement(sideFaces[0]).GetGeometryObjectFromReference(sideFaces[0]) as Face;

                EdgeArray loop = face.EdgeLoops.get_Item(0);

                foreach (Autodesk.Revit.DB.Edge vertex in loop)
                {
                    IList<XYZ> edgePts = vertex.Tessellate();

                    List<Coordinate> coordinates = new List<Coordinate>();

                    foreach (XYZ curve in edgePts)
                    {
                        Coordinate point = new Coordinate(curve.X, curve.Y, curve.Z);

                        coordinates.Add(point);
                    }
                    var vertexCoordinatesToAdd = new VertexCoordinates(coordinates);

                    allVertices.Add(vertexCoordinatesToAdd);
                }
            }

            return allVertices;
        }
    }

}
