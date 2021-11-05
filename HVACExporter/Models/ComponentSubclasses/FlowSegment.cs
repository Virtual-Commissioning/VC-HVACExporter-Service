namespace HVACExporter.Models.ComponentSubclasses
{
    public class FlowSegment : Component
    {

        public FlowSegment(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }

        public void AddNullConnector(FlowSegment component)
        {
            if (component.ConnectedWith.Count < 2)
            {
                component.ConnectedWith.Add(null);
            }
        }
    }
}
