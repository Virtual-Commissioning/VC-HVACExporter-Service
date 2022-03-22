using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class AirLoadSystem
    {
        public string Zone_Name { get; set; }
        public string Template_Thermostat_Name { get; set; }
        public string System_Availability_Schedule_Name { get; set; }
        public double? Maximum_Heating_Supply_Air_Temperature { get; set; }
        public double? Minimum_Cooling_Supply_Air_Temperature { get; set; }
        public double? Maximum_Heating_Supply_Air_Humidity_Ratio { get; set; }
        public double? Minimum_Cooling_Supply_Air_Humidity_Ratio { get; set; }
        public double? Heating_Limit { get; set; }
        public double? Maximum_Heating_Air_Flow_Rate { get; set; }
        public double? Maximum_Sensible_Heating_Capacity { get; set; }
        public double? Cooling_Limit { get; set; }
        public double? Maximum_Cooling_Air_Flow_Rate { get; set; }
        public double? Maximum_Total_Cooling_Capacity { get; set; }
        public string Heating_Availability_Schedule_Name { get; set;}
        public string Cooling_Availability_Schedule_Name { get; set;}
        public string Dehumidification_Control_Type { get; set;}
        public double? Cooling_Sensible_Heat_Ratio { get; set; }
        public double? Dehumidification_Setpoint { get; set; }
        public string Humidification_Control_Type { get; set;}
        public double? Humidification_Setpoint { get; set; }
        public string Outdoor_Air_Method { get; set; }
        public double? Outdoor_Air_Flow_Rate_per_Person { get; set; }
        public double? Outdoor_Air_Flow_Rate_per_Zone_Floor_Area { get; set; }
        public double? Outdoor_Air_Flow_Rate_per_Zone { get; set; }
        public string Design_Specification_Outdoor_Air_Object_Name { get; set; }
        public string Demand_Controlled_Ventilation_Type { get; set; }
        public string Outdoor_Air_Economizer_Type { get; set; }
        public string Heat_Recovery_Type { get; set; }
        public double? Sensible_Heat_Recovery_Effectiveness { get; set; }
        public double? Latent_Heat_Recovery_Effectiveness { get; set; }


        public AirLoadSystem(string zoneId, string thermostatName, string avaliabilitySchedule, double? maxHeatingSupplyAirTemp, 
            double? minCoolingSupplyAirTemp, double? maxHeatingSupplyAirHumidity, double? minCoolingSupplyAirHumidity,
            double? heatingLimit, double? maxHeatingAFR, double? maxSensibleHeatingCapacity, double? coolingLimit, 
            double? maxCoolingAFR, double? maxSensibleCoolingCapacity, string heatingAvaliabilitySchedule, string coolingAvaliabilitySchedule,
            string dehumidityControlType, double? coolingSensibleHeatingRatio, double? dehumidificationSetpoint, string humidityControlType, 
            double? humiditySetpoint, string outdoorAirMethod, double outAFRPrPerson, double? outAFRPrArea, double? outAFRPrZone,
            string outdoorAirObject, string demandControlledVentilationType, string outdoorAirEconomizerType, 
            string heatRecoveryType, double? sensibleHeatRecoveryEfficiency, double? latentHeatRecoveryEfficiency)
        {
            Zone_Name = zoneId;
            Template_Thermostat_Name = thermostatName;
            System_Availability_Schedule_Name = avaliabilitySchedule;
            Maximum_Heating_Supply_Air_Temperature = maxHeatingSupplyAirTemp;
            Minimum_Cooling_Supply_Air_Temperature = minCoolingSupplyAirTemp;
            Maximum_Heating_Supply_Air_Humidity_Ratio = maxHeatingSupplyAirHumidity;
            Minimum_Cooling_Supply_Air_Humidity_Ratio = minCoolingSupplyAirHumidity;
            Heating_Limit = heatingLimit;
            Maximum_Heating_Air_Flow_Rate = maxHeatingAFR;
            Maximum_Sensible_Heating_Capacity = maxSensibleHeatingCapacity;
            Cooling_Limit = coolingLimit;
            Maximum_Cooling_Air_Flow_Rate = maxCoolingAFR;
            Maximum_Total_Cooling_Capacity = maxSensibleCoolingCapacity;
            Heating_Availability_Schedule_Name = heatingAvaliabilitySchedule;
            Cooling_Availability_Schedule_Name = coolingAvaliabilitySchedule;
            Dehumidification_Control_Type = dehumidityControlType;
            Cooling_Sensible_Heat_Ratio = coolingSensibleHeatingRatio;
            Dehumidification_Setpoint = dehumidificationSetpoint;
            Humidification_Control_Type = humidityControlType;
            Humidification_Setpoint = humiditySetpoint;
            Outdoor_Air_Method = outdoorAirMethod;
            Outdoor_Air_Flow_Rate_per_Person = outAFRPrPerson;
            Outdoor_Air_Flow_Rate_per_Zone_Floor_Area = outAFRPrArea;
            Outdoor_Air_Flow_Rate_per_Zone = outAFRPrZone;
            Design_Specification_Outdoor_Air_Object_Name = outdoorAirObject;
            Demand_Controlled_Ventilation_Type = demandControlledVentilationType;
            Outdoor_Air_Economizer_Type = outdoorAirEconomizerType;
            Heat_Recovery_Type = heatRecoveryType;
            Sensible_Heat_Recovery_Effectiveness = sensibleHeatRecoveryEfficiency;
            Latent_Heat_Recovery_Effectiveness = latentHeatRecoveryEfficiency;
        }
    }
}