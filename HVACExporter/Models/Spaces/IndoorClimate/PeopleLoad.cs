using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class PeopleLoad
    {
        public ValueMatrix AmountOfPeople { get; set; }
        public double HeatloadPrPerson { get; set; }

        public PeopleLoad(ValueMatrix amountOfPeople, double heatloadPrPerson)
        {
            AmountOfPeople = amountOfPeople;
            HeatloadPrPerson = heatloadPrPerson;
        }
    }
}
