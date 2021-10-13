using Autodesk.Revit.DB;
using HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Radiator component = new Radiator(id, tag, $"{systemType} consumer", systemType, nomPower, nomSupplyTemperature, nomReturnTemperature, nomRoomTemperature, nomDp);

            component.FillConnectedMechEquipment(mechanicalEquipment);

            return component;
        }
    }
}
