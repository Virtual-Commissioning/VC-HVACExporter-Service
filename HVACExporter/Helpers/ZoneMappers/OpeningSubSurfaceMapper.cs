
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
    public class OpeningSubSurfaceMapper
    {
        public static List<SubSurfOpening> MapOpeningSubSurfaces
            (EnergyAnalysisSurface energyAnalysisSurface, Document doc, FilteredElementCollector allAnalyticalSurfaces)
        {
            List<SubSurfOpening> allSubSurfaces = new List<SubSurfOpening>();

            EnergyAnalysisSurface analyticalSurface = doc.GetElement(energyAnalysisSurface.Id) as EnergyAnalysisSurface;
            IList<EnergyAnalysisOpening> subSurfaces = analyticalSurface.GetAnalyticalOpenings();
            foreach (EnergyAnalysisOpening opening in subSurfaces)
            {
                if (opening.OpeningType.ToString() != "Air") continue;
                string id = opening.Id.ToString();
                string subSurfType = opening.OpeningType.ToString();
                string constructionId = opening.Type.ToString();
                string zoneId = analyticalSurface.GetAdjacentAnalyticalSpace().Id.ToString();
                string outsideBCObj = "NA";
                string outsideBC = "NA";
                bool sunExposure;
                bool windExposure;
                if (analyticalSurface.GetAnalyticalOpenings().Count > 0 && analyticalSurface.SurfaceType.ToString() == "ExteriorWall")
                {
                    sunExposure = true;
                    windExposure = true;
                }
                else
                {
                    sunExposure = false;
                    windExposure = false;
                }
                string viewFactorToGround = "NA";
                List<VertexCoordinates> vertices = SubSurfaceGeometryMapper.MapSubSurfaceGeometry(opening, doc);
                SubSurfOpening subSurfaceToAdd = new SubSurfOpening
                    (id, subSurfType, constructionId, zoneId, outsideBCObj, outsideBC, sunExposure, windExposure, viewFactorToGround, vertices);

                allSubSurfaces.Add(subSurfaceToAdd);
            }

            
            return allSubSurfaces;
        }

    }
}

