using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.SubSurfOpening
{
    public class SubSurfOpening
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string SubSurfType { get; set; } // If bool is needed, define types and use the SubSurfType class
        public string ConstructionId { get; set; }
        public string ZoneId { get; set; }
        public string SpaceId { get; set; }
        public OutsideBCObj OutsideBCObj { get; set; }
        public string OutsideBC { get; set; }
        public bool SunExposure { get; set; }
        public bool WindExposure { get; set; }
        public string ViewFactorToGround { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public SubSurfOpening(string id, string tag, SubSurfType subSurfType, string constructionId, string zoneId, string spaceId, OutsideBCObj outsideBCObj, OutsideBC outsideBC, bool sunExposure, bool windExposure, string viewFactorToGround, VertexCoordinates vertexCoordinates)
        {
            Id = id;
            Tag = tag;
            SubSurfType = subSurfType;
            ConstructionId = constructionId;
            ZoneId = zoneId;
            SpaceId = spaceId;
            OutsideBCObj = outsideBCObj;
            OutsideBC = outsideBC;
            SunExposure = sunExposure;
            WindExposure = windExposure;
            ViewFactorToGround = viewFactorToGround;
            VertexCoordinates = vertexCoordinates;
        }
    }
}
