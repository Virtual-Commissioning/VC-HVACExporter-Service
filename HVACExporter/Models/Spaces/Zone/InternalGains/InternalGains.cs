using System;
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
        public List<Equipment> Equiptment { get; set; }

        public InternalGains
            (List<People> people, List<Lighting> lighting, List<Equipment> equiptment)
        {
            People = people;
            Lights = lighting;
            Equiptment = equiptment;
        }
    }
}