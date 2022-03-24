using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SurfaceGeometryMapper
    {
        public static List<Coordinate> MapSurfaceGeometry(EnergyAnalysisSurface energyAnalysisSurface, Document doc, string analyticalZoneId)
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
                            double x = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].X),4);
                            double y = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].Y),4);
                            double z = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].Z),4);
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
