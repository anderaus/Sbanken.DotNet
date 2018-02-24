using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response.Bank
{
    public class Account
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("ownerCustomerId")]
        public string OwnerCustomerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("balance ")]
        public decimal Balance { get; set; }

        [JsonProperty("creditLimit ")]
        public decimal CreditLimit { get; set; }

        [JsonProperty("defaultAccount")]
        public bool DefaultAccount { get; set; }
    }
}