using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class OpeningConstruction
    {
        public string OpeningConstructionId { get; set; }
        public string AnalyticalOpeningConstructionId { get; set; }
        public OpeningConstructionParameters OpeningConstructionParameters { get; set; }
        public OpeningConstruction(string openingConstructionId, string analyticalOpeningConstructionId, OpeningConstructionParameters openingConstructionParameters)
        {
            OpeningConstructionId = openingConstructionId;
            AnalyticalOpeningConstructionId = analyticalOpeningConstructionId;
            OpeningConstructionParameters = openingConstructionParameters;
        }
    }
}