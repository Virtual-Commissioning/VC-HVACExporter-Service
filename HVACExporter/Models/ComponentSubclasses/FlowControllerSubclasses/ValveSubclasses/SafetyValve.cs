namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    class SafetyValve : Valve
    {
        public double Kv { get; set; }
        public double Kvs { get; set; }
        public double NomFlow { get; set; }

        public SafetyValve(string id, string tag, string systemName, string systemType, double kv, double kvs, double nomFlow)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            NomFlow = nomFlow;
            ComponentType = this.GetType().Name;
        }
    }
}
