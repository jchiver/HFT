using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TradeEngine.Authentication
{
    public class SessionRequest
    {
        /// <summary>
        /// Username of the IG API Account
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("encryptedPassword")]
        public object EncryptedPassword { get; set; }
    }
}
