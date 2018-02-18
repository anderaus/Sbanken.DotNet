using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sbanken.DotNet.Models
{
    public class PhoneNumber
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}