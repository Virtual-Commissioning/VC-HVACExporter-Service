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
using HVACExporter.Models.Zone;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Models.Spaces.Zone;
using System.Collections.Generic;
using HVACExporter.Models.Zones;
using Autodesk.Revit.DB.Analysis;

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
            List<Materials> allMaterials = new List<Materials>();
            Zones zones = new Zones();

            var allElements = HelperFunctions.GetConnectorElements(doc);
            var allSpaces = new FilteredElementCollector(doc).OfClass(typeof(SpatialElement));
            var allWalls = new FilteredElementCollector(doc).OfClass(typeof(Wall));
            var allRoofs = new FilteredElementCollector(doc).OfClass(typeof(RoofBase));
            var allFloors = new FilteredElementCollector(doc).OfClass(typeof(Floor));
            var allDoors = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_Doors);
            var allWindows = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_Windows);
            //var allAnalyticalSurfaces = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_AnalyticSurfaces);
            var allAnalyticalSurfaces = new FilteredElementCollector(doc).OfClass(typeof(EnergyAnalysisSurface));
            var allAnalyticalSpaces = new FilteredElementCollector(doc).OfClass(typeof(EnergyAnalysisSpace));
            var allAnalyticalSubSurfaces = new FilteredElementCollector(doc).OfClass(typeof(EnergyAnalysisOpening));

            system = Mapper.MapAllComponents(allElements);
            spaces = SpaceMapper.MapAllSpaces(allSpaces);
            allMaterials = MaterialMapper.MapAllMaterials(allWalls, allRoofs, allFloors, allDoors, allWindows, doc);
            zones = ZoneMapper.MapAllZones(allSpaces, doc, allAnalyticalSurfaces, allAnalyticalSpaces, allAnalyticalSubSurfaces);


            (string userId, string projectId, string url) = HelperFunctions.PromptToken();

            string serializedJson = JsonParser.ParseToJson(system, spaces, userId, projectId);

            HttpClientHelper.POSTData(serializedJson, url);

            return Result.Succeeded;
        }
    }
}
