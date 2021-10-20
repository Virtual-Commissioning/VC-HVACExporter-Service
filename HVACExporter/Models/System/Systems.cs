using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.System
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
        public List<Component> Components { get; set; } = new List<Component>();

        public SubSystem(string type)
        {
            Type = type;
        }

        public void AddComponent(Component component)
        {
            Components.Add(component);
        }
    }
}

