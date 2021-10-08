using System.Collections.Generic;

namespace HVACExporter.Models.Spaces
{
    public class SpacesInModel
    {
        public List<Space> Spaces { get; set; } = new List<Space>();

        public void AddSpace(Space space)
        {
            if (!IsSpaceInList(space))
            {
                Spaces.Add(space);
            }
        }

        public bool IsSpaceInList(Space space)
        {
            if (Spaces.Contains(space))
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
