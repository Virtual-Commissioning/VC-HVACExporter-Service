using Autodesk.Revit.DB;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;

namespace HVACExporter.Helpers.MaterialMappers
{
    class CurtainWallWindowMaterialMapper
    {
        public static List<Dictionary<string, WindowMat>> MapAllCurtainWallWindows(FilteredElementCollector allWalls)
        {
            List<Dictionary<string, WindowMat>> windowMaterials = new List<Dictionary<string, WindowMat>>();

            foreach (Wall wall in allWalls)
            {
                if (wall.WallType.Kind.ToString() != "Curtain") continue;
                string name = "CW_Window_Mat_" + wall.Id.ToString();
                double uFactor = 0;
                double solarHeatGain = 0;
                double visibleTransmittance = 0;

                WindowMat windowMaterial = new WindowMat(name, uFactor, solarHeatGain, visibleTransmittance);
                Dictionary<string, WindowMat> linkedWindowMaterial = new Dictionary<string, WindowMat>();
                linkedWindowMaterial.Add(windowMaterial.Name, windowMaterial);
                windowMaterials.Add(linkedWindowMaterial);
            }
            return windowMaterials;
        }
    }
}

