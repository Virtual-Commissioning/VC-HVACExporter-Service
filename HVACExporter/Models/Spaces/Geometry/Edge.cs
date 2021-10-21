using HVACExporter.Models.GeometricTypes;

namespace HVACExporter.Models.Spaces.Geometry
{
    public class Edge
    {
        public Coordinate Point1 { get; set; }
        public Coordinate Point2 { get; set; }

        public Edge(Coordinate point1, Coordinate point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
    }
}
