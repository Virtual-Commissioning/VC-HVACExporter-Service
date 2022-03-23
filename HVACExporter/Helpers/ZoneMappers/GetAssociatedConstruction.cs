using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class GetAssociatedConstruction
    {
        public static string MapAssociatedConstruction(Coordinate point, Document doc, EnergyAnalysisSurface energyAnalysisSurface)
        {
            if (point != null)
            {
                XYZ basePnt = new XYZ(point.X, point.Y, point.Z);
                bool isCW;
                BoundingBoxContainsPointFilter filter = new BoundingBoxContainsPointFilter(basePnt, false);
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                IList<Element> elements;
                if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorWall" || 
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall")
                {
                    elements = collector.OfClass(typeof(Wall)).WherePasses(filter).ToElements();
                    Wall wall = doc.GetElement(elements[0].Id) as Wall;
                    if (wall.WallType.Kind.ToString() == "Curtain")
                    {
                        isCW = true;
                    }
                    else
                    {
                        isCW = false;
                    }
                }
                else if (energyAnalysisSurface.SurfaceType.ToString() == "Roof")
                {
                    elements = collector.OfClass(typeof(RoofBase)).WherePasses(filter).ToElements();
                    isCW = false;
                }
                else if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorFloor" ||
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
                {
                    elements = collector.OfClass(typeof(Floor)).WherePasses(filter).ToElements();
                    isCW = false;
                }
                else
                {
                    elements = collector.WherePasses(filter).ToElements();
                    isCW = false;
                }

                string constructionId;
                if (elements.Count == 1)
                {
                    if (isCW == true)
                    {
                        constructionId = "CW_" + elements[0].Id.ToString();
                    }
                    else
                    {
                        constructionId = elements[0].Id.ToString();
                    }
                }
                else if (elements.Count == 0)
                {
                    constructionId = "No construction found";
                }
                else
                {
                    List<string> allElementIds = new List<string>();
                    foreach (Element element in elements)
                    {
                        allElementIds.Add(element.Category + element.Id.ToString());
                    }
                    string allIds = string.Join(", ", allElementIds);
                    constructionId = elements.Count.ToString() + " elements found. Possible Ids:" + allIds;
                }
                return constructionId;
            }
            else
            {
                string constructionId = "No Id found.";
                return constructionId;
            }
        }
    }

}
