using Autodesk.Revit.DB;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces.Geometry;
using System.Collections.Generic;

namespace HVACExporter.Helpers.SpaceMappers
{
    public class GeometricMapper
    {
        public static SpaceGeometry MapGeometry(SpatialElement space)
        {
            //Get the spaceBoundingBox
            //Get the boundingBox height
            var spaceBottomElevation = ImperialToMetricConverter.ConvertFromFeetToMeters(space.Level.Elevation);
            var spaceHeight = ImperialToMetricConverter.ConvertFromFeetToMeters(
                ((Autodesk.Revit.DB.Mechanical.Space)space).UnboundedHeight);

            //Instantiating classes
            var footprint = new List<Models.Spaces.Geometry.Edge>();

            IList<IList<Autodesk.Revit.DB.BoundarySegment>> segments = space.GetBoundarySegments(new SpatialElementBoundaryOptions());

            foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in segments)
            {
                foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                {
                    Curve curve = boundarySegment.GetCurve();
                    Coordinate point1 = new Coordinate(
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).X),
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).Y),
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(0).Z));
                    Coordinate point2 = new Coordinate(
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).X),
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).Y),
                        ImperialToMetricConverter.ConvertFromFeetToMeters(curve.GetEndPoint(1).Z));

                    Models.Spaces.Geometry.Edge edge = new Models.Spaces.Geometry.Edge(point1, point2);
                    footprint.Add(edge);
                }
            }

            return new SpaceGeometry(spaceBottomElevation, spaceHeight, footprint);
        }
    }
        
}
