using Autodesk.Revit.DB;
using HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowMovingDeviceSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models.Controls;

namespace HVACExporter.Helpers.ComponentMappers
{
    class MechanicalEquipmentMapper
    {
        public static Radiator MapToRadiator(MEPModel mechanicalEquipment)
        {
            string id = mechanicalEquipment.ConnectorManager.Owner.UniqueId;
            string tag = mechanicalEquipment.ConnectorManager.Owner.Id.ToString();

            string systemIdentifiers = HelperFunctions.MapSystemOfMechEquipment(mechanicalEquipment);

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            double nomPower = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_nomPower").AsDouble(),UnitTypeId.Watts);
            double nomDp = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_nomPressureDrop").AsDouble(),UnitTypeId.Pascals);
            double nomSupplyTemperature = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_nomSupplyTemp").AsDouble(),UnitTypeId.Celsius);
            double nomReturnTemperature = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_nomReturnTemp").AsDouble(),UnitTypeId.Celsius);
            double nomRoomTemperature = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_nomRoomTemp").AsDouble(),UnitTypeId.Celsius);

            Radiator component = new Radiator(id, tag, systemIdentifiers, systemType, nomPower, nomSupplyTemperature, nomReturnTemperature, nomRoomTemperature, nomDp);

            component.FillConnectedComponents(mechanicalEquipment);

            return component;
        }
        public static Fan MapToFan(MEPModel mechanicalEquipment)
        {
            
            string id = mechanicalEquipment.ConnectorManager.Owner.UniqueId;
            string tag = mechanicalEquipment.ConnectorManager.Owner.Id.ToString();

            string systemIdentifiers = HelperFunctions.MapSystemOfMechEquipment(mechanicalEquipment);

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Dictionary<double, double> powerCurve = new Dictionary<double, double>();
            Dictionary<double, double> pressureCurve = new Dictionary<double, double>();

            try
            {
                string powerCurveString = mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_powerCurve").AsString();
                powerCurve = JsonConvert.DeserializeObject<Dictionary<double, double>>(powerCurveString);
            }
            catch (Exception e)
            {
                powerCurve = null;
            }
            try
            {
                string pressureCurveString = mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_pressureCurve").AsString();
                pressureCurve = JsonConvert.DeserializeObject<Dictionary<double, double>>(pressureCurveString);
            }
            catch
            {
                pressureCurve = null;
            }

            Controller control = HelperFunctions.GetController(mechanicalEquipment);

            Fan component = new Fan(id, tag, systemIdentifiers, systemType, control);

            component.PowerCurve = powerCurve;
            component.PressureCurve = pressureCurve;
            
            component.FillConnectedComponents(mechanicalEquipment);


            return component;
        }
        public static Pump MapToPump(MEPModel mechanicalEquipment)
        {

            string id = mechanicalEquipment.ConnectorManager.Owner.UniqueId;
            string tag = mechanicalEquipment.ConnectorManager.Owner.Id.ToString();

            string systemIdentifiers = HelperFunctions.MapSystemOfMechEquipment(mechanicalEquipment);

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);


            Dictionary<double, double> powerCurve;
            Dictionary<double, double> pressureCurve;

            try
            {
                string powerCurveString = mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_powerCurve").AsString();
                powerCurve = JsonConvert.DeserializeObject<Dictionary<double, double>>(powerCurveString);
            }
            catch (Exception e)
            {
                powerCurve = null;
            }
            try
            {
                string pressureCurveString = mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_pressureCurve").AsString();
                pressureCurve = JsonConvert.DeserializeObject<Dictionary<double, double>>(pressureCurveString);
            }
            catch
            {
                pressureCurve = null;
            }

            PumpController pumpController = Pump.GetPumpController(mechanicalEquipment);

            Pump component = new Pump(id, tag, systemIdentifiers, systemType, pumpController);

            component.PowerCurve = powerCurve;
            component.PressureCurve = pressureCurve;

            component.FillConnectedComponents(mechanicalEquipment);

            return component;
        }
        public static ShuntValve MapToShunt(MEPModel mechanicalEquipment)
        {
            string id = mechanicalEquipment.ConnectorManager.Owner.UniqueId;
            string tag = mechanicalEquipment.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = HelperFunctions.MapSystemOfMechEquipment(mechanicalEquipment);

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            bool hasCheckValve = Convert.ToBoolean(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_hasCheckValve").AsInteger());
            double shuntDiameter = UnitUtils.ConvertFromInternalUnits(mechanicalEquipment.ConnectorManager.Owner.LookupParameter("FSC_shuntDiameter").AsDouble(),UnitTypeId.Millimeters);

            ShuntValve component = new ShuntValve(id, tag, systemIdentifiers, systemType, shuntDiameter, hasCheckValve);
            component.FillConnectedComponents(mechanicalEquipment);

            return component;
        }
    }
}
