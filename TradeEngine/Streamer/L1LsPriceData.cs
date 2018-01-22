using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEngine.Streamer
{
    public class L1LsPriceData
    {
        public decimal? MidOpen;
        public decimal? High;
        public decimal? Low;
        public decimal? Change;
        public decimal? ChangePct;
        //public string UpdateTime;
        public DateTime? UpdateTime;
        public int? MarketDelay;
        public string MarketState;
        public decimal? Bid;
        public decimal? Offer;
    }
}
