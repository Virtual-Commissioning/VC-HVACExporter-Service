using HVACExporter.Models.Enums;

namespace HVACExporter.Models.ComponentSubclasses
{
    public class Segment : Component
    {

        public Segment(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {

        }

        public void AddNullConnector(Segment component)
        {
            if (component.ConnectedWith.Count < 2)
            {
                component.ConnectedWith.Add(null);
            }
        }
    }
}
