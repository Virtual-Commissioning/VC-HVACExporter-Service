﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class InternalGains
    {
        public List<People> People { get; set; }
        public List<Lighting> Lights { get; set; }
        public List<Equipment> Equipment { get; set; }

        public InternalGains
            (List<People> people, List<Lighting> lighting, List<Equipment> equipment)
        {
            People = people;
            Lights = lighting;
            Equipment = equipment;
        }
    }
}