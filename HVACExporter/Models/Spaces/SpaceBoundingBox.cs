using HVACExporter.Models.GeometricTypes;

namespace HVACExporter.Models.Spaces
{
    public class SpaceBoundingBox
    {
        public Coordinate MinCoordinate { get; set; }
        public Coordinate MaxCoordinate { get; set; }

        public SpaceBoundingBox(Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            MinCoordinate = minCoordinate;
            MaxCoordinate = maxCoordinate;
        }
    }
}
