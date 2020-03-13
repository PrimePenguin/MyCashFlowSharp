using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Shipment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shipping_method_id")]
        public int ShippingMethodId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("parcel_count")]
        public int ParcelCount { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("external_pickup_point_id")]
        public string ExternalPickupPointId { get; set; }

        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("shipping_label_url")]
        public object ShippingLabelUrl { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }
}
