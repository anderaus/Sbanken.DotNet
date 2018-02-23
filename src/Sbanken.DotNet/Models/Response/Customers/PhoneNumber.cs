using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response.Customers
{
    public class PhoneNumber
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; protected set; }

        [JsonProperty("number")]
        public string Number { get; protected set; }
    }
}