namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class IndoorClimateZone
    {
        public Heating Heating { get; set; }
        public Ventilation Ventilation { get; set; }
        public Cooling Cooling { get; set; }
        public HeatGain HeatGain { get; set; }
        public Schedules Schedules { get; set; }

        public IndoorClimateZone(Heating heating, Ventilation ventilation, Cooling cooling, HeatGain heatGain, Schedules schedules)
        {
            Heating = heating;
            Ventilation = ventilation;
            Cooling = cooling;
            HeatGain = heatGain;
            Schedules = schedules;
        }
    }
}
