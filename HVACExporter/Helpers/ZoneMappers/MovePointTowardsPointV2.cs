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
    public class MovePointTowardsPointV2
    {
        public static Coordinate PointMover(Coordinate a, Coordinate b, double distance, XYZ faceNormal) // Move point 'a' towards point 'b' with distance 'distance'
        {
            int decimalPlaces = 4;
            int normalX = (int)faceNormal.X;
            int normalY = (int)faceNormal.Y;
            Coordinate vector, unitVector;
            double length;
            if (normalX != 0)
            {
                vector = new Coordinate(0, b.Y - a.Y, b.Z - a.Z);
                length = Math.Sqrt(vector.Y * vector.Y + vector.Z * vector.Z);
                unitVector = new Coordinate(0, vector.Y / length, vector.Z / length);
                return new Coordinate(Math.Round(a.X, decimalPlaces), Math.Round(a.Y + unitVector.Y * distance, decimalPlaces), Math.Round(a.Z + unitVector.Z * distance, decimalPlaces));
            }
            else if (normalY != 0)
            {
                vector = new Coordinate(b.X - a.X, 0, b.Z - a.Z);
                length = Math.Sqrt(vector.X * vector.X + vector.Z * vector.Z);
                unitVector = new Coordinate(vector.X / length, 0, vector.Z / length);
                return new Coordinate(Math.Round(a.X + unitVector.X * distance, decimalPlaces), Math.Round(a.Y, decimalPlaces), Math.Round(a.Z + unitVector.Z * distance, decimalPlaces));
            }
            else
            {
                vector = new Coordinate(b.X - a.X, b.Y - a.Y, 0);
                length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                unitVector = new Coordinate(vector.X / length, vector.Y / length, 0);
                return new Coordinate(Math.Round(a.X + unitVector.X * distance, decimalPlaces), Math.Round(a.Y + unitVector.Y * distance, decimalPlaces), Math.Round(a.Z, decimalPlaces));
            }

        }
    }
}
