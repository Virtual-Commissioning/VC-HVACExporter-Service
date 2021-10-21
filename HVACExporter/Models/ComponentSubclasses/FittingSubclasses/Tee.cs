using System.Linq;

namespace HVACExporter.Models.ComponentSubclasses.FittingSubclasses
{
    public class Tee : Fitting
    {
        public Tee(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {
            ComponentType = this.GetType().Name;
        }

        public void RemoveRedundantUnusedConnectors(Tee tee)
        {
            if (tee.ConnectedWith.Count() > 3)
            {
                for (int i = 0; i < tee.ConnectedWith.Count(); i++)
                {
                    if (ConnectedWith.ElementAt(i).Tag.ToLower() == "not connected")
                    {
                        tee.ConnectedWith.RemoveAt(i);
                    }
                }
            }
        }
    }
}
