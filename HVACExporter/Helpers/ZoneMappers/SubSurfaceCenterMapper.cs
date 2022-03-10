using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class SubSurfaceCenterMapper
    {
        public static Coordinate MapSubSurface(EnergyAnalysisOpening energyAnalysisSubSurface, Document doc)
        {
            Document surfDoc = energyAnalysisSubSurface.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = energyAnalysisSubSurface.get_Geometry(opt);
            List<Coordinate> centerPoint = new List<Coordinate>();
            foreach (GeometryObject obj in geo)
            {
                Solid solid = obj as Solid;
                if (null == solid || 0 == solid.Faces.Size || 0 == solid.Edges.Size) continue;
                
                double x = solid.ComputeCentroid().X;
                double y = solid.ComputeCentroid().Y;
                double z = solid.ComputeCentroid().Z;
                Coordinate point = new Coordinate(x, y, z);

                centerPoint.Add(point);
                
                
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
