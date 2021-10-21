using System.Collections.Generic;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.IndoorClimate;

namespace HVACExporter.Helpers.SpaceMappers
{
    public class IndoorClimateMapper
    {
        public static IndoorClimateZone MapIndoorClimate()
        {
            //Now we fill the IndoorClimateZone
            //Heating
            ValueMatrix heatingMaxTemp = new ValueMatrix(26, 27);
            ValueMatrix heatingMinTemp = new ValueMatrix(22, 21);
            ValueMatrix heatingDemand = new ValueMatrix(400, 500);
            Heating heating = new Heating(heatingMaxTemp, heatingMinTemp, heatingDemand);
            //Ventilation
            ValueMatrix airFlow = new ValueMatrix(1, 2);
            ValueMatrix airTemp = new ValueMatrix(18, 18);
            Ventilation ventilation = new Ventilation(airFlow, airTemp);
            //Cooling
            ValueMatrix coolingMaxTemp = new ValueMatrix(25, 27);
            ValueMatrix coolingMinTemp = new ValueMatrix(18, 19);
            ValueMatrix coolingDemand = new ValueMatrix(6000, 7000);
            Cooling cooling = new Cooling(coolingMaxTemp, coolingMinTemp, coolingDemand);

            //Heatgain
            //Peopleload
            ValueMatrix amountOfPeople = new ValueMatrix(20, 20);
            double heatLoadPrPerson = 100;
            PeopleLoad peopleLoad = new PeopleLoad(amountOfPeople, heatLoadPrPerson);
            //Equipmentload
            ValueMatrix amountOfEquipment = new ValueMatrix(20, 20);
            double heatloadPrEquipment = 200;
            EquipmentLoad equipmentLoad = new EquipmentLoad(amountOfEquipment, heatloadPrEquipment);
            //Lightingload
            ValueMatrix heatLoadPrSqm = new ValueMatrix(5, 5);
            LightingLoad lightingLoad = new LightingLoad(heatLoadPrSqm);
            //Externalload
            double heatLoad = 5000;
            ExternalLoad externalLoad = new ExternalLoad(heatLoad);
            //Create HeatGain
            HeatGain heatGain = new HeatGain(peopleLoad, equipmentLoad, lightingLoad, externalLoad);

            //Schedules
            //PeopleSchedule
            var peopleTimer = new List<double>(new double[] { 0, 10, 20, 24 });
            var peoplePercentage = new List<double>(new double[] { 0.5, 1, 0.5 });
            var peopleSchedule = new Schedule(peopleTimer, peoplePercentage);
            //EquipmentSchedule
            var equipmentTimer = new List<double>(new double[] { 0, 10, 20, 24 });
            var equipmentPercentage = new List<double>(new double[] { 0.5, 1, 0.5 });
            var equipmentSchedule = new Schedule(equipmentTimer, equipmentPercentage);
            //LightingSchedule
            var lightingTimer = new List<double>(new double[] { 0, 10, 20, 24 });
            var lightingPercentage = new List<double>(new double[] { 0.5, 1, 0.5 });
            var lightingSchedule = new Schedule(lightingTimer, lightingPercentage);
            //ExternalSchedule
            var externalTimer = new List<double>(new double[] { 0, 10, 20, 24 });
            var externalPercentage = new List<double>(new double[] { 0.5, 1, 0.5 });
            var externalSchedule = new Schedule(externalTimer, externalPercentage);
            //Create Schedule
            var schedules = new Schedules(peopleSchedule, equipmentSchedule, lightingSchedule, externalSchedule);
            
            //Create the IndoorClimateZone
            return new IndoorClimateZone(heating, ventilation, cooling, heatGain, schedules);
        }
        
    }
}
