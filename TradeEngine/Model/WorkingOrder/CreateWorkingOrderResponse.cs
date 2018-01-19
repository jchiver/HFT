﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.Model.WorkingOrder
{
    public class CreateWorkingOrderResponse
    {
        [JsonProperty("dealReference")]
        public string DealReference { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
