using System;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Payment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("external_id")]
        public object ExternalId { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange_rate")]
        public string ExchangeRate { get; set; }

        [JsonProperty("is_confirmed")]
        public bool IsConfirmed { get; set; }

        [JsonProperty("is_paid")]
        public bool IsPaid { get; set; }

        /// <summary>
        /// Open:  Only when using a payment link (Checkout and Klarna) and the payment has not been carried out.<para></para>
        /// PENDING_ACTIVATION:  The payment has been received, but it has not been activated yet (only with Klarna). Used also with payment links, when the payment has been carried out.<para></para>
        /// PAID:  The payment has been activated.<para></para>
        /// REFUNDED:  The payment has been refunded in full, after it had been activated.<para></para>
        /// CANCELLED:  Payment has been cancelled, before it was activated.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
