using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightstreamer.DotNet.Client;
using Newtonsoft.Json;

namespace TradeEngine.Streamer
{
    public enum TradeSubscriptionType
    {
        Opu,
        Wou,
        Confirm,
    }

    public class TradeData
    {
        public TradeSubscriptionType Type { get; set; }

        public TradeDataConfirmResponse ConfirmResponse { get; set; }

        public TradeDataOPUResponse OPUResponse { get; set; }

        public TradeDataWOUResponse WOUResponse { get; set; }
    }

    public class TradeDataTableListner : TableListenerAdapterBase<TradeData>
    {
        protected override TradeData LoadUpdate(IUpdateInfo update)
        {
            try
            {

                TradeData tradeData = new TradeData();

                var confirms = update.GetNewValue("CONFIRMS");
                var opu = update.GetNewValue("OPU");
                var wou = update.GetNewValue("WOU");

                if (!(String.IsNullOrEmpty(opu)))
                {
                    System.Console.WriteLine("Update type is opu");
                    tradeData.Type = TradeSubscriptionType.Opu;

                    tradeData.OPUResponse = JsonConvert.DeserializeObject<TradeDataOPUResponse>(opu);

                    return tradeData;
                }
                if (!(String.IsNullOrEmpty(wou)))
                {
                    System.Console.WriteLine("Update type is wou");

                    tradeData.Type = TradeSubscriptionType.Wou;

                    tradeData.WOUResponse = JsonConvert.DeserializeObject<TradeDataWOUResponse>(wou);

                    return tradeData;
                }
                if (!(String.IsNullOrEmpty(confirms)))
                {
                    System.Console.WriteLine("Update type is confirms");

                    tradeData.Type = TradeSubscriptionType.Confirm;

                    tradeData.ConfirmResponse = JsonConvert.DeserializeObject<TradeDataConfirmResponse>(confirms);

                    return tradeData;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
