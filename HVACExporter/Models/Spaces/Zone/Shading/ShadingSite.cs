using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ShadingBuilding
    {
        public string Name { get; set; }
        public string Transmittance_Schedule_Name { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public ShadingBuilding(string id, string transmSchedule, VertexCoordinates vertexCoordinates)
        {
            Name = id;
            Transmittance_Schedule_Name = transmSchedule;
            VertexCoordinates = vertexCoordinates;
        }
    }
}