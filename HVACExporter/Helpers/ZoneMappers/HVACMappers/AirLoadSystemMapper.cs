using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class AirLoadSystemMapper
    {
        public static AirLoadSystem MapAirLoadSystem(string analyticalZoneId)
        {
            string zoneId = analyticalZoneId;
            string thermostatName = "Zone" + analyticalZoneId + "_" + "Thermostat";
            string avaliabilitySchedule = "";
            double maxHeatingSupplyAirTemp = 0;
            double minCoolingSupplyAirTemp = 0;
            double maxHeatingSupplyAirHumidity = 0;
            double minCoolingSupplyAirHumidity = 0;
            double heatingLimit = 0;
            double maxHeatingAFR = 0;
            double maxSensibleHeatingCapacity = 0;
            double coolingLimit = 0;
            double maxCoolingAFT = 0;
            double maxSensibleCoolingCapacity = 0;
            string heatingAvaliabilitySchedule = "";
            string coolingAvaliabilitySchedule = "";
            string dehumidityControlType = "";
            double coolingSensibleHeatingRatio = 0;
            double dehumidificationSetpoint = 0;
            string humidityControlType = "";
            double humiditySetpoint = 0;
            string outdoorAirMethod = "";
            double outAFPPrPerson = 0;
            double outAFPPrArea = 0;
            double outAFPPrZone = 0;
            string outdoorAirObject = "";
            string demandControllVentilationType = "";
            string outdoorAirEconomizerType = "";
            string heatRecoveryType = "";
            double sensibleheatRecoveryEfficiency = 0;
            double latentHeatRecoveryEfficiency = 0;

            AirLoadSystem airLoadSystem = new AirLoadSystem(zoneId, thermostatName, avaliabilitySchedule, maxHeatingSupplyAirTemp,
                minCoolingSupplyAirTemp, maxHeatingSupplyAirHumidity, minCoolingSupplyAirHumidity, heatingLimit,
                maxHeatingAFR, maxSensibleHeatingCapacity, coolingLimit, maxCoolingAFT, maxSensibleCoolingCapacity,
                heatingAvaliabilitySchedule, coolingAvaliabilitySchedule, dehumidityControlType, coolingSensibleHeatingRatio,
                dehumidificationSetpoint, humidityControlType, humiditySetpoint, outdoorAirMethod, outAFPPrPerson, outAFPPrArea, outAFPPrZone,
                outdoorAirObject, demandControllVentilationType, outdoorAirEconomizerType, heatRecoveryType, 
                sensibleheatRecoveryEfficiency, latentHeatRecoveryEfficiency);
            return airLoadSystem;
        }
    }
}
