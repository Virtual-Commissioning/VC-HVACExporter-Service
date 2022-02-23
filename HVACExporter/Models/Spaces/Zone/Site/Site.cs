using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Site
    {
        public string SiteId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; }
        public double Elevation { get; set; }

        public Site(string siteId, double latitude, double longitude, string timeZone, double elevation)
        {
            SiteId = siteId;
            Latitude = latitude;
            Longitude = longitude;
            TimeZone = timeZone;
            Elevation = elevation;
        }
    }
}