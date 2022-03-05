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
        public static AirLoadSystem MapAirLoadSystem(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            string id = "Zone" + associatedSpace.Id.ToString() + "_" + "AirLoadSystem";
            string zoneId = associatedSpace.Id.ToString();
            string avaliabilitySchedule = "NA";
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
            string heatingAvaliabilitySchedule = "NA";
            string coolingAvaliabilitySchedule = "NA";
            string dehumidityControlType = "NA";
            double coolingSensibleHeatingRatio = 0;
            string humidityControlType = "NA";
            double humiditySetpoint = 0;
            string outdoorAirMethod = "NA";
            double outAFPPrPerson = 0;
            double outAFPPrArea = 0;
            double outAFPPrZone = 0;
            string outdoorAirObject = "NA";
            string demandControllVentilationType = "NA";
            string outdoorAirEconomizerType = "NA";
            string heatRecoveryType = "NA";
            double sensibleheatRecoveryEfficiency = 0;
            double latentHeatRecoveryEfficiency = 0;

            AirLoadSystem airLoadSystem = new AirLoadSystem(id, zoneId, avaliabilitySchedule, maxHeatingSupplyAirTemp,
                minCoolingSupplyAirTemp, maxHeatingSupplyAirHumidity, minCoolingSupplyAirHumidity, heatingLimit,
                maxHeatingAFR, maxSensibleHeatingCapacity, coolingLimit, maxCoolingAFT, maxSensibleCoolingCapacity,
                heatingAvaliabilitySchedule, coolingAvaliabilitySchedule, dehumidityControlType, coolingSensibleHeatingRatio,
                humidityControlType, humiditySetpoint, outdoorAirMethod, outAFPPrPerson, outAFPPrArea, outAFPPrZone,
                outdoorAirObject, demandControllVentilationType, outdoorAirEconomizerType, heatRecoveryType, 
                sensibleheatRecoveryEfficiency, latentHeatRecoveryEfficiency);
            return airLoadSystem;
        }
    }
}
