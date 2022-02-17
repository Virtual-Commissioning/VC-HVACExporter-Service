using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class ShadingSite
    {
        public string Id { get; set; }
        public string TransmSchedule { get; set; }
        public int NoVertices { get; set; }
        public VertexCoordinates VertexCoordinates { get; set; }

        public ShadingSite(string id, string transmSchedule, int noVertices, VertexCoordinates vertexCoordinates)
        {
            Id = id;
            TransmSchedule = transmSchedule;
            NoVertices = noVertices;
            VertexCoordinates = vertexCoordinates;
        }
    }
}