﻿using Autodesk.Revit.Attributes;
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
            Materials materials = new Materials();
            LayerMaterials layerMaterials = new LayerMaterials();

            var allElements = HelperFunctions.GetConnectorElements(doc);
            var allSpaces = new FilteredElementCollector(doc).OfClass(typeof(SpatialElement));
            var allMaterials = new FilteredElementCollector(doc).OfClass(typeof(Material));
            var allWalls = new FilteredElementCollector(doc).OfClass(typeof(Wall));

            system = Mapper.MapAllComponents(allElements);
            spaces = SpaceMapper.MapAllSpaces(allSpaces);
            materials = MaterialMapper.MapAllMaterials(allMaterials);
            layerMaterials = WallMaterialMapper.MapAllWalls(allWalls);

            (string userId, string projectId, string url) = HelperFunctions.PromptToken();

            string serializedJson = JsonParser.ParseToJson(system, spaces, userId, projectId);

            HttpClientHelper.POSTData(serializedJson, url);

            return Result.Succeeded;
        }
    }
}
