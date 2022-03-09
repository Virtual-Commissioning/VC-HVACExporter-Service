using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace HVACExporter.Helpers
{
    public class OpeningConstructionMapper
    {
        public static List<Dictionary<string, OpeningConstruction>> MapAllOpeningConstructions(FilteredElementCollector allOpenings)
        {
            List<Dictionary<string, OpeningConstruction>> allOpeningConstructions = new List<Dictionary<string, OpeningConstruction>>();

            foreach (Opening opening in allOpenings)
            {
                string openingConstructionId = opening.Id.ToString();
                string airExchangeMethod = "";
                string airMixingChangesPerHour = "";
                string simpleMixingPerHour = "";
                OpeningConstruction openingConstructionToAdd = new OpeningConstruction(openingConstructionId, airExchangeMethod, airMixingChangesPerHour, simpleMixingPerHour);
                Dictionary<string, OpeningConstruction> linkedOpeningConstruction = new Dictionary<string, OpeningConstruction>();
                linkedOpeningConstruction.Add(openingConstructionId, openingConstructionToAdd);
                allOpeningConstructions.Add(linkedOpeningConstruction);
            }

            return allOpeningConstructions;
         }

    }
}
