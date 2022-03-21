using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Building
    {
        public string Name { get; set; }
        public string North_Axis { get; set; }
        public string Terrain { get; set; }
        public string Loads_Convergence_Tolerance_Value { get; set; }
        public string Temperature_Convergence_Tolerance_Value { get; set; }
        public string Solar_Distribution { get; set; }
        public string Maximum_Number_of_Warmup_Days { get; set; }
        public string Minimum_Number_of_Warmup_Days { get; set; }
        public List<Dictionary<string, Zone>> Zones { get; set; }
        public List<Dictionary<string, ShadingBuilding>> BuildingShadings { get; set; }


        public Building(string name, string northAxis, string terrain, 
            string loadConvTol, string tempConvTol, string solarDistribution, 
            string maxWarmupDays, string minWarmupDays, List<Dictionary<string, Zone>> zones,
            List<Dictionary<string, ShadingBuilding>> buildingShadings)
        {
            Name = name;
            North_Axis = northAxis;
            Terrain = terrain;
            Loads_Convergence_Tolerance_Value = loadConvTol;
            Temperature_Convergence_Tolerance_Value = tempConvTol;
            Solar_Distribution = solarDistribution;
            Maximum_Number_of_Warmup_Days = maxWarmupDays;
            Minimum_Number_of_Warmup_Days = minWarmupDays;
            Zones = zones;
            BuildingShadings = buildingShadings;
        }
    }
}