using HVACExporter.Models.GeometricTypes;
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
        public string SurfType { get; set; }
        public string ConstructionId { get; set; }
        public string ZoneTag { get; set; }
        public string OutsideBC { get; set; }  
        public string OutsideBCObject { get; set; }
        public bool SunExposure { get; set; }
        public bool WindExposure { get; set; }
        public string ViewFactorToGround { get; set; } 
        public List<Coordinate> VertexCoordinates { get; set; }
        public SubSurfType SubSurfaceType { get; set; }

        public Surface(string id,
            string surfType,
            string constructionId,
            string zoneTag,
            string outsideBC, 
            string outsideBCObject,
            bool sunExposure,
            bool windExposure,
            string viewFactorToGround,
            List<Coordinate> vertexCoordinates, 
            SubSurfType subSurfaceType)
        {
            Id = id;
            SurfType = surfType;
            ConstructionId = constructionId;
            ZoneTag = zoneTag;
            OutsideBC = outsideBC;
            OutsideBCObject = outsideBCObject;
            SunExposure = sunExposure;
            WindExposure = windExposure;
            ViewFactorToGround = viewFactorToGround;
            VertexCoordinates = vertexCoordinates;
            SubSurfaceType = subSurfaceType;
        }
    }
}
