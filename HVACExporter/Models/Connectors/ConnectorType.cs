using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HVACExporter.Models.Connectors
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConnectorType
    {
        suppliesFluidTo,
        suppliesFluidFrom,
        exchangesFluidWith,
        transferHeatTo,
        transferHeatFrom
    }
}

