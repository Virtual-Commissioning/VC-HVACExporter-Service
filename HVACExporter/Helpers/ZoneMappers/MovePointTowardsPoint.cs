using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class MovePointTowardsPoint
    {
        public static Coordinate PointMover(Coordinate a, Coordinate b, double distance, XYZ faceNormal) // Move point 'a' towards point 'b' with distance 'distance'
        {
            int normalX = (int)faceNormal.X;
            int normalY = (int)faceNormal.Y;
            var vector = new Coordinate(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
            var unitVector = new Coordinate(vector.X / length, vector.Y / length, vector.Z / length);

            if (normalX != 0)
            {
                return new Coordinate(Math.Round(a.X, 4), Math.Round(a.Y + unitVector.Y * distance, 4), Math.Round(a.Z + unitVector.Z * distance, 4));
            }
            else if(normalY != 0)
            {
                return new Coordinate(Math.Round(a.X + unitVector.X * distance, 4), Math.Round(a.Y, 4), Math.Round(a.Z + unitVector.Z * distance, 4));
            }
            else
            {
                return new Coordinate(Math.Round(a.X + unitVector.X * distance, 4), Math.Round(a.Y + unitVector.Y * distance, 4), Math.Round(a.Z, 4));
            }
            
        }
    }

}
