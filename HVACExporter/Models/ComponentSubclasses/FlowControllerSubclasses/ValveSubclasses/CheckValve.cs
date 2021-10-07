namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    public class CheckValve : Valve
    {
        public double Kv { get; set; }
        public double Kvs { get; set; }
        public double NomFlow { get; set; }

        public CheckValve(string id, string tag, string systemName, string systemType, double kv, double kvs, double nomFlow)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            NomFlow = nomFlow;
            ComponentType = this.GetType().Name;
        }
    }
}
