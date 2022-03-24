using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SubSurfaceGeometryMapper
    {
        public static List<Coordinate> MapSubSurfaceGeometry
            (EnergyAnalysisOpening opening, Document doc, EnergyAnalysisSurface energyAnalysisSurface, string analyticalZoneId)
        {
            List<Coordinate> vertices = new List<Coordinate>();

            Document surfDoc = opening.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = opening.get_Geometry(opt);
            XYZ faceNormal = new XYZ();

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
                            PlanarFace planarFace = face as PlanarFace;
                            IList<XYZ> edgePts = vertex.Tessellate();
                            double x, y, z;
                            foreach (XYZ edgePt in edgePts)
                            {
                                x = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.X), 4);
                                y = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.Y), 4);
                                z = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.Z), 4) + 0.00001; //Value can be added to keep points within wall (+0.01)
                                Coordinate point = new Coordinate(x, y, z);
                                if (energyAnalysisSurface.GetAnalyticalSpace().Id.ToString() == analyticalZoneId)
                                {
                                    vertices.Add(point);
                                    faceNormal = - planarFace.FaceNormal;
                                }
                                else
                                {
                                    vertices.Add(point);
                                    faceNormal = planarFace.FaceNormal;
                                }
                            }
                        }
                    }
                }
            }
            List<Coordinate> newVertices = new List<Coordinate>();
            foreach (Coordinate coord in vertices)
            {
                if (!newVertices.Where(x => x.X == coord.X && x.Y == coord.Y && x.Z == coord.Z).Any())
                {
                    newVertices.Add(coord);
                }
            }

            List<Coordinate> sortedVertices = SortPointsV2.PointSorter(newVertices, faceNormal);
            
            return sortedVertices;
        }
    }

}
