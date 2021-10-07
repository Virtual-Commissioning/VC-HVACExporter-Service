namespace HVACExporter.Models.GeometricTypes
{
    public class DirectionVector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public DirectionVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
