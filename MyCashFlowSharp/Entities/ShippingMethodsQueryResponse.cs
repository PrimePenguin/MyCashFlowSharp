using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class ShippingMethod
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("service_provider")]
        public string ServiceProvider { get; set; }

        [JsonProperty("service_code")]
        public string ServiceCode { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tracking_info")]
        public string TrackingInfo { get; set; }

        [JsonProperty("free_shipping_threshold")]
        public int FreeShippingThreshold { get; set; }

        [JsonProperty("sort")]
        public int Sort { get; set; }
    }


    public class ShippingMethodsQueryResponse
    {
        [JsonProperty("data")]
        public List<ShippingMethod> ShippingMethods { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
