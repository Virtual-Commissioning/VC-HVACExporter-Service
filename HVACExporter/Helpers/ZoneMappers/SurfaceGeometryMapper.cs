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
                            double x = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].X),3);
                            double y = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].Y),3);
                            double z = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePts[0].Z),3);
                            Coordinate point = new Coordinate(x,y,z);
                            //In order to controll the direction of the normal vector of the surface, the order of vertices in the list is determined by:
                            if (energyAnalysisSurface.GetAnalyticalSpace().Id.ToString() == analyticalZoneId)
                            {
                                //vertices.Add(point);
                                vertices.Insert(0, point);
                            }
                            else
                            {
                                vertices.Add(point);
                                //vertices.Insert(0, point);
                            }
                        }
                    }
                }
            }
            return vertices;
        }
    }

}
