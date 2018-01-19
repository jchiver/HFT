using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TradeEngine.Model.WorkingOrder
{
    public class DeleteWorkingOrderResponse
    {
        [JsonProperty("dealReference")]
        public string DealReference { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
