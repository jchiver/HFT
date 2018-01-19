using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.Model.Trading
{
    public class TradeConfirmResponse
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("dealStatus")]
        public string DealStatus { get; set; }

        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("dealReference")]
        public string DealReference { get; set; }

        [JsonProperty("dealId")]
        public string DealId { get; set; }

        [JsonProperty("affectedDeals")]
        public AffectedDeal[] AffectedDeals { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("stopLevel")]
        public object StopLevel { get; set; }

        [JsonProperty("limitLevel")]
        public object LimitLevel { get; set; }

        [JsonProperty("stopDistance")]
        public long StopDistance { get; set; }

        [JsonProperty("limitDistance")]
        public long LimitDistance { get; set; }

        [JsonProperty("guaranteedStop")]
        public bool GuaranteedStop { get; set; }

        [JsonProperty("trailingStop")]
        public bool TrailingStop { get; set; }

        [JsonProperty("profit")]
        public object Profit { get; set; }

        [JsonProperty("profitCurrency")]

        public object ProfitCurrency { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
    public partial class AffectedDeal
    {
        [JsonProperty("dealId")]
        public string DealId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
