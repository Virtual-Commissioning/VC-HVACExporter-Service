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
using HVACExporter.Models.System;
using HVACExporter.Models.Spaces;

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

            Systems system = new Systems();
            Spaces spaces = new Spaces();

            var allElements = HelperFunctions.GetConnectorElements(doc);
            var allSpaces = new FilteredElementCollector(doc).OfClass(typeof(SpatialElement));

            system = Mapper.MapAllComponents(allElements);
            spaces = SpaceMapper.MapAllSpaces(allSpaces);

            string serializedJson = JsonParser.ParseToJson(system, spaces);

            HttpClientHelper.POSTData(serializedJson, url);

            return Result.Succeeded;
        }
    }
}
