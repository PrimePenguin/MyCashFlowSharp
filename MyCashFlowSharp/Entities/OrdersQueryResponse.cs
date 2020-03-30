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
        public string TaxRate { get; set; }

        /// <summary>
        ///  custom named property
        /// </summary>
        [JsonProperty("total")]
        public double? Whole { get; set; }

        [JsonProperty("total_tax")]
        public decimal? TotalTax { get; set; }

        [JsonProperty("total_without_tax")]
        public double? TotalWithoutTax { get; set; }
    }

    public class Comment
    {
        [JsonProperty("order_id")] 
        public string OrderId { get; set; }

        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }

        [JsonProperty("user_id")] 
        public string UserId { get; set; }

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

    public class OrdersQueryResponse
    {
        [JsonProperty("data")]
        public List<Order> Orders { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
