using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sbanken.DotNet.Models.Response
{
    public class ListResult<T> : IResult
    {
        [JsonProperty("availableItems")]
        public int AvailableItems { get; set; }

        [JsonProperty("items")]
        public IReadOnlyList<T> Items { get; set; }

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