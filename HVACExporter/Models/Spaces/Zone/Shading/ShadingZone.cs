using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ShadingZone
    {
        public string Id { get; set; }
        public string BaseSurfId { get; set; }
        public string TransmSchedule { get; set; }
        public int NoVertices { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public ShadingZone(string id, string baseSurfId, string transmSchedule, int noVertices, VertexCoordinates vertexCoordinates)
        {
            Id = id;
            BaseSurfId = baseSurfId;
            TransmSchedule = transmSchedule;
            NoVertices = noVertices;
            VertexCoordinates = vertexCoordinates;
        }
    }
}