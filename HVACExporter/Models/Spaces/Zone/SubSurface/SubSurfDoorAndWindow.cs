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
        public string Id { get; set; }
        public string SubSurfType { get; set; } // If bool is needed, define types and use the SubSurfType class
        public string ConstructionId { get; set; }
        public string HostSurfId { get; set; }
        public string OutsideBCObj { get; set; } //Later use OutsideBCObj
        public string ViewFactorToGround { get; set; }
        public string FrameAndDividerName { get; set; }
        public int Multiplier { get; set; }
        public List<Coordinate> VertexCoordinates { get; set; }
        public FrameAndDivider FrameAndDivider { get; set; }

        public SubSurfDoorAndWindow(string id, string subSurfType, string constructionId, 
            string hostSurfId, string outsideBCObj, string viewFactorToGround, string frameAndDividerName, 
            int multiplier, List<Coordinate> vertexCoordinates, FrameAndDivider frameAndDivider)
        {
            Id = id;
            SubSurfType = subSurfType;
            ConstructionId = constructionId;
            HostSurfId = hostSurfId;
            OutsideBCObj = outsideBCObj;
            ViewFactorToGround = viewFactorToGround;
            FrameAndDividerName = frameAndDividerName;
            Multiplier = multiplier;
            VertexCoordinates = vertexCoordinates;
            FrameAndDivider = frameAndDivider;
        }
    }
}
