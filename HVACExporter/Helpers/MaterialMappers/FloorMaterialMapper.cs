﻿using Autodesk.Revit.DB;
using HVACExporter.Helpers.MaterialMappers;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using System;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    class FloorMaterialMapper
    {
        public static List<SurfaceMat> MapAllFloors(FilteredElementCollector allFloors, Autodesk.Revit.DB.Document doc)   
        {
            List<SurfaceMat> layerFloorMaterials = new List<SurfaceMat>();
            
            foreach (Floor floor in allFloors)
            {
                CompoundStructure structure = floor.FloorType.GetCompoundStructure();
                IList<CompoundStructureLayer> layers = structure.GetLayers();

                foreach (CompoundStructureLayer layer in layers)
                {
                    string id = layer.MaterialId.ToString();
                    double thickness = Math.Round(ImperialToMetricConverter.ConvertFromFeetToMeters(layer.Width), 3);
                    Material layerFloorMaterial = doc.GetElement(layer.MaterialId) as Material;
                    int roughness = 0;
                    double thermalAbsorbtance = 0; 
                    double solarAbsorbtance = 0; 
                    double visibleAbsorbtance = 0;
                    // Getting thermal assets:
                    ElementId thermalAssetId = layerFloorMaterial.ThermalAssetId;
                    PropertySetElement pse = doc.GetElement(thermalAssetId) as PropertySetElement;
                    if (pse == null) continue;
                    ThermalAsset asset = pse.GetThermalAsset();
                    double conductivity = Math.Round(ImperialToMetricConverter.ConvertThermalConductivityImpToMet(asset.ThermalConductivity),3);
                    double density = Math.Round(ImperialToMetricConverter.ConvertDensityImpToMet(asset.Density),3);
                    double specificHeat = Math.Round(ImperialToMetricConverter.ConvertSpecificHeatImpToMet(asset.SpecificHeat),3);

                    SurfaceMat layerFloorMaterialToAdd = new SurfaceMat(id, roughness, thickness,
                        conductivity, density, specificHeat, thermalAbsorbtance,
                        solarAbsorbtance, visibleAbsorbtance);

                    layerFloorMaterials.Add(layerFloorMaterialToAdd);
                }
            }

            return layerFloorMaterials;

        }
    }
}
