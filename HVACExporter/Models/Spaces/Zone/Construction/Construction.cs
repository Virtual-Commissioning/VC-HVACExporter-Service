using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class Construction
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public string OutsideLayerId { get; set; }

        public Construction(string id, string tag, string outsideLayerId)
        {
            Id = id;
            Tag = tag;
            OutsideLayerId = outsideLayerId;
        }
    }
}