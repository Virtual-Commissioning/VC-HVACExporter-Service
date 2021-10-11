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
using Segment = HVACExporter.Models.ComponentSubclasses.Segment;

namespace HVACExporter.Helpers
{
    public class SegmentMapper
    {
        public static Segment MapPipeToSegment(Pipe segment)
        {
            string id = segment.UniqueId;
            string tag = segment.Id.IntegerValue.ToString();
            string systemIdentifiers = segment.LookupParameter("System Type").AsValueString().ToLower();
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);
            //double insulationThickness = UnitUtils.ConvertFromInternalUnits(segment.LookupParameter("Insulation Thickness").AsDouble(), UnitTypeId.Millimeters);
            //double insulationThermalConductivity = 0;

            Segment component = new Segment(id
                , tag
                , systemIdentifiers
                , systemType
                //, insulationThickness
                //, insulationThermalConductivity
                );
            component.FillConnectedSegments(segment);

            return component;
        }

        public static Segment MapDuctToSegment(Duct segment)
        {
            string id = segment.UniqueId;
            string tag = segment.Id.IntegerValue.ToString();
            string systemIdentifiers = segment.LookupParameter("System Type").AsValueString().ToLower();
            string systemType = HelperFunctions.GetSystemType(systemIdentifiers);
            //double insulationThickness = UnitUtils.ConvertFromInternalUnits(segment.LookupParameter("Insulation Thickness").AsDouble(), UnitTypeId.Millimeters);
            //double insulationThermalConductivity = 0;

            Segment component = new Segment(id
                , tag
                , systemIdentifiers
                , systemType
                //, insulationThickness
                //, insulationThermalConductivity
                );
            component.FillConnectedSegments(segment);

            return component;
        }

    }

}
