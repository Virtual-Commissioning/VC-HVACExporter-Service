namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    public class BalancingValve : Valve
    {
        public double? Kv { get; set; }
        public double? Kvs { get; set; }

        public BalancingValve(string id, string tag, string systemName, string systemType, 
                              double? kv, double? kvs)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            ComponentType = this.GetType().Name;
        }
    }
}