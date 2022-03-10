using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Autodesk.Revit.DB.Analysis;

namespace HVACExporter.Helpers
{
    public class SubSurfaceMapper
    {
        public static SubSurfType MapSubSurfaces
            (EnergyAnalysisSurface energyAnalysisSurface, Document doc, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            List<SubSurfDoorAndWindow> subSurfaces = DoorAndWindowSubSurfaceMapper.MapDoorAndWindowSubSurfaces
                (energyAnalysisSurface, doc, allAnalyticalSubSurfaces);
            List<SubSurfOpening> subSurfaceOpenings = OpeningSubSurfaceMapper.MapOpeningSubSurfaces
                (energyAnalysisSurface, doc, allAnalyticalSubSurfaces);

            List<Dictionary<string, SubSurfDoorAndWindow>> allSubSurfDoors = new List<Dictionary<string, SubSurfDoorAndWindow>>();
            List<Dictionary<string, SubSurfDoorAndWindow>> allSubSurfWindows = new List<Dictionary<string, SubSurfDoorAndWindow>>();
            List<Dictionary<string, SubSurfOpening>> allSubSurfOpenings = new List<Dictionary<string, SubSurfOpening>>();

            foreach (SubSurfOpening subSurfOpening in subSurfaceOpenings)
            {
                Dictionary<string, SubSurfOpening> linkedSubSurf = new Dictionary<string, SubSurfOpening>();
                linkedSubSurf.Add(subSurfOpening.Id, subSurfOpening);
                allSubSurfOpenings.Add(linkedSubSurf);
            }
            foreach (SubSurfDoorAndWindow subSurfDoorAndWindow in subSurfaces)
            {
                if (subSurfDoorAndWindow.SubSurfType == "Window")
                {
                    Dictionary<string, SubSurfDoorAndWindow> linkedSubSurf = new Dictionary<string, SubSurfDoorAndWindow>();
                    linkedSubSurf.Add(subSurfDoorAndWindow.Id, subSurfDoorAndWindow);
                    allSubSurfWindows.Add(linkedSubSurf);
                }
                if (subSurfDoorAndWindow.SubSurfType == "Door")
                {
                    Dictionary<string, SubSurfDoorAndWindow> linkedSubSurf = new Dictionary<string, SubSurfDoorAndWindow>();
                    linkedSubSurf.Add(subSurfDoorAndWindow.Id, subSurfDoorAndWindow);
                    allSubSurfDoors.Add(linkedSubSurf);
                }
                else continue;
            }

            SubSurfType AllSubSurfaces = new SubSurfType(allSubSurfDoors, allSubSurfWindows, allSubSurfOpenings);

            return AllSubSurfaces;
        }

    }
}

