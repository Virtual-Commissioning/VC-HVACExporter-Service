using System.Collections.Generic;
using HVACExporter.Models.Spaces;
using Autodesk.Revit.DB;
using System.Linq;
using System;

namespace HVACExporter.Models.Zones
{
    public class Zones
    {
        public List<HVACExporter.Models.Zone.Zone> ZonesInModel { get; set; } = new List<HVACExporter.Models.Zone.Zone>();

        public void AddZone(HVACExporter.Models.Zone.Zone space)
        {
            if (!IsZoneInList(space))
            {
                ZonesInModel.Add(space);
            }
        }

        public bool IsZoneInList(HVACExporter.Models.Zone.Zone space)
        {
            if (ZonesInModel.Contains(space))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
    }
}