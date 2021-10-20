using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Controls.PumpControllerSubclasses
{
    class ExternalControl
    {
        public Controller Control { get; set; }
        public ExternalControl(Controller controller)
        {
            Control = controller;
        }
    }
}
