using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Connectors;

namespace HVACExporter.Models.Connectors
{
    public class Connector
    {
        public string Tag { get; set; }
        public double Dimension { get; set; }
        public string Shape { get; set; }
        public Coordinate Coordinate { get; set; }
        public DirectionVector DirectionVector { get; set; }
        public ConnectorType ConnectorType { get; set; }


        public Connector(string tag, double dimension, string shape, Coordinate coordinate,
                         DirectionVector directionVector, ConnectorType connectorType)
        {
            Tag = tag;
            Dimension = dimension;
            Shape = shape;
            Coordinate = coordinate;
            DirectionVector = directionVector;
            ConnectorType = connectorType;
        }
    }
}
