﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.XYZOrigin
{
    public class XYZOrigin
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public XYZOrigin(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}