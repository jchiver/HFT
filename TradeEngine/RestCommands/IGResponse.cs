using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TradeEngine.RestCommands
{
    public class IGResponse<T>
    {
        /// <summary>
        /// HTTP Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        public T Response { get; set; }

        /// <summary>
        /// Stores the headers received from the request so they can be processed or used should they need to be
        /// </summary>
        public HttpHeaders httpHeaders { get; set; }

        public void something()
        {

        }
    }
}
