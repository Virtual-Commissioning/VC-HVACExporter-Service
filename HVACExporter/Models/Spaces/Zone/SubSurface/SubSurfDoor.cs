using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.SubSurfDoor
{
    public class SubSurfDoor
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string SubSurfType { get; set; } // If bool is needed, define types and use the SubSurfType class
        public string ConstructionId { get; set; }
        public string HostSurfId { get; set; }
        public OutsideBCObj OutsideBCObj { get; set; }
        public string ViewFactorToGround { get; set; }
        public FrameAndDivider FrameAndDivider { get; set; } 
        public int Multiplier { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public SubSurfDoor(string id, string tag, SubSurfType subSurfType, string constructionId, string hostSurfId, OutsideBCObj outsideBCObj, string viewFactorToGround, FrameAndDivider frameAndDivider, int multiplier, VertexCoordinates vertexCoordinates)
        {
            Id = id;
            Tag = tag;
            SubSurfType = subSurfType;
            ConstructionId = constructionId;
            HostSurfId = hostSurfId;
            OutsideBCObj = outsideBCObj;
            ViewFactorToGround = viewFactorToGround;
            FrameAndDivider = frameAndDivider;
            Multiplier = multiplier;
            VertexCoordinates = vertexCoordinates;
        }
    }
}
