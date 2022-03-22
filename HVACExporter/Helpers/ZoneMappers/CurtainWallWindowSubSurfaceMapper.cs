
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Helpers.ZoneMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Zone;
using HVACExporter;
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.ApplicationServices;

namespace HVACExporter.Helpers
{
    public class CurtainWallWindowSubSurfaceMapper
    {
        public static SubSurfDoorAndWindow MapCurtainWallWindowSubSurfaces
            (EnergyAnalysisSurface energyAnalysisSurface, EnergyAnalysisSpace energyAnalysisSpace, Document doc, 
            string surfConstructionId, string analyticalZoneId)
        {
            string name = "CW_Window_" + energyAnalysisSurface.Id.ToString();
            string subSurfType = "Window";
            string constructionName = surfConstructionId + "_Window";
            string hostSurfaceName = energyAnalysisSurface.Id.ToString();
            string outsideBCObj;
            if (energyAnalysisSurface.GetAdjacentAnalyticalSpace() != null)
            {
                if (energyAnalysisSurface.GetAnalyticalSpace().Id == energyAnalysisSpace.Id)
                {
                    outsideBCObj = energyAnalysisSurface.Id.ToString() + "_" + energyAnalysisSurface.GetAdjacentAnalyticalSpace().Id.ToString();
                }
                else
                {
                    outsideBCObj = energyAnalysisSurface.Id.ToString() + "_" + energyAnalysisSurface.GetAnalyticalSpace().Id.ToString();
                }
            }
            else
            {
                outsideBCObj = "";
            }
            string viewFactorToGround = "";
            string frameAndDividerName = "CW_Window_" + energyAnalysisSurface.Id.ToString() + "_Frame";
            int multiplier = 1;
            FrameAndDivider frameAndDivider = CWFrameAndDividerMapper.MapCWFrameAndDivider(energyAnalysisSurface);
            List<Coordinate> vertices = SurfaceGeometryMapper.MapSurfaceGeometry(energyAnalysisSurface, doc, analyticalZoneId);
            Coordinate planeCenter = PlaneCenterMapper.MapPlaneCenter(energyAnalysisSurface,doc);
            XYZ faceNormal = new XYZ();
            Document surfDoc = energyAnalysisSurface.Document;
            Application app = surfDoc.Application;
            Options opt = app.Create.NewGeometryOptions();
            GeometryElement geo = energyAnalysisSurface.get_Geometry(opt);
            foreach (GeometryObject obj in geo)
            {
                Solid solid = obj as Solid;
                if (null == solid) continue;
                foreach (Face face in solid.Faces)
                {
                    PlanarFace planarFace = face as PlanarFace;
                    faceNormal = planarFace.FaceNormal;
                }
            }     
            List<Coordinate> newVertices = new List<Coordinate>();
            foreach (Coordinate vertex in vertices)
            {
                Coordinate newVertex = MovePointTowardsPoint.PointMover(vertex, planeCenter, 0.0, faceNormal);
                
                newVertices.Add(newVertex);
            }
            List<Coordinate> sortedVertices = SortPointsV2.PointSorter(newVertices, faceNormal);

            SubSurfDoorAndWindow subSurface = new SubSurfDoorAndWindow
                (name, subSurfType, constructionName, hostSurfaceName, outsideBCObj, viewFactorToGround, 
                frameAndDividerName, multiplier, sortedVertices, frameAndDivider);

            return subSurface;
        }

    }
}

