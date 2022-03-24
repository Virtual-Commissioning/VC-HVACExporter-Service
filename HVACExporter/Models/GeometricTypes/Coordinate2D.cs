namespace HVACExporter.Models.GeometricTypes
{
    public class Coordinate2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
