using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class GetOrderQueryResponse
    {
        [JsonProperty("data")]
        public Order Order { get; set; }
    }
}
