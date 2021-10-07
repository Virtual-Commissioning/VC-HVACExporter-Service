using System.Collections.Generic;
using HVACExporter.Models.Controls;

namespace HVACExporter.Models.ComponentSubclasses.FlowMovingDeviceSubclasses
{
    public class Fan : FlowMovingDevice
    {
        public Dictionary<double, double> PressureCurve { get; set; } = new Dictionary<double, double>();
        public Dictionary<double, double> PowerCurve { get; set; } = new Dictionary<double, double>();
        public Controller Control { get; set; }

        public Fan(string id, string tag, string systemName, string systemType, Controller control)
            : base(id, tag, systemName, systemType)
        {
            Control = control;
            ComponentType = this.GetType().Name;
        }
    }
}
