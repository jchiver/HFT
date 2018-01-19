using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TradeEngine.Model.WorkingOrder
{
    public class CreateWorkingOrderRequest
    {
        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("forceOpen")]
        public object ForceOpen { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("goodTillDate")]
        public object GoodTillDate { get; set; }

        [JsonProperty("guaranteedStop")]
        public string GuaranteedStop { get; set; }

        [JsonProperty("stopLevel")]
        public String StopLevel { get; set; }

        [JsonProperty("stopDistance")]
        public string StopDistance { get; set; }

        [JsonProperty("limitLevel")]
        public object LimitLevel { get; set; }

        [JsonProperty("limitDistance")]
        public object LimitDistance { get; set; }
    }

}
