using System.Collections.Generic;
using HVACExporter.Models.Spaces;
using Autodesk.Revit.DB.Architecture;
using System.Linq;
using System;

namespace HVACExporter.Models.Spaces
{
    public class Zones
    {
        public List<Room> ZonesInModel { get; set; } = new List<Room>();

        public void AddRoom(Room room)
        {
            if (!IsRoomInList(room))
            {
                ZonesInModel.Add(room);
            }
        }

        public bool IsRoomInList(Room room)
        {
            if (ZonesInModel.Contains(room))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        internal void AddRoom(Zone.Zone zoneToAdd)
        {
            throw new NotImplementedException();
        }
        */
    }
}