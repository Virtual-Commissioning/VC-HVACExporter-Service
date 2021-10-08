namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.DamperSubclasses
{
    class FireDamper : Damper
    {
        public double Kv { get; set; }
        public double Kvs { get; set; }
        public string FireDamperType { get; set; }

        public FireDamper(string id, string tag, string systemName, string systemType, 
                          double kv, double kvs, string fireDamperType)
            : base(id, tag, systemName, systemType)
        {
            Kv = kv;
            Kvs = kvs;
            FireDamperType = fireDamperType;
            ComponentType = this.GetType().Name;
        }
    }
}
