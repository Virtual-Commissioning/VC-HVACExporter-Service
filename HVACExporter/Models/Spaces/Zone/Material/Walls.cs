using System.Collections.Generic;
using HVACExporter.Models.Spaces;

namespace HVACExporter.Models.Zone
{
    public class Walls
    {
        public List<Walls> WallsInModel { get; set; } = new List<Walls>();

        public void AddWall(Walls wall)
        {
            if (!IsWallInList(wall))
            {
                WallsInModel.Add(wall);
            }
        }

        public bool IsWallInList(Walls wall)
        {
            if (WallsInModel.Contains(wall))
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