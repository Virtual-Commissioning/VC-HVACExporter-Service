using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Controls.PumpControllerSubclasses
{
    class ExternalControl : PumpController
    {
        public string ControlType { get; set; }
        public Controller Control { get; set; }
        public ExternalControl(Controller controller)
            : base()
        {
            ControlType = this.GetType().Name;
            Control = controller;
        }
    }
}
