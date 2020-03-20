using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class QuickProcessOrderResponse
    {
        [JsonProperty("data")]
        public Order Order { get; set; }
    }
}
