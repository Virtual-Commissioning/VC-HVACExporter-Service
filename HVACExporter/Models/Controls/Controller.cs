namespace HVACExporter.Models.Controls
{
    public class Controller
    {
        public string ControllerId { get; set; }
        public string Type { get; set; }
        public double Setpoint { get; set; }
        public string ProcessVariableComponentTag { get; set; }
        public string ProcessVariableParameterType { get; set; }

        public Controller(string controllerId, string type, double setpoint,
                          string processVariableComponentTag, string processVariableParameterType)
        {
            ControllerId = controllerId;
            Type = type;
            Setpoint = setpoint;
            ProcessVariableComponentTag = processVariableComponentTag;
            ProcessVariableParameterType = processVariableParameterType;
        }
    }
}
