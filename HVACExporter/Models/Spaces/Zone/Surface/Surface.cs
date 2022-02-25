using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Surface
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string SurfType { get; set; } // If bool is needed, use the SurfType class
        public string ConstructionId { get; set; }
        public string ZoneTag { get; set; }
        public string OutsideBC { get; set; }    //Class changed from OutsideBC for testing
        public string OutsideBCObject { get; set; }
        public bool SunExposure { get; set; }
        public bool WindExposure { get; set; }
        public string ViewFactorToGround { get; set; } // Not sure how to define this
        public VertexCoordinates VertexCoordinates { get; set; }

        public Surface(string id, 
            string tag, 
            string surfType, 
            string constructionId, 
            string zoneTag, 
            string outsideBC, //Class changed from OutsideBC for testing
            bool sunExposure, 
            bool windExposure, 
            string viewFactorToGround, 
            VertexCoordinates vertexCoordinates)
        {
            Id = id;
            Tag = tag;
            SurfType = surfType;
            ConstructionId = constructionId;
            ZoneTag = zoneTag;
            OutsideBC = outsideBC;
            SunExposure = sunExposure;
            WindExposure = windExposure;
            ViewFactorToGround = viewFactorToGround;
            VertexCoordinates = vertexCoordinates;
        }
    }
}
