using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVACExporter.Models;
using HVACExporter.Models.ComponentSubclasses;
using HVACExporter.Models.ComponentSubclasses.EnergyConversionDeviceSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowMovingDeviceSubclasses;
using HVACExporter.Models.ComponentSubclasses.FittingSubclasses;
using HVACExporter.Models.Connectors;
using HVACExporter.Models.Controls;
using HVACExporter.Models.Enums;
using HVACExporter.Models.GeometricTypes;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Segment = HVACExporter.Models.ComponentSubclasses.Segment;
using HVACExporter.Helpers.ComponentMappers;

namespace HVACExporter.Helpers
{
    public class Mapper
    {
        public static Systems MapAllComponents(FilteredElementCollector allElements)
        {
            Systems system = new Systems();
            //SpacesInModel spacesInModel = new SpacesInModel();

            foreach (Element element in allElements)
            {
                string elementCategory = element.Category.Name;

                if (elementCategory == "Pipes")
                {
                    Pipe pipe = (Pipe)element;

                    Segment component = SegmentMapper.MapPipeToSegment(pipe);

                    system.AddComponent(component);
                }
                else if (elementCategory == "Ducts")
                {
                    Duct duct = (Duct)element;

                    Segment component = SegmentMapper.MapDuctToSegment(duct);

                    system.AddComponent(component);
                }
                else if (elementCategory == "Pipe Fittings" || elementCategory == "Duct Fittings")
                {
                    MEPModel fitting = ((FamilyInstance)element).MEPModel;
                    string fittingType = ((MechanicalFitting)fitting).PartType.ToString();


                    if (fittingType == "Tee")
                    {
                        Tee component = FittingMapper.MapFittingTee(fitting);

                        system.AddComponent(component);
                    }

                    else if (fittingType == "Elbow")
                    {
                        Bend component = FittingMapper.MapFittingBend(fitting);

                        system.AddComponent(component);
                    }
                    else if (fittingType == "Transition")
                    {
                        Reduction component = FittingMapper.MapFittingReduction(fitting);

                        system.AddComponent(component);
                    }
                }
            }

            return system;
        }



    }
}
