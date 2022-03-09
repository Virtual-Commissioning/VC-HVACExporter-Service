using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Site
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
        public string Elevation { get; set; }
        public List<Dictionary<string, Building>> Buildings { get; set; }
        public List<ShadingSite> ShadingSite { get; set; }

        public Site(string name, string latitude, string longitude, string timeZone, string elevation, List<Dictionary<string, Building>> buildings, List<ShadingSite> shadingSite)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            TimeZone = timeZone;
            Elevation = elevation;
            Buildings = buildings;
            ShadingSite = shadingSite;
        }
    }
}