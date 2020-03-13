using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Subtotal : Total
    {
    }

    public class OrderDiscount : Total
    {
    }

    public class ShippingCost : Total
    {
    }

    public class PaymentCost : Total
    {
    }
    public class Total
    {
        [JsonProperty("tax_rate")]
        public int TaxRate { get; set; }

        /// <summary>
        ///  custom named property
        /// </summary>
        [JsonProperty("total")]
        public double Whole { get; set; }

        [JsonProperty("total_tax")]
        public double TotalTax { get; set; }

        [JsonProperty("total_without_tax")]
        public double TotalWithoutTax { get; set; }
    }
    public class Document
    {
        [JsonProperty("type")] 
        public string Type { get; set; }

        [JsonProperty("url")] 
        public string Url { get; set; }
    }

    public class Comment
    {
        [JsonProperty("order_id")] 
        public int OrderId { get; set; }

        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }

        [JsonProperty("user_id")] 
        public int UserId { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("text")] 
        public string Text { get; set; }
    }

    public class Event
    {
        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Anonymous type, will contain the cart information
        /// </summary>
        [JsonProperty("data")] 
        public object Data { get; set; }
    }


    public class TaxSummary
    {
        [JsonProperty("subtotal")]
        public List<Subtotal> SubTotal { get; set; }

        [JsonProperty("discount")]
        public List<OrderDiscount> Discount { get; set; }

        [JsonProperty("shipping_costs")]
        public List<ShippingCost> ShippingCosts { get; set; }

        [JsonProperty("payment_costs")]
        public List<PaymentCost> PaymentCosts { get; set; }

        [JsonProperty("total")]
        public List<Total> Total { get; set; }
    }

    public class Orders
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("archived_at")]
        public string ArchivedAt { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("version_id")]
        public int VersionId { get; set; }

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
        public int SubTotal { get; set; }

        [JsonProperty("shipping_costs")]
        public int ShippingCosts { get; set; }

        [JsonProperty("payment_costs")]
        public double PaymentCosts { get; set; }

        [JsonProperty("discount")]
        public object Discount { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

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

    public class OrdersQueryResponse
    {
        [JsonProperty("data")]
        public List<Orders> Orders { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
