using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SubSurfaceGeometryMapper
    {
        public static List<VertexCoordinates> MapSubSurfaceGeometry(EnergyAnalysisOpening opening, Document doc)
        {
            List<VertexCoordinates> allVertices = new List<VertexCoordinates>();

            Document surfDoc = opening.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = opening.get_Geometry(opt);

            foreach (GeometryObject obj in geo)
            {
                Solid solid = obj as Solid;
                if (null != solid)
                {
                    foreach (Face face in solid.Faces)
                    {
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
                }
            }
            
            return allVertices;
        }
    }

}
