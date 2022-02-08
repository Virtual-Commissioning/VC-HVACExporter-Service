using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.VertexCoordinates
{
    public class VertexCoordinates // This class need some work, maybe make a loop that defines points based on amount of vertices counted.
    {
        public Coordinate P1 { get; set; }
        public Coordinate P2 { get; set; }
        public Coordinate P3 { get; set; }
        public Coordinate P4 { get; set; }

        /* Loop idea
        i = 0;
        while i <= count.Vertices
            {
                public CoordinatesOfP P+"i"
                i++
            }
        bla
        */

        public VertexCoordinates(Coordinate p1, Coordinate p2, Coordinate p3, Coordinate p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

    }
}
