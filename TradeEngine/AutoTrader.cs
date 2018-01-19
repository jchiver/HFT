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

        public void AddTrade()
        {
            //Trades.Add(new Trade());
        }
    }
}
