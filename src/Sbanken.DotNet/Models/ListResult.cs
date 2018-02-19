using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sbanken.DotNet.Models
{
    public class ListResult<T>
    {
        [JsonProperty("availableItems")]
        public int AvailableItems { get; set; }

        [JsonProperty("items")]
        public IEnumerable<T> Items { get; set; }

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