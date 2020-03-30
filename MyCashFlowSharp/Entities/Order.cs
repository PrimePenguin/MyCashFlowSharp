using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("archived_at")]
        public string ArchivedAt { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("version_id")]
        public string VersionId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_external_id")]
        public string CustomerExternalId { get; set; }

        [JsonProperty("shipping_method_id")]
        public int ShippingMethodId { get; set; }

        [JsonProperty("payment_method_id")]
        public int PaymentMethodId { get; set; }

        [JsonProperty("customer_information")]
        public CustomerInformation CustomerInformation { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("different_shipping_address")]
        public bool DifferentShippingAddress { get; set; }

        [JsonProperty("subtotal")]
        public string SubTotal { get; set; }

        [JsonProperty("shipping_costs")]
        public string ShippingCosts { get; set; }

        [JsonProperty("payment_costs")]
        public double? PaymentCosts { get; set; }

        [JsonProperty("discount")]
        public object Discount { get; set; }

        [JsonProperty("total")]
        public double? Total { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; set; }

        [JsonProperty("return_document_url")]
        public string ReturnDocumentUrl { get; set; }

        [JsonProperty("dispatch_note_url")]
        public string DispatchNoteUrl { get; set; }

        [JsonProperty("custom_data")]
        public string CustomData { get; set; }

        [JsonProperty("products")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("shipments")]
        public List<Shipment> Shipments { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [JsonProperty("tax_summary")]
        public TaxSummary TaxSummary { get; set; }
    }
}
