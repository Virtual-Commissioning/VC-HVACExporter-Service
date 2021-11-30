namespace HVACExporter.Models.ComponentSubclasses.FlowSensorSubclasses
{
    class PressureSensor : Sensor
    {
        public PressureSensor(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }
    }
}
