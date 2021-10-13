using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models
{
    public class Systems
    {
        public Dictionary<string, SubSystem> SubSystems { get; set; } = new Dictionary<string, SubSystem>();
        public Systems()
        {

        }

        public void AddComponent(Component component)
        {
            if (!SubSystems.ContainsKey(component.SystemType))
            {
                CreateSubSystem(component.SystemType);
            }

            SubSystems[component.SystemType].AddComponent(component);
        }

        public void CreateSubSystem(string type)
        {
            SubSystem subSystem = new SubSystem(type);
            SubSystems[type] = subSystem;
        }

        public void BuildLocation(string systemName)
        {
            throw new NotImplementedException();
        }


    }
    public class SubSystem
    {
        public string Type { get; set; }
        public List<Component> SupplySystem { get; set; } = new List<Component>();
        public List<Component> ReturnSystem { get; set; } = new List<Component>();
        public List<Component> Suppliers { get; set; } = new List<Component>();
        public List<Component> Consumers { get; set; } = new List<Component>();

        public SubSystem(string type)
        {
            Type = type;
        }

        public void AddSupplyComponent(Component component)
        {
            SupplySystem.Add(component);
        }

        public void AddReturnComponent(Component component)
        {
            ReturnSystem.Add(component);
        }

        public void AddSupplier(Component component)
        {
            Suppliers.Add(component);
        }

        public void AddConsumer(Component component)
        {
            Consumers.Add(component);
        }

        public void AddComponent(Component component)
        {

            if (component.SystemName.ToLower().Contains("frem") || component.SystemName.ToLower().Contains("tilluft"))
            {
                AddSupplyComponent(component);
            }
            else if (component.SystemName.ToLower().Contains("retur") || component.SystemName.ToLower().Contains("fraluft"))
            {
                AddReturnComponent(component);
            }
            else if (component.SystemName.ToLower().Contains("supplier"))
            {
                AddSupplier(component);
            }
            else if (component.SystemName.ToLower().Contains("consumer"))
            {
                AddConsumer(component);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

