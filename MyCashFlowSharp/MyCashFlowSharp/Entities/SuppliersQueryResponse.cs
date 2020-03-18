using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Supplier
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class SuppliersQueryResponse
    {
        [JsonProperty("data")]
        public List<Supplier> Suppliers { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
