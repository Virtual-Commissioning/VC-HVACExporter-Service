using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Building
    {
        public string Id { get; set; }
        public string NorthAxis { get; set; }
        public string Terrain { get; set; }
        public string LoadConvTol { get; set; }
        public string TempConvTol { get; set; }
        public string MaxWarmupDays { get; set; }
        public string MinWarmupDays { get; set; }
        public List<Dictionary<string, Zone>> Zones { get; set; }


        public Building(string id, string tag, string northAxis, string terrain, string loadConvTol, string tempConvTol, string maxWarmupDays, string minWarmupDays, List<Dictionary<string, Zone>> zones)
        {
            Id = id;
            NorthAxis = northAxis;
            Terrain = terrain;
            LoadConvTol = loadConvTol;
            TempConvTol = tempConvTol;
            MaxWarmupDays = maxWarmupDays;
            MinWarmupDays = minWarmupDays;
            Zones = zones;
        }
    }
}