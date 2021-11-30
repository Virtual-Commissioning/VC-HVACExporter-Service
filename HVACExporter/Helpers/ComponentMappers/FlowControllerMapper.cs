using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.DamperSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses;
using Autodesk.Revit.DB;
using HVACExporter.Models.Controls;

namespace HVACExporter.Helpers.ComponentMappers
{
    class FlowControllerMapper
    {
        public static BalancingDamper MapToBalancingDamper(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            double kv = accessory.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();
            double kvs = accessory.ConnectorManager.Owner.LookupParameter("FSC_kvs").AsDouble();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            BalancingDamper component = new BalancingDamper(id, tag, systemIdentifiers, systemType, kv, kvs);
            
            component.FillConnectedComponents(accessory);
            
            return component;
        }
        public static MotorizedDamper MapToMotorizedDamper(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            double kv = accessory.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();
            double kvs = accessory.ConnectorManager.Owner.LookupParameter("FSC_kvs").AsDouble();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Controller control = HelperFunctions.GetController(accessory);

            MotorizedDamper component = new MotorizedDamper(id, tag, systemIdentifiers, systemType, kv, kvs, control);
            
            component.FillConnectedComponents(accessory);

            return component;
        }
        public static FireDamper MapToFireDamper(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            double kv = accessory.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();
            double kvs = accessory.ConnectorManager.Owner.LookupParameter("FSC_kvs").AsDouble();
            string fireDamperType = "Unknown";

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            FireDamper component = new FireDamper(id, tag, systemIdentifiers, systemType, kv, kvs,fireDamperType);
            
            component.FillConnectedComponents(accessory);

            return component;
        }
        public static Damper MapToDamper(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Damper component = new Damper(id, tag, systemIdentifiers, systemType);
            
            component.FillConnectedComponents(accessory);

            return component;
        }
        public static BalancingValve MapToBalancingValve(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            double kv = accessory.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();
            double kvs = accessory.ConnectorManager.Owner.LookupParameter("FSC_kvs").AsDouble();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            BalancingValve component = new BalancingValve(id, tag, systemIdentifiers, systemType, kv, kvs);
            
            component.FillConnectedComponents(accessory);

            return component;
        }
        public static MotorizedValve MapToMotorizedValve(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            double kv = accessory.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();
            double kvs = accessory.ConnectorManager.Owner.LookupParameter("FSC_kvs").AsDouble();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Controller control = HelperFunctions.GetController(accessory);

            MotorizedValve component = new MotorizedValve(id, tag, systemIdentifiers, systemType, kv, kvs, control);
            
            component.FillConnectedComponents(accessory);

            return component;
        }
        public static Valve MapToValve(MEPModel accessory)
        {
            string id = accessory.ConnectorManager.Owner.UniqueId;
            string tag = accessory.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = accessory.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();

            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Valve component = new Valve(id, tag, systemIdentifiers, systemType);
            
            component.FillConnectedComponents(accessory);

            return component;
        }

    }
}
