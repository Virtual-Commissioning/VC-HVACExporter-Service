using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class LightingMapper
    {
        public static Lighting MapLighting(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "NA";
            string zoneName = associatedSpace.Id.ToString();
            string lightingSchedule = "NA";
            string calculationMethod = "NA";
            double lightingLevel = 1;
            double wattM2 = 0;
            double returnAirFraction = 0;
            double fractionRadiant = 0;
            double fractionVisible = 0;
            double fractionReplaceable = 0;
            string endUseSubCategory = "NA";

            Lighting lightingGains = new Lighting(id, zoneName, lightingSchedule, calculationMethod,
                lightingLevel, wattM2, returnAirFraction, fractionRadiant,
                fractionVisible, fractionReplaceable, endUseSubCategory);
            return lightingGains;
        }
    }
}
