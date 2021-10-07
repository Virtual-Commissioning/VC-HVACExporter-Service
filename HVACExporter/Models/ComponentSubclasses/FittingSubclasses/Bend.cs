namespace HVACExporter.Models.ComponentSubclasses.FittingSubclasses
{
    public class Bend : Fitting
    {
        public double Angle { get; set; }

        public Bend(string id, string tag, string systemName, string systemType,
            double angle)
            : base(id, tag, systemName, systemType)
        {
            Angle = angle;
            ComponentType = this.GetType().Name;
        }
    }
}
