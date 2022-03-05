using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class InternalGains
    {
        public People People { get; set; }
        public Lighting Lighting { get; set; }
        public Equipment Equiptment { get; set; }

        public InternalGains
            (People people, Lighting lighting, Equipment equiptment)
        {
            People = people;
            Lighting = lighting;
            Equiptment = equiptment;
        }
    }
}