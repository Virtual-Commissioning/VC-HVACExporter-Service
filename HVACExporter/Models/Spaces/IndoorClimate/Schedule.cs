using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class Schedule
    {
        public List<double> Timer { get; set; }
        public List<double> Load { get; set; }

        public Schedule(List<double> timer, List<double> load)
        {
            Timer = timer;
            Load = load;
        }
    }
}
