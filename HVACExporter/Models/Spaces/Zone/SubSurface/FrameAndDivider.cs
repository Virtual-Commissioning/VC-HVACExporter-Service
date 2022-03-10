using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class FrameAndDivider
    {
        public string Id { get; set; }
        public string FrameWidth { get; set; }
        public string FrameOutsideProjection { get; set; }
        public string FrameInsideProjection { get; set; }
        public string FrameConductance { get; set; }
        public string RatioOfFrameEdgeGlassConductanceToCenterOfGlassConductance { get; set; }
        public string FrameSolarAbsorptance { get; set; }
        public string FrameVisibleAbsorptance { get; set; }
        public string FrameThermalHemisphericalEmissivity { get; set; }
        public string DividerType { get; set; }
        public string DividerWidth { get; set; }
        public string NumberOfHorizontalDividers { get; set; }
        public string NumberOfVerticalDividers { get; set; }
        public string DividerOutsideProjection { get; set; }
        public string DividerInsideProjection { get; set; }
        public string DividerConductance { get; set; }
        public string RatioOfDividerEdgeGlassConductanceToCenterOfGlassConductance { get; set; }
        public string DividerSolarAbsorptance { get; set; }
        public string DividerVisibleAbsorptance { get; set; }
        public string DividerThermalHemisphericalEmissivity { get; set; }
        public string OutsideRevealSolarAbsorptance { get; set; }
        public string InsideSillDepth { get; set; }
        public string InsideSillSolarAbsorptance { get; set; }
        public string InsideRevealDepth { get; set; }
        public string InsideRevealSolarAbsorptance { get; set; }

        public FrameAndDivider(string id,
            string frameWidth,
            string frameOutsideProjection,
            string frameInsideProjection,
            string frameConductance,
            string ratioOfFrameEdgeGlassConductanceToCenterOfGlassConductance,
            string frameSolarAbsorptance,
            string frameVisibleAbsorptance,
            string frameThermalHemisphericalEmissivity,
            string dividerType,
            string dividerWidth,
            string numberOfHorizontalDividers,
            string numberOfVerticalDividers,
            string dividerOutsideProjection,
            string dividerInsideProjection,
            string dividerConductance,
            string ratioOfDividerEdgeGlassConductanceToCenterOfGlassConductance,
            string dividerSolarAbsorptance,
            string dividerVisibleAbsorptance,
            string dividerThermalHemisphericalEmissivity,
            string outsideRevealSolarAbsorptance,
            string insideSillDepth,
            string insideSillSolarAbsorptance,
            string insideRevealDepth,
            string insideRevealSolarAbsorptance)
        {
            Id = id;
            FrameWidth = frameWidth;
            FrameOutsideProjection = frameOutsideProjection;
            FrameInsideProjection = frameInsideProjection;
            FrameConductance = frameConductance;
            RatioOfFrameEdgeGlassConductanceToCenterOfGlassConductance = ratioOfFrameEdgeGlassConductanceToCenterOfGlassConductance;
            FrameSolarAbsorptance = frameSolarAbsorptance;
            FrameVisibleAbsorptance = frameVisibleAbsorptance;
            FrameThermalHemisphericalEmissivity = frameThermalHemisphericalEmissivity;
            DividerType = dividerType;
            DividerWidth = dividerWidth;
            NumberOfHorizontalDividers = numberOfHorizontalDividers;
            NumberOfVerticalDividers = numberOfVerticalDividers;
            DividerOutsideProjection = dividerOutsideProjection;
            DividerInsideProjection = dividerInsideProjection;
            DividerConductance = dividerConductance;
            RatioOfDividerEdgeGlassConductanceToCenterOfGlassConductance = ratioOfDividerEdgeGlassConductanceToCenterOfGlassConductance;
            DividerSolarAbsorptance = dividerSolarAbsorptance;
            DividerVisibleAbsorptance = dividerVisibleAbsorptance;
            DividerThermalHemisphericalEmissivity = dividerThermalHemisphericalEmissivity;
            OutsideRevealSolarAbsorptance = outsideRevealSolarAbsorptance;
            InsideSillDepth = insideSillDepth;
            InsideSillSolarAbsorptance = insideSillSolarAbsorptance;
            InsideRevealDepth = insideRevealDepth;
            InsideRevealSolarAbsorptance = insideRevealSolarAbsorptance;
        }
    }
}