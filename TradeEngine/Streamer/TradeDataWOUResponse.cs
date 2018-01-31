using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.Streamer
{
    public class TradeDataWOUResponse
    {
        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("dealReference")]
        public string DealReference { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("dealId")]
        public string DealId { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("dealStatus")]
        public string DealStatus { get; set; }

        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("limitDistance")]
        public long? LimitDistance { get; set; }

        [JsonProperty("guaranteedStop")]
        public bool GuaranteedStop { get; set; }

        [JsonProperty("goodTillDate")]
        public object GoodTillDate { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("stopDistance")]
        public object StopDistance { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
