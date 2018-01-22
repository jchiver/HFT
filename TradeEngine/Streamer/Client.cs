using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightstreamer.DotNet.Client;

namespace TradeEngine.Streamer
{
    public class Client : IConnectionListener
    {

        private LSClient lsClient;
        private ConnectionInfo connectionInfo;
        private Authentication.Session Session;

        public Client(Authentication.Session Session)
        {
            this.Session = Session;
        }

        public void CreateConnection()
        {
            try
            {

                lsClient = new LSClient();

                connectionInfo = new ConnectionInfo();
                connectionInfo.Adapter = "DEFAULT";
                connectionInfo.User = Session.Username;
                connectionInfo.Password = string.Format("CST-{0}|XST-{1}", Session.CST, Session.X_SECURITY_TOKEN);
                connectionInfo.PushServerUrl = Session.Response.Response.LightstreamerEndpoint;

                lsClient.OpenConnection(connectionInfo, this);

            }
            catch (Exception ex)
            {
                Console.WriteLine("LS Connection Failed");
            }
        }

        public void EstablishListtentoEpic(String Epic)
        {
            //IndexListener = new Listener<IndexUpdateHandler>();
            L1LsPriceDataTableListener l1LsPriceDataTableListener = new L1LsPriceDataTableListener();

            SubscribeToIndexMarketData(l1LsPriceDataTableListener, Epic);

            l1LsPriceDataTableListener.Update += L1LsPriceDataTableListener_Update;
        }

        private void L1LsPriceDataTableListener_Update(object sender, UpdateArgs<L1LsPriceData> e)
        {
            Console.WriteLine("The time stamp is: " + DateTime.Now.ToUniversalTime().ToString());
            Console.WriteLine("The bid is: " + e.UpdateData.Bid);
            Console.WriteLine("The offer is: " + e.UpdateData.Offer);
            Console.WriteLine("The offer is: " + e.ItemName);
        }

        public SubscribedTableKey SubscribeToIndexMarketData(IHandyTableListener iHandyTableListener, String Epic)
        {
            String Trade = "MARKET:" + Epic;
            String[] Items = new String[] { Trade };
            String[] Fields = new string[] { "BID", "OFFER", "UPDATE_TIME" };

            ExtendedTableInfo extendedTableInfo = new ExtendedTableInfo(Items, "MERGE", Fields, true);

            return lsClient.SubscribeTable(extendedTableInfo, iHandyTableListener, false);
        }

        public void OnActivityWarning(bool warningOn)
        {
            throw new NotImplementedException();
        }

        public void OnClose()
        {
            throw new NotImplementedException();
        }

        public void OnConnectionEstablished()
        {
            Console.WriteLine("LS Connection Established");
        }

        public void OnDataError(PushServerException e)
        {
            throw new NotImplementedException();
        }

        public void OnEnd(int cause)
        {
            //throw new NotImplementedException();
        }

        public void OnFailure(PushServerException e)
        {
            throw new NotImplementedException();
        }

        public void OnFailure(PushConnException e)
        {
            throw new NotImplementedException();
        }

        public void OnNewBytes(long bytes)
        {
            //throw new NotImplementedException();
        }

        public void OnSessionStarted(bool isPolling)
        {
            Console.WriteLine("LS Connection Session Started, IsPoling = " + isPolling.ToString());
        }
    }
}
