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
        public string Name { get; set; }
        public string Surface_Type { get; set; }
        public string Construction_Name { get; set; }
        public string Zone_Name { get; set; }
        public string Outside_Boundary_Condition { get; set; }  
        public string Outside_Boundary_Condition_Object { get; set; }
        public bool Sun_Exposure { get; set; }
        public bool Wind_Exposure { get; set; }
        public string View_Factor_to_Ground { get; set; } 
        public List<Coordinate> VertexCoordinates { get; set; }
        public SubSurfType SubSurfaces { get; set; }

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
            Name = id;
            Surface_Type = surfType;
            Construction_Name = constructionId;
            Zone_Name = zoneTag;
            Outside_Boundary_Condition = outsideBC;
            Outside_Boundary_Condition_Object = outsideBCObject;
            Sun_Exposure = sunExposure;
            Wind_Exposure = windExposure;
            View_Factor_to_Ground = viewFactorToGround;
            VertexCoordinates = vertexCoordinates;
            SubSurfaces = subSurfaceType;
        }
    }
}
