using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using HVACExporter.Helpers.SpaceMappers;
using HVACExporter.Helpers.ZoneMappers.InternalGainsMappers;
using HVACExporter.Models.GeometricTypes;
using HVACExporter.Models.Spaces;
using HVACExporter.Models.Spaces.Geometry;
using HVACExporter.Models.Spaces.IndoorClimate;
using HVACExporter.Models.Zone;
using HVACExporter.Models.Zones;
using System.Collections.Generic;
using Surface = HVACExporter.Models.Zone.Surface;

namespace HVACExporter.Helpers
{
    public class ZoneMapper
    {
        public static List<Dictionary<string, Zone>> MapAllZones
            (FilteredElementCollector allSpaces, Document doc, FilteredElementCollector allAnalyticalSurfaces, 
            FilteredElementCollector allAnalyticalSpaces, FilteredElementCollector allAnalyticalSubSurfaces)
        {
            List<Dictionary<string, Zone>> allZones = new List<Dictionary<string, Zone>>();
            int n = 0;
            List<EnergyAnalysisSpace> energyAnalysisSpaces = new List<EnergyAnalysisSpace>();
            foreach (EnergyAnalysisSpace space in allAnalyticalSpaces)
            {
                energyAnalysisSpaces.Add(space);
            }

            foreach (SpatialElement zone in allSpaces)
            {
                if (zone.Category.Name != "Spaces") continue;
                //string tag = zone.Id.ToString();
                Autodesk.Revit.DB.Mechanical.Space associatedSpace = (Autodesk.Revit.DB.Mechanical.Space)zone;
                double x, y, z;
                if (associatedSpace.Location == null)
                {
                    x = 0;
                    y = 0;
                    z = 0;
                }
                else
                {
                    x = ((LocationPoint)associatedSpace.Location).Point.X;
                    y = ((LocationPoint)associatedSpace.Location).Point.Y;
                    z = ((LocationPoint)associatedSpace.Location).Point.Z;
                }
                string zoneType;
                if (associatedSpace.SpaceType.ToString() == string.Empty)
                {
                    zoneType = "NA";
                }
                else
                {
                    zoneType = associatedSpace.SpaceType.ToString();
                }
                //string id = associatedSpace.Id.ToString();
                string analyticalZoneId = energyAnalysisSpaces[n].Id.ToString();
                double ceilingHeight = associatedSpace.UnboundedHeight;
                double floorArea = associatedSpace.Area;
                double zoneVolume = (associatedSpace.UnboundedHeight - associatedSpace.Level.Elevation) * floorArea;
                string intConvAlg = "0";
                string outConvAlg = "0";
                bool includedInTotArea = true;

                List<Dictionary<string, Models.Zone.Surface>> surfaces = SurfaceMapper.MapSurfaces
                    (analyticalZoneId, doc, allAnalyticalSurfaces, allAnalyticalSubSurfaces);
                InternalGains internalGains = InternalGainsMapper.MapInternalGains(associatedSpace);
                HVAC hvac = HVACMapper.MapHVAC(associatedSpace);
                Infiltration infiltration = InfiltrationMapper.MapInfiltration(associatedSpace);
                ShadingZone shadingZone = ZoneShadingMapper.MapZoneShading(associatedSpace);
                var zoneToAdd = new Zone(analyticalZoneId,
                                     x,
                                     y,
                                     z,
                                     zoneType,
                                     ceilingHeight,
                                     floorArea,
                                     zoneVolume,
                                     intConvAlg,
                                     outConvAlg,
                                     includedInTotArea,
                                     surfaces, 
                                     internalGains,
                                     hvac,
                                     infiltration,
                                     shadingZone);

                Dictionary<string, Zone> linkedZone = new Dictionary<string, Zone>();
                linkedZone.Add(analyticalZoneId, zoneToAdd);
                allZones.Add(linkedZone);

                n++;
            }

            return allZones;
        }
    }
}