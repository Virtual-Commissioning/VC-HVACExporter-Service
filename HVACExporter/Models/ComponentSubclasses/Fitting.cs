using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.ComponentSubclasses
{
    public class Fitting : Component
    {
        public Fitting(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {

        }

        public void FillConnectedFittings(MEPModel fitting)
        {
            ConnectorSet connectorSet = fitting.ConnectorManager.Connectors;

            foreach (Autodesk.Revit.DB.Connector connector in connectorSet)
            {
                ConnectorSet connectorInfo = connector.AllRefs;
                foreach (Autodesk.Revit.DB.Connector revitConnector in connectorInfo)
                {
                    var connectorId = revitConnector.Owner.Id.ToString();

                    if (connectorId == Tag) continue;

                    var connectedWith = MapFromRevitConnector(revitConnector, connector);
                    ConnectedWith.Add(connectedWith);
                }
            }
        }
    }
}
