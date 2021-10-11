using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HVACExporter.Helpers;
using HVACExporter.Models.Enums;
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
        [JsonConverter(typeof(StringEnumConverter))]
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

        public void FillConnectedSegments(MEPCurve segment)
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
                    double diameter = 2 * ImperialToMetricConverter.ConvertFromFeetToMeters(connector.Radius);
                    string shape = connector.Shape.ToString();
                    double designFlow = connector.Flow;
                    var connectorType = GetDirectionOfConnector(connector);

                    XYZ origin = connector.Origin;
                    double x = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.X);
                    double y = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Y);
                    double z = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Z);

                    Coordinate coordinate = new Coordinate(x, y, z);

                    return new Connectors.Connector(connectedToId, diameter, shape, designFlow, coordinate, directionVector, connectorType);
                }
                else
                {
                    string connectedToId = revitConnector.Owner.Id.ToString();
                    double diameter = 2 * ImperialToMetricConverter.ConvertFromFeetToMeters(revitConnector.Radius);
                    string shape = revitConnector.Shape.ToString();
                    double designFlow = connector.Flow;
                    var connectorType = GetDirectionOfConnector(connector);

                    XYZ origin = revitConnector.Origin;
                    double x = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.X);
                    double y = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Y);
                    double z = ImperialToMetricConverter.ConvertFromFeetToMeters(origin.Z);

                    Coordinate coordinate = new Coordinate(x, y, z);

                    return new Connectors.Connector(connectedToId, diameter, shape, designFlow, coordinate, directionVector, connectorType);
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

        public Space GetSpaceAndComponentsInSpace(FamilyInstance component)
        {

            BoundingBoxXYZ boundingBox = component.Space.Room.ClosedShell.GetBoundingBox();

            XYZ bbMinCoordinates = boundingBox.Min;
            XYZ bbMaxCoordinates = boundingBox.Max;

            Coordinate minCoordinates = new Coordinate(
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMinCoordinates.X),
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMinCoordinates.Y),
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMinCoordinates.Z));

            Coordinate maxCoordinates = new Coordinate(
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMaxCoordinates.X),
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMaxCoordinates.Y),
                ImperialToMetricConverter.ConvertFromFeetToMeters(bbMaxCoordinates.Z));

            SpaceBoundingBox spaceBoundingBox = new SpaceBoundingBox(minCoordinates, maxCoordinates);

            string id = component.Space.UniqueId.ToString();
            string tag = component.Space.Id.ToString();
            double heatingDemand = component.Space.LookupParameter("Design Heating Load").AsDouble();

            Space space = new Space(id, tag, heatingDemand, spaceBoundingBox);

            return space;
        }
    }
}

