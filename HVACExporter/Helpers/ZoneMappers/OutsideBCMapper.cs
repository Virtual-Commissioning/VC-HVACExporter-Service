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

namespace HVACExporter.Helpers.ZoneMappers
{
    public class OutsideBCMapper
    {
        public static OutsideBC MapOutsideBC(EnergyAnalysisSurface energyAnalysisSurface)
        {
            string outsideBCType;
            if ((energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall" && energyAnalysisSurface.GetAnalyticalOpenings() == null) ||
                energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
            {
                outsideBCType = OutBC.Surface.ToString();
            }
            else if (energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall" &&
                energyAnalysisSurface.GetAnalyticalOpenings() != null)
            {
                outsideBCType = OutBC.Adiabatic.ToString();
            }
            else if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorWall" || 
                energyAnalysisSurface.SurfaceType.ToString() == "ExteriorFloor" || 
                energyAnalysisSurface.SurfaceType.ToString() == "Roof")
            {
                outsideBCType = OutBC.Outdoors.ToString();
            }
            else if (energyAnalysisSurface.SurfaceType.ToString() == "Ceiling")
            {
                outsideBCType = OutBC.Adiabatic.ToString();
            }
            else if (energyAnalysisSurface.SurfaceType.ToString() == "Underground")
            {
                outsideBCType = OutBC.Ground.ToString();
            }
            else
            {
                outsideBCType = null;
            }
            OutsideBC outsideBC = new OutsideBC(outsideBCType);

            return outsideBC;
        }
    }
}
