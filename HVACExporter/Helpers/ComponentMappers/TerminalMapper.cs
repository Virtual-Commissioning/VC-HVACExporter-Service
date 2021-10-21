using Autodesk.Revit.DB;
using HVACExporter.Models.ComponentSubclasses.TerminalSubclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers.ComponentMappers
{
    class TerminalMapper
    {
        public static AirTerminal MapToAirTerminal(MEPModel terminal)
        {
            string id = terminal.ConnectorManager.Owner.UniqueId;
            string tag = terminal.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = terminal.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            double kv = terminal.ConnectorManager.Owner.LookupParameter("FSC_kv").AsDouble();

            AirTerminal component = new AirTerminal(id, tag, systemIdentifiers, systemType, kv);

            component.FillConnectedComponents(terminal);

            return component;
        }
        
    }
}
