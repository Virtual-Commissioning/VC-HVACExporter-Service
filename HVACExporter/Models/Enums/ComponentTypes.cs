using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HVACExporter.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentTypes
    {
        Bend,
        FlowController,
        FlowMovingDevice,
        HeatExchanger,
        Radiator,
        Reduction,
        Segment,
        Tee
    }
}
