namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    public class ShuntValve : Valve
    {
        public double ShuntDiameter { get; set; }
        public double HasCheckValve { get; set; }

        public ShuntValve(string id, string tag, string systemName, string systemType,
                              double shuntDiameter, double hasCheckValve)
            : base(id, tag, systemName, systemType)
        {
            ShuntDiameter = shuntDiameter;
            HasCheckValve = hasCheckValve;
            ComponentType = this.GetType().Name;
        }
    }
}