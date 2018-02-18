using Newtonsoft.Json;

namespace Sbanken.DotNet.Models
{
    public class CustomerResult
    {
        [JsonProperty("item")]
        public Customer Item { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("isError")]
        public bool IsError { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }
    }
}