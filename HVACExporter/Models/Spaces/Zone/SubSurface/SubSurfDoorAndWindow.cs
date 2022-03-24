using HVACExporter.Models.GeometricTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SubSurfDoorAndWindow
    {
        public string Name { get; set; }
        public string Surface_Type { get; set; } 
        public string Construction_Name { get; set; }
        public string Building_Surface_Name { get; set; }
        public string Outside_Boundary_Condition_Object { get; set; } 
        public string View_Factor_to_Ground { get; set; }
        public string Frame_and_Divider_Name { get; set; }
        public int? Multiplier { get; set; }
        public List<Coordinate> VertexCoordinates { get; set; }
        public FrameAndDivider FrameAndDivider { get; set; }

        public SubSurfDoorAndWindow(string name, string subSurfType, string constructionId, 
            string hostSurfId, string outsideBCObj, string viewFactorToGround, string frameAndDividerName, 
            int? multiplier, List<Coordinate> vertexCoordinates, FrameAndDivider frameAndDivider)
        {
            Name = name;
            Surface_Type = subSurfType;
            Construction_Name = constructionId;
            Building_Surface_Name = hostSurfId;
            Outside_Boundary_Condition_Object = outsideBCObj;
            View_Factor_to_Ground = viewFactorToGround;
            Frame_and_Divider_Name = frameAndDividerName;
            Multiplier = multiplier;
            VertexCoordinates = vertexCoordinates;
            FrameAndDivider = frameAndDivider;
        }
    }
}
