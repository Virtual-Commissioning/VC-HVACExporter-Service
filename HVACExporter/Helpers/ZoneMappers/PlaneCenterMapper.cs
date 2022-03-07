using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class PlaneCenterMapper
    {
        public static Coordinate MapPlaneCenter(EnergyAnalysisSurface energyAnalysisSurface, Document doc)
        {
            Document surfDoc = energyAnalysisSurface.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = energyAnalysisSurface.get_Geometry(opt);
            List<Coordinate> centerPoint = new List<Coordinate>();
            foreach (GeometryObject obj in geo)
            {
                Solid solid = obj as Solid;
                if (null == solid || 0 == solid.Faces.Size || 0 == solid.Edges.Size) continue;
                if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorFloor" ||
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
                {
                    foreach (Face face in solid.Faces)
                    {
                        EdgeArray loop = face.EdgeLoops.get_Item(0);
                        List<Coordinate> allVertices = new List<Coordinate>();
                        foreach (Autodesk.Revit.DB.Edge vertex in loop)
                        {
                            IList<XYZ> edgePts = vertex.Tessellate();
                            foreach (XYZ curve in edgePts)
                            {
                                Coordinate pnt = new Coordinate(curve.X, curve.Y, curve.Z);
                                allVertices.Add(pnt);
                            }
                        }
                        Coordinate calculatedCenter = new Coordinate(allVertices.Average(p => p.X),
                            allVertices.Average(p => p.Y), allVertices.Average(p => p.Z));

                        centerPoint.Add(calculatedCenter);
                    }
                }
                else if (energyAnalysisSurface.SurfaceType.ToString() == "Roof")
                {
                    double x = solid.ComputeCentroid().X;
                    double y = solid.ComputeCentroid().Y;
                    double z = solid.ComputeCentroid().Z - 0.005; //- 0.005 is an adjustment value to find the correct bounding box
                    Coordinate point = new Coordinate(x, y, z);

                    centerPoint.Add(point);
                }
                else
                {
                    double x = solid.ComputeCentroid().X;
                    double y = solid.ComputeCentroid().Y;
                    double z = solid.ComputeCentroid().Z;
                    Coordinate point = new Coordinate(x, y, z);

                    centerPoint.Add(point);
                }
                
            }
            if (null != centerPoint)
            {
                return centerPoint[0];
            }
            else
            {
                return null;
            }
        }
    }

}
