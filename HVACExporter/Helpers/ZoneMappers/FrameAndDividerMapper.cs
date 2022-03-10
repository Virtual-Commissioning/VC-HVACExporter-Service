
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
using HVACExporter.Helpers.ZoneMappers.InternalGainsMappers;

namespace HVACExporter.Helpers
{
    public class FrameAndDividerMapper
    {
        public static FrameAndDivider MapFrameAndDivider
            (EnergyAnalysisOpening opening)
        {
            string id = opening.Id.ToString();
            string frameWidth = "";
            string frameOutsideProjection = "";
            string frameInsideProjection = "";
            string frameConductance = "";
            string ratioOfFrameEdgeGlassConductanceToCenterOfGlassConductance = "";
            string frameSolarAbsorptance = "";
            string frameVisibleAbsorptance = "";
            string frameThermalHemisphericalEmissivity = "";
            string dividerType = "";
            string dividerWidth = "";
            string numberOfHorizontalDividers = "";
            string numberOfVerticalDividers = "";
            string dividerOutsideProjection = "";
            string dividerInsideProjection = "";
            string dividerConductance = "";
            string ratioOfDividerEdgeGlassConductanceToCenterOfGlassConductance = "";
            string dividerSolarAbsorptance = "";
            string dividerVisibleAbsorptance = "";
            string dividerThermalHemisphericalEmissivity = "";
            string outsideRevealSolarAbsorptance = "";
            string insideSillDepth = "";
            string insideSillSolarAbsorptance = "";
            string insideRevealDepth = "";
            string insideRevealSolarAbsorptance = "";

            FrameAndDivider frameAndDivider = new FrameAndDivider(id, frameWidth, frameOutsideProjection, frameInsideProjection, frameConductance,
                ratioOfFrameEdgeGlassConductanceToCenterOfGlassConductance, frameSolarAbsorptance, frameVisibleAbsorptance, frameThermalHemisphericalEmissivity,
                dividerType, dividerWidth, numberOfHorizontalDividers, numberOfVerticalDividers, dividerOutsideProjection, dividerInsideProjection,
                dividerConductance, ratioOfDividerEdgeGlassConductanceToCenterOfGlassConductance, dividerSolarAbsorptance, dividerVisibleAbsorptance,
                dividerThermalHemisphericalEmissivity, outsideRevealSolarAbsorptance, insideSillDepth, insideSillSolarAbsorptance,
                insideRevealDepth, insideRevealSolarAbsorptance);
            return frameAndDivider;
        }

    }
}

