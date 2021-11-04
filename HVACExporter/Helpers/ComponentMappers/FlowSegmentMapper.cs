using HVACExporter.Models.ComponentSubclasses;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowSegment = HVACExporter.Models.ComponentSubclasses.FlowSegment;

namespace HVACExporter.Helpers.ComponentMappers
{
    public class FlowSegmentMapper
    {
        public static FlowSegment MapPipeToSegment(Pipe segment)
        {
            string id = segment.UniqueId;
            string tag = segment.Id.IntegerValue.ToString();
            string systemIdentifiers = segment.LookupParameter("System Type").AsValueString().ToLower();
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);
            double insulationThickness = UnitUtils.ConvertFromInternalUnits(segment.LookupParameter("Insulation Thickness").AsDouble(), UnitTypeId.Millimeters);
            double insulationThermalConductivity;

            if (insulationThickness != 0)
            {
                insulationThermalConductivity = HelperFunctions.GetSegmentInsulationConductivity(segment);
            }


            FlowSegment component = new FlowSegment(id
                , tag
                , systemIdentifiers
                , systemType
                //, insulationThickness
                //, insulationThermalConductivity
                );
            component.FillConnectedComponents(segment);

            return component;
        }

        public static FlowSegment MapDuctToSegment(Duct segment)
        {
            string id = segment.UniqueId;
            string tag = segment.Id.IntegerValue.ToString();
            string systemIdentifiers = segment.LookupParameter("System Type").AsValueString().ToLower();
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);
            double insulationThickness = UnitUtils.ConvertFromInternalUnits(segment.LookupParameter("Insulation Thickness").AsDouble(), UnitTypeId.Millimeters);
            double insulationThermalConductivity;

            if (insulationThickness != 0)
            {
                insulationThermalConductivity = HelperFunctions.GetSegmentInsulationConductivity(segment);
            }

            FlowSegment component = new FlowSegment(id
                , tag
                , systemIdentifiers
                , systemType
                //, insulationThickness
                //, insulationThermalConductivity
                );
            component.FillConnectedComponents(segment);

            return component;
        }
    }
}
