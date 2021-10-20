using System.Collections.Generic;
using Autodesk.Revit.DB;
using HVACExporter.Models.Controls;
using HVACExporter.Models.Controls.PumpControllerSubclasses;

namespace HVACExporter.Models.ComponentSubclasses.FlowMovingDeviceSubclasses
{
    public class Pump : FlowMovingDevice
    {
        public Dictionary<double, double> PressureCurve { get; set; } = new Dictionary<double, double>();
        public Dictionary<double, double> PowerCurve { get; set; } = new Dictionary<double, double>();
        public PumpController Control { get; set; }

        public Pump(string id, string tag, string systemName, string systemType, PumpController control)
            : base(id, tag, systemName, systemType)
        {
            Control = control;
            ComponentType = this.GetType().Name;
        }
        public static PumpController GetPumpController(MEPModel pump)
        {
            string controlType = pump.ConnectorManager.Owner.LookupParameter("FSC_pumpControlType").AsString();
            double setpoint = pump.ConnectorManager.Owner.LookupParameter("FSC_pumpControlSetting").AsDouble();

            PumpController pumpController = new PumpController();

            switch (controlType.ToLower())
            {
                case "constantspeed":
                    pumpController = new ConstantSpeedControl(setpoint);
                    break;

                case "constantpressure":
                    pumpController = new ConstantPressureControl(setpoint);
                    break;

                case "proportionalpressure":
                    pumpController = new ProportionalPressureControl();
                    break;

                case "external":
                    string controllerType = pump.ConnectorManager.Owner.LookupParameter("FSC_controlType").AsString();
                    double controllerSetPoint = pump.ConnectorManager.Owner.LookupParameter("FSC_controlSetPoint").AsDouble();
                    string processVariableComponentTag = pump.ConnectorManager.Owner.LookupParameter("FSC_controlTarget").AsString();
                    string processVariableParameterType = pump.ConnectorManager.Owner.LookupParameter("FSC_controlProcessVariable").AsString();

                    Controller controller = new Controller(controllerType,
                                                controllerSetPoint,
                                                processVariableComponentTag,
                                                processVariableParameterType);
                    pumpController = new ExternalControl(controller);
                    break;
            }
            return pumpController;
        }
    }
}
