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
            List<SubSurfOpening> subSurfaceOpenings = OpeningSubSurfaceMapper.MapOpeningSubSurfaces(energyAnalysisSurface, doc, allAnalyticalSubSurfaces);
            List<SubSurfDoorAndWindow> subSurfDoor = new List<SubSurfDoorAndWindow>();
            List<SubSurfDoorAndWindow> subSurfWindow = new List<SubSurfDoorAndWindow>();
            List<SubSurfOpening> subSurfOpening = new List<SubSurfOpening>();

            subSurfOpening.AddRange(subSurfaceOpenings);
            foreach (SubSurfDoorAndWindow subSurfDoorAndWindow in subSurfaces)
            {
                if (subSurfDoorAndWindow.SubSurfType == "Window")
                {
                    subSurfWindow.Add(subSurfDoorAndWindow);
                }
                if (subSurfDoorAndWindow.SubSurfType == "Door")
                {
                    subSurfDoor.Add(subSurfDoorAndWindow);
                }
            }

            SubSurfType AllSubSurfaces = new SubSurfType(subSurfDoor, subSurfWindow, subSurfOpening);

            return AllSubSurfaces;
        }

    }
}

