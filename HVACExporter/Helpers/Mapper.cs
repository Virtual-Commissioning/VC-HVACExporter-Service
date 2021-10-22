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
using HVACExporter.Models.System;
using HVACExporter.Models.ComponentSubclasses.TerminalSubclasses;

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
                Component component = new Component(null, null, null, null);

                string elementCategory = element.Category.Name;

                if (elementCategory == "Pipes")
                {
                    Pipe pipe = (Pipe)element;

                    component = SegmentMapper.MapPipeToSegment(pipe);

                    system.AddComponent(component);
                }
                else if (elementCategory == "Ducts")
                {
                    Duct duct = (Duct)element;

                    component = SegmentMapper.MapDuctToSegment(duct);

                    system.AddComponent(component);
                }
                else if (elementCategory == "Pipe Fittings" || elementCategory == "Duct Fittings")
                {
                    MEPModel fitting = ((FamilyInstance)element).MEPModel;
                    string fittingType = ((MechanicalFitting)fitting).PartType.ToString();


                    if (fittingType == "Tee")
                    {
                        component = FittingMapper.MapFittingTee(fitting);

                        system.AddComponent(component);
                    }
                    else if (fittingType == "Cross")
                    {
                        component = FittingMapper.MapFittingCross(fitting);

                        system.AddComponent(component);
                    }
                    else if (fittingType == "Elbow")
                    {
                        component = FittingMapper.MapFittingBend(fitting);

                        system.AddComponent(component);
                    }
                    else if (fittingType == "Transition")
                    {
                        component = FittingMapper.MapFittingReduction(fitting);

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
                            component = FlowControllerMapper.MapToBalancingDamper(accessory);
                            system.AddComponent(component);
                        }
                        else if (fscType == "MotorizedDamper")
                        {
                            component = FlowControllerMapper.MapToMotorizedDamper(accessory);
                            system.AddComponent(component);
                        }
                        else if (fscType == "FireDamper")
                        {
                            component = FlowControllerMapper.MapToFireDamper(accessory);
                            system.AddComponent(component);
                        }
                        else
                        {
                            component = FlowControllerMapper.MapToDamper(accessory);
                            system.AddComponent(component);
                        }
                    }
                    else if (accessoryType.ToLower().Contains("valve"))
                    {
                        if (fscType == "BalancingValve")
                        {
                            component = FlowControllerMapper.MapToBalancingValve(accessory);
                            system.AddComponent(component);
                        }
                        else if (fscType == "MotorizedValve")
                        {
                            component = FlowControllerMapper.MapToMotorizedValve(accessory);
                            system.AddComponent(component);
                        }
                        else
                        {
                            component = FlowControllerMapper.MapToValve(accessory);
                            system.AddComponent(component);
                        }
                    }
                    else
                    {
                        if (fscType == "Fan")
                        {
                            component = MechanicalEquipmentMapper.MapToFan(accessory);

                            system.AddComponent(component);
                        }
                        
                        else if (fscType == "Pump")
                        {
                            component = MechanicalEquipmentMapper.MapToPump(accessory);

                            system.AddComponent(component);
                        }
                        
                        else if (fscType == "HeatExchanger")
                        {
                            List<HeatExchanger> components = EnergyConversionDeviceMapper.MapToHeatExchanger(accessory);

                            foreach (HeatExchanger comp in components)
                            {
                                system.AddComponent(comp);

                                if (((FamilyInstance)element).Space == null) continue;

                                component.ContainedInSpaces.Add(((FamilyInstance)element).Space.Id.ToString());
                                continue;
                            }
                        }

                        else if (fscType.ToLower().Contains("sensor"))
                        {
                            component = FittingMapper.MapFittingReduction(accessory);

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
                        component = MechanicalEquipmentMapper.MapToRadiator(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "Fan")
                    {
                        component = MechanicalEquipmentMapper.MapToFan(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "Pump")
                    {
                        component = MechanicalEquipmentMapper.MapToPump(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "Shunt")
                    {
                        component = MechanicalEquipmentMapper.MapToShunt(mechanicalEquipment);

                        system.AddComponent(component);
                    }
                    else if (fscType == "HeatExchanger")
                    {
                        List<HeatExchanger> components = EnergyConversionDeviceMapper.MapToHeatExchanger(mechanicalEquipment);
                        
                        foreach (HeatExchanger comp in components)
                        {
                            system.AddComponent(comp);
                        }
                    }
                }
                else if (elementCategory == "Air Terminals")
                {
                    MEPModel terminal = ((FamilyInstance)element).MEPModel;

                    string fscType = HelperFunctions.GetFSCType(element);

                    if (fscType == "AirTerminal")
                    {
                        component = TerminalMapper.MapToAirTerminal(terminal);

                        system.AddComponent(component);
                    }
                }

                try
                {
                    if (((FamilyInstance)element).Space == null) continue;

                    component.ContainedInSpaces.Add(((FamilyInstance)element).Space.Id.ToString());
                }
                catch
                {

                    continue;
                }

            }

            return system;
        }



    }
}
