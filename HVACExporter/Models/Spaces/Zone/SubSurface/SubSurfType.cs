using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class SubSurfType
    {
        public List<SubSurfDoorAndWindow> SubSurfDoor { get; set; }
        public List<SubSurfDoorAndWindow> SubSurfWindow { get; set; }
        public List<SubSurfOpening> SubSurfOpening { get; set; }

        public SubSurfType(List<SubSurfDoorAndWindow> subSurfDoor, List<SubSurfDoorAndWindow> subSurfWindow, List<SubSurfOpening> subSurfOpening)
        {
            SubSurfDoor = subSurfDoor;
            SubSurfWindow = subSurfWindow;
            SubSurfOpening = subSurfOpening;
        }
    }
}