using HVACExporter.Models.GeometricTypes;

namespace HVACExporter.Models.Connectors
{
    public class Connector
    {
        public string Tag { get; set; }
        public double Dimension { get; set; }
        public string Shape { get; set; }
        public double DesignFlow { get; set; }
        public Coordinate Coordinate { get; set; }
        public DirectionVector DirectionVector { get; set; }
        public ConnectorType ConnectorType { get; set; }


        public Connector(string tag, double dimension, string shape, double designFlow, Coordinate coordinate,
                         DirectionVector directionVector, ConnectorType connectorType)
        {
            Tag = tag;
            Dimension = dimension;
            Shape = shape;
            DesignFlow = designFlow;
            Coordinate = coordinate;
            DirectionVector = directionVector;
            ConnectorType = connectorType;
        }
    }
}
