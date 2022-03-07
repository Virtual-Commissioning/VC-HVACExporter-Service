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

                BoundingBoxContainsPointFilter filter = new BoundingBoxContainsPointFilter(basePnt, false);
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                IList<Element> elements;
                if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorWall" || 
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorWall")
                {
                    elements = collector.OfClass(typeof(Wall)).WherePasses(filter).ToElements();
                }
                else if (energyAnalysisSurface.SurfaceType.ToString() == "Roof")
                {
                    elements = collector.OfClass(typeof(RoofBase)).WherePasses(filter).ToElements();
                }
                else if (energyAnalysisSurface.SurfaceType.ToString() == "ExteriorFloor" ||
                    energyAnalysisSurface.SurfaceType.ToString() == "InteriorFloor")
                {
                    elements = collector.OfClass(typeof(Floor)).WherePasses(filter).ToElements();
                }
                else
                {
                    elements = collector.WherePasses(filter).ToElements();
                }

                string constructionId;
                if (elements.Count == 1)
                {
                    constructionId = elements[0].UniqueId.ToString();
                }
                else if (elements.Count == 0)
                {
                    constructionId = "No elements found";
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
