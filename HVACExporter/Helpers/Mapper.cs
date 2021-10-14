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
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.DamperSubclasses;
using HVACExporter.Models.ComponentSubclasses.FlowControllerSubclasses.ValveSubclasses;
using HVACExporter.Models.Spaces;
using Space = HVACExporter.Models.Spaces.Space;

namespace HVACExporter.Helpers
{
    public class Mapper
    {
        public static Models.System MapAllComponents(FilteredElementCollector allElements)
        {
            Models.System system = new Models.System();
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
                else if (elementCategory == "Pipe Accessories" || elementCategory == "Duct Accessories")
                {
                    MEPModel accessory = ((FamilyInstance)element).MEPModel;

                    string accessoryType = ((FamilyInstance)element).Symbol.Family.get_Parameter(BuiltInParameter.FAMILY_CONTENT_PART_TYPE).AsValueString();
                    string fscType = HelperFunctions.GetFSCType(element);

                    if (accessoryType == "Damper")
                    {
                        if (fscType == "BalancingDamper")
                        {
                            BalancingDamper component = FlowControllerMapper.MapToBalancingDamper(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                        else if (fscType == "MotorizedDamper")
                        {
                            MotorizedDamper component = FlowControllerMapper.MapToMotorizedDamper(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                        else if (fscType == "FireDamper")
                        {
                            FireDamper component = FlowControllerMapper.MapToFireDamper(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                        else
                        {
                            Damper component = FlowControllerMapper.MapToDamper(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                    }
                    else if (accessoryType.ToLower().Contains("valve"))
                    {
                        if (fscType == "BalancingValve")
                        {
                            BalancingValve component = FlowControllerMapper.MapToBalancingValve(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                        else if (fscType == "MotorizedValve")
                        {
                            MotorizedValve component = FlowControllerMapper.MapToMotorizedValve(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                        else
                        {
                            Valve component = FlowControllerMapper.MapToValve(accessory);
                            system.AddComponent(component);

                            if (((FamilyInstance)element).Space == null) continue;
                            Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                            //spacesInModel.AddSpace(space);
                            component.ContainedInSpaces.Add(space.Id.ToString());
                        }
                    }
                    else
                    {
                        if (fscType == "Fan")
                        {
                            Fan component = MechanicalEquipmentMapper.MapToFan(accessory);

                            system.AddComponent(component);
                        }
                        else if (fscType == "Pump")
                        {
                            Pump component = MechanicalEquipmentMapper.MapToPump(accessory);

                            system.AddComponent(component);
                        }
                    }
                }
                else if (elementCategory == "Mechanical Equipment")
                {
                    MEPModel mechanicalEquipment = ((FamilyInstance)element).MEPModel;

                    string fscType = HelperFunctions.GetFSCType(element);

                    if (fscType == "Radiator")
                    {
                        Radiator component = MechanicalEquipmentMapper.MapToRadiator(mechanicalEquipment);

                        if (((FamilyInstance)element).Space == null) continue;
                        Space space = component.GetSpaceAndComponentsInSpace(((FamilyInstance)element));
                        //spacesInModel.AddSpace(space);
                        component.ContainedInSpaces.Add(space.Id.ToString());

                        system.AddComponent(component);
                    }
                    else if (fscType == "Fan")
                    {
                        Fan component = MechanicalEquipmentMapper.MapToFan(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "Pump")
                    {
                        Pump component = MechanicalEquipmentMapper.MapToPump(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "Shunt")
                    {
                        ShuntValve component = MechanicalEquipmentMapper.MapToShunt(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                }
            }

            return system;
        }



    }
}
