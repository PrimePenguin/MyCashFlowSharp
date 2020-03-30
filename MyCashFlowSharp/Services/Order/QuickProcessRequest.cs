using Newtonsoft.Json;

namespace MyCashFlowSharp.Services.Order
{
    public class QuickProcessRequest
    {
        /// <summary>
        /// Allow use of cash-on-deliver payment type when quick processing the order. If set to false, the quick processing will fail.
        /// </summary>
        [JsonProperty("allow_open_cash_on_delivery_payments")]
        public bool AllowOpenCashOnDeliveryPayments { get; set; }

        /// <summary>
        /// Determines whether any errors activating payments should be ignored. Use this option, if the order has a Klarna payment that has been processed in Klarna Online.
        /// </summary>
        [JsonProperty("ignore_payment_activation_errors")]
        public bool IgnorePaymentActivationErrors { get; set; }

        /// <summary>
        /// The tracking code for the order.
        /// </summary>
        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Determines whether to automatically send the shipping confirmation email upon successful processing.
        /// </summary>
        [JsonProperty("send_emails")]
        public bool SendEmails { get; set; }
    }
}
