using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class PaymentMethod
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }

    public class PaymentMethodsQueryResponse
    {
        [JsonProperty("data")]
        public List<PaymentMethod> PaymentMethods { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
