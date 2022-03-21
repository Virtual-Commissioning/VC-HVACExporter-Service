using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HVACExporter.Models.GeometricTypes;
using Autodesk.Revit.ApplicationServices;
using System;
using System.Linq;
using HVACExporter.Helpers.ZoneMappers;

namespace HVACExporter.Helpers
{
    public class SiteShadingMapper
    {
        public static List<Dictionary<string, ShadingSite>> MapSiteShading(FilteredElementCollector allMasses)
        {
            List<Dictionary<string, ShadingSite>> siteShadings = new List<Dictionary<string, ShadingSite>>();
            List<FamilyInstance> masses = new List<FamilyInstance>();
            foreach (FamilyInstance mass in allMasses)
            {
                Document surfDoc = mass.Document;
                Application app = surfDoc.Application;
                Options opt = app.Create.NewGeometryOptions();
                GeometryElement geo = mass.get_Geometry(opt);
                foreach (GeometryObject obj in geo)
                {
                    Solid solid = obj as Solid;
                    if (null != solid)
                    {
                        foreach (Face face in solid.Faces)
                        {
                            string name = mass.Id.ToString() + "_" + face.Id.ToString();
                            string transmSchedule = "";
                            List<Coordinate> vertices = new List<Coordinate>();
                            EdgeArray loop = face.EdgeLoops.get_Item(0);
                            PlanarFace planarFace = face as PlanarFace;
                            XYZ faceNormal = planarFace.FaceNormal;
                            foreach (Edge vertex in loop)
                            {
                                IList<XYZ> edgePts = vertex.Tessellate();
                                double x, y, z;
                                foreach (XYZ edgePt in edgePts)
                                {
                                    x = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.X), 3);
                                    y = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.Y), 3);
                                    z = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(edgePt.Z), 3);
                                    Coordinate point = new Coordinate(x, y, z);
                                    vertices.Add(point);
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
                            ShadingSite shadingSite = new ShadingSite(name, transmSchedule, sortedVertices);
                            Dictionary<string, ShadingSite> shadingElement = new Dictionary<string, ShadingSite>();
                            shadingElement.Add(name, shadingSite);

                            siteShadings.Add(shadingElement);
                        }
                    }
                }
            }
            

            return siteShadings;
        }
    }
}
