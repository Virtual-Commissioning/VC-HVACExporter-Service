using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers
{
    public class ImperialToMetricConverter
    {
        public static double ConvertFromFeetToMeters(double feet)
        {
            return feet * 0.3048;
        }
    }
}