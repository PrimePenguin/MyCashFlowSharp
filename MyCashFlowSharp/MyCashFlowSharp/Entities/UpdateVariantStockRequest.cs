using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class UpdateVariantStockRequest
    {
        /// <summary>
        ///  barcode of the variant
        /// </summary>
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        ///  location of the variant stock
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Determines, whether stock management is enabled for the stock item.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The current amount of items in stock. Used to calculate the balance.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Amount of reservations. Read-only.
        /// </summary>
        [JsonProperty("reserved")]
        public int Reserved { get; set; }

        /// <summary>
        /// This field only contains data, if the stock item has been attached to a product or variation.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Determines whether to use stock alert with this sotck item.
        /// </summary>
        [JsonProperty("balance_alert")]
        public bool BalanceAlert { get; set; }

        /// <summary>
        /// The number of items that will trigger the stock alarm, if balance_alert is set to true.
        /// </summary>

        [JsonProperty("balance_limit")]
        public int BalanceLimit { get; set; }

        /// <summary>
        /// Determines whether the item will be kept on sale, after its stock has run out.
        /// </summary>
        [JsonProperty("backorder_enabled")]
        public bool BackOrderEnabled { get; set; }

        /// <summary>
        /// The alternative delivery time estimate, when the stock item has run out, and backorders are enabled.
        /// </summary>
        [JsonProperty("backorder_estimate")]
        public string BackOrderEstimate { get; set; }
    }
}
