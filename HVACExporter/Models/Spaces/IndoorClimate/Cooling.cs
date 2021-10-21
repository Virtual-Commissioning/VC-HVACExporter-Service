namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class Cooling
    {
        public ValueMatrix MaxTemp { get; set; }
        public ValueMatrix MinTemp { get; set; }
        public ValueMatrix CoolingDemand { get; set; }

        public Cooling(ValueMatrix maxTemp, ValueMatrix minTemp, ValueMatrix coolingDemand)
        {
            MaxTemp = maxTemp;
            MinTemp = minTemp;
            CoolingDemand = coolingDemand;
        }
    }
}
