using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Zone;
using System.Collections.Generic;

namespace HVACExporter.Helpers.ZoneMappers
{
    public class GetAssociatedOpeningConstruction
    {
        public static string MapAssociatedOpeningConstruction(Coordinate point, Document doc, EnergyAnalysisOpening energyAnalysisSubSurface)
        {
            if (point != null)
            {
                XYZ basePnt = new XYZ(point.X, point.Y, point.Z);

                BoundingBoxContainsPointFilter filter = new BoundingBoxContainsPointFilter(basePnt, false);
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                IList<Element> elements;
                if (energyAnalysisSubSurface.OpeningType.ToString() == "Window")
                {
                    elements = collector.OfCategory(BuiltInCategory.OST_Windows).WherePasses(filter).ToElements();
                }
                else if (energyAnalysisSubSurface.OpeningType.ToString() == "Door")
                {
                    elements = collector.OfCategory(BuiltInCategory.OST_Doors).WherePasses(filter).ToElements();
                }
                else if (energyAnalysisSubSurface.OpeningType.ToString() == "Air")
                {
                    elements = collector.OfCategory(BuiltInCategory.OST_SWallRectOpening).WherePasses(filter).ToElements();
                }
                else
                {
                    elements = collector.WherePasses(filter).ToElements();
                }

                string constructionId;
                if (elements.Count == 1)
                {
                    constructionId = elements[0].Id.ToString();
                }
                else if (elements.Count == 0)
                {
                    constructionId = "";
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
                string constructionId = "";
                return constructionId;
            }
        }
    }

}
