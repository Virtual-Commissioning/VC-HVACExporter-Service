namespace HVACExporter.Models.ComponentSubclasses.FittingSubclasses
{
    public class Reduction : Fitting
    {
        public Reduction(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }
    }
}
