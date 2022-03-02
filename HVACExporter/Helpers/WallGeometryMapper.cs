using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class WallSurfaceGeometryMapper
    {
        public static List<VertexCoordinates> MapWallSurfaceGeometry(BoundarySegment boundarySegment, Document doc)
        {
            List<VertexCoordinates> allVertices = new List<VertexCoordinates>();

            Wall wall = doc.GetElement(boundarySegment.ElementId) as Wall;

            //Figure out how to take the center line of interior walls
            if (wall.WallType.Function.ToString() != "Interior")
            {
                IList<Reference> sideFaces = HostObjectUtils.GetSideFaces(wall, ShellLayerType.Exterior);
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
                IList<Reference> sideFaces = HostObjectUtils.GetSideFaces(wall, ShellLayerType.Exterior);
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
