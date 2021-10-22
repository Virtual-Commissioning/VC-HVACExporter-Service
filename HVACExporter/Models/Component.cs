using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HVACExporter.Helpers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Connectors;
using System;
using System.Collections.Generic;

namespace HVACExporter.Models
{
    public class Component
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string ComponentType { get; set; }
        public string SystemName { get; set; }
        public string SystemType { get; set; }
        public List<Connectors.Connector> ConnectedWith { get; set; } = new List<Connectors.Connector>();
        public List<string> ContainedInSpaces { get; set; } = new List<string>();

        public Component(string id, string tag, string systemName, string systemType)
        {
            Id = id;
            Tag = tag;
            SystemName = systemName;
            SystemType = systemType;
        }

        public void FillConnectedComponents(MEPCurve segment)
        {
            ConnectorSet connectorSet = segment.ConnectorManager.Connectors;

            foreach (Autodesk.Revit.DB.Connector connector in connectorSet)
            {
                ConnectorSet connectorInfo = connector.AllRefs;
                foreach (Autodesk.Revit.DB.Connector revitConnector in connectorInfo)
                {
                    var connectorId = revitConnector.Owner.Id.ToString();

                    if (connectorId == Tag) continue;
                    //if (revitConnector.Owner.Category.Name.ToLower().Equals("piping systems")) continue;

                    var connectedWith = MapFromRevitConnector(revitConnector, connector);

                    ConnectedWith.Add(connectedWith);
                }
            }
        }
        public void FillConnectedComponents(MEPModel segment)
        {
            ConnectorSet connectorSet = segment.ConnectorManager.Connectors;

            foreach (Autodesk.Revit.DB.Connector connector in connectorSet)
            {
                ConnectorSet connectorInfo = connector.AllRefs;
                foreach (Autodesk.Revit.DB.Connector revitConnector in connectorInfo)
                {
                    var connectorId = revitConnector.Owner.Id.ToString();

                    if (connectorId == Tag) continue;
                    //if (revitConnector.Owner.Category.Name.ToLower().Equals("piping systems")) continue;

                    var connectedWith = MapFromRevitConnector(revitConnector, connector);

                    ConnectedWith.Add(connectedWith);
                }
            }
        }
        protected Connectors.Connector MapFromRevitConnector(Autodesk.Revit.DB.Connector revitConnector,
            Autodesk.Revit.DB.Connector connector)
        {
            try
            {

                DirectionVector directionVector = GetDirectionVector(connector);

                if (revitConnector.ConnectorType.ToString() == "Logical")
                {

                    string connectedToId = "Not connected";
                    string shape = connector.Shape.ToString();

                    List<double> dimension = new List<double>();

                    if (shape.ToLower() == "round")
                    {
                        double diameter = 2 * ImperialToMetricConverter.ConvertFromFeetToMeters(revitConnector.Radius);
                        dimension.Add(diameter);
                    }
                    else if (shape.ToLower() == "rectangular")
                    {
                        double height = UnitUtils.ConvertFromInternalUnits(revitConnector.Height, UnitTypeId.Millimeters);
                        double width = UnitUtils.ConvertFromInternalUnits(revitConnector.Width, UnitTypeId.Millimeters);

                        dimension.Add(height);
                        dimension.Add(width);
                    }

                    double designFlow = UnitUtils.ConvertFromInternalUnits(connector.Flow, UnitTypeId.LitersPerSecond);
                    var connectorType = GetDirectionOfConnector(connector);

                    XYZ origin = connector.Origin;
                    double x = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.X);
                    double y = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Y);
                    double z = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Z);

                    Coordinate coordinate = new Coordinate(x, y, z);

                    return new Connectors.Connector(connectedToId, dimension, shape, designFlow, coordinate, directionVector, connectorType);
                }
                else
                {
                    string connectedToId = revitConnector.Owner.Id.ToString();
                    string shape = revitConnector.Shape.ToString();

                    List<double> dimension = new List<double>();

                    if (shape.ToLower() == "round")
                    {
                        double diameter = 2 * ImperialToMetricConverter.ConvertFromFeetToMeters(revitConnector.Radius);
                        dimension.Add(diameter);
                    }
                    else if (shape.ToLower() == "rectangular")
                    {
                        double height = UnitUtils.ConvertFromInternalUnits(revitConnector.Height, UnitTypeId.Millimeters);
                        double width = UnitUtils.ConvertFromInternalUnits(revitConnector.Width, UnitTypeId.Millimeters);

                        dimension.Add(height);
                        dimension.Add(width);
                    }

                    double designFlow = UnitUtils.ConvertFromInternalUnits(connector.Flow, UnitTypeId.LitersPerSecond);
                    var connectorType = GetDirectionOfConnector(connector);

                    XYZ origin = revitConnector.Origin;
                    double x = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.X);
                    double y = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Y);
                    double z = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Z);

                    Coordinate coordinate = new Coordinate(x, y, z);

                    return new Connectors.Connector(connectedToId, dimension, shape, designFlow, coordinate, directionVector, connectorType);
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }

        private Connectors.ConnectorType GetDirectionOfConnector(Autodesk.Revit.DB.Connector connector)
        {
            string direction = connector.Direction.ToString();

            if (direction == "In")
            {
                return Connectors.ConnectorType.suppliesFluidTo;
            }

            else if (direction == "Out")
            {
                return Connectors.ConnectorType.suppliesFluidFrom;
            }

            else
            {
                return Connectors.ConnectorType.exchangesFluidWith;
            } 
        }

        private DirectionVector GetDirectionVector(Autodesk.Revit.DB.Connector connector)
        {
            XYZ dirVector = connector.CoordinateSystem.BasisZ;
            double xVec = dirVector.X;
            double yVec = dirVector.Y;
            double zVec = dirVector.Z;

            return new DirectionVector(xVec, yVec, zVec);
        }

        public void FillConnectedMechEquipment(MEPModel fitting)
        {
            ConnectorSet connectorSet = fitting.ConnectorManager.Connectors;

            foreach (Autodesk.Revit.DB.Connector connector in connectorSet)
            {
                ConnectorSet connectorInfo = connector.AllRefs;
                foreach (Autodesk.Revit.DB.Connector revitConnector in connectorInfo)
                {
                    var connectorId = revitConnector.Owner.Id.ToString();

                    if (connectorId == Tag) continue;

                    var connectedWith = MapFromRevitConnector(revitConnector, connector);
                    ConnectedWith.Add(connectedWith);
                }
            }
        }

    }
}

