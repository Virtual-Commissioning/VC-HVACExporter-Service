using HVACExporter.Models.GeometricTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ShadingSite
    {
        public string Name { get; set; }
        public string Transmittance_Schedule_Name { get; set; }
        public List<Coordinate> VertexCoordinates { get; set; }

        public ShadingSite(string name, string transmSchedule, List<Coordinate> vertexCoordinates)
        {
            Name = name;
            Transmittance_Schedule_Name = transmSchedule;
            VertexCoordinates = vertexCoordinates;
        }
    }
}