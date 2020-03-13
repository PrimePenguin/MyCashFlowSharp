using System;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class StockItem
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] 
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("sku")] 
        public string Sku { get; set; }

        [JsonProperty("barcode")] 
        public string Barcode { get; set; }

        [JsonProperty("location")] 
        public string Location { get; set; }

        [JsonProperty("enabled")] 
        public bool Enabled { get; set; }

        [JsonProperty("quantity")] 
        public int Quantity { get; set; }

        [JsonProperty("balance_limit")]
        public string BalanceLimit { get; set; }

        [JsonProperty("backorder_enabled")] 
        public bool BackorderEnabled { get; set; }

        [JsonProperty("backorder_estimate")]
        public string BackorderEstimate { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        [JsonProperty("reserved")]
        public int Reserved { get; set; }

        [JsonProperty("code")] 
        public string Code { get; set; }

        [JsonProperty("product_id")] 
        public int ProductId { get; set; }

        [JsonProperty("variation_id")] 
        public string VariationId { get; set; }

        [JsonProperty("balance_alert")] 
        public string BalanceAlert { get; set; }
    }
}
