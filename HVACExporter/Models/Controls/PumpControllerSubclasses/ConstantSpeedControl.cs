﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Controls.PumpControllerSubclasses
{
    class ConstantSpeedControl : PumpController
    {
        public string ControlType { get; set; }
        public double Speed { get; set; }

        public ConstantSpeedControl(double speed)
            : base()
        {
            ControlType = this.GetType().Name;
            Speed = CheckSpeed(speed);
        }
        public double CheckSpeed(double speed)
        {
            if (speed<1 && speed >= 0)
            {
                return speed;
            }
            else
            {
                throw new ArgumentOutOfRangeException("speed","Parameter 'speed' is out of range. Only 0-1 allowed.");
            }
        }
    }
}
