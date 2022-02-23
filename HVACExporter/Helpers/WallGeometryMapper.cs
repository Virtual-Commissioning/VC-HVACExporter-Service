using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Zone;
using System.Collections.Generic;
using Surface = HVACExporter.Models.Zone.Surface;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class WallGeometryMapper
    {
        public static VertexCoordinates MapWallGeometry(BoundarySegment boundarySegment)
        {
            //Get the spaceBoundingBox
            //Get the boundingBox height
            //var spaceBottomElevation = ImperialToMetricConverter.ConvertFromFeetToMeters(room.Level.Elevation);
            //var spaceHeight = ImperialToMetricConverter.ConvertFromFeetToMeters(room.UnboundedHeight);

            //Instantiating classes
            var footprint = new List<Models.Spaces.Geometry.Edge>();

            
                Curve curve = boundarySegment.GetCurve();
                Models.GeometricTypes.Coordinate point1 = new Models.GeometricTypes.Coordinate(
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).X),
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).Y),
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).Z));
                Models.GeometricTypes.Coordinate point2 = new Models.GeometricTypes.Coordinate(
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).X),
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).Y),
                    ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).Z));

                Models.Spaces.Geometry.Edge edge = new Models.Spaces.Geometry.Edge(point1, point2);
                footprint.Add(edge);


            return new VertexCoordinates(footprint);
        }
    }

}
