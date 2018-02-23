using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response.Customers
{
    public class PhoneNumber
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}