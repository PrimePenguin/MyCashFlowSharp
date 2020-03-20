using System;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class PaymentQueryResponse
    {
        [JsonProperty("data")]
        public Payment Payment { get; set; }
    }
}
