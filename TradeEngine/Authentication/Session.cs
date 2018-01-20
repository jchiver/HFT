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

        public RestCommands.IGResponse<SessionResponse> Response { get; set; }


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
            RestCommands.IGResponse<SessionResponse> Response = await Post.Execute<SessionResponse>(this.BaseURL + @"/session", this,RestCommands.Post.CommandType.Post, "2", GetWorkingSessionRequestContent());

            this.Response = Response;

            HttpHeaders ReceivedHeaders = this.Response.httpHeaders;

            IEnumerable<string> headerValuesA = ReceivedHeaders.GetValues("CST");
            CST = headerValuesA.FirstOrDefault();

            IEnumerable<string> headerValuesB = ReceivedHeaders.GetValues("X-SECURITY-TOKEN");
            X_SECURITY_TOKEN = headerValuesB.FirstOrDefault();
        }

        private SessionRequest GetWorkingSessionRequestContent()
        {
            SessionRequest sessionRequest = new SessionRequest();
            sessionRequest.EncryptedPassword = false;
            sessionRequest.Identifier = Username;
            sessionRequest.Password = Password;

            return sessionRequest;
        }
        
        //private List<String> GenerateCustomHTTPHeaders()
        //{
        //    List<String> TempStringList = new List<string>();

        //    //The  :: acts as the position to split the string when creating the custom headers
        //    TempStringList.Add("X-IG-API-KEY" + ":" + this.API_Key);
        //    TempStringList.Add("VERSION" + ":" + "2");

        //    return TempStringList;
        //}


    }
}
