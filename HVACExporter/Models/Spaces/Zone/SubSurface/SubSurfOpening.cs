using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SubSurfOpening
    {
        public string Id { get; set; }
        public string SubSurfType { get; set; } // If bool is needed, define types and use the SubSurfType class
        public string ConstructionId { get; set; }
        public string ZoneId { get; set; }
        public string OutsideBCObj { get; set; }
        public string OutsideBC { get; set; }
        public bool SunExposure { get; set; }
        public bool WindExposure { get; set; }
        public string ViewFactorToGround { get; set; }
        public List<VertexCoordinates> Vertices { get; set; }

        public SubSurfOpening(string id, string subSurfType, string constructionId, string zoneId, 
            string outsideBCObj, string outsideBC, bool sunExposure, bool windExposure, 
            string viewFactorToGround, List<VertexCoordinates> vertices)
        {
            Id = id;
            SubSurfType = subSurfType;
            ConstructionId = constructionId;
            ZoneId = zoneId;
            OutsideBCObj = outsideBCObj;
            OutsideBC = outsideBC;
            SunExposure = sunExposure;
            WindExposure = windExposure;
            ViewFactorToGround = viewFactorToGround;
            Vertices = vertices;
        }
    }
}
