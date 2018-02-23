using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response.Customers
{
    public class Address
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; protected set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; protected set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; protected set; }

        [JsonProperty("addressLine4")]
        public string AddressLine4 { get; protected set; }

        [JsonProperty("country")]
        public string Country { get; protected set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; protected set; }

        [JsonProperty("city")]
        public string City { get; protected set; }
    }
}