using System.Collections.Generic;
using HVACExporter.Models.Spaces;

namespace HVACExporter.Models.Spaces
{
    public class Spaces
    {
        public List<Space> SpacesInModel { get; set; } = new List<Space>();

        public void AddRoom(Space room)
        {
            if (!IsRoomInList(room))
            {
                SpacesInModel.Add(room);
            }
        }

        public bool IsRoomInList(Space room)
        {
            if (SpacesInModel.Contains(room))
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