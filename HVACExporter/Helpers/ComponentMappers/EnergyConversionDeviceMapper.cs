using Autodesk.Revit.DB;
using HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ComponentMappers
{
    class EnergyConversionDeviceMapper
    {
        public static List<HeatExchanger> MapToHeatExchanger(MEPModel heatExchanger)
        {
            List<HeatExchanger> components = new List<HeatExchanger>();

            string id = heatExchanger.ConnectorManager.Owner.UniqueId;
            string tag = heatExchanger.ConnectorManager.Owner.Id.ToString();

            double nomFlowPrimary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomFlow1").AsDouble(),UnitTypeId.LitersPerSecond);
            double nomFlowSecondary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomFlow2").AsDouble(),UnitTypeId.LitersPerSecond);
            double nomPower = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomPower").AsDouble(),UnitTypeId.Watts);
            double nomDpPrimary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomPressureDrop1").AsDouble(),UnitTypeId.Pascals);
            double nomDpSecondary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomPressureDrop2").AsDouble(),UnitTypeId.Pascals);
            double nomReturnTemperaturePrimary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomReturnTemp1").AsDouble(),UnitTypeId.Celsius);
            double nomReturnTemperatureSecondary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomReturnTemp2").AsDouble(),UnitTypeId.Celsius);
            double nomSupplyTemperaturePrimary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomSupplyTemp1").AsDouble(),UnitTypeId.Celsius);
            double nomSupplyTemperatureSecondary = UnitUtils.ConvertFromInternalUnits(heatExchanger.ConnectorManager.Owner.LookupParameter("FSC_nomSupplyTemp2").AsDouble(),UnitTypeId.Celsius);

            (List<string> systemTypes, List<string> systemNames) = HelperFunctions.GetSystemTypesFromConnectors(heatExchanger);

            for (int i = 0; i < systemTypes.Count(); i++)
            {
                HeatExchanger component = new HeatExchanger(id,
                                                            tag,
                                                            systemNames[i],
                                                            systemTypes[i],
                                                            nomPower,
                                                            nomSupplyTemperaturePrimary,
                                                            nomSupplyTemperatureSecondary,
                                                            nomReturnTemperaturePrimary,
                                                            nomReturnTemperatureSecondary,
                                                            nomFlowPrimary,
                                                            nomFlowSecondary,
                                                            nomDpPrimary,
                                                            nomDpSecondary);
                component.FillConnectedComponents(heatExchanger);
                components.Add(component);
            }

            return components;
        }
    }
}
