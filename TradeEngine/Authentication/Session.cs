using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace TradeEngine.Authentication
{
    public class Session
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String API_Key { get; set; }

        public String BaseURL { get; set; }

        public String CST { get; set; }

        public String X_SECURITY_TOKEN { get; set; }

        RestCommands.IGResponse<SessionResponse> Response;


        public Session(String Username, String Password, String API_Key, String URL)
        {
            this.Username = Username;
            this.Password = Password;
            this.API_Key = API_Key;
            this.BaseURL = URL;
        }

        public async void Logon()
        {

            RestCommands.Post Post = new RestCommands.Post();
            RestCommands.IGResponse<SessionResponse> Response = await Post.Execute<SessionResponse>(this.BaseURL + @"/session", GetSerializedSessionRequest(), GenerateCustomHTTPHeaders());

            this.Response = Response;

            HttpHeaders ReceivedHeaders = this.Response.httpHeaders;

            IEnumerable<string> headerValuesA = ReceivedHeaders.GetValues("CST");
            CST = headerValuesA.FirstOrDefault();

            IEnumerable<string> headerValuesB = ReceivedHeaders.GetValues("X-SECURITY-TOKEN");
            X_SECURITY_TOKEN = headerValuesB.FirstOrDefault();

            Console.WriteLine("2");
        }

        private String GetSerializedSessionRequest()
        {
            SessionRequest sessionRequest = new SessionRequest();
            sessionRequest.EncryptedPassword = false;
            sessionRequest.Identifier = Username;
            sessionRequest.Password = Password;

            return JsonConvert.SerializeObject(sessionRequest);
        }

        private List<String> GenerateCustomHTTPHeaders()
        {
            List<String> TempStringList = new List<string>();

            //The  :: acts as the position to split the string when creating the custom headers
            TempStringList.Add("X-IG-API-KEY" + ":" + this.API_Key);
            TempStringList.Add("VERSION" + ":" + "2");

            return TempStringList;
        }


    }
}
