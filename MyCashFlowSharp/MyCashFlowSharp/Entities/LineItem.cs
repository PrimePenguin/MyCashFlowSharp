using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class LineItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("delivered_at")]
        public DateTime DeliveredAt { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("variation_id")]
        public int VariationId { get; set; }

        [JsonProperty("download_id")]
        public string DownloadId { get; set; }

        [JsonProperty("download_time_ends")]
        public string DownloadTimeEnds { get; set; }

        [JsonProperty("download_times_left")]
        public string DownloadTimesLeft { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("customizations")]
        public string Customizations { get; set; }

        [JsonProperty("vat_rate")]
        public int VatRate { get; set; }

        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("model_name")]
        public string ModelName { get; set; }

        [JsonProperty("warranty")]
        public string Warranty { get; set; }

        [JsonProperty("custom_data")]
        public string CustomData { get; set; }

        [JsonProperty("shipment_id")]
        public string ShipmentId { get; set; }

        [JsonProperty("return_to_stock")] 
        public object ReturnToStock { get; set; }

        [JsonProperty("return_reasons")] 
        public List<object> ReturnReasons { get; set; }
    }
}
