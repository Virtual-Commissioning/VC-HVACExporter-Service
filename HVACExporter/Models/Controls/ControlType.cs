using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HVACExporter.Models.Controls
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ControlTypes
    {
        P,
        PI,
        IO,
        Slave,
        Constant
    }
}

