using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Building
{
    public class Building
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public double NorthAxis { get; set; }
        public string Terrain { get; set; }
        public double LoadConvTol { get; set; }
        public double TempConvTol { get; set; }
        public int MaxWarmupDays { get; set; }
        public int MinWarmupDays { get; set; }

        public Building(string id, string tag, double northAxis, string terrain, double loadConvTol, double tempConvTol, int maxWarmupDays, int minWarmupDays)
        {
            Id = id;
            Tag = tag;
            NorthAxis = northAxis;
            Terrain = terrain;
            LoadConvTol = loadConvTol;
            TempConvTol = tempConvTol;
            MaxWarmupDays = maxWarmupDays;
            MinWarmupDays = minWarmupDays;
        }
    }
}