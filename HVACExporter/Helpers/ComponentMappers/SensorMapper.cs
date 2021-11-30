using Autodesk.Revit.DB;
using HVACExporter.Models.ComponentSubclasses.SensorSubclasses;

namespace HVACExporter.Helpers.ComponentMappers
{
    class SensorMapper
    {
        public static TemperatureSensor MapToTemperatureSensor(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            TemperatureSensor component = new TemperatureSensor(id, tag, systemIdentifiers, systemType);
            component.FillConnectedComponents(fitting);

            return component;
        }
        public static PressureSensor MapToPressureSensor(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            PressureSensor component = new PressureSensor(id, tag, systemIdentifiers, systemType);
            component.FillConnectedComponents(fitting);

            return component;
        }
    }
}
