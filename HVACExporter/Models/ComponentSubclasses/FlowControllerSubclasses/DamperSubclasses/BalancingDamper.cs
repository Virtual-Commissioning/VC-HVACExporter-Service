using System;
using System.Collections.Generic;
namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.DamperSubclasses
{
    class BalancingDamper : Damper
    {
        public double Kv { get; set; }
        public double Kvs { get; set; }

        public BalancingDamper(string id, string tag, string systemName, string systemType, double kv, double kvs)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            ComponentType = this.GetType().Name;
        }
    }
}
