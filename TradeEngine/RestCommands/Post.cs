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
        public async Task<IGResponse<T>> Execute<T>(String URL, String Content, List<String> CustomHeaders)
        {

            HttpContent SendContent = new StringContent(Content,
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            using (HttpClient c = new HttpClient())
            {
                foreach (String S in CustomHeaders)
                {
                    String[] t = S.Split(':');
                    c.DefaultRequestHeaders.Add(t[0],t[1]);
                }

                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                using (HttpResponseMessage response = c.PostAsync(URL, SendContent).Result)
                {

                    using (HttpContent ReceivedContent = response.Content)
                    {
                        string mycontent = await ReceivedContent.ReadAsStringAsync();//.result ;

                        IGResponse<T> iGResponse = new IGResponse<T>();

                        iGResponse.Response = JsonConvert.DeserializeObject<T>(mycontent);
                        iGResponse.StatusCode = response.StatusCode;
                        iGResponse.httpHeaders = response.Headers;

                        return iGResponse;

                        //SessionDetails = JsonConvert.DeserializeObject<Security.PostSessionResponse>(mycontent);

                        //HttpHeaders ReceivedHeaders = response.Headers;

                        //IEnumerable<string> headerValuesA = ReceivedHeaders.GetValues("CST");
                        //CST = headerValuesA.FirstOrDefault();

                        //IEnumerable<string> headerValuesB = ReceivedHeaders.GetValues("X-SECURITY-TOKEN");
                        //X_SECURITY_TOKEN = headerValuesB.FirstOrDefault();

                        //OnStatusUpdated(SessionLogonStatusEventArgs.eStatus.Successful);
                    }

                }
            }
        }
        
    }
}
