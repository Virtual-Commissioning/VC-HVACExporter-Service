namespace HVACExporter.Models.ComponentSubclasses.FittingSubclasses
{
    class Cross : Fitting
    {
        public Cross(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }
    }
}
