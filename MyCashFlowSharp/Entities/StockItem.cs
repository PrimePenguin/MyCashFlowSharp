using System;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class StockItem
    {
        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("created_at")] 
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")] 
        public string UpdatedAt { get; set; }

        [JsonProperty("sku")] 
        public string Sku { get; set; }

        [JsonProperty("barcode")] 
        public string Barcode { get; set; }

        [JsonProperty("location")] 
        public string Location { get; set; }

        [JsonProperty("enabled")] 
        public bool Enabled { get; set; }

        [JsonProperty("quantity")] 
        public string Quantity { get; set; }

        [JsonProperty("balance_limit")]
        public string BalanceLimit { get; set; }

        [JsonProperty("backorder_enabled")] 
        public bool BackOrderEnabled { get; set; }

        [JsonProperty("backorder_estimate")]
        public string BackOrderEstimate { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("reserved")]
        public string Reserved { get; set; }

        [JsonProperty("code")] 
        public string Code { get; set; }

        [JsonProperty("product_id")] 
        public string ProductId { get; set; }

        [JsonProperty("variation_id")] 
        public string VariationId { get; set; }

        [JsonProperty("balance_alert")] 
        public string BalanceAlert { get; set; }
    }

    public class StocksQueryResponse
    {
        [JsonProperty("data")]
        public StockItem StockItem { get; set; }
    }
}
