using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class MetaData
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("item_count")]
        public int ItemCount { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
