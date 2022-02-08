using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.OutsideBC
{
    public class OutsideBC // This class is needed to determine what type of surface it is
    {
        public bool IntWallBetweenZones { get; set; } // Interior wall between zones
        public bool IntWallInZone { get; set; } // Interior wall in the same zone
        public bool IntFloor { get; set; } // Floor between levels
        public bool ExtFloor { get; set; } // Floor towards ground
        public bool Roof { get; set; } // Roof in revit is always exterior
        public bool ExtWall { get; set; } // Exterior wall


        public OutsideBC(bool intWallBetweenZones, bool intWallInZone, bool intFloor, bool extFloor, bool roof, bool extWall)
        {
            IntWallBetweenZones = intWallBetweenZones;
            IntWallInZone = intWallInZone;
            IntFloor = intFloor;
            ExtFloor = extFloor;
            Roof = roof;
            ExtWall = extWall;
        }

    }
}
