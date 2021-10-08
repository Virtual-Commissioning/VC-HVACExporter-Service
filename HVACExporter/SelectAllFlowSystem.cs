using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using HVACExporter.Helpers;
using HVACExporter.Models.ComponentSubclasses;
using HVACExporter.Models.Controls;
using HVACExporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HVACExporter
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SelectAllFlowSystem : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiapp = commandData.Application;
            var doc = uiapp.ActiveUIDocument.Document;

            // Loop through all mechanical components
            var allElements = HelperFunctions.GetConnectorElements(doc);


            return Result.Succeeded;
        }


    }
}
