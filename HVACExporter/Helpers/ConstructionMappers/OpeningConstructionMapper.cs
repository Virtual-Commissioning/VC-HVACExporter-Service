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
        public static List<OpeningConstruction> MapAllOpeningConstructions(FilteredElementCollector allOpenings)
        {
            List<OpeningConstruction> allOpeningConstructions = new List<OpeningConstruction>();

            foreach (Opening opening in allOpenings)
            {
                string openingConstructionId = opening.UniqueId.ToString();
                string analyticalOpeningConstructionId = opening.GetAnalyticalModelId().ToString();
                string airExchangeMethod = "0";
                string airMixingChangesPerHour = "0";
                string simpleMixingPerHour = "0";

                OpeningConstructionParameters openingConstructionParameters 
                    = new OpeningConstructionParameters(airExchangeMethod, airMixingChangesPerHour, simpleMixingPerHour);

                OpeningConstruction openingConstructionToAdd = new OpeningConstruction(openingConstructionId, analyticalOpeningConstructionId, openingConstructionParameters);
                allOpeningConstructions.Add(openingConstructionToAdd);
            }

            return allOpeningConstructions;
         }

    }
}
