using System;
using System.Collections.Generic;
using MyCashFlowSharp.Helpers;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Variation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("purchase_price")]
        public string PurchasePrice { get; set; }

        [JsonProperty("weight")]
        public double? Weight { get; set; }

        //[JsonConverter(typeof(CustomAttributeArrayValueConverter))]
        [JsonProperty("stock_item", NullValueHandling = NullValueHandling.Ignore)]
        public StockItem StockItem { get; set; }
    }
}
