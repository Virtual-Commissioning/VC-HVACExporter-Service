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
            (string analyticalZoneId, Document doc, FilteredElementCollector allAnalyticalSurfaces, 
            FilteredElementCollector allAnalyticalSubSurfaces)
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
                    string id;
                    if (energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall" ||
                        energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
                    {
                        id = energyAnalysisSurface.Id.ToString() + "_" + analyticalZoneId;
                    }
                    else
                    {
                        id = energyAnalysisSurface.Id.ToString();
                    }

                    Coordinate planeCenter = PlaneCenterMapper.MapPlaneCenter(energyAnalysisSurface, doc);
                    string constructionId = GetAssociatedConstruction.MapAssociatedConstruction(planeCenter, doc, energyAnalysisSurface);
                    string surfType = energyAnalysisSurface.SurfaceType.ToString();
                    string zoneTag = analyticalZoneId;
                    OutsideBC outsideBC = OutsideBCMapper.MapOutsideBC(energyAnalysisSurface); //
                    OutsideBCObj outsideBCObj = OutsideBCObjMapper.MapOutsideBCObj(energyAnalysisSurface, outsideBC); //
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
                    Models.Zone.Surface surface = new Models.Zone.Surface(id, surfType,
                        constructionId, zoneTag, outsideBC, outsideBCObj, sunExposure, windExposure,
                        viewFactorToGround, vertexCoordinates, subSurfType);

                    allSurfaces.Add(surface);
                }
                else continue;
            }
            return allSurfaces;
        }

    }
}

