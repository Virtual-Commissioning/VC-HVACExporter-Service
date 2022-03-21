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
    public class SortPointsV2 //Finds angle between three points
    {
        public static List<Coordinate> PointSorter(List<Coordinate> vertices, XYZ faceNormal)
        {
            Coordinate centerPoint = new Coordinate(vertices.Average(p => p.X), vertices.Average(p => p.Y), vertices.Average(p => p.Z));
            List<Coordinate> sortedCoordinates = new List<Coordinate>();
            List<Coordinate> q1_1 = new List<Coordinate>(); // Dependent on the location of the point in the top left corner
            List<Coordinate> q1_2 = new List<Coordinate>(); // Dependent on the location of the point in the top left corner
            List<Coordinate> q2 = new List<Coordinate>();
            List<Coordinate> q3 = new List<Coordinate>();
            List<Coordinate> q4 = new List<Coordinate>();
            List<Coordinate> quadrantsAdded = new List<Coordinate>();
            int normalX = (int)Math.Round(faceNormal.X);
            int normalY = (int)Math.Round(faceNormal.Y);
            int normalZ = (int)Math.Round(faceNormal.Z);
            if (normalX == 1 || normalX == -1)
            {
                vertices = vertices.OrderBy(p => p.Y).ThenByDescending(p => p.Z).ToList();
                sortedCoordinates.Add(vertices[0]);
                vertices.Remove(vertices[0]);
                foreach (Coordinate c in vertices)
                {
                    if (c.Z > centerPoint.Z && c.Y <= centerPoint.Y)
                    {
                        if (c.Z < sortedCoordinates[0].Z && c.Y <= sortedCoordinates[0].Y)
                        {
                            q1_1.Add(c);
                            q1_1 = q1_1.OrderByDescending(p => p.Z).ThenBy(p => p.Y).ToList();
                        }
                        else
                        {
                            q1_2.Add(c);
                            q1_2 = q1_2.OrderByDescending(p => p.Y).ThenByDescending(p => p.Z).ToList();
                        }
                    }
                    else if (c.Z <= centerPoint.Z && c.Y < centerPoint.Y)
                    {
                        q2.Add(c);
                        q2 = q2.OrderByDescending(p => p.Z).ThenBy(p => p.Y).ToList();
                    }
                    else if (c.Z < centerPoint.Z && c.Y >= centerPoint.Y)
                    {
                        q3.Add(c);
                        q3 = q3.OrderBy(p => p.Y).ThenBy(p => p.Z).ToList();
                    }
                    else
                    {
                        q4.Add(c);
                        q4 = q4.OrderBy(p => p.Z).ThenByDescending(p => p.Y).ToList();
                    }
                }
                quadrantsAdded.AddRange(q1_1);
                quadrantsAdded.AddRange(q2);
                quadrantsAdded.AddRange(q3);
                quadrantsAdded.AddRange(q4);
                quadrantsAdded.AddRange(q1_2);
                if (normalX == -1)
                {
                    quadrantsAdded.Reverse();
                }
                sortedCoordinates.AddRange(quadrantsAdded);
            }
            else if (normalY == 1 || normalY == -1)
            {
                vertices = vertices.OrderBy(p => p.X).ThenByDescending(p => p.Z).ToList();
                sortedCoordinates.Add(vertices[0]);
                vertices.Remove(vertices[0]);
                foreach (Coordinate c in vertices)
                {
                    if (c.Z > centerPoint.Z && c.X <= centerPoint.X)
                    {
                        if (c.Z < sortedCoordinates[0].Z && c.X <= sortedCoordinates[0].X)
                        {
                            q1_1.Add(c);
                            q1_1 = q1_1.OrderByDescending(p => p.Z).ThenBy(p => p.X).ToList();
                        }
                        else
                        {
                            q1_2.Add(c);
                            q1_2 = q1_2.OrderByDescending(p => p.X).ThenByDescending(p => p.Z).ToList();
                        }
                    }
                    else if (c.Z <= centerPoint.Z && c.X < centerPoint.X)
                    {
                        q2.Add(c);
                        q2 = q2.OrderByDescending(p => p.Z).ThenBy(p => p.X).ToList();
                    }
                    else if (c.Z < centerPoint.Z && c.X >= centerPoint.X)
                    {
                        q3.Add(c);
                        q3 = q3.OrderBy(p => p.X).ThenBy(p => p.Z).ToList();
                    }
                    else
                    {
                        q4.Add(c);
                        q4 = q4.OrderBy(p => p.Z).ThenByDescending(p => p.X).ToList();
                    }
                }
                quadrantsAdded.AddRange(q1_1);
                quadrantsAdded.AddRange(q2);
                quadrantsAdded.AddRange(q3);
                quadrantsAdded.AddRange(q4);
                quadrantsAdded.AddRange(q1_2);
                if (normalY == -1)
                {
                    quadrantsAdded.Reverse();
                }
                sortedCoordinates.AddRange(quadrantsAdded);
            }
            else
            {
                vertices = vertices.OrderBy(p => p.X).ThenByDescending(p => p.Y).ToList();
                sortedCoordinates.Add(vertices[0]);
                vertices.Remove(vertices[0]);
                foreach (Coordinate c in vertices)
                {
                    if (c.Y > centerPoint.Y && c.X <= centerPoint.X)
                    {
                        if (c.Y < sortedCoordinates[0].Y && c.X <= sortedCoordinates[0].X)
                        {
                            q1_1.Add(c);
                            q1_1 = q1_1.OrderByDescending(p => p.Y).ThenBy(p => p.X).ToList();
                        }
                        else
                        {
                            q1_2.Add(c);
                            q1_2 = q1_2.OrderByDescending(p => p.X).ThenByDescending(p => p.Y).ToList();
                        }
                    }
                    else if (c.Y <= centerPoint.Y && c.X < centerPoint.X)
                    {
                        q2.Add(c);
                        q2 = q2.OrderByDescending(p => p.Y).ThenBy(p => p.X).ToList();
                    }
                    else if (c.Y < centerPoint.Y && c.X >= centerPoint.X)
                    {
                        q3.Add(c);
                        q3 = q3.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
                    }
                    else
                    {
                        q4.Add(c);
                        q4 = q4.OrderBy(p => p.Y).ThenByDescending(p => p.X).ToList();
                    }
                }
                quadrantsAdded.AddRange(q1_1);
                quadrantsAdded.AddRange(q2);
                quadrantsAdded.AddRange(q3);
                quadrantsAdded.AddRange(q4);
                quadrantsAdded.AddRange(q1_2);
                if (normalZ == -1)
                {
                    quadrantsAdded.Reverse();
                }
                sortedCoordinates.AddRange(quadrantsAdded);
            }

            return sortedCoordinates;
        }
    }

}
