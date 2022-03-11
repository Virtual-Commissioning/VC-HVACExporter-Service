using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SubSurfType
    {
        public List<Dictionary<string, SubSurfDoorAndWindow>> Doors { get; set; }
        public List<Dictionary<string, SubSurfDoorAndWindow>> Windows { get; set; }
        public List<Dictionary<string, SubSurfOpening>> Openings { get; set; }

        public SubSurfType(List<Dictionary<string, SubSurfDoorAndWindow>> subSurfDoor, List<Dictionary<string, SubSurfDoorAndWindow>> subSurfWindow, List<Dictionary<string, SubSurfOpening>> subSurfOpening)
        {
            Doors = subSurfDoor;
            Windows = subSurfWindow;
            Openings = subSurfOpening;
        }
    }
}