﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Controls.PumpControllerSubclasses
{
    class ProportionalPressureControl : PumpController
    {
        public string ControlType { get; set; }
        public ProportionalPressureControl()
            : base()
        {
            ControlType = this.GetType().Name;
            throw new NotImplementedException("This class is not yet supported.");
        }
    }
}
