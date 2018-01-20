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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void OnSessionStarted(bool isPolling)
        {
            Console.WriteLine("LS Connection Session Started, IsPoling = " + isPolling.ToString());
        }
    }
}
