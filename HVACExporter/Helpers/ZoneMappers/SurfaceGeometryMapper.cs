using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SurfaceGeometryMapper
    {
        public static List<Coordinate> MapSurfaceGeometry(EnergyAnalysisSurface energyAnalysisSurface, Document doc)
        {
            List<Coordinate> vertices = new List<Coordinate>();
            Document surfDoc = energyAnalysisSurface.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = energyAnalysisSurface.get_Geometry(opt);

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
                            double x = edgePts[0].X;
                            double y = edgePts[0].Y;
                            double z = edgePts[0].Z;
                            Coordinate point = new Coordinate(x,y,z);

                            vertices.Add(point);
                        }
                    }
                }
            }
            
            return vertices;
        }
    }

}
