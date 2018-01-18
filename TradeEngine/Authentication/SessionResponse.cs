using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TradeEngine.Authentication
{
    public partial class SessionResponse
    {
        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("accountInfo")]
        public AccountInfo AccountInfo { get; set; }

        [JsonProperty("currencyIsoCode")]
        public string CurrencyIsoCode { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [JsonProperty("lightstreamerEndpoint")]
        public string LightstreamerEndpoint { get; set; }

        [JsonProperty("accounts")]
        public Account[] Accounts { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("timezoneOffset")]
        public long TimezoneOffset { get; set; }

        [JsonProperty("hasActiveDemoAccounts")]
        public bool HasActiveDemoAccounts { get; set; }

        [JsonProperty("hasActiveLiveAccounts")]
        public bool HasActiveLiveAccounts { get; set; }

        [JsonProperty("trailingStopsEnabled")]
        public bool TrailingStopsEnabled { get; set; }

        [JsonProperty("reroutingEnvironment")]
        public object ReroutingEnvironment { get; set; }

        [JsonProperty("dealingEnabled")]
        public bool DealingEnabled { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }

    public partial class AccountInfo
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("deposit")]
        public long Deposit { get; set; }

        [JsonProperty("profitLoss")]
        public long ProfitLoss { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("preferred")]
        public bool Preferred { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }
    }

}
