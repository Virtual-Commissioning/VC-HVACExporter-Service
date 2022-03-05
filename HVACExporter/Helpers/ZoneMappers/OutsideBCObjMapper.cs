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
    public class OutsideBCObjMapper
    {
        public static OutsideBCObj MapOutsideBCObj(EnergyAnalysisSurface energyAnalysisSurface, OutsideBC outsideBC)
        {
            string outsideBCObjType;
            if (outsideBC.OutsideBCType == "Zone")
            {
                outsideBCObjType = energyAnalysisSurface.GetAdjacentAnalyticalSpace().Id.ToString();
            }
            else if (outsideBC.OutsideBCType == "Surface")
            {
                outsideBCObjType = energyAnalysisSurface.Id.ToString();
            }
            else
            {
                outsideBCObjType = null;
            }
            OutsideBCObj outsideBCObj = new OutsideBCObj(outsideBCObjType);

            return outsideBCObj;
        }
    }
}
