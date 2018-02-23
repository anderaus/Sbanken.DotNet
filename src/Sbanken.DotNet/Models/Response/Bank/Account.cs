using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response.Bank
{
    public class Account
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; protected set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; protected set; }

        [JsonProperty("ownerCustomerId")]
        public string OwnerCustomerId { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("accountType")]
        public string AccountType { get; protected set; }

        [JsonProperty("available")]
        public decimal Available { get; protected set; }

        [JsonProperty("balance ")]
        public decimal Balance { get; protected set; }

        [JsonProperty("creditLimit ")]
        public decimal CreditLimit { get; protected set; }

        [JsonProperty("defaultAccount")]
        public bool DefaultAccount { get; protected set; }
    }
}