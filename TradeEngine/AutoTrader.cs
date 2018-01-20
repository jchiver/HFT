using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEngine
{
    public class AutoTrader
    {
        public List<Trade> Trades { get; set; }

        public AutoTrader()
        {
            Trades = new List<Trade>();
        }

        public void AddTrade(Trade Trade)
        {
            Trades.Add(Trade);
        }
    }
}


///This will monitor trades and execute the appriopriate actions or update them as required.