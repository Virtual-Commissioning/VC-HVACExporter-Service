using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;


namespace HVACExporter.Models.Zone
{
    public class VertexCoordinates
    {
        public List<Coordinate> Vertices { get; set; } // Figure out correct element types in list 

        public VertexCoordinates(List<Coordinate> vertices)
        {
            Vertices = vertices;
        }

    }
}
