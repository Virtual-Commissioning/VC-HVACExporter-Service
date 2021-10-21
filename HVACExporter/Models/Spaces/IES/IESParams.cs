namespace HVACExporter.Models.Spaces.IES
{
    public class IESParams
    {
        public string IESSpaceId { get; set; }
        public string Tag { get; set; }
        public string ThermalTemplate { get; set; }
        public double HeatingUnitSize { get; set; }
        public double SimHeatingUnitCapacity { get; set; }
        public double CoolingUnitSize { get; set; }
        public double SimCoolingUnitCapacity { get; set; }
        public double HeatingSetpoint { get; set; }
        public double CoolingSetpoint { get; set; }
        public double MaxHeatgainPeople { get; set; }
        public string HeatgainVariationProfilePeople { get; set; }
        public double MaxHeatgainEquipment { get; set; }
        public string HeatgainVariationProfileEquipment { get; set; }
        public double MaxHeatgainLighting { get; set; }
        public string HeatgainVariationProfileLighting { get; set; }
        public double MaxAirflowFacade { get; set; }
        public double MaxAirflow { get; set; }
        public string AirflowVariationProfile { get; set; }
        public string AirflowTemperatureVariationProfile { get; set; }

        public IESParams(string iESSpaceId,
                         string tag,
                         string thermalTemplate,
                         double heatingUnitSize,
                         double simHeatingUnitCapacity,
                         double coolingUnitSize,
                         double simCoolingUnitCapacity,
                         double heatingSetpoint,
                         double coolingSetpoint,
                         double maxHeatgainPeople,
                         string heatgainVariationProfilePeople,
                         double maxHeatgainEquipment,
                         string heatgainVariationProfileEquipment,
                         double maxHeatgainLighting,
                         string heatgainVariationProfileLighting,
                         double maxAirflowFacade,
                         double maxAirflow,
                         string airflowVariationProfile,
                         string airflowTemperatureVariationProfile)
        {
            IESSpaceId = iESSpaceId;
            Tag = tag;
            ThermalTemplate = thermalTemplate;
            HeatingUnitSize = heatingUnitSize;
            SimHeatingUnitCapacity = simHeatingUnitCapacity;
            CoolingUnitSize = coolingUnitSize;
            SimCoolingUnitCapacity = simCoolingUnitCapacity;
            HeatingSetpoint = heatingSetpoint;
            CoolingSetpoint = coolingSetpoint;
            MaxHeatgainPeople = maxHeatgainPeople;
            HeatgainVariationProfilePeople = heatgainVariationProfilePeople;
            MaxHeatgainEquipment = maxHeatgainEquipment;
            HeatgainVariationProfileEquipment = heatgainVariationProfileEquipment;
            MaxHeatgainLighting = maxHeatgainLighting;
            HeatgainVariationProfileLighting = heatgainVariationProfileLighting;
            MaxAirflowFacade = maxAirflowFacade;
            MaxAirflow = maxAirflow;
            AirflowVariationProfile = airflowVariationProfile;
            AirflowTemperatureVariationProfile = airflowTemperatureVariationProfile;
        }
    }
}
