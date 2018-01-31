using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.Streamer
{
    public class TradeDataConfirmResponse
    {
        [JsonProperty("direction")]
        public string direction { get; set; }
        [JsonProperty("epic")]
        public string epic { get; set; }
        [JsonProperty("stopLevel")]
        public string stopLevel { get; set; }
        [JsonProperty("limitLevel")]
        public string limitLevel { get; set; }
        [JsonProperty("dealReference")]
        public string dealReference { get; set; }
        [JsonProperty("dealId")]
        public string dealId { get; set; }
        [JsonProperty("limitDistance")]
        public string limitDistance { get; set; }
        [JsonProperty("stopDistance")]
        public string stopDistance { get; set; }
        [JsonProperty("expiry")]
        public string expiry { get; set; }
        [JsonProperty("affectedDeals")]
        public List<AffectedDeal> affectedDeals { get; set; }
        [JsonProperty("dealStatus")]
        public string dealStatus { get; set; }
        [JsonProperty("guaranteedStop")]
        public bool guaranteedStop { get; set; }
        [JsonProperty("trailingStop")]
        public bool trailingStop { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("size")]
        public string size { get; set; }
        [JsonProperty("profit")]
        public string profit { get; set; }
        [JsonProperty("profitCurrency")]
        public string profitCurrency { get; set; }
        [JsonProperty("date")]
        public String date { get; set; }
        [JsonProperty("channel")]
        public string channel { get; set; }
    }

    public class AffectedDeal
    {
        public string dealId { get; set; }
        public string status { get; set; }
    }
}
