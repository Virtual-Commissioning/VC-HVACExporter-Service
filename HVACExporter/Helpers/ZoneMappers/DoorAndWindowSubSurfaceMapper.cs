
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

namespace HVACExporter.Helpers
{
    public class DoorAndWindowSubSurfaceMapper
    {
        public static List<SubSurfDoorAndWindow> MapDoorAndWindowSubSurfaces
            (EnergyAnalysisSurface energyAnalysisSurface, Document doc, FilteredElementCollector allAnalyticalSurfaces)
        {
            List<SubSurfDoorAndWindow> allSubSurfaces = new List<SubSurfDoorAndWindow>();

            EnergyAnalysisSurface analyticalSurface = doc.GetElement(energyAnalysisSurface.Id) as EnergyAnalysisSurface;
            IList<EnergyAnalysisOpening> subSurfaces = analyticalSurface.GetAnalyticalOpenings();
            foreach (EnergyAnalysisOpening opening in subSurfaces)
            {
                if (opening.OpeningType.ToString() == "Air") continue;
                string id = opening.Id.ToString();
                string subSurfType = opening.OpeningType.ToString();
                Coordinate openingCenter = SubSurfaceCenterMapper.MapSubSurface(opening, doc);
                string constructionId = GetAssociatedOpeningConstruction.MapAssociatedOpeningConstruction(openingCenter, doc, opening);
                string hostSurfId;
                if (energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall" ||
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
                {
                    hostSurfId = energyAnalysisSurface.Id.ToString() + "_" + energyAnalysisSurface.GetAdjacentAnalyticalSpace().ToString();
                }
                else
                {
                    hostSurfId = energyAnalysisSurface.Id.ToString();
                }
                string outsideBCObj = "NA";
                string viewFactorToGround = "NA";
                int multiplier = 1;
                FrameAndDivider frameAndDivider = FrameAndDividerMapper.MapFrameAndDivider(opening);
                string frameAndDividerName = frameAndDivider.Name;
                List<Coordinate> vertices = SubSurfaceGeometryMapper.MapSubSurfaceGeometry(opening, doc);
                SubSurfDoorAndWindow subSurfaceToAdd = new SubSurfDoorAndWindow
                    (id, subSurfType, constructionId, hostSurfId, outsideBCObj, viewFactorToGround, 
                    frameAndDividerName, multiplier, vertices, frameAndDivider);
                
                allSubSurfaces.Add(subSurfaceToAdd);
            }

            
            return allSubSurfaces;
        }

    }
}

