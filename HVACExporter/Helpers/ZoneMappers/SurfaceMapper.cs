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
    public class SurfaceMapper
    {
        public static List<Models.Zone.Surface> MapSurfaces
            (string analyticalZoneId, Document doc, FilteredElementCollector allAnalyticalSurfaces, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            List<Models.Zone.Surface> allSurfaces = new List<Models.Zone.Surface>();

            foreach (EnergyAnalysisSurface energyAnalysisSurface in allAnalyticalSurfaces)
            {
                string surfaceAnalyticalSpaceId = energyAnalysisSurface.GetAnalyticalSpace().Id.ToString();
                string surfaceAdjacentAnalyticalSpaceId;
                if (energyAnalysisSurface.GetAdjacentAnalyticalSpace() != null)
                {
                    surfaceAdjacentAnalyticalSpaceId = energyAnalysisSurface.GetAdjacentAnalyticalSpace().Id.ToString();
                }
                else { surfaceAdjacentAnalyticalSpaceId = "0"; }

                if (surfaceAnalyticalSpaceId == analyticalZoneId || surfaceAdjacentAnalyticalSpaceId == analyticalZoneId)
                {
                    string id = energyAnalysisSurface.Id.ToString();
                    string constructionName = energyAnalysisSurface.Id.ToString(); //Figure out how to associate later
                    string surfType = energyAnalysisSurface.SurfaceType.ToString();
                    string zoneTag = analyticalZoneId;
                    string outsideBC = "NA";
                    string OutsideBCObj = "NA";
                    bool sunExposure;
                    bool windExposure;
                    if ((energyAnalysisSurface.SurfaceType.ToString() == "ExteriorWall") || (energyAnalysisSurface.SurfaceType.ToString() == "Roof"))
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
                    List<VertexCoordinates> vertexCoordinates = SurfaceGeometryMapper.MapSurfaceGeometry(energyAnalysisSurface, doc);

                    SubSurfType subSurfType = SubSurfaceMapper.MapSubSurfaces(energyAnalysisSurface, doc, allAnalyticalSubSurfaces);

                    Models.Zone.Surface surface = new Models.Zone.Surface(id, constructionName,
                        surfType, zoneTag, outsideBC, OutsideBCObj, sunExposure, windExposure,
                        viewFactorToGround, vertexCoordinates, subSurfType);

                    allSurfaces.Add(surface);
                }
                else continue;
            }
            return allSurfaces;
        }

    }
}

