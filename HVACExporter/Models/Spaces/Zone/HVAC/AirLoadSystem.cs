using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class AirLoadSystem
    {
        public string ZoneId { get; set; }
        public string ThermostatId { get; set;}
        public string AvaliabilitySchedule { get; set; }
        public double MaxHeatingSupplyAirTemp { get; set; }
        public double MinCoolingSupplyAirTemp { get; set; }
        public double MaxHeatingSupplyAirHumidity { get; set; }
        public double MinCoolingSupplyAirHumidity { get; set; }
        public double HeatingLimit { get; set; }
        public double MaxHeatingAFR { get; set; }
        public double MaxSensibleHeatingCapacity { get; set; }
        public double CoolingLimit { get; set; }
        public double MaxCoolingAFR { get; set; }
        public double MaxSensibleCoolingCapacity { get; set; }
        public string HeatingAvaliabilitySchedule { get; set;}
        public string CoolingAvaliabilitySchedule { get; set;}
        public string DehumidityControlType { get; set;}
        public double CoolingSensibleHeatingRatio { get; set; }
        public string HumidityControlType { get; set;}
        public double HumiditySetpoint { get; set; }
        public string OutdoorAirMethod { get; set; }
        public double OutAFRPrPerson { get; set; }
        public double OutAFRPrArea { get; set; }
        public double OutAFRPrZone { get; set; }
        public string OutdoorAirObject { get; set; }
        public string DemandControlledVentilationType { get; set; }
        public string OutdoorAirEconomizerType { get; set; }
        public string HeatRecoveryType { get; set; }
        public double SensibleHeatRecoveryEfficiency { get; set; }
        public double LatentHeatRecoveryEfficiency { get; set; }


        public AirLoadSystem(string zoneId, string thermostatId, string avaliabilitySchedule, double maxHeatingSupplyAirTemp, double minCoolingSupplyAirTemp, double maxHeatingSupplyAirHumidity, double minCoolingSupplyAirHumidity,
            double heatingLimit, double maxHeatingAFR, double maxSensibleHeatingCapacity, double coolingLimit, double maxCoolingAFR, double maxSensibleCoolingCapacity, string heatingAvaliabilitySchedule, string coolingAvaliabilitySchedule,
            string dehumidityControlType, double coolingSensibleHeatingRatio, string humidityControlType, double humiditySetpoint, string outdoorAirMethod, double outAFRPrPerson, double outAFRPrArea, double outAFRPrZone,
            string outdoorAirObject, string demandControlledVentilationType, string outdoorAirEconomizerType, string heatRecoveryType, double sensibleHeatRecoveryEfficiency, double latentHeatRecoveryEfficiency)
        {
            ZoneId = zoneId;
            ThermostatId = thermostatId;
            AvaliabilitySchedule = avaliabilitySchedule;
            MaxHeatingSupplyAirTemp = maxHeatingSupplyAirTemp;
            MinCoolingSupplyAirTemp = minCoolingSupplyAirTemp;
            MaxHeatingSupplyAirHumidity = maxHeatingSupplyAirHumidity;
            MinCoolingSupplyAirHumidity = minCoolingSupplyAirHumidity;
            HeatingLimit = heatingLimit;
            MaxHeatingAFR = maxHeatingAFR;
            MaxSensibleHeatingCapacity = maxSensibleHeatingCapacity;
            CoolingLimit = coolingLimit;
            MaxCoolingAFR = maxCoolingAFR;
            MaxSensibleCoolingCapacity = maxSensibleCoolingCapacity;
            HeatingAvaliabilitySchedule = heatingAvaliabilitySchedule;
            CoolingAvaliabilitySchedule = coolingAvaliabilitySchedule;
            DehumidityControlType = dehumidityControlType;
            CoolingSensibleHeatingRatio = coolingSensibleHeatingRatio;
            HumidityControlType = humidityControlType;
            HumiditySetpoint = humiditySetpoint;
            OutdoorAirMethod = outdoorAirMethod;
            OutAFRPrPerson = outAFRPrPerson;
            OutAFRPrArea = outAFRPrArea;
            OutAFRPrZone = outAFRPrZone;
            OutdoorAirObject = outdoorAirObject;
            DemandControlledVentilationType = demandControlledVentilationType;
            OutdoorAirEconomizerType = outdoorAirEconomizerType;
            HeatRecoveryType = heatRecoveryType;
            SensibleHeatRecoveryEfficiency = sensibleHeatRecoveryEfficiency;
            LatentHeatRecoveryEfficiency = latentHeatRecoveryEfficiency;
        }
    }
}