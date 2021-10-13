﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models;

namespace HVACExporter.Helpers
{
    class HelperFunctions
    {
        public static FilteredElementCollector GetConnectorElements(Document doc)
        {
            // what categories of family instances
            // are we interested in?

            BuiltInCategory[] bics = new BuiltInCategory[] {
                BuiltInCategory.OST_DuctFitting,
                BuiltInCategory.OST_DuctTerminal,
                //BuiltInCategory.OST_DuctCurves,
                BuiltInCategory.OST_DuctAccessory,
                BuiltInCategory.OST_MechanicalEquipment,
                BuiltInCategory.OST_PipeFitting,
                BuiltInCategory.OST_PlumbingFixtures,
                BuiltInCategory.OST_PipeAccessory
                //BuiltInCategory.OST_SpecialityEquipment,
                //BuiltInCategory.OST_Sprinklers
            };

            IList<ElementFilter> a = new List<ElementFilter>(bics.Count());

            foreach (BuiltInCategory bic in bics)
            {
                a.Add(new ElementCategoryFilter(bic));
            }

            LogicalOrFilter categoryFilter
              = new LogicalOrFilter(a);

            LogicalAndFilter familyInstanceFilter
                = new LogicalAndFilter(categoryFilter,
                new ElementClassFilter(typeof(FamilyInstance)));

            IList<ElementFilter> b
              = new List<ElementFilter>(6);

            b.Add(new ElementClassFilter(typeof(Duct)));
            b.Add(new ElementClassFilter(typeof(Pipe)));

            b.Add(familyInstanceFilter);

            LogicalOrFilter classFilter
              = new LogicalOrFilter(b);

            FilteredElementCollector collector
              = new FilteredElementCollector(doc);


            collector.WherePasses(classFilter);

            return collector;
        }
        public static string GetSystemType(string systemIdentifiers)
        {
            if (systemIdentifiers.ToLower().Contains("varme"))
            {
                return "heating";
            }
            else if (systemIdentifiers.ToLower().Contains("køling"))
            {
                return "cooling";
            }
            else if (systemIdentifiers.ToLower().Contains("ventilation"))
            {
                return "ventilation";
            }
            else
            {
                return "not a recognized systemtype";
            }
        }
        public static string MapSystemOfMechEquipment(MEPModel element)
        {
            string elementId = element.ConnectorManager.Owner.Id.ToString();
            string connectedWithSystem = string.Empty;
            ConnectorSet elementConnectors = element.ConnectorManager.Connectors;

            foreach (Autodesk.Revit.DB.Connector connector in elementConnectors)
            {

                ConnectorSet connectorInfo = connector.AllRefs;

                foreach (Autodesk.Revit.DB.Connector revitConnector in connectorInfo)
                {
                    var connectorId = revitConnector.Owner.Id.ToString();

                    if (connectorId == elementId) continue;
                    try
                    {
                        connectedWithSystem = revitConnector.Owner.LookupParameter("System Type").AsValueString();
                        if (connectedWithSystem != "Undefined")
                        {
                            return connectedWithSystem;
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                }
            }
            return connectedWithSystem;
        }
        public static string GetFSCType(Element element)
        {
            FamilyInstance familyInstance = (FamilyInstance)element;

            string fscType = familyInstance.Symbol.LookupParameter("FSC_type").AsString();

            return fscType;
        }

    }
}