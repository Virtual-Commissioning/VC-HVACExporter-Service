using HVACExporter.Models.Controls;

namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses
{
    class MotorizedValve : Valve
    {
        public double Kv { get; set; }
        public double Kvs { get; set; }
        public Controller Control { get; set; }

        public MotorizedValve(string id, string tag, string systemName, string systemType,
                              double kv, double kvs, Controller control)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            Control = control;
            ComponentType = this.GetType().Name;
        }
    }
}
