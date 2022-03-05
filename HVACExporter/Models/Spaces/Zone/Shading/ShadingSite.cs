using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ShadingBuilding
    {
        public string Id { get; set; }
        public string TransmSchedule { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public ShadingBuilding(string id, string transmSchedule, VertexCoordinates vertexCoordinates)
        {
            Id = id;
            TransmSchedule = transmSchedule;
            VertexCoordinates = vertexCoordinates;
        }
    }
}