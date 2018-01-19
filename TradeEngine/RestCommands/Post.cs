using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine.RestCommands
{
    public class Post
    { 
        public enum CommandType
        {
            Get,
            Post,
            Delete
        }

        private void SetDefaultHeaders(HttpClient HttpClient, Authentication.Session session, String Version)
        {

            if (session.API_Key != string.Empty)
            {
                HttpClient.DefaultRequestHeaders.Add("X-IG-API-KEY", session.API_Key);
            }

            if (session.X_SECURITY_TOKEN != string.Empty)
            {
                HttpClient.DefaultRequestHeaders.Add("X-SECURITY-TOKEN", session.X_SECURITY_TOKEN);
            }

            if (session.CST != string.Empty)
            {
                HttpClient.DefaultRequestHeaders.Add("CST", session.CST);
            }

            HttpClient.DefaultRequestHeaders.Add("VERSION", Version);

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IGResponse<T>> Execute<T>(String URL, Authentication.Session Session, CommandType commandType, String Version, Object ContentBody = null)
        {

            HttpContent SendContent = null;

            if (ContentBody != null)
            {
                String SerializeObject = JsonConvert.SerializeObject(ContentBody);

                SendContent = new StringContent(SerializeObject,
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header
            }

            using (HttpClient c = new HttpClient())
            {

                SetDefaultHeaders(c, Session, Version);

                 HttpResponseMessage response = new HttpResponseMessage();

                switch (commandType)
                {
                    case CommandType.Get:
                        response = c.GetAsync(URL).Result;
                        break;
                    case CommandType.Post:
                        response = c.PostAsync(URL, SendContent).Result;
                        break;
                    case CommandType.Delete:
                        response = c.DeleteAsync(URL).Result;
                        break;
                }

                using (HttpContent ReceivedContent = response.Content)
                {
                    string mycontent = await ReceivedContent.ReadAsStringAsync();//.result ;

                    IGResponse<T> iGResponse = new IGResponse<T>();

                    iGResponse.Response = JsonConvert.DeserializeObject<T>(mycontent);
                    iGResponse.StatusCode = response.StatusCode;
                    iGResponse.httpHeaders = response.Headers;

                    return iGResponse;

                }

            }
        }
        
    }
}
