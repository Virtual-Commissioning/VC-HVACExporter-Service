using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Autodesk.Revit.DB.Analysis;

namespace HVACExporter.Helpers
{
    public class SubSurfaceMapper
    {
        public static SubSurfType MapSubSurfaces
            (EnergyAnalysisSurface energyAnalysisSurface, EnergyAnalysisSpace energyAnalysisSpace, Document doc, 
            FilteredElementCollector allAnalyticalSubSurfaces, string analyticalZoneId, string constructionId)
        {
            List<SubSurfDoorAndWindow> subSurfaces = DoorAndWindowSubSurfaceMapper.MapDoorAndWindowSubSurfaces
                (energyAnalysisSurface, energyAnalysisSpace, doc, allAnalyticalSubSurfaces, analyticalZoneId);
            List<SubSurfOpening> subSurfaceOpenings = OpeningSubSurfaceMapper.MapOpeningSubSurfaces
                (energyAnalysisSurface, doc, allAnalyticalSubSurfaces, analyticalZoneId);

            List<Dictionary<string, SubSurfDoorAndWindow>> allSubSurfDoors = new List<Dictionary<string, SubSurfDoorAndWindow>>();
            List<Dictionary<string, SubSurfDoorAndWindow>> allSubSurfWindows = new List<Dictionary<string, SubSurfDoorAndWindow>>();
            List<Dictionary<string, SubSurfOpening>> allSubSurfOpenings = new List<Dictionary<string, SubSurfOpening>>();

            foreach (SubSurfOpening subSurfOpening in subSurfaceOpenings)
            {
                Dictionary<string, SubSurfOpening> linkedSubSurf = new Dictionary<string, SubSurfOpening>();
                linkedSubSurf.Add(subSurfOpening.Name, subSurfOpening);
                allSubSurfOpenings.Add(linkedSubSurf);
            }
            foreach (SubSurfDoorAndWindow subSurfDoorAndWindow in subSurfaces)
            {
                if (subSurfDoorAndWindow.Surface_Type == "Window")
                {
                    Dictionary<string, SubSurfDoorAndWindow> linkedSubSurf = new Dictionary<string, SubSurfDoorAndWindow>();
                    linkedSubSurf.Add(subSurfDoorAndWindow.Name, subSurfDoorAndWindow);
                    allSubSurfWindows.Add(linkedSubSurf);
                }
                else if (subSurfDoorAndWindow.Surface_Type == "Door")
                {
                    Dictionary<string, SubSurfDoorAndWindow> linkedSubSurf = new Dictionary<string, SubSurfDoorAndWindow>();
                    linkedSubSurf.Add(subSurfDoorAndWindow.Name, subSurfDoorAndWindow);
                    allSubSurfDoors.Add(linkedSubSurf);
                }
                else continue;
            }
            if (constructionId != null && constructionId.Contains("CW_") == true)
            {
                SubSurfDoorAndWindow curtainWallWindows = CurtainWallWindowSubSurfaceMapper.MapCurtainWallWindowSubSurfaces
                    (energyAnalysisSurface, energyAnalysisSpace, doc, constructionId, analyticalZoneId);
                Dictionary<string, SubSurfDoorAndWindow> linkedSubSurf = new Dictionary<string, SubSurfDoorAndWindow>();
                linkedSubSurf.Add(curtainWallWindows.Name, curtainWallWindows);
                allSubSurfWindows.Add(linkedSubSurf);
            }

            SubSurfType AllSubSurfaces = new SubSurfType(allSubSurfDoors, allSubSurfWindows, allSubSurfOpenings);

            return AllSubSurfaces;
        }

    }
}

