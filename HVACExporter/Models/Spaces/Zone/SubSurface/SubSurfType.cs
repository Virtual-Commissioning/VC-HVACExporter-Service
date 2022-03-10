using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SubSurfType
    {
        public List<Dictionary<string, SubSurfDoorAndWindow>> SubSurfDoor { get; set; }
        public List<Dictionary<string, SubSurfDoorAndWindow>> SubSurfWindow { get; set; }
        public List<Dictionary<string, SubSurfOpening>> SubSurfOpening { get; set; }

        public SubSurfType(List<Dictionary<string, SubSurfDoorAndWindow>> subSurfDoor, List<Dictionary<string, SubSurfDoorAndWindow>> subSurfWindow, List<Dictionary<string, SubSurfOpening>> subSurfOpening)
        {
            SubSurfDoor = subSurfDoor;
            SubSurfWindow = subSurfWindow;
            SubSurfOpening = subSurfOpening;
        }
    }
}