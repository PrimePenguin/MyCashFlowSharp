using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class CancelOrderQueryResponse
    {
        [JsonProperty("data")]
        public Order Order { get; set; }
    }
}
