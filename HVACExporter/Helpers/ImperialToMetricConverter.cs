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

        public static double ConvertFromSqFeetToSqMeters(double feet)
        {
            return feet * 0.092903;
        }
        public static double ConvertDensityImpToMet(double feet)
        {
            return feet * 35.3146667; //From own calcs 35.3146667;
        }
        public static double ConvertSpecificHeatImpToMet(double feet)
        {
            return feet * 9.290304000000171e-5 * 1000; //From own calcs 9.290304000000171e-5
        }
        public static double ConvertThermalConductivityImpToMet(double feet)
        {
            return feet * 0.3048; //From own calcs 0.3048
        }
        public static double ConvertThermalResistanceImpToMet(double feet)
        {
            return feet / 0.3048; //From own calcs 1/0.3048
        }

    }
}