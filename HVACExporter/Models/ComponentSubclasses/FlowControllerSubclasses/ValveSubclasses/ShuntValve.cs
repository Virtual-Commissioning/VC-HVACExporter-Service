namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    public class ShuntValve : Valve
    {
        public double ShuntDiameter { get; set; }
        public bool HasCheckValve { get; set; }

        public ShuntValve(string id, string tag, string systemName, string systemType,
                              double shuntDiameter, bool hasCheckValve)
            : base(id, tag, systemName, systemType)
        {
            ShuntDiameter = shuntDiameter;
            HasCheckValve = hasCheckValve;
            ComponentType = this.GetType().Name;
        }
    }
}