
namespace HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses
{
    public class Valve : FlowController
    {
        //Need to add flow parameters for each valve type
        public Valve(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {

        }
    }
}
