﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class AirGapMat
    {
        public string Name { get; set; }
        public double ThermalResistance { get; set; }

        public AirGapMat(string name, string tag, double thermalResistance)
        {
            Name = name;
            ThermalResistance = thermalResistance;
        }
    }
}