using Autodesk.Revit.DB;
using HVACExporter.Models.Enums;

namespace HVACExporter.Models.ComponentSubclasses
{
    public class FlowController : Component
    {
        public FlowController(string id, string tag, string systemName, string systemType)
            : base(id, tag, systemName, systemType)
        {

        }

        public void FillConnectedPipeAccessories(MEPModel fitting)
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
