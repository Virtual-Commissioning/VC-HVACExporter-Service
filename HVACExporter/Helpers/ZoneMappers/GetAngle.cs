﻿using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class GetAngle //Finds angle between three points
    {
        public static double AngleFinder(Coordinate p1, Coordinate p2, Coordinate centerPoint, XYZ faceNormal)
        {
            Coordinate a = new Coordinate(centerPoint.X - p1.X, centerPoint.Y - p1.Y, centerPoint.Z - p1.Z);
            Coordinate b = new Coordinate(centerPoint.X - p2.X, centerPoint.Y - p2.Y, centerPoint.Z - p2.Z);
            /*double angle = Math.Acos((a.X * b.X + a.Y * b.Y + a.Z * b.Z)/
                (Math.Sqrt(Math.Pow(a.X,2) + Math.Pow(a.Y, 2) + Math.Pow(a.Z, 2)) * 
                Math.Sqrt(Math.Pow(b.X,2) + Math.Pow(b.Y, 2) + Math.Pow(b.Z, 2)))) *180/Math.PI;*/
            double dot, det;
            if (faceNormal.X == 1 || faceNormal.X == -1) // (Y, Z)
            {
                dot = a.Y * a.Z + b.Y * b.Z;
                det = a.Y * b.Z - b.Y * a.Z;
            }
            else if (faceNormal.Y == 1 || faceNormal.Y == -1) // (X, Z)
            {
                dot = a.X * a.Z + b.X * b.Z;
                det = a.X * b.Z - b.X * a.Z;
            }
            else // (X, Y)
            {
                dot = a.X * a.Y + b.X * b.Y;
                det = a.X * b.Y - b.X * a.Y;
            }
            double angle = Math.Atan2(det, dot) * 180 / Math.PI;
            return angle; //Returns an angle between 0 and 360
        }
    }
}