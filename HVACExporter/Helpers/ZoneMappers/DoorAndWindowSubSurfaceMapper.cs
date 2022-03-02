
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
                string constructionId = opening.Type.ToString();
                string hostSurfId = energyAnalysisSurface.Id.ToString();
                string outsideBCObj = "NA";
                string viewFactorToGround = "NA";
                int multiplier = 1;
                FrameAndDivider frameAndDivider = null; //FrameAndDividerMapper.MapFrameAndDivider;
                List<VertexCoordinates> vertices = SubSurfaceGeometryMapper.MapSubSurfaceGeometry(opening, doc);
                SubSurfDoorAndWindow subSurfaceToAdd = new SubSurfDoorAndWindow
                    (id, subSurfType, constructionId, hostSurfId, outsideBCObj, viewFactorToGround, frameAndDivider,multiplier, vertices);

                allSubSurfaces.Add(subSurfaceToAdd);
            }

            
            return allSubSurfaces;
        }

    }
}

