using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TradeEngine.Authentication
{
    public class Session
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String API_Key { get; set; }

        public String URL { get; set; }

        RestCommands.IGResponse<SessionResponse> Response;


        public Session(String Username, String Password, String API_Key, String URL)
        {
            this.Username = Username;
            this.Password = Password;
            this.API_Key = API_Key;
            this.URL = URL;
        }

        public async void Logon()
        {

            RestCommands.Post Post = new RestCommands.Post();
            RestCommands.IGResponse<SessionResponse> Response = await Post.Execute<SessionResponse>(this.URL + @"/session", GetSerializedSessionRequest(), GetCustomHTTPHeaders());

            this.Response = Response;

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

        private List<String> GetCustomHTTPHeaders()
        {
            List<String> TempStringList = new List<string>();

            //The  :: acts as the position to split the string when creating the custom headers
            TempStringList.Add("X-IG-API-KEY" + ":" + this.API_Key);
            TempStringList.Add("VERSION" + ":" + "2");

            return TempStringList;
        }


    }
}
