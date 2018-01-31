using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.Streamer
{
    public class TradeDataOPUResponse
    {
        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("dealIdOrigin")]
        public string DealIdOrigin { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("dealId")]
        public string DealId { get; set; }

        [JsonProperty("dealStatus")]
        public string DealStatus { get; set; }

        [JsonProperty("dealReference")]
        public string DealReference { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("limitLevel")]
        public long? LimitLevel { get; set; }

        [JsonProperty("guaranteedStop")]
        public bool GuaranteedStop { get; set; }

        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("stopLevel")]
        public object StopLevel { get; set; }

        [JsonProperty("trailingStep")]
        public object TrailingStep { get; set; }

        [JsonProperty("trailingStopDistance")]
        public object TrailingStopDistance { get; set; }
    }
}
