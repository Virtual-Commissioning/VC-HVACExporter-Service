using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class FrameAndDivider
    {
        public string Name { get; set; }
        public string Frame_Width { get; set; }
        public string Frame_Outside_Projection { get; set; }
        public string Frame_Inside_Projection { get; set; }
        public string Frame_Conductance { get; set; }
        public string Ratio_of_FrameEdge_Glass_Conductance_to_CenterOfGlass_Conductance { get; set; }
        public string Frame_Solar_Absorptance { get; set; }
        public string Frame_Visible_Absorptance { get; set; }
        public string Frame_Thermal_Hemispherical_Emissivity { get; set; }
        public string Divider_Type { get; set; }
        public string Divider_Width { get; set; }
        public string Number_of_Horizontal_Dividers { get; set; }
        public string Number_of_Vertical_Dividers { get; set; }
        public string Divider_Outside_Projection { get; set; }
        public string Divider_Inside_Projection { get; set; }
        public string Divider_Conductance { get; set; }
        public string Ratio_of_DividerEdge_Glass_Conductance_to_CenterOfGlass_Conductance { get; set; }
        public string Divider_Solar_Absorptance { get; set; }
        public string Divider_Visible_Absorptance { get; set; }
        public string Divider_Thermal_Hemispherical_Emissivity { get; set; }
        public string Outside_Reveal_Solar_Absorptance { get; set; }
        public string Inside_Sill_Depth { get; set; }
        public string Inside_Sill_Solar_Absorptance { get; set; }
        public string Inside_Reveal_Depth { get; set; }
        public string Inside_Reveal_Solar_Absorptance { get; set; }

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
            Name = id;
            Frame_Width = frameWidth;
            Frame_Outside_Projection = frameOutsideProjection;
            Frame_Inside_Projection = frameInsideProjection;
            Frame_Conductance = frameConductance;
            Ratio_of_FrameEdge_Glass_Conductance_to_CenterOfGlass_Conductance = ratioOfFrameEdgeGlassConductanceToCenterOfGlassConductance;
            Frame_Solar_Absorptance = frameSolarAbsorptance;
            Frame_Visible_Absorptance = frameVisibleAbsorptance;
            Frame_Thermal_Hemispherical_Emissivity = frameThermalHemisphericalEmissivity;
            Divider_Type = dividerType;
            Divider_Width = dividerWidth;
            Number_of_Horizontal_Dividers = numberOfHorizontalDividers;
            Number_of_Vertical_Dividers = numberOfVerticalDividers;
            Divider_Outside_Projection = dividerOutsideProjection;
            Divider_Inside_Projection = dividerInsideProjection;
            Divider_Conductance = dividerConductance;
            Ratio_of_DividerEdge_Glass_Conductance_to_CenterOfGlass_Conductance = ratioOfDividerEdgeGlassConductanceToCenterOfGlassConductance;
            Divider_Solar_Absorptance = dividerSolarAbsorptance;
            Divider_Visible_Absorptance = dividerVisibleAbsorptance;
            Divider_Thermal_Hemispherical_Emissivity = dividerThermalHemisphericalEmissivity;
            Outside_Reveal_Solar_Absorptance = outsideRevealSolarAbsorptance;
            Inside_Sill_Depth = insideSillDepth;
            Inside_Sill_Solar_Absorptance = insideSillSolarAbsorptance;
            Inside_Reveal_Depth = insideRevealDepth;
            Inside_Reveal_Solar_Absorptance = insideRevealSolarAbsorptance;
        }
    }
}