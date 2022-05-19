﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class HVAC
    {
        public Thermostat Thermostat { get; set; }
        public AirLoadSystem IdealAirLoadsSystem { get; set; }

        public HVAC(Thermostat thermostat, AirLoadSystem airLoadSystem)
        {
            Thermostat = thermostat;
            IdealAirLoadsSystem = airLoadSystem;
        }
    }
}