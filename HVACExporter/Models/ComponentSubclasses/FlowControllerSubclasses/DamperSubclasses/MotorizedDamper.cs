using HVACExporter.Models.Controls;

namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.DamperSubclasses
{
    class MotorizedDamper : Damper
    {
        public double? Kv { get; set; }
        public double? Kvs { get; set; }
        public Controller Control { get; set; }

        public MotorizedDamper(string id, string tag, string systemName, string systemType, double? kv, double? kvs, Controller control)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            Control = control;
            ComponentType = this.GetType().Name;
        }
    }
}
