using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.VertexCoordinates
{
    public class VertexCoordinates
    {
        public List<Coordinate> Points { get; set; } // Figure out correct element types in list 


        public VertexCoordinates(List<T> points)
        {
            Points = points;
        }

    }
}
