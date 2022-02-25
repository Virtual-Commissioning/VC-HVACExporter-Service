using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using HVACExporter.Models.Spaces.Geometry;


namespace HVACExporter.Models.Zone
{
    public class VertexCoordinates
    {
        public List<Spaces.Geometry.Edge> Footprint { get; set; } // Figure out correct element types in list 


        public VertexCoordinates(List<Spaces.Geometry.Edge> footprint)
        {
            Footprint = footprint;
        }

    }
}
