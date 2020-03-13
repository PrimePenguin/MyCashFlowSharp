using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class ShipmentsQueryResponse
    {
        [JsonProperty("data")]
        public Shipment Shipment { get; set; }
    }
}
