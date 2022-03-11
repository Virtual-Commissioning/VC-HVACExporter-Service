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
        public static List<Lighting> MapLighting(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            List<Lighting> lighting = new List<Lighting>();
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "Lighting";
            string zoneId = associatedSpace.Id.ToString();
            string lightingSchedule = "";
            string calculationMethod = "";
            double lightingLevel = 0;
            double returnAirFraction = 0;
            double fractionRadiant = 0;
            double fractionVisible = 0;
            double fractionReplaceable = 0;
            string endUseSubCategory = "";

            Lighting lightingGains = new Lighting(id, zoneId, lightingSchedule, calculationMethod,
                lightingLevel, returnAirFraction, fractionRadiant,
                fractionVisible, fractionReplaceable, endUseSubCategory);
            lighting.Add(lightingGains);
            return lighting;
        }
    }
}
