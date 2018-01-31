using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEngine.Streamer;

namespace TradeEngine
{
    public class CustomIndexListener
    {
        public String Epic { get; set; }
        public L1LsPriceDataTableListener L1LsPriceDataTableListener { get; set; }
    }

    public class AutoTrader
    {
        public List<Trade> Trades { get; set; }
        private Authentication.Session Session;
        private Streamer.Client client;
        private List<CustomIndexListener> L1LsPriceDataTableListenerCollection { get; set; }

        public AutoTrader(Authentication.Session Session)
        {
            Trades = new List<Trade>();
            this.Session = Session;
            abc();

            L1LsPriceDataTableListenerCollection = new List<CustomIndexListener>();
        }

        public void AddTrade(Trade Trade)
        {
            Trades.Add(Trade);
        }

        private void abc()
        {
            client = new Streamer.Client(Session);
            client.CreateConnection();
        }

        public void EstablishListtentoEpic(String Epic)
        {
            CustomIndexListener autoTradeIndexListeners = new CustomIndexListener();
            autoTradeIndexListeners.Epic = Epic;
            autoTradeIndexListeners.L1LsPriceDataTableListener = new L1LsPriceDataTableListener();

            L1LsPriceDataTableListenerCollection.Add(autoTradeIndexListeners);

            client.SubscribeToIndexMarketData(autoTradeIndexListeners.L1LsPriceDataTableListener, Epic);

            autoTradeIndexListeners.L1LsPriceDataTableListener.Update += L1LsPriceDataTableListener_Update;
        }

        private void L1LsPriceDataTableListener_Update(object sender, UpdateArgs<Streamer.L1LsPriceData> e)
        {
            //Action here to do something when the index value changes
            Console.WriteLine("The time stamp is: " + DateTime.Now.ToUniversalTime().ToString());
            Console.WriteLine("The bid is: " + e.UpdateData.Bid);
            Console.WriteLine("The offer is: " + e.UpdateData.Offer);
            Console.WriteLine("The epic is: " + e.ItemName);
        }

    }
}


///This will monitor trades and execute the appriopriate actions or update them as required.