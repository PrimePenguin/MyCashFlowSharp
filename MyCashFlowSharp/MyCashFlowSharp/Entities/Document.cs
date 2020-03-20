using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Document
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
