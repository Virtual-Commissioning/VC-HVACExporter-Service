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
            double? maxHeatingSupplyAirTemp = null;
            double? minCoolingSupplyAirTemp = null;
            double? maxHeatingSupplyAirHumidity = null;
            double? minCoolingSupplyAirHumidity = null;
            double? heatingLimit = null;
            double? maxHeatingAFR = null;
            double? maxSensibleHeatingCapacity = null;
            double? coolingLimit = null;
            double? maxCoolingAFT = null;
            double? maxSensibleCoolingCapacity = null;
            string heatingAvaliabilitySchedule = "";
            string coolingAvaliabilitySchedule = "";
            string dehumidityControlType = "";
            double? coolingSensibleHeatingRatio = null;
            double? dehumidificationSetpoint = null;
            string humidityControlType = "";
            double? humiditySetpoint = null;
            string outdoorAirMethod = "";
            double? outAFPPrPerson = null;
            double? outAFPPrArea = null;
            double? outAFPPrZone = null;
            string outdoorAirObject = "";
            string demandControllVentilationType = "";
            string outdoorAirEconomizerType = "";
            string heatRecoveryType = "";
            double? sensibleheatRecoveryEfficiency = null;
            double? latentHeatRecoveryEfficiency = null;

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
