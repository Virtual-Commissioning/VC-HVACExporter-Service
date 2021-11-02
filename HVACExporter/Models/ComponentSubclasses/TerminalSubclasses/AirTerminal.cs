namespace HVACExporter.Models.ComponentSubclasses.TerminalSubclasses
{
    public class AirTerminal : FlowTerminal
    {
        public double Kv { get; set; }
        public AirTerminal(string id, string tag, string systemName, string systemType, double kv)
           : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            ComponentType = this.GetType().Name;
        }
    }
}
