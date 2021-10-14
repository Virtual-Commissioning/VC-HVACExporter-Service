using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using HVACExporter.Models.ComponentSubclasses.FittingSubclasses;

namespace HVACExporter.Helpers.ComponentMappers
{
    class FittingMapper
    {
        public static Tee MapFittingTee(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Tee component = new Tee(id, tag, systemIdentifiers, systemType);
            component.FillConnectedFittings(fitting);
            component.RemoveRedundantUnusedConnectors(component);

            return component;
        }
        public static Cross MapFittingCross(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Cross component = new Cross(id, tag, systemIdentifiers, systemType);
            component.FillConnectedFittings(fitting);

            return component;
        }
        public static Bend MapFittingBend(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);


            string angle = fitting.ConnectorManager.Owner.LookupParameter("Angle").AsValueString().Trim('°');
            bool canParse = double.TryParse(angle, out double parsedAngle);

            if (!canParse)
            {
                throw new FormatException();
            }

            Bend component = new Bend(id, tag, systemIdentifiers, systemType, parsedAngle);
            component.FillConnectedFittings(fitting);

            return component;
        }
        public static Reduction MapFittingReduction(MEPModel fitting)
        {
            string id = fitting.ConnectorManager.Owner.UniqueId;
            string tag = fitting.ConnectorManager.Owner.Id.ToString();
            string systemIdentifiers = fitting.ConnectorManager.Owner.LookupParameter("System Type").AsValueString().ToLower();
            // Add parameter to add a system name that has heat and supply/return
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);

            Reduction component = new Reduction(id, tag, systemIdentifiers, systemType);
            component.FillConnectedFittings(fitting);

            return component;
        }
    }
}
