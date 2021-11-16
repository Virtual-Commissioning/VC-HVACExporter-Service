using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Controls.PumpControllerSubclasses
{
    class ConstantPressureControl : PumpController
    {
        public string ControlType { get; set; }
        public double Pressure { get; set; }
        public ConstantPressureControl(double pressure)
            : base()
        {
            ControlType = this.GetType().Name;
            Pressure = pressure;
        }
    }
}
