using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Shipment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("completed_at")]
        public string CompletedAt { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shipping_method_id")]
        public string ShippingMethodId { get; set; }

        [JsonProperty("weight")]
        public double? Weight { get; set; }

        [JsonProperty("parcel_count")]
        public string ParcelCount { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("external_pickup_postring_id")]
        public string ExternalPickupPostringId { get; set; }

        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("shipping_label_url")]
        public object ShippingLabelUrl { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }

    public class ShipmentsQueryResponse
    {
        [JsonProperty("data")]
        public Shipment Shipment { get; set; }
    }

    public enum ShipmentStatus
    {
        OPEN,
        COMPLETED,
    }
}
