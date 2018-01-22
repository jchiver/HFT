using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightstreamer.DotNet.Client;

namespace TradeEngine.Streamer
{
    public class L1LsPriceDataTableListener : TableListenerAdapterBase<L1LsPriceData>
    {
        protected override L1LsPriceData LoadUpdate(IUpdateInfo update)
        {
            try
            {
                var l1LsPriceData = new L1LsPriceData
                {
                    //If you don't subscribe to the data then you cannot obtain it without an exception
                    //MidOpen = StringToNullableDecimal(update.GetNewValue("MID_OPEN")),
                    Bid = StringToNullableDecimal(update.GetNewValue("BID")),
                    //Change = StringToNullableDecimal(update.GetNewValue("CHANGE")),
                    //ChangePct = StringToNullableDecimal(update.GetNewValue("CHANGE_PCT")),
                    //High = StringToNullableDecimal(update.GetNewValue("HIGH")),
                    //Low = StringToNullableDecimal(update.GetNewValue("LOW")),
                    //MarketDelay = StringToNullableInt(update.GetNewValue("MARKET_DELAY")),
                    //MarketState = update.GetNewValue("MARKET_STATE"),
                    Offer = StringToNullableDecimal(update.GetNewValue("OFFER")),
                    UpdateTime = EpocStringToNullableDateTime(update.GetNewValue("UPDATE_TIME")),
                };
                return l1LsPriceData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
