using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEngine
{
    public class TradeAttributes
    {
        public String CurrencyCode { get; set; }
        public String Direction { get; set; }
        public String Epic { get; set; }
        public String Expiry { get { return "DFB"; } }
        public Boolean ForceOpen { get { return true; } }
        public String GoodTillDate { get { return null; } }
        public String GuaranteedStop { get; set; }
        public String Level { get; set; }
        public String LimitDistance { get; set; }
        public String LimitLevel { get { return null; } }
        public String Size { get; set; }
        public String StopDistance { get; set; }
        public String StopLevel { get { return null; } }
        public String TimeInForce { get { return "GOOD_TILL_CANCELLED"; } }
        public String Type { get; set; }
    }
}
