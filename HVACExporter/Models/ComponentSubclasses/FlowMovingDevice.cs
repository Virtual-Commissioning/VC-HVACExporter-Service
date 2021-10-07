using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses
{
    public class FlowMovingDevice : Component
    {
        public FlowMovingDevice(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {

        }
    }
}
