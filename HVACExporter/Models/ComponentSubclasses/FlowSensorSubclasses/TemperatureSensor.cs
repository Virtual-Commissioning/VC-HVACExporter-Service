﻿namespace HVACExporter.Models.ComponentSubclasses.FlowSensorSubclasses
{
    class TemperatureSensor : Sensor
    {
        public TemperatureSensor(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }
    }
}
